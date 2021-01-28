using System;
using WHCH.Api.Entities.Enums;
using static WHCH.Api.Entities.Enums.CommonEnum;

namespace WHCH.Api.ViewModels.Rbac.Dncwind
{
	public class DncwindCreateViewModel
	{
    
        public System.Int32 Id = 0;
        
    
        /// <summary>
    	/// 编号
    	/// </summary>
    	
	
    
        /// <summary>
    	/// 风门名称
    	/// </summary>
        public System.String Wind_Name_kw { get; set; }



        public System.Int32 DncWindgroupId { get; set; }
        public WHCH.Api.Entities.Dncwindgroup Dncwindgroup { get; set; }
        public System.String DncGroup_Name { get; set; }



        /// <summary>
        /// 门宽
        /// </summary>
        public System.Double Doorwitdh { get; set; } 
    	
	
    
        /// <summary>
    	/// 门高
    	/// </summary>
        public System.Double Doorheight { get; set; } 
    	
	
    
        /// <summary>
    	/// 0%角度
    	/// </summary>
        public System.Int32 Angle0 { get; set; } 
    	
	
    
        /// <summary>
    	/// 风门角度（基础工况）
    	/// </summary>
        public System.Int32 Base_angle { get; set; } 
    	
	
    
        /// <summary>
    	/// 流通面积（基础工况）
    	/// </summary>
        public System.Double Base_ltmj { get; set; } 
    	
	
    
        /// <summary>
    	/// 百分比（基础工况）
    	/// </summary>
        public System.Double Base_percent { get; set; } 
    	
	
    
        /// <summary>
    	/// 实际时间
    	/// </summary>
        public DateTime? RealTime { get; set; } 
    	
	
    
        /// <summary>
    	/// 风门角度（实际工况）
    	/// </summary>
        public System.Int32 Real_angle { get; set; } 
    	
	
    
        /// <summary>
    	/// 流通面积（实际工况）
    	/// </summary>
        public System.Double Real_ltmj { get; set; } 
    	
	
    
        /// <summary>
    	/// 百分比（实际工况）
    	/// </summary>
        public System.Double Real_percent { get; set; } 
    	
	
    
        /// <summary>
    	/// 锅炉ID
    	/// </summary>
    	public WHCH.Api.Entities.Dncboiler DncBoiler { get; set; }
        public int DncBoilerId { get; set; }
        public System.String DncBoiler_Name { get; set; } 
    	
	
    
        /// <summary>
    	/// 备注
    	/// </summary>
        public System.String Remarks { get; set; } 
    	
	
	
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
