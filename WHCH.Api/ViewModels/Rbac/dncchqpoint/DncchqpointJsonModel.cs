using System;
using WHCH.Api.Entities.Enums;
using static WHCH.Api.Entities.Enums.CommonEnum;

namespace WHCH.Api.ViewModels.Rbac.Dncchqpoint
{
	public class DncchqpointJsonModel
	{
    
    
    
        /// <summary>
    	/// 序号
    	/// </summary>
        public System.Int32 Id { get; set; } 
	
    
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
    	/// 吹灰区域ID
    	/// </summary>
    	public WHCH.Api.Entities.Dnccharea DncCharea { get; set; } 
        public int DncChareaId { get; set; } 
	
    
        /// <summary>
    	/// 
    	/// </summary>
        public System.String DncCharea_Name { get; set; } 
	
    
        /// <summary>
    	/// 锅炉ID
    	/// </summary>
    	public WHCH.Api.Entities.Dncboiler DncBoiler { get; set; } 
        public int DncBoilerId { get; set; } 
	
    
        /// <summary>
    	/// 锅炉名称
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
