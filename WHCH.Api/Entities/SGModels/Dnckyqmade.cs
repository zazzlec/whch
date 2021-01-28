using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WHCH.Api.Entities.Enums.CommonEnum;

namespace WHCH.Api.Entities
{
	[Serializable]
	public class Dnckyqmade
	{
    
    
    
        /// <summary>
    	/// 编号
    	/// </summary>
        [Key,Required]
   
        public System.Int32 Id { get; set; } 
        
    
        /// <summary>
    	/// 名称
    	/// </summary>
        
   
        public System.String K_Name_kw { get; set; } 
        
    
        /// <summary>
    	/// 寿命
    	/// </summary>
        
   
        public System.Int64 Life_Val { get; set; } 
        
    
        /// <summary>
    	/// 单位
    	/// </summary>
        
   
        public System.String Unit { get; set; } 
        
    
        /// <summary>
    	/// 更换时间
    	/// </summary>
        
   
        public DateTime? Changedate { get; set; } 
        
    
        /// <summary>
    	/// 类型
    	/// </summary>
        
    	public Dnckyqtype DncKyqTpye { get; set; } 
        public System.Int32 DncKyqTpyeId { get; set; } 
    
        /// <summary>
    	/// 类型
    	/// </summary>
        
   
        public System.String DncKyqTpye_Name { get; set; } 
        
    
        /// <summary>
    	/// 锅炉ID
    	/// </summary>
        
    	public Dncboiler DncBoiler { get; set; } 
        public System.Int32 DncBoilerId { get; set; } 
    
        /// <summary>
    	/// 锅炉描述
    	/// </summary>
        
   
        public System.String DncBoiler_Name { get; set; }

        /// <summary>
        /// 空预器Id
        /// </summary>

        public Dnckyq DncKyq { get; set; }
        public System.Int32 DncKyqId { get; set; }

        /// <summary>
        /// 
        /// </summary>


        public System.String DncKyq_Name { get; set; }
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
