using System;
using WHCH.Api.Entities.Enums;
using static WHCH.Api.Entities.Enums.CommonEnum;

namespace WHCH.Api.ViewModels.Rbac.Dnchfburn
{
	public class DnchfburnJsonModel
	{
    
    
    
        /// <summary>
    	/// 
    	/// </summary>
        public System.Int32 Id { get; set; } 
	
    
        /// <summary>
    	/// 班次
    	/// </summary>
    	public WHCH.Api.Entities.Dncclasses DncClasses { get; set; } 
        public int DncClassesId { get; set; } 
	
    
        /// <summary>
    	/// 班次
    	/// </summary>
        public System.String DncClasses_Name { get; set; } 
	
    
        /// <summary>
    	/// 锅炉ID
    	/// </summary>
    	public WHCH.Api.Entities.Dncboiler DncBoiler { get; set; } 
        public int DncBoilerId { get; set; } 
	
    
        /// <summary>
    	/// 锅炉名称
    	/// </summary>
        public System.String DncBoiler_Name { get; set; } 
	
    
        /// <summary>
    	/// 添加时间
    	/// </summary>
        public DateTime? AddTime { get; set; } 
	
    
        /// <summary>
    	/// 值
    	/// </summary>
        public System.Decimal Pvalue { get; set; } 
	
    
        /// <summary>
    	/// 备注
    	/// </summary>
        public System.String Remark { get; set; } 
	
	
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
