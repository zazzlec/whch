using System;
using WHCH.Api.Entities.Enums;
using static WHCH.Api.Entities.Enums.CommonEnum;

namespace WHCH.Api.ViewModels.Rbac.Dncchlist
{
	public class DncchlistJsonModel
	{
    
    
    
        /// <summary>
    	/// 序号
    	/// </summary>
        public System.Int32 Id { get; set; } 
	
    
        /// <summary>
    	/// 吹灰器描述
    	/// </summary>
        public System.String K_Name_kw { get; set; } 
	
    
        /// <summary>
    	/// 实际时间
    	/// </summary>
        public DateTime? AddTime { get; set; } 
	
    
        /// <summary>
    	/// 吹灰时间
    	/// </summary>
        public DateTime? RunTime { get; set; } 
	
    
        /// <summary>
    	/// 备注
    	/// </summary>
        public System.String Remarks { get; set; } 
	
    
        /// <summary>
    	/// 吹灰器ID
    	/// </summary>
    	public WHCH.Api.Entities.Dncchqpoint DncChqpoint { get; set; } 
        public int DncChqpointId { get; set; } 
	
    
        /// <summary>
    	/// 吹灰器名称
    	/// </summary>
        public System.String DncChqpoint_Name { get; set; } 
	
    
        /// <summary>
    	/// 污染率
    	/// </summary>
        public System.Double Wrl_Val { get; set; } 
	
    
        /// <summary>
    	/// 污染率上限
    	/// </summary>
        public System.Double Wrlhigh_Val { get; set; } 
	
    
        /// <summary>
    	/// 区域1为污染率满足判据时添加入的吹灰器；区域2为周期性(短吹)、长时间未吹灰的、低负荷长期运行添加入的吹灰器
    	/// </summary>
        public System.Int32 AddReason { get; set; } 
	
    
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
        /// 是否可用(0:禁用,1:可用)
        /// </summary>
        public Status Status { get; set; }
        /// <summary>
        /// 是否已删
        /// </summary>
        public IsDeleted IsDeleted { get; set; }
		
	}
}
