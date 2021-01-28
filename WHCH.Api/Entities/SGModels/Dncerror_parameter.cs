using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WHCH.Api.Entities.Enums.CommonEnum;

namespace WHCH.Api.Entities
{
	[Serializable]
	public class Dncerror_parameter
	{
    
    
    
        /// <summary>
    	/// 序号
    	/// </summary>
        [Key,Required]
   
        public System.Int32 Id { get; set; } 
        
    
        /// <summary>
    	/// 分隔屏焓增B比A高
    	/// </summary>
        
   
        public System.Double Fgp_hz_b_big_a { get; set; } 
        
    
        /// <summary>
    	/// 后屏焓增B比A高
    	/// </summary>
        
   
        public System.Double Hp_hz_b_big_a { get; set; } 
        
    
        /// <summary>
    	/// 高过焓增A比B高
    	/// </summary>
        
   
        public System.Double Mg_hz_a_big_b { get; set; } 
        
    
        /// <summary>
    	/// 低再焓增A比B高
    	/// </summary>
        
   
        public System.Double Dz_hz_a_big_b { get; set; } 
        
    
        /// <summary>
    	/// 末再焓增A比B高
    	/// </summary>
        
   
        public System.Double Mz_hz_a_big_b { get; set; } 
        
    
        /// <summary>
    	/// 烟气浓度左比右高（左切圆）
    	/// </summary>
        
   
        public System.Double Left_qy_yqnd_l_big_r { get; set; } 
        
    
        /// <summary>
    	/// 悬吊管最高点左比右高(左切圆)
    	/// </summary>
        
   
        public System.Double Left_qy_xdgtop_l_big_r { get; set; } 
        
    
        /// <summary>
    	/// 消旋、起旋动量不足异常值条件数量
    	/// </summary>
        
   
        public System.Int32 Xx_qxbz_error_num { get; set; } 
        
    
        /// <summary>
    	/// 分隔屏焓增C比D高
    	/// </summary>
        
   
        public System.Double Fgp_hz_c_big_d { get; set; } 
        
    
        /// <summary>
    	/// 后屏焓增C比D高
    	/// </summary>
        
   
        public System.Double Hp_hz_c_big_d { get; set; } 
        
    
        /// <summary>
    	/// 高过焓增A比B高
    	/// </summary>
        
   
        public System.Double Mg_hz_d_big_c { get; set; } 
        
    
        /// <summary>
    	/// 低再焓增D比C高
    	/// </summary>
        
   
        public System.Double Dz_hz_d_big_c { get; set; } 
        
    
        /// <summary>
    	/// 末再焓增D比C高
    	/// </summary>
        
   
        public System.Double Mz_hz_d_big_c { get; set; } 
        
    
        /// <summary>
    	/// 烟气浓度右比左高（右切圆）
    	/// </summary>
        
   
        public System.Double Right_qy_yqnd_r_big_l { get; set; } 
        
    
        /// <summary>
    	/// 悬吊管最高点右比左高(右切圆)
    	/// </summary>
        
   
        public System.Double Right_qy_xdgtop_r_big_l { get; set; } 
        
    
        /// <summary>
    	/// 分隔屏焓增B比A低
    	/// </summary>
        
   
        public System.Double Fgp_hz_b_small_a { get; set; } 
        
    
        /// <summary>
    	/// 后屏焓增B比A低
    	/// </summary>
        
   
        public System.Double Hp_hz_b_small_a { get; set; } 
        
    
        /// <summary>
    	/// 高过焓增A比B低
    	/// </summary>
        
   
        public System.Double Mg_hz_a_small_b { get; set; } 
        
    
        /// <summary>
    	/// 低再焓增A比B低
    	/// </summary>
        
   
        public System.Double Dz_hz_a_small_b { get; set; } 
        
    
        /// <summary>
    	/// 末再焓增A比B低
    	/// </summary>
        
   
        public System.Double Mz_hz_a_small_b { get; set; } 
        
    
        /// <summary>
    	/// 烟气浓度左比右低（左切圆）
    	/// </summary>
        
   
        public System.Double Left_qy_yqnd_l_small_r { get; set; } 
        
    
        /// <summary>
    	/// 悬吊管最高点左比右低(左切圆)
    	/// </summary>
        
   
        public System.Double Left_qy_xdgtop_l_small_r { get; set; } 
        
    
        /// <summary>
    	/// 分隔屏焓增C比D低
    	/// </summary>
        
   
        public System.Double Fgp_hz_c_small_d { get; set; } 
        
    
        /// <summary>
    	/// 后屏焓增C比D低
    	/// </summary>
        
   
        public System.Double Hp_hz_c_small_d { get; set; } 
        
    
        /// <summary>
    	/// 高过焓增D比C低
    	/// </summary>
        
   
        public System.Double Mg_hz_d_small_c { get; set; } 
        
    
        /// <summary>
    	/// 低再焓增D比C低
    	/// </summary>
        
   
        public System.Double Dz_hz_d_small_c { get; set; } 
        
    
        /// <summary>
    	/// 末再焓增D比C低
    	/// </summary>
        
   
        public System.Double Mz_hz_dsmall_c { get; set; } 
        
    
        /// <summary>
    	/// 烟气浓度右比左低（右切圆）
    	/// </summary>
        
   
        public System.Double Right_qy_yqnd_r_small_l { get; set; } 
        
    
        /// <summary>
    	/// 悬吊管最高点右比左低(右切圆)
    	/// </summary>
        
   
        public System.Double Right_qy_xdgtop_r_small_l { get; set; } 
        
    
        /// <summary>
    	/// 垂直段水冷壁左墙右墙温度差
    	/// </summary>
        
   
        public System.Double Czd_temp_left_right { get; set; } 
        
    
        /// <summary>
    	/// 左、右切圆后墙悬吊管水冷壁左侧、右侧最高三点平均值的差值
    	/// </summary>
        
   
        public System.Double Qy_back_xdg_top3_avg_l_r { get; set; } 
        
    
        /// <summary>
    	/// 螺旋段水冷壁壁温左侧、右侧最高10个点平均值的差值
    	/// </summary>
        
   
        public System.Double Lxd_temp_top10_l_r { get; set; } 
        
    
        /// <summary>
    	/// 左、右切圆向左、向右偏斜异常值条件数量
    	/// </summary>
        
   
        public System.Int32 Qy_px_l_r_num { get; set; } 
        
    
        /// <summary>
    	/// 左、右切圆后墙管屏水冷壁温度比前墙垂直水冷壁高
    	/// </summary>
        
   
        public System.Double Qy_gp_h_big_q { get; set; } 
        
    
        /// <summary>
    	/// 左、右切圆前墙管屏水冷壁温度比后墙垂直水冷壁高
    	/// </summary>
        
   
        public System.Double Qy_gp_q_big_h { get; set; } 
        
    
        /// <summary>
    	/// 左、右切圆前墙、后墙螺旋段水冷壁温度差值
    	/// </summary>
        
   
        public System.Double Qy_lxd_q_h { get; set; } 
        
    
        /// <summary>
    	/// 左、右切圆向前、向后偏斜异常值条件数量
    	/// </summary>
        
   
        public System.Int32 Qy_px_q_h_num { get; set; } 
        
    
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
