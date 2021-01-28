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
    

    public class SynTask
    {
        public static double yl_fh_out;
        public static string fh_zone;
        public static string fh_zone_zw;
        public static string fgp_design_hz_zone;
        public static string hp_design_hz_zone;
        public static string mg_design_hz_zone;
        public static string dz_design_hz_zone;
        public static string gz_design_hz_zone;
        public static string dg_design_hz_zone;
        public static JsonData json_fh_zone;
        public static JsonData json_fh_zone_zw;
        public static double grq_jws_hz;
        public static int index;
        public static int index_zwxs;
        public static int all_boilerid;
        public static string boiler_name;
        public static DateTime all_syntime;
        public static double hz_a1;
        public static double hz_a2;
        public static double hz_a3;
        public static double hz_a4;
        public static double hz_a5;
        public static double hz_a6;
        public static double hz_a7;
        public static double hz_a8;



        /// <summary>
        /// 受热面焓增计算公式
        /// </summary>
        /// <param name="temp"></param>
        /// <param name="press"></param>
        /// <returns></returns>
        public static double Steamhz(double temp, double press)
        {
            temp = temp + 273.15;//℃转成K
            
            return hz_a1 + hz_a2 * temp + hz_a3 * Math.Pow(temp, 2)+ hz_a4* press / Math.Pow(temp, hz_a5) + hz_a6 * Math.Pow(10, hz_a7) * Math.Pow(press, 2) / Math.Pow(temp, hz_a8);
        }


        private static string HmacSHA256(string message, string secret)
        {
            secret = secret ?? "";
            var encoding = new System.Text.UTF8Encoding();
            byte[] keyByte = encoding.GetBytes(secret);
            byte[] messageBytes = encoding.GetBytes(message);
            using (var hmacsha256 = new HMACSHA256(keyByte))
            {
                byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
                return Convert.ToBase64String(hashmessage);
            }
        }
        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <returns></returns>
        private static string GetTimeStamp()
        {
            //TimeSpan ts = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            //return Convert.ToInt64(ts.TotalSeconds).ToString();

            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0));
            //Ticks表示自 0001 年 1 月 1 日午夜 12:00:00 以来已经过的时间的以 100 毫微秒为间隔的间隔数
            //除10000000调整为10位  1 毫秒 = 10^-3 秒，1 微秒 = 10 ^ -6 秒，1 毫微秒 = 10 ^ -9 秒，100 毫微秒 = 10 ^ -7 秒
            long t = (DateTime.Now.Ticks - startTime.Ticks) / 10000000;
            return t + "";
        }

        private static string SignRequest(JObject param, string secret)
        {
            IEnumerable<JProperty> list = param.Properties().OrderBy(a => a.Name, StringComparer.Ordinal);
            StringBuilder query = new StringBuilder();
            int i = 0;
            foreach (var item in list)
            {
                if (i > 0) query.Append("\n");
                i++;
                var itemType = item.Value.GetType();
                string itemvalue = string.Empty;
                if (itemType != typeof(JValue))
                {
                    itemvalue = JsonConvert.SerializeObject(item.Value);
                }
                else

                {
                    itemvalue = item.Value.ToString();
                }
                query.Append(itemvalue);
            }
            return HMACSHA256ToBase64(query.ToString(), secret).ToString();
        }
        private static string HMACSHA256ToBase64(string message, string secret)
        {
            secret = secret ?? "";
            var encoding = new System.Text.UTF8Encoding();
            byte[] messageBytes = encoding.GetBytes(message);
            using (var hmacsha256 = new HMACSHA256())
            {
                hmacsha256.Key = encoding.GetBytes(secret);
                byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
                return Convert.ToBase64String(hashmessage);
            }
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
        /// 输入数组,根据实际负荷、负荷区间，算出数组区间对应的数值
        /// </summary>
        /// <param name="arr"></param>
        
        /// <returns></returns>
        public static double FindValue(string arr)
        {
           
            JsonData jsondata = JsonMapper.ToObject(arr);
            double fh_up = double.Parse(json_fh_zone[index].ToString());
            double fh_down = double.Parse(json_fh_zone[index + 1].ToString());
            double x1 = double.Parse(jsondata[index].ToString());
            double x2 = double.Parse(jsondata[index + 1].ToString());
            return (x1 - x2) / (fh_up - fh_down) * (yl_fh_out - fh_down) + x2;
        }


        /// <summary>
        /// 输入数组,根据实际负荷、沾污计算负荷区间，算出数组区间对应的数值
        /// </summary>
        /// <param name="arr"></param>

        /// <returns></returns>
        public static double FindValue_zw(string arr)
        {

            JsonData jsondata = JsonMapper.ToObject(arr);
            double fh_up = double.Parse(json_fh_zone_zw[index_zwxs].ToString());
            double fh_down = double.Parse(json_fh_zone_zw[index_zwxs + 1].ToString());
            double x1 = double.Parse(jsondata[index_zwxs].ToString());
            double x2 = double.Parse(jsondata[index_zwxs + 1].ToString());
            return (x1 - x2) / (fh_up - fh_down) * (yl_fh_out - fh_down) + x2;
        }

        /// <summary>
        /// 获取dncfireerror_mid的插入SQL语句
        /// </summary>
        /// <param name="type1"></param>
        /// <param name="type1_des"></param>
        /// <param name="type2"></param>
        /// <param name="type2_des"></param>
        /// <returns></returns>
        public static string Errormid_sql(int type1, string type1_des, int type2, string type2_des)
        {
            string sql= "insert into dncfireerror_mid (DncTypeId,DncType_Name,RealTime,Etype,Evalue,Remarks,Status,IsDeleted,DncBoilerId,DncBoiler_Name) values (" + type1 + ",'" + type1_des + "','" + all_syntime + "'," + type2 + ",1,'" + type2_des + "',1,0," + all_boilerid + ",'" + boiler_name + "');";
            return sql;
        }

        /// <summary>
        /// 获取dncfireerror_advice的插入SQL语句（燃烧异常）
        /// </summary>
        /// <param name="type"></param>
        /// <param name="type_des"></param>
        /// <param name="advice"></param>
        /// <param name="remarks"></param>
        /// <returns></returns>
        public static string Fireerror_sql(int type, string type_des, string advice, string remarks)
        {
            string sql = "insert into dncfireerror_advice (DncTypeId,DncType_Name,RealTime,Evalue,Advice,Remarks,Status,IsDeleted,DncBoilerId,DncBoiler_Name) values (" + type + ",'" + type_des + "','" + all_syntime + "',1,'" + advice + "','"+remarks+"',1,0," + all_boilerid + ",'" + boiler_name + "');";
            return sql;
        }

        /// <summary>
        /// 获取dncfireerror_advice的插入SQL语句（沾污程度）
        /// </summary>
        /// <param name="error_status"></param>
        /// <param name="type"></param>
        /// <param name="type_des"></param>
        /// <param name="advice"></param>
        /// <param name="remarks"></param>
        /// <returns></returns>
        public static string Fireerror_sql_zw(int error_status,int type, string type_des, string advice, string remarks)
        {
            string sql = "insert into dncfireerror_advice (DncTypeId,DncType_Name,RealTime,Evalue,Advice,Remarks,Status,IsDeleted,DncBoilerId,DncBoiler_Name) values (" + type + ",'" + type_des + "','" + all_syntime + "',"+error_status+",'" + advice + "','" + remarks + "',1,0," + all_boilerid + ",'" + boiler_name + "');";
            return sql;
        }

        /// <summary>
        /// 一、二、三级过热器减温水计算公式：{(h前-h后)/(h后-h减)*(流量测点)}
        /// </summary>
        /// <param name="hq"></param>
        /// <param name="hh"></param>
        /// <param name="ll"></param>
        /// <returns></returns>
        public static double Grqjws(double hq, double hh,double ll)
        {
            return (hq - hh) / (hh - grq_jws_hz) * ll;

        }

        /// <summary>
        /// 各受热面设计焓增计算
        /// </summary>
        /// <returns></returns>
        //public static Designhz Designhz()
        //{
        //    Designhz d = new Designhz();
        //    d.Fgp = FindValue(fgp_design_hz_zone);
        //    d.Hp = FindValue(hp_design_hz_zone);
        //    d.Mg = FindValue(mg_design_hz_zone);
        //    d.Dg = FindValue(dg_design_hz_zone);
        //    d.Dz = FindValue(dz_design_hz_zone);
        //    d.Gz = FindValue(gz_design_hz_zone);
        //    return d;
        //}

         
      

         


        /// <summary>
        /// 受热面焓增计算、存储
        /// </summary>
        /// <param name="boilerid"></param>
        /// <param name="csyntime"></param>
        public static void Hztemp(int boilerid,DateTime csyntime)
        {
           
            //ThreadPool.QueueUserWorkItem((obj) =>
            //{
                try
                {

                  
                   all_syntime = csyntime;
                    all_boilerid = boilerid;
               
                    DBHelper db = new DBHelper();
                    //获取锅炉信息
                    string sql_boiler = "select Edfh,K_Name_kw from dncboiler where Status=1 and IsDeleted=0 and Id=" + boilerid;
                    DataTable dt_boiler = db.GetCommand(sql_boiler);
                    if (dt_boiler != null && dt_boiler.Rows.Count > 0)
                    {

                        //  DateTime syntime = DateTime.Parse(dt_boiler.Rows[0][0].ToString());

                        int edfh = int.Parse(dt_boiler.Rows[0][0].ToString());
                        boiler_name = dt_boiler.Rows[0][1].ToString();

                        //获取受热面的参数配置表信息
                        string sql_srm_para = "select zrqll_design,hz_a1,hz_a2,hz_a3,hz_a4,hz_a5,hz_a6,hz_a7,hz_a8,zrq_jws_mh_xs,gz_out_temp_ed,gz_out_temp_high,gz_out_temp_low,gz_out_temp_mh_xs,mg_out_temp_ed,mg_out_temp_high,mg_out_temp_low,mg_out_temp_mh_xs,fh_zone,o2_high_zone,o2_low_zone,nox_high_zone,nox_low_zone,zwxs_fh_zone,fgp_design_hz_zone,fgp_design_zwxs,fgp_zwxs_low,fgp_zwxs_high,hp_design_hz_zone,hp_design_zwxs,hp_zwxs_low,hp_zwxs_high,mg_design_hz_zone,mg_design_zwxs,mg_zwxs_low,mg_zwxs_high,dz_design_hz_zone,dz_design_zwxs,dz_zwxs_low,dz_zwxs_high,gz_design_hz_zone,gz_design_zwxs,gz_zwxs_low,gz_zwxs_high,dg_design_hz_zone,dg_design_zwxs,dg_zwxs_low,dg_zwxs_high,agp_basic_percent,grq_jws_design_1,grq_jws_design_2,grq_jws_design_3 from dncsrm_parameter where Status=1 and IsDeleted=0 and DncBoilerId=" + boilerid;
                        DataTable dt_srm_para = db.GetCommand(sql_srm_para);
                        //if (dt_srm_para != null && dt_srm_para.Rows.Count > 0)
                        //{
                        //}
                        double zrqll_design = double.Parse(dt_srm_para.Rows[0][0].ToString());
                        hz_a1 = double.Parse(dt_srm_para.Rows[0][1].ToString());
                        hz_a2 = double.Parse(dt_srm_para.Rows[0][2].ToString());
                        hz_a3 = double.Parse(dt_srm_para.Rows[0][3].ToString());
                        hz_a4 = double.Parse(dt_srm_para.Rows[0][4].ToString());
                        hz_a5 = double.Parse(dt_srm_para.Rows[0][5].ToString());
                        hz_a6 = double.Parse(dt_srm_para.Rows[0][6].ToString());
                        hz_a7 = double.Parse(dt_srm_para.Rows[0][7].ToString());
                        hz_a8 = double.Parse(dt_srm_para.Rows[0][8].ToString());
                        double zrq_jws_mh_xs = double.Parse(dt_srm_para.Rows[0][9].ToString());
                        double gz_out_temp_ed = double.Parse(dt_srm_para.Rows[0][10].ToString());
                        double gz_out_temp_high = double.Parse(dt_srm_para.Rows[0][11].ToString());
                        double gz_out_temp_low = double.Parse(dt_srm_para.Rows[0][12].ToString());
                        double gz_out_temp_mh_xs = double.Parse(dt_srm_para.Rows[0][13].ToString());
                        double mg_out_temp_ed = double.Parse(dt_srm_para.Rows[0][14].ToString());                        
                        double mg_out_temp_high = double.Parse(dt_srm_para.Rows[0][15].ToString());
                        double mg_out_temp_low = double.Parse(dt_srm_para.Rows[0][16].ToString());
                        double mg_out_temp_mh_xs = double.Parse(dt_srm_para.Rows[0][17].ToString());
                        fh_zone = dt_srm_para.Rows[0][18].ToString();
                        json_fh_zone = JsonMapper.ToObject(fh_zone);
                       
                        string o2_high_zone = dt_srm_para.Rows[0][19].ToString();
                        string o2_low_zone = dt_srm_para.Rows[0][20].ToString();
                        string nox_high_zone = dt_srm_para.Rows[0][21].ToString();
                        string nox_low_zone = dt_srm_para.Rows[0][22].ToString();
                        fh_zone_zw = dt_srm_para.Rows[0][23].ToString();
                        json_fh_zone_zw = JsonMapper.ToObject(fh_zone_zw);
                        fgp_design_hz_zone = dt_srm_para.Rows[0][24].ToString();
                        double fgp_design_zwxs = double.Parse(dt_srm_para.Rows[0][25].ToString());
                        double fgp_zwxs_low = double.Parse(dt_srm_para.Rows[0][26].ToString());
                        double fgp_zwxs_high = double.Parse(dt_srm_para.Rows[0][27].ToString());
                        hp_design_hz_zone = dt_srm_para.Rows[0][28].ToString();
                        double hp_design_zwxs = double.Parse(dt_srm_para.Rows[0][29].ToString());
                        double hp_zwxs_low = double.Parse(dt_srm_para.Rows[0][30].ToString());
                        double hp_zwxs_high = double.Parse(dt_srm_para.Rows[0][31].ToString());
                        mg_design_hz_zone = dt_srm_para.Rows[0][32].ToString();
                        double mg_design_zwxs = double.Parse(dt_srm_para.Rows[0][33].ToString());
                        double mg_zwxs_low = double.Parse(dt_srm_para.Rows[0][34].ToString());
                        double mg_zwxs_high = double.Parse(dt_srm_para.Rows[0][35].ToString());
                        dz_design_hz_zone = dt_srm_para.Rows[0][36].ToString();
                        double dz_design_zwxs = double.Parse(dt_srm_para.Rows[0][37].ToString());
                        double dz_zwxs_low = double.Parse(dt_srm_para.Rows[0][38].ToString());
                        double dz_zwxs_high = double.Parse(dt_srm_para.Rows[0][39].ToString());
                        gz_design_hz_zone = dt_srm_para.Rows[0][40].ToString();
                        double gz_design_zwxs = double.Parse(dt_srm_para.Rows[0][41].ToString());
                        double gz_zwxs_low = double.Parse(dt_srm_para.Rows[0][42].ToString());
                        double gz_zwxs_high = double.Parse(dt_srm_para.Rows[0][43].ToString());
                        dg_design_hz_zone = dt_srm_para.Rows[0][44].ToString();
                        double dg_design_zwxs = double.Parse(dt_srm_para.Rows[0][45].ToString());
                        double dg_zwxs_low = double.Parse(dt_srm_para.Rows[0][45].ToString());
                        double dg_zwxs_high = double.Parse(dt_srm_para.Rows[0][47].ToString());
                        double agp_basic_percent = double.Parse(dt_srm_para.Rows[0][48].ToString());
                        string grq_jws_design_1 = dt_srm_para.Rows[0][49].ToString();
                        string grq_jws_design_2 = dt_srm_para.Rows[0][50].ToString();
                        string grq_jws_design_3 = dt_srm_para.Rows[0][51].ToString();


                    //获取DncType表数据
                    string sql_typet = "select Id,K_Name_kw from dnctype where  Status=1 and IsDeleted=0";
                    DataTable dt_type = db.GetCommand(sql_typet);
                    Dictionary<int, string> dic_type = new Dictionary<int, string>();   //数据存入词典，方便查找 
                    foreach (DataRow item in dt_type.Rows)
                    {
                        dic_type.Add(int.Parse(item[0].ToString()), item[1].ToString());

                    }


                    //获取测点数据
                    string sql_point = "select DncTypeId,Pvalue from dnchztemp_point where  RealTime = '"+ csyntime+ "' and DncBoilerId=" + boilerid;
                        DataTable dt_point = db.GetCommand(sql_point);
                        Dictionary<string, string> dic = new Dictionary<string, string>();   //数据存入词典，方便查找           
                        if (dt_point != null && dt_point.Rows.Count > 0)
                        {
                                foreach (DataRow item in dt_point.Rows)
                                {
                                    dic.Add(item[0].ToString(), item[1].ToString());

                                }

                            double flq_press_a = Compute.Avgdata(dic["1"]);//分离器压力A
                            double fgp_out_temp_a = Compute.Avgdata(dic["2"]);//分隔屏出口温度A
                            double fgp_out_temp_b = Compute.Avgdata(dic["3"]);//分隔屏出口温度B
                            double fgp_out_temp_c = Compute.Avgdata(dic["4"]);//分隔屏出口温度C
                            double fgp_out_temp_d = Compute.Avgdata(dic["5"]);//分隔屏出口温度D
                            double mg_out_press_a = Compute.Avgdata(dic["6"]);//末级过热器出口压力A
                            double mg_out_press_b = Compute.Avgdata(dic["7"]);//末级过热器出口压力B
                            double mg_out_press_c = Compute.Avgdata(dic["8"]);//末级过热器出口压力C
                            double mg_out_press_d = Compute.Avgdata(dic["9"]);//末级过热器出口压力D
                            double fgp_in_temp_a = Compute.Avgdata(dic["10"]);//分隔屏进口温度A
                            double fgp_in_temp_b = Compute.Avgdata(dic["11"]);//分隔屏进口温度B
                            double fgp_in_temp_c = Compute.Avgdata(dic["12"]);//分隔屏进口温度C
                            double fgp_in_temp_d = Compute.Avgdata(dic["13"]);//分隔屏进口温度D
                            double hp_out_temp_a = Compute.Avgdata(dic["14"]);//后屏出口温度A
                            double hp_out_temp_b = Compute.Avgdata(dic["15"]);//后屏出口温度B
                            double hp_out_temp_c = Compute.Avgdata(dic["16"]);//后屏出口温度C
                            double hp_out_temp_d = Compute.Avgdata(dic["17"]);//后屏出口温度D
                            double hp_in_temp_a = Compute.Avgdata(dic["18"]);//后屏进口温度A
                            double hp_in_temp_b = Compute.Avgdata(dic["19"]);//后屏进口温度B
                            double hp_in_temp_c = Compute.Avgdata(dic["20"]);//后屏进口温度C
                            double hp_in_temp_d = Compute.Avgdata(dic["21"]);//后屏进口温度D
                            double mg_out_temp_a = Compute.Avgdata(dic["22"]);//末级过热器出口温度A
                            double mg_out_temp_b = Compute.Avgdata(dic["23"]);//末级过热器出口温度B
                            double mg_out_temp_c = Compute.Avgdata(dic["24"]);//末级过热器出口温度C
                            double mg_out_temp_d = Compute.Avgdata(dic["25"]);//末级过热器出口温度D
                            double mg_in_temp_a = Compute.Avgdata(dic["26"]);//末级过热器进口温度A
                            double mg_in_temp_b = Compute.Avgdata(dic["27"]);//末级过热器进口温度B
                            double mg_in_temp_c = Compute.Avgdata(dic["28"]);//末级过热器进口温度C
                            double mg_in_temp_d = Compute.Avgdata(dic["29"]);//末级过热器进口温度D
                            double dz_in_press_left = Compute.Avgdata(dic["30"]);//低温再热器进口压力左侧
                            double dz_in_press_right = Compute.Avgdata(dic["31"]);//低温再热器进口压力右侧
                            double gz_out_press_left = Compute.Avgdata(dic["32"]);//高温再热器出口压力左侧
                            double gz_out_press_right = Compute.Avgdata(dic["33"]);//高温再热器出口压力右侧
                            double dz_out_temp_left = Compute.Avgdata(dic["34"]);//低温再热器出口温度左侧
                            double dz_out_temp_right = Compute.Avgdata(dic["35"]);//低温再热器出口温度右侧
                            double dz_in_temp_left = Compute.Avgdata(dic["36"]);//低温再热器进口温度左侧
                            double dz_in_temp_right = Compute.Avgdata(dic["37"]);//低温再热器进口温度右侧
                            double gz_out_temp_left = Compute.Avgdata(dic["38"]);//高温再热器出口温度左侧
                            double gz_out_temp_right = Compute.Avgdata(dic["39"]);//高温再热器出口温度右侧
                            double dg_out_temp_a = Compute.Avgdata(dic["52"]);//低温过热器出口温度A
                            double dg_out_temp_b = Compute.Avgdata(dic["53"]);//低温过热器出口温度B
                            double dg_out_temp_c = Compute.Avgdata(dic["54"]);//低温过热器出口温度C
                            double dg_out_temp_d = Compute.Avgdata(dic["55"]);//低温过热器出口温度D
                            double flq_press_b = Compute.Avgdata(dic["56"]);//分离器压力B
                            double flq_press_c = Compute.Avgdata(dic["57"]);//分离器压力C
                            double flq_press_d = Compute.Avgdata(dic["58"]);//分离器压力D
                            double flq_temp_a = Compute.Avgdata(dic["59"]);//分离器温度A
                            double flq_temp_b = Compute.Avgdata(dic["60"]);//分离器温度B
                            double flq_temp_c = Compute.Avgdata(dic["61"]);//分离器温度C
                            double flq_temp_d = Compute.Avgdata(dic["62"]);//分离器温度D
                            double gz_in_temp_left = Compute.Avgdata(dic["63"]);//高温再热器进口温度左侧
                            double gz_in_temp_right = Compute.Avgdata(dic["64"]);//高温再热器进口温度右侧

                            double flq_press_avg1 = (flq_press_a + flq_press_b + flq_press_c + flq_press_d) / 4; 
                            double flq_press_avg = Compute.Avgdata("[" + flq_press_a.ToString() + ',' + flq_press_b.ToString() + ',' + flq_press_c.ToString() + ',' + flq_press_d.ToString() + ']');//分离器压力平均值
                            double flq_temp_avg = Compute.Avgdata("[" + flq_temp_a.ToString() + ',' + flq_temp_b.ToString() + ',' + flq_temp_c.ToString() + ',' + flq_temp_d.ToString() + ']');//分离器温度平均值
                            double mg_press_out_left_avg = (mg_out_press_a + mg_out_press_b) / 2;//末级过热器出口压力左侧平均值
                            double mg_press_out_right_avg = (mg_out_press_c + mg_out_press_d) / 2;//末级过热器出口压力右侧平均值
                            double dg_press_out_a = flq_press_avg - (flq_press_avg - mg_press_out_left_avg) / 5 * 2;//低温过热器出口压力A
                            double dg_press_out_b = dg_press_out_a;//低温过热器出口压力B,等于低温过热器出口压力A
                            double dg_press_out_c = flq_press_avg - (flq_press_avg - mg_press_out_right_avg) / 5 * 2;//低温过热器出口压力C
                            double dg_press_out_d = dg_press_out_c;//低温过热器出口压力D,等于低温过热器出口压力C
                            double dg_out_hz_a = Steamhz(dg_out_temp_a,dg_press_out_a);//低温过热器出口焓值A
                            double dg_out_hz_b = Steamhz(dg_out_temp_b, dg_press_out_b);//低温过热器出口焓值B
                            double dg_out_hz_c = Steamhz(dg_out_temp_c, dg_press_out_c);//低温过热器出口焓值C
                            double dg_out_hz_d = Steamhz(dg_out_temp_d, dg_press_out_d);//低温过热器出口焓值D

                            double dg_press_in_a = flq_press_avg - (flq_press_avg - mg_press_out_left_avg) / 5 * 1;//低温过热器进口压力A
                            double dg_press_in_b = dg_press_in_a;//低温过热器进口压力B,等于低温过热器进口压力A
                            double dg_press_in_c = flq_press_avg - (flq_press_avg - mg_press_out_right_avg) / 5 * 1;//低温过热器进口压力C
                            double dg_press_in_d = dg_press_in_c;//低温过热器进口压力D,等于低温过热器进口压力C
                            double dg_temp_in_a = flq_temp_avg;//低温过热器进口温度A,同分离器温度平均值
                            double dg_temp_in_b = flq_temp_avg;//低温过热器进口温度B,同分离器温度平均值
                            double dg_temp_in_c = flq_temp_avg;//低温过热器进口温度C,同分离器温度平均值
                            double dg_temp_in_d = flq_temp_avg;//低温过热器进口温度D,同分离器温度平均值
                            double dg_in_hz_a = Steamhz(dg_temp_in_a, dg_press_in_a);//低温过热器进口焓值A
                            double dg_in_hz_b = dg_in_hz_a;//低温过热器进口焓值B，等于低温过热器进口焓值A
                            double dg_in_hz_c = Steamhz(dg_temp_in_c, dg_press_in_c);//低温过热器进口焓值C
                            double dg_in_hz_d = dg_in_hz_c;//低温过热器进口焓值D，等于低温过热器进口焓值C

                            double fgp_press_out_a = flq_press_avg - (flq_press_avg - mg_press_out_left_avg) / 5 * 3;//分隔屏出口压力A
                            double fgp_press_out_b = fgp_press_out_a;//分隔屏出口压力B,等于分隔屏出口压力A
                            double fgp_press_out_c = flq_press_avg - (flq_press_avg - mg_press_out_right_avg) / 5 * 3;//分隔屏出口压力C
                            double fgp_press_out_d = fgp_press_out_c;//分隔屏出口压力D,等于分隔屏出口压力C
                            double fgp_out_hz_a = Steamhz(fgp_out_temp_a, fgp_press_out_a);//分隔屏出口焓值A
                            double fgp_out_hz_b = Steamhz(fgp_out_temp_b, fgp_press_out_b);//分隔屏出口焓值B
                            double fgp_out_hz_c = Steamhz(fgp_out_temp_c, fgp_press_out_c);//分隔屏出口焓值C
                            double fgp_out_hz_d = Steamhz(fgp_out_temp_d, fgp_press_out_d);//分隔屏出口焓值D

                            double fgp_press_in_a = flq_press_avg - (flq_press_avg - mg_press_out_left_avg) / 5 * 2;//分隔屏进口压力A
                            double fgp_press_in_b = fgp_press_in_a;//分隔屏进口压力B,等于分隔屏进口压力A
                            double fgp_press_in_c = flq_press_avg - (flq_press_avg - mg_press_out_right_avg) / 5 * 2;//分隔屏进口压力C
                            double fgp_press_in_d = fgp_press_in_c;//分隔屏进口压力D,等于分隔屏进口压力C
                            double fgp_in_hz_a = Steamhz(fgp_in_temp_a, fgp_press_in_a);//分隔屏进口焓值A
                            double fgp_in_hz_b = Steamhz(fgp_in_temp_b, fgp_press_in_b);//分隔屏进口焓值B
                            double fgp_in_hz_c = Steamhz(fgp_in_temp_c, fgp_press_in_c);//分隔屏进口焓值C
                            double fgp_in_hz_d = Steamhz(fgp_in_temp_d, fgp_press_in_d);//分隔屏进口焓值D

                            double hp_press_out_a = flq_press_avg - (flq_press_avg - mg_press_out_left_avg) / 5 * 4;//后屏出口压力A
                            double hp_press_out_b = hp_press_out_a;//后屏出口压力B,等于后屏出口压力A
                            double hp_press_out_c = flq_press_avg - (flq_press_avg - mg_press_out_right_avg) / 5 * 4;//后屏出口压力C
                            double hp_press_out_d = hp_press_out_c;//后屏出口压力D,等于后屏出口压力C
                            double hp_out_hz_a = Steamhz(hp_out_temp_a, hp_press_out_a);//后屏出口焓值A
                            double hp_out_hz_b = Steamhz(hp_out_temp_b, hp_press_out_b);//后屏出口焓值B
                            double hp_out_hz_c = Steamhz(hp_out_temp_c, hp_press_out_c);//后屏出口焓值C
                            double hp_out_hz_d = Steamhz(hp_out_temp_d, hp_press_out_d);//后屏出口焓值D

                            double hp_press_in_a = fgp_press_out_a;//后屏进口压力A，等于分隔屏出口压力A
                            double hp_press_in_b = fgp_press_out_b;//后屏进口压力B，等于分隔屏出口压力B
                            double hp_press_in_c = fgp_press_out_c;//后屏进口压力C，等于分隔屏出口压力C
                            double hp_press_in_d = fgp_press_out_d;//后屏进口压力D，等于分隔屏出口压力D
                            double hp_in_hz_a = Steamhz(hp_in_temp_a, hp_press_in_a);//后屏进口焓值A
                            double hp_in_hz_b = Steamhz(hp_in_temp_b, hp_press_in_b);//后屏进口焓值B
                            double hp_in_hz_c = Steamhz(hp_in_temp_c, hp_press_in_c);//后屏进口焓值C
                            double hp_in_hz_d = Steamhz(hp_in_temp_d, hp_press_in_d);//后屏进口焓值D

                            double mg_out_hz_a = Steamhz(mg_out_temp_a, mg_out_press_a);//末级过热器出口焓值A
                            double mg_out_hz_b = Steamhz(mg_out_temp_b, mg_out_press_b);//末级过热器出口焓值B
                            double mg_out_hz_c = Steamhz(mg_out_temp_c, mg_out_press_c);//末级过热器出口焓值C
                            double mg_out_hz_d = Steamhz(mg_out_temp_d, mg_out_press_d);//末级过热器出口焓值D

                            double mg_press_in_a = hp_press_out_a;//末级过热器进口压力A，等于后屏出口压力A
                            double mg_press_in_b = hp_press_out_b;//末级过热器进口压力B，等于后屏出口压力B
                            double mg_press_in_c = hp_press_out_c;//末级过热器进口压力C，等于后屏出口压力C
                            double mg_press_in_d = hp_press_out_d;//末级过热器进口压力D，等于后屏出口压力D
                            double mg_in_hz_a = Steamhz(mg_in_temp_a, mg_press_in_a);//末级过热器进口焓值A
                            double mg_in_hz_b = Steamhz(mg_in_temp_b, mg_press_in_b);//末级过热器进口焓值B
                            double mg_in_hz_c = Steamhz(mg_in_temp_c, mg_press_in_c);//末级过热器进口焓值C
                            double mg_in_hz_d = Steamhz(mg_in_temp_d, mg_press_in_d);//末级过热器进口焓值D

                            double dz_press_out_left = dz_in_press_left - (dz_in_press_left - gz_out_press_right) / 2;//低温再热器出口压力左侧
                            double dz_press_out_right = dz_in_press_right - (dz_in_press_right - gz_out_press_left) / 2;//低温再热器出口压力右侧
                            double dz_out_hz_left = Steamhz(dz_out_temp_left, dz_press_out_left);//低温再热器出口焓值左侧
                            double dz_out_hz_right = Steamhz(dz_out_temp_right, dz_press_out_right);//低温再热器出口焓值右侧


                            double dz_in_hz_left = Steamhz(dz_in_temp_left, dz_in_press_left);//低温再热器进口焓值左侧
                            double dz_in_hz_right = Steamhz(dz_in_temp_right, dz_in_press_right);//低温再热器进口焓值右侧

                            double gz_out_hz_left = Steamhz(gz_out_temp_left, gz_out_press_left);//高温再热器出口焓值左侧
                            double gz_out_hz_right = Steamhz(gz_out_temp_right, gz_out_press_right);//高温再热器出口焓值右侧

                            double gz_press_in_left = dz_press_out_right;//高温再热器进口压力左侧，等于低温再热器出口压力右侧
                            double gz_press_in_right = dz_press_out_left;//高温再热器进口压力右侧，等于低温再热器出口压力左侧
                            double gz_in_hz_left = Steamhz(gz_in_temp_left, gz_press_in_left);//高温再热器进口焓值左侧
                            double gz_in_hz_right = Steamhz(gz_in_temp_right, gz_press_in_right);//高温再热器进口焓值右侧

                            string sql_o2nox = "select DncTypeId,Ovalue from dnco2nox_point where RealTime = '" + csyntime + "' and DncBoilerId=" + boilerid;
                            DataTable dt_o2nox = db.GetCommand(sql_o2nox);
                            Dictionary<string, string> dic_o2nox = new Dictionary<string, string>();   //数据存入词典，方便查找 
                            //if (dt_o2nox != null && dt_o2nox.Rows.Count > 0)
                            //{
                                foreach (DataRow item in dt_o2nox.Rows)
                                {
                                    dic_o2nox.Add(item[0].ToString(), item[1].ToString());
                                }
                                double left_qy_o2_left_avg = Compute.O_avg(dic_o2nox["40"], dic_o2nox["41"], dic_o2nox["42"])[0];//左切圆左侧氧量平均值
                                double left_qy_o2_right_avg = Compute.O_avg(dic_o2nox["40"], dic_o2nox["41"], dic_o2nox["42"])[1];//左切圆右侧氧量平均值
                                double right_qy_o2_left_avg = Compute.O_avg(dic_o2nox["43"], dic_o2nox["44"], dic_o2nox["45"])[0];//右切圆左侧氧量平均值
                                double right_qy_o2_right_avg = Compute.O_avg(dic_o2nox["43"], dic_o2nox["44"], dic_o2nox["45"])[1];//右切圆右侧氧量平均值
                          //  }
                      
                            //else
                            //{
                            //    AddLgoToTXT(csyntime+"：O2、NOx无巡测数据" );
                            //}
                            Returndata back_xdg = new Returndata();
                            back_xdg = Compute.Xdgdata(dic["65"]);//后墙悬吊管水冷壁返回值
                            double left_qy_back_xdg_left_top = back_xdg.left_qy_back_xdg_left_top_value;//左切圆后墙悬吊管水冷壁左侧最高点的值
                            double left_qy_back_xdg_right_top = back_xdg.left_qy_back_xdg_right_top_value;//左切圆后墙悬吊管水冷壁右侧最高点的值
                            double right_qy_back_xdg_left_top = back_xdg.right_qy_back_xdg_left_top_value;//右切圆后墙悬吊管水冷壁左侧最高点的值
                            double right_qy_back_xdg_right_top = back_xdg.right_qy_back_xdg_right_top_value;//右切圆后墙悬吊管水冷壁右侧最高点的值

                            double left_qy_back_xdg_left_top3_avg = back_xdg.left_qy_back_xdg_left_top3_avg;//左切圆后墙悬吊管水冷壁左侧最高三个点平均值
                            double left_qy_back_xdg_right_top3_avg = back_xdg.left_qy_back_xdg_right_top3_avg;//左切圆后墙悬吊管水冷壁右侧最高三个点平均值
                            double right_qy_back_xdg_left_top3_avg = back_xdg.right_qy_back_xdg_left_top3_avg;//右切圆后墙悬吊管水冷壁左侧最高三个点平均值
                            double right_qy_back_xdg_right_top3_avg = back_xdg.right_qy_back_xdg_right_top3_avg;//右切圆后墙悬吊管水冷壁右侧最高三个点平均值

                            string left_qy_back_xdg_left_top_point= back_xdg.left_qy_back_xdg_left_top.ToJson();//左切圆后墙悬吊管水冷壁左侧最高点
                            string left_qy_back_xdg_right_top_point = back_xdg.left_qy_back_xdg_right_top.ToJson();//左切圆后墙悬吊管水冷壁右侧最高点
                            string right_qy_back_xdg_left_top_point = back_xdg.right_qy_back_xdg_left_top.ToJson();//右切圆后墙悬吊管水冷壁左侧最高点
                            string right_qy_back_xdg_right_top_point = back_xdg.right_qy_back_xdg_right_top.ToJson();//右切圆后墙悬吊管水冷壁右侧最高点

                            string left_qy_back_xdg_left_top3 = back_xdg.left_qy_back_xdg_left_top3.ToJson();//左切圆后墙悬吊管水冷壁左侧最高三个点
                            string left_qy_back_xdg_right_top3 = back_xdg.left_qy_back_xdg_right_top3.ToJson();//左切圆后墙悬吊管水冷壁右侧最高三个点
                            string right_qy_back_xdg_left_top3 = back_xdg.right_qy_back_xdg_left_top3.ToJson();//右切圆后墙悬吊管水冷壁左侧最高三个点
                            string right_qy_back_xdg_right_top3 = back_xdg.right_qy_back_xdg_right_top3.ToJson();//右切圆后墙悬吊管水冷壁右侧最高三个点

                            double left_czd_temp = Compute.Avgdata(dic["70"]);//左墙垂直段水冷壁温度
                            double right_czd_temp = Compute.Avgdata(dic["71"]);//右墙垂直段水冷壁温度

                            double left_lxd_top10_avg = Compute.Avgtopn(dic["72"], 10);//左墙螺旋段水冷壁最高10个点的平均值
                            double right_lxd_top10_avg = Compute.Avgtopn(dic["73"], 10);//右墙螺旋段水冷壁最高10个点的平均值

                            double left_qy_back_gp_temp = Compute.Avgdata(Compute.Qy(dic["78"])[0]);//左切圆后墙管屏水冷壁温度
                            double right_qy_back_gp_temp = Compute.Avgdata(Compute.Qy(dic["78"])[1]);//右切圆后墙管屏水冷壁温度

                            double left_qy_front_cz_temp = Compute.Avgdata(Compute.Qy(dic["79"])[0]);//左切圆前墙垂直段水冷壁温度
                            double right_qy_front_cz_temp = Compute.Avgdata(Compute.Qy(dic["79"])[1]);//右切圆前墙垂直段水冷壁温度

                            double left_qy_back_lxd_top10_avg = Compute.Avgtopn(Compute.Qy(dic["80"])[0], 10);//左切圆后墙螺旋段水冷壁温度最高10个点的平均值
                            double right_qy_back_lxd_top10_avg = Compute.Avgtopn(Compute.Qy(dic["80"])[1], 10);//右切圆后墙螺旋段水冷壁温度最高10个点的平均值

                            double left_qy_front_lxd_top10_avg = Compute.Avgtopn(Compute.Qy(dic["81"])[0], 10);//左切圆前墙螺旋段水冷壁温度最高10个点的平均值
                            double right_qy_front_lxd_top10_avg = Compute.Avgtopn(Compute.Qy(dic["81"])[1], 10);//右切圆前墙螺旋段水冷壁温度最高10个点的平均值

                            double dz_jws_press = Compute.Avgdata(dic["85"]);//低温再热器减温水压力
                            double dz_jws_temp = Compute.Avgdata(dic["86"]);//低温再热器减温水温度
                            double dz_jws_hz = Compute.Whz(dz_jws_temp, dz_jws_press);//低温再热器减温水焓值

                            double dz_jwq_front_left = Compute.Avgdata(dic["87"]);//低温再热器减温器前温度（左侧）
                            double dz_jwq_back_left = Compute.Avgdata(dic["88"]);//低温再热器减温器后温度（左侧）
                            double dz_jwq_front_right = Compute.Avgdata(dic["89"]);//低温再热器减温器前温度（右侧）
                            double dz_jwq_back_right = Compute.Avgdata(dic["90"]);//低温再热器减温器后温度（右侧）

                            double dz_jwq_front_hz_left = Steamhz(dz_jwq_front_left,dz_press_out_left);//低温再热器减温器前再热蒸汽焓值（左侧）
                            double dz_jwq_back_hz_left = Steamhz(dz_jwq_back_left, dz_press_out_left);//低温再热器减温器后再热蒸汽焓值（左侧）
                            double dz_jwq_front_hz_right = Steamhz(dz_jwq_front_right, dz_press_out_right);//低温再热器减温器前再热蒸汽焓值（右侧）
                            double dz_jwq_back_hz_right = Steamhz(dz_jwq_back_right, dz_press_out_right);//低温再热器减温器后再热蒸汽焓值（右侧）

                            yl_fh_out = Compute.Avgdata(dic["109"]);//机组实时负荷
                            index = Compute.FindIndex(fh_zone, yl_fh_out);
                            index_zwxs = Compute.FindIndex(fh_zone_zw, yl_fh_out);
                            double zrq_jws_left = Compute.Jwsl_zrq(dz_jwq_front_hz_left, dz_jwq_back_hz_left, dz_jws_hz, yl_fh_out, edfh, zrqll_design);//再热器减温水量（左侧）
                            double zrq_jws_right = Compute.Jwsl_zrq(dz_jwq_front_hz_right, dz_jwq_back_hz_right, dz_jws_hz, yl_fh_out, edfh, zrqll_design);//再热器减温水量（右侧）

                            double fgp_hz_design = FindValue_zw(fgp_design_hz_zone);//分隔屏设计焓增
                            double hp_hz_design = FindValue_zw(hp_design_hz_zone);//后屏设计焓增
                            double mg_hz_design = FindValue_zw(mg_design_hz_zone);//末级过热器设计焓增
                            double dg_hz_design = FindValue_zw(dg_design_hz_zone);//低温过热器设计焓增
                            double dz_hz_design = FindValue_zw(dz_design_hz_zone);//低温再热器设计焓增
                            double gz_hz_design = FindValue_zw(gz_design_hz_zone);//高温再热器设计焓增
                            int del_status = 0;

                            grq_jws_hz = Compute.Whz(Compute.Avgdata(dic["102"]), Compute.Avgdata(dic["101"]));//过热器减温水焓值                          
                       /*
                            //插入表dnchztemp_mid
                            db.CommandExecuteNonQuery(db.ConnectString, "insert into dnchztemp_mid(RealTime,Flq_press_avg,Flq_temp_avg,Mg_press_out_a,Mg_press_out_b,Mg_press_out_c,Mg_press_out_d,Mg_press_out_left_avg,Mg_press_out_right_avg,Dg_press_out_a,Dg_press_out_b,Dg_press_out_c,Dg_press_out_d,Dg_temp_out_a,Dg_temp_out_b,Dg_temp_out_c,Dg_temp_out_d,Dg_out_hz_a,Dg_out_hz_b,Dg_out_hz_c,Dg_out_hz_d,Dg_press_in_a,Dg_press_in_b,Dg_press_in_c,Dg_press_in_d,Dg_temp_in_a,Dg_temp_in_b,Dg_temp_in_c,Dg_temp_in_d,Dg_in_hz_a,Dg_in_hz_b,Dg_in_hz_c,Dg_in_hz_d,Fgp_press_out_a,Fgp_press_out_b,Fgp_press_out_c,Fgp_press_out_d,Fgp_temp_out_a,Fgp_temp_out_b,Fgp_temp_out_c,Fgp_temp_out_d,Fgp_out_hz_a,Fgp_out_hz_b,Fgp_out_hz_c,Fgp_out_hz_d,Fgp_press_in_a,Fgp_press_in_b,Fgp_press_in_c,Fgp_press_in_d,Fgp_temp_in_a,Fgp_temp_in_b,Fgp_temp_in_c,Fgp_temp_in_d,Fgp_in_hz_a,Fgp_in_hz_b,Fgp_in_hz_c,Fgp_in_hz_d,Hp_press_out_a,Hp_press_out_b,Hp_press_out_c,Hp_press_out_d,Hp_temp_out_a,Hp_temp_out_b,Hp_temp_out_c,Hp_temp_out_d,Hp_out_hz_a,Hp_out_hz_b,Hp_out_hz_c,Hp_out_hz_d,Hp_press_in_a,Hp_press_in_b,Hp_press_in_c,Hp_press_in_d,Hp_temp_in_a,Hp_temp_in_b,Hp_temp_in_c,Hp_temp_in_d,Hp_in_hz_a,Hp_in_hz_b,Hp_in_hz_c,Hp_in_hz_d,Mg_temp_out_a,Mg_temp_out_b,Mg_temp_out_c,Mg_temp_out_d,Mg_out_hz_a,Mg_out_hz_b,Mg_out_hz_c,Mg_out_hz_d,Mg_press_in_a,Mg_press_in_b,Mg_press_in_c,Mg_press_in_d,Mg_temp_in_a,Mg_temp_in_b,Mg_temp_in_c,Mg_temp_in_d,Mg_in_hz_a,Mg_in_hz_b,Mg_in_hz_c,Mg_in_hz_d,Dz_press_in_left,Dz_press_in_right,Gz_press_out_left,Gz_press_out_right,Dz_press_out_left,Dz_press_out_right,Dz_temp_out_left,Dz_temp_out_right,Dz_out_hz_left,Dz_out_hz_right,Dz_temp_in_left,Dz_temp_in_right,Dz_in_hz_left,Dz_in_hz_right,Gz_temp_out_left,Gz_temp_out_right,Gz_out_hz_left,Gz_out_hz_right,Gz_press_in_left,Gz_press_in_right,Gz_temp_in_left,Gz_temp_in_right,Gz_in_hz_left,Gz_in_hz_right,Left_qy_o2_left_avg,Left_qy_o2_right_avg,Left_qy_back_xdg_left_top,Left_qy_back_xdg_right_top,Right_qy_o2_left_avg,Right_qy_o2_right_avg,Right_qy_back_xdg_left_top,Right_qy_back_xdg_right_top,Left_czd_temp,Right_czd_temp,Left_qy_back_xdg_left_top3_avg,Left_qy_back_xdg_right_top3_avg,Left_lxd_top10_avg,Right_lxd_top10_avg,Right_qy_back_xdg_left_top3_avg,Right_qy_back_xdg_right_top3_avg,Left_qy_back_gp_temp,Right_qy_back_gp_temp,Left_qy_front_gp_temp,Right_qy_front_gp_temp,Left_qy_back_lxd_top10_avg,Right_qy_back_lxd_top10_avg,Left_qy_front_lxd_top10_avg,Right_qy_front_lxd_top10_avg,Dz_jws_press,Dz_jws_temp,Dz_jws_hz,Dz_jwq_front_left,Dz_jwq_back_left,Dz_jwq_front_right,Dz_jwq_back_right,Dz_jwq_front_hz_left,Dz_jwq_back_hz_left,Dz_jwq_front_hz_right,Dz_jwq_back_hz_right,Zrq_jws_left,Zrq_jws_right,Fgp_hz_design,Hp_hz_design,Mg_hz_design,Dz_hz_design,Gz_hz_design,Grq_jws_hz,Status,IsDeleted,DncBoilerId,DncBoiler_Name,Left_qy_back_xdg_left_top_point,Left_qy_back_xdg_right_top_point,Right_qy_back_xdg_left_top_point,Right_qy_back_xdg_right_top_point,Left_qy_back_xdg_left_top3,Left_qy_back_xdg_right_top3,Right_qy_back_xdg_left_top3,Right_qy_back_xdg_right_top3,Dg_hz_design) values(@RealTime,@Flq_press_avg,@Flq_temp_avg,@Mg_press_out_a,@Mg_press_out_b,@Mg_press_out_c,@Mg_press_out_d,@Mg_press_out_left_avg,@Mg_press_out_right_avg,@Dg_press_out_a,@Dg_press_out_b,@Dg_press_out_c,@Dg_press_out_d,@Dg_temp_out_a,@Dg_temp_out_b,@Dg_temp_out_c,@Dg_temp_out_d,@Dg_out_hz_a,@Dg_out_hz_b,@Dg_out_hz_c,@Dg_out_hz_d,@Dg_press_in_a,@Dg_press_in_b,@Dg_press_in_c,@Dg_press_in_d,@Dg_temp_in_a,@Dg_temp_in_b,@Dg_temp_in_c,@Dg_temp_in_d,@Dg_in_hz_a,@Dg_in_hz_b,@Dg_in_hz_c,@Dg_in_hz_d,@Fgp_press_out_a,@Fgp_press_out_b,@Fgp_press_out_c,@Fgp_press_out_d,@Fgp_temp_out_a,@Fgp_temp_out_b,@Fgp_temp_out_c,@Fgp_temp_out_d,@Fgp_out_hz_a,@Fgp_out_hz_b,@Fgp_out_hz_c,@Fgp_out_hz_d,@Fgp_press_in_a,@Fgp_press_in_b,@Fgp_press_in_c,@Fgp_press_in_d,@Fgp_temp_in_a,@Fgp_temp_in_b,@Fgp_temp_in_c,@Fgp_temp_in_d,@Fgp_in_hz_a,@Fgp_in_hz_b,@Fgp_in_hz_c,@Fgp_in_hz_d,@Hp_press_out_a,@Hp_press_out_b,@Hp_press_out_c,@Hp_press_out_d,@Hp_temp_out_a,@Hp_temp_out_b,@Hp_temp_out_c,@Hp_temp_out_d,@Hp_out_hz_a,@Hp_out_hz_b,@Hp_out_hz_c,@Hp_out_hz_d,@Hp_press_in_a,@Hp_press_in_b,@Hp_press_in_c,@Hp_press_in_d,@Hp_temp_in_a,@Hp_temp_in_b,@Hp_temp_in_c,@Hp_temp_in_d,@Hp_in_hz_a,@Hp_in_hz_b,@Hp_in_hz_c,@Hp_in_hz_d,@Mg_temp_out_a,@Mg_temp_out_b,@Mg_temp_out_c,@Mg_temp_out_d,@Mg_out_hz_a,@Mg_out_hz_b,@Mg_out_hz_c,@Mg_out_hz_d,@Mg_press_in_a,@Mg_press_in_b,@Mg_press_in_c,@Mg_press_in_d,@Mg_temp_in_a,@Mg_temp_in_b,@Mg_temp_in_c,@Mg_temp_in_d,@Mg_in_hz_a,@Mg_in_hz_b,@Mg_in_hz_c,@Mg_in_hz_d,@Dz_press_in_left,@Dz_press_in_right,@Gz_press_out_left,@Gz_press_out_right,@Dz_press_out_left,@Dz_press_out_right,@Dz_temp_out_left,@Dz_temp_out_right,@Dz_out_hz_left,@Dz_out_hz_right,@Dz_temp_in_left,@Dz_temp_in_right,@Dz_in_hz_left,@Dz_in_hz_right,@Gz_temp_out_left,@Gz_temp_out_right,@Gz_out_hz_left,@Gz_out_hz_right,@Gz_press_in_left,@Gz_press_in_right,@Gz_temp_in_left,@Gz_temp_in_right,@Gz_in_hz_left,@Gz_in_hz_right,@Left_qy_o2_left_avg,@Left_qy_o2_right_avg,@Left_qy_back_xdg_left_top,@Left_qy_back_xdg_right_top,@Right_qy_o2_left_avg,@Right_qy_o2_right_avg,@Right_qy_back_xdg_left_top,@Right_qy_back_xdg_right_top,@Left_czd_temp,@Right_czd_temp,@Left_qy_back_xdg_left_top3_avg,@Left_qy_back_xdg_right_top3_avg,@Left_lxd_top10_avg,@Right_lxd_top10_avg,@Right_qy_back_xdg_left_top3_avg,@Right_qy_back_xdg_right_top3_avg,@Left_qy_back_gp_temp,@Right_qy_back_gp_temp,@Left_qy_front_gp_temp,@Right_qy_front_gp_temp,@Left_qy_back_lxd_top10_avg,@Right_qy_back_lxd_top10_avg,@Left_qy_front_lxd_top10_avg,@Right_qy_front_lxd_top10_avg,@Dz_jws_press,@Dz_jws_temp,@Dz_jws_hz,@Dz_jwq_front_left,@Dz_jwq_back_left,@Dz_jwq_front_right,@Dz_jwq_back_right,@Dz_jwq_front_hz_left,@Dz_jwq_back_hz_left,@Dz_jwq_front_hz_right,@Dz_jwq_back_hz_right,@Zrq_jws_left,@Zrq_jws_right,@Fgp_hz_design,@Hp_hz_design,@Mg_hz_design,@Dz_hz_design,@Gz_hz_design,@Grq_jws_hz,@Status,@IsDeleted,@DncBoilerId,@DncBoiler_Name,@Left_qy_back_xdg_left_top_point,@Left_qy_back_xdg_right_top_point,@Right_qy_back_xdg_left_top_point,@Right_qy_back_xdg_right_top_point,@Left_qy_back_xdg_left_top3,@Left_qy_back_xdg_right_top3,@Right_qy_back_xdg_left_top3,@Right_qy_back_xdg_right_top3,@Dg_hz_design)",
                            new MySql.Data.MySqlClient.MySqlParameter("@RealTime", csyntime),//实际时间
                            new MySql.Data.MySqlClient.MySqlParameter("@Flq_press_avg", flq_press_avg),//分离器压力平均值
                            new MySql.Data.MySqlClient.MySqlParameter("@Flq_temp_avg", flq_temp_avg),//分离器温度平均值
                            new MySql.Data.MySqlClient.MySqlParameter("@Mg_press_out_a", mg_out_press_a),//末级过热器出口压力A
                            new MySql.Data.MySqlClient.MySqlParameter("@Mg_press_out_b", mg_out_press_b),//末级过热器出口压力B
                            new MySql.Data.MySqlClient.MySqlParameter("@Mg_press_out_c", mg_out_press_c),//末级过热器出口压力B
                            new MySql.Data.MySqlClient.MySqlParameter("@Mg_press_out_d", mg_out_press_d),//末级过热器出口压力D
                            new MySql.Data.MySqlClient.MySqlParameter("@Mg_press_out_left_avg", mg_press_out_left_avg),//末级过热器出口压力左侧平均值
                            new MySql.Data.MySqlClient.MySqlParameter("@Mg_press_out_right_avg", mg_press_out_right_avg),//末级过热器出口压力右侧平均值
                            new MySql.Data.MySqlClient.MySqlParameter("@Dg_press_out_a", dg_press_out_a),//低温过热器出口压力A
                            new MySql.Data.MySqlClient.MySqlParameter("@Dg_press_out_b", dg_press_out_b),//低温过热器出口压力B
                            new MySql.Data.MySqlClient.MySqlParameter("@Dg_press_out_c", dg_press_out_c),//低温过热器出口压力C
                            new MySql.Data.MySqlClient.MySqlParameter("@Dg_press_out_d", dg_press_out_d),//低温过热器出口压力D
                            new MySql.Data.MySqlClient.MySqlParameter("@Dg_temp_out_a", dg_out_temp_a),//低温过热器出口温度A
                            new MySql.Data.MySqlClient.MySqlParameter("@Dg_temp_out_b", dg_out_temp_b),//低温过热器出口温度B
                            new MySql.Data.MySqlClient.MySqlParameter("@Dg_temp_out_c", dg_out_temp_c),//低温过热器出口温度C
                            new MySql.Data.MySqlClient.MySqlParameter("@Dg_temp_out_d", dg_out_temp_d),//低温过热器出口温度D
                            new MySql.Data.MySqlClient.MySqlParameter("@Dg_out_hz_a", dg_out_hz_a),//低温过热器出口焓值A
                            new MySql.Data.MySqlClient.MySqlParameter("@Dg_out_hz_b", dg_out_hz_b),//低温过热器出口焓值B
                            new MySql.Data.MySqlClient.MySqlParameter("@Dg_out_hz_c", dg_out_hz_c),//低温过热器出口焓值C
                            new MySql.Data.MySqlClient.MySqlParameter("@Dg_out_hz_d", dg_out_hz_d),//低温过热器出口焓值D
                            new MySql.Data.MySqlClient.MySqlParameter("@Dg_press_in_a", dg_press_in_a),//低温过热器进口压力A
                            new MySql.Data.MySqlClient.MySqlParameter("@Dg_press_in_b", dg_press_in_b),//低温过热器进口压力B
                            new MySql.Data.MySqlClient.MySqlParameter("@Dg_press_in_c", dg_press_in_c),//低温过热器进口压力C
                            new MySql.Data.MySqlClient.MySqlParameter("@Dg_press_in_d", dg_press_in_d),//低温过热器进口压力D
                            new MySql.Data.MySqlClient.MySqlParameter("@Dg_temp_in_a", dg_temp_in_a),//低温过热器进口温度A
                            new MySql.Data.MySqlClient.MySqlParameter("@Dg_temp_in_b", dg_temp_in_b),//低温过热器进口温度B
                            new MySql.Data.MySqlClient.MySqlParameter("@Dg_temp_in_c", dg_temp_in_c),//低温过热器进口温度C
                            new MySql.Data.MySqlClient.MySqlParameter("@Dg_temp_in_d", dg_temp_in_d),//低温过热器进口温度D
                            new MySql.Data.MySqlClient.MySqlParameter("@Dg_in_hz_a", dg_in_hz_a),//低温过热器进口焓值A
                            new MySql.Data.MySqlClient.MySqlParameter("@Dg_in_hz_b", dg_in_hz_b),//低温过热器进口焓值B
                            new MySql.Data.MySqlClient.MySqlParameter("@Dg_in_hz_c", dg_in_hz_c),//低温过热器进口焓值C
                            new MySql.Data.MySqlClient.MySqlParameter("@Dg_in_hz_d", dg_in_hz_d),//低温过热器进口焓值D
                            new MySql.Data.MySqlClient.MySqlParameter("@Fgp_press_out_a", fgp_press_out_a),//分隔屏出口压力A
                            new MySql.Data.MySqlClient.MySqlParameter("@Fgp_press_out_b", fgp_press_out_b),//分隔屏出口压力B
                            new MySql.Data.MySqlClient.MySqlParameter("@Fgp_press_out_c", fgp_press_out_c),//分隔屏出口压力C
                            new MySql.Data.MySqlClient.MySqlParameter("@Fgp_press_out_d", fgp_press_out_d),//分隔屏出口压力D
                            new MySql.Data.MySqlClient.MySqlParameter("@Fgp_temp_out_a", fgp_out_temp_a),//分隔屏出口温度A
                            new MySql.Data.MySqlClient.MySqlParameter("@Fgp_temp_out_b", fgp_out_temp_b),//分隔屏出口温度B
                            new MySql.Data.MySqlClient.MySqlParameter("@Fgp_temp_out_c", fgp_out_temp_c),//分隔屏出口温度C
                            new MySql.Data.MySqlClient.MySqlParameter("@Fgp_temp_out_d", fgp_out_temp_d),//分隔屏出口温度D
                            new MySql.Data.MySqlClient.MySqlParameter("@Fgp_out_hz_a", fgp_out_hz_a),//分隔屏出口焓值A
                            new MySql.Data.MySqlClient.MySqlParameter("@Fgp_out_hz_b", fgp_out_hz_b),//分隔屏出口焓值B
                            new MySql.Data.MySqlClient.MySqlParameter("@Fgp_out_hz_c", fgp_out_hz_c),//分隔屏出口焓值C
                            new MySql.Data.MySqlClient.MySqlParameter("@Fgp_out_hz_d", fgp_out_hz_d),//分隔屏出口焓值D
                            new MySql.Data.MySqlClient.MySqlParameter("@Fgp_press_in_a", fgp_press_in_a),//分隔屏进口压力A
                            new MySql.Data.MySqlClient.MySqlParameter("@Fgp_press_in_b", fgp_press_in_b),//分隔屏进口压力B
                            new MySql.Data.MySqlClient.MySqlParameter("@Fgp_press_in_c", fgp_press_in_c),//分隔屏进口压力C
                            new MySql.Data.MySqlClient.MySqlParameter("@Fgp_press_in_d", fgp_press_in_d),//分隔屏进口压力D
                            new MySql.Data.MySqlClient.MySqlParameter("@Fgp_temp_in_a", fgp_in_temp_a),//分隔屏进口温度A
                            new MySql.Data.MySqlClient.MySqlParameter("@Fgp_temp_in_b", fgp_in_temp_b),//分隔屏进口温度B
                            new MySql.Data.MySqlClient.MySqlParameter("@Fgp_temp_in_c", fgp_in_temp_c),//分隔屏进口温度C
                            new MySql.Data.MySqlClient.MySqlParameter("@Fgp_temp_in_d", fgp_in_temp_d),//分隔屏进口温度D
                            new MySql.Data.MySqlClient.MySqlParameter("@Fgp_in_hz_a", fgp_in_hz_a),//分隔屏进口焓值A
                            new MySql.Data.MySqlClient.MySqlParameter("@Fgp_in_hz_b", fgp_in_hz_b),//分隔屏进口焓值B
                            new MySql.Data.MySqlClient.MySqlParameter("@Fgp_in_hz_c", fgp_in_hz_c),//分隔屏进口焓值C
                            new MySql.Data.MySqlClient.MySqlParameter("@Fgp_in_hz_d", fgp_in_hz_d),//分隔屏进口焓值D
                            new MySql.Data.MySqlClient.MySqlParameter("@Hp_press_out_a", hp_press_out_a),//后屏出口压力A
                            new MySql.Data.MySqlClient.MySqlParameter("@Hp_press_out_b", hp_press_out_b),//后屏出口压力B
                            new MySql.Data.MySqlClient.MySqlParameter("@Hp_press_out_c", hp_press_out_c),//后屏出口压力C
                            new MySql.Data.MySqlClient.MySqlParameter("@Hp_press_out_d", hp_press_out_d),//后屏出口压力D
                            new MySql.Data.MySqlClient.MySqlParameter("@Hp_temp_out_a", hp_out_temp_a),//后屏出口温度A
                            new MySql.Data.MySqlClient.MySqlParameter("@Hp_temp_out_b", hp_out_temp_b),//后屏出口温度B
                            new MySql.Data.MySqlClient.MySqlParameter("@Hp_temp_out_c", hp_out_temp_c),//后屏出口温度C
                            new MySql.Data.MySqlClient.MySqlParameter("@Hp_temp_out_d", hp_out_temp_d),//后屏出口温度D
                            new MySql.Data.MySqlClient.MySqlParameter("@Hp_out_hz_a", hp_out_hz_a),//后屏出口焓值A
                            new MySql.Data.MySqlClient.MySqlParameter("@Hp_out_hz_b", hp_out_hz_b),//后屏出口焓值B
                            new MySql.Data.MySqlClient.MySqlParameter("@Hp_out_hz_c", hp_out_hz_c),//后屏出口焓值C
                            new MySql.Data.MySqlClient.MySqlParameter("@Hp_out_hz_d", hp_out_hz_d),//后屏出口焓值D
                            new MySql.Data.MySqlClient.MySqlParameter("@Hp_press_in_a", hp_press_in_a),//后屏进口压力A
                            new MySql.Data.MySqlClient.MySqlParameter("@Hp_press_in_b", hp_press_in_b),//后屏进口压力B
                            new MySql.Data.MySqlClient.MySqlParameter("@Hp_press_in_c", hp_press_in_c),//后屏进口压力C
                            new MySql.Data.MySqlClient.MySqlParameter("@Hp_press_in_d", hp_press_in_d),//后屏进口压力D
                            new MySql.Data.MySqlClient.MySqlParameter("@Hp_temp_in_a", hp_in_temp_a),//后屏进口温度A
                            new MySql.Data.MySqlClient.MySqlParameter("@Hp_temp_in_b", hp_in_temp_b),//后屏进口温度B
                            new MySql.Data.MySqlClient.MySqlParameter("@Hp_temp_in_c", hp_in_temp_c),//后屏进口温度C
                            new MySql.Data.MySqlClient.MySqlParameter("@Hp_temp_in_d", hp_in_temp_d),//后屏进口温度D
                            new MySql.Data.MySqlClient.MySqlParameter("@Hp_in_hz_a", hp_in_hz_a),//后屏进口焓值A
                            new MySql.Data.MySqlClient.MySqlParameter("@Hp_in_hz_b", hp_in_hz_b),//后屏进口焓值B
                            new MySql.Data.MySqlClient.MySqlParameter("@Hp_in_hz_c", hp_in_hz_c),//后屏进口焓值C
                            new MySql.Data.MySqlClient.MySqlParameter("@Hp_in_hz_d", hp_in_hz_d),//后屏进口焓值D
                            new MySql.Data.MySqlClient.MySqlParameter("@Mg_temp_out_a", mg_out_temp_a),//末级过热器出口温度A
                            new MySql.Data.MySqlClient.MySqlParameter("@Mg_temp_out_b", mg_out_temp_b),//末级过热器出口温度B
                            new MySql.Data.MySqlClient.MySqlParameter("@Mg_temp_out_c", mg_out_temp_c),//末级过热器出口温度C
                            new MySql.Data.MySqlClient.MySqlParameter("@Mg_temp_out_d", mg_out_temp_d),//末级过热器出口温度D
                            new MySql.Data.MySqlClient.MySqlParameter("@Mg_out_hz_a", mg_out_hz_a),//末级过热器出口焓值A
                            new MySql.Data.MySqlClient.MySqlParameter("@Mg_out_hz_b", mg_out_hz_b),//末级过热器出口焓值B
                            new MySql.Data.MySqlClient.MySqlParameter("@Mg_out_hz_c", mg_out_hz_c),//末级过热器出口焓值C
                            new MySql.Data.MySqlClient.MySqlParameter("@Mg_out_hz_d", mg_out_hz_d),//末级过热器出口焓值D
                            new MySql.Data.MySqlClient.MySqlParameter("@Mg_press_in_a", mg_press_in_a),//末级过热器进口压力A
                            new MySql.Data.MySqlClient.MySqlParameter("@Mg_press_in_b", mg_press_in_b),//末级过热器进口压力B
                            new MySql.Data.MySqlClient.MySqlParameter("@Mg_press_in_c", mg_press_in_c),//末级过热器进口压力C
                            new MySql.Data.MySqlClient.MySqlParameter("@Mg_press_in_d", mg_press_in_d),//末级过热器进口压力D
                            new MySql.Data.MySqlClient.MySqlParameter("@Mg_temp_in_a", mg_in_temp_a),//末级过热器进口温度A
                            new MySql.Data.MySqlClient.MySqlParameter("@Mg_temp_in_b", mg_in_temp_b),//末级过热器进口温度B
                            new MySql.Data.MySqlClient.MySqlParameter("@Mg_temp_in_c", mg_in_temp_c),//末级过热器进口温度C
                            new MySql.Data.MySqlClient.MySqlParameter("@Mg_temp_in_d", mg_in_temp_d),//末级过热器进口温度D
                            new MySql.Data.MySqlClient.MySqlParameter("@Mg_in_hz_a", mg_in_hz_a),//末级过热器进口焓值A
                            new MySql.Data.MySqlClient.MySqlParameter("@Mg_in_hz_b", mg_in_hz_b),//末级过热器进口焓值B
                            new MySql.Data.MySqlClient.MySqlParameter("@Mg_in_hz_c", mg_in_hz_c),//末级过热器进口焓值C
                            new MySql.Data.MySqlClient.MySqlParameter("@Mg_in_hz_d", mg_in_hz_d),//末级过热器进口焓值D
                            new MySql.Data.MySqlClient.MySqlParameter("@Dz_press_in_left", dz_in_press_left),//低温再热器进口压力左侧
                            new MySql.Data.MySqlClient.MySqlParameter("@Dz_press_in_right", dz_in_press_right),//低温再热器进口压力右侧
                            new MySql.Data.MySqlClient.MySqlParameter("@Gz_press_out_left", gz_out_press_left),//高温再热器出口压力左侧
                            new MySql.Data.MySqlClient.MySqlParameter("@Gz_press_out_right", gz_out_press_right),//高温再热器出口压力右侧
                            new MySql.Data.MySqlClient.MySqlParameter("@Dz_press_out_left", dz_press_out_left),//低温再热器出口压力左侧
                            new MySql.Data.MySqlClient.MySqlParameter("@Dz_press_out_right", dz_press_out_right),//低温再热器出口压力右侧
                            new MySql.Data.MySqlClient.MySqlParameter("@Dz_temp_out_left", dz_out_temp_left),//低温再热器出口温度左侧
                            new MySql.Data.MySqlClient.MySqlParameter("@Dz_temp_out_right", dz_out_temp_right),//低温再热器出口温度右侧
                            new MySql.Data.MySqlClient.MySqlParameter("@Dz_out_hz_left", dz_out_hz_left),//低温再热器出口焓值左侧
                            new MySql.Data.MySqlClient.MySqlParameter("@Dz_out_hz_right", dz_out_hz_right),//低温再热器出口焓值右侧
                            new MySql.Data.MySqlClient.MySqlParameter("@Dz_temp_in_left", dz_in_temp_left),//低温再热器进口温度左侧
                            new MySql.Data.MySqlClient.MySqlParameter("@Dz_temp_in_right", dz_in_temp_right),//低温再热器进口温度右侧
                            new MySql.Data.MySqlClient.MySqlParameter("@Dz_in_hz_left", dz_in_hz_left),//低温再热器进口焓值左侧
                            new MySql.Data.MySqlClient.MySqlParameter("@Dz_in_hz_right", dz_in_hz_right),//低温再热器进口焓值右侧
                            new MySql.Data.MySqlClient.MySqlParameter("@Gz_temp_out_left", gz_out_temp_left),//高温再热器出口温度左侧
                            new MySql.Data.MySqlClient.MySqlParameter("@Gz_temp_out_right", gz_out_temp_right),//高温再热器出口温度右侧
                            new MySql.Data.MySqlClient.MySqlParameter("@Gz_out_hz_left", gz_out_hz_left),//高温再热器出口焓值左侧
                            new MySql.Data.MySqlClient.MySqlParameter("@Gz_out_hz_right", gz_out_hz_right),//高温再热器出口焓值右侧
                            new MySql.Data.MySqlClient.MySqlParameter("@Gz_press_in_left", gz_press_in_left),//高温再热器进口压力左侧
                            new MySql.Data.MySqlClient.MySqlParameter("@Gz_press_in_right", gz_press_in_right),//高温再热器进口压力右侧
                            new MySql.Data.MySqlClient.MySqlParameter("@Gz_temp_in_left", gz_in_temp_left),//高温再热器进口温度左侧
                            new MySql.Data.MySqlClient.MySqlParameter("@Gz_temp_in_right", gz_in_temp_right),//高温再热器进口温度右侧
                            new MySql.Data.MySqlClient.MySqlParameter("@Gz_in_hz_left", gz_in_hz_left),//高温再热器进口焓值左侧
                            new MySql.Data.MySqlClient.MySqlParameter("@Gz_in_hz_right", gz_in_hz_right),//高温再热器进口焓值右侧
                            new MySql.Data.MySqlClient.MySqlParameter("@Left_qy_o2_left_avg", left_qy_o2_left_avg),//左切圆左侧氧量平均值
                            new MySql.Data.MySqlClient.MySqlParameter("@Left_qy_o2_right_avg", left_qy_o2_right_avg),//左切圆右侧氧量平均值
                            new MySql.Data.MySqlClient.MySqlParameter("@Left_qy_back_xdg_left_top", left_qy_back_xdg_left_top),//左切圆后墙悬吊管水冷壁左侧最高点
                            new MySql.Data.MySqlClient.MySqlParameter("@Left_qy_back_xdg_right_top", left_qy_back_xdg_right_top),//左切圆后墙悬吊管水冷壁右侧最高点
                            new MySql.Data.MySqlClient.MySqlParameter("@Right_qy_o2_left_avg", right_qy_o2_left_avg),//右切圆左侧氧量平均值
                            new MySql.Data.MySqlClient.MySqlParameter("@Right_qy_o2_right_avg", right_qy_o2_right_avg),//右切圆右侧氧量平均值
                            new MySql.Data.MySqlClient.MySqlParameter("@Right_qy_back_xdg_left_top", right_qy_back_xdg_left_top),//右切圆后墙悬吊管水冷壁左侧最高点
                            new MySql.Data.MySqlClient.MySqlParameter("@Right_qy_back_xdg_right_top", right_qy_back_xdg_right_top),//右切圆后墙悬吊管水冷壁右侧最高点
                            new MySql.Data.MySqlClient.MySqlParameter("@Left_czd_temp", left_czd_temp),//左墙垂直段水冷壁温度
                            new MySql.Data.MySqlClient.MySqlParameter("@Right_czd_temp", right_czd_temp),//右墙垂直段水冷壁温度
                            new MySql.Data.MySqlClient.MySqlParameter("@Left_qy_back_xdg_left_top3_avg", left_qy_back_xdg_left_top3_avg),//左切圆后墙悬吊管水冷壁左侧最高三个点平均值
                            new MySql.Data.MySqlClient.MySqlParameter("@Left_qy_back_xdg_right_top3_avg", left_qy_back_xdg_right_top3_avg),//左切圆后墙悬吊管水冷壁右侧最高三个点平均值
                            new MySql.Data.MySqlClient.MySqlParameter("@Left_lxd_top10_avg", left_lxd_top10_avg),//左墙螺旋段水冷壁最高10个点的平均值
                            new MySql.Data.MySqlClient.MySqlParameter("@Right_lxd_top10_avg", right_lxd_top10_avg),//右墙螺旋段水冷壁最高10个点的平均值
                            new MySql.Data.MySqlClient.MySqlParameter("@Right_qy_back_xdg_left_top3_avg", right_qy_back_xdg_left_top3_avg),//右切圆后墙悬吊管水冷壁左侧最高三个点平均值
                            new MySql.Data.MySqlClient.MySqlParameter("@Right_qy_back_xdg_right_top3_avg", right_qy_back_xdg_right_top3_avg),//右切圆后墙悬吊管水冷壁右侧最高三个点平均值
                            new MySql.Data.MySqlClient.MySqlParameter("@Left_qy_back_gp_temp", left_qy_back_gp_temp),//左切圆后墙管屏水冷壁温度
                            new MySql.Data.MySqlClient.MySqlParameter("@Right_qy_back_gp_temp", right_qy_back_gp_temp),//右切圆后墙管屏水冷壁温度
                            new MySql.Data.MySqlClient.MySqlParameter("@Left_qy_front_gp_temp", left_qy_front_cz_temp),//左切圆前墙垂直水冷壁温度
                            new MySql.Data.MySqlClient.MySqlParameter("@Right_qy_front_gp_temp", right_qy_front_cz_temp),//右切圆前墙垂直水冷壁温度
                            new MySql.Data.MySqlClient.MySqlParameter("@Left_qy_back_lxd_top10_avg", left_qy_back_lxd_top10_avg),//左切圆后墙螺旋段水冷壁温度最高10个点的平均值
                            new MySql.Data.MySqlClient.MySqlParameter("@Right_qy_back_lxd_top10_avg", right_qy_back_lxd_top10_avg),//右切圆后墙螺旋段水冷壁温度最高10个点的平均值
                            new MySql.Data.MySqlClient.MySqlParameter("@Left_qy_front_lxd_top10_avg", left_qy_front_lxd_top10_avg),//左切圆前墙螺旋段水冷壁温度最高10个点的平均值
                            new MySql.Data.MySqlClient.MySqlParameter("@Right_qy_front_lxd_top10_avg", right_qy_front_lxd_top10_avg),//右切圆前墙螺旋段水冷壁温度最高10个点的平均值
                            new MySql.Data.MySqlClient.MySqlParameter("@Dz_jws_press", dz_jws_press),//低温再热器减温水压力
                            new MySql.Data.MySqlClient.MySqlParameter("@Dz_jws_temp", dz_jws_temp),//低温再热器减温水温度
                            new MySql.Data.MySqlClient.MySqlParameter("@Dz_jws_hz", dz_jws_hz),//低温再热器减温水焓值
                            new MySql.Data.MySqlClient.MySqlParameter("@Dz_jwq_front_left", dz_jwq_front_left),//低温再热器减温器前温度（左侧）
                            new MySql.Data.MySqlClient.MySqlParameter("@Dz_jwq_back_left", dz_jwq_back_left),//低温再热器减温器后温度（左侧）
                            new MySql.Data.MySqlClient.MySqlParameter("@Dz_jwq_front_right", dz_jwq_front_right),//低温再热器减温器前温度（右侧）
                            new MySql.Data.MySqlClient.MySqlParameter("@Dz_jwq_back_right", dz_jwq_back_right),//低温再热器减温器后温度（右侧）
                            new MySql.Data.MySqlClient.MySqlParameter("@Dz_jwq_front_hz_left", dz_jwq_front_hz_left),//低温再热器减温器前再热蒸汽焓值（左侧）
                            new MySql.Data.MySqlClient.MySqlParameter("@Dz_jwq_back_hz_left", dz_jwq_back_hz_left),//低温再热器减温器后再热蒸汽焓值（左侧）
                            new MySql.Data.MySqlClient.MySqlParameter("@Dz_jwq_front_hz_right", dz_jwq_front_hz_right),//低温再热器减温器前再热蒸汽焓值（右侧）
                            new MySql.Data.MySqlClient.MySqlParameter("@Dz_jwq_back_hz_right", dz_jwq_back_hz_right),//低温再热器减温器后再热蒸汽焓值（右侧）
                            new MySql.Data.MySqlClient.MySqlParameter("@Zrq_jws_left", zrq_jws_left),//再热器减温水量（左侧）
                            new MySql.Data.MySqlClient.MySqlParameter("@Zrq_jws_right", zrq_jws_right),//再热器减温水量（右侧）
                            new MySql.Data.MySqlClient.MySqlParameter("@Fgp_hz_design", fgp_hz_design),//分隔屏设计焓增
                            new MySql.Data.MySqlClient.MySqlParameter("@Hp_hz_design", hp_hz_design),//后屏设计焓增
                            new MySql.Data.MySqlClient.MySqlParameter("@Mg_hz_design", mg_hz_design),//末级过热器设计焓增
                            new MySql.Data.MySqlClient.MySqlParameter("@Dz_hz_design", dz_hz_design),//低温再热器设计焓增
                            new MySql.Data.MySqlClient.MySqlParameter("@Gz_hz_design", gz_hz_design),//高温再热器设计焓增
                            new MySql.Data.MySqlClient.MySqlParameter("@Grq_jws_hz", grq_jws_hz),//过热器减温水焓值
                            new MySql.Data.MySqlClient.MySqlParameter("@Status", 1),//状态
                            new MySql.Data.MySqlClient.MySqlParameter("@IsDeleted", del_status),//是否删除
                            new MySql.Data.MySqlClient.MySqlParameter("@DncBoilerId", boilerid),//锅炉ID
                            new MySql.Data.MySqlClient.MySqlParameter("@DncBoiler_Name", boiler_name),//锅炉描述
                            new MySql.Data.MySqlClient.MySqlParameter("@Left_qy_back_xdg_left_top_point", left_qy_back_xdg_left_top_point),//左切圆后墙悬吊管水冷壁左侧最高点
                            new MySql.Data.MySqlClient.MySqlParameter("@Left_qy_back_xdg_right_top_point", left_qy_back_xdg_right_top_point),//左切圆后墙悬吊管水冷壁右侧最高点
                            new MySql.Data.MySqlClient.MySqlParameter("@Right_qy_back_xdg_left_top_point", right_qy_back_xdg_left_top_point),//右切圆后墙悬吊管水冷壁左侧最高点
                            new MySql.Data.MySqlClient.MySqlParameter("@Right_qy_back_xdg_right_top_point", right_qy_back_xdg_right_top_point),//右切圆后墙悬吊管水冷壁右侧最高点
                            new MySql.Data.MySqlClient.MySqlParameter("@Left_qy_back_xdg_left_top3", left_qy_back_xdg_left_top3),//左切圆后墙悬吊管水冷壁左侧最高三个点
                            new MySql.Data.MySqlClient.MySqlParameter("@Left_qy_back_xdg_right_top3", left_qy_back_xdg_right_top3),//左切圆后墙悬吊管水冷壁右侧最高三个点
                            new MySql.Data.MySqlClient.MySqlParameter("@Right_qy_back_xdg_left_top3", right_qy_back_xdg_left_top3),//右切圆后墙悬吊管水冷壁左侧最高三个点
                            new MySql.Data.MySqlClient.MySqlParameter("@Right_qy_back_xdg_right_top3", right_qy_back_xdg_right_top3),//右切圆后墙悬吊管水冷壁右侧最高三个点
                            new MySql.Data.MySqlClient.MySqlParameter("@Dg_hz_design", dg_hz_design)//低温过热器设计焓增
                            );
                         //    */                        
                            double dg_temp_out_left = (dg_out_temp_a + dg_out_temp_b) / 2;//低温过热器左侧出口温度
                            double dg_temp_out_right = (dg_out_temp_c + dg_out_temp_d) / 2;//低温过热器左侧出口温度
                            double dg_hz_a = dg_out_hz_a - dg_in_hz_a;//低温过热器焓增A
                            double dg_hz_b = dg_out_hz_b - dg_in_hz_b;//低温过热器焓增B
                            double dg_hz_c = dg_out_hz_c - dg_in_hz_c;//低温过热器焓增C
                            double dg_hz_d = dg_out_hz_d - dg_in_hz_d;//低温过热器焓增D

                            double fgp_temp_out_left = (fgp_out_temp_a + fgp_out_temp_b) / 2;//分隔屏左侧出口温度
                            double fgp_temp_out_right = (fgp_out_temp_c + fgp_out_temp_d) / 2;//分隔屏左侧出口温度
                            double fgp_hz_a = fgp_out_hz_a - fgp_in_hz_a;//分隔屏焓增A
                            double fgp_hz_b = fgp_out_hz_b - fgp_in_hz_b;//分隔屏焓增B
                            double fgp_hz_c = fgp_out_hz_c - fgp_in_hz_c;//分隔屏焓增C
                            double fgp_hz_d = fgp_out_hz_d - fgp_in_hz_d;//分隔屏焓增D

                            double hp_temp_out_left = (hp_out_temp_a + hp_out_temp_b) / 2;//后屏左侧出口温度
                            double hp_temp_out_right = (hp_out_temp_c + hp_out_temp_d) / 2;//后屏左侧出口温度
                            double hp_hz_a = hp_out_hz_a - hp_in_hz_a;//后屏焓增A
                            double hp_hz_b = hp_out_hz_b - hp_in_hz_b;//后屏焓增B
                            double hp_hz_c = hp_out_hz_c - hp_in_hz_c;//后屏焓增C
                            double hp_hz_d = hp_out_hz_d - hp_in_hz_d;//后屏焓增D

                            double mg_temp_out_left = (mg_out_temp_a + mg_out_temp_b) / 2;//末级过热器左侧出口温度
                            double mg_temp_out_right = (mg_out_temp_c + mg_out_temp_d) / 2;//末级过热器左侧出口温度
                            double mg_hz_a = mg_out_hz_a - mg_in_hz_a;//末级过热器焓增A
                            double mg_hz_b = mg_out_hz_b - mg_in_hz_b;//末级过热器焓增B
                            double mg_hz_c = mg_out_hz_c - mg_in_hz_c;//末级过热器焓增C
                            double mg_hz_d = mg_out_hz_d - mg_in_hz_d;//末级过热器焓增D

                            double dz_hz_left = dz_out_hz_left - dz_in_hz_left;//低温再热器焓增左侧
                            double dz_hz_right = dz_out_hz_right - dz_in_hz_right;//低温再热器焓增右侧
                            double gz_hz_left = gz_out_hz_left - gz_in_hz_left;//高温再热器焓增左侧
                            double gz_hz_right = gz_out_hz_right - gz_in_hz_right;//高温再热器焓增右侧

                            double cql = Compute.Avgdata(dic["110"]);//抽气量;
                            double dz_jws_mh = (zrq_jws_left + zrq_jws_right) * zrq_jws_mh_xs;//再热器减温水对煤耗影响
                            double gz_temp_mh = (gz_out_temp_ed - (gz_out_temp_left + gz_out_temp_right) / 2) * gz_out_temp_mh_xs;//再热器出口蒸汽温度对煤耗影响
                            double mg_temp_mh = (mg_out_temp_ed - (mg_temp_out_left + mg_temp_out_right) / 2) * mg_out_temp_mh_xs;//过热器出口蒸汽温度对煤耗影响

                            double o2_avg = Compute.Avgdata(dic["91"]);//O2氧量平均值
                            double nox_avg = Compute.Avgdata(dic["92"]);//NOx氧量平均值

                            double o2_high = FindValue(o2_high_zone);//O2氧量偏高值
                            double o2_low = FindValue(o2_low_zone);//O2氧量偏低值
                            double nox_high = FindValue(nox_high_zone);//nox氧量偏高值
                            double nox_low = FindValue(nox_low_zone);//nox氧量偏低值

                            double dg_zwxs = dg_hz_design / ((dg_hz_a + dg_hz_b + dg_hz_c + dg_hz_d) / 4) * dg_design_zwxs;//低温过热器沾污程度
                            double fgp_zwxs = fgp_hz_design / ((fgp_hz_a + fgp_hz_b + fgp_hz_c + fgp_hz_d) / 4) * fgp_design_zwxs;//分隔屏沾污程度
                            double hp_zwxs = hp_hz_design / ((hp_hz_a + hp_hz_b + hp_hz_c + hp_hz_d) / 4) * hp_design_zwxs;//后屏沾污程度
                            double mg_zwxs = mg_hz_design / ((mg_hz_a + mg_hz_b + mg_hz_c + mg_hz_d) / 4) * mg_design_zwxs;//末级过热器沾污程度
                            double dz_zwxs = dz_hz_design / ((dz_hz_left + dz_hz_right) / 2) * dz_design_zwxs;//低温再热器沾污程度
                            double gz_zwxs = gz_hz_design / ((gz_hz_left + gz_hz_right) / 2) * gz_design_zwxs;//高温再热器沾污程度

                            double gsll = Compute.Avgdata(dic["111"]);//给水流量测点平均值
                            //一级过热器减温水量={(h前-h后)/(h后-h减)*(流量测点)}
                            //h前：减温器前蒸汽焓值=低过出口焓值
                            //h后：减温器后蒸汽焓值=分隔屏进口焓值
                            //h减：过热器减温水焓值
                            //流量测点：给水流量测点 
                            double grq_jws_1a = Grqjws(dg_out_hz_a, fgp_in_hz_a, gsll); //过热器一级减温水量A
                            double grq_jws_1b = Grqjws(dg_out_hz_b, fgp_in_hz_b, gsll);//过热器一级减温水量B
                            double grq_jws_1c = Grqjws(dg_out_hz_c, fgp_in_hz_c, gsll);//过热器一级减温水量C
                            double grq_jws_1d = Grqjws(dg_out_hz_d, fgp_in_hz_d, gsll);//过热器一级减温水量D

                            //二级过热器减温水量={(h前-h后)/(h后-h减)*(流量测点)}
                            // h前：减温器前蒸汽焓值 = 分隔屏出口焓值
                            //h后：减温器后蒸汽焓值 = 后屏进口焓值（AB有交叉、CD交叉）
                            //h减：过热器减温水焓值
                            //流量测点 = 给水流量测点 + 一级减温水流量
                            double grq_jws_2a = Grqjws(fgp_out_hz_a, hp_in_hz_b, gsll + grq_jws_1a); //过热器二级减温水量A
                            double grq_jws_2b = Grqjws(fgp_out_hz_b, hp_in_hz_a, gsll + grq_jws_1b); //过热器二级减温水量B
                            double grq_jws_2c = Grqjws(fgp_out_hz_c, hp_in_hz_d, gsll + grq_jws_1c); //过热器二级减温水量C
                            double grq_jws_2d = Grqjws(fgp_out_hz_d, hp_in_hz_c, gsll + grq_jws_1d); //过热器二级减温水量D

                            //三级过热器减温水量={(h前-h后)/(h后-h减)*(流量测点)}
                            //h前：减温器前蒸汽焓值 = 后屏出口焓值
                            //h后：减温器后蒸汽焓值 = 高过进口焓值（AB有交叉、CD交叉）
                            //h减：过热器减温水焓值
                            //流量测点 = 给水流量测点 + 一级减温水流量 + 二级减温水流量
                            double grq_jws_3a = Grqjws(hp_out_hz_a, mg_in_hz_b, gsll + grq_jws_1a + grq_jws_2a); //过热器三级减温水量A
                            double grq_jws_3b = Grqjws(hp_out_hz_b, mg_in_hz_a, gsll + grq_jws_1b + grq_jws_2b); //过热器三级减温水量B
                            double grq_jws_3c = Grqjws(hp_out_hz_c, mg_in_hz_d, gsll + grq_jws_1c + grq_jws_2c); //过热器三级减温水量C
                            double grq_jws_3d = Grqjws(hp_out_hz_d, mg_in_hz_c, gsll + grq_jws_1d + grq_jws_2d); //过热器三级减温水量D

                            double dz_yqdb_kd = Compute.Avgdata(dic["113"]);//低再侧烟气挡板开度
                        /*
                            db.CommandExecuteNonQuery(db.ConnectString, "insert into Dnchztemp_real(RealTime,Dg_hz_a,Dg_hz_b,Dg_hz_c,Dg_hz_d,Fgp_hz_a,Fgp_hz_b,Fgp_hz_c,Fgp_hz_d,Hp_hz_a,Hp_hz_b,Hp_hz_c,Hp_hz_d,Mg_hz_a,Mg_hz_b,Mg_hz_c,Mg_hz_d,Dz_hz_left,Dz_hz_right,Gz_hz_left,Gz_hz_right,Dg_temp_out_left,Dg_temp_out_right,Fgp_temp_out_left,Fgp_temp_out_right,Hp_temp_out_left,Hp_temp_out_right,Mg_temp_out_left,Mg_temp_out_right,Dz_temp_out_left,Dz_temp_out_right,Gz_temp_out_left,Gz_temp_out_right,Nox_avg,Nox_high,Nox_low,O2_avg,O2_high,O2_low,Yl_fh_out,Cql,Dz_jws_mh,Gz_temp_mh,Mg_temp_mh,Dg_zwxs,Fgp_zwxs,Hp_zwxs,Mg_zwxs,Dz_zwxs,Gz_zwxs,Grq_jws_1a,Grq_jws_1b,Grq_jws_1c,Grq_jws_1d,Grq_jws_2a,Grq_jws_2b,Grq_jws_2c,Grq_jws_2d,Grq_jws_3a,Grq_jws_3b,Grq_jws_3c,Grq_jws_3d,Status,IsDeleted,DncBoilerId,DncBoiler_Name,dz_yqdb_kd) values(@RealTime,@Dg_hz_a,@Dg_hz_b,@Dg_hz_c,@Dg_hz_d,@Fgp_hz_a,@Fgp_hz_b,@Fgp_hz_c,@Fgp_hz_d,@Hp_hz_a,@Hp_hz_b,@Hp_hz_c,@Hp_hz_d,@Mg_hz_a,@Mg_hz_b,@Mg_hz_c,@Mg_hz_d,@Dz_hz_left,@Dz_hz_right,@Gz_hz_left,@Gz_hz_right,@Dg_temp_out_left,@Dg_temp_out_right,@Fgp_temp_out_left,@Fgp_temp_out_right,@Hp_temp_out_left,@Hp_temp_out_right,@Mg_temp_out_left,@Mg_temp_out_right,@Dz_temp_out_left,@Dz_temp_out_right,@Gz_temp_out_left,@Gz_temp_out_right,@Nox_avg,@Nox_high,@Nox_low,@O2_avg,@O2_high,@O2_low,@Yl_fh_out,@Cql,@Dz_jws_mh,@Gz_temp_mh,@Mg_temp_mh,@Dg_zwxs,@Fgp_zwxs,@Hp_zwxs,@Mg_zwxs,@Dz_zwxs,@Gz_zwxs,@Grq_jws_1a,@Grq_jws_1b,@Grq_jws_1c,@Grq_jws_1d,@Grq_jws_2a,@Grq_jws_2b,@Grq_jws_2c,@Grq_jws_2d,@Grq_jws_3a,@Grq_jws_3b,@Grq_jws_3c,@Grq_jws_3d,@Status,@IsDeleted,@DncBoilerId,@DncBoiler_Name,@dz_yqdb_kd)",
                            new MySql.Data.MySqlClient.MySqlParameter("@RealTime", csyntime),//当前时间
                            new MySql.Data.MySqlClient.MySqlParameter("@Dg_hz_a", dg_hz_a),//低温过热器焓增A
                            new MySql.Data.MySqlClient.MySqlParameter("@Dg_hz_b", dg_hz_b),//低温过热器焓增B
                            new MySql.Data.MySqlClient.MySqlParameter("@Dg_hz_c", dg_hz_c),//低温过热器焓增C
                            new MySql.Data.MySqlClient.MySqlParameter("@Dg_hz_d", dg_hz_d),//低温过热器焓增D
                            new MySql.Data.MySqlClient.MySqlParameter("@Fgp_hz_a", fgp_hz_a),//分隔屏焓增A
                            new MySql.Data.MySqlClient.MySqlParameter("@Fgp_hz_b", fgp_hz_b),//分隔屏焓增B
                            new MySql.Data.MySqlClient.MySqlParameter("@Fgp_hz_c", fgp_hz_c),//分隔屏焓增C
                            new MySql.Data.MySqlClient.MySqlParameter("@Fgp_hz_d", fgp_hz_d),//分隔屏焓增D
                            new MySql.Data.MySqlClient.MySqlParameter("@Hp_hz_a", hp_hz_a),//后屏焓增A
                            new MySql.Data.MySqlClient.MySqlParameter("@Hp_hz_b", hp_hz_b),//后屏焓增B
                            new MySql.Data.MySqlClient.MySqlParameter("@Hp_hz_c", hp_hz_c),//后屏焓增C
                            new MySql.Data.MySqlClient.MySqlParameter("@Hp_hz_d", hp_hz_d),//后屏焓增D
                            new MySql.Data.MySqlClient.MySqlParameter("@Mg_hz_a", mg_hz_a),//末级过热器焓增A
                            new MySql.Data.MySqlClient.MySqlParameter("@Mg_hz_b", mg_hz_b),//末级过热器焓增B
                            new MySql.Data.MySqlClient.MySqlParameter("@Mg_hz_c", mg_hz_c),//末级过热器焓增C
                            new MySql.Data.MySqlClient.MySqlParameter("@Mg_hz_d", mg_hz_d),//末级过热器焓增D
                            new MySql.Data.MySqlClient.MySqlParameter("@Dz_hz_left", dz_hz_left),//低温再热器焓增左侧
                            new MySql.Data.MySqlClient.MySqlParameter("@Dz_hz_right", dz_hz_right),//低温再热器焓增右侧
                            new MySql.Data.MySqlClient.MySqlParameter("@Gz_hz_left", gz_hz_left),//高温再热器焓增左侧
                            new MySql.Data.MySqlClient.MySqlParameter("@Gz_hz_right", gz_hz_right),//高温再热器焓增右侧
                            new MySql.Data.MySqlClient.MySqlParameter("@Dg_temp_out_left", dg_temp_out_left),//低温过热器左侧出口温度
                            new MySql.Data.MySqlClient.MySqlParameter("@Dg_temp_out_right", dg_temp_out_right),//低温过热器右侧出口温度
                            new MySql.Data.MySqlClient.MySqlParameter("@Fgp_temp_out_left", fgp_temp_out_left),//分隔屏左出口温度
                            new MySql.Data.MySqlClient.MySqlParameter("@Fgp_temp_out_right", fgp_temp_out_right),//分隔屏右出口温度
                            new MySql.Data.MySqlClient.MySqlParameter("@Hp_temp_out_left", hp_temp_out_left),//后屏左出口温度
                            new MySql.Data.MySqlClient.MySqlParameter("@Hp_temp_out_right", hp_temp_out_right),//后屏右出口温度
                            new MySql.Data.MySqlClient.MySqlParameter("@Mg_temp_out_left", mg_temp_out_left),//高过左出口温度
                            new MySql.Data.MySqlClient.MySqlParameter("@Mg_temp_out_right", mg_temp_out_right),//高过右出口温度
                            new MySql.Data.MySqlClient.MySqlParameter("@Dz_temp_out_left", dz_out_temp_left),//低再左出口温度
                            new MySql.Data.MySqlClient.MySqlParameter("@Dz_temp_out_right", dz_out_temp_right),//低再右出口温度
                            new MySql.Data.MySqlClient.MySqlParameter("@Gz_temp_out_left", gz_out_temp_left),//高再左出口温度
                            new MySql.Data.MySqlClient.MySqlParameter("@Gz_temp_out_right", gz_out_temp_right),//高再右出口温度
                            new MySql.Data.MySqlClient.MySqlParameter("@Nox_avg", nox_avg),//nox测点平均值
                            new MySql.Data.MySqlClient.MySqlParameter("@Nox_high", nox_high),//NOx偏高值
                            new MySql.Data.MySqlClient.MySqlParameter("@Nox_low", nox_low),//O2氧量偏低值
                            new MySql.Data.MySqlClient.MySqlParameter("@O2_avg", o2_avg),//O2测点平均值
                            new MySql.Data.MySqlClient.MySqlParameter("@O2_high", o2_high),//O2氧量偏高值
                            new MySql.Data.MySqlClient.MySqlParameter("@O2_low", o2_low),//O2氧量偏低值
                            new MySql.Data.MySqlClient.MySqlParameter("@Yl_fh_out", yl_fh_out),//机组实时负荷
                            new MySql.Data.MySqlClient.MySqlParameter("@Cql", cql),//抽汽量
                            new MySql.Data.MySqlClient.MySqlParameter("@Dz_jws_mh", dz_jws_mh),//再热器减温水对煤耗影响
                            new MySql.Data.MySqlClient.MySqlParameter("@Gz_temp_mh", gz_temp_mh),//再热器出口蒸汽温度对煤耗影响
                            new MySql.Data.MySqlClient.MySqlParameter("@Mg_temp_mh", mg_temp_mh),//过热器出口蒸汽温度对煤耗影响
                            new MySql.Data.MySqlClient.MySqlParameter("@Dg_zwxs", dg_zwxs),//低温过热器沾污程度
                            new MySql.Data.MySqlClient.MySqlParameter("@Fgp_zwxs", fgp_zwxs),//分隔屏粘污系数
                            new MySql.Data.MySqlClient.MySqlParameter("@Hp_zwxs", hp_zwxs),//后屏粘污系数
                            new MySql.Data.MySqlClient.MySqlParameter("@Mg_zwxs", mg_zwxs),//高过粘污系数
                            new MySql.Data.MySqlClient.MySqlParameter("@Dz_zwxs", dz_zwxs),//低再粘污系数
                            new MySql.Data.MySqlClient.MySqlParameter("@Gz_zwxs", gz_zwxs),//高再粘污系数
                            new MySql.Data.MySqlClient.MySqlParameter("@Grq_jws_1a", grq_jws_1a),//过热器一级减温水量A
                            new MySql.Data.MySqlClient.MySqlParameter("@Grq_jws_1b", grq_jws_1b),//过热器一级减温水量B
                            new MySql.Data.MySqlClient.MySqlParameter("@Grq_jws_1c", grq_jws_1c),//过热器一级减温水量C
                            new MySql.Data.MySqlClient.MySqlParameter("@Grq_jws_1d", grq_jws_1d),//过热器一级减温水量D
                            new MySql.Data.MySqlClient.MySqlParameter("@Grq_jws_2a", grq_jws_2a),//过热器二级减温水量A
                            new MySql.Data.MySqlClient.MySqlParameter("@Grq_jws_2b", grq_jws_2b),//过热器二级减温水量B
                            new MySql.Data.MySqlClient.MySqlParameter("@Grq_jws_2c", grq_jws_2c),//过热器二级减温水量C
                            new MySql.Data.MySqlClient.MySqlParameter("@Grq_jws_2d", grq_jws_2d),//过热器二级减温水量D
                            new MySql.Data.MySqlClient.MySqlParameter("@Grq_jws_3a", grq_jws_3a),//过热器三级减温水量A
                            new MySql.Data.MySqlClient.MySqlParameter("@Grq_jws_3b", grq_jws_3b),//过热器三级减温水量B
                            new MySql.Data.MySqlClient.MySqlParameter("@Grq_jws_3c", grq_jws_3c),//过热器三级减温水量C
                            new MySql.Data.MySqlClient.MySqlParameter("@Grq_jws_3d", grq_jws_3d),//过热器三级减温水量D
                            new MySql.Data.MySqlClient.MySqlParameter("@Status", 1),//状态
                            new MySql.Data.MySqlClient.MySqlParameter("@IsDeleted", del_status),//是否删除
                            new MySql.Data.MySqlClient.MySqlParameter("@DncBoilerId", boilerid),//锅炉ID
                            new MySql.Data.MySqlClient.MySqlParameter("@DncBoiler_Name", boiler_name),//锅炉描述
                            new MySql.Data.MySqlClient.MySqlParameter("@dz_yqdb_kd", dz_yqdb_kd)//低再侧烟气挡板开度
                            );
                         */

                        string sql_error_para = "select fgp_hz_b_big_a,hp_hz_b_big_a,mg_hz_a_big_b,dz_hz_a_big_b,mz_hz_a_big_b,left_qy_yqnd_l_big_r,left_qy_xdgtop_l_big_r,xx_qxbz_error_num,fgp_hz_c_big_d,hp_hz_c_big_d,mg_hz_d_big_c,dz_hz_d_big_c,mz_hz_d_big_c,right_qy_yqnd_r_big_l,right_qy_xdgtop_r_big_l,fgp_hz_b_small_a,hp_hz_b_small_a,mg_hz_a_small_b,dz_hz_a_small_b,mz_hz_a_small_b,left_qy_yqnd_l_small_r,left_qy_xdgtop_l_small_r,fgp_hz_c_small_d,hp_hz_c_small_d,mg_hz_d_small_c,dz_hz_d_small_c,mz_hz_dsmall_c,right_qy_yqnd_r_small_l,right_qy_xdgtop_r_small_l,czd_temp_left_right,qy_back_xdg_top3_avg_l_r,lxd_temp_top10_l_r,qy_px_l_r_num,qy_gp_h_big_q,qy_lxd_q_h,qy_gp_q_big_h,qy_px_q_h_num from dncerror_parameter where  Status=1 and IsDeleted=0 and DncBoilerId=" + boilerid;
                        DataTable dt_error_para = db.GetCommand(sql_error_para);
                        double Fgp_hz_b_big_a = double.Parse(dt_error_para.Rows[0][0].ToString());//分隔屏焓增B比A高
                        double Hp_hz_b_big_a = double.Parse(dt_error_para.Rows[0][1].ToString());//后屏焓增B比A高
                        double Mg_hz_a_big_b = double.Parse(dt_error_para.Rows[0][2].ToString());//高过焓增A比B高
                        double Dz_hz_a_big_b = double.Parse(dt_error_para.Rows[0][3].ToString());//低再焓增A比B高
                        double Mz_hz_a_big_b = double.Parse(dt_error_para.Rows[0][4].ToString());//末再焓增A比B高
                        double Left_qy_yqnd_l_big_r = double.Parse(dt_error_para.Rows[0][5].ToString());//烟气浓度左比右高（左切圆）
                        double Left_qy_xdgtop_l_big_r = double.Parse(dt_error_para.Rows[0][6].ToString());//悬吊管最高点左比右高(左切圆)
                        int Xx_qxbz_error_num = int.Parse(dt_error_para.Rows[0][7].ToString());//消旋、起旋动量不足异常值条件数量
                        double Fgp_hz_c_big_d = double.Parse(dt_error_para.Rows[0][8].ToString());//分隔屏焓增C比D高
                        double Hp_hz_c_big_d = double.Parse(dt_error_para.Rows[0][9].ToString());//后屏焓增C比D高
                        double Mg_hz_d_big_c = double.Parse(dt_error_para.Rows[0][10].ToString());//高过焓增A比B高
                        double Dz_hz_d_big_c = double.Parse(dt_error_para.Rows[0][11].ToString());//低再焓增D比C高
                        double Mz_hz_d_big_c = double.Parse(dt_error_para.Rows[0][12].ToString());//末再焓增D比C高
                        double Right_qy_yqnd_r_big_l = double.Parse(dt_error_para.Rows[0][13].ToString());//烟气浓度右比左高（右切圆）
                        double Right_qy_xdgtop_r_big_l = double.Parse(dt_error_para.Rows[0][14].ToString());//悬吊管最高点右比左高(右切圆)
                        double Fgp_hz_b_small_a = double.Parse(dt_error_para.Rows[0][15].ToString());//分隔屏焓增B比A低
                        double Hp_hz_b_small_a = double.Parse(dt_error_para.Rows[0][16].ToString());//后屏焓增B比A低
                        double Mg_hz_a_small_b = double.Parse(dt_error_para.Rows[0][17].ToString());//高过焓增A比B低
                        double Dz_hz_a_small_b = double.Parse(dt_error_para.Rows[0][18].ToString());//低再焓增A比B低
                        double Mz_hz_a_small_b = double.Parse(dt_error_para.Rows[0][19].ToString());//末再焓增A比B低
                        double Left_qy_yqnd_l_small_r = double.Parse(dt_error_para.Rows[0][20].ToString());//烟气浓度右比左高（左切圆）
                        double Left_qy_xdgtop_l_small_r = double.Parse(dt_error_para.Rows[0][21].ToString());//悬吊管最高点右比左高(左切圆)
                        double Fgp_hz_c_small_d = double.Parse(dt_error_para.Rows[0][22].ToString());//分隔屏焓增C比D低
                        double Hp_hz_c_small_d = double.Parse(dt_error_para.Rows[0][23].ToString());//后屏焓增C比D低
                        double Mg_hz_d_small_c = double.Parse(dt_error_para.Rows[0][24].ToString());//高过焓增D比C低
                        double Dz_hz_d_small_c = double.Parse(dt_error_para.Rows[0][25].ToString());//低再焓增D比C低
                        double Mz_hz_dsmall_c = double.Parse(dt_error_para.Rows[0][26].ToString());//末再焓增D比C低
                        double Right_qy_yqnd_r_small_l = double.Parse(dt_error_para.Rows[0][27].ToString());//烟气浓度左比右高（右切圆）
                        double Right_qy_xdgtop_r_small_l = double.Parse(dt_error_para.Rows[0][28].ToString());//悬吊管最高点左比右高(右切圆)
                        double Czd_temp_left_right = double.Parse(dt_error_para.Rows[0][29].ToString());//垂直段水冷壁左墙右墙温度差
                        double Qy_back_xdg_top3_avg_l_r = double.Parse(dt_error_para.Rows[0][30].ToString());//左、右切圆后墙悬吊管水冷壁左侧、右侧最高三点平均值的差值
                        double Lxd_temp_top10_l_r = double.Parse(dt_error_para.Rows[0][31].ToString());//螺旋段水冷壁壁温左侧、右侧最高10个点平均值的差值
                        int Qy_px_l_r_num = int.Parse(dt_error_para.Rows[0][32].ToString());//左、右切圆向左、向右偏斜异常值条件数量
                        double Qy_gp_h_big_q = double.Parse(dt_error_para.Rows[0][33].ToString());//左、右切圆后墙管屏水冷壁温度比前墙垂直水冷壁高
                        double Qy_gp_q_big_h = double.Parse(dt_error_para.Rows[0][34].ToString());//左、右切圆前墙管屏水冷壁温度比后墙垂直水冷壁高
                        double Qy_lxd_q_h = double.Parse(dt_error_para.Rows[0][35].ToString());//左、右切圆前墙、后墙螺旋段水冷壁温度差值
                        double Qy_px_q_h_num = double.Parse(dt_error_para.Rows[0][36].ToString());//左、右切圆向前、向后偏斜异常值条件数量


                        StringBuilder sql_error_mid = new StringBuilder();
                        StringBuilder sql_fireerror_advice = new StringBuilder();
                        int left_qy_xxbz = 0;//左切圆消旋动量不足
                        string left_qy_xxbz_advice = "";////左切圆消旋动量不足建议

                        int right_qy_xxbz = 0;//右切圆消旋动量不足
                        string right_qy_xxbz_advice = "";//右切圆消旋动量不足建议

                        int left_qy_qxbz = 0;//左切圆起旋动量不足
                        string left_qy_qxbz_advice = "";//左切圆起旋动量不足建议

                        int right_qy_qxbz = 0;//右切圆起旋动量不足
                        string right_qy_qxbz_advice = "";//右切圆起旋动量不足建议

                        int left_qy_px_left = 0;//左切圆偏斜（向左）
                        string left_qy_px_left_advice = "";//左切圆偏斜（向左）建议

                        int right_qy_px_left = 0;//右切圆偏斜（向左）
                        string right_qy_px_left_advice = "";//右切圆偏斜（向左）建议

                        int left_qy_px_right = 0;//左切圆偏斜（向右）
                        string left_qy_px_right_advice = "";//左切圆偏斜（向右）建议

                        int right_qy_px_right = 0;//右切圆偏斜（向右）
                        string right_qy_px_right_advice = "";//右切圆偏斜（向右）建议

                        int left_qy_px_back = 0;//左切圆偏斜（向后）
                        string left_qy_px_back_advice = "";//左切圆偏斜（向后）建议

                        int right_qy_px_back = 0;//右切圆偏斜（向后）
                        string right_qy_px_back_advice = "";//右切圆偏斜（向后）建议

                        int left_qy_px_front = 0;//左切圆偏斜（向前）
                        string left_qy_px_front_advice = "";//左切圆偏斜（向前）建议

                        int right_qy_px_front = 0;//右切圆偏斜（向前）
                        string right_qy_px_front_advice = "";//右切圆偏斜（向前）建议


                        int zqy_xx = 0;
                        int yqy_xx = 0;
                        int zqy_qx = 0;
                        int yqy_qx = 0;
                        int zqy_px = 0;
                        int yqy_px = 0;
                        int cxbj = 0;
                        int normal = 1;


                        //********以下左切圆消旋动量不足，5项满足3项则成立********
                        //分隔屏焓增B比A高
                        if ((fgp_hz_b - fgp_hz_a) > Fgp_hz_b_big_a)
                        {
                            sql_error_mid.Append(Errormid_sql(112,dic_type[112],1, "分隔屏焓增B比A高"+ (fgp_hz_b - fgp_hz_a).ToString()));
                            left_qy_xxbz += 1;
                        }

                        //后屏焓增B比A高
                        if ((hp_hz_b - hp_hz_a) > Hp_hz_b_big_a)
                        {
                            sql_error_mid.Append(Errormid_sql(112, dic_type[112], 2, "后屏焓增B比A高" + (hp_hz_b - hp_hz_a).ToString()));
                            left_qy_xxbz += 1;
                        }
                        //高过焓增A比B高
                        if ((mg_hz_a - mg_hz_b) > Mg_hz_a_big_b)
                        {
                            sql_error_mid.Append(Errormid_sql(112, dic_type[112], 3, "高过焓增A比B高" + (mg_hz_a - mg_hz_b).ToString()));
                            left_qy_xxbz += 1;
                        }

                        ////低再焓增左比右高
                        //if ((dz_hz_left - dz_hz_right) > Dz_hz_a_big_b)
                        //{
                        //    sql_error_mid.Append(Errormid_sql(112, dic_type[112], 4, "低再焓增左比右高" + (dz_hz_left - dz_hz_right).ToString()));
                        //   left_qy_xxbz += 1;
                        //}
                        ////末再焓增左比右高
                        //if ((gz_hz_left - gz_hz_right) > Mz_hz_a_big_b)
                        //{
                        //    sql_error_mid.Append(Errormid_sql(112, dic_type[112], 5, "末再焓增左比右高" + (gz_hz_left - gz_hz_right).ToString()));
                        //   left_qy_xxbz += 1;
                        //}

                        //烟气浓度(O2)左比右高（左切圆）
                        if ((left_qy_o2_left_avg-left_qy_o2_right_avg)> Left_qy_yqnd_l_big_r*2)
                        {
                            sql_error_mid.Append(Errormid_sql(112, dic_type[112], 6, "左切圆烟气浓度左比右高" + (left_qy_o2_left_avg - left_qy_o2_right_avg).ToString()));
                            left_qy_xxbz += 1;
                        }
                        //悬吊管最高点左比右高(左切圆)
                        if ((left_qy_back_xdg_left_top - left_qy_back_xdg_right_top) > Left_qy_xdgtop_l_big_r)
                        {
                            sql_error_mid.Append(Errormid_sql(112, dic_type[112], 7, "左切圆悬吊管最高点左比右高" + (left_qy_back_xdg_left_top - left_qy_back_xdg_right_top).ToString()));
                            left_qy_xxbz += 1;
                        }

                        if (left_qy_xxbz >= Xx_qxbz_error_num)
                        {
                            left_qy_xxbz_advice = "请从BAGP1开始到UAGP3共6层，每隔10分钟逐层将1#-4#开至100%。";
                            sql_fireerror_advice.Append(Fireerror_sql(112, dic_type[112],left_qy_xxbz_advice , left_qy_xxbz.ToString()));
                            zqy_xx = 1;
                            normal = 0;
                        }


                        //********以下右切圆消旋动量不足，5项满足3项则成立********
                        //分隔屏焓增C比D高
                        if ((fgp_hz_c - fgp_hz_d) > Fgp_hz_c_big_d)
                        {
                            sql_error_mid.Append(Errormid_sql(66, dic_type[66], 1, "分隔屏焓增C比D高" + (fgp_hz_c - fgp_hz_d).ToString()));
                            right_qy_xxbz += 1;
                        }

                        //后屏焓增C比D高
                        if ((hp_hz_c - hp_hz_d) > Hp_hz_c_big_d)
                        {
                            sql_error_mid.Append(Errormid_sql(66, dic_type[66], 2, "后屏焓增C比D高" + (hp_hz_c - hp_hz_d).ToString()));
                            right_qy_xxbz += 1;
                        }
                        //高过焓增D比C高
                        if ((mg_hz_d - mg_hz_c) > Mg_hz_d_big_c)
                        {
                            sql_error_mid.Append(Errormid_sql(66, dic_type[66], 3, "高过焓增D比C高" + (mg_hz_d - mg_hz_c).ToString()));
                            right_qy_xxbz += 1;
                        }
                        ////低再焓增右比左高
                        //if ((dz_hz_right - dz_hz_left) > Dz_hz_b_big_a)
                        //{
                        //    sql_error_mid.Append(Errormid_sql(66, dic_type[66], 4, "低再焓增右比左高" + (dz_hz_right - dz_hz_left).ToString()));
                        //     right_qy_xxbz += 1;
                        //}
                        ////末再焓增右比左高
                        //if ((gz_hz_right - gz_hz_left) > Mz_hz_b_big_a)
                        //{
                        //    sql_error_mid.Append(Errormid_sql(66, dic_type[66], 5, "末再焓增右比左高" + (gz_hz_right - gz_hz_left).ToString()));
                        //    right_qy_xxbz += 1;
                        //}

                        //烟气浓度(O2)右比左高（右切圆）
                        if ((right_qy_o2_right_avg - right_qy_o2_left_avg) > Right_qy_yqnd_r_big_l * 2)
                        {
                            sql_error_mid.Append(Errormid_sql(66, dic_type[66], 6, "右切圆烟气浓度右比左高" + (left_qy_o2_left_avg - left_qy_o2_right_avg).ToString()));
                            right_qy_xxbz += 1;
                        }
                        //悬吊管最高点右比左高(右切圆)
                        if ((right_qy_back_xdg_right_top - right_qy_back_xdg_left_top) > Right_qy_xdgtop_r_big_l)
                        {
                            sql_error_mid.Append(Errormid_sql(66, dic_type[66], 7, "右切圆悬吊管最高点右比左高" + (right_qy_back_xdg_right_top - right_qy_back_xdg_left_top).ToString()));
                            right_qy_xxbz += 1;
                        }
                    

                        if (right_qy_xxbz >= Xx_qxbz_error_num)
                        {
                            right_qy_xxbz_advice = "请从BAGP1开始到UAGP3共6层，每隔10分钟逐层将5#-8#开至100%。";
                            sql_fireerror_advice.Append(Fireerror_sql(66, dic_type[66], right_qy_xxbz_advice, right_qy_xxbz.ToString()));
                            yqy_xx = 1;
                            normal = 0;
                        }



                        //********以下左切圆起旋动量不足，5项满足3项则成立********
                        //分隔屏焓增B比A低
                        if ((fgp_hz_a - fgp_hz_b) > Fgp_hz_b_small_a)
                        {
                            sql_error_mid.Append(Errormid_sql(67, dic_type[67], 1, "分隔屏焓增B比A低" + (fgp_hz_a - fgp_hz_b).ToString()));
                            left_qy_qxbz += 1;
                        }

                        //后屏焓增B比A低
                        if ((hp_hz_a - hp_hz_b) > Hp_hz_b_small_a)
                        {
                            sql_error_mid.Append(Errormid_sql(67, dic_type[67], 2, "后屏焓增B比A低" + (hp_hz_b - hp_hz_a).ToString()));
                            left_qy_qxbz += 1;
                        }
                        //高过焓增A比B低
                        if ((mg_hz_b - mg_hz_a) > Mg_hz_a_small_b)
                        {
                            sql_error_mid.Append(Errormid_sql(67, dic_type[67], 3, "高过焓增A比B低" + (mg_hz_b - mg_hz_a).ToString()));
                            left_qy_qxbz += 1;
                        }
                        ////低再焓增左比右低
                        //if ((dz_hz_right - dz_hz_left) > Dz_hz_a_small_b)
                        //{
                        //    sql_error_mid.Append(Errormid_sql(67, dic_type[67], 4, "低再焓增左比右低" + (dz_hz_right - dz_hz_left).ToString()));
                        //    left_qy_qxbz += 1;
                        //}
                        ////末再焓增左比右低
                        //if ((gz_hz_right - gz_hz_left) > Mz_hz_a_small_b)
                        //{
                        //    sql_error_mid.Append(Errormid_sql(67, dic_type[67], 5, "末再焓增左比右低" + (gz_hz_right - gz_hz_left).ToString()));
                        //    left_qy_qxbz += 1;
                        //}

                        //烟气浓度(O2)左比右低（左切圆）
                        if ((left_qy_o2_right_avg - left_qy_o2_left_avg) > Left_qy_yqnd_l_small_r * 2)
                        {
                            sql_error_mid.Append(Errormid_sql(67, dic_type[67], 6, "左切圆烟气浓度左比右低" + (left_qy_o2_right_avg - left_qy_o2_left_avg).ToString()));
                            left_qy_qxbz += 1;
                        }
                        //悬吊管最高点左比右低(左切圆)
                        if ((left_qy_back_xdg_right_top - left_qy_back_xdg_left_top) > Left_qy_xdgtop_l_small_r)
                        {
                            sql_error_mid.Append(Errormid_sql(67, dic_type[67], 7, "左切圆悬吊管最高点左比右低" + (left_qy_back_xdg_right_top - left_qy_back_xdg_left_top).ToString()));
                            left_qy_qxbz += 1;
                        }

                        if (left_qy_qxbz >= Xx_qxbz_error_num)
                        {
                            left_qy_qxbz_advice = "请从UAGP3开始到BAGP1共6层，每隔10分钟逐层将1#-4#关至10%。";
                            sql_fireerror_advice.Append(Fireerror_sql(67, dic_type[67], left_qy_qxbz_advice, left_qy_qxbz.ToString()));
                            zqy_qx = 1;
                            normal = 0;

                        }


                        //********以下右切圆起旋动量不足，5项满足3项则成立********
                        //分隔屏焓增C比D低
                        if ((fgp_hz_d - fgp_hz_c) > Fgp_hz_c_small_d)
                        {
                            sql_error_mid.Append(Errormid_sql(68, dic_type[68], 1, "分隔屏焓增C比D低" + (fgp_hz_d - fgp_hz_c).ToString()));
                            right_qy_qxbz += 1;
                        }

                        //后屏焓增C比D低
                        if ((hp_hz_d - hp_hz_c) > Hp_hz_c_small_d)
                        {
                            sql_error_mid.Append(Errormid_sql(68, dic_type[68], 2, "后屏焓增C比D低" + (hp_hz_d - hp_hz_c).ToString()));
                            right_qy_qxbz += 1;
                        }
                        //高过焓增D比C低
                        if ((mg_hz_c - mg_hz_d) > Mg_hz_d_small_c)
                        {
                            sql_error_mid.Append(Errormid_sql(68, dic_type[68], 3, "高过焓增D比C低" + (mg_hz_c - mg_hz_d).ToString()));
                            right_qy_qxbz += 1;
                        }
                        ////低再焓增右比左低
                        //if ((dz_hz_left - dz_hz_right) > Dz_hz_b_small_a)
                        //{
                        //    sql_error_mid.Append(Errormid_sql(68, dic_type[68], 4, "低再焓增右比左低" + (dz_hz_left - dz_hz_right).ToString()));
                        //    right_qy_qxbz += 1;
                        //}
                        ////末再焓增右比左低
                        //if ((gz_hz_left - gz_hz_right) > Mz_hz_b_small_a)
                        //{
                        //    sql_error_mid.Append(Errormid_sql(68, dic_type[68], 5, "末再焓增右比左低" + (gz_hz_left - gz_hz_right).ToString()));
                        //     right_qy_qxbz += 1;
                        //}

                        //烟气浓度(O2)右比左低（右切圆）
                        if ((right_qy_o2_left_avg - right_qy_o2_right_avg) > Right_qy_yqnd_r_small_l * 2)
                        {
                            sql_error_mid.Append(Errormid_sql(68, dic_type[68], 6, "右切圆烟气浓度右比左低" + (right_qy_o2_left_avg - right_qy_o2_right_avg).ToString()));
                            right_qy_qxbz += 1;
                        }
                        //悬吊管最高点右比左低(右切圆)
                        if ((right_qy_back_xdg_left_top - right_qy_back_xdg_right_top) > Right_qy_xdgtop_r_small_l)
                        {
                            sql_error_mid.Append(Errormid_sql(68, dic_type[68], 7, "右切圆悬吊管最高点右比左低" + (right_qy_back_xdg_left_top - right_qy_back_xdg_right_top).ToString()));
                            right_qy_qxbz += 1;
                        }


                        if (right_qy_qxbz >= Xx_qxbz_error_num)
                        {
                            right_qy_qxbz_advice = "请从UAGP3开始到BAGP1共6层，每隔10分钟逐层将5#-8#关至10%。";
                            sql_fireerror_advice.Append(Fireerror_sql(68, dic_type[68], right_qy_qxbz_advice, right_qy_qxbz.ToString()));
                            yqy_qx = 1;
                            normal = 0;
                        }


                        //********以下左切圆切圆偏斜（向左），4项满足2项则成立********
                        //高过焓增A比B高且垂直段水冷壁壁温左侧高于右侧
                        if ((mg_hz_a - mg_hz_b)> Mg_hz_a_big_b && (left_czd_temp-right_czd_temp)>Czd_temp_left_right)
                        {
                            sql_error_mid.Append(Errormid_sql(69, dic_type[69], 1, "高过焓增A比B高"+ (mg_hz_a - mg_hz_b).ToString() + "且垂直段水冷壁壁温左侧高于右侧" + (left_czd_temp - right_czd_temp).ToString()));
                            left_qy_px_left += 1;
                        }
                        //分隔屏焓增A比B高且高过焓增A比B高
                        if ((mg_hz_a - mg_hz_b) > Mg_hz_a_big_b && (fgp_hz_a - fgp_hz_b) > Fgp_hz_b_small_a)
                        {
                            sql_error_mid.Append(Errormid_sql(69, dic_type[69], 2, "高过焓增A比B高" + (mg_hz_a - mg_hz_b).ToString() + "且分隔屏焓增A比B高" + (fgp_hz_a - fgp_hz_b).ToString()));
                            left_qy_px_left += 1;
                        }
                        //左切圆后墙悬吊管水冷壁左侧最高三点平均值比右侧高
                        if ((left_qy_back_xdg_left_top3_avg - left_qy_back_xdg_right_top3_avg) > Qy_back_xdg_top3_avg_l_r)
                        {
                            sql_error_mid.Append(Errormid_sql(69, dic_type[69], 3, "左切圆后墙悬吊管水冷壁左侧最高三点平均值比右侧高" + (left_qy_back_xdg_left_top3_avg - left_qy_back_xdg_right_top3_avg).ToString()));
                            left_qy_px_left += 1;
                        }
                        //螺旋段水冷壁壁温左侧最高10个点平均值高于右侧
                        if ((left_lxd_top10_avg-right_lxd_top10_avg) > Lxd_temp_top10_l_r)
                        {
                            sql_error_mid.Append(Errormid_sql(69, dic_type[69], 4, "螺旋段水冷壁壁温左侧最高10个点平均值高于右侧" + (left_lxd_top10_avg - right_lxd_top10_avg).ToString()));
                            left_qy_px_left += 1;
                        }

                        if (left_qy_px_left >= Qy_px_l_r_num)
                        {
                            left_qy_px_left_advice = "1.检查燃烧器摆角，重做一次风调平；2.燃烧器摆角1的3#、4#设置-5的偏置（偏置的绝对值小于等于15）。";
                            sql_fireerror_advice.Append(Fireerror_sql(69, dic_type[69], left_qy_px_left_advice, left_qy_px_left.ToString()));
                            zqy_px = 1;
                            normal = 0;
                        }


                        //********以下右切圆切圆偏斜（向左），4项满足2项则成立********
                        //高过焓增C比D高且垂直段水冷壁壁温左侧高于右侧
                        if ((mg_hz_c - mg_hz_d) > Mg_hz_d_small_c && (left_czd_temp - right_czd_temp) > Czd_temp_left_right)
                        {
                            sql_error_mid.Append(Errormid_sql(74, dic_type[74], 1, "高过焓增C比D高" + (mg_hz_c - mg_hz_d).ToString() + "且垂直段水冷壁壁温左侧高于右侧" + (left_czd_temp - right_czd_temp).ToString()));
                            right_qy_px_left += 1;
                        }
                        //分隔屏焓增C比D高且高过焓增C比D高
                        if ((mg_hz_c - mg_hz_d) > Mg_hz_d_small_c && (fgp_hz_c - fgp_hz_d) > Fgp_hz_c_big_d)
                        {
                            sql_error_mid.Append(Errormid_sql(74, dic_type[74], 2, "高过焓增C比D高" + (mg_hz_c - mg_hz_d).ToString() + "且分隔屏焓增C比D高" + (fgp_hz_c - fgp_hz_d).ToString()));
                            right_qy_px_left += 1;
                        }
                        //右切圆后墙悬吊管水冷壁左侧最高三点平均值比右侧高
                        if ((right_qy_back_xdg_left_top3_avg - right_qy_back_xdg_right_top3_avg) > Qy_back_xdg_top3_avg_l_r)
                        {
                            sql_error_mid.Append(Errormid_sql(74, dic_type[74], 3, "右切圆后墙悬吊管水冷壁左侧最高三点平均值比右侧高" + (right_qy_back_xdg_left_top3_avg - right_qy_back_xdg_right_top3_avg).ToString()));
                            right_qy_px_left += 1;
                        }
                        //螺旋段水冷壁壁温左侧最高10个点平均值高于右侧
                        if ((left_lxd_top10_avg - right_lxd_top10_avg) > Lxd_temp_top10_l_r)
                        {
                            sql_error_mid.Append(Errormid_sql(74, dic_type[74], 4, "螺旋段水冷壁壁温左侧最高10个点平均值高于右侧" + (left_lxd_top10_avg - right_lxd_top10_avg).ToString()));
                            right_qy_px_left += 1;
                        }

                        if (right_qy_px_left >= Qy_px_l_r_num)
                        {
                            right_qy_px_left_advice = "1.检查燃烧器摆角，重做一次风调平；2.燃烧器摆角2的7#、8#设置-5的偏置（偏置的绝对值小于等于15）。";
                            sql_fireerror_advice.Append(Fireerror_sql(74, dic_type[74], right_qy_px_left_advice, right_qy_px_left.ToString()));
                            yqy_px = 1;
                            normal = 0;
                        }


                        //********以下左切圆切圆偏斜（向右），4项满足2项则成立********
                        //高过焓增B比A高且垂直段水冷壁壁温右侧高于左侧
                        if ((mg_hz_b - mg_hz_a) > Mg_hz_a_small_b && (right_czd_temp - left_czd_temp) > Czd_temp_left_right)
                        {
                            sql_error_mid.Append(Errormid_sql(75, dic_type[75], 1, "高过焓增B比A高" + (mg_hz_b - mg_hz_a).ToString() + "且垂直段水冷壁壁温右侧高于左侧" + (right_czd_temp - left_czd_temp).ToString()));
                            left_qy_px_right += 1;
                        }
                        //分隔屏焓增B比A高且高过焓增B比A高
                        if ((mg_hz_b - mg_hz_a) > Mg_hz_a_small_b && (fgp_hz_b - fgp_hz_a) > Fgp_hz_b_big_a)
                        {
                            sql_error_mid.Append(Errormid_sql(75, dic_type[75], 2, "高过焓增B比A高" + (mg_hz_a - mg_hz_b).ToString() + "且分隔屏焓增B比A高" + (fgp_hz_a - fgp_hz_b).ToString()));
                            left_qy_px_right += 1;
                        }
                        //左切圆后墙悬吊管水冷壁右侧最高三点平均值比左侧高
                        if ((left_qy_back_xdg_right_top3_avg - left_qy_back_xdg_left_top3_avg) > Qy_back_xdg_top3_avg_l_r)
                        {
                            sql_error_mid.Append(Errormid_sql(75, dic_type[75], 3, "左切圆后墙悬吊管水冷壁右侧最高三点平均值比左侧高" + (left_qy_back_xdg_right_top3_avg - left_qy_back_xdg_left_top3_avg).ToString()));
                            left_qy_px_right += 1;
                        }
                        //螺旋段水冷壁壁温右侧最高10个点平均值高于左侧
                        if ((right_lxd_top10_avg - left_lxd_top10_avg) > Lxd_temp_top10_l_r)
                        {
                            sql_error_mid.Append(Errormid_sql(75, dic_type[75], 4, "螺旋段水冷壁壁温右侧最高10个点平均值高于左侧" + (right_lxd_top10_avg - left_lxd_top10_avg).ToString()));
                            left_qy_px_right += 1;
                        }

                        if (left_qy_px_right >= Qy_px_l_r_num)
                        {
                            left_qy_px_right_advice = "1.检查燃烧器摆角，重做一次风调平；2.燃烧器摆角1的1#、2#设置-5的偏置（偏置的绝对值小于等于15）。";
                            sql_fireerror_advice.Append(Fireerror_sql(75, dic_type[75], left_qy_px_right_advice, left_qy_px_right.ToString()));
                            zqy_px = 1;
                            normal = 0;
                        }


                        //********以下右切圆切圆偏斜（向右），4项满足2项则成立********                      
                        //高过焓增D比C高且垂直段水冷壁壁温右侧高于左侧
                        if ((mg_hz_d - mg_hz_c) > Mg_hz_d_big_c && (right_czd_temp - left_czd_temp) > Czd_temp_left_right)
                        {
                            sql_error_mid.Append(Errormid_sql(76, dic_type[76], 1, "高过焓增D比C高" + (mg_hz_d - mg_hz_c).ToString() + "且垂直段水冷壁壁温右侧高于左侧" + (right_czd_temp - left_czd_temp).ToString()));
                            right_qy_px_right += 1;
                        }
                        //分隔屏焓增D比C高且高过焓增D比C高
                        if ((mg_hz_d - mg_hz_c) > Mg_hz_d_big_c && (fgp_hz_d - fgp_hz_c) > Fgp_hz_c_small_d)
                        {
                            sql_error_mid.Append(Errormid_sql(76, dic_type[76], 2, "高过焓增D比C高" + (mg_hz_d - mg_hz_c).ToString() + "分隔屏焓增D比C高" + (fgp_hz_d - fgp_hz_c).ToString()));
                            right_qy_px_right += 1;
                        }
                        //右切圆后墙悬吊管水冷壁右侧最高三点平均值比左侧高
                        if ((right_qy_back_xdg_right_top3_avg - right_qy_back_xdg_left_top3_avg) > Qy_back_xdg_top3_avg_l_r)
                        {
                            sql_error_mid.Append(Errormid_sql(76, dic_type[76], 3, "右切圆后墙悬吊管水冷壁右侧最高三点平均值比左侧高" + (right_qy_back_xdg_right_top3_avg - right_qy_back_xdg_left_top3_avg).ToString()));
                            right_qy_px_right += 1;
                        }
                        //螺旋段水冷壁壁温右侧最高10个点平均值高于左侧
                        if ((right_lxd_top10_avg - left_lxd_top10_avg) > Lxd_temp_top10_l_r)
                        {
                            sql_error_mid.Append(Errormid_sql(76, dic_type[76], 4, "螺旋段水冷壁壁温右侧最高10个点平均值高于左侧" + (right_lxd_top10_avg - left_lxd_top10_avg).ToString()));
                            right_qy_px_right += 1;
                        }

                        if (right_qy_px_right >= Qy_px_l_r_num)
                        {
                            right_qy_px_right_advice = "1.检查燃烧器摆角，重做一次风调平；2.燃烧器摆角2的5#、6#设置-5的偏置（偏置的绝对值小于等于15）。";
                            sql_fireerror_advice.Append(Fireerror_sql(76, dic_type[76], right_qy_px_right_advice, right_qy_px_right.ToString()));
                            yqy_px = 1;
                            normal = 0;
                        }

                        //********以下左切圆切圆偏斜（向后），2项满足1项则成立******** 
                        //左切圆后墙管屏水冷壁温度比前墙垂直水冷壁高
                        if ((left_qy_back_gp_temp - left_qy_front_cz_temp) > Qy_gp_h_big_q)
                        {
                            sql_error_mid.Append(Errormid_sql(77, dic_type[77], 1, "左切圆后墙管屏水冷壁温度比前墙垂直水冷壁高" + (left_qy_back_gp_temp - left_qy_front_cz_temp).ToString()));
                            left_qy_px_back += 1;
                        }
                        //左切圆后墙螺旋段水冷壁温度比前墙螺旋段水冷壁温度高
                        if ((left_qy_back_lxd_top10_avg - left_qy_front_lxd_top10_avg) > Qy_lxd_q_h)
                        {
                            sql_error_mid.Append(Errormid_sql(77, dic_type[77], 2, "左切圆后墙螺旋段水冷壁温度比前墙螺旋段水冷壁温度高" + (left_qy_back_lxd_top10_avg - left_qy_front_lxd_top10_avg).ToString()));
                            left_qy_px_back += 1;
                        }
                        if (left_qy_px_back >= Qy_px_q_h_num)
                        {
                            left_qy_px_back_advice = "1.检查燃烧器摆角，重做一次风调平；2.燃烧器摆角1的1#、4#设置-5的偏置（偏置的绝对值小于等于15）。";
                            sql_fireerror_advice.Append(Fireerror_sql(77, dic_type[77], left_qy_px_back_advice, left_qy_px_back.ToString()));
                            zqy_px = 1;
                            normal = 0;
                        }

                        //********以下右切圆切圆偏斜（向后），2项满足1项则成立******** 
                        //右切圆后墙管屏水冷壁温度比前墙垂直水冷壁高
                        if ((right_qy_back_gp_temp - right_qy_front_cz_temp) > Qy_gp_h_big_q)
                        {
                            sql_error_mid.Append(Errormid_sql(82, dic_type[82], 1, "右切圆后墙管屏水冷壁温度比前墙垂直水冷壁高" + (right_qy_back_gp_temp - right_qy_front_cz_temp).ToString()));
                            right_qy_px_back += 1;
                        }
                        //右切圆后墙螺旋段水冷壁温度比前墙螺旋段水冷壁温度高
                        if ((right_qy_back_lxd_top10_avg - right_qy_front_lxd_top10_avg) > Qy_lxd_q_h)
                        {
                            sql_error_mid.Append(Errormid_sql(82, dic_type[82], 2, "右切圆后墙螺旋段水冷壁温度比前墙螺旋段水冷壁温度高" + (right_qy_back_lxd_top10_avg - right_qy_front_lxd_top10_avg).ToString()));
                            right_qy_px_back += 1;
                        }
                        if (right_qy_px_back >= Qy_px_q_h_num)
                        {
                            right_qy_px_back_advice = "1.检查燃烧器摆角，重做一次风调平；2.燃烧器摆角2的5#、8#设置-5的偏置（偏置的绝对值小于等于15）。";
                            sql_fireerror_advice.Append(Fireerror_sql(82, dic_type[82], right_qy_px_back_advice, right_qy_px_back.ToString()));
                            yqy_px = 1;
                            normal = 0;
                        }

                        //********以下左切圆切圆偏斜（向前），2项满足1项则成立******** 
                        //左切圆前墙垂直水冷壁比后墙管屏水冷壁温度高
                        if ((left_qy_front_cz_temp-left_qy_back_gp_temp ) > Qy_gp_q_big_h)
                        {
                            sql_error_mid.Append(Errormid_sql(83, dic_type[83], 1, "左切圆前墙垂直水冷壁比后墙管屏水冷壁温度高" + (left_qy_front_cz_temp - left_qy_back_gp_temp).ToString()));
                            left_qy_px_front += 1;
                        }
                        //左切圆前墙螺旋段水冷壁温度比后墙螺旋段水冷壁温度高
                        if ((left_qy_front_lxd_top10_avg - left_qy_back_lxd_top10_avg) > Qy_lxd_q_h)
                        {
                            sql_error_mid.Append(Errormid_sql(83, dic_type[83], 2, "左切圆前墙螺旋段水冷壁温度比后墙螺旋段水冷壁温度高" + (left_qy_front_lxd_top10_avg - left_qy_back_lxd_top10_avg).ToString()));
                            left_qy_px_front += 1;
                        }
                        if (left_qy_px_front >= Qy_px_q_h_num)
                        {
                            left_qy_px_front_advice = "1.检查燃烧器摆角，重做一次风调平；2.燃烧器摆角1的2#、3#设置-5的偏置（偏置的绝对值小于等于15）；3.如无壁温超温，可不调。";
                            sql_fireerror_advice.Append(Fireerror_sql(83, dic_type[83], left_qy_px_front_advice, left_qy_px_front.ToString()));
                            zqy_px = 1;
                            normal = 0;
                        }

                        //********以下右切圆切圆偏斜（向前），2项满足1项则成立******** 
                        //右切圆前墙垂直水冷壁比后墙管屏水冷壁温度高
                        if ((right_qy_front_cz_temp - right_qy_back_gp_temp) > Qy_gp_q_big_h)
                        {
                            sql_error_mid.Append(Errormid_sql(84, dic_type[84], 1, "右切圆前墙垂直水冷壁比后墙管屏水冷壁温度高" + (right_qy_front_cz_temp - right_qy_back_gp_temp).ToString()));
                            right_qy_px_front += 1;
                        }
                        //右切圆前墙螺旋段水冷壁温度比后墙螺旋段水冷壁温度高
                        if ((right_qy_front_lxd_top10_avg - right_qy_back_lxd_top10_avg) > Qy_lxd_q_h)
                        {
                            sql_error_mid.Append(Errormid_sql(84, dic_type[84], 2, "右切圆前墙螺旋段水冷壁温度比后墙螺旋段水冷壁温度高" + (right_qy_front_lxd_top10_avg - right_qy_back_lxd_top10_avg).ToString()));
                            right_qy_px_front += 1;
                        }
                        if (right_qy_px_front >= Qy_px_q_h_num)
                        {
                            right_qy_px_front_advice = "1.检查燃烧器摆角，重做一次风调平；2.燃烧器摆角2的6#、7#设置-5的偏置（偏置的绝对值小于等于15）；3.如无壁温超温，可不调。";
                            sql_fireerror_advice.Append(Fireerror_sql(84, dic_type[84], right_qy_px_front_advice, right_qy_px_front.ToString()));
                            yqy_px = 1;
                            normal = 0;
                        }
                        string o2_high_advice = "";
                        string o2_low_advice = "";
                        string nox_high_advice = "";
                        string nox_low_advice = "";
                       
                        //O2偏高
                        if (o2_avg > o2_high)
                        {
                            o2_high_advice = "每间隔十分钟，以0.2%的幅度恢复至基准工况氧量。";
                            sql_fireerror_advice.Append(Fireerror_sql(93, dic_type[93], o2_high_advice, (o2_avg- o2_high).ToString()));
                            cxbj = 1;
                            normal = 0;
                        }
                        //O2偏低
                        if (o2_avg < o2_low)
                        {
                            o2_low_advice = "每间隔十分钟，以0.2%的幅度恢复至基准工况氧量。";
                            sql_fireerror_advice.Append(Fireerror_sql(94, dic_type[94], o2_low_advice, (o2_low - o2_avg).ToString()));
                            cxbj = 1;
                            normal = 0;
                        }

                        //NOx偏高
                        if (nox_avg > nox_high)
                        {
                            nox_high_advice = "UAGP3至UAGP1逐步开至100%，如果UAGP3、2、1的开度指令已达100%，BAGP3至BAGP1逐步开至100%。";
                            sql_fireerror_advice.Append(Fireerror_sql(95, dic_type[95], nox_high_advice, (nox_avg - nox_high).ToString()));
                            cxbj = 1;
                            normal = 0;
                        }
                        //NOx偏低
                        if (nox_avg < nox_low)
                        {
                            nox_low_advice = "BAGP1至BAGP3逐步关至10%，如果BAGP1、2、3的开度指令已达10%，UAGP1至UAGP3逐步关至10%。";
                            sql_fireerror_advice.Append(Fireerror_sql(96, dic_type[96], nox_low_advice, (nox_low - nox_avg).ToString()));
                            cxbj = 1;
                            normal = 0;
                        }

                        string gz_out_temp_high_advice = "";
                        string gz_out_temp_low_advice = "";
                        string mg_out_temp_high_advice = "";
                        string mg_out_temp_low_advice = "";
                        List<double> gz_out_temp = new List<double>();
                        gz_out_temp.Add(gz_out_temp_left);
                        gz_out_temp.Add(gz_out_temp_right);

                        List<double> mg_out_temp = new List<double>();
                        mg_out_temp.Add(mg_out_temp_a);
                        mg_out_temp.Add(mg_out_temp_b);
                        mg_out_temp.Add(mg_out_temp_c);
                        mg_out_temp.Add(mg_out_temp_d);
                        //高温再热器超温
                        double gz_out_temp_max = Compute.Maxdata(gz_out_temp.ToArray());
                        if (gz_out_temp_max > gz_out_temp_high)
                        {
                            if ((zrq_jws_left + zrq_jws_right) > 20)
                            {
                                gz_out_temp_high_advice = "1.调整减温水，控制高温再热器气温至设计值" + gz_out_temp_ed.ToString() + "℃﹢3～-5℃；2.以间隔10min、10%的幅度关小低温再热气侧烟气挡板，同时以相同幅度开大低过侧烟气挡板，直至低再侧烟气挡板≮10%。";
                            }
                            else
                            {
                                gz_out_temp_high_advice = "调整减温水，控制高温再热器气温至设计值" + gz_out_temp_ed.ToString() + "℃﹢3～-5℃。";
                            }
                            sql_fireerror_advice.Append(Fireerror_sql(97, dic_type[97], gz_out_temp_high_advice, gz_out_temp_max.ToString()));
                            cxbj = 1;
                            normal = 0;
                        }

                        //高温再热器欠温
                        double gz_out_temp_min = Compute.Mindata(gz_out_temp.ToArray());
                        if (gz_out_temp_min < gz_out_temp_low)
                        {
                            if((zrq_jws_left + zrq_jws_right) > 10)
                           {
                                gz_out_temp_low_advice = "调整减温水，控制高温再热器气温至设计值" + gz_out_temp_ed.ToString() + "℃﹢3～-5℃";

                            }
                            else if (dz_yqdb_kd < 95)
                            {
                                gz_out_temp_low_advice = "以间隔10min、10%的幅度开大低温再热气侧烟气挡板，同时以相同幅度关小低过侧烟气挡板，直至低再侧烟气挡板≮95%。";
                            }
                            else
                            {
                                gz_out_temp_low_advice = "间隔10分钟，以5%的幅度调整燃烧器1、2摆角上摆。";
                            }
                           
                            sql_fireerror_advice.Append(Fireerror_sql(98, dic_type[98], gz_out_temp_low_advice, gz_out_temp_min.ToString()));
                            cxbj = 1;
                            normal = 0;
                        }

                        //末级过热器超温
                        double grq_jws = grq_jws_1a + grq_jws_1b + grq_jws_1c + grq_jws_1d + grq_jws_2a + grq_jws_2b + grq_jws_2c + grq_jws_2d + grq_jws_3a + grq_jws_3b + grq_jws_3c + grq_jws_3d;//过热器减温水量
                        double grq_jws_design = Compute.Sumdata(grq_jws_design_1) + Compute.Sumdata(grq_jws_design_2) + Compute.Sumdata(grq_jws_design_3);//过热器减温水量设计值
                        double mg_out_temp_max = Compute.Maxdata(mg_out_temp.ToArray());
                        if(mg_out_temp_max>mg_out_temp_high)
                        {
                            if (grq_jws < grq_jws_design * 0.8)
                            {
                                mg_out_temp_high_advice = "调整减温水，控制高温再热器气温至设计值" + mg_out_temp_ed + "℃﹢3～-5℃。";
                            }
                            else if (grq_jws > grq_jws_design + 20)
                            {
                                mg_out_temp_high_advice = "以1℃的幅度降低过热度。";
                            }
                            else
                            {
                                mg_out_temp_high_advice = "调整过热器减温水量，同时以1℃的幅度降低过热度。";
                            }
                           
                            sql_fireerror_advice.Append(Fireerror_sql(99, dic_type[99], mg_out_temp_high_advice, mg_out_temp_max.ToString()));
                            cxbj = 1;
                            normal = 0;
                        }

                        //末级过热器欠温
                        double mg_out_temp_min = Compute.Mindata(mg_out_temp.ToArray());
                        if (mg_out_temp_min < gz_out_temp_low)
                        {
                            if (grq_jws > grq_jws_design * 0.8)
                            {
                                mg_out_temp_low_advice = "调整减温水，控制高温再热器气温至设计值" + mg_out_temp_ed + "℃﹢3～-5℃。";
                            }
                            else if (grq_jws < grq_jws_design - 20)
                            {
                                mg_out_temp_low_advice = "以1℃的幅度提高过热度。";
                            }
                            else
                            {
                                mg_out_temp_low_advice = "调整过热器减温水量，同时以1℃的幅度提高过热度。";
                            }
                           
                            sql_fireerror_advice.Append(Fireerror_sql(100, dic_type[100], mg_out_temp_low_advice, mg_out_temp_min.ToString()));
                            cxbj = 1;
                            normal = 0;
                        }

                        string sql_error_status = "insert into Dncerror_status (RealTime,Leftqy_xxbz,Rightqy_xxbz,Leftqy_qxbz,Rightqy_qxbz,Leftqy_px,Rightqy_px,Cxbj,Normal,Status,IsDeleted,DncBoilerId,DncBoiler_Name) values('"+csyntime+"',"+zqy_xx+","+yqy_xx+","+zqy_qx+","+yqy_qx+","+zqy_px+","+yqy_px+","+cxbj+","+normal+",1,0,"+boilerid+",'"+boiler_name+"')";
                            /*  
                        db.CommandExecuteNonQuery(sql_error_status);


                        //没有任何燃烧异常小类（中间表）
                        if (!string.IsNullOrEmpty(sql_error_mid.ToString()))
                        {
                            db.CommandExecuteNonQuery(sql_error_mid.ToString());
                        }
                        else
                        {
                           // AddLgoToTXT(csyntime + "：无异常小类！");
                        }
                        //没有任何燃烧异常大类（结果表）
                        if (!string.IsNullOrEmpty(sql_fireerror_advice.ToString()))
                        {
                            db.CommandExecuteNonQuery(sql_fireerror_advice.ToString());
                        }
                        else
                        {
                           // AddLgoToTXT(csyntime + "：无任何燃烧异常！");
                        }

                        //***************以下为受热面沾污异常和建议****************

                        StringBuilder sql_fireerror_zw_advice = new StringBuilder();
                        string dg_zwxs_advice = "";
                        string fgp_zwxs_advice = "";
                        string hp_zwxs_advice = "";
                        string mg_zwxs_advice = "";
                        string dz_zwxs_advice = "";
                        string gz_zwxs_advice = "";
                        //低温过热器沾污异常
                        if (dg_zwxs > dg_zwxs_high)
                        {
                            dg_zwxs_advice = "建议增加吹灰频率";
                            sql_fireerror_zw_advice.Append(Fireerror_sql_zw(1, 103, dic_type[103], dg_zwxs_advice, dg_zwxs.ToString()));
                        }
                        else if (dg_zwxs < dg_zwxs_low)
                        {
                            dg_zwxs_advice = "建议减少吹灰频率";
                            sql_fireerror_zw_advice.Append(Fireerror_sql_zw(2, 103, dic_type[103], dg_zwxs_advice, dg_zwxs.ToString()));
                        }
                        //分隔屏过热器沾污异常
                        if (fgp_zwxs > fgp_zwxs_high)
                        {
                            fgp_zwxs_advice = "建议增加吹灰频率";
                            sql_fireerror_zw_advice.Append(Fireerror_sql_zw(1, 104, dic_type[104], fgp_zwxs_advice, fgp_zwxs.ToString()));
                        }
                        else if (fgp_zwxs < fgp_zwxs_low)
                        {
                            fgp_zwxs_advice = "建议减少吹灰频率";
                            sql_fireerror_zw_advice.Append(Fireerror_sql_zw(2, 104, dic_type[104], fgp_zwxs_advice, fgp_zwxs.ToString()));
                        }
                        //后屏过热器沾污异常
                        if (hp_zwxs > hp_zwxs_high)
                        {
                            hp_zwxs_advice = "建议增加吹灰频率";
                            sql_fireerror_zw_advice.Append(Fireerror_sql_zw(1, 105, dic_type[105], hp_zwxs_advice, hp_zwxs.ToString()));
                        }
                        else if (hp_zwxs < hp_zwxs_low)
                        {
                            hp_zwxs_advice = "建议减少吹灰频率";
                            sql_fireerror_zw_advice.Append(Fireerror_sql_zw(2, 105, dic_type[105], hp_zwxs_advice, hp_zwxs.ToString()));
                        }
                        //末级过热器沾污异常
                        if (mg_zwxs > mg_zwxs_high)
                        {
                            mg_zwxs_advice = "建议增加吹灰频率";
                            sql_fireerror_zw_advice.Append(Fireerror_sql_zw(1, 106, dic_type[106], mg_zwxs_advice, mg_zwxs.ToString()));
                        }
                        else if (mg_zwxs < mg_zwxs_low)
                        {
                            mg_zwxs_advice = "建议减少吹灰频率";
                            sql_fireerror_zw_advice.Append(Fireerror_sql_zw(2, 106, dic_type[106], mg_zwxs_advice, mg_zwxs.ToString()));
                        }

                        //低温再热器沾污异常
                        if (dz_zwxs > dz_zwxs_high)
                        {
                            dz_zwxs_advice = "建议增加吹灰频率";
                            sql_fireerror_zw_advice.Append(Fireerror_sql_zw(1, 107, dic_type[107], dz_zwxs_advice, dz_zwxs.ToString()));
                        }
                        else if (dz_zwxs < dz_zwxs_low)
                        {
                            dz_zwxs_advice = "建议减少吹灰频率";
                            sql_fireerror_zw_advice.Append(Fireerror_sql_zw(2, 107, dic_type[107], dz_zwxs_advice, dz_zwxs.ToString()));
                        }
                        //高温再热器沾污异常
                        if (gz_zwxs > gz_zwxs_high)
                        {
                            gz_zwxs_advice = "建议增加吹灰频率";
                            sql_fireerror_zw_advice.Append(Fireerror_sql_zw(1, 108, dic_type[108], gz_zwxs_advice, gz_zwxs.ToString()));
                        }
                        else if (gz_zwxs < gz_zwxs_low)
                        {
                            gz_zwxs_advice = "建议减少吹灰频率";
                            sql_fireerror_zw_advice.Append(Fireerror_sql_zw(2, 108, dic_type[108], gz_zwxs_advice, gz_zwxs.ToString()));
                        }


                      
                        //没有任何受热面沾污异常（结果表）
                        if (!string.IsNullOrEmpty(sql_fireerror_zw_advice.ToString()))
                        {
                            db.CommandExecuteNonQuery(sql_fireerror_zw_advice.ToString());
                        }
                        else
                        {
                          //  AddLgoToTXT(csyntime + "：无任何沾污异常！");
                        }

                    */

                    }


                   

                   


                    // db.CommandExecuteNonQuery("update DncSapSynDpt set SynTime=GETDATE(),K_Name_kw='" + SHORT + "',Pid='" + pid + "' where SapId='" + id + "'");
                    //   AddLgoToTXT("部门 " + STEXT + ":" + id + " 更新" + "  " + DateTime.Now.ToLongDateString());
                }
                else
                    {
                       // AddLgoToTXT(csyntime + "：测点表无数据");

                        //AddLgoToTXT("--------------------------------------------------------");
                        //AddLgoToTXT("部门号 " + org + " 不存在 人员" + ICNUM + "  " + DateTime.Now.ToLongDateString());
                        //AddLgoToTXT("--------------------------------------------------------");
                    }
                    

                }
                catch (Exception rrr)
                {
                    //AddLgoToTXT(rrr.Message + "\n " + rrr.StackTrace);
                }
            //});

        }
    }
}
