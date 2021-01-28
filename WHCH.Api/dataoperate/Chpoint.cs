using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WHCH.Api.dataoperate
{
    public class Chpoint
    {
        /// <summary>
        /// 吹灰器序号
        /// </summary>
        public System.Int32 Id { get; set; }

        /// <summary>
        /// 吹灰器描述
        /// </summary>


        public System.String Name_kw { get; set; }



        /// <summary>
        /// 锅炉ID
        /// </summary>

       
        public System.Int32 DncBoilerId { get; set; }

        /// <summary>
        /// 锅炉名称
        /// </summary>


        public System.String DncBoiler_Name { get; set; }


        /// <summary>
        /// 水冷壁的层级
        /// </summary>


        public System.Int32 Slb_floor_Val { get; set; }

        /// <summary>
        /// 上次吹灰列表清空时差值
        /// </summary>


        public System.Double Last_temp_dif_Val { get; set; }


        /// <summary>
        /// 当前温度差值
        /// </summary>


        public System.Double Now_temp_dif_Val { get; set; }

        /// <summary>
        /// 差值降低量
        /// </summary>


        public System.Double Last_now_dif { get; set; }
    }
}
