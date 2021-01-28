using System;
using WHCH.Api.Entities.Enums;
using static WHCH.Api.Entities.Enums.CommonEnum;

namespace WHCH.Api.ViewModels.Rbac.Dncfireerror_mid
{
	public class Dncfireerror_midEditViewModel
	{
    
    
    
        /// <summary>
    	/// 序号
    	/// </summary>
        public System.Int64 Id { get; set; } 
	
    
        /// <summary>
    	/// 异常类型ID
    	/// </summary>
    	public System.String DncType { get; set; } 
	
    
        /// <summary>
    	/// 
    	/// </summary>
        public System.String DncType_Name { get; set; } 
	
    
        /// <summary>
    	/// 实际时间
    	/// </summary>
        public DateTime? RealTime { get; set; } 
	
    
        /// <summary>
    	/// 异常小类ID
    	/// </summary>
        public System.Int32 Etype { get; set; } 
	
    
        /// <summary>
    	/// 状态(0:正常 1:异常)
    	/// </summary>
        public System.Int32 Evalue { get; set; } 
	
    
        /// <summary>
    	/// 备注
    	/// </summary>
        public System.String Remarks { get; set; } 
	
    
        /// <summary>
    	/// 
    	/// </summary>
    	public System.String DncBoiler { get; set; } 
	
    
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
