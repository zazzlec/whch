using System;
using WHCH.Api.Entities.Enums;
using static WHCH.Api.Entities.Enums.CommonEnum;

namespace WHCH.Api.ViewModels.Rbac.Dncboilerstatus
{
	public class DncboilerstatusEditViewModel
	{
    
    
    
        /// <summary>
    	/// 序号
    	/// </summary>
        public System.Int32 Id { get; set; } 
	
    
        /// <summary>
    	/// 运行状态（0：停机 1：运行）
    	/// </summary>
        public System.Int32 NowStatus { get; set; } 
	
    
        /// <summary>
    	/// 状态更新时间
    	/// </summary>
        public DateTime? Sta_time { get; set; } 
	
    
        /// <summary>
    	/// 锅炉ID
    	/// </summary>
        public System.Int32 DncBoilerId { get; set; } 
	
    
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
