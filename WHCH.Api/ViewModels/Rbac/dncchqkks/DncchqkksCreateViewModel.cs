using System;
using WHCH.Api.Entities.Enums;
using static WHCH.Api.Entities.Enums.CommonEnum;

namespace WHCH.Api.ViewModels.Rbac.Dncchqkks
{
	public class DncchqkksCreateViewModel
	{
    
        public System.Int32 Id = 0;
        
    
        /// <summary>
    	/// 序号
    	/// </summary>
    	
	
    
        /// <summary>
    	/// 名称描述
    	/// </summary>
        public System.String Name_kw { get; set; } 
    	
	
    
        /// <summary>
    	/// KKS编号
    	/// </summary>
        public System.String Kkscode { get; set; } 
    	
	
    
        /// <summary>
    	/// 吹灰器描述
    	/// </summary>
        public System.String Kkscode_50 { get; set; } 
    	
	
    
        /// <summary>
    	/// 锅炉ID
    	/// </summary>
    	public WHCH.Api.Entities.Dncboiler DncBoiler { get; set; } 
    	
	
    
        /// <summary>
    	/// 锅炉名称
    	/// </summary>
        public System.String DncBoiler_Name { get; set; } 
    	
	
    
        /// <summary>
    	/// 吹灰器编号
    	/// </summary>
        public System.String Chq_name { get; set; } 
    	
	
    
        /// <summary>
    	/// DCS系统中的编号
    	/// </summary>
        public System.String Dcs_name { get; set; } 
    	
	
    
        /// <summary>
    	/// 备注
    	/// </summary>
        public System.String Remarks { get; set; } 
    	
	
    
        /// <summary>
    	/// 吹灰状态
    	/// </summary>
        public System.Int32 Chstatus { get; set; } 
    	
	
    
        /// <summary>
    	/// 前进/后退
    	/// </summary>
        public System.Int32 Updown { get; set; } 
    	
	
    
        /// <summary>
    	/// 实际时间
    	/// </summary>
        public DateTime? RealTime { get; set; } 
    	
	
    
        /// <summary>
    	/// 测点数值
    	/// </summary>
        public System.Double Pvalue { get; set; } 
    	
	
	
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
