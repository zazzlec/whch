using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WHCH.Api.Entities;
using static WHCH.Api.Entities.Enums.CommonEnum;

namespace WHCH.Api.Entities
{
	[Serializable]
	public class Dncexpandgroup
	{

        /// <summary>
        /// 分组名称
        /// </summary>


        public System.String K_Name_kw { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        [Key,Required]
   
        public System.Int32 Id { get; set; } 
        
    
        /// <summary>
    	/// 组别
    	/// </summary>
        
   
        public System.Int32 GroupId { get; set; } 
        
    
        /// <summary>
    	/// X轴膨胀异常值
    	/// </summary>
        
   
        public System.Double X_errornum { get; set; } 
        
    
        /// <summary>
    	/// Y轴膨胀异常值
    	/// </summary>
        
   
        public System.Double Y_errornum { get; set; } 
        
    
        /// <summary>
    	/// Z轴膨胀异常值
    	/// </summary>
        
   
        public System.Double Z_errornum { get; set; } 
        
    
        /// <summary>
    	/// 备注
    	/// </summary>
        
   
        public System.String Remarks { get; set; } 
        
    
        /// <summary>
    	/// 锅炉ID
    	/// </summary>
        
    	public Dncboiler Dncboiler { get; set; } 
        public System.Int32 DncboilerId { get; set; } 
        public System.String Dncboiler_Name { get; set; } 
        
	
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
