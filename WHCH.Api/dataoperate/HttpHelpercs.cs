using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace SynWHCH
{
    public class HttpHelpercs
    {
        public static string HttpGet(string url)
        {
            string result = "";
            try
            {
                HttpWebRequest wbRequest = (HttpWebRequest)WebRequest.Create(url);
                wbRequest.Method = "GET";
                wbRequest.ContentType = "application/json";//链接类型
                HttpWebResponse wbResponse = (HttpWebResponse)wbRequest.GetResponse();
                using (Stream responseStream = wbResponse.GetResponseStream())
                {
                    using (StreamReader sReader = new StreamReader(responseStream, System.Text.Encoding.Default))
                    {
                        result = sReader.ReadToEnd();
                    }
                }





                
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }


        public static string HttpGet(string url, System.Text.Encoding dd)
        {
            string result = "";
            try
            {
                HttpWebRequest wbRequest = (HttpWebRequest)WebRequest.Create(url);
                wbRequest.Method = "GET";
                wbRequest.ContentType = "application/x-www-form-urlencoded";//链接类型
                HttpWebResponse wbResponse = (HttpWebResponse)wbRequest.GetResponse();
                using (Stream responseStream = wbResponse.GetResponseStream())
                {
                    using (StreamReader sReader = new StreamReader(responseStream, dd))
                    {
                        result = sReader.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }



        public static string HttpPost(string postUrl, JObject param,string signature)
        {
            string ret = "";
            try
            {

                
                param.Add("signature", signature);


                //byte[] byteArray = Encoding.UTF8.GetBytes(paramData); //转化
                HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(new Uri(postUrl));
                webReq.Method = "POST";
                webReq.ContentType = "application/json";
                byte[] btBodys = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(param));
                webReq.ContentLength = btBodys.Length;
                //webReq.ContentLength = byteArray.Length;
                Stream newStream = webReq.GetRequestStream();
                newStream.Write(btBodys, 0, btBodys.Length);//写入参数
                newStream.Close();
                using (HttpWebResponse response = (HttpWebResponse)webReq.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        using (StreamReader sReader = new StreamReader(responseStream, System.Text.Encoding.UTF8))
                        {
                            ret = sReader.ReadToEnd();
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                ret = ex.Message;
            }
            return ret;
        }


    }
}
