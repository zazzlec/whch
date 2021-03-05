using LitJson;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;


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

       





      

    }
}
