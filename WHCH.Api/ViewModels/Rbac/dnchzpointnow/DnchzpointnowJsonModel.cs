using System;
using WHCH.Api.Entities.Enums;
using static WHCH.Api.Entities.Enums.CommonEnum;

namespace WHCH.Api.ViewModels.Rbac.Dnchzpointnow
{
	public class DnchzpointnowJsonModel
	{
    
    
    
        /// <summary>
    	/// 序号
    	/// </summary>
        public System.Int64 Id { get; set; } 
	
    
        /// <summary>
    	/// 测点类型
    	/// </summary>
    	public WHCH.Api.Entities.Dnctype DncType { get; set; } 
        public int DncTypeId { get; set; } 
	
    
        /// <summary>
    	/// 测点类型名称
    	/// </summary>
        public System.String DncType_Name { get; set; } 
	
    
        /// <summary>
    	/// 实际时间
    	/// </summary>
        public DateTime? RealTime { get; set; } 
	
    
        /// <summary>
    	/// 测点数值（数组）
    	/// </summary>
        public System.String Pvalue { get; set; } 
	
    
        /// <summary>
    	/// 备注
    	/// </summary>
        public System.String Remarks { get; set; } 
	
    
        /// <summary>
    	/// 锅炉id
    	/// </summary>
    	public WHCH.Api.Entities.Dncboiler DncBoiler { get; set; } 
        public int DncBoilerId { get; set; } 
	
    
        /// <summary>
    	/// 锅炉名称
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
