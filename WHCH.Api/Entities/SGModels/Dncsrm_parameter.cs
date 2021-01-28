using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WHCH.Api.Entities.Enums.CommonEnum;

namespace WHCH.Api.Entities
{
	[Serializable]
	public class Dncsrm_parameter
	{
    
    
    
        /// <summary>
    	/// 编号
    	/// </summary>
        [Key,Required]
   
        public System.Int32 Id { get; set; } 
        
    
        /// <summary>
    	/// 再热蒸汽设计流量
    	/// </summary>
        
   
        public System.Double Zrqll_design { get; set; } 
        
    
        /// <summary>
    	/// 焓增计算公式参数1
    	/// </summary>
        
   
        public System.Double Hz_a1 { get; set; } 
        
    
        /// <summary>
    	/// 焓增计算公式参数2
    	/// </summary>
        
   
        public System.Double Hz_a2 { get; set; } 
        
    
        /// <summary>
    	/// 焓增计算公式参数3
    	/// </summary>
        
   
        public System.Double Hz_a3 { get; set; } 
        
    
        /// <summary>
    	/// 焓增计算公式参数4
    	/// </summary>
        
   
        public System.Double Hz_a4 { get; set; } 
        
    
        /// <summary>
    	/// 焓增计算公式参数5
    	/// </summary>
        
   
        public System.Double Hz_a5 { get; set; } 
        
    
        /// <summary>
    	/// 焓增计算公式参数6
    	/// </summary>
        
   
        public System.Double Hz_a6 { get; set; } 
        
    
        /// <summary>
    	/// 焓增计算公式参数7
    	/// </summary>
        
   
        public System.Double Hz_a7 { get; set; } 
        
    
        /// <summary>
    	/// 焓增计算公式参数8
    	/// </summary>
        
   
        public System.Double Hz_a8 { get; set; } 
        
    
        /// <summary>
    	/// 再热器减温水量对煤耗影响系数
    	/// </summary>
        
   
        public System.Double Zrq_jws_mh_xs { get; set; } 
        
    
        /// <summary>
    	/// 高温再热器出口温度额定值
    	/// </summary>
        
   
        public System.Double Gz_out_temp_ed { get; set; } 
        
    
        /// <summary>
    	/// 高温再热器出口温度上限值
    	/// </summary>
        
   
        public System.Double Gz_out_temp_high { get; set; } 
        
    
        /// <summary>
    	/// 高温再热器出口温度下限值
    	/// </summary>
        
   
        public System.Double Gz_out_temp_low { get; set; } 
        
    
        /// <summary>
    	/// 高温再热器出口温度对煤耗影响系数
    	/// </summary>
        
   
        public System.Double Gz_out_temp_mh_xs { get; set; } 
        
    
        /// <summary>
    	/// 末级过热器出口温度额定值
    	/// </summary>
        
   
        public System.Double Mg_out_temp_ed { get; set; } 
        
    
        /// <summary>
    	/// 末级过热器出口温度上限值
    	/// </summary>
        
   
        public System.Double Mg_out_temp_high { get; set; } 
        
    
        /// <summary>
    	/// 末级过热器出口温度下限值
    	/// </summary>
        
   
        public System.Double Mg_out_temp_low { get; set; } 
        
    
        /// <summary>
    	/// 末级过热器出口温度对煤耗影响系数
    	/// </summary>
        
   
        public System.Double Mg_out_temp_mh_xs { get; set; } 
        
    
        /// <summary>
    	/// 负荷区间
    	/// </summary>
        
   
        public System.String Fh_zone { get; set; } 
        
    
        /// <summary>
    	/// 氧量上限区间
    	/// </summary>
        
   
        public System.String O2_high_zone { get; set; } 
        
    
        /// <summary>
    	/// 氧量下限区间
    	/// </summary>
        
   
        public System.String O2_low_zone { get; set; } 
        
    
        /// <summary>
    	/// Nox上限区间
    	/// </summary>
        
   
        public System.String Nox_high_zone { get; set; } 
        
    
        /// <summary>
    	/// Nox下限区间
    	/// </summary>
        
   
        public System.String Nox_low_zone { get; set; } 
        
    
        /// <summary>
    	/// 沾污系数计算负荷区间
    	/// </summary>
        
   
        public System.String Zwxs_fh_zone { get; set; } 
        
    
        /// <summary>
    	/// 分隔屏设计焓增参考值区间
    	/// </summary>
        
   
        public System.String Fgp_design_hz_zone { get; set; } 
        
    
        /// <summary>
    	/// 分隔屏设计沾污系数
    	/// </summary>
        
   
        public System.Double Fgp_design_zwxs { get; set; } 
        
    
        /// <summary>
    	/// 分隔屏沾污系数上限
    	/// </summary>
        
   
        public System.Double Fgp_zwxs_high { get; set; } 
        
    
        /// <summary>
    	/// 分隔屏沾污系数下限
    	/// </summary>
        
   
        public System.Double Fgp_zwxs_low { get; set; } 
        
    
        /// <summary>
    	/// 后屏设计焓增参考值区间
    	/// </summary>
        
   
        public System.String Hp_design_hz_zone { get; set; } 
        
    
        /// <summary>
    	/// 后屏设计沾污系数
    	/// </summary>
        
   
        public System.Double Hp_design_zwxs { get; set; } 
        
    
        /// <summary>
    	/// 后屏沾污系数上限
    	/// </summary>
        
   
        public System.Double Hp_zwxs_high { get; set; } 
        
    
        /// <summary>
    	/// 后屏沾污系数下限
    	/// </summary>
        
   
        public System.Double Hp_zwxs_low { get; set; } 
        
    
        /// <summary>
    	/// 末级过热器设计焓增参考值区间
    	/// </summary>
        
   
        public System.String Mg_design_hz_zone { get; set; } 
        
    
        /// <summary>
    	/// 末级过热器设计沾污系数
    	/// </summary>
        
   
        public System.Double Mg_design_zwxs { get; set; } 
        
    
        /// <summary>
    	/// 末级过热器沾污系数上限
    	/// </summary>
        
   
        public System.Double Mg_zwxs_high { get; set; } 
        
    
        /// <summary>
    	/// 末级过热器沾污系数下限
    	/// </summary>
        
   
        public System.Double Mg_zwxs_low { get; set; } 
        
    
        /// <summary>
    	/// 低温再热器设计焓增参考值区间
    	/// </summary>
        
   
        public System.String Dz_design_hz_zone { get; set; } 
        
    
        /// <summary>
    	/// 低温再热器设计沾污系数
    	/// </summary>
        
   
        public System.Double Dz_design_zwxs { get; set; } 
        
    
        /// <summary>
    	/// 低温再热器沾污系数上限
    	/// </summary>
        
   
        public System.Double Dz_zwxs_high { get; set; } 
        
    
        /// <summary>
    	/// 低温再热器沾污系数下限
    	/// </summary>
        
   
        public System.Double Dz_zwxs_low { get; set; } 
        
    
        /// <summary>
    	/// 高温再热器设计焓增参考值区间
    	/// </summary>
        
   
        public System.String Gz_design_hz_zone { get; set; } 
        
    
        /// <summary>
    	/// 高温再热器设计沾污系数
    	/// </summary>
        
   
        public System.Double Gz_design_zwxs { get; set; } 
        
    
        /// <summary>
    	/// 高温再热器沾污系数上限
    	/// </summary>
        
   
        public System.Double Gz_zwxs_high { get; set; } 
        
    
        /// <summary>
    	/// 高温再热器沾污系数下限
    	/// </summary>
        
   
        public System.Double Gz_zwxs_low { get; set; } 
        
    
        /// <summary>
    	/// 低温过热器设计焓值参考值
    	/// </summary>
        
   
        public System.String Dg_design_hz_zone { get; set; } 
        
    
        /// <summary>
    	/// 低温过热器设计沾污系数
    	/// </summary>
        
   
        public System.Double Dg_design_zwxs { get; set; } 
        
    
        /// <summary>
    	/// 低温过热器沾污系数上限
    	/// </summary>
        
   
        public System.Double Dg_zwxs_high { get; set; } 
        
    
        /// <summary>
    	/// 低温过热器沾污系数下限
    	/// </summary>
        
   
        public System.Double Dg_zwxs_low { get; set; } 
        
    
        /// <summary>
    	/// AGP风量基础工况占比(%)
    	/// </summary>
        
   
        public System.Double Agp_basic_percent { get; set; } 
        
    
        /// <summary>
    	/// 一级过热器减温水量设计值
    	/// </summary>
        
   
        public System.String Grq_jws_design_1 { get; set; } 
        
    
        /// <summary>
    	/// 二级过热器减温水量设计值
    	/// </summary>
        
   
        public System.String Grq_jws_design_2 { get; set; } 
        
    
        /// <summary>
    	/// 三级过热器减温水量设计值
    	/// </summary>
        
   
        public System.String Grq_jws_design_3 { get; set; } 
        
    
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
		
	}
}
