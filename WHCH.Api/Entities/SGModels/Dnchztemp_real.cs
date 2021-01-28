using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WHCH.Api.Entities.Enums.CommonEnum;

namespace WHCH.Api.Entities
{
	[Serializable]
	public class Dnchztemp_real
	{
    
    
    
        /// <summary>
    	/// 序号
    	/// </summary>
        [Key,Required]
   
        public System.Int64 Id { get; set; } 
        
    
        /// <summary>
    	/// 当前时间
    	/// </summary>
        
   
        public DateTime? RealTime { get; set; } 
        
    
        /// <summary>
    	/// 低温过热器焓增A
    	/// </summary>
        
   
        public System.Double Dg_hz_a { get; set; } 
        
    
        /// <summary>
    	/// 低温过热器焓增B
    	/// </summary>
        
   
        public System.Double Dg_hz_b { get; set; } 
        
    
        /// <summary>
    	/// 低温过热器焓增C
    	/// </summary>
        
   
        public System.Double Dg_hz_c { get; set; } 
        
    
        /// <summary>
    	/// 低温过热器焓增D
    	/// </summary>
        
   
        public System.Double Dg_hz_d { get; set; } 
        
    
        /// <summary>
    	/// 分隔屏焓增A
    	/// </summary>
        
   
        public System.Double Fgp_hz_a { get; set; } 
        
    
        /// <summary>
    	/// 分隔屏焓增B
    	/// </summary>
        
   
        public System.Double Fgp_hz_b { get; set; } 
        
    
        /// <summary>
    	/// 分隔屏焓增C
    	/// </summary>
        
   
        public System.Double Fgp_hz_c { get; set; } 
        
    
        /// <summary>
    	/// 分隔屏焓增D
    	/// </summary>
        
   
        public System.Double Fgp_hz_d { get; set; } 
        
    
        /// <summary>
    	/// 后屏焓增A
    	/// </summary>
        
   
        public System.Double Hp_hz_a { get; set; } 
        
    
        /// <summary>
    	/// 后屏焓增B
    	/// </summary>
        
   
        public System.Double Hp_hz_b { get; set; } 
        
    
        /// <summary>
    	/// 后屏焓增C
    	/// </summary>
        
   
        public System.Double Hp_hz_c { get; set; } 
        
    
        /// <summary>
    	/// 后屏焓增D
    	/// </summary>
        
   
        public System.Double Hp_hz_d { get; set; } 
        
    
        /// <summary>
    	/// 末级过热器焓增A
    	/// </summary>
        
   
        public System.Double Mg_hz_a { get; set; } 
        
    
        /// <summary>
    	/// 末级过热器焓增B
    	/// </summary>
        
   
        public System.Double Mg_hz_b { get; set; } 
        
    
        /// <summary>
    	/// 末级过热器焓增C
    	/// </summary>
        
   
        public System.Double Mg_hz_c { get; set; } 
        
    
        /// <summary>
    	/// 末级过热器焓增D
    	/// </summary>
        
   
        public System.Double Mg_hz_d { get; set; } 
        
    
        /// <summary>
    	/// 低温再热器焓增左侧
    	/// </summary>
        
   
        public System.Double Dz_hz_left { get; set; } 
        
    
        /// <summary>
    	/// 低温再热器焓增右侧
    	/// </summary>
        
   
        public System.Double Dz_hz_right { get; set; } 
        
    
        /// <summary>
    	/// 高温再热器焓增左侧
    	/// </summary>
        
   
        public System.Double Gz_hz_left { get; set; } 
        
    
        /// <summary>
    	/// 高温再热器焓增右侧
    	/// </summary>
        
   
        public System.Double Gz_hz_right { get; set; } 
        
    
        /// <summary>
    	/// 低温过热器左侧出口温度
    	/// </summary>
        
   
        public System.Double Dg_temp_out_left { get; set; } 
        
    
        /// <summary>
    	/// 低温过热器右侧出口温度
    	/// </summary>
        
   
        public System.Double Dg_temp_out_right { get; set; } 
        
    
        /// <summary>
    	/// 分隔屏左出口温度
    	/// </summary>
        
   
        public System.Double Fgp_temp_out_left { get; set; } 
        
    
        /// <summary>
    	/// 分隔屏右出口温度
    	/// </summary>
        
   
        public System.Double Fgp_temp_out_right { get; set; } 
        
    
        /// <summary>
    	/// 后屏左出口温度
    	/// </summary>
        
   
        public System.Double Hp_temp_out_left { get; set; } 
        
    
        /// <summary>
    	/// 后屏右出口温度
    	/// </summary>
        
   
        public System.Double Hp_temp_out_right { get; set; } 
        
    
        /// <summary>
    	/// 高过左出口温度
    	/// </summary>
        
   
        public System.Double Mg_temp_out_left { get; set; } 
        
    
        /// <summary>
    	/// 高过右出口温度
    	/// </summary>
        
   
        public System.Double Mg_temp_out_right { get; set; } 
        
    
        /// <summary>
    	/// 低再左出口温度
    	/// </summary>
        
   
        public System.Double Dz_temp_out_left { get; set; } 
        
    
        /// <summary>
    	/// 低再右出口温度
    	/// </summary>
        
   
        public System.Double Dz_temp_out_right { get; set; } 
        
    
        /// <summary>
    	/// 高再左出口温度
    	/// </summary>
        
   
        public System.Double Gz_temp_out_left { get; set; } 
        
    
        /// <summary>
    	/// 高再右出口温度
    	/// </summary>
        
   
        public System.Double Gz_temp_out_right { get; set; } 
        
    
        /// <summary>
    	/// nox测点平均值
    	/// </summary>
        
   
        public System.Double Nox_avg { get; set; } 
        
    
        /// <summary>
    	/// NOx偏高值
    	/// </summary>
        
   
        public System.Double Nox_high { get; set; } 
        
    
        /// <summary>
    	/// O2氧量偏低值
    	/// </summary>
        
   
        public System.Double Nox_low { get; set; } 
        
    
        /// <summary>
    	/// O2测点平均值
    	/// </summary>
        
   
        public System.Double O2_avg { get; set; } 
        
    
        /// <summary>
    	/// O2氧量偏高值
    	/// </summary>
        
   
        public System.Double O2_high { get; set; } 
        
    
        /// <summary>
    	/// O2氧量偏低值
    	/// </summary>
        
   
        public System.Double O2_low { get; set; } 
        
    
        /// <summary>
    	/// 机组实时负荷
    	/// </summary>
        
   
        public System.Double Yl_fh_out { get; set; } 
        
    
        /// <summary>
    	/// 抽汽量
    	/// </summary>
        
   
        public System.Double Cql { get; set; } 
        
    
        /// <summary>
    	/// 再热器减温水对煤耗影响
    	/// </summary>
        
   
        public System.Double Dz_jws_mh { get; set; } 
        
    
        /// <summary>
    	/// 再热器出口蒸汽温度对煤耗影响
    	/// </summary>
        
   
        public System.Double Gz_temp_mh { get; set; } 
        
    
        /// <summary>
    	/// 过热器出口蒸汽温度对煤耗影响
    	/// </summary>
        
   
        public System.Double Mg_temp_mh { get; set; } 
        
    
        /// <summary>
    	/// 低温过热器沾污程度
    	/// </summary>
        
   
        public System.Double Dg_zwxs { get; set; } 
        
    
        /// <summary>
    	/// 分隔屏粘污系数
    	/// </summary>
        
   
        public System.Double Fgp_zwxs { get; set; } 
        
    
        /// <summary>
    	/// 后屏粘污系数
    	/// </summary>
        
   
        public System.Double Hp_zwxs { get; set; } 
        
    
        /// <summary>
    	/// 高过粘污系数
    	/// </summary>
        
   
        public System.Double Mg_zwxs { get; set; } 
        
    
        /// <summary>
    	/// 低再粘污系数
    	/// </summary>
        
   
        public System.Double Dz_zwxs { get; set; } 
        
    
        /// <summary>
    	/// 高再粘污系数
    	/// </summary>
        
   
        public System.Double Gz_zwxs { get; set; } 
        
    
        /// <summary>
    	/// 过热器一级减温水量A
    	/// </summary>
        
   
        public System.Double Grq_jws_1a { get; set; } 
        
    
        /// <summary>
    	/// 过热器一级减温水量B
    	/// </summary>
        
   
        public System.Double Grq_jws_1b { get; set; } 
        
    
        /// <summary>
    	/// 过热器一级减温水量C
    	/// </summary>
        
   
        public System.Double Grq_jws_1c { get; set; } 
        
    
        /// <summary>
    	/// 过热器一级减温水量D
    	/// </summary>
        
   
        public System.Double Grq_jws_1d { get; set; } 
        
    
        /// <summary>
    	/// 过热器二级减温水量A
    	/// </summary>
        
   
        public System.Double Grq_jws_2a { get; set; } 
        
    
        /// <summary>
    	/// 过热器二级减温水量B
    	/// </summary>
        
   
        public System.Double Grq_jws_2b { get; set; } 
        
    
        /// <summary>
    	/// 过热器二级减温水量C
    	/// </summary>
        
   
        public System.Double Grq_jws_2c { get; set; } 
        
    
        /// <summary>
    	/// 过热器二级减温水量D
    	/// </summary>
        
   
        public System.Double Grq_jws_2d { get; set; } 
        
    
        /// <summary>
    	/// 过热器三级减温水量A
    	/// </summary>
        
   
        public System.Double Grq_jws_3a { get; set; } 
        
    
        /// <summary>
    	/// 过热器三级减温水量B
    	/// </summary>
        
   
        public System.Double Grq_jws_3b { get; set; } 
        
    
        /// <summary>
    	/// 过热器三级减温水量C
    	/// </summary>
        
   
        public System.Double Grq_jws_3c { get; set; } 
        
    
        /// <summary>
    	/// 过热器三级减温水量D
    	/// </summary>
        
   
        public System.Double Grq_jws_3d { get; set; } 
        
    
        /// <summary>
    	/// 
    	/// </summary>
        
    	public Dncboiler DncBoiler { get; set; } 
        public System.Int32 DncBoilerId { get; set; } 
    
        /// <summary>
    	/// 
    	/// </summary>
        
   
        public System.String DncBoiler_Name { get; set; } 
        
	
        /// <summary>
        /// 是否可用(0:禁用,1:可用)
        /// </summary>
        public Status Status { get; set; }
        /// <summary>
        /// 是否已删
        /// </summary>
        public IsDeleted IsDeleted { get; set; }

        /// <summary>
        /// 低再侧烟气挡板开度
        /// </summary>
        public System.Double dz_yqdb_kd { get; set; }


    }
}
