using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SynZnrs;
using Newtonsoft.Json.Linq;
using SiPHDOM;
using System.IO;
using SynWHCH;

namespace Whapp
{
    public partial class Form1 : Form
    {

        static ILServer m_pServer;
        static ILGroup m_pGroup;
        static int boilerid = 1;
        public static string boiler_name;

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
        /// 相对湿度计算公式
        /// </summary>
        /// <param name="Drybulbtemp"></param>
        /// <param name="Wetbulbtemp"></param>
        /// <param name="Watertemp3"></param>
        /// <param name="Airpress"></param>
        /// <returns></returns>

        public static double Wxds(double Drybulbtemp, double Wetbulbtemp, double Watertemp3, double Airpress)
        {

            double gqjdwd = 273.15 + Drybulbtemp;//干球绝对温度
            double sqjdwd = 273.15 + Wetbulbtemp;//湿球绝对温度
            double logEw = 10.79574 * (1 - Watertemp3 / gqjdwd) - 5.028 * Math.Log10(gqjdwd / Watertemp3) + 1.50475 * Math.Pow(10, -4) * (1 - Math.Pow(10, (-8.2969 * gqjdwd / (Watertemp3 - 1)))) + 0.42873 * Math.Pow(10, -3) * Math.Pow(10, (4.76955 * (1 - Watertemp3) / gqjdwd) - 1) + 0.78614;
            double logEtw = 10.79574 * (1 - Watertemp3 / sqjdwd) - 5.028 * Math.Log10(sqjdwd / Watertemp3) + 1.50475 * Math.Pow(10, -4) * (1 - Math.Pow(10, (-8.2969 * sqjdwd / (Watertemp3 - 1)))) + 0.42873 * Math.Pow(10, -3) * Math.Pow(10, (4.76955 * (1 - Watertemp3) / sqjdwd) - 1) + 0.78614;
            double Ew = Math.Pow(10, logEw);//干球温度t对应的饱和水气压
            double Etw = Math.Pow(10, logEtw);//湿球温度tw对应的饱和水气压
            double gsbxs = 0.662 * Math.Pow(10, -3);//干湿表系数
            double wather_press = Etw - gsbxs * Airpress * (Drybulbtemp - Wetbulbtemp);//水气压
            double xdsd = wather_press / Ew * 100;//相对湿度
            return xdsd;


        }


        /// <summary>
        /// 减温水焓增计算公式
        /// </summary>
        /// <param name="temp"></param>
        /// <param name="press"></param>
        /// <returns></returns>
        /// 

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

        public Form1()
        {
            InitializeComponent();
        }
        class point
        {
            public string name { get; set; }
            public double pvalue { get; set; }
            public double typeid { get; set; }
            public string typename { get; set; }
        }

        public static void Hzpoint()
        {
            DBHelper db = new DBHelper();
            List<string> arr = new List<string>();
            string sql_point_all = "select  Name_kw,DncTypeId,DncType_Name,Pvalue from dncpointkks where Status=1 and IsDeleted=0 and DncBoilerId=" + boilerid;//
            DataTable dt_pvalue = db.GetCommand(sql_point_all);
            List<point> vl = new List<point>();
            foreach (DataRow item in dt_pvalue.Rows)
            {
                point p = new point();
                p.name = item[0].ToString();
                p.typeid = int.Parse(item[1].ToString());
                p.typename = item[2].ToString();
                p.pvalue = double.Parse(item[3].ToString());
                vl.Add(p);
            }

            int typeid = 0;
            string typename = "";
            string sql_pgroup = "select Id,K_Name_kw from dnctype where Status=1 and IsDeleted=0";
            DataTable dt_pgroup = db.GetCommand(sql_pgroup);
            DateTime dtnow = DateTime.Now;
            foreach (DataRow item in dt_pgroup.Rows)
            {
                //typelist.Add(int.Parse(item[0].ToString()));
                typeid = int.Parse(item[0].ToString());
                typename = item[1].ToString();
                JArray jar = JArray.Parse("[]");
                var f = vl.FindAll(x => x.typeid == typeid);
                foreach (var i in f)
                {
                    jar.Add(i.pvalue);
                }
                //jar.ToString()
                System.Text.RegularExpressions.MatchEvaluator matchEvalu = delegate (System.Text.RegularExpressions.Match m)
                {
                    return "";
                };
                string jarstr = System.Text.RegularExpressions.Regex.Replace(jar.ToString(), @"\r\n", matchEvalu);
                jarstr = System.Text.RegularExpressions.Regex.Replace(jarstr.ToString(), @" ", matchEvalu);
                arr.Add("insert into dnchzpoint(DncTypeId,DncType_Name,RealTime,Pvalue,Status,IsDeleted,DncBoilerId,DncBoiler_Name) values(" + typeid + ",'" + typename + "','" + dtnow + "','" + jarstr + "',1,0," + boilerid + ",'" + boilerid.ToString() + "号机组');");


                string sql = "update dnchzpointnow set RealTime='" + dtnow + "',Pvalue='" + jarstr + "' where DncBoilerId=" + boilerid + " and DncTypeId=" + typeid + ";";
                arr.Add(sql);

            }
            db.ExecuteTransaction(arr);

        }
        public static void znrs_ch()
        {
            try
            {

                DBHelper db = new DBHelper();
                List<string> arr = new List<string>();
                //获取锅炉信息
                string sql_boiler = "select Edfh,K_Name_kw,Ch_Run,Ch_EndTime,Ch_Run_kyq,Ch_EndTime_kyq from dncboiler where Status=1 and IsDeleted=0 and Id=" + boilerid;
                DataTable dt_boiler = db.GetCommand(sql_boiler);

                int edfh = int.Parse(dt_boiler.Rows[0][0].ToString());
                boiler_name = dt_boiler.Rows[0][1].ToString();
                int chrun = int.Parse(dt_boiler.Rows[0][2].ToString());
                /*
                 * 0：吹灰刚执行完，准备计算参考温升、参考压降
                 * 1：20分钟时，更新参考温升、参考压降完成
                 * 2：30分钟时，开始加入待吹灰列表
                 * 3：触发执行吹灰，待确认执行
                 */

                DateTime dt_chend = DateTime.MinValue;
                if (dt_boiler.Rows[0][3] != null && dt_boiler.Rows[0][3].ToString() != "")
                {
                    dt_chend = DateTime.Parse(dt_boiler.Rows[0][3].ToString());
                }
                int chrun_kyq = int.Parse(dt_boiler.Rows[0][4].ToString());
                /*
                 * 0：吹灰刚执行完，准备计算参考压降
                 * 1：20分钟时，更新参考压降完成
                 * 2：30分钟时，开始加入执行列表，等待执行
                 */
                DateTime dt_chend_kyq = DateTime.MinValue;
                if (dt_boiler.Rows[0][5] != null && dt_boiler.Rows[0][5].ToString() != "")
                {
                    dt_chend_kyq = DateTime.Parse(dt_boiler.Rows[0][5].ToString());
                }

                //获取定额参数配置表信息
                string sql_para = "select Airpress,Drybulbtemp,Wetbulbtemp,Watertemp3,Flyashratio,Slagratio,Temp0cp,Temp100cp,Temp200cp,Temp0ch,Temp100ch,Temp200ch,Specificheat,Heatloss,Airheat,Design_in_wind_temp from dncparameter where Status=1 and IsDeleted=0 and DncBoilerId=" + boilerid;
                DataTable dt_ch_para = db.GetCommand(sql_para);

                double Airpress = double.Parse(dt_ch_para.Rows[0][0].ToString());//大气压力
                double Drybulbtemp = double.Parse(dt_ch_para.Rows[0][1].ToString());//干球温度
                double Wetbulbtemp = double.Parse(dt_ch_para.Rows[0][2].ToString());//湿球温度
                double Watertemp3 = double.Parse(dt_ch_para.Rows[0][3].ToString());//水的三相点绝对温度
                double Flyashratio = double.Parse(dt_ch_para.Rows[0][4].ToString());//飞灰比率
                double Slagratio = double.Parse(dt_ch_para.Rows[0][5].ToString());//大渣比率
                double Temp0cp = double.Parse(dt_ch_para.Rows[0][6].ToString());//温度0Cp.H2O
                double Temp100cp = double.Parse(dt_ch_para.Rows[0][7].ToString());//温度100Cp.H2O
                double Temp200cp = double.Parse(dt_ch_para.Rows[0][8].ToString());//温度200Cp.H2O
                double Temp0ch = double.Parse(dt_ch_para.Rows[0][9].ToString());//温度0Ch
                double Temp100ch = double.Parse(dt_ch_para.Rows[0][10].ToString());//温度100Ch
                double Temp200ch = double.Parse(dt_ch_para.Rows[0][11].ToString());//温度200Ch
                double Specificheat = double.Parse(dt_ch_para.Rows[0][12].ToString());//大渣比热
                double Heatloss = double.Parse(dt_ch_para.Rows[0][13].ToString());//散热损失
                double Airheat = double.Parse(dt_ch_para.Rows[0][14].ToString());//空气比热
                double Design_in_wind_temp = double.Parse(dt_ch_para.Rows[0][15].ToString());//设计进口风温

                string sql_fuel_para = "select Carbon,Hydrogen,O2,Nitrogen,Sulfur,H2o,Ashcontent,Flyashfuel,Cinderfuel,Co,Calorificvalue,Chargingfuel from dncfuelpara where Status=1 and IsDeleted=0 and DncBoilerId=" + boilerid+ " order by RealTime desc";
                DataTable dt_fuel_para = db.GetCommand(sql_fuel_para);
                double Carbon = double.Parse(dt_fuel_para.Rows[0][0].ToString());//碳(收到基)
                double Hydrogen = double.Parse(dt_fuel_para.Rows[0][1].ToString());//氢(收到基)
                double O2 = double.Parse(dt_fuel_para.Rows[0][2].ToString());//氧(收到基)
                double Nitrogen = double.Parse(dt_fuel_para.Rows[0][3].ToString());//氮(收到基)
                double Sulfur = double.Parse(dt_fuel_para.Rows[0][4].ToString());//硫(收到基)
                double H2o = double.Parse(dt_fuel_para.Rows[0][5].ToString());//水分(收到基)
                double Ashcontent = double.Parse(dt_fuel_para.Rows[0][6].ToString());//灰分(收到基)
                double Flyashfuel = double.Parse(dt_fuel_para.Rows[0][7].ToString());//飞灰可燃物（含碳量）
                double Cinderfuel = double.Parse(dt_fuel_para.Rows[0][8].ToString());//大渣可燃物（含碳量）
                double Co = double.Parse(dt_fuel_para.Rows[0][9].ToString());//AH出口一氧化碳
                double Calorificvalue = double.Parse(dt_fuel_para.Rows[0][10].ToString());//收到基低位发热量
                double Chargingfuel = double.Parse(dt_fuel_para.Rows[0][11].ToString());//入炉燃料量



                //获取dnctype表数据
                string sql_typet = "select Id,K_Name_kw from dnctype where  Status=1 and IsDeleted=0";
                DataTable dt_type = db.GetCommand(sql_typet);
                Dictionary<int, string> dic_type = new Dictionary<int, string>();   //数据存入词典，方便查找 
                foreach (DataRow item in dt_type.Rows)
                {
                    dic_type.Add(int.Parse(item[0].ToString()), item[1].ToString());

                }


                //获取测点数据
                DateTime uptime = DateTime.MinValue;
                string sql_point = "select DncTypeId,Pvalue,RealTime from dnchzpointnow where DncBoilerId=" + boilerid;
                DataTable dt_point = db.GetCommand(sql_point);
                Dictionary<string, string> dic = new Dictionary<string, string>();   //数据存入词典，方便查找           
                if (dt_point != null && dt_point.Rows.Count > 0)
                {
                    foreach (DataRow item in dt_point.Rows)
                    {
                        dic.Add(item[0].ToString(), item[1].ToString());
                        uptime = DateTime.Parse(item[2].ToString());

                    }


                    double wind_in_temp1 = Compute.Avgdata(dic["1"]);//AH进口一次风温
                    double wind_in_temp2 = Compute.Avgdata(dic["2"]);//AH进口二次风温
                    double wind_in1 = Compute.Avgdata(dic["3"]) * 1.293 / 3600;//AH进口一次风量
                    double wind_in2 = Compute.Avgdata(dic["4"]) * 1.293 / 3600;//AH进口二次风量
                    double pzwd = Compute.Avgdata(dic["5"]);//炉膛排渣温度
                    double o2out = Compute.Avgdata(dic["6"]);//AH出口氧量
                    double kyq_in_temp_gas = Compute.Avgdata(dic["7"]);//空预器进口烟气温度
                    double temp_gas_out = Compute.Avgdata(dic["8"]);//排烟温度
                    double temp_water = Compute.Avgdata(dic["9"]);//给水温度
                    double grq_temp_out = Compute.Avgdata(dic["10"]);//过热器出口蒸汽温度
                    double grq_press_out = Compute.Avgdata(dic["11"]);//过热器出口蒸汽压力
                    double grq_ll_out = Compute.Avgdata(dic["12"]) / 3.6;//过热器出口蒸汽流量
                    double gsll = Compute.Avgdata(dic["13"]) / 3.6;//给水流量
                    double jws = Compute.Sumdata(dic["14"]) / 3.6;//减温水量
                    double dg_out_temp = Compute.Avgdata(dic["15"]);//低过出口工质温度
                    double dg_in_temp = Compute.Avgdata(dic["16"]);//低过进口工质温度
                    double smq_out_temp = Compute.Avgdata(dic["17"]);//省煤器出口工质温度
                    double smq_in_temp = Compute.Avgdata(dic["18"]);//省煤器进口工质温度
                    double dg_press_in = Compute.Avgdata(dic["19"]);//低过进口烟气侧压力
                    double dg_press_out = Compute.Avgdata(dic["20"]);//低过出口烟气侧压力
                    double smq_press_in = Compute.Avgdata(dic["21"]);//省煤器进口烟气侧压力
                    double smq_press_out = Compute.Avgdata(dic["22"]);//省煤器出口烟气侧压力
                    double jnq_press_in = Compute.Avgdata(dic["23"]);//节能器进口烟气侧压力
                    double jnq_press_out = Compute.Avgdata(dic["24"]);//节能器出口烟气侧压力
                    double kyq_press_in = Compute.Avgdata(dic["25"]);//空预器进口烟气侧压力
                    double kyq_press_out = Compute.Avgdata(dic["26"]);//空预器出口烟气侧压力
                    double fh = Compute.Avgdata(dic["27"]);//实时负荷

                    //以下为锅炉效率（反平衡）计算过程
                    double xdsd = Wxds(Drybulbtemp, Wetbulbtemp, Watertemp3, Airpress);//相对湿度
                    double bhzqyl = 611.7927 + 42.7809 * Drybulbtemp + 1.6883 * Math.Pow(Drybulbtemp, 2) + 1.2079 * Math.Pow(Drybulbtemp, 3) / 100 + 6.1637 * Math.Pow(Drybulbtemp, 4) / 10000;//饱和蒸汽压力
                    double jdsd = 0.622 * xdsd / 100 * bhzqyl / (1000 * Airpress - xdsd / 100 * bhzqyl);//绝对湿度

                    double jzwd = (wind_in1 * wind_in_temp1 + wind_in2 * wind_in_temp2) / (wind_in1 + wind_in2);//基准温度
                    double t_h_radio = Flyashratio * 100 * Flyashfuel / (100 - Flyashfuel) + Slagratio * 100 * Cinderfuel / (100 - Cinderfuel);//平均碳量与燃煤总灰量的百分率

                    double t_zl_radio = Carbon - Ashcontent * t_h_radio / 100;//实际燃烧的碳质量含量百分率
                    double hz_krw_avg = Flyashratio * Flyashfuel + Slagratio * Cinderfuel;//灰渣平均可燃物
                    double c_rj_real = Carbon - Ashcontent * hz_krw_avg / (100 - hz_krw_avg);//实际燃尽碳分

                    double co2_br = 1.59981 + 1.07732 * Math.Pow(10, -3) * temp_gas_out - 7.70675 * Math.Pow(10, -7) * Math.Pow(temp_gas_out, 2) + 3.43519 * Math.Pow(10, -10) * Math.Pow(temp_gas_out, 3);//二氧化碳定压比热
                    double n2_br = 1.29465 + 7.31852 * Math.Pow(10, -6) * temp_gas_out + 1.79523 * Math.Pow(10, -7) * Math.Pow(temp_gas_out, 2) - 6.3889 * Math.Pow(10, -10) * Math.Pow(temp_gas_out, 3);//氮气定压比热

                    double air_ll = (11.51 * c_rj_real + 34.3 * (Hydrogen - O2 / 7.937) + 4.335 * Sulfur) / 100;//理论空气量
                    double gyq_fire = 0.3132 * c_rj_real + 0.11528 * Sulfur + 0.13442 * Nitrogen;//燃烧产生的干烟气量
                    double air_gs = o2out * (gyq_fire + 10.331 * air_ll) / air_ll / (2.73 - 0.13068 * o2out);//过剩空气量
                    double co2_ah_out = (31.32 * c_rj_real + 11.528 * Sulfur) / (gyq_fire + air_ll * (10.331 + 0.13068 * air_gs));//AH出口二氧化碳



                    double t0_py_br = co2_br * co2_ah_out / 100 + n2_br * (100 - co2_ah_out) / 100;//干烟气从t0到θpy的平均定压比热

                    double xl_cp = (Temp200cp - Temp0cp) / 200;//Cp.H2O,0～200的斜率
                    double dybr_cp = xl_cp * temp_gas_out + Temp0cp;//水蒸气从t0到θpy的平均定压比热,查表：Cp.H2O,0～排烟温度的平均定压比热

                    double xl_ch = (Temp200ch - Temp100ch) / 100;//Ch,0～200的斜率
                    double hf_br = xl_ch * (temp_gas_out - 100) + Temp100ch;//飞灰比热,查表：Ch,0～排烟温度的平均定压比热
                    double dry_air_c_real = 0.089 * (t_zl_radio + 0.375 * Sulfur) + 0.265 * Hydrogen - 0.0333 * O2;//实际燃烧掉的碳计算的理论燃烧所需干空气量
                    double gyq_c_real = 1.866 - (t_zl_radio + 0.375 * Sulfur) / 100 + 0.79 * dry_air_c_real + 0.8 * Nitrogen / 100;//实际燃烧掉的碳计算的理论干烟气量
                    double gyq_v_kg = gyq_c_real + (21 / (21 - o2out) - 1) * dry_air_c_real;//每公斤燃料产生的干烟气体积
                    double szq_v_yq = 1.24 * ((9 * Hydrogen + H2o) / 100 + 1.293 * 21 / (21 - o2out) * dry_air_c_real * jdsd);//烟气中所含水蒸汽的体积

                    double gyq_loss = gyq_v_kg * t0_py_br * (temp_gas_out - jzwd) / Calorificvalue * 100;//干烟气热损失
                    double szq_yq_loss = 100 * szq_v_yq * dybr_cp * (temp_gas_out - jzwd) / Calorificvalue;//烟气所含水蒸汽的显热损失
                    double krqt_loss = gyq_v_kg * 126.36 * Co * 100 / Calorificvalue;//可燃气体未完全燃烧热损失
                    double gtwrs_loss = 337.27 * Ashcontent * t_h_radio / Calorificvalue;//固体未完全燃烧热损失
                    double hz_loss = Ashcontent / Calorificvalue / 100 * (Slagratio * 100 * (pzwd - jzwd) * Specificheat / (100 - Cinderfuel) + Flyashratio * 100 * (temp_gas_out - jzwd) * hf_br / (100 - Flyashfuel));//灰渣物理热损失
                    double heat_loss_total = gyq_loss + szq_yq_loss + krqt_loss + gtwrs_loss + Heatloss + hz_loss;//总热损失
                    double boiler_efficiency_counter = 100 - heat_loss_total;//锅炉效率（反平衡）


                    //以下为锅炉效率（正平衡）计算过程

                    double jzwd_air_in = (wind_in1 * wind_in_temp1 + wind_in2 * wind_in_temp2) / (wind_in1 + wind_in2);//进口空气基准温度
                    double whz_gs = 4.22 * (temp_water - 0);//给水焓
                    double grq_out_hz = 2022.7 + 1.6675 * (grq_temp_out + 273.15) + 2.9593 * Math.Pow(10, -4) * Math.Pow((grq_temp_out + 273.15), 2) - 1.269 * Math.Pow(10, 9) * grq_press_out / Math.Pow((grq_temp_out + 273.15), 2.7984) - 1.0185 * Math.Pow(10, 23) * Math.Pow(grq_press_out, 2) / Math.Pow((grq_temp_out + 273.15), 8.3077);//过热器出口蒸汽焓
                    double boiler_efficiency_positive = (grq_ll_out * grq_out_hz - (jws + gsll) * whz_gs) / (Calorificvalue * Chargingfuel + (wind_in1 + wind_in2) * (jzwd_air_in - 25) * Airheat) * 100;//锅炉效率（正平衡）


                    //以下为空预器实际烟气侧效率计算过程
                    double wind_temp_in = jzwd_air_in;//实测进口风温=（进口一次风量*进口一次风温+进口二次风量*进口二次风温）/（进口一次风量+进口二次风量）
                    double py_temp_dif_modify = (Design_in_wind_temp - wind_temp_in) * 0.33;//经进口风温修正后排烟温度变化值=(设计进口风温-实测进口风温)*0.33
                    double py_temp_modify = temp_gas_out + py_temp_dif_modify;//修正后的排烟温度=实测排烟温度+经进口风温修正后排烟温度变化值
                    double yqc_radio = (kyq_in_temp_gas - py_temp_modify) / (kyq_in_temp_gas - wind_temp_in);//实际烟气侧效率=(预热器进口烟温-修正后排烟温度)/(预热器进口烟温-实测进口风温)



                    arr.Add("update dncboiler set Syntime='" + uptime + "',Positive=" + boiler_efficiency_positive + ",Counter=" + boiler_efficiency_counter + " where Id=" + boilerid + ";");
                    arr.Add("insert into dncboilerrat (Positive,Counter,RealTime,Status,IsDeleted,DncBoilerId,DncBoiler_Name) values(" + boiler_efficiency_positive + "," + boiler_efficiency_counter + ",'" + uptime + "',1,0," + boilerid + ",'" + boiler_name + "');");
                    db.ExecuteTransaction(arr);
                    arr.Clear();

                    double dg_sjws = dg_out_temp - dg_in_temp;//低过实际温升=低过出口工质温度-低过进口工质温度
                    double smq_sjws = smq_out_temp - smq_in_temp;//省煤器实际温升=省煤器出口工质温度-省煤器进口工质温度
                    double dg_sjyj = dg_press_in - dg_press_out;// 低过实际压降=实时（低过进口烟气侧压力-低过出口烟气侧压力）
                    double smq_sjyj = smq_press_in - smq_press_out;//省煤器实际压降=实时（省煤器进口烟气侧压力-省煤器出口烟气侧压力）
                    double jnq_sjyj = jnq_press_in - jnq_press_out;//节能器实际压降=实时（节能器进口烟气侧压力-节能器出口烟气侧压力）
                    double kyq_sjyj = kyq_press_in - kyq_press_out;//空预器实际压降=实时（空预器进口烟气侧压力-空预器出口烟气侧压力）


                    DateTime dtnow = DateTime.Now;
                    int sta_ch_exec = 0;//执行吹灰标志，初始化0
                    if (chrun == 0)//吹灰刚执行完，准备计算参考温升、参考压降
                    {

                        if (dtnow.Subtract(dt_chend).TotalMinutes > 20)
                        {
                            arr.Add("update dnccharea set Ckws_Val=" + dg_sjws + ",Ckws_time='" + dtnow + "',Ckyj_Val=" + dg_sjyj + ",Ckyj_time='" + dtnow + "' where DncBoilerId=" + boilerid + " and Name_kw='低过';");
                            arr.Add("update dnccharea set Ckws_Val=" + smq_sjws + ",Ckws_time='" + dtnow + "',Ckyj_Val=" + smq_sjyj + ",Ckyj_time='" + dtnow + "' where DncBoilerId=" + boilerid + " and Name_kw='省煤器';");
                            arr.Add("update dnccharea set Ckyj_Val=" + jnq_sjyj + ",Ckyj_time='" + dtnow + "' where DncBoilerId=" + boilerid + " and Name_kw='节能器';");
                            //arr.Add("update dnccharea set Ckyj=" + kyq_sjyj + ",Ckyj_time='" + dtnow + "' where DncBoilerId=" + boilerid + " and Name_kw='空预器';");
                            arr.Add("update dncboiler set Ch_Run=1 where Id=" + boilerid + ";");
                            db.ExecuteTransaction(arr);
                            arr.Clear();

                        }

                    }
                    else if (chrun == 1)//参考温升、参考压降，满30分钟开始加入待吹灰列表
                    {
                        if (dtnow.Subtract(dt_chend).TotalMinutes > 30)
                        {
                            string sql_area = "select Id,Wrldch_Val,Wrlexec_Val,Dslhigh_Val,Dslexec_Val,Ckws_Val,Ckyj_Val,Name_kw from dnccharea where DncBoilerId=" + boilerid;
                            DataTable dt_area = db.GetCommand(sql_area);
                            foreach (DataRow item in dt_area.Rows)
                            {
                                int area_id = int.Parse(item[0].ToString());//区域ID
                                double Wrldch_Val = double.Parse(item[1].ToString());//加入待吹灰列表污染率上限
                                double Wrlexec_Val = double.Parse(item[2].ToString()); //加入执行吹灰列表污染率上限
                                double Dslhigh_Val = double.Parse(item[3].ToString());//加入待吹灰列表堵塞率上限
                                double Dslexec_Val = double.Parse(item[4].ToString());//加入执行吹灰列表堵塞率上限
                                double ckws = double.Parse(item[5].ToString());//参考温升
                                double ckyj = double.Parse(item[6].ToString());//参考压降
                                string area_name = item[7].ToString();//区域名称
                                double wrl = 0;//污染率初始化
                                double dsl = 0;//堵塞率初始化

                                if (fh > 10)
                                {
                                    if (Wrldch_Val > 0 && area_name == "低过")
                                    {
                                        wrl = ckws / dg_sjws;//低过污染率
                                        arr.Add("update dnccharea set Wrl_Val=" + wrl + " where Id=" + area_id + ";");
                                        arr.Add("update dncchqpoint set Wrl_Val=" + wrl + " where DncChareaId=" + area_id + ";");

                                    }
                                    if (Dslhigh_Val > 0 && area_name == "低过")
                                    {
                                        dsl = ckyj / dg_sjyj;//低过堵塞率
                                        arr.Add("update dnccharea set Dsl_Val=" + dsl + " where Id=" + area_id + ";");
                                        arr.Add("update dncchqpoint set Dsl_Val=" + dsl + " where DncChareaId=" + area_id + ";");
                                    }
                                    if (Wrldch_Val > 0 && area_name == "省煤器")
                                    {
                                        wrl = ckws / smq_sjws;//省煤器污染率
                                        arr.Add("update dnccharea set Wrl_Val=" + wrl + " where Id=" + area_id + ";");
                                        arr.Add("update dncchqpoint set Wrl_Val=" + wrl + " where DncChareaId=" + area_id + ";");
                                    }
                                    if (Dslhigh_Val > 0 && area_name == "省煤器")
                                    {
                                        dsl = ckyj / smq_sjyj;//省煤器堵塞率
                                        arr.Add("update dnccharea set Dsl_Val=" + dsl + " where Id=" + area_id + ";");
                                        arr.Add("update dncchqpoint set Dsl_Val=" + dsl + " where DncChareaId=" + area_id + ";");
                                    }
                                    if (Dslhigh_Val > 0 && area_name == "节能器")
                                    {
                                        dsl = ckyj / jnq_sjyj;//节能器堵塞率
                                        arr.Add("update dnccharea set Dsl_Val=" + dsl + " where Id=" + area_id + ";");
                                        arr.Add("update dncchqpoint set Dsl_Val=" + dsl + " where DncChareaId=" + area_id + ";");
                                    }

                                    
                                  

                                    if (wrl > Wrlexec_Val || dsl > Dslexec_Val)//执行列表
                                    {
                                        sta_ch_exec = 1;
                                    }
                                    else if ((wrl > Wrldch_Val) && (wrl <= Wrlexec_Val) || (dsl > Dslhigh_Val && dsl <= Dslexec_Val))//加入待吹灰
                                    {
                                        sta_ch_exec = 2;
                                    }

                                }


                            }

                            db.ExecuteTransaction(arr);
                            arr.Clear();
                            db.CommandExecuteNonQuery("UPDATE dnccharea set RealTime=now() where Name_kw<>'空预器' and  DncBoilerId=" + boilerid);
                            db.CommandExecuteNonQuery("insert dncchareahis(K_Name_kw,Remarks,`Status`,IsDeleted,DncBoilerId,DncBoiler_Name,Wrl_Val,Wrldch_Val,Wrlexcu_Val,Dsl_Val,Dslhigh_Val,Dslexcu_Val,RealTime,AreaId) select Name_kw,Remarks,`Status`,IsDeleted,DncBoilerId,DncBoiler_Name,Wrl_Val,Wrldch_Val,Wrlexec_Val,Dsl_Val,Dslhigh_Val,Dslexec_Val,RealTime,Id from dnccharea where Name_kw<>'空预器' and DncBoilerId=" + boilerid);

                            if (sta_ch_exec == 2)
                            {
                                arr.Add("insert dncchlist(K_Name_kw, AddTime, RunTime, Remarks, DncChqpointId, DncChqpoint_Name, Wrl_Val, Dsl_Val, AddReason, DncBoilerId, DncBoiler_Name,`Status`, IsDeleted, DncChareaId) select Name_kw, NOW() as dtnow, NULL, NULL, Id as chqid, Name_kw, Wrl_Val, Dsl_Val, CASE WHEN Wrlhigh_Val <> 0 and Wrl_Val > Wrlhigh_Val THEN '污染率超标' WHEN(Dslhigh_Val <> 0 and Dsl_Val > Dslhigh_Val) then '堵塞率超标'  END as addreason, DncBoilerId, DncBoiler_Name, 0, 0, DncChareaId from dncchqpoint where ((Wrlhigh_Val <> 0 and Wrl_Val > Wrlhigh_Val) or(Dslhigh_Val <> 0 and Dsl_Val > Dslhigh_Val)) and DncBoilerId = " + boilerid + " and DncCharea_Name<>'空预器';");
                                arr.Add("update dncboiler set Ch_Run=2 where Id=" + boilerid + ";");
                                db.ExecuteTransaction(arr);
                                arr.Clear();

                                string sql_dch_num = "select * from dncchlist where `Status`=0 and IsDeleted=0 and DncBoilerId = " + boilerid;
                                DataTable dt_dch_num = db.GetCommand(sql_dch_num);
                                if (dt_dch_num.Rows.Count >= 5)//待吹灰列表中达到5组加入执行列表
                                {
                                    arr.Add("update dncchlist set `Status`=1 where `Status`=0 and IsDeleted=0 and DncBoilerId = " + boilerid + ";");
                                    arr.Add("update dncboiler set Ch_Run=3 where Id=" + boilerid + ";");
                                    db.ExecuteTransaction(arr);
                                    arr.Clear();
                                }


                            }
                            else if(sta_ch_exec==1)
                            {
                                arr.Add("insert dncchlist(K_Name_kw, AddTime, RunTime, Remarks, DncChqpointId, DncChqpoint_Name, Wrl_Val, Dsl_Val, AddReason, DncBoilerId, DncBoiler_Name,`Status`, IsDeleted, DncChareaId) select Name_kw, NOW() as dtnow, NULL, NULL, Id as chqid, Name_kw, Wrl_Val, Dsl_Val, CASE WHEN Wrlhigh_Val <> 0 and Wrl_Val > Wrlhigh_Val THEN '污染率超标' WHEN(Dslhigh_Val <> 0 and Dsl_Val > Dslhigh_Val) then '堵塞率超标'  END as addreason, DncBoilerId, DncBoiler_Name, 1, 0, DncChareaId from dncchqpoint where ((Wrlhigh_Val <> 0 and Wrl_Val > Wrlhigh_Val) or(Dslhigh_Val <> 0 and Dsl_Val > Dslhigh_Val)) and DncBoilerId = " + boilerid + " and DncCharea_Name<>'空预器';");
                                arr.Add("update dncboiler set Ch_Run=3 where Id=" + boilerid + ";");
                                db.ExecuteTransaction(arr);
                                arr.Clear();
                            }



                        }
                    }
                    else if(chrun==2)//待吹灰列表里已有数据
                    {
                        string sql_area = "select Id,Wrldch_Val,Wrlexec_Val,Dslhigh_Val,Dslexec_Val,Ckws_Val,Ckyj_Val,Name_kw from dnccharea where DncBoilerId=" + boilerid;
                        DataTable dt_area = db.GetCommand(sql_area);
                        foreach (DataRow item in dt_area.Rows)
                        {
                            int area_id = int.Parse(item[0].ToString());//区域ID
                            double Wrldch_Val = double.Parse(item[1].ToString());//加入待吹灰列表污染率上限
                            double Wrlexec_Val = double.Parse(item[2].ToString()); //加入执行吹灰列表污染率上限
                            double Dslhigh_Val = double.Parse(item[3].ToString());//加入待吹灰列表堵塞率上限
                            double Dslexec_Val = double.Parse(item[4].ToString());//加入执行吹灰列表堵塞率上限
                            double ckws = double.Parse(item[5].ToString());//参考温升
                            double ckyj = double.Parse(item[6].ToString());//参考压降
                            string area_name = item[7].ToString();//区域名称
                            double wrl = 0;//污染率初始化
                            double dsl = 0;//堵塞率初始化

                            if (fh > 10)
                            {
                                if (Wrldch_Val > 0 && area_name == "低过")
                                {
                                    wrl = ckws / dg_sjws;//低过污染率
                                    arr.Add("update dnccharea set Wrl_Val=" + wrl + " where Id=" + area_id + ";");
                                    arr.Add("update dncchqpoint set Wrl_Val=" + wrl + " where DncChareaId=" + area_id + ";");

                                }
                                if (Dslhigh_Val > 0 && area_name == "低过")
                                {
                                    dsl = ckyj / dg_sjyj;//低过堵塞率
                                    arr.Add("update dnccharea set Dsl_Val=" + dsl + " where Id=" + area_id + ";");
                                    arr.Add("update dncchqpoint set Dsl_Val=" + dsl + " where DncChareaId=" + area_id + ";");
                                }
                                if (Wrldch_Val > 0 && area_name == "省煤器")
                                {
                                    wrl = ckws / smq_sjws;//省煤器污染率
                                    arr.Add("update dnccharea set Wrl_Val=" + wrl + " where Id=" + area_id + ";");
                                    arr.Add("update dncchqpoint set Wrl_Val=" + wrl + " where DncChareaId=" + area_id + ";");
                                }
                                if (Dslhigh_Val > 0 && area_name == "省煤器")
                                {
                                    dsl = ckyj / smq_sjyj;//省煤器堵塞率
                                    arr.Add("update dnccharea set Dsl_Val=" + dsl + " where Id=" + area_id + ";");
                                    arr.Add("update dncchqpoint set Dsl_Val=" + dsl + " where DncChareaId=" + area_id + ";");
                                }
                                if (Dslhigh_Val > 0 && area_name == "节能器")
                                {
                                    dsl = ckyj / jnq_sjyj;//节能器堵塞率
                                    arr.Add("update dnccharea set Dsl_Val=" + dsl + " where Id=" + area_id + ";");
                                    arr.Add("update dncchqpoint set Dsl_Val=" + dsl + " where DncChareaId=" + area_id + ";");
                                }


                              

                                if (wrl > Wrlexec_Val || dsl > Dslexec_Val)//加入执行列表
                                {
                                    sta_ch_exec = 1;
                                }
                                else if ((wrl > Wrldch_Val) && (wrl <= Wrlexec_Val) || (dsl > Dslhigh_Val && dsl <= Dslexec_Val))//加入待吹灰
                                {
                                    sta_ch_exec = 2;
                                }

                            }


                        }

                        db.ExecuteTransaction(arr);
                        arr.Clear();
                        db.CommandExecuteNonQuery("UPDATE dnccharea set RealTime=now() where Name_kw<>'空预器' and  DncBoilerId=" + boilerid);
                        db.CommandExecuteNonQuery("insert dncchareahis(K_Name_kw,Remarks,`Status`,IsDeleted,DncBoilerId,DncBoiler_Name,Wrl_Val,Wrldch_Val,Wrlexcu_Val,Dsl_Val,Dslhigh_Val,Dslexcu_Val,RealTime,AreaId) select Name_kw,Remarks,`Status`,IsDeleted,DncBoilerId,DncBoiler_Name,Wrl_Val,Wrldch_Val,Wrlexec_Val,Dsl_Val,Dslhigh_Val,Dslexec_Val,RealTime,Id from dnccharea where Name_kw<>'空预器' and DncBoilerId=" + boilerid);

                        if (sta_ch_exec == 2)
                        {
                            arr.Add("insert dncchlist(K_Name_kw, AddTime, RunTime, Remarks, DncChqpointId, DncChqpoint_Name, Wrl_Val, Dsl_Val, AddReason, DncBoilerId, DncBoiler_Name,`Status`, IsDeleted, DncChareaId) select Name_kw, NOW() as dtnow, NULL, NULL, Id as chqid, Name_kw, Wrl_Val, Dsl_Val, CASE WHEN Wrlhigh_Val <> 0 and Wrl_Val > Wrlhigh_Val THEN '污染率超标' WHEN(Dslhigh_Val <> 0 and Dsl_Val > Dslhigh_Val) then '堵塞率超标'  END as addreason, DncBoilerId, DncBoiler_Name, 0, 0, DncChareaId from dncchqpoint where ((Wrlhigh_Val <> 0 and Wrl_Val > Wrlhigh_Val) or(Dslhigh_Val <> 0 and Dsl_Val > Dslhigh_Val)) and DncBoilerId = " + boilerid + " and DncCharea_Name<>'空预器' and Name_kw not in(select K_Name_kw from dncchlist where `Status`=0 and IsDeleted =0);");
                            
                            db.ExecuteTransaction(arr);
                            arr.Clear();

                            string sql_dch_num = "select * from dncchlist where `Status`=0 and IsDeleted=0 and DncBoilerId = " + boilerid;
                            DataTable dt_dch_num = db.GetCommand(sql_dch_num);
                            if (dt_dch_num.Rows.Count >= 5)//待吹灰列表中达到5组加入执行列表
                            {
                                arr.Add("update dncchlist set `Status`=1 where `Status`=0 and IsDeleted=0 and DncBoilerId = " + boilerid + ";");
                                arr.Add("update dncboiler set Ch_Run=3 where Id=" + boilerid + ";");
                                db.ExecuteTransaction(arr);
                                arr.Clear();
                            }


                        }
                        else if(sta_ch_exec == 1)
                        {
                            arr.Add("insert dncchlist(K_Name_kw, AddTime, RunTime, Remarks, DncChqpointId, DncChqpoint_Name, Wrl_Val, Dsl_Val, AddReason, DncBoilerId, DncBoiler_Name,`Status`, IsDeleted, DncChareaId) select Name_kw, NOW() as dtnow, NULL, NULL, Id as chqid, Name_kw, Wrl_Val, Dsl_Val, CASE WHEN Wrlhigh_Val <> 0 and Wrl_Val > Wrlhigh_Val THEN '污染率超标' WHEN(Dslhigh_Val <> 0 and Dsl_Val > Dslhigh_Val) then '堵塞率超标'  END as addreason, DncBoilerId, DncBoiler_Name, 1, 0, DncChareaId from dncchqpoint where ((Wrlhigh_Val <> 0 and Wrl_Val > Wrlhigh_Val) or(Dslhigh_Val <> 0 and Dsl_Val > Dslhigh_Val)) and DncBoilerId = " + boilerid + " and DncCharea_Name<>'空预器' and Name_kw not in(select K_Name_kw from dncchlist where `Status`=0 and IsDeleted =0);");
                            arr.Add("update dncchlist set `Status`=1 where `Status`=0 and IsDeleted=0 and DncBoilerId = " + boilerid + ";");
                            arr.Add("update dncboiler set Ch_Run=3 where Id=" + boilerid + ";");
                            db.ExecuteTransaction(arr);
                            arr.Clear();
                        }
                    }



                    if (chrun_kyq == 0)//吹灰刚执行完，准备计算参考压降
                    {


                        if (dtnow.Subtract(dt_chend_kyq).TotalMinutes > 20)
                        {
                            // string sql_area = "select Id";
                            arr.Add("update dnccharea set Ckyj_Val=" + kyq_sjyj + ",Ckyj_time='" + dtnow + "' where DncBoilerId=" + boilerid + " and Name_kw='空预器';");
                            arr.Add("update dncboiler set Ch_Run_kyq=1 where Id=" + boilerid + ";");
                            db.ExecuteTransaction(arr);
                            arr.Clear();
                        }

                    }
                    else if (chrun_kyq == 1)//
                    {
                        string sql_area_kyq = "select Id,Wrlexec_Val,Dslexec_Val,Ckyj_Val from dnccharea where Name_kw='空预器' and DncBoilerId=" + boilerid;
                        DataTable dt_area_kyq = db.GetCommand(sql_area_kyq);
                        int area_id_kyq = int.Parse(dt_area_kyq.Rows[0][0].ToString());//区域ID

                        double Wrlexec_Val_kyq = double.Parse(dt_area_kyq.Rows[0][1].ToString()); //加入执行吹灰列表烟气侧效率下限

                        double Dslexec_Val_kyq = double.Parse(dt_area_kyq.Rows[0][2].ToString());//加入执行吹灰列表堵塞率上限

                        double ckyj_kyq = double.Parse(dt_area_kyq.Rows[0][3].ToString());//参考压降

                        double dsl_kyq = 0;//堵塞率初始化
                        arr.Add("update dnccharea set Wrl_Val=" + yqc_radio + " where Name_kw='空预器' and DncBoilerId= " + boilerid + ";");
                        arr.Add("update dncchqpoint set Wrl_Val=" + yqc_radio + " where DncCharea_Name='空预器' and DncBoilerId= " + boilerid + ";");
                        dsl_kyq = ckyj_kyq / kyq_sjyj;//空预器堵塞率
                        arr.Add("update dnccharea set Dsl_Val=" + dsl_kyq + " where Name_kw='空预器' and DncBoilerId= " + boilerid);
                        arr.Add("update dncchqpoint set Dsl_Val=" + dsl_kyq + " where DncCharea_Name='空预器' and DncBoilerId= " + boilerid + ";");
                        db.ExecuteTransaction(arr);
                        arr.Clear();
                        db.CommandExecuteNonQuery("UPDATE dnccharea set RealTime=now() where Name_kw='空预器' and  DncBoilerId=" + boilerid);
                        db.CommandExecuteNonQuery("insert dncchareahis(K_Name_kw,Remarks,`Status`,IsDeleted,DncBoilerId,DncBoiler_Name,Wrl_Val,Wrldch_Val,Wrlexcu_Val,Dsl_Val,Dslhigh_Val,Dslexcu_Val,RealTime,AreaId) select Name_kw,Remarks,`Status`,IsDeleted,DncBoilerId,DncBoiler_Name,Wrl_Val,Wrldch_Val,Wrlexec_Val,Dsl_Val,Dslhigh_Val,Dslexec_Val,RealTime,Id from dnccharea where Name_kw='空预器' and DncBoilerId=" + boilerid);

                        if (yqc_radio < Wrlexec_Val_kyq || dsl_kyq > Dslexec_Val_kyq)
                        {
                            arr.Add("insert dncchrunlist_kyq(Name_kw, AddTime, RunTime, Remarks, DncChqpointId, DncChqpoint_Name, DncBoilerId, DncBoiler_Name,`Status`, IsDeleted) select Name_kw, NOW() as dtnow, NULL, CASE WHEN  Wrl_Val < Wrlhigh_Val THEN '烟气侧效率低于下限' WHEN Dsl_Val > Dslhigh_Val then '堵塞率超标'  END as addreason, Id as chqid, Name_kw, DncBoilerId, DncBoiler_Name, 1, 0 from dncchqpoint where DncBoilerId = "+boilerid+" and DncCharea_Name = '空预器';");
                            arr.Add("update dncboiler set Ch_Run_kyq=2 where Id=" + boilerid + ";");
                            db.ExecuteTransaction(arr);
                            arr.Clear();
                        }

                    }
                  //  db.CommandExecuteNonQuery("UPDATE dnccharea set RealTime=now() where DncBoilerId="+boilerid);
                   // db.CommandExecuteNonQuery("insert dncchareahis(K_Name_kw,Remarks,`Status`,IsDeleted,DncBoilerId,DncBoiler_Name,Wrl_Val,Wrldch_Val,Wrlexcu_Val,Dsl_Val,Dslhigh_Val,Dslexcu_Val,RealTime,AreaId) select Name_kw,Remarks,`Status`,IsDeleted,DncBoilerId,DncBoiler_Name,Wrl_Val,Wrldch_Val,Wrlexec_Val,Dsl_Val,Dslhigh_Val,Dslexec_Val,RealTime,Id from dnccharea where DncBoilerId="+boilerid);

                }







            }

            catch (Exception rrr)
            {
                AddLgoToTXT(rrr.Message + "\n " + rrr.StackTrace);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            znrs_ch();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string szServer = "10.56.250.147";
            string szDB = "WH";
            string szUser = "dba";
            string szPassWord = "123456";
            int iPort = 1666;
            //1.0连接服务器

            Connect(szServer, szDB, szUser, szPassWord, iPort);

            getpoint();
          
        }


        static bool Connect(string szServer, string szDB, string szUser, string szPassWord, int iPort)
        {
            if (m_pServer != null && m_pServer.Online)
            {
                m_pServer.DisConnect();
                m_pServer = null;
            }
            m_pServer = new CLServer();
            m_pServer.Connect(0, szServer, szDB, szUser, szPassWord, iPort);
            return true;
        }

        static List<int> GetIDofNames(Dictionary<int, string> dic)
        {
           
            // string[] Names = new string[] { "2JD1004A_2JD1004B.OUT", "1TE1009A.OUT" };
            string[] Names = dic.Values.ToArray();
            int[] Ids = new int[dic.Count];
            Ids = m_pServer.GetIDOfNames(Names);

            return Ids.ToList();
        }

        static bool ReadRtValue(int[] ids)
        {
           // int[] ids = new int[2] { m_iID1, m_iID2 };
            ILValueList pList = null;
            pList = m_pServer.GetRTValues(ids);
            if (pList != null)
            {
                List<string> arr_up = new List<string>();
               
                DBHelper db = new DBHelper();
                //string sql_kks = "select Ordernum,Name_kw from  dncpointkks  where DncBoilerId=" + boilerid + " ORDER BY Ordernum";
                //DataTable dt_kks = db.GetCommand(sql_kks);
               
                   
              //  db.ExecuteTransaction(arr_up);
                for (uint i = 0; i < pList.Count; i++)
                {
                    CLValue pValue = pList.GetValue(i);
                    long tt = pValue.Time;
                    short uQaulity = pValue.Quality;
                    short uStat = pValue.Stat;     //Stat=0表示无实时数据
                    double fValue = pValue.Value;
                    arr_up.Add("UPDATE dncpointkks set Pvalue=" + fValue + ",RealTime=now() where Ordernum=" + i + " and DncBoilerId=" + boilerid);


                }
                if (db.ExecuteTransaction(arr_up))
                {
                    arr_up.Clear();
                    arr_up.Add("insert dncpointkks_data(DncTypeId,DncType_Name,Name_kw,Remarks,`Status`,IsDeleted,DncBoilerId,DncBoiler_Name,RealTime,Pvalue) SELECT DncTypeId,DncType_Name,Name_kw,Remarks,`Status`,IsDeleted,DncBoilerId,DncBoiler_Name,RealTime,Pvalue from dncpointkks where DncBoilerId=" + boilerid) ;
                    if (db.ExecuteTransaction(arr_up))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                else
                {
                    return false;
                }
            }
            return false;
           
        }
        //获取测点数据
        public static void getpoint()
        {
          
            Dictionary<int,string> a = new Dictionary<int, string>();
            DBHelper db = new DBHelper();
            string sql_kks = "select Ordernum,Name_kw from  dncpointkks  where DncBoilerId=" + boilerid+" ORDER BY Ordernum";
            DataTable dt_kks = db.GetCommand(sql_kks);
            int k = 0;
            foreach (DataRow item in dt_kks.Rows)
            {
                a.Add(int.Parse(item[0].ToString()),item[1].ToString());
                k++;
            }
           
            List<int> arr = GetIDofNames(a);
            bool t =  ReadRtValue(arr.ToArray());
            if (t)
            {
                Hzpoint();
            }
            else
            {
                MessageBox.Show("测点数据获取失败！");
            }
           


            ;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                string szServer = "10.56.250.147";
                string szDB = "WH";
                string szUser = "dba";
                string szPassWord = "123456";
                int iPort = 1666;
                //1.0连接服务器

                Connect(szServer, szDB, szUser, szPassWord, iPort);

                getpoint();
                znrs_ch();


            }
            catch (Exception rrr)
            {

                AddLgoToTXT(rrr.Message + "\n " + rrr.StackTrace);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }
    }
}
