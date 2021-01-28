using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WHCH.Api.Entities.Enums.CommonEnum;

namespace WHCH.Api.Entities
{
	[Serializable]
	public class Dncexpand3d
	{
    
    
    
        /// <summary>
    	/// 序号
    	/// </summary>
        [Key,Required]
   
        public System.Int64 Id { get; set; } 
        
    
        /// <summary>
    	/// 点位ID
    	/// </summary>
        
    	public Dncexpand3d_base Dncexpand3d_base { get; set; } 
        public System.Int32 Dncexpand3d_baseId { get; set; } 
    
        /// <summary>
    	/// 点位名称
    	/// </summary>
        
   
        public System.String Dncexpand3d_base_Name { get; set; } 
        
    
        /// <summary>
    	/// 实际时间
    	/// </summary>
        
   
        public DateTime? RealTime { get; set; } 
        
    
        /// <summary>
    	/// X轴膨胀值
    	/// </summary>
        
   
        public System.Double R_X_expand { get; set; } 
        
    
        /// <summary>
    	/// Y轴膨胀值
    	/// </summary>
        
   
        public System.Double R_Y_expand { get; set; } 
        
    
        /// <summary>
    	/// Z轴膨胀值
    	/// </summary>
        
   
        public System.Double R_Z_expand { get; set; } 
        
    
        /// <summary>
    	/// 备注
    	/// </summary>
        
   
        public System.String Remarks { get; set; } 
        
    
        /// <summary>
    	/// 锅炉ID
    	/// </summary>
        
    	public Dncboiler DncBoiler { get; set; } 
        public System.Int32 DncBoilerId { get; set; } 
    
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
