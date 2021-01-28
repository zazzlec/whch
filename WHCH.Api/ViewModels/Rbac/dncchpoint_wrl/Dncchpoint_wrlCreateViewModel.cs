using System;
using WHCH.Api.Entities.Enums;
using static WHCH.Api.Entities.Enums.CommonEnum;

namespace WHCH.Api.ViewModels.Rbac.Dncchpoint_wrl
{
	public class Dncchpoint_wrlCreateViewModel
	{
    
        public System.Int32 Id = 0;
        
    
        /// <summary>
    	/// 序号
    	/// </summary>
    	
	
    
        /// <summary>
    	/// 吹灰器描述
    	/// </summary>
        public System.String Name_kw { get; set; } 
    	
	
    
        /// <summary>
    	/// 备注
    	/// </summary>
        public System.String Remarks { get; set; } 
    	
	
    
        /// <summary>
    	/// 当前时间
    	/// </summary>
        public DateTime? RealTime { get; set; } 
    	
	
    
        /// <summary>
    	/// 吹灰器ID
    	/// </summary>
    	public WHCH.Api.Entities.Dncchqpoint DncChqpoint { get; set; } 
    	
	
    
        /// <summary>
    	/// 
    	/// </summary>
        public System.String DncChqpoint_Name { get; set; } 
    	
	
    
        /// <summary>
    	/// 吹灰区域ID
    	/// </summary>
    	public WHCH.Api.Entities.Dnccharea DncCharea { get; set; } 
    	
	
    
        /// <summary>
    	/// 
    	/// </summary>
        public System.String DncCharea_Name { get; set; } 
    	
	
    
        /// <summary>
    	/// 污染率
    	/// </summary>
        public System.Double Wrl_Val { get; set; } 
    	
	
    
        /// <summary>
    	/// 污染率上限
    	/// </summary>
        public System.Double Wrlhigh_Val { get; set; } 
    	
	
    
        /// <summary>
    	/// 上次吹灰列表清空时差值
    	/// </summary>
        public System.Single Last_temp_dif_Val { get; set; } 
    	
	
    
        /// <summary>
    	/// 当前温度差值
    	/// </summary>
        public System.Single Now_temp_dif_Val { get; set; } 
    	
	
    
        /// <summary>
    	/// 某层方差
    	/// </summary>
        public System.Double Dx_temp_dif_Val { get; set; } 
    	
	
    
        /// <summary>
    	/// 锅炉ID
    	/// </summary>
    	public WHCH.Api.Entities.Dncboiler DncBoiler { get; set; } 
    	
	
    
        /// <summary>
    	/// 锅炉名称
    	/// </summary>
        public System.String DncBoiler_Name { get; set; } 
    	
	
    
        /// <summary>
    	/// 吹灰类型ID
    	/// </summary>
    	public WHCH.Api.Entities.Dncchtype DncChtype { get; set; } 
    	
	
    
        /// <summary>
    	/// 吹灰类型名称
    	/// </summary>
        public System.String DncChtype_Name { get; set; } 
    	
	
	
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
