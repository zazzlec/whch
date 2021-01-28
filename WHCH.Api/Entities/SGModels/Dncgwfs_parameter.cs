using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WHCH.Api.Entities.Enums.CommonEnum;

namespace WHCH.Api.Entities
{
	[Serializable]
	public class Dncgwfs_parameter
	{

        public System.Int32 h2s_alert { get; set; }
        public System.Int32 h2s_high { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
        [Key,Required]
   
        public System.Int32 Id { get; set; } 
        
    
        /// <summary>
    	/// 材料系数
    	/// </summary>
        
   
        public System.Double Clxs { get; set; } 
        
    
        /// <summary>
    	/// 温度系数
    	/// </summary>
        
   
        public System.Double Wdxs { get; set; } 
        
    
        /// <summary>
    	/// 周期（小时）
    	/// </summary>
        
   
        public System.Double Circle { get; set; } 
        
    
        /// <summary>
    	/// 巡测时间（小时）
    	/// </summary>
        
   
        public System.Double Cir_time { get; set; } 
        
    
        /// <summary>
    	/// 密度（kg/m3）
    	/// </summary>
        
   
        public System.Double Density { get; set; } 
        
    
        /// <summary>
    	/// PBR
    	/// </summary>
        
   
        public System.Double Pbr { get; set; } 
        
    
        /// <summary>
    	/// 锅炉ID
    	/// </summary>
        
    	public Dncboiler DncBoiler { get; set; } 
        public System.Int32 DncBoilerId { get; set; } 
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
