using System;
using WHCH.Api.Entities.Enums;
using static WHCH.Api.Entities.Enums.CommonEnum;

namespace WHCH.Api.ViewModels.Rbac.Dnchfburn
{
	public class DnchfburnEditViewModel
	{
    
    
    
        /// <summary>
    	/// 
    	/// </summary>
        public System.Int32 Id { get; set; } 
	
    
        /// <summary>
    	/// 班次
    	/// </summary>
    	public System.String DncClasses { get; set; } 
	
    
        /// <summary>
    	/// 班次
    	/// </summary>
        public System.String DncClasses_Name { get; set; } 
	
    
        /// <summary>
    	/// 锅炉ID
    	/// </summary>
    	public System.String DncBoiler { get; set; } 
	
    
        /// <summary>
    	/// 锅炉名称
    	/// </summary>
        public System.String DncBoiler_Name { get; set; }




        /// <summary>
        /// 值
        /// </summary>
        public System.Double Pvalue { get; set; }
        public System.Int32 Lid { get; set; }

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
