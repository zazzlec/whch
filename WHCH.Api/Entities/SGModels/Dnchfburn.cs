using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WHCH.Api.Entities.Enums.CommonEnum;

namespace WHCH.Api.Entities
{
	[Serializable]
	public class Dnchfburn
	{
    
    
    
        /// <summary>
    	/// 
    	/// </summary>
        [Key,Required]
   
        public System.Int32 Id { get; set; } 
        
    
        /// <summary>
    	/// 班次
    	/// </summary>
        
    	public Dncclasses DncClasses { get; set; } 
        public System.Int32 DncClassesId { get; set; } 
    
        /// <summary>
    	/// 班次
    	/// </summary>
        
   
        public System.String DncClasses_Name { get; set; } 
        
    
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
    	/// 添加时间
    	/// </summary>
        
   
        public DateTime? AddTime { get; set; } 
        
    
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
