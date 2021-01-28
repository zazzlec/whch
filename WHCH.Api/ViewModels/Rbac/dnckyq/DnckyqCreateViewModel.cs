using System;
using WHCH.Api.Entities.Enums;
using static WHCH.Api.Entities.Enums.CommonEnum;

namespace WHCH.Api.ViewModels.Rbac.Dnckyq
{
	public class DnckyqCreateViewModel
	{
    
        public System.Int32 Id = 0;
        
    
        /// <summary>
    	/// 
    	/// </summary>
    	
	
    
        /// <summary>
    	/// 空预器名称
    	/// </summary>
        public System.String K_Name_kw { get; set; } 
    	
	
    
        /// <summary>
    	/// 开口方向
    	/// </summary>
        public System.Int32 LR { get; set; } 
    	
	
    
        /// <summary>
    	/// 转动方向
    	/// </summary>
        public System.Int32 Way { get; set; } 
    	
	
    
        /// <summary>
    	/// 锅炉ID
    	/// </summary>
    	public WHCH.Api.Entities.Dncboiler DncBoiler { get; set; } 
    	
	
    
        /// <summary>
    	/// 锅炉描述
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
