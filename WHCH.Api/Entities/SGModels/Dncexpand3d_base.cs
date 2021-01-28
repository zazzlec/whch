
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WHCH.Api.Entities.Enums.CommonEnum;

namespace WHCH.Api.Entities
{
	[Serializable]
	public class Dncexpand3d_base
	{
    
    
    
        /// <summary>
    	/// 序号
    	/// </summary>
        [Key,Required]
   
        public System.Int32 Id { get; set; } 
        
    
        /// <summary>
    	/// 点位名称
    	/// </summary>
        
   
        public System.String K_Name_kw { get; set; } 
        
    
        /// <summary>
    	/// 点位号
    	/// </summary>
        
   
        public System.String R_GroupId { get; set; } 
        
    
        /// <summary>
    	/// X坐标
    	/// </summary>
        
   
        public System.Double R_X_axis { get; set; } 
        
    
        /// <summary>
    	/// Y坐标
    	/// </summary>
        
   
        public System.Double R_Y_axis { get; set; } 
        
    
        /// <summary>
    	/// X轴膨胀上限值
    	/// </summary>
        
   
        public System.Double R_X_up { get; set; } 
        
    
        /// <summary>
    	/// X轴膨胀下限值
    	/// </summary>
        
   
        public System.Double R_X_down { get; set; } 
        
    
        /// <summary>
    	/// Y轴膨胀上限值
    	/// </summary>
        
   
        public System.Double R_Y_up { get; set; } 
        
    
        /// <summary>
    	/// Y轴膨胀下限值
    	/// </summary>
        
   
        public System.Double R_Y_down { get; set; } 
        
    
        /// <summary>
    	/// Z轴膨胀上限值
    	/// </summary>
        
   
        public System.Double R_Z_up { get; set; } 
        
    
        /// <summary>
    	/// Z轴膨胀下限值
    	/// </summary>
        
   
        public System.Double R_Z_down { get; set; }


        public System.Double R_X_ed { get; set; }
        public System.Double R_Y_ed { get; set; }
        public System.Double R_Z_ed { get; set; }


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
        /// 分组号
        /// </summary>

        public Dncexpandgroup Dncexpandgroup { get; set; }
        public System.Int32 DncexpandgroupId { get; set; }

        /// <summary>
        /// 分组名称
        /// </summary>


        public System.String Dncexpandgroup_Name { get; set; }
        public System.String X_errornum { get; set; }
        public System.String Y_errornum { get; set; }
        public System.String Z_errornum { get; set; }
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
