using System;
using WHCH.Api.Entities.Enums;
using static WHCH.Api.Entities.Enums.CommonEnum;

namespace WHCH.Api.ViewModels.Rbac.Dnccharea
{
	public class DncchareaJsonModel
	{
    
    
    
        /// <summary>
    	/// 序号
    	/// </summary>
        public System.Int32 Id { get; set; } 
	
    
        /// <summary>
    	/// 区域描述
    	/// </summary>
        public System.String Name_kw { get; set; } 
	
    
        /// <summary>
    	/// 备注
    	/// </summary>
        public System.String Remarks { get; set; } 
	
    
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
    	/// 污染率
    	/// </summary>
        public System.Double Wrl_Val { get; set; } 
	
    
        /// <summary>
    	/// 污染率待吹灰上限
    	/// </summary>
        public System.Double Wrldch_Val { get; set; } 
	
    
        /// <summary>
    	/// 污染率执行上限
    	/// </summary>
        public System.Double Wrlexec_Val { get; set; } 
	
    
        /// <summary>
    	/// 堵塞率
    	/// </summary>
        public System.Double Dsl_Val { get; set; } 
	
    
        /// <summary>
    	/// 堵塞率待吹灰上限
    	/// </summary>
        public System.Double Dslhigh_Val { get; set; } 
	
    
        /// <summary>
    	/// 堵塞率执行上限
    	/// </summary>
        public System.Double Dslexec_Val { get; set; } 
	
    
        /// <summary>
    	/// 参考温升
    	/// </summary>
        public System.Double Ckws_Val { get; set; } 
	
    
        /// <summary>
    	/// 参考压降
    	/// </summary>
        public System.Double Ckyj_Val { get; set; } 
	
    
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
