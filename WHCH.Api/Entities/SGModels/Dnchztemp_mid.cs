using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WHCH.Api.Entities.Enums.CommonEnum;

namespace WHCH.Api.Entities
{
	[Serializable]
	public class Dnchztemp_mid
	{
    
    
    
        /// <summary>
    	/// 序号
    	/// </summary>
        [Key,Required]
   
        public System.Int64 Id { get; set; } 
        
    
        /// <summary>
    	/// 实际时间
    	/// </summary>
        
   
        public DateTime? RealTime { get; set; } 
        
    
        /// <summary>
    	/// 分离器压力平均值
    	/// </summary>
        
   
        public System.Double Flq_press_avg { get; set; } 
        
    
        /// <summary>
    	/// 分离器温度平均值
    	/// </summary>
        
   
        public System.Double Flq_temp_avg { get; set; } 
        
    
        /// <summary>
    	/// 末级过热器出口压力A
    	/// </summary>
        
   
        public System.Double Mg_press_out_a { get; set; } 
        
    
        /// <summary>
    	/// 末级过热器出口压力B
    	/// </summary>
        
   
        public System.Double Mg_press_out_b { get; set; } 
        
    
        /// <summary>
    	/// 末级过热器出口压力B
    	/// </summary>
        
   
        public System.Double Mg_press_out_c { get; set; } 
        
    
        /// <summary>
    	/// 末级过热器出口压力D
    	/// </summary>
        
   
        public System.Double Mg_press_out_d { get; set; } 
        
    
        /// <summary>
    	/// 末级过热器出口压力左侧平均值
    	/// </summary>
        
   
        public System.Double Mg_press_out_left_avg { get; set; } 
        
    
        /// <summary>
    	/// 末级过热器出口压力右侧平均值
    	/// </summary>
        
   
        public System.Double Mg_press_out_right_avg { get; set; } 
        
    
        /// <summary>
    	/// 低温过热器出口压力A
    	/// </summary>
        
   
        public System.Double Dg_press_out_a { get; set; } 
        
    
        /// <summary>
    	/// 低温过热器出口压力B
    	/// </summary>
        
   
        public System.Double Dg_press_out_b { get; set; } 
        
    
        /// <summary>
    	/// 低温过热器出口压力C
    	/// </summary>
        
   
        public System.Double Dg_press_out_c { get; set; } 
        
    
        /// <summary>
    	/// 低温过热器出口压力D
    	/// </summary>
        
   
        public System.Double Dg_press_out_d { get; set; } 
        
    
        /// <summary>
    	/// 低温过热器出口温度A
    	/// </summary>
        
   
        public System.Double Dg_temp_out_a { get; set; } 
        
    
        /// <summary>
    	/// 低温过热器出口温度B
    	/// </summary>
        
   
        public System.Double Dg_temp_out_b { get; set; } 
        
    
        /// <summary>
    	/// 低温过热器出口温度C
    	/// </summary>
        
   
        public System.Double Dg_temp_out_c { get; set; } 
        
    
        /// <summary>
    	/// 低温过热器出口温度D
    	/// </summary>
        
   
        public System.Double Dg_temp_out_d { get; set; } 
        
    
        /// <summary>
    	/// 低温过热器出口焓值A
    	/// </summary>
        
   
        public System.Double Dg_out_hz_a { get; set; } 
        
    
        /// <summary>
    	/// 低温过热器出口焓值B
    	/// </summary>
        
   
        public System.Double Dg_out_hz_b { get; set; } 
        
    
        /// <summary>
    	/// 低温过热器出口焓值C
    	/// </summary>
        
   
        public System.Double Dg_out_hz_c { get; set; } 
        
    
        /// <summary>
    	/// 低温过热器出口焓值D
    	/// </summary>
        
   
        public System.Double Dg_out_hz_d { get; set; } 
        
    
        /// <summary>
    	/// 低温过热器进口压力A
    	/// </summary>
        
   
        public System.Double Dg_press_in_a { get; set; } 
        
    
        /// <summary>
    	/// 低温过热器进口压力B
    	/// </summary>
        
   
        public System.Double Dg_press_in_b { get; set; } 
        
    
        /// <summary>
    	/// 低温过热器进口压力C
    	/// </summary>
        
   
        public System.Double Dg_press_in_c { get; set; } 
        
    
        /// <summary>
    	/// 低温过热器进口压力D
    	/// </summary>
        
   
        public System.Double Dg_press_in_d { get; set; } 
        
    
        /// <summary>
    	/// 低温过热器进口温度A
    	/// </summary>
        
   
        public System.Double Dg_temp_in_a { get; set; } 
        
    
        /// <summary>
    	/// 低温过热器进口温度B
    	/// </summary>
        
   
        public System.Double Dg_temp_in_b { get; set; } 
        
    
        /// <summary>
    	/// 低温过热器进口温度C
    	/// </summary>
        
   
        public System.Double Dg_temp_in_c { get; set; } 
        
    
        /// <summary>
    	/// 低温过热器进口温度D
    	/// </summary>
        
   
        public System.Double Dg_temp_in_d { get; set; } 
        
    
        /// <summary>
    	/// 低温过热器进口焓值A
    	/// </summary>
        
   
        public System.Double Dg_in_hz_a { get; set; } 
        
    
        /// <summary>
    	/// 低温过热器进口焓值B
    	/// </summary>
        
   
        public System.Double Dg_in_hz_b { get; set; } 
        
    
        /// <summary>
    	/// 低温过热器进口焓值C
    	/// </summary>
        
   
        public System.Double Dg_in_hz_c { get; set; } 
        
    
        /// <summary>
    	/// 低温过热器进口焓值D
    	/// </summary>
        
   
        public System.Double Dg_in_hz_d { get; set; } 
        
    
        /// <summary>
    	/// 分隔屏出口压力A
    	/// </summary>
        
   
        public System.Double Fgp_press_out_a { get; set; } 
        
    
        /// <summary>
    	/// 分隔屏出口压力B
    	/// </summary>
        
   
        public System.Double Fgp_press_out_b { get; set; } 
        
    
        /// <summary>
    	/// 分隔屏出口压力C
    	/// </summary>
        
   
        public System.Double Fgp_press_out_c { get; set; } 
        
    
        /// <summary>
    	/// 分隔屏出口压力D
    	/// </summary>
        
   
        public System.Double Fgp_press_out_d { get; set; } 
        
    
        /// <summary>
    	/// 分隔屏出口温度A
    	/// </summary>
        
   
        public System.Double Fgp_temp_out_a { get; set; } 
        
    
        /// <summary>
    	/// 分隔屏出口温度B
    	/// </summary>
        
   
        public System.Double Fgp_temp_out_b { get; set; } 
        
    
        /// <summary>
    	/// 分隔屏出口温度C
    	/// </summary>
        
   
        public System.Double Fgp_temp_out_c { get; set; } 
        
    
        /// <summary>
    	/// 分隔屏出口温度D
    	/// </summary>
        
   
        public System.Double Fgp_temp_out_d { get; set; } 
        
    
        /// <summary>
    	/// 分隔屏出口焓值A
    	/// </summary>
        
   
        public System.Double Fgp_out_hz_a { get; set; } 
        
    
        /// <summary>
    	/// 分隔屏出口焓值B
    	/// </summary>
        
   
        public System.Double Fgp_out_hz_b { get; set; } 
        
    
        /// <summary>
    	/// 分隔屏出口焓值C
    	/// </summary>
        
   
        public System.Double Fgp_out_hz_c { get; set; } 
        
    
        /// <summary>
    	/// 分隔屏出口焓值D
    	/// </summary>
        
   
        public System.Double Fgp_out_hz_d { get; set; } 
        
    
        /// <summary>
    	/// 分隔屏进口压力A
    	/// </summary>
        
   
        public System.Double Fgp_press_in_a { get; set; } 
        
    
        /// <summary>
    	/// 分隔屏进口压力B
    	/// </summary>
        
   
        public System.Double Fgp_press_in_b { get; set; } 
        
    
        /// <summary>
    	/// 分隔屏进口压力C
    	/// </summary>
        
   
        public System.Double Fgp_press_in_c { get; set; } 
        
    
        /// <summary>
    	/// 分隔屏进口压力D
    	/// </summary>
        
   
        public System.Double Fgp_press_in_d { get; set; } 
        
    
        /// <summary>
    	/// 分隔屏进口温度A
    	/// </summary>
        
   
        public System.Double Fgp_temp_in_a { get; set; } 
        
    
        /// <summary>
    	/// 分隔屏进口温度B
    	/// </summary>
        
   
        public System.Double Fgp_temp_in_b { get; set; } 
        
    
        /// <summary>
    	/// 分隔屏进口温度C
    	/// </summary>
        
   
        public System.Double Fgp_temp_in_c { get; set; } 
        
    
        /// <summary>
    	/// 分隔屏进口温度D
    	/// </summary>
        
   
        public System.Double Fgp_temp_in_d { get; set; } 
        
    
        /// <summary>
    	/// 分隔屏进口焓值A
    	/// </summary>
        
   
        public System.Double Fgp_in_hz_a { get; set; } 
        
    
        /// <summary>
    	/// 分隔屏进口焓值B
    	/// </summary>
        
   
        public System.Double Fgp_in_hz_b { get; set; } 
        
    
        /// <summary>
    	/// 分隔屏进口焓值C
    	/// </summary>
        
   
        public System.Double Fgp_in_hz_c { get; set; } 
        
    
        /// <summary>
    	/// 分隔屏进口焓值D
    	/// </summary>
        
   
        public System.Double Fgp_in_hz_d { get; set; } 
        
    
        /// <summary>
    	/// 后屏出口压力A
    	/// </summary>
        
   
        public System.Double Hp_press_out_a { get; set; } 
        
    
        /// <summary>
    	/// 后屏出口压力B
    	/// </summary>
        
   
        public System.Double Hp_press_out_b { get; set; } 
        
    
        /// <summary>
    	/// 后屏出口压力C
    	/// </summary>
        
   
        public System.Double Hp_press_out_c { get; set; } 
        
    
        /// <summary>
    	/// 后屏出口压力D
    	/// </summary>
        
   
        public System.Double Hp_press_out_d { get; set; } 
        
    
        /// <summary>
    	/// 后屏出口温度A
    	/// </summary>
        
   
        public System.Double Hp_temp_out_a { get; set; } 
        
    
        /// <summary>
    	/// 后屏出口温度B
    	/// </summary>
        
   
        public System.Double Hp_temp_out_b { get; set; } 
        
    
        /// <summary>
    	/// 后屏出口温度C
    	/// </summary>
        
   
        public System.Double Hp_temp_out_c { get; set; } 
        
    
        /// <summary>
    	/// 后屏出口温度D
    	/// </summary>
        
   
        public System.Double Hp_temp_out_d { get; set; } 
        
    
        /// <summary>
    	/// 后屏出口焓值A
    	/// </summary>
        
   
        public System.Double Hp_out_hz_a { get; set; } 
        
    
        /// <summary>
    	/// 后屏出口焓值B
    	/// </summary>
        
   
        public System.Double Hp_out_hz_b { get; set; } 
        
    
        /// <summary>
    	/// 后屏出口焓值C
    	/// </summary>
        
   
        public System.Double Hp_out_hz_c { get; set; } 
        
    
        /// <summary>
    	/// 后屏出口焓值D
    	/// </summary>
        
   
        public System.Double Hp_out_hz_d { get; set; } 
        
    
        /// <summary>
    	/// 后屏进口压力A
    	/// </summary>
        
   
        public System.Double Hp_press_in_a { get; set; } 
        
    
        /// <summary>
    	/// 后屏进口压力B
    	/// </summary>
        
   
        public System.Double Hp_press_in_b { get; set; } 
        
    
        /// <summary>
    	/// 后屏进口压力C
    	/// </summary>
        
   
        public System.Double Hp_press_in_c { get; set; } 
        
    
        /// <summary>
    	/// 后屏进口压力D
    	/// </summary>
        
   
        public System.Double Hp_press_in_d { get; set; } 
        
    
        /// <summary>
    	/// 后屏进口温度A
    	/// </summary>
        
   
        public System.Double Hp_temp_in_a { get; set; } 
        
    
        /// <summary>
    	/// 后屏进口温度B
    	/// </summary>
        
   
        public System.Double Hp_temp_in_b { get; set; } 
        
    
        /// <summary>
    	/// 后屏进口温度C
    	/// </summary>
        
   
        public System.Double Hp_temp_in_c { get; set; } 
        
    
        /// <summary>
    	/// 后屏进口温度D
    	/// </summary>
        
   
        public System.Double Hp_temp_in_d { get; set; } 
        
    
        /// <summary>
    	/// 后屏进口焓值A
    	/// </summary>
        
   
        public System.Double Hp_in_hz_a { get; set; } 
        
    
        /// <summary>
    	/// 后屏进口焓值B
    	/// </summary>
        
   
        public System.Double Hp_in_hz_b { get; set; } 
        
    
        /// <summary>
    	/// 后屏进口焓值C
    	/// </summary>
        
   
        public System.Double Hp_in_hz_c { get; set; } 
        
    
        /// <summary>
    	/// 后屏进口焓值D
    	/// </summary>
        
   
        public System.Double Hp_in_hz_d { get; set; } 
        
    
        /// <summary>
    	/// 末级过热器出口温度A
    	/// </summary>
        
   
        public System.Double Mg_temp_out_a { get; set; } 
        
    
        /// <summary>
    	/// 末级过热器出口温度B
    	/// </summary>
        
   
        public System.Double Mg_temp_out_b { get; set; } 
        
    
        /// <summary>
    	/// 末级过热器出口温度C
    	/// </summary>
        
   
        public System.Double Mg_temp_out_c { get; set; } 
        
    
        /// <summary>
    	/// 末级过热器出口温度D
    	/// </summary>
        
   
        public System.Double Mg_temp_out_d { get; set; } 
        
    
        /// <summary>
    	/// 末级过热器出口焓值A
    	/// </summary>
        
   
        public System.Double Mg_out_hz_a { get; set; } 
        
    
        /// <summary>
    	/// 末级过热器出口焓值B
    	/// </summary>
        
   
        public System.Double Mg_out_hz_b { get; set; } 
        
    
        /// <summary>
    	/// 末级过热器出口焓值C
    	/// </summary>
        
   
        public System.Double Mg_out_hz_c { get; set; } 
        
    
        /// <summary>
    	/// 末级过热器出口焓值D
    	/// </summary>
        
   
        public System.Double Mg_out_hz_d { get; set; } 
        
    
        /// <summary>
    	/// 末级过热器进口压力A
    	/// </summary>
        
   
        public System.Double Mg_press_in_a { get; set; } 
        
    
        /// <summary>
    	/// 末级过热器进口压力B
    	/// </summary>
        
   
        public System.Double Mg_press_in_b { get; set; } 
        
    
        /// <summary>
    	/// 末级过热器进口压力C
    	/// </summary>
        
   
        public System.Double Mg_press_in_c { get; set; } 
        
    
        /// <summary>
    	/// 末级过热器进口压力D
    	/// </summary>
        
   
        public System.Double Mg_press_in_d { get; set; } 
        
    
        /// <summary>
    	/// 末级过热器进口温度A
    	/// </summary>
        
   
        public System.Double Mg_temp_in_a { get; set; } 
        
    
        /// <summary>
    	/// 末级过热器进口温度B
    	/// </summary>
        
   
        public System.Double Mg_temp_in_b { get; set; } 
        
    
        /// <summary>
    	/// 末级过热器进口温度C
    	/// </summary>
        
   
        public System.Double Mg_temp_in_c { get; set; } 
        
    
        /// <summary>
    	/// 末级过热器进口温度D
    	/// </summary>
        
   
        public System.Double Mg_temp_in_d { get; set; } 
        
    
        /// <summary>
    	/// 末级过热器进口焓值A
    	/// </summary>
        
   
        public System.Double Mg_in_hz_a { get; set; } 
        
    
        /// <summary>
    	/// 末级过热器进口焓值B
    	/// </summary>
        
   
        public System.Double Mg_in_hz_b { get; set; } 
        
    
        /// <summary>
    	/// 末级过热器进口焓值C
    	/// </summary>
        
   
        public System.Double Mg_in_hz_c { get; set; } 
        
    
        /// <summary>
    	/// 末级过热器进口焓值D
    	/// </summary>
        
   
        public System.Double Mg_in_hz_d { get; set; } 
        
    
        /// <summary>
    	/// 低温再热器进口压力左侧
    	/// </summary>
        
   
        public System.Double Dz_press_in_left { get; set; } 
        
    
        /// <summary>
    	/// 低温再热器进口压力右侧
    	/// </summary>
        
   
        public System.Double Dz_press_in_right { get; set; } 
        
    
        /// <summary>
    	/// 高温再热器出口压力左侧
    	/// </summary>
        
   
        public System.Double Gz_press_out_left { get; set; } 
        
    
        /// <summary>
    	/// 高温再热器出口压力右侧
    	/// </summary>
        
   
        public System.Double Gz_press_out_right { get; set; } 
        
    
        /// <summary>
    	/// 低温再热器出口压力左侧
    	/// </summary>
        
   
        public System.Double Dz_press_out_left { get; set; } 
        
    
        /// <summary>
    	/// 低温再热器出口压力右侧
    	/// </summary>
        
   
        public System.Double Dz_press_out_right { get; set; } 
        
    
        /// <summary>
    	/// 低温再热器出口温度左侧
    	/// </summary>
        
   
        public System.Double Dz_temp_out_left { get; set; } 
        
    
        /// <summary>
    	/// 低温再热器出口温度右侧
    	/// </summary>
        
   
        public System.Double Dz_temp_out_right { get; set; } 
        
    
        /// <summary>
    	/// 低温再热器出口焓值左侧
    	/// </summary>
        
   
        public System.Double Dz_out_hz_left { get; set; } 
        
    
        /// <summary>
    	/// 低温再热器出口焓值右侧
    	/// </summary>
        
   
        public System.Double Dz_out_hz_right { get; set; } 
        
    
        /// <summary>
    	/// 低温再热器进口温度左侧
    	/// </summary>
        
   
        public System.Double Dz_temp_in_left { get; set; } 
        
    
        /// <summary>
    	/// 低温再热器进口温度右侧
    	/// </summary>
        
   
        public System.Double Dz_temp_in_right { get; set; } 
        
    
        /// <summary>
    	/// 低温再热器进口焓值左侧
    	/// </summary>
        
   
        public System.Double Dz_in_hz_left { get; set; } 
        
    
        /// <summary>
    	/// 低温再热器进口焓值右侧
    	/// </summary>
        
   
        public System.Double Dz_in_hz_right { get; set; } 
        
    
        /// <summary>
    	/// 高温再热器出口温度左侧
    	/// </summary>
        
   
        public System.Double Gz_temp_out_left { get; set; } 
        
    
        /// <summary>
    	/// 高温再热器出口温度右侧
    	/// </summary>
        
   
        public System.Double Gz_temp_out_right { get; set; } 
        
    
        /// <summary>
    	/// 高温再热器出口焓值左侧
    	/// </summary>
        
   
        public System.Double Gz_out_hz_left { get; set; } 
        
    
        /// <summary>
    	/// 高温再热器出口焓值右侧
    	/// </summary>
        
   
        public System.Double Gz_out_hz_right { get; set; } 
        
    
        /// <summary>
    	/// 高温再热器进口压力左侧
    	/// </summary>
        
   
        public System.Double Gz_press_in_left { get; set; } 
        
    
        /// <summary>
    	/// 高温再热器进口压力右侧
    	/// </summary>
        
   
        public System.Double Gz_press_in_right { get; set; } 
        
    
        /// <summary>
    	/// 高温再热器进口温度左侧
    	/// </summary>
        
   
        public System.Double Gz_temp_in_left { get; set; } 
        
    
        /// <summary>
    	/// 高温再热器进口温度右侧
    	/// </summary>
        
   
        public System.Double Gz_temp_in_right { get; set; } 
        
    
        /// <summary>
    	/// 高温再热器进口焓值左侧
    	/// </summary>
        
   
        public System.Double Gz_in_hz_left { get; set; } 
        
    
        /// <summary>
    	/// 高温再热器进口焓值右侧
    	/// </summary>
        
   
        public System.Double Gz_in_hz_right { get; set; } 
        
    
        /// <summary>
    	/// 左切圆左侧氧量平均值
    	/// </summary>
        
   
        public System.Double Left_qy_o2_left_avg { get; set; } 
        
    
        /// <summary>
    	/// 左切圆右侧氧量平均值
    	/// </summary>
        
   
        public System.Double Left_qy_o2_right_avg { get; set; } 
        
    
        /// <summary>
    	/// 左切圆后墙悬吊管水冷壁左侧最高点
    	/// </summary>
        
   
        public System.Double Left_qy_back_xdg_left_top { get; set; } 
        
    
        /// <summary>
    	/// 左切圆后墙悬吊管水冷壁右侧最高点
    	/// </summary>
        
   
        public System.Double Left_qy_back_xdg_right_top { get; set; } 
        
    
        /// <summary>
    	/// 右切圆左侧氧量平均值
    	/// </summary>
        
   
        public System.Double Right_qy_o2_left_avg { get; set; } 
        
    
        /// <summary>
    	/// 右切圆右侧氧量平均值
    	/// </summary>
        
   
        public System.Double Right_qy_o2_right_avg { get; set; } 
        
    
        /// <summary>
    	/// 右切圆后墙悬吊管水冷壁左侧最高点
    	/// </summary>
        
   
        public System.Double Right_qy_back_xdg_left_top { get; set; } 
        
    
        /// <summary>
    	/// 右切圆后墙悬吊管水冷壁右侧最高点
    	/// </summary>
        
   
        public System.Double Right_qy_back_xdg_right_top { get; set; } 
        
    
        /// <summary>
    	/// 左墙垂直段水冷壁温度
    	/// </summary>
        
   
        public System.Double Left_czd_temp { get; set; } 
        
    
        /// <summary>
    	/// 右墙垂直段水冷壁温度
    	/// </summary>
        
   
        public System.Double Right_czd_temp { get; set; } 
        
    
        /// <summary>
    	/// 左切圆后墙悬吊管水冷壁左侧最高三个点平均值
    	/// </summary>
        
   
        public System.Double Left_qy_back_xdg_left_top3_avg { get; set; } 
        
    
        /// <summary>
    	/// 左切圆后墙悬吊管水冷壁右侧最高三个点平均值
    	/// </summary>
        
   
        public System.Double Left_qy_back_xdg_right_top3_avg { get; set; } 
        
    
        /// <summary>
    	/// 左墙螺旋段水冷壁最高10个点的平均值
    	/// </summary>
        
   
        public System.Double Left_lxd_top10_avg { get; set; } 
        
    
        /// <summary>
    	/// 右墙螺旋段水冷壁最高10个点的平均值
    	/// </summary>
        
   
        public System.Double Right_lxd_top10_avg { get; set; } 
        
    
        /// <summary>
    	/// 右切圆后墙悬吊管水冷壁左侧最高三个点平均值
    	/// </summary>
        
   
        public System.Double Right_qy_back_xdg_left_top3_avg { get; set; } 
        
    
        /// <summary>
    	/// 右切圆后墙悬吊管水冷壁右侧最高三个点平均值
    	/// </summary>
        
   
        public System.Double Right_qy_back_xdg_right_top3_avg { get; set; } 
        
    
        /// <summary>
    	/// 左切圆后墙管屏水冷壁温度
    	/// </summary>
        
   
        public System.Double Left_qy_back_gp_temp { get; set; } 
        
    
        /// <summary>
    	/// 右切圆后墙管屏水冷壁温度
    	/// </summary>
        
   
        public System.Double Right_qy_back_gp_temp { get; set; } 
        
    
        /// <summary>
    	/// 左切圆前墙垂直水冷壁温度
    	/// </summary>
        
   
        public System.Double Left_qy_front_gp_temp { get; set; } 
        
    
        /// <summary>
    	/// 右切圆前墙垂直水冷壁温度
    	/// </summary>
        
   
        public System.Double Right_qy_front_gp_temp { get; set; } 
        
    
        /// <summary>
    	/// 左切圆后墙螺旋段水冷壁温度最高10个点的平均值
    	/// </summary>
        
   
        public System.Double Left_qy_back_lxd_top10_avg { get; set; } 
        
    
        /// <summary>
    	/// 右切圆后墙螺旋段水冷壁温度最高10个点的平均值
    	/// </summary>
        
   
        public System.Double Right_qy_back_lxd_top10_avg { get; set; } 
        
    
        /// <summary>
    	/// 左切圆前墙螺旋段水冷壁温度最高10个点的平均值
    	/// </summary>
        
   
        public System.Double Left_qy_front_lxd_top10_avg { get; set; } 
        
    
        /// <summary>
    	/// 右切圆前墙螺旋段水冷壁温度最高10个点的平均值
    	/// </summary>
        
   
        public System.Double Right_qy_front_lxd_top10_avg { get; set; } 
        
    
        /// <summary>
    	/// 低温再热器减温水压力
    	/// </summary>
        
   
        public System.Double Dz_jws_press { get; set; } 
        
    
        /// <summary>
    	/// 低温再热器减温水温度
    	/// </summary>
        
   
        public System.Double Dz_jws_temp { get; set; } 
        
    
        /// <summary>
    	/// 低温再热器减温水焓值
    	/// </summary>
        
   
        public System.Double Dz_jws_hz { get; set; } 
        
    
        /// <summary>
    	/// 低温再热器减温器前温度（左侧）
    	/// </summary>
        
   
        public System.Double Dz_jwq_front_left { get; set; } 
        
    
        /// <summary>
    	/// 低温再热器减温器后温度（左侧）
    	/// </summary>
        
   
        public System.Double Dz_jwq_back_left { get; set; } 
        
    
        /// <summary>
    	/// 低温再热器减温器前温度（右侧）
    	/// </summary>
        
   
        public System.Double Dz_jwq_front_right { get; set; } 
        
    
        /// <summary>
    	/// 低温再热器减温器后温度（右侧）
    	/// </summary>
        
   
        public System.Double Dz_jwq_back_right { get; set; } 
        
    
        /// <summary>
    	/// 低温再热器减温器前再热蒸汽焓值（左侧）
    	/// </summary>
        
   
        public System.Double Dz_jwq_front_hz_left { get; set; } 
        
    
        /// <summary>
    	/// 低温再热器减温器后再热蒸汽焓值（左侧）
    	/// </summary>
        
   
        public System.Double Dz_jwq_back_hz_left { get; set; } 
        
    
        /// <summary>
    	/// 低温再热器减温器前再热蒸汽焓值（右侧）
    	/// </summary>
        
   
        public System.Double Dz_jwq_front_hz_right { get; set; } 
        
    
        /// <summary>
    	/// 低温再热器减温器后再热蒸汽焓值（右侧）
    	/// </summary>
        
   
        public System.Double Dz_jwq_back_hz_right { get; set; } 
        
    
        /// <summary>
    	/// 再热器减温水量（左侧）
    	/// </summary>
        
   
        public System.Double Zrq_jws_left { get; set; } 
        
    
        /// <summary>
    	/// 再热器减温水量（右侧）
    	/// </summary>
        
   
        public System.Double Zrq_jws_right { get; set; } 
        
    
        /// <summary>
    	/// 分隔屏设计焓增
    	/// </summary>
        
   
        public System.Double Fgp_hz_design { get; set; } 
        
    
        /// <summary>
    	/// 后屏设计焓增
    	/// </summary>
        
   
        public System.Double Hp_hz_design { get; set; } 
        
    
        /// <summary>
    	/// 末级过热器设计焓增
    	/// </summary>
        
   
        public System.Double Mg_hz_design { get; set; } 
        
    
        /// <summary>
    	/// 低温再热器设计焓增
    	/// </summary>
        
   
        public System.Double Dz_hz_design { get; set; } 
        
    
        /// <summary>
    	/// 高温再热器设计焓增
    	/// </summary>
        
   
        public System.Double Gz_hz_design { get; set; } 
        
    
        /// <summary>
    	/// 过热器减温水焓值
    	/// </summary>
        
   
        public System.Double Grq_jws_hz { get; set; } 
        
    
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
    	/// 左切圆后墙悬吊管水冷壁左侧最高点
    	/// </summary>
        
   
        public System.String Left_qy_back_xdg_left_top_point { get; set; } 
        
    
        /// <summary>
    	/// 左切圆后墙悬吊管水冷壁右侧最高点
    	/// </summary>
        
   
        public System.String Left_qy_back_xdg_right_top_point { get; set; } 
        
    
        /// <summary>
    	/// 右切圆后墙悬吊管水冷壁左侧最高点
    	/// </summary>
        
   
        public System.String Right_qy_back_xdg_left_top_point { get; set; } 
        
    
        /// <summary>
    	/// 右切圆后墙悬吊管水冷壁右侧最高点
    	/// </summary>
        
   
        public System.String Right_qy_back_xdg_right_top_point { get; set; } 
        
    
        /// <summary>
    	/// 左切圆后墙悬吊管水冷壁左侧最高三个点
    	/// </summary>
        
   
        public System.String Left_qy_back_xdg_left_top3 { get; set; } 
        
    
        /// <summary>
    	/// 左切圆后墙悬吊管水冷壁右侧最高三个点
    	/// </summary>
        
   
        public System.String Left_qy_back_xdg_right_top3 { get; set; } 
        
    
        /// <summary>
    	/// 右切圆后墙悬吊管水冷壁左侧最高三个点
    	/// </summary>
        
   
        public System.String Right_qy_back_xdg_left_top3 { get; set; } 
        
    
        /// <summary>
    	/// 右切圆后墙悬吊管水冷壁右侧最高三个点
    	/// </summary>
        
   
        public System.String Right_qy_back_xdg_right_top3 { get; set; } 
        
    
        /// <summary>
    	/// 低温过热器设计焓增
    	/// </summary>
        
   
        public System.Double Dg_hz_design { get; set; } 
        
	
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
