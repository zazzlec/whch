﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WHCH.Api.Entities.Enums.CommonEnum;

namespace WHCH.Api.Entities
{
	[Serializable]
	public class Dncclasses
	{
    
    
    
        /// <summary>
    	/// 
    	/// </summary>
        [Key,Required]
   
        public System.Int32 Id { get; set; } 
        
    
        /// <summary>
    	/// 班次
    	/// </summary>
        
   
        public System.String K_Name_kw { get; set; } 
        
    
        /// <summary>
    	/// 开始时间
    	/// </summary>
        
   
        public DateTime? StartTime { get; set; } 
        
    
        /// <summary>
    	/// 结束时间
    	/// </summary>
        
   
        public DateTime? EndTime { get; set; } 
        
    
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
