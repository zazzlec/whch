using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WHCH.Api.Entities.Enums.CommonEnum;

namespace WHCH.Api.Entities
{
	[Serializable]
	public class Dncchlist
	{
    
    
    
        /// <summary>
    	/// 序号
    	/// </summary>
        [Key,Required]
   
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
        
    	public Dncchqpoint DncChqpoint { get; set; } 
        public System.Int32 DncChqpointId { get; set; } 
    
        /// <summary>
    	/// 吹灰器名称
    	/// </summary>
        
   
        public System.String DncChqpoint_Name { get; set; } 
        
    
        /// <summary>
    	/// 污染率
    	/// </summary>
        
   
        public System.Double Wrl_Val { get; set; } 
        
    
        /// <summary>
    	/// 堵塞率
    	/// </summary>
        
   
        public System.Double Dsl_Val { get; set; } 
        
    
        /// <summary>
    	/// 区域1为污染率满足判据时添加入的吹灰器；区域2为周期性(短吹)、长时间未吹灰的、低负荷长期运行添加入的吹灰器
    	/// </summary>
        
   
        public System.Int32 AddReason { get; set; } 
        
    
        /// <summary>
    	/// 锅炉ID
    	/// </summary>
        
    	public Dncboiler DncBoiler { get; set; } 
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
