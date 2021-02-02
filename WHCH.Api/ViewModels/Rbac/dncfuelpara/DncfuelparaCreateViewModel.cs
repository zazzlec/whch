using System;
using WHCH.Api.Entities.Enums;
using static WHCH.Api.Entities.Enums.CommonEnum;

namespace WHCH.Api.ViewModels.Rbac.Dncfuelpara
{
	public class DncfuelparaCreateViewModel
	{
    
        public System.Int32 Id = 0;
        
    
        /// <summary>
    	/// 序号
    	/// </summary>
    	
	
    
        /// <summary>
    	/// 机组id
    	/// </summary>
    	public WHCH.Api.Entities.Dncboiler DncBoiler { get; set; } 
        public int DncBoilerId { get; set; }
    	
	
    
        /// <summary>
    	/// 机组
    	/// </summary>
        public System.String DncBoiler_Name { get; set; } 
    	
	
    
        /// <summary>
    	/// 碳(收到基)
    	/// </summary>
        public System.Double Carbon { get; set; } 
    	
	
    
        /// <summary>
    	/// 氢(收到基)
    	/// </summary>
        public System.Double Hydrogen { get; set; } 
    	
	
    
        /// <summary>
    	/// 氧(收到基)
    	/// </summary>
        public System.Double O2 { get; set; } 
    	
	
    
        /// <summary>
    	/// 水的三相点绝对温度
    	/// </summary>
        public System.Double Watertemp3 { get; set; } 
    	
	
    
        /// <summary>
    	/// 氮(收到基)
    	/// </summary>
        public System.Double Nitrogen { get; set; } 
    	
	
    
        /// <summary>
    	/// 硫(收到基)
    	/// </summary>
        public System.Double Sulfur { get; set; } 
    	
	
    
        /// <summary>
    	/// 水分(收到基)
    	/// </summary>
        public System.Double H2o { get; set; } 
    	
	
    
        /// <summary>
    	/// 灰分(收到基)
    	/// </summary>
        public System.Double Ashcontent { get; set; } 
    	
	
    
        /// <summary>
    	/// 飞灰可燃物（含碳量）
    	/// </summary>
        public System.Double Flyashfuel { get; set; } 
    	
	
    
        /// <summary>
    	/// 大渣可燃物（含碳量）
    	/// </summary>
        public System.Double Cinderfuel { get; set; } 
    	
	
    
        /// <summary>
    	/// AH出口一氧化碳
    	/// </summary>
        public System.Double Co { get; set; } 
    	
	
    
        /// <summary>
    	/// 收到基低位发热量
    	/// </summary>
        public System.Double Calorificvalue { get; set; } 
    	
	
    
        /// <summary>
    	/// 入炉燃料量
    	/// </summary>
        public System.Double Chargingfuel { get; set; } 
    	
	
    
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
