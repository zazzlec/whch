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

namespace Whapp
{
    public partial class Form1 : Form
    {
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

        public static void Hzpoint(int boilerid)
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
        private void button1_Click(object sender, EventArgs e)
        {
            Hzpoint(1);
        }
    }
}
