using LitJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace znrsserver
{
    public class Returndata
    {
        public JsonData left_qy_back_xdg_left_top {get;set;}

        public JsonData left_qy_back_xdg_right_top { get; set; }

        public JsonData right_qy_back_xdg_left_top { get; set; }

        public JsonData right_qy_back_xdg_right_top { get; set; }

        public JsonData left_qy_back_xdg_left_top3 { get; set; }

        public JsonData left_qy_back_xdg_right_top3 { get; set; }

        public JsonData right_qy_back_xdg_left_top3 { get; set; }

        public JsonData right_qy_back_xdg_right_top3 { get; set; }
      

        public double left_qy_back_xdg_left_top_value { get;set;}

        public double left_qy_back_xdg_right_top_value { get; set; }

        public double right_qy_back_xdg_left_top_value { get; set; }

        public double right_qy_back_xdg_right_top_value { get; set; }

        public double left_qy_back_xdg_left_top3_avg { get; set; }

        public double left_qy_back_xdg_right_top3_avg { get; set; }

        public double right_qy_back_xdg_left_top3_avg { get; set; }

        public double right_qy_back_xdg_right_top3_avg { get; set; }
    }
}
