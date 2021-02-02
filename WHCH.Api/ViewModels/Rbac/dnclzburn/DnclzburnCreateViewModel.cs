using System;
using WHCH.Api.Entities.Enums;
using static WHCH.Api.Entities.Enums.CommonEnum;

namespace WHCH.Api.ViewModels.Rbac.Dnclzburn
{
	public class DnclzburnCreateViewModel
	{
    
        public System.Int32 Id = 0;
        
    
        /// <summary>
    	/// 
    	/// </summary>
    	
	
    
        /// <summary>
    	/// 化验员
    	/// </summary>
        public System.String OptionUser { get; set; } 
    	
	
    
        /// <summary>
    	/// 加入日期
    	/// </summary>
        public DateTime? AddTime { get; set; } 
    	
	
    
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
