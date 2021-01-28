using LitJson;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using WHCH.Api.dataoperate;

namespace SynWHCH
{
    public class Compute
    {
        /// <summary>
        /// 传入数组格式的数据，返回平均值
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static double Avgdata(string data)
        {
            JsonData jsonData = JsonMapper.ToObject(data);
            
            int count = jsonData.Count;
            if (count == 1)
            {
                return double.Parse(jsonData[0].ToString());
            }
            else
            {
                double a = 0d;

                for (int i = 0; i < count; i++)
                {
                    a = a + double.Parse(jsonData[i].ToString());

                }
                a = a / count;
                return a;
            }

        }

        /// <summary>
        /// 传入数组字符串，获取数据和
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static double Sumdata(string data)
        {
            JsonData jsonData = JsonMapper.ToObject(data);

            int count = jsonData.Count;
            double sum = 0d;
            for (int i = 0; i < count; i++)
            {
                sum = sum + double.Parse(jsonData[i].ToString());

            }
            return sum;
        }

        /// <summary>
        /// 传入数组字符串，获取最大值
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static double Maxdata(double[] data)
        {
            double a = 0d;
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] > a)
                {
                    a = data[i];
                }
            }
            return a;           
        }

        /// <summary>
        ///  传入数组字符串，获取最小值
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static double Mindata(double[] data)
        {
            double a = data[0];
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] < a)
                {
                    a = data[i];
                }
            }
            return a;
        }



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
        /// 减温水焓增计算公式
        /// </summary>
        /// <param name="temp"></param>
        /// <param name="press"></param>
        /// <returns></returns>

        public static double Whz(double temp, double press)
        {

            // return 130.06 + 0.947711 * t ^ 1.2521 + p * (0.7234 - 9.2384 * (10 ^ -10) * t ^ 3.6606);
           // var whz = 130.06 + 0.947711 * Math.Pow(temp, 1.2521) + press * (0.7234 - 9.2384 * (10e-10) * Math.Pow(temp, 3.6606));
            var whz= 130.06 + 0.947711 * Math.Pow(temp, 1.2521) + press * (0.7234 - 9.2384 * Math.Pow(10, -10) * Math.Pow(temp, 3.6606));
            return whz;
        }

        /// <summary>
        /// O2、NOx巡测测点平均值计算
        /// </summary>
        /// <returns></returns>
        public static double[] O_avg(string deep1, string deep2, string deep3)
        {
            double[] avg = new double[2];
            JsonData jsonData1 = JsonMapper.ToObject(deep1);
            JsonData jsonData2 = JsonMapper.ToObject(deep2);
            JsonData jsonData3 = JsonMapper.ToObject(deep3);
            int count1 = jsonData1.Count;
            int count2 = jsonData2.Count;
            int count3 = jsonData3.Count;

            double a = 0d;
            double b = 0d;
            for (int i = 0; i < count1; i++)
            {
                if (i < count1 / 2)
                {
                    a = a + double.Parse(jsonData1[i].ToString());
                }
                else
                {
                    b = b + double.Parse(jsonData1[i].ToString());
                }


            }

            for (int i = 0; i < count2; i++)
            {
                if (i < count2 / 2)
                {
                    a = a + double.Parse(jsonData2[i].ToString());
                }
                else
                {
                    b = b + double.Parse(jsonData2[i].ToString());
                }


            }

            for (int i = 0; i < count3; i++)
            {
                if (i < count3 / 2)
                {
                    a = a + double.Parse(jsonData3[i].ToString());
                }
                else
                {
                    b = b + double.Parse(jsonData3[i].ToString());
                }


            }

            avg[0] = a / (count1 / 2 + count2 / 2 + count3 / 2);
            avg[1] = b / (count1 / 2 + count2 / 2 + count3 / 2);
            return avg;


        }

        /// <summary>
        /// 传入数组和定义取最高的n个值，返回最高n个的平均值
        /// </summary>
        /// <param name="data"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static double Avgtopn(string data, int n)
        {
            JsonData jsonData = JsonMapper.ToObject(data);
            int count = jsonData.Count;
            var list = new List<double>();
            for (int i = 0; i < count; i++)
            {
                list.Add(double.Parse(jsonData[i].ToString()));
            }
            var q = from u in list.ToArray() select u;
            return q.OrderByDescending(x => x).Take(n).Average();
           
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hq">减温器前焓值</param>
        /// <param name="hh">减温器后焓值</param>
        /// <param name="hj">低再减温水焓值</param>
        /// <param name="fh">实时负荷</param>
        /// <param name="edfh">额定负荷（MW）</param>
        /// <param name="edll">再热蒸汽设计流量</param>
        /// <returns></returns>
        public static double Jwsl_zrq(double hq,double hh,double hj,double fh,double edfh,double edll)
        {
            double jwsl = (hq - hh) / (hh - hj) * (fh * edll / edfh);
            return jwsl;
        }

        /// <summary>
        /// 输入：arr 要查找的数组，x：要查找的值
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int FindIndex(string arr, double x)
        {
            
            var index = -1;
            JsonData jsonData = JsonMapper.ToObject(arr);
            int count = jsonData.Count;
            if (x >= double.Parse(jsonData[0].ToString()))
            {
                index = 0;
            }
            else if (x <= double.Parse(jsonData[count - 1].ToString()))
            {
                index = count - 1;
            }
             else

            { 
                for (var i = 0; i < count - 1; i++)
                {
                    if (x <= double.Parse(jsonData[i].ToString()) && x > double.Parse(jsonData[i + 1].ToString()))
                    {
                        index = i;
                        break;
                    }
                }
            }
            
            return index;
        }

       


        /// <summary>
        /// 传入测点数据组，返回左右切圆的数组
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string[] Qy(string data)
        {
           
            string[] qy = new string[2];
            List<string> left_qy = new List<string>();//左切圆数组
            List<string> right_qy = new List<string>();//右切圆数组
            JsonData jsonData = JsonMapper.ToObject(data);
            int count = jsonData.Count;
            //偶数测点的情况
            if (count % 2 == 0)
            {
                for (int i = 0; i < count; i++)
                {
                    if (i < count / 2)
                    {
                        left_qy.Add(jsonData[i].ToString());
                        
                    }
                    else
                    {
                        right_qy.Add(jsonData[i].ToString());
                    }
                    
                }
            }
            //奇数测点的情况
            else
            {
                for (int i = 0; i < count; i++)
                {
                    if (i < (count + 1)/ 2)
                    {
                        left_qy.Add(jsonData[i].ToString());
                    }
                    if(i > ((count - 1) / 2 - 1))
                    {
                        right_qy.Add(jsonData[i].ToString());
                    }

                }

            }
            qy[0] = "["+string.Join(',',left_qy)+"]";
            qy[1] = "[" + string.Join(',', right_qy) + "]";
            return qy;
        }



        /// <summary>
        /// 悬吊管取最高点、值以及最高三点、平均值
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>

        public static Returndata Xdgdata(string data)
        {
            
            JsonData jsonData = JsonMapper.ToObject(data);
            int count = jsonData.Count;

            JsonData left_qy_back_xdg_left_top = new JsonData();//左切圆后墙悬吊管水冷壁左侧最高点
            JsonData left_qy_back_xdg_right_top = new JsonData();//左切圆后墙悬吊管水冷壁右侧最高点
            JsonData right_qy_back_xdg_left_top = new JsonData();//右切圆后墙悬吊管水冷壁左侧最高点
            JsonData right_qy_back_xdg_right_top = new JsonData();//右切圆后墙悬吊管水冷壁右侧最高点

            double left_qy_back_xdg_left_top_value = 0d;//左切圆后墙悬吊管水冷壁左侧最高点的值
            double left_qy_back_xdg_right_top_value = 0d;//左切圆后墙悬吊管水冷壁右侧最高点的值
            double right_qy_back_xdg_left_top_value = 0d;//右切圆后墙悬吊管水冷壁左侧最高点的值
            double right_qy_back_xdg_right_top_value = 0d;//右切圆后墙悬吊管水冷壁右侧最高点的值

            JsonData left_qy_back_xdg_left_top3 = new JsonData();//左切圆后墙悬吊管水冷壁左侧最高三个点
            JsonData left_qy_back_xdg_right_top3 = new JsonData();//左切圆后墙悬吊管水冷壁右侧最高三个点
            JsonData right_qy_back_xdg_left_top3 = new JsonData();//右切圆后墙悬吊管水冷壁左侧最高三个点
            JsonData right_qy_back_xdg_right_top3 = new JsonData();//右切圆后墙悬吊管水冷壁右侧最高三个点

            double left_qy_back_xdg_left_top3_avg = 0d;//左切圆后墙悬吊管水冷壁左侧最高三个点的平均值
            double left_qy_back_xdg_right_top3_avg = 0d;//左切圆后墙悬吊管水冷壁右侧最高三个点的平均值
            double right_qy_back_xdg_left_top3_avg = 0d;//右切圆后墙悬吊管水冷壁左侧最高三个点的平均值
            double right_qy_back_xdg_right_top3_avg = 0d;//右切圆后墙悬吊管水冷壁右侧最高三个点的平均值

            var list = new List<Datalist>();
            for (int i = 0; i < count; i++)
            {
                var obj = new Datalist();
                obj.Id = i + 1;
                obj.Pvalue = double.Parse(jsonData[i].ToJson().Replace("\"", "").Replace("\"", ""));
                list.Add(obj);

            }
            var q = from u in list.ToArray() select u;
            Returndata rd = new Returndata();
            //left_qy_back_xdg_left_top3.ToJson()

            if (count%2 == 0)
            {
                if (count%4 == 0)
                {
                    int num_top = count / 4 - 1;//取最高点的数量
                    int num_top_3 = count / 4;//取最高3点的数量

                    //左切圆左边最高点
                    var ll1 = q.Take(num_top).OrderByDescending(x => x.Pvalue).Take(1);
                    foreach (var item in ll1)
                    {
                        left_qy_back_xdg_left_top["" + item.Id] = item.Pvalue;
                        left_qy_back_xdg_left_top_value = item.Pvalue;
                    }

                    //左切圆右边最高点
                    var lr1 = q.Skip(num_top_3 + 1).Take(num_top).OrderByDescending(x => x.Pvalue).Take(1);
                    foreach (var item in lr1)
                    {
                        left_qy_back_xdg_right_top["" + item.Id] = item.Pvalue;
                        left_qy_back_xdg_right_top_value = item.Pvalue;
                    }

                    //右切圆左边最高点
                    var rl1 = q.Skip(count / 2).Take(num_top).OrderByDescending(x => x.Pvalue).Take(1);
                    foreach (var item in rl1)
                    {
                        right_qy_back_xdg_left_top["" + item.Id] = item.Pvalue;
                        right_qy_back_xdg_left_top_value = item.Pvalue;
                    }

                    //右切圆右边最高点
                    var rr1 = q.Skip(count / 2 + num_top_3 + 1).Take(num_top).OrderByDescending(x => x.Pvalue).Take(1);
                    foreach (var item in rr1)
                    {
                        right_qy_back_xdg_right_top["" + item.Id] = item.Pvalue;
                        right_qy_back_xdg_right_top_value = item.Pvalue;
                    }

                    //左切圆左侧最高三个点
                    var ll3 = q.Take(num_top_3).OrderByDescending(x => x.Pvalue).Take(3);
                    left_qy_back_xdg_left_top3_avg = ll3.Average(x => x.Pvalue);
                    foreach (var item in ll3)
                    {
                        left_qy_back_xdg_left_top3["" + item.Id] = item.Pvalue;
                        
                    }

                    //左切圆右侧最高三个点
                    var lr3 = q.Skip(num_top_3).Take(num_top_3).OrderByDescending(x => x.Pvalue).Take(3);
                    left_qy_back_xdg_right_top3_avg = lr3.Average(x => x.Pvalue);
                    foreach (var item in lr3)
                    {
                        left_qy_back_xdg_right_top3["" + item.Id] = item.Pvalue;
                    }

                    //右切圆左侧最高三个点
                    var rl3 = q.Skip(count / 2).Take(num_top_3).OrderByDescending(x => x.Pvalue).Take(3);
                    right_qy_back_xdg_left_top3_avg = rl3.Average(x => x.Pvalue);
                    foreach (var item in rl3)
                    {
                        right_qy_back_xdg_left_top3["" + item.Id] = item.Pvalue;
                    }

                    //右切圆右侧最高三个点
                    var rr3 = q.Skip(num_top_3 * 3).Take(num_top_3).OrderByDescending(x => x.Pvalue).Take(3);
                    right_qy_back_xdg_right_top3_avg = rr3.Average(x => x.Pvalue);
                    foreach (var item in rr3)
                    {
                        right_qy_back_xdg_right_top3["" + item.Id] = item.Pvalue;
                    }

                    
                }
                else
                {
                    int num_top = (count / 2 - 1) / 2 - 1;//取最高点的数量
                    int num_top_3 = num_top + 2;//取最高3点的数量

                    //左切圆左边最高点
                    var ll1 = q.Take(num_top).OrderByDescending(x => x.Pvalue).Take(1);
                    foreach (var item in ll1)
                    {
                        left_qy_back_xdg_left_top["" + item.Id] = item.Pvalue;
                        left_qy_back_xdg_left_top_value = item.Pvalue;
                    }

                    //左切圆右边最高点
                    var lr1 = q.Skip(num_top_3 + 1).Take(num_top).OrderByDescending(x => x.Pvalue).Take(1);
                    foreach (var item in lr1)
                    {
                        left_qy_back_xdg_right_top["" + item.Id] = item.Pvalue;
                        left_qy_back_xdg_right_top_value = item.Pvalue;
                    }

                    //右切圆左边最高点
                    var rl1 = q.Skip(count / 2).Take(num_top).OrderByDescending(x => x.Pvalue).Take(1);
                    foreach (var item in rl1)
                    {
                        right_qy_back_xdg_left_top["" + item.Id] = item.Pvalue;
                        right_qy_back_xdg_left_top_value = item.Pvalue;
                    }

                    //右切圆右边最高点
                    var rr1 = q.Skip(count / 2 + num_top_3 + 1).Take(num_top).OrderByDescending(x => x.Pvalue).Take(1);
                    foreach (var item in rr1)
                    {
                        right_qy_back_xdg_right_top["" + item.Id] = item.Pvalue;
                        right_qy_back_xdg_right_top_value = item.Pvalue;
                    }

                    //左切圆左侧最高三个点
                    var ll3 = q.Take(num_top_3).OrderByDescending(x => x.Pvalue).Take(3);
                    left_qy_back_xdg_left_top3_avg = ll3.Average(x => x.Pvalue);
                    foreach (var item in ll3)
                    {
                        left_qy_back_xdg_left_top3["" + item.Id] = item.Pvalue;
                    }

                    //左切圆右侧最高三个点
                    var lr3 = q.Skip(num_top_3 - 1).Take(num_top_3).OrderByDescending(x => x.Pvalue).Take(3);
                    left_qy_back_xdg_right_top3_avg = lr3.Average(x => x.Pvalue);
                    foreach (var item in lr3)
                    {
                        left_qy_back_xdg_right_top3["" + item.Id] = item.Pvalue;
                    }

                    //右切圆左侧最高三个点
                    var rl3 = q.Skip(count / 2).Take(num_top_3).OrderByDescending(x => x.Pvalue).Take(3);
                    foreach (var item in rl3)
                    {
                        right_qy_back_xdg_left_top3["" + item.Id] = item.Pvalue;
                        right_qy_back_xdg_left_top3_avg = rl3.Average(x => x.Pvalue);
                    }

                    //右切圆右侧最高三个点
                    var rr3 = q.Skip(count / 2 + num_top_3 - 1).Take(num_top_3).OrderByDescending(x => x.Pvalue).Take(3);
                    foreach (var item in rr3)
                    {
                        right_qy_back_xdg_right_top3["" + item.Id] = item.Pvalue;
                        right_qy_back_xdg_right_top3_avg = rr3.Average(x => x.Pvalue);
                    }                   
                 
                }
               
            }
            else
            {
                if ((count + 1) % 4 == 0)
                {
                    count = count + 1;
                    int num_top = count / 4 - 1;//取最高点的数量
                    int num_top_3 = count / 4;//取最高3点的数量

                    //左切圆左边最高点
                    var ll1 = q.Take(num_top).OrderByDescending(x => x.Pvalue).Take(1);
                    foreach (var item in ll1)
                    {
                        left_qy_back_xdg_left_top["" + item.Id] = item.Pvalue;
                        left_qy_back_xdg_left_top_value = item.Pvalue;
                    }

                    //左切圆右边最高点
                    var lr1 = q.Skip(num_top_3 + 1).Take(num_top).OrderByDescending(x => x.Pvalue).Take(1);
                    foreach (var item in lr1)
                    {
                        left_qy_back_xdg_right_top["" + item.Id] = item.Pvalue;
                        left_qy_back_xdg_right_top_value = item.Pvalue;
                    }

                    //右切圆左边最高点
                    var rl1 = q.Skip(count / 2 - 1).Take(num_top).OrderByDescending(x => x.Pvalue).Take(1);
                    foreach (var item in rl1)
                    {
                        right_qy_back_xdg_left_top["" + item.Id] = item.Pvalue;
                        right_qy_back_xdg_left_top_value = item.Pvalue;
                    }

                    //右切圆右边最高点
                    var rr1 = q.Skip(count / 2 + num_top_3).Take(num_top).OrderByDescending(x => x.Pvalue).Take(1);
                    foreach (var item in rr1)
                    {
                        right_qy_back_xdg_right_top["" + item.Id] = item.Pvalue;
                        right_qy_back_xdg_right_top_value = item.Pvalue;
                    }

                    //左切圆左侧最高三个点
                    var ll3 = q.Take(num_top_3).OrderByDescending(x => x.Pvalue).Take(3);
                    left_qy_back_xdg_left_top3_avg = ll3.Average(x => x.Pvalue);
                    foreach (var item in ll3)
                    {
                        left_qy_back_xdg_left_top3["" + item.Id] = item.Pvalue;
                    }

                    //左切圆右侧最高三个点
                    var lr3 = q.Skip(num_top_3).Take(num_top_3).OrderByDescending(x => x.Pvalue).Take(3);
                    left_qy_back_xdg_right_top3_avg = lr3.Average(x => x.Pvalue);
                    foreach (var item in lr3)
                    {
                        left_qy_back_xdg_right_top3["" + item.Id] = item.Pvalue;
                    }

                    //右切圆左侧最高三个点
                    var rl3 = q.Skip(count / 2 - 1).Take(num_top_3).OrderByDescending(x => x.Pvalue).Take(3);
                    right_qy_back_xdg_left_top3_avg = rl3.Average(x => x.Pvalue);
                    foreach (var item in rl3)
                    {
                        right_qy_back_xdg_left_top3["" + item.Id] = item.Pvalue;
                    }

                    //右切圆右侧最高三个点
                    var rr3 = q.Skip(count / 2 + num_top_3 - 1).Take(num_top_3).OrderByDescending(x => x.Pvalue).Take(3);
                    right_qy_back_xdg_right_top3_avg = rr3.Average(x => x.Pvalue);
                    foreach (var item in rr3)
                    {
                        right_qy_back_xdg_right_top3["" + item.Id] = item.Pvalue;
                    }


                }
                else
                {
                    count = count + 1;
                    int num_top = (count / 2 - 1) / 2 - 1;//取最高点的数量
                    int num_top_3 = num_top + 2;//取最高3点的数量

                    //左切圆左边最高点
                    var ll1 = q.Take(num_top).OrderByDescending(x => x.Pvalue).Take(1);
                    foreach (var item in ll1)
                    {
                        left_qy_back_xdg_left_top["" + item.Id] = item.Pvalue;
                        left_qy_back_xdg_left_top_value = item.Pvalue;
                    }

                    //左切圆右边最高点
                    var lr1 = q.Skip(num_top_3 + 1).Take(num_top).OrderByDescending(x => x.Pvalue).Take(1);
                    foreach (var item in lr1)
                    {
                        left_qy_back_xdg_right_top["" + item.Id] = item.Pvalue;
                        left_qy_back_xdg_right_top_value = item.Pvalue;
                    }

                    //右切圆左边最高点
                    var rl1 = q.Skip(count / 2 - 1).Take(num_top).OrderByDescending(x => x.Pvalue).Take(1);
                    foreach (var item in rl1)
                    {
                        right_qy_back_xdg_left_top["" + item.Id] = item.Pvalue;
                        right_qy_back_xdg_left_top_value = item.Pvalue;
                    }

                    //右切圆右边最高点
                    var rr1 = q.Skip(count / 2 + num_top_3).Take(num_top).OrderByDescending(x => x.Pvalue).Take(1);
                    foreach (var item in rr1)
                    {
                        right_qy_back_xdg_right_top["" + item.Id] = item.Pvalue;
                        right_qy_back_xdg_right_top_value = item.Pvalue;
                    }

                    //左切圆左侧最高三个点
                    var ll3 = q.Take(num_top_3).OrderByDescending(x => x.Pvalue).Take(3);
                    left_qy_back_xdg_left_top3_avg = ll3.Average(x => x.Pvalue);
                    foreach (var item in ll3)
                    {
                        left_qy_back_xdg_left_top3["" + item.Id] = item.Pvalue;
                    }

                    //左切圆右侧最高三个点
                    var lr3 = q.Skip(num_top_3 - 1).Take(num_top_3).OrderByDescending(x => x.Pvalue).Take(3);
                    left_qy_back_xdg_right_top3_avg = lr3.Average(x => x.Pvalue);
                    foreach (var item in lr3)
                    {
                        left_qy_back_xdg_right_top3["" + item.Id] = item.Pvalue;
                    }

                    //右切圆左侧最高三个点
                    var rl3 = q.Skip(count / 2 - 1).Take(num_top_3).OrderByDescending(x => x.Pvalue).Take(3);
                    right_qy_back_xdg_left_top3_avg = rl3.Average(x => x.Pvalue);
                    foreach (var item in rl3)
                    {
                        right_qy_back_xdg_left_top3["" + item.Id] = item.Pvalue;
                    }

                    //右切圆右侧最高三个点
                    var rr3 = q.Skip(count / 2 + num_top).Take(num_top_3).OrderByDescending(x => x.Pvalue).Take(3);
                    right_qy_back_xdg_right_top3_avg = rr3.Average(x => x.Pvalue);
                    foreach (var item in rr3)
                    {
                        right_qy_back_xdg_right_top3["" + item.Id] = item.Pvalue;
                    }

                }

              
            }

            rd.left_qy_back_xdg_left_top = left_qy_back_xdg_left_top;
            rd.left_qy_back_xdg_right_top = left_qy_back_xdg_right_top;
            rd.right_qy_back_xdg_left_top = right_qy_back_xdg_left_top;
            rd.right_qy_back_xdg_right_top = right_qy_back_xdg_right_top;
            rd.left_qy_back_xdg_left_top_value = left_qy_back_xdg_left_top_value;
            rd.left_qy_back_xdg_right_top_value = left_qy_back_xdg_right_top_value;
            rd.right_qy_back_xdg_left_top_value = right_qy_back_xdg_left_top_value;
            rd.right_qy_back_xdg_right_top_value = right_qy_back_xdg_right_top_value;
            rd.left_qy_back_xdg_left_top3 = left_qy_back_xdg_left_top3;
            rd.left_qy_back_xdg_right_top3 = left_qy_back_xdg_right_top3;
            rd.right_qy_back_xdg_left_top3 = right_qy_back_xdg_left_top3;
            rd.right_qy_back_xdg_right_top3 = right_qy_back_xdg_right_top3;
            rd.left_qy_back_xdg_left_top3_avg = left_qy_back_xdg_left_top3_avg;
            rd.left_qy_back_xdg_right_top3_avg = left_qy_back_xdg_right_top3_avg;
            rd.right_qy_back_xdg_left_top3_avg = right_qy_back_xdg_left_top3_avg;
            rd.right_qy_back_xdg_right_top3_avg = right_qy_back_xdg_right_top3_avg;

            return rd;

        }



      

    }
}
