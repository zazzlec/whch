using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WHCH.Api.Entities.Enums.CommonEnum;

namespace WHCH.Api.Entities
{
	[Serializable]
	public class Dncwinddata
	{
    
    
    
        /// <summary>
    	/// 编号
    	/// </summary>
        [Key,Required]
   
        public System.Int32 Id { get; set; } 
        
    
        /// <summary>
    	/// 风门Id
    	/// </summary>
        
    	public Dncwind DncWind { get; set; } 
        public System.Int32 DncWindId { get; set; } 
    
        /// <summary>
    	/// 风门名称
    	/// </summary>
        
   
        public System.String DncWind_Name { get; set; } 
        
    
        /// <summary>
    	/// 实际时间
    	/// </summary>
        
   
        public DateTime? RealTime { get; set; } 
        
    
        /// <summary>
    	/// 风门角度（实际工况）
    	/// </summary>
        
   
        public System.Int32 Real_angle { get; set; } 
        
    
        /// <summary>
    	/// 流通面积（实际工况）
    	/// </summary>
        
   
        public System.Double Real_ltmj { get; set; } 
        
    
        /// <summary>
    	/// 百分比（实际工况）
    	/// </summary>
        
   
        public System.Double Real_percent { get; set; } 
        
    
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
    	/// 备注
    	/// </summary>
        
   
        public System.String Remarks { get; set; } 
        
	
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
