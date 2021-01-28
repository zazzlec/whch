using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LitJson;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SynWHCH;
namespace WHCH.Api.dataoperate
{


    public class Chcompute
    {
        public static double yl_fh_out;
        public static int all_boilerid;
        public static string boiler_name;
        public static DateTime all_syntime;
        public static double dg_zwxs_design;
        public static double pg_zwxs_design;
        public static double mg_zwxs_design;
        public static double dz_zwxs_design;
        public static double gz_zwxs_design;
        public static double fs_zwxs_design;
        public static double zs_zwxs_design;




        /// <summary>
        /// 受热面焓增计算公式
        /// </summary>
        /// <param name="temp"></param>
        /// <param name="press"></param>
        /// <returns></returns>
        public static double Steamhz(double temp, double press)
        {
            temp = temp + 273.15;//℃转成K

            return 2022.7 + 1.6675 * temp + 0.00029593 * Math.Pow(temp, 2) - 1269000000 * press / Math.Pow(temp, 2.7984) - 1.0185 * Math.Pow(10, 23) * Math.Pow(press, 2) / Math.Pow(temp, 8.3207);
        }

        /// <summary>
        /// 空气比热公式
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        public static double Airc(double temp)
        {
            double airc = -2 * Math.Pow(10, -15) * Math.Pow(temp, 5) + 2 * Math.Pow(10, -12) * Math.Pow(temp, 4) - 9 * Math.Pow(10, -10) * Math.Pow(temp, 3) + 3 * Math.Pow(10, -7) * Math.Pow(temp, 2) + 8 * Math.Pow(10, -6) * temp + 1.005;
            return airc;
        }

        /// <summary>
        /// 烟气比热公式
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        public static double Gasc(double temp)
        {
            double gasc = 3 * Math.Pow(10, -17) * Math.Pow(temp, 5) - 9 * Math.Pow(10, -14) * Math.Pow(temp, 4) + 3 * Math.Pow(10, -11) * Math.Pow(temp, 3) + 4 * Math.Pow(10, -8) * Math.Pow(temp, 2) + Math.Pow(10, -4) * temp + 0.9837;
            return gasc;
        }

        /// <summary>
        /// 减温水焓增计算公式
        /// </summary>
        /// <param name="temp"></param>
        /// <param name="press"></param>
        /// <returns></returns>

        public static double Whz(double temp, double press)
        {

            // return 130.06 + 0.947711 * t ^ 1.2521 + p * (0.7234 - 9.2384 * (10 ^ -10) * t ^ 3.6606);
            // var whz = 130.06 + 0.947711 * Math.Pow(temp, 1.2521) + press * (0.7234 - 9.2384 * (10e-10) * Math.Pow(temp, 3.6606));
            var whz = 130.06 + 0.947711 * Math.Pow(temp, 1.2521) + press * (0.7234 - 9.2384 * Math.Pow(10, -10) * Math.Pow(temp, 3.6606));
            return whz;
        }

        /// <summary>
        /// 计算水冷壁一层非周期性吹灰逻辑
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<Chpoint> Chlist(List<Chpoint> list)
        {
            var q = from u in list.ToArray() select u;
            int num = list.Count;
            double dif_sum = 0d;
            double dx_sum = 0d;
            double dx = 0d;
            List<Chpoint> rtlist = new List<Chpoint>();
            for (int i = 0; i < num; i++)
            {
                dif_sum += list[i].Now_temp_dif_Val;
            }
            double avg = Math.Round(dif_sum * 1.0 / num, 4);

            for (int j = 0; j < num; j++)
            {
                double minus = list[j].Now_temp_dif_Val - avg;
                dx_sum += Math.Pow(minus, 2);
            }
            dx = dx_sum / num;

            if (dx > 60)
            {
                rtlist = q.OrderByDescending(x => x.Last_now_dif).Take(4).ToList();

            }
            else if (dx > 40 && dx <= 60)
            {
                rtlist = q.OrderByDescending(x => x.Last_now_dif).Take(6).ToList();
            }
            else if (dx >= 20 && dx <= 40)
            {
                rtlist = q.OrderByDescending(x => x.Last_now_dif).Take(8).ToList();
            }
            else
            {
                rtlist = list;
            }

            return rtlist;

        }

        private static void AddLgoToTXT(string logstring)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "logs/synlog_" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            if (!System.IO.File.Exists(path))
            {
                FileStream stream = System.IO.File.Create(path);
                stream.Close();
                stream.Dispose();
            }
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(logstring);
            }
        }






        /// <summary>
        /// 非周期性，吹灰受热面焓增计算、存储（5分钟/次）
        /// </summary>
        /// <param name="boilerid"></param>
        /// <param name="csyntime"></param>
        public static void Znchtask(int boilerid, DateTime csyntime)
        {

            try
            {

                DBHelper db = new DBHelper();
                //获取锅炉信息
                string sql_boiler = "select Edfh,K_Name_kw from dncboiler where Status=1 and IsDeleted=0 and Id=" + boilerid;
                DataTable dt_boiler = db.GetCommand(sql_boiler);
                if (dt_boiler != null && dt_boiler.Rows.Count > 0)
                {

                    //  DateTime syntime = DateTime.Parse(dt_boiler.Rows[0][0].ToString());

                    int edfh = int.Parse(dt_boiler.Rows[0][0].ToString());
                    boiler_name = dt_boiler.Rows[0][1].ToString();

                    //获取智能吹灰参数配置表信息
                    string sql_ch_para = "select dg_zwxs_design_Val,pg_zwxs_design_Val,mg_zwxs_design_Val,dz_zwxs_design_Val,gz_zwxs_design_Val,fs_zwxs_design_Val,zs_zwxs_design_Val,ctylxs_Val,xs_py_x_modify_Val,wind_temp_in_design_Val,py_temp_in_wind_temp_modify_xs_Val,kyq_yq_ratio_low_Val,mg_wrl_low_Val,gz_wrl_low_Val from dncch_parameter where Status=1 and IsDeleted=0 and DncBoilerId=" + boilerid;
                    DataTable dt_ch_para = db.GetCommand(sql_ch_para);
                    //if (dt_srm_para != null && dt_srm_para.Rows.Count > 0)
                    //{
                    //}
                    dg_zwxs_design = double.Parse(dt_ch_para.Rows[0][0].ToString());//低过设计沾污系数
                    pg_zwxs_design = double.Parse(dt_ch_para.Rows[0][1].ToString());//屏过设计沾污系数
                    mg_zwxs_design = double.Parse(dt_ch_para.Rows[0][2].ToString());//高过设计沾污系数
                    dz_zwxs_design = double.Parse(dt_ch_para.Rows[0][3].ToString());//低再设计沾污系数
                    gz_zwxs_design = double.Parse(dt_ch_para.Rows[0][4].ToString());//高再设计沾污系数
                    fs_zwxs_design = double.Parse(dt_ch_para.Rows[0][5].ToString());//分级省煤器设计沾污系数
                    zs_zwxs_design = double.Parse(dt_ch_para.Rows[0][6].ToString());//主省煤器设计沾污系数
                    double ctylxs = double.Parse(dt_ch_para.Rows[0][7].ToString());//给水泵中间抽头压力系数
                    double xs_py_x_modify = double.Parse(dt_ch_para.Rows[0][8].ToString());//经X比修正后排烟温度变化值系数
                    double wind_temp_in_design = double.Parse(dt_ch_para.Rows[0][9].ToString());//设计进口风温
                    double py_temp_in_wind_temp_modify_xs = double.Parse(dt_ch_para.Rows[0][10].ToString());//经进口风温修正后排烟温度变化值系数
                    double kyq_yq_ratio_low_Val= double.Parse(dt_ch_para.Rows[0][11].ToString());//空预器烟气侧效率下限
                    double mg_wrl_low = double.Parse(dt_ch_para.Rows[0][12].ToString());//高过污染率下限
                    double gz_wrl_low = double.Parse(dt_ch_para.Rows[0][13].ToString());//高再污染率上限



                    //获取dncchhztype表数据
                    string sql_typet = "select Id,K_Name_kw from dncchhztype where  Status=1 and IsDeleted=0";
                    DataTable dt_type = db.GetCommand(sql_typet);
                    Dictionary<int, string> dic_type = new Dictionary<int, string>();   //数据存入词典，方便查找 
                    foreach (DataRow item in dt_type.Rows)
                    {
                        dic_type.Add(int.Parse(item[0].ToString()), item[1].ToString());

                    }


                    //获取测点数据
                    string sql_point = "select DncTypeId,Pvalue from dncchhzpoint where  RealTime = '" + csyntime + "' and DncBoilerId=" + boilerid;
                    DataTable dt_point = db.GetCommand(sql_point);
                    Dictionary<string, string> dic = new Dictionary<string, string>();   //数据存入词典，方便查找           
                    if (dt_point != null && dt_point.Rows.Count > 0)
                    {
                        foreach (DataRow item in dt_point.Rows)
                        {
                            dic.Add(item[0].ToString(), item[1].ToString());

                        }

                        yl_fh_out = Compute.Avgdata(dic["1"]);//实际负荷
                        double flq_press = Compute.Avgdata(dic["2"]);//分离器压力
                        double mg_out_press_left = Compute.Avgdata(dic["3"]);//高过左侧出口压力
                        double mg_out_press_right = Compute.Avgdata(dic["4"]);//高过右侧出口压力
                        double dg_out_qw_left = Compute.Avgdata(dic["5"]);//低过左侧出口汽温测点
                        double dg_out_qw_right = Compute.Avgdata(dic["6"]);//低过右侧出口汽温测点
                        double dg_bw_left = Compute.Avgdata(dic["7"]);//低过左侧壁温测点
                        double dg_bw_right = Compute.Avgdata(dic["8"]);//低过右侧壁温测点
                        double dg_in_temp_left = Compute.Avgdata(dic["9"]);//低过左侧进口温度
                        double dg_in_temp_right = Compute.Avgdata(dic["10"]);//低过右侧进口温度
                        double pg_out_qw_left = Compute.Avgdata(dic["11"]);//屏过左侧出口汽温测点
                        double pg_out_qw_right = Compute.Avgdata(dic["12"]);//屏过右侧出口汽温测点
                        double pg_bw_left = Compute.Avgdata(dic["13"]);//屏过左侧壁温测点
                        double pg_bw_right = Compute.Avgdata(dic["14"]);//屏过右侧壁温测点
                        double pg_in_temp_left = Compute.Avgdata(dic["15"]);//屏过左侧进口温度
                        double pg_in_temp_right = Compute.Avgdata(dic["16"]);//屏过右侧进口温度
                        double mg_out_qw_left = Compute.Avgdata(dic["17"]);//高过左侧出口汽温测点
                        double mg_out_qw_right = Compute.Avgdata(dic["18"]);//高过右侧出口汽温测点
                        double mg_bw_left = Compute.Avgdata(dic["19"]);//高过左侧壁温测点
                        double mg_bw_right = Compute.Avgdata(dic["20"]);//高过右侧壁温测点
                        double mg_in_temp_left = Compute.Avgdata(dic["21"]);//高过左侧进口温度
                        double mg_in_temp_right = Compute.Avgdata(dic["22"]);//高过右侧进口温度
                        double dz_in_press_left = Compute.Avgdata(dic["23"]);//低再左侧入口压力值
                        double dz_in_press_right = Compute.Avgdata(dic["24"]);//低再右侧入口压力值
                        double gz_out_press_left = Compute.Avgdata(dic["25"]);//高再左侧出口压力值
                        double gz_out_press_right = Compute.Avgdata(dic["26"]);//高再右侧出口压力值
                        double dz_out_qw_left = Compute.Avgdata(dic["27"]);//低再左侧出口汽温测点
                        double dz_out_qw_right = Compute.Avgdata(dic["28"]);//低再右侧出口汽温测点
                        double dz_bw_left = Compute.Avgdata(dic["29"]);//低再左侧壁温测点
                        double dz_bw_right = Compute.Avgdata(dic["30"]);//低再右侧壁温测点
                        double dz_in_temp_left = Compute.Avgdata(dic["31"]);//低再左侧进口温度 
                        double dz_in_temp_right = Compute.Avgdata(dic["32"]);//低再右侧进口温度 
                        double gz_out_qw_left = Compute.Avgdata(dic["33"]);//高再左侧出口汽温测点
                        double gz_out_qw_right = Compute.Avgdata(dic["34"]);//高再右侧出口汽温测点
                        double gz_bw_left = Compute.Avgdata(dic["35"]);//高再左侧壁温测点
                        double gz_bw_right = Compute.Avgdata(dic["36"]);//高再右侧壁温测点
                        double gz_in_temp_left = Compute.Avgdata(dic["37"]);//高再左侧进口温度
                        double gz_in_temp_right = Compute.Avgdata(dic["38"]);//高再右侧进口温度
                         // double yq_in_press = Compute.Avgdata(dic["39"]);//烟气侧进口压力
                        double fs_out_temp = Compute.Avgdata(dic["40"]);//分级省煤器出口温度
                        double fs_in_press = Compute.Avgdata(dic["41"]);//分级省煤器进口压力
                        double fs_in_temp = Compute.Avgdata(dic["42"]);//分级省煤器进口温度
                        // double yq_out_press = Compute.Avgdata(dic["43"]);//烟气侧出口压力
                        double zs_out_temp = Compute.Avgdata(dic["44"]);//主省煤器出口温度
                       

                        double fs_out_press = fs_in_press - 0.04; //分级省煤器出口压力
                        double zs_out_press = fs_in_press - 0.12;//主省煤器出口压力
                        double zs_in_press = fs_out_press;//主省煤器进口压力
                        double zs_in_temp = Compute.Avgdata(dic["46"]);//主省煤器进口温度
                        double yrq_in_yw = Compute.Avgdata(dic["47"]);//预热器进口烟温
                       // double yrq_py_temp = Compute.Avgdata(dic["48"]);//排烟温度
                        //double yrq_in_wt1 = Compute.Avgdata(dic["49"]);//预热器进口一次风温
                       // double yrq_in_wt2 = Compute.Avgdata(dic["50"]);//预热器进口二次风温
                        double yrq_yq_pd = Compute.Avgdata(dic["51"]);//实际烟气侧压降
                        double gsll = Compute.Avgdata(dic["52"]);//给水流量
                        double gspress = Compute.Avgdata(dic["53"]);//给水压力
                        double gstemp = Compute.Avgdata(dic["54"]);//给水温度
                        double sgjwq_front_temp_left = Compute.Avgdata(dic["55"]);//事故减温器前温度（左侧）
                        double sgjwq_front_temp_right = Compute.Avgdata(dic["56"]);//事故减温器前温度（右侧）
                        double cql = Compute.Avgdata(dic["57"]);//总抽气量
                        double kyq_in_fw_1 = Compute.Avgdata(dic["58"]);//空预器进口一次风温
                        double kyq_out_fw_1 = Compute.Avgdata(dic["59"]);//空预器出口一次风温
                        double kyq_in_fw_2 = Compute.Avgdata(dic["60"]);//空预器进口二次风温
                        double kyq_out_fw_2 = Compute.Avgdata(dic["61"]);//空预器出口二次风温
                       // double kyq_wind_2 = Compute.Sumdata(dic["62"]) / 3; //空预器二次风量，6个测点求和除以3
                        double kyq_wind_2 = Compute.Avgdata(dic["62"]);//测试环境只有一个测点，直接用
                        double kyq_in_yw = Compute.Avgdata(dic["63"]);//空预器进口烟温
                        double kyq_py_temp = Compute.Avgdata(dic["64"]);//实测空预器排烟温度
                        double kyq_in_o2 = Compute.Avgdata(dic["65"]);//空预器进口氧量
                        double kyq_out_o2 = Compute.Avgdata(dic["66"]);//空预器出口氧量
                        double kyq_wind_1 = Compute.Sumdata(dic["67"]) + Compute.Sumdata(dic["68"]) + Compute.Sumdata(dic["69"]) + Compute.Sumdata(dic["70"]) + Compute.Sumdata(dic["71"]) + Compute.Sumdata(dic["72"]);//一次风量=A磨进口一次风量+B磨进口一次风量+……+F磨进口一次风量
                        double dg_dbkd_left = Compute.Avgdata(dic["73"]);//低过挡板开度（左侧）
                        double dg_dbkd_right = Compute.Avgdata(dic["74"]);//低过挡板开度（右侧）
                        double dz_dbkd_left = Compute.Avgdata(dic["75"]);//低再挡板开度（左侧）
                        double dz_dbkd_right = Compute.Avgdata(dic["76"]);//低再挡板开度（右侧）


                        double dg_xrl_design = (0.0336 * Math.Pow(yl_fh_out / 6.6, 2) - 2.2052 * (yl_fh_out / 6.6) + 107.85) / 2;//低过设计吸热量
                        double pg_xrl_design = (-0.0106 * Math.Pow(yl_fh_out / 6.6, 2) + 6.4571 * (yl_fh_out / 6.6) + 39.429) / 2;//屏过设计吸热量
                        double mg_xrl_design = (0.004 * Math.Pow(yl_fh_out / 6.6, 2) + 2.4461 * (yl_fh_out / 6.6) + 4.1171) / 2;//高过设计吸热量
                        double dz_xrl_design = (0.0045 * Math.Pow(yl_fh_out / 6.6, 2) + 4.721 * (yl_fh_out / 6.6) + 18.6) / 2;//低再设计吸热量
                        double gz_xrl_design = (0.0215 * Math.Pow(yl_fh_out / 6.6, 2) + 2.1836 * (yl_fh_out / 6.6) + 1.9571) / 2;//高再设计吸热量
                        double fs_xrl_design = 0.009 * Math.Pow(yl_fh_out / 6.6, 2) - 1.01 * (yl_fh_out / 6.6) + 69.4;//分省设计吸热量
                        double zs_xrl_design = 0.0411 * Math.Pow(yl_fh_out / 6.6, 2) - 2.7678 * (yl_fh_out / 6.6) + 171.51; //主省设计吸热量


                        double dg_out_press_left = flq_press - (flq_press - mg_out_press_left) / 4 * 2;//低过左侧出口压力
                        double dg_out_temp_left = dg_out_qw_left * 0.95 + dg_bw_left * 0.05;//低过左侧出口温度
                        double dg_out_hz_left = Steamhz(dg_out_temp_left, dg_out_press_left);//低过左侧出口焓
                        double dg_in_press_left = flq_press - (flq_press - mg_out_press_left) / 4 * 1;//低过左侧进口压力
                        double dg_in_hz_left = Steamhz(dg_in_temp_left, dg_in_press_left);//低过左侧进口焓
                        double dg_hz_left = dg_out_hz_left - dg_in_hz_left;//低过左侧焓增



                        double dg_out_press_right = flq_press - (flq_press - mg_out_press_right) / 4 * 2;//低过右侧出口压力
                        double dg_out_temp_right = dg_out_qw_right * 0.95 + dg_bw_right * 0.05;//低过右侧出口温度
                        double dg_out_hz_right = Steamhz(dg_out_temp_right, dg_out_press_right);//低过右侧出口焓
                        double dg_in_press_right = flq_press - (flq_press - mg_out_press_right) / 4 * 1;//低过右侧进口压力
                        double dg_in_hz_right = Steamhz(dg_in_temp_right, dg_in_press_right);//低过右侧进口焓
                        double dg_hz_right = dg_out_hz_right - dg_in_hz_right;//低过右侧焓增


                        double pg_out_press_left = flq_press - (flq_press - mg_out_press_left) / 4 * 3;//屏过左侧出口压力
                        double pg_out_temp_left = pg_out_qw_left * 0.95 + pg_bw_left * 0.05;//屏过左侧出口温度
                        double pg_out_hz_left = Steamhz(pg_out_temp_left, pg_out_press_left);//屏过左侧出口焓
                        double pg_in_press_left = flq_press - (flq_press - mg_out_press_left) / 4 * 2;//屏过左侧进口压力
                        double pg_in_hz_left = Steamhz(pg_in_temp_left, pg_in_press_left);//屏过左侧进口焓
                        double pg_hz_left = pg_out_hz_left - pg_in_hz_left;//屏过左侧焓增


                        double pg_out_press_right = flq_press - (flq_press - mg_out_press_right) / 4 * 3;//屏过右侧出口压力
                        double pg_out_temp_right = pg_out_qw_right * 0.95 + pg_bw_right * 0.05;//屏过右侧出口温度
                        double pg_out_hz_right = Steamhz(pg_out_temp_right, pg_out_press_right);//屏过右侧出口焓
                        double pg_in_press_right = flq_press - (flq_press - mg_out_press_right) / 4 * 2;//屏过右侧进口压力
                        double pg_in_hz_right = Steamhz(pg_in_temp_right, pg_in_press_right);//屏过右侧进口焓
                        double pg_hz_right = pg_out_hz_right - pg_in_hz_right;//屏过右侧焓增


                        double mg_out_temp_left = mg_out_qw_left * 0.9 + mg_bw_left * 0.1;//高过左侧出口温度
                        double mg_out_hz_left = Steamhz(mg_out_temp_left, mg_out_press_left);//高过左侧出口焓
                        double mg_in_press_left = flq_press - (flq_press - mg_out_press_left) / 4 * 3;//高过左侧进口压力
                        double mg_in_hz_left = Steamhz(mg_in_temp_left, mg_in_press_left);//高过左侧进口焓
                        double mg_hz_left = mg_out_hz_left - mg_in_hz_left;//高过左侧焓增


                        double mg_out_temp_right = mg_out_qw_right * 0.9 + mg_bw_right * 0.1;//高过右侧出口温度
                        double mg_out_hz_right = Steamhz(mg_out_temp_right, mg_out_press_right);//高过右侧出口焓
                        double mg_in_press_right = flq_press - (flq_press - mg_out_press_right) / 4 * 3;//高过右侧进口压力
                        double mg_in_hz_right = Steamhz(mg_in_temp_right, mg_in_press_right);//高过右侧进口焓
                        double mg_hz_right = mg_out_hz_right - mg_in_hz_right;//高过右侧焓增


                        double dz_out_press_left = dz_in_press_left - (dz_in_press_left - gz_out_press_left) / 2;//低再左侧出口压力
                        double dz_out_temp_left = dz_out_qw_left * 0.95 + dz_bw_left * 0.05;//低再左侧出口温度
                        double dz_out_hz_left = Steamhz(dz_out_temp_left, dz_out_press_left);//低再左侧出口焓
                        double dz_in_hz_left = Steamhz(dz_in_temp_left, dz_in_press_left); //低再左侧进口焓
                        double dz_hz_left = dz_out_hz_left - dz_in_hz_left;//低再左侧焓增


                        double dz_out_press_right = dz_in_press_right - (dz_in_press_right - gz_out_press_right) / 2;//低再右侧出口压力
                        double dz_out_temp_right = dz_out_qw_right * 0.95 + dz_bw_right * 0.05;//低再右侧出口温度
                        double dz_out_hz_right = Steamhz(dz_out_temp_right, dz_out_press_right);//低再右侧出口焓
                        double dz_in_hz_right = Steamhz(dz_in_temp_right, dz_in_press_right); //低再右侧进口焓
                        double dz_hz_right = dz_out_hz_right - dz_in_hz_right;//低再右侧焓增


                        double gz_out_temp_left = gz_out_qw_left * 0.9 + gz_bw_left * 0.1;//高再左侧出口温度
                        double gz_out_hz_left = Steamhz(gz_out_temp_left, gz_out_press_left);//高再左侧出口焓
                        double gz_in_press_left = dz_out_press_left;//高再左侧进口压力
                        double gz_in_hz_left = Steamhz(gz_in_temp_left, gz_in_press_left);//高再左侧进口焓
                        double gz_hz_left = gz_out_hz_left - gz_in_hz_left;//高再左侧焓增


                        double gz_out_temp_right = gz_out_qw_right * 0.9 + gz_bw_right * 0.1;//高再右侧出口温度
                        double gz_out_hz_right = Steamhz(gz_out_temp_right, gz_out_press_right);//高再右侧出口焓
                        double gz_in_press_right = dz_out_press_right;//高再右侧进口压力
                        double gz_in_hz_right = Steamhz(gz_in_temp_right, gz_in_press_right);//高再右侧进口焓
                        double gz_hz_right = gz_out_hz_right - gz_in_hz_right;//高再右侧焓增


                        double fs_out_hz = Steamhz(fs_out_temp, fs_out_press);//分省出口焓
                        double fs_in_hz = Steamhz(fs_in_temp, fs_in_press);//分省进口焓
                        double fs_hz = fs_out_hz - fs_in_hz;//分省焓增


                        double zs_out_hz = Steamhz(zs_out_temp, zs_out_press);//主省出口焓
                        double zs_in_hz = Steamhz(zs_in_temp, zs_in_press);//主省进口焓
                        double zs_hz = zs_out_hz - zs_in_hz;//主省焓增


                        double whz_jws = Whz(gstemp, gspress);//一级减温水焓值、二级减温水焓值
                        double hz_jwq_front_1_left = Steamhz(dg_out_temp_left, pg_in_press_left); //一级减温器前过热蒸汽焓值（左侧）
                        double hz_jwq_back_1_left = Steamhz(pg_in_temp_left, pg_in_press_left); //一级减温器后过热蒸汽焓值（左侧）
                        double hz_jwq_front_1_right = Steamhz(dg_out_temp_right, pg_in_press_right); //一级减温器前过热蒸汽焓值（右侧）
                        double hz_jwq_back_1_right = Steamhz(pg_in_temp_right, pg_in_press_right); //一级减温器后过热蒸汽焓值（右侧）

                        double jws_1_left = (hz_jwq_front_1_left - hz_jwq_back_1_left) * gsll / 2 / (hz_jwq_back_1_left - whz_jws);//一级减温水量（左侧）
                        if (jws_1_left < 0)
                        {
                            jws_1_left = 0;
                        }
                        double jws_1_right = (hz_jwq_front_1_right - hz_jwq_back_1_right) * gsll / 2 / (hz_jwq_back_1_right - whz_jws);//一级减温水量（右侧）
                        if (jws_1_right < 0)
                        {
                            jws_1_right = 0;
                        }
                        double jws_1 = jws_1_left + jws_1_right;//一级减温水总量

                        double hz_jwq_front_2_left = Steamhz(pg_out_temp_left, mg_in_press_left); //二级减温器前过热蒸汽焓值（左侧）
                        double hz_jwq_back_2_left = Steamhz(mg_in_temp_left, mg_in_press_left); //二级减温器后过热蒸汽焓值（左侧）
                        double hz_jwq_front_2_right = Steamhz(pg_out_temp_right, mg_in_press_right); //二级减温器前过热蒸汽焓值（右侧）
                        double hz_jwq_back_2_right = Steamhz(mg_in_temp_right, mg_in_press_right); //二级减温器后过热蒸汽焓值（右侧）

                        double jws_2_left = (hz_jwq_front_2_left - hz_jwq_back_2_left) * (gsll + jws_1) / 2 / (hz_jwq_back_2_left - whz_jws);//二级减温水量（左侧）
                        if (jws_2_left < 0)
                        {
                            jws_2_left = 0;
                        }
                        double jws_2_right = (hz_jwq_front_2_right - hz_jwq_back_2_right) * (gsll + jws_1) / 2 / (hz_jwq_back_2_right - whz_jws);//二级减温水量（右侧）
                        if (jws_2_right < 0)
                        {
                            jws_2_right = 0;
                        }
                        double jws_2 = jws_2_left + jws_2_right;//二级减温水总量

                        double sjzr_grzq = 0.0017 * Math.Pow(yl_fh_out / 100, 3) - 0.0175 * Math.Pow(yl_fh_out / 100, 2) + 0.0381 * (yl_fh_out / 100) + 0.8318;//设计再热/过热蒸汽流量比
                        double grq_jws = jws_1 + jws_2;//过热器减温水总量
                        double gp_out_zqll = sjzr_grzq * (gsll + grq_jws);//高排出口蒸汽流量

                        double sgjws_press = ctylxs * gspress;//事故减温水压力
                        double whz_sgjws = Whz(gstemp, sgjws_press);//事故减温水焓值
                        double hz_sgjwq_front_left = Steamhz(sgjwq_front_temp_left, dz_in_press_left);//事故减温器前再热蒸汽焓值（左侧）
                        double hz_sgjwq_back_left = Steamhz(dz_in_temp_left, dz_in_press_left);//事故减温器后再热蒸汽焓值（左侧）
                        double hz_sgjwq_front_right = Steamhz(sgjwq_front_temp_right, dz_in_press_right);//事故减温器前再热蒸汽焓值（右侧）
                        double hz_sgjwq_back_right = Steamhz(dz_in_temp_right, dz_in_press_right);//事故减温器后再热蒸汽焓值（右侧）

                        double zrq_zqll_single = gp_out_zqll / 2;//当前单侧再热蒸汽流量
                        double zrq_sgjws_left = (hz_sgjwq_front_left - hz_sgjwq_back_left) * (zrq_zqll_single - cql / 2) / (hz_sgjwq_back_left - whz_sgjws);//再热器事故减温水量（左侧）
                        if (zrq_sgjws_left < 0)
                        {
                            zrq_sgjws_left = 0;
                        }
                        double zrq_sgjws_right = (hz_sgjwq_front_right - hz_sgjwq_back_right) * (zrq_zqll_single - cql / 2) / (hz_sgjwq_back_right - whz_sgjws);//再热器事故减温水量（右侧）
                        if (zrq_sgjws_right < 0)
                        {
                            zrq_sgjws_right = 0;
                        }
                        double dzzqll_single_left = (gp_out_zqll - cql) / 2 + zrq_sgjws_left;//单侧低再蒸汽流量（左侧）
                        double dzzqll_single_right = (gp_out_zqll - cql) / 2 + zrq_sgjws_right;//单侧低再蒸汽流量（右侧）

                        double hz_wljwq_front_left = Steamhz(dz_out_temp_left, gz_in_press_left);//微量减温器前再热蒸汽焓值（左侧）
                        double hz_wljwq_back_left = Steamhz(gz_in_temp_left, gz_in_press_left);//微量减温器后再热蒸汽焓值（左侧）
                        double hz_wljwq_front_right = Steamhz(dz_out_temp_right, gz_in_press_right);//微量减温器前再热蒸汽焓值（右侧）
                        double hz_wljwq_back_right = Steamhz(gz_in_temp_right, gz_in_press_right);//微量减温器后再热蒸汽焓值（右侧）

                        double zrq_wljws_left = (hz_wljwq_front_left - hz_wljwq_back_left) * dzzqll_single_left / (hz_wljwq_back_left - whz_sgjws);//再热器微量减温水量（左侧）

                        double zrq_wljws_right = (hz_wljwq_front_right - hz_wljwq_back_right) * dzzqll_single_right / (hz_wljwq_back_right - whz_sgjws);//再热器微量减温水量（右侧）


                        double gzzqll_single_left = dzzqll_single_left + zrq_wljws_left;//单侧高再蒸汽流量（左侧）
                        double gzzqll_single_right = dzzqll_single_right + zrq_wljws_right;//单侧高再蒸汽流量（右侧）



                        double dg_xrl_real_left = dg_hz_left * (gsll / 2) / 1000;//低过左侧实际吸热量
                        double dg_wrl_left = dg_xrl_design / dg_xrl_real_left;//低过左侧污染率
                        double dg_xrl_real_right = dg_hz_right * (gsll / 2) / 1000;//低过右侧实际吸热量
                        double dg_wrl_right = dg_xrl_design / dg_xrl_real_right;//低过右侧污染率

                        double pg_xrl_real_left = pg_hz_left * (gsll / 2 + jws_1_left) / 1000;//屏过左侧实际吸热量
                        double pg_wrl_left = pg_xrl_design / pg_xrl_real_left;//屏过左侧污染率
                        double pg_xrl_real_right = pg_hz_right * (gsll / 2 + jws_1_right) / 1000;//屏过右侧实际吸热量
                        double pg_wrl_right = pg_xrl_design / pg_xrl_real_right;//屏过右侧污染率

                        double mg_xrl_real_left = mg_hz_left * (gsll / 2 + grq_jws) / 1000;//高过左侧实际吸热量
                        double mg_wrl_left = mg_xrl_design / mg_xrl_real_left;//高过左侧污染率
                        double mg_xrl_real_right = mg_hz_right * (gsll / 2 + grq_jws) / 1000;//高过右侧实际吸热量
                        double mg_wrl_right = mg_xrl_design / mg_xrl_real_right;//高过右侧污染率

                        double dz_xrl_real_left = dz_hz_left * dzzqll_single_left / 1000;//低再左侧实际吸热量
                        double dz_wrl_left = dz_xrl_design / dz_xrl_real_left;//低再左侧污染率
                        double dz_xrl_real_right = dz_hz_right * dzzqll_single_right / 1000;//低再右侧实际吸热量
                        double dz_wrl_right = dz_xrl_design / dz_xrl_real_right;//低再右侧污染率

                        double gz_xrl_real_left = gz_hz_left * gzzqll_single_left / 1000;//高再左侧实际吸热量
                        double gz_wrl_left = gz_xrl_design / gz_xrl_real_left;//高再左侧污染率
                        double gz_xrl_real_right = gz_hz_right * gzzqll_single_right / 1000;//高再右侧实际吸热量
                        double gz_wrl_right = gz_xrl_design / gz_xrl_real_right;//高再右侧污染率

                        double zs_xrl_real = zs_hz * gsll / 1000;//主省煤器实际吸热量
                        double zs_wrl = zs_xrl_design / zs_xrl_real;//主省污染率
                        double fs_xrl_real = fs_hz * gsll / 1000;//分级省煤器实际吸热量
                        double fs_wrl = fs_xrl_design / fs_xrl_real;//分级省煤器污染率



                        //double yrq_wrl = (1 + (0.7134 - yq_ratio_real) / 0.1 + (yrq_yq_pd - yq_pd_design) / yq_pd_design)*0.6;//预热器污染率
                        // double yrq_in_wind_temp = 0.3 * yrq_in_wt1 + 0.7 * yrq_in_wt2;//预热器进口风温
                        // double yq_pd_design = Math.Pow(yl_fh_out / 700, 2) * 1015;//设计烟气侧压降
                        //以下为空气预热器实际烟气侧效率计算逻辑

                        double kyq_in_xs_kqgl = 21 / (21 - kyq_in_o2);//空预器进口过量空气系数
                        double kyq_out_xs_kqgl = 21 / (21 - kyq_out_o2);//空预器出口过量空气系数

                        double kyq_in_wind_temp_jq = (kyq_in_fw_1 * kyq_wind_1 + kyq_in_fw_2 * kyq_wind_2) / (kyq_wind_1 + kyq_wind_2);//加权平均后空预器进口风温
                        double kyq_out_wind_temp_jq = (kyq_out_fw_1 * kyq_wind_1 + kyq_out_fw_2 * kyq_wind_2) / (kyq_wind_1 + kyq_wind_2);//加权平均后空预器出口风温

                        double kyq_wind_temp_inout_avg = (kyq_in_wind_temp_jq + kyq_out_wind_temp_jq) / 2;//空预器进出口风温平均值
                        double kyq_gas_temp_inout_avg = 240d;//空预器进出口烟温平均值
                        double kyq_airc = Airc(kyq_wind_temp_inout_avg);  //空预器进出口平均风温对应比热
                        double kyq_gasc = 0d;//空预器进出口平均烟温（入口与零漏风）对应比热
                        double px_temp_0_modify = 0d;//零漏风修正后的排烟温度
                        double kyq_lfl = (kyq_out_xs_kqgl - kyq_in_xs_kqgl) / kyq_in_xs_kqgl * 0.9 * 100;//空预器漏风率
                        double kyq_gas_temp_inout_avg_modify = 0d;//修正后的空预器进出口烟温平均值

                        DateTime now_time = DateTime.Now;

                        for (int i = 0; i < 20; i++)
                        {
                            kyq_gasc = Gasc(kyq_gas_temp_inout_avg);
                            px_temp_0_modify = kyq_lfl * kyq_airc * (kyq_py_temp - kyq_in_wind_temp_jq) / (100 * kyq_gasc) + kyq_py_temp;
                            kyq_gas_temp_inout_avg_modify = (kyq_in_yw + px_temp_0_modify) / 2;
                            if (Math.Abs(kyq_gas_temp_inout_avg_modify - kyq_gas_temp_inout_avg) < 0.1)
                            {

                                break;
                            }
                            else
                            {
                                kyq_gas_temp_inout_avg = kyq_gas_temp_inout_avg_modify;
                                continue;
                            }

                        }
                        kyq_gasc = Gasc(kyq_gas_temp_inout_avg_modify);
                        px_temp_0_modify = kyq_lfl * kyq_airc * (kyq_py_temp - kyq_in_wind_temp_jq) / (100 * kyq_gasc) + kyq_py_temp;
                        double x_ratio_design = 0.0039 * Math.Pow(yl_fh_out / 100, 3) - 0.0565 * Math.Pow(yl_fh_out / 100, 2) + 0.2725 * yl_fh_out/100 + 0.2979;//设计X比
                        double x_ratio_real = (kyq_in_yw - px_temp_0_modify) / (kyq_out_wind_temp_jq - kyq_in_wind_temp_jq);//实测X比
                        double py_temp_x_modify = (x_ratio_design - x_ratio_real) * xs_py_x_modify;//经X比修正后排烟温度变化值
                        double wind_temp_in_real = kyq_wind_1 / (kyq_wind_1 + kyq_wind_2) * kyq_in_fw_1 + kyq_wind_1 / (kyq_wind_1 + kyq_wind_2) * kyq_in_fw_2;//实测进口风温

                        double py_temp_in_wind_temp_modify = (wind_temp_in_design - wind_temp_in_real) * py_temp_in_wind_temp_modify_xs;//经进口风温修正后排烟温度变化值
                        double py_temp_modify = kyq_py_temp + py_temp_x_modify + py_temp_in_wind_temp_modify;//修正后的排烟温度
                        double yq_ratio_real = (kyq_in_yw - py_temp_modify) / (kyq_in_yw - wind_temp_in_real);//实际烟气侧效率
                       
                        //判断空预器的效率是否低于下限，如果低于，将吹灰器加入执行列表
                        if (yq_ratio_real < kyq_yq_ratio_low_Val)
                        {
                            StringBuilder sql_ky_runlist_add = new StringBuilder();
                            string sql_kyq_run = "select Id,Name_kw,DncBoiler_Name,Lastchtime from dncchqpoint where DncChtypeId=4 and DncBoilerId=" + boilerid;
                            string sql_exe_ky = "select * from dncchrunlist_kyq where OffTime is null or OffTime=''";
                            int runnum_ky = db.GetCommand(sql_exe_ky).Rows.Count;
                            DataTable dt_kyq = db.GetCommand(sql_kyq_run);
                            DateTime lastruntime = DateTime.Parse("1900-1-1 00:00:00");
                            int kyqid = 0;
                            string kyqname = "";
                            string bname = "";

                            foreach (DataRow item in dt_kyq.Rows)
                            {
                                kyqid = int.Parse(item[0].ToString());
                                kyqname = item[1].ToString();
                                bname = item[2].ToString();
                                sql_ky_runlist_add.Append("insert into dncchrunlist_kyq(Name_kw, AddTime, Remarks, Status, IsDeleted, DncChqpointId, DncChqpoint_Name, DncBoilerId, DncBoiler_Name) values('" + kyqname + "', '" + csyntime + "', '" + kyqname + "', 1, 0, " + kyqid + ", '" + kyqname + "', " + boilerid + ", '" + bname + "'); ");
                                lastruntime = DateTime.Parse(item[3].ToString());
                            }
                            if (runnum_ky == 0 && int.Parse(csyntime.Subtract(lastruntime).Minutes.ToString()) > 30)
                            {
                                db.CommandExecuteNonQuery(sql_ky_runlist_add.ToString());
                            }
                        }

                        StringBuilder sql_chlist_add = new StringBuilder();
                        string sql_exe = "select * from dncchrunlist where OffTime is null or OffTime=''";
                        int runnum = db.GetCommand(sql_exe).Rows.Count;


                        if (yl_fh_out > 400)
                        {


                            string sql_last_ch = "select OffTime from dncchrunlist ORDER BY OffTime desc LIMIT 1";
                            DataTable dt_last_ch = db.GetCommand(sql_last_ch);
                            DateTime d1 = DateTime.Parse(dt_last_ch.Rows[0][0].ToString());
                            DateTime d2 = DateTime.Now;
                            TimeSpan d3 = d2.Subtract(d1);
                            if (runnum == 0 && d3.TotalMinutes > 35)
                            {


                                string sql_fh = "select Fh from dncfhdata ORDER BY RealTime DESC LIMIT 11";
                                DataTable dt_fh = db.GetCommand(sql_fh);
                                //int[] fh = new int[10];
                                bool a = true;
                                if (dt_fh != null && dt_fh.Rows.Count > 0)
                                {
                                    for (int i = 1; i < 11; i++)
                                    {
                                        if (Math.Abs(int.Parse(dt_fh.Rows[i + 1][0].ToString()) - int.Parse(dt_fh.Rows[i][0].ToString())) > 5)
                                        {
                                            a = false;
                                            break;
                                        }

                                    }
                                }


                                if (a == true)
                                {



                                    #region 污染率计算
                                    StringBuilder sql_up_wrl = new StringBuilder();
                                    sql_up_wrl.Append("update dnccharea set Wrl_Val=" + pg_wrl_left + ",RealTime='" + now_time + "'where DncBoilerId=" + boilerid + " and K_Name_kw='屏式过热器（左侧）';");
                                    sql_up_wrl.Append("update dnccharea set Wrl_Val=" + pg_wrl_right + ",RealTime='" + now_time + "' where DncBoilerId=" + boilerid + " and K_Name_kw='屏式过热器（右侧）';");
                                    sql_up_wrl.Append("update dnccharea set Wrl_Val=" + mg_wrl_left + ",RealTime='" + now_time + "' where DncBoilerId=" + boilerid + " and K_Name_kw='高温过热器（左侧）';");
                                    sql_up_wrl.Append("update dnccharea set Wrl_Val=" + mg_wrl_right + ",RealTime='" + now_time + "' where DncBoilerId=" + boilerid + " and K_Name_kw='高温过热器（右侧）';");
                                    sql_up_wrl.Append("update dnccharea set Wrl_Val=" + gz_wrl_left + ",RealTime='" + now_time + "' where DncBoilerId=" + boilerid + " and K_Name_kw='高温再热器（左侧）';");
                                    sql_up_wrl.Append("update dnccharea set Wrl_Val=" + gz_wrl_right + ",RealTime='" + now_time + "' where DncBoilerId=" + boilerid + " and K_Name_kw='高温再热器（右侧）';");
                                    sql_up_wrl.Append("update dnccharea set Wrl_Val=" + dz_wrl_left + ",RealTime='" + now_time + "' where DncBoilerId=" + boilerid + " and K_Name_kw='低温再热器（左侧）';");
                                    sql_up_wrl.Append("update dnccharea set Wrl_Val=" + dz_wrl_right + ",RealTime='" + now_time + "' where DncBoilerId=" + boilerid + " and K_Name_kw='低温再热器（右侧）';");
                                    sql_up_wrl.Append("update dnccharea set Wrl_Val=" + dg_wrl_left + ",RealTime='" + now_time + "' where DncBoilerId=" + boilerid + " and K_Name_kw='低温过热器（左侧）';");
                                    sql_up_wrl.Append("update dnccharea set Wrl_Val=" + dg_wrl_right + ",RealTime='" + now_time + "' where DncBoilerId=" + boilerid + " and K_Name_kw='低温过热器（右侧）';");
                                    sql_up_wrl.Append("update dnccharea set Wrl_Val=" + zs_wrl + ",RealTime='" + now_time + "' where DncBoilerId=" + boilerid + " and K_Name_kw='主省煤器（左侧）';");
                                    sql_up_wrl.Append("update dnccharea set Wrl_Val=" + zs_wrl + ",RealTime='" + now_time + "' where DncBoilerId=" + boilerid + " and K_Name_kw='主省煤器（右侧）';");
                                    sql_up_wrl.Append("update dnccharea set Wrl_Val=" + fs_wrl + ",RealTime='" + now_time + "' where DncBoilerId=" + boilerid + " and K_Name_kw='分级省煤器';");
                                    sql_up_wrl.Append("update dnccharea set Wrl_Val=" + yq_ratio_real + ",RealTime='" + now_time + "' where DncBoilerId=" + boilerid + " and K_Name_kw='空气预热器';");
                                    sql_up_wrl.Append("update dncchpoint_wrl set Wrl_Val=" + pg_wrl_left + ",RealTime='" + now_time + "'where DncBoilerId=" + boilerid + " and DncCharea_Name='屏式过热器（左侧）';");
                                    sql_up_wrl.Append("update dncchpoint_wrl set Wrl_Val=" + pg_wrl_right + ",RealTime='" + now_time + "' where DncBoilerId=" + boilerid + " and DncCharea_Name='屏式过热器（右侧）';");
                                    sql_up_wrl.Append("update dncchpoint_wrl set Wrl_Val=" + mg_wrl_left + ",RealTime='" + now_time + "' where DncBoilerId=" + boilerid + " and DncCharea_Name='高温过热器（左侧）';");
                                    sql_up_wrl.Append("update dncchpoint_wrl set Wrl_Val=" + mg_wrl_right + ",RealTime='" + now_time + "' where DncBoilerId=" + boilerid + " and DncCharea_Name='高温过热器（右侧）';");
                                    sql_up_wrl.Append("update dncchpoint_wrl set Wrl_Val=" + gz_wrl_left + ",RealTime='" + now_time + "' where DncBoilerId=" + boilerid + " and DncCharea_Name='高温再热器（左侧）';");
                                    sql_up_wrl.Append("update dncchpoint_wrl set Wrl_Val=" + gz_wrl_right + ",RealTime='" + now_time + "' where DncBoilerId=" + boilerid + " and DncCharea_Name='高温再热器（右侧）';");
                                    if(dz_dbkd_left>60)
                                    {
                                        sql_up_wrl.Append("update dncchpoint_wrl set Wrl_Val=" + dz_wrl_left + ",RealTime='" + now_time + "',Status=1 where DncBoilerId=" + boilerid + " and DncCharea_Name='低温再热器（左侧）';");
                                    }
                                    else
                                    {
                                        sql_up_wrl.Append("update dncchpoint_wrl set Wrl_Val=" + dz_wrl_left + ",RealTime='" + now_time + "',Status=0 where DncBoilerId=" + boilerid + " and DncCharea_Name='低温再热器（左侧）';");
                                    }
                                    if (dz_dbkd_right > 60)
                                    {
                                        sql_up_wrl.Append("update dncchpoint_wrl set Wrl_Val=" + dz_wrl_right + ",RealTime='" + now_time + "',Status=1 where DncBoilerId=" + boilerid + " and DncCharea_Name='低温再热器（右侧）';");
                                    }
                                    else
                                    {
                                        sql_up_wrl.Append("update dncchpoint_wrl set Wrl_Val=" + dz_wrl_right + ",RealTime='" + now_time + "',Status=0 where DncBoilerId=" + boilerid + " and DncCharea_Name='低温再热器（右侧）';");
                                    }
                                    if (dg_dbkd_left > 50)
                                    {
                                        sql_up_wrl.Append("update dncchpoint_wrl set Wrl_Val=" + dg_wrl_left + ",RealTime='" + now_time + "',Status=1 where DncBoilerId=" + boilerid + " and DncCharea_Name='低温过热器（左侧）';");
                                    }
                                    else
                                    {
                                        sql_up_wrl.Append("update dncchpoint_wrl set Wrl_Val=" + dg_wrl_left + ",RealTime='" + now_time + "',Status=0 where DncBoilerId=" + boilerid + " and DncCharea_Name='低温过热器（左侧）';");
                                    }
                                    if (dg_dbkd_right > 50)
                                    {
                                        sql_up_wrl.Append("update dncchpoint_wrl set Wrl_Val=" + dg_wrl_right + ",RealTime='" + now_time + "',Status=1 where DncBoilerId=" + boilerid + " and DncCharea_Name='低温过热器（右侧）';");
                                    }
                                    else
                                    {
                                        sql_up_wrl.Append("update dncchpoint_wrl set Wrl_Val=" + dg_wrl_right + ",RealTime='" + now_time + "',Status=0 where DncBoilerId=" + boilerid + " and DncCharea_Name='低温过热器（右侧）';");
                                    }
                                    sql_up_wrl.Append("update dncchpoint_wrl set Wrl_Val=" + zs_wrl + ",RealTime='" + now_time + "' where DncBoilerId=" + boilerid + " and DncCharea_Name='主省煤器（左侧）';");
                                    sql_up_wrl.Append("update dncchpoint_wrl set Wrl_Val=" + zs_wrl + ",RealTime='" + now_time + "' where DncBoilerId=" + boilerid + " and DncCharea_Name='主省煤器（右侧）';");
                                    sql_up_wrl.Append("update dncchpoint_wrl set Wrl_Val=" + fs_wrl + ",RealTime='" + now_time + "' where DncBoilerId=" + boilerid + " and DncCharea_Name='分级省煤器';");
                                    sql_up_wrl.Append("update dncchpoint_wrl set Wrl_Val=" + yq_ratio_real + ",RealTime='" + now_time + "' where DncBoilerId=" + boilerid + " and DncCharea_Name='空气预热器';");



                                    if (!string.IsNullOrEmpty(sql_up_wrl.ToString()))
                                    {
                                        db.CommandExecuteNonQuery(sql_up_wrl.ToString());
                                    }

                                    #endregion


                                    #region 加入待吹灰列表

                                    //水冷壁非周期性
                                    double mg_wrl = (mg_wrl_left + mg_wrl_right) / 2;
                                    double gz_wrl = (gz_wrl_left + gz_wrl_right) / 2;

                                    if (mg_wrl < mg_wrl_low && gz_wrl < gz_wrl_low)
                                    {
                                        // string sql_chlist = "select Name_kw,Wrl_Val,Wrlhigh_Val,last_temp_dif_Val,now_temp_dif_Val,dx_temp_dif_Val,slb_circle_num,slb_floor_Val from V_chwrl where Status=1  and DncBoilerId=" + boilerid;
                                        string sql_chlist = "select Id,Name_kw,slb_floor_Val,last_temp_dif_Val,now_temp_dif_Val,DncBoiler_Name from dncchqpoint where DncChtypeId=1 and DncBoilerId=" + boilerid;
                                        DataTable dt_chlist = db.GetCommand(sql_chlist);
                                        var list1 = new List<Chpoint>();
                                        var list2 = new List<Chpoint>();
                                        var list3 = new List<Chpoint>();
                                        var list4 = new List<Chpoint>();
                                        foreach (DataRow item in dt_chlist.Rows)
                                        {
                                            var obj = new Chpoint();
                                            obj.Id = int.Parse(item[0].ToString());
                                            obj.Name_kw = item[1].ToString();
                                            obj.Slb_floor_Val = int.Parse(item[2].ToString());
                                            obj.Last_temp_dif_Val = double.Parse(item[3].ToString());
                                            obj.Now_temp_dif_Val = double.Parse(item[4].ToString());
                                            obj.Last_now_dif = double.Parse(item[3].ToString()) - double.Parse(item[4].ToString());
                                            obj.DncBoilerId = boilerid;
                                            obj.DncBoiler_Name = item[5].ToString();
                                            if (obj.Id == 1)
                                            {
                                                list1.Add(obj);
                                            }
                                            if (obj.Id == 2)
                                            {
                                                list2.Add(obj);
                                            }
                                            if (obj.Id == 3)
                                            {
                                                list3.Add(obj);
                                            }
                                            if (obj.Id == 4)
                                            {
                                                list4.Add(obj);
                                            }

                                        }
                                        List<Chpoint> chlist = new List<Chpoint>();
                                        chlist = Chlist(list1).Concat(Chlist(list2)).Concat(Chlist(list3)).Concat(Chlist(list4)).ToList();
                                        int cl_num = chlist.Count;

                                        for (int i = 0; i < cl_num; i++)
                                        {
                                            int id = chlist[i].Id;

                                            string chq_name = chlist[i].Name_kw;
                                            int bid = chlist[i].DncBoilerId;
                                            string bname = chlist[i].DncBoiler_Name;
                                            string sql_add = "insert into dncchlist (K_Name_kw,AddTime,DncChqpointId,DncChqpoint_Name,AddReason,DncBoilerId,DncBoiler_Name,Status,IsDeleted) values('" + chq_name + "','" + now_time + "'," + id + ",'" + chq_name + "',1," + bid + ",'" + bname + "',1,0);";
                                            sql_chlist_add.Append(sql_add);

                                        }

                                    }
                                    string sql_chlist_else = "select DncChqpointId,DncChqpoint_Name,DncBoilerId,DncBoiler_Name from dncchpoint_wrl where Status=1 and IsDeleted=0 and (DncChtypeId=2 or DncChtypeId=3) and Wrl_Val>Wrlhigh_Val and DncBoilerId=" + boilerid;
                                    DataTable dt_chlist_else = db.GetCommand(sql_chlist_else);
                                    string sql_add_else = "";
                                    if (dt_chlist_else != null && dt_chlist_else.Rows.Count > 0)
                                    {

                                        foreach (DataRow item in dt_chlist_else.Rows)
                                        {
                                            sql_add_else = "insert into dncchlist (K_Name_kw,AddTime,DncChqpointId,DncChqpoint_Name,AddReason,DncBoilerId,DncBoiler_Name,Status,IsDeleted) values('" + item[1].ToString() + "','" + now_time + "'," + int.Parse(item[0].ToString()) + ",'" + item[1].ToString() + "',1," + int.Parse(item[2].ToString()) + ",'" + item[3].ToString() + "',1,0);";
                                            sql_chlist_add.Append(sql_add_else);

                                        }

                                    }

                                    #endregion
                                }


                            }


                        }

                        //水平烟道超过10天或者尾部烟道超过20天未吹
                        string sql_yd = "select Id,Name_kw,DncBoilerId,DncBoiler_Name from dncchqpoint where DncBoilerId=" + boilerid + " and  ((position=2 and TIMESTAMPDIFF(DAY,Lastchtime,DATE_FORMAT(NOW(), '%Y-%m-%d %H:%i:%S'))>=10) or (position=3 and TIMESTAMPDIFF(DAY,Lastchtime,DATE_FORMAT(NOW(), '%Y-%m-%d %H:%i:%S'))>=20))";
                        DataTable dt_yd = db.GetCommand(sql_yd);

                        if (dt_yd != null && dt_yd.Rows.Count > 0)
                        {
                            foreach (DataRow item in dt_yd.Rows)
                            {

                                sql_chlist_add.Append("insert into dncchlist (K_Name_kw,AddTime,DncChqpointId,DncChqpoint_Name,AddReason,DncBoilerId,DncBoiler_Name,Status,IsDeleted) values('" + item[1].ToString() + "','" + now_time + "'," + int.Parse(item[0].ToString()) + ",'" + item[1].ToString() + "',2," + int.Parse(item[2].ToString()) + ",'" + item[3].ToString() + "',1,0);");
                            }
                        }

                        //负荷低于330MV超过6小时，将IK21和IK22加入列表
                        string sql_fh_6 = "select TIMESTAMPDIFF(HOUR, RealTime, now()) RealTime from dncfhdata where Fh_Val>=330 order by RealTime desc LIMIT 1";
                        DataTable dt_fh_6 = db.GetCommand(sql_fh_6);
                        int hour_fh6 = int.Parse(dt_fh_6.Rows[0][0].ToString());


                        if (runnum == 0 && hour_fh6 >= 6)
                        {
                            string sql_fh6_point = "select Id,Name_kw,DncBoilerId,DncBoiler_Name from dncchqpoint where DncBoilerId=" + boilerid + " and (Name_kw='IK21' or Name_kw='IK22')";
                            DataTable dt_fh6_p = db.GetCommand(sql_fh6_point);
                            foreach (DataRow item in dt_fh6_p.Rows)
                            {
                                sql_chlist_add.Append("insert into dncchlist (K_Name_kw,AddTime,DncChqpointId,DncChqpoint_Name,AddReason,DncBoilerId,DncBoiler_Name,Status,IsDeleted) values('" + item[1].ToString() + "','" + now_time + "'," + int.Parse(item[0].ToString()) + ",'" + item[1].ToString() + "',2," + int.Parse(item[2].ToString()) + ",'" + item[3].ToString() + "',1,0);");
                            }
                        }

                        if (!string.IsNullOrEmpty(sql_chlist_add.ToString()))
                        {
                            db.CommandExecuteNonQuery(sql_chlist_add.ToString());
                        }



                    }
                }
            }

            catch (Exception rrr)
            {
                //AddLgoToTXT(rrr.Message + "\n " + rrr.StackTrace);
            }
            //});

        }

        /// <summary>
        /// 判断是否加入执行列表
        /// </summary>
        /// <param name="boilerid"></param>
        /// <param name="csyntime"></param>
       
        public static void Znchrun(int boilerid, DateTime csyntime)
        {
            DBHelper db = new DBHelper();
           
            int chtime_sum = 0;
            int reason = 0;
            string sql_chlist_sum = "select count(*),Ch_time_Val from v_chlist where DncBoilerId=" + boilerid + " GROUP BY DncChtypeId,Ch_time_Val";
            DataTable dt_chtime = db.GetCommand(sql_chlist_sum);
            foreach (DataRow item in dt_chtime.Rows)
            {
                int num = int.Parse(item[0].ToString());
                int chtime = int.Parse(item[1].ToString());

                //以下为对吹计算方法
                //if (num % 2 == 0)
                //{
                //    chtime_sum += num / 2 * chtime;
                //}
                //else
                //{
                //    chtime_sum += (num + 1) / 2 * chtime;
                //}

                //以下为单吹计算方法
                chtime_sum += num * chtime;

            }
            string sql_wrl_cx = "select * from dnccharea where DncBoilerId="+boilerid+" and (DncChtypeId=2 or DncChtypeId=3) and K_Name_kw<>'分级省煤器' and ((Wrl_Val-Wrlhigh_Val)>=0.25 or ((K_Name_kw='高温过热器（左侧）' or K_Name_kw='高温过热器（右侧）') and Wrl_Val<0.7 ) or ((K_Name_kw='高温再热器（左侧）' or K_Name_kw='高温再热器（右侧）') and Wrl_Val<0.75 ))";
            DataTable dt_wrl_cx = db.GetCommand(sql_wrl_cx);
            string sql_norun = "select * from dncchrunlist  where DATE_FORMAT(AddTime,'%Y-%m-%d')= DATE_FORMAT('2020-7-7 20:20:00','%Y-%m-%d') ";
            DataTable dt_norun = db.GetCommand(sql_norun);
            string rname = "";
            if (chtime_sum > 7200)
            {
                reason = 1;
            }
            else if (dt_wrl_cx != null && dt_wrl_cx.Rows.Count > 0)
            {
                reason = 2;
            }
            else if (dt_norun != null && dt_norun.Rows.Count > 0 && csyntime > DateTime.Parse(DateTime.Now.ToShortDateString() + " 20:00:00"))
            {
                reason = 3;

            }

            switch (reason)
            {

                case 1:
                    rname = "待吹灰列表达7200s";
                    break;
                case 2:
                    rname = "污染率超限";
                    break;
                case 3:
                    rname = "晚20点一天未吹";
                    break;

            }
            if(reason>0)
            {
                string sql_chlist = "select  DISTINCT DncChqpointId,DncChqpoint_Name,DncBoiler_Name from dncchlist  where Status=1 and IsDeleted=0 and DncBoilerId=" + boilerid;
                DataTable dt_chlist = db.GetCommand(sql_chlist);
                if (dt_chlist != null && dt_chlist.Rows.Count > 0)
                {

                    StringBuilder sql_runlist = new StringBuilder();
                    int chqid = 0;
                    string chqname = "";
                    string bname = "";
                    if (reason > 0)
                    {

                    }

                    foreach (DataRow item in dt_chlist.Rows)
                    {
                        chqid = int.Parse(item[0].ToString());
                        chqname = item[1].ToString();
                        bname = item[2].ToString();
                        sql_runlist.Append("insert into dncchrunlist (Name_kw,AddTime,Remarks,Status,IsDeleted,DncChqpointId,DncChqpoint_Name,DncBoilerId,DncBoiler_Name) values ('" + chqname + "','" + csyntime + "','" + rname + "',1,0," + chqid + ",'" + chqname + "'," + boilerid + ",'" + bname + "');");

                    }

                    if (!string.IsNullOrEmpty(sql_runlist.ToString()))
                    {
                        db.CommandExecuteNonQuery(sql_runlist.ToString());
                    }
                }

            }
            
        }
    }
}
