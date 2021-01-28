using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WHCH.Api.Entities.Enums.CommonEnum;

namespace WHCH.Api.Entities
{
	[Serializable]
	public class Dncch_parameter
	{

        public System.String loop { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        [Key,Required]
   
        public System.Int32 Id { get; set; } 
        
    
        /// <summary>
    	/// 机组id
    	/// </summary>
        
    	public Dncboiler DncBoiler { get; set; } 
        public System.Int32 DncBoilerId { get; set; } 
    
        /// <summary>
    	/// 机组
    	/// </summary>
        
   
        public System.String DncBoiler_Name { get; set; } 
        
    
        /// <summary>
    	/// 低过设计沾污系数
    	/// </summary>
        
   
        public System.Double Dg_zwxs_design_Val { get; set; } 
        
    
        /// <summary>
    	/// 屏过设计沾污系数
    	/// </summary>
        
   
        public System.Double Pg_zwxs_design_Val { get; set; } 
        
    
        /// <summary>
    	/// 高过设计沾污系数
    	/// </summary>
        
   
        public System.Double Mg_zwxs_design_Val { get; set; } 
        
    
        /// <summary>
    	/// 低再设计沾污系数
    	/// </summary>
        
   
        public System.Double Dz_zwxs_design_Val { get; set; } 
        
    
        /// <summary>
    	/// 高再设计沾污系数
    	/// </summary>
        
   
        public System.Double Gz_zwxs_design_Val { get; set; } 
        
    
        /// <summary>
    	/// 分级省煤器设计沾污系数
    	/// </summary>
        
   
        public System.Double Fs_zwxs_design_Val { get; set; } 
        
    
        /// <summary>
    	/// 主省煤器设计沾污系数
    	/// </summary>
        
   
        public System.Double Zs_zwxs_design_Val { get; set; } 
        
    
        /// <summary>
    	/// 给水泵中间抽头压力系数
    	/// </summary>
        
   
        public System.Double Ctylxs_Val { get; set; } 
        
    
        /// <summary>
    	/// 经X比修正后排烟温度变化值系数
    	/// </summary>
        
   
        public System.Double Xs_py_x_modify_Val { get; set; } 
        
    
        /// <summary>
    	/// 设计进口风温
    	/// </summary>
        
   
        public System.Double Wind_temp_in_design_Val { get; set; } 
        
    
        /// <summary>
    	/// 经进口风温修正后排烟温度变化值系数
    	/// </summary>
        
   
        public System.Double Py_temp_in_wind_temp_modify_xs_Val { get; set; } 
        
    
        /// <summary>
    	/// 屏过污染率上限
    	/// </summary>
        
   
        public System.Double Pg_wrl_high_Val { get; set; } 
        
    
        /// <summary>
    	/// 高过污染率上限
    	/// </summary>
        
   
        public System.Double Mg_wrl_high_Val { get; set; } 
        
    
        /// <summary>
    	/// 高再污染率上限
    	/// </summary>
        
   
        public System.Double Gz_wrl_high_Val { get; set; } 
        
    
        /// <summary>
    	/// 低再污染率上限
    	/// </summary>
        
   
        public System.Double Dz_wrl_high_Val { get; set; } 
        
    
        /// <summary>
    	/// 低过污染率上限
    	/// </summary>
        
   
        public System.Double Dg_wrl_high_Val { get; set; } 
        
    
        /// <summary>
    	/// 主省煤器污染率上限
    	/// </summary>
        
   
        public System.Double Zs_wrl_high_Val { get; set; } 
        
    
        /// <summary>
    	/// 分级省煤器污染率上限
    	/// </summary>
        
   
        public System.Double Fs_wrl_high_Val { get; set; } 
        
    
        /// <summary>
    	/// 空预器烟气侧效率下限
    	/// </summary>
        
   
        public System.Double Kyq_yq_ratio_low_Val { get; set; } 
        
    
        /// <summary>
    	/// 高过污染率下限
    	/// </summary>
        
   
        public System.Double Mg_wrl_low_Val { get; set; } 
        
    
        /// <summary>
    	/// 高再污染率上限
    	/// </summary>
        
   
        public System.Double Gz_wrl_low_Val { get; set; } 
        
	
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
