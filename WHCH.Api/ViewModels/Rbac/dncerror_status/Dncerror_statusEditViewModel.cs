using System;
using WHCH.Api.Entities.Enums;
using static WHCH.Api.Entities.Enums.CommonEnum;

namespace WHCH.Api.ViewModels.Rbac.Dncerror_status
{
	public class Dncerror_statusEditViewModel
	{
    
    
    
        /// <summary>
    	/// 序号
    	/// </summary>
        public System.Int64 Id { get; set; } 
	
    
        /// <summary>
    	/// 当前时间
    	/// </summary>
        public DateTime? RealTime { get; set; } 
	
    
        /// <summary>
    	/// 左切圆消旋动量不足
    	/// </summary>
        public System.Int32 Leftqy_xxbz { get; set; } 
	
    
        /// <summary>
    	/// 右切圆消旋动量不足
    	/// </summary>
        public System.Int32 Rightqy_xxbz { get; set; } 
	
    
        /// <summary>
    	/// 左切圆起旋动量不足
    	/// </summary>
        public System.Int32 Leftqy_qxbz { get; set; } 
	
    
        /// <summary>
    	/// 右切圆起旋动量不足
    	/// </summary>
        public System.Int32 Rightqy_qxbz { get; set; } 
	
    
        /// <summary>
    	/// 左切圆偏斜
    	/// </summary>
        public System.Int32 Leftqy_px { get; set; } 
	
    
        /// <summary>
    	/// 右切圆偏斜
    	/// </summary>
        public System.Int32 Rightqy_px { get; set; } 
	
    
        /// <summary>
    	/// 超限报警
    	/// </summary>
        public System.Int32 Cxbj { get; set; } 
	
    
        /// <summary>
    	/// 正常
    	/// </summary>
        public System.Int32 Normal { get; set; } 
	
    
        /// <summary>
    	/// 锅炉ID
    	/// </summary>
        public System.Int32 DncBoilerId { get; set; } 
	
    
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
