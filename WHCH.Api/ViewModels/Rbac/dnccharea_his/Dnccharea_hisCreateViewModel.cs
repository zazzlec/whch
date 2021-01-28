using System;
using WHCH.Api.Entities.Enums;
using static WHCH.Api.Entities.Enums.CommonEnum;

namespace WHCH.Api.ViewModels.Rbac.Dnccharea_his
{
	public class Dnccharea_hisCreateViewModel
	{
    
        public System.Int32 Id = 0;
        
    
        /// <summary>
    	/// 序号
    	/// </summary>
    	
	
    
        /// <summary>
    	/// 备注
    	/// </summary>
        public System.String Remarks { get; set; } 
    	
	
    
        /// <summary>
    	/// 锅炉ID
    	/// </summary>
    	public WHCH.Api.Entities.Dncboiler DncBoiler { get; set; } 
    	
	
    
        /// <summary>
    	/// 锅炉名称
    	/// </summary>
        public System.String DncBoiler_Name { get; set; } 
    	
	
    
        /// <summary>
    	/// 吹灰器区域ID
    	/// </summary>
    	public WHCH.Api.Entities.Dnccharea DncCharea { get; set; } 
    	
	
    
        /// <summary>
    	/// 吹灰器区域名称
    	/// </summary>
        public System.String DncCharea_Name { get; set; } 
    	
	
    
        /// <summary>
    	/// 污染率
    	/// </summary>
        public System.Double Wrl_Val { get; set; } 
    	
	
    
        /// <summary>
    	/// 污染率上限
    	/// </summary>
        public System.Double Wrlhigh_Val { get; set; } 
    	
	
    
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
