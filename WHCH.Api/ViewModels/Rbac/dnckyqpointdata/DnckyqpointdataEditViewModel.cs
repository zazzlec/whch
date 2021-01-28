using System;
using WHCH.Api.Entities.Enums;
using static WHCH.Api.Entities.Enums.CommonEnum;

namespace WHCH.Api.ViewModels.Rbac.Dnckyqpointdata
{
	public class DnckyqpointdataEditViewModel
	{
    
    
    
        /// <summary>
    	/// 
    	/// </summary>
        public System.Int32 Id { get; set; } 
	
    
        /// <summary>
    	/// 类型
    	/// </summary>
    	public System.String DncKyqTpye { get; set; } 
	
    
        /// <summary>
    	/// 类型
    	/// </summary>
        public System.String DncKyqTpye_Name { get; set; } 
	
    
        /// <summary>
    	/// 测点值
    	/// </summary>
        public System.String Pval { get; set; } 
	
    
        /// <summary>
    	/// 类型
    	/// </summary>
        public System.Single Point_Val { get; set; } 
	
    
        /// <summary>
    	/// 锅炉ID
    	/// </summary>
    	public System.String DncBoiler { get; set; } 
	
    
        /// <summary>
    	/// 锅炉描述
    	/// </summary>
        public System.String DncBoiler_Name { get; set; }

        /// <summary>
        /// 空预器Id
        /// </summary>

        public WHCH.Api.Entities.Dnckyq DncKyq { get; set; }
        public System.String DncKyq_Name { get; set; }
        /// <summary>
    	/// 实际时间
    	/// </summary>
        public DateTime? RealTime { get; set; } 
	
	
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
