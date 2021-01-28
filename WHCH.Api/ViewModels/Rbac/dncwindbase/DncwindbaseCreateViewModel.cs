using System;
using WHCH.Api.Entities.Enums;
using static WHCH.Api.Entities.Enums.CommonEnum;

namespace WHCH.Api.ViewModels.Rbac.Dncwindbase
{
	public class DncwindbaseCreateViewModel
	{
    
        public System.Int32 Id = 0;
        
    
        /// <summary>
    	/// 编号
    	/// </summary>
    	
	
    
        /// <summary>
    	/// 风门角度（基础工况）
    	/// </summary>
        public System.Int32 Base_angle { get; set; } 
    	
	
    
        /// <summary>
    	/// 百分比（基础工况）
    	/// </summary>
        public System.Double Base_percent { get; set; } 
    	
	
    
        /// <summary>
    	/// 实际时间
    	/// </summary>
        public DateTime? RealTime { get; set; } 
    	
	
    
        /// <summary>
    	/// 锅炉ID
    	/// </summary>
    	public System.String DncBoiler { get; set; }

        public System.Int32 DncBoilerId { get; set; }

        /// <summary>
        /// 锅炉描述
        /// </summary>
        public System.String DncBoiler_Name { get; set; } 
    	
	
    
        /// <summary>
    	/// 备注
    	/// </summary>
        public System.String Remarks { get; set; } 
    	
	
    
        /// <summary>
    	/// 风门Id
    	/// </summary>
    	public System.String DncWind { get; set; } 
    	
	
    
        /// <summary>
    	/// 风门名称
    	/// </summary>
        public System.String DncWind_Name { get; set; } 
    	
	
    
        /// <summary>
    	/// 操作人
    	/// </summary>
        public System.String OpeartePerson { get; set; } 
    	
	
	
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
