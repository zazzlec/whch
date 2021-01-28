using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WHCH.Api.Entities.Enums.CommonEnum;

namespace WHCH.Api.Entities
{
	[Serializable]
	public class Dncfireerror_advice
	{
    
    
    
        /// <summary>
    	/// 编号
    	/// </summary>
        [Key,Required]
   
        public System.Int64 Id { get; set; } 
        
    
        /// <summary>
    	/// 异常类型ID
    	/// </summary>
        
    	public Dnctype DncType { get; set; } 
        public System.Int32 DncTypeId { get; set; } 
    
        /// <summary>
    	/// 
    	/// </summary>
        
   
        public System.String DncType_Name { get; set; }

        
        /// <summary>
        /// 实际时间
        /// </summary>


        public DateTime? RealTime { get; set; } 
        
    
        /// <summary>
    	/// 燃烧0：正常 1：异常 吹灰0：正常 1：偏高 2：偏低
    	/// </summary>
        
   
        public System.Int32 Evalue { get; set; } 
        
    
        /// <summary>
    	/// 调整建议
    	/// </summary>
        
   
        public System.String Advice { get; set; }


        /// <summary>
        /// 调整确认时间
        /// </summary>

        public System.String CheckPerson { get; set; }
        public DateTime? CheckTime { get; set; } 
        
    
        /// <summary>
    	/// 备注
    	/// </summary>
        
   
        public System.String Remarks { get; set; } 
        
    
        /// <summary>
    	/// 
    	/// </summary>
        
    	public Dncboiler DncBoiler { get; set; } 
        public System.Int32 DncBoilerId { get; set; } 
    
        /// <summary>
    	/// 
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
