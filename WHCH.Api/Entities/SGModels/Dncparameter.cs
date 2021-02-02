using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WHCH.Api.Entities.Enums.CommonEnum;

namespace WHCH.Api.Entities
{
	[Serializable]
	public class Dncparameter
	{
    
    
    
        /// <summary>
    	/// 序号
    	/// </summary>
        [Key,Required]
   
        public System.Int32 Id { get; set; } 
        
    
        /// <summary>
    	/// 机组id
    	/// </summary>
        
    	public Dncboiler DncBoiler { get; set; } 
        public System.Int32 DncBoilerId { get; set; } 
    
        /// <summary>
    	/// 机组
    	/// </summary>
        
   
        public System.String DncBoiler_Name { get; set; } 
        
    
        /// <summary>
    	/// 大气压力
    	/// </summary>
        
   
        public System.Double Airpress { get; set; } 
        
    
        /// <summary>
    	/// 干球温度
    	/// </summary>
        
   
        public System.Double Drybulbtemp { get; set; } 
        
    
        /// <summary>
    	/// 湿球温度
    	/// </summary>
        
   
        public System.Double Wetbulbtemp { get; set; } 
        
    
        /// <summary>
    	/// 水的三相点绝对温度
    	/// </summary>
        
   
        public System.Double Watertemp3 { get; set; } 
        
    
        /// <summary>
    	/// 飞灰比率
    	/// </summary>
        
   
        public System.Double Flyashratio { get; set; } 
        
    
        /// <summary>
    	/// 大渣比率
    	/// </summary>
        
   
        public System.Double Slagratio { get; set; } 
        
    
        /// <summary>
    	/// 温度0Cp.H2O
    	/// </summary>
        
   
        public System.Double Temp0cp { get; set; } 
        
    
        /// <summary>
    	/// 温度100Cp.H2O
    	/// </summary>
        
   
        public System.Double Temp100cp { get; set; } 
        
    
        /// <summary>
    	/// 温度200Cp.H2O
    	/// </summary>
        
   
        public System.Double Temp200cp { get; set; } 
        
    
        /// <summary>
    	/// 温度0Ch
    	/// </summary>
        
   
        public System.Double Temp0ch { get; set; } 
        
    
        /// <summary>
    	/// 温度100Ch
    	/// </summary>
        
   
        public System.Double Temp100ch { get; set; } 
        
    
        /// <summary>
    	/// 温度200Ch
    	/// </summary>
        
   
        public System.Double Temp200ch { get; set; } 
        
    
        /// <summary>
    	/// 大渣比热
    	/// </summary>
        
   
        public System.Double Specificheat { get; set; } 
        
    
        /// <summary>
    	/// 散热损失
    	/// </summary>
        
   
        public System.Double Heatloss { get; set; } 
        
    
        /// <summary>
    	/// 空气比热
    	/// </summary>
        
   
        public System.Double Airheat { get; set; } 
        
    
        /// <summary>
    	/// 设计进口风温
    	/// </summary>
        
   
        public System.Double Design_in_wind_temp { get; set; } 
        
	
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
