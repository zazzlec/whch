using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WHCH.Api.Entities.Enums.CommonEnum;

namespace WHCH.Api.Entities
{
	[Serializable]
	public class Dncchareahis
	{
    
    
    
        /// <summary>
    	/// 序号
    	/// </summary>
        [Key,Required]
   
        public System.Int32 Id { get; set; }

        public System.Int32 AreaId { get; set; }
        /// <summary>
        /// 区域描述
        /// </summary>


        public System.String K_Name_kw { get; set; } 
        
    
        /// <summary>
    	/// 备注
    	/// </summary>
        
   
        public System.String Remarks { get; set; } 
        
    
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
    	/// 污染率
    	/// </summary>
        
   
        public System.Double Wrl_Val { get; set; } 
        
    
        /// <summary>
    	/// 污染率待吹灰上限
    	/// </summary>
        
   
        public System.Double Wrldch_Val { get; set; } 
        
    
        /// <summary>
    	/// 污染率执行上限
    	/// </summary>
        
   
        public System.Double Wrlexcu_Val { get; set; } 
        
    
        /// <summary>
    	/// 堵塞率
    	/// </summary>
        
   
        public System.Double Dsl_Val { get; set; } 
        
    
        /// <summary>
    	/// 堵塞率待吹灰上限
    	/// </summary>
        
   
        public System.Double Dslhigh_Val { get; set; } 
        
    
        /// <summary>
    	/// 堵塞率执行上限
    	/// </summary>
        
   
        public System.Double Dslexcu_Val { get; set; } 
        
    
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
