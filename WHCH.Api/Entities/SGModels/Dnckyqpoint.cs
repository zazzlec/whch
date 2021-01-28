using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WHCH.Api.Entities.Enums.CommonEnum;

namespace WHCH.Api.Entities
{
	[Serializable]
	public class Dnckyqpoint
	{
    
    
    
        /// <summary>
    	/// 
    	/// </summary>
        [Key,Required]
   
        public System.Int32 Id { get; set; } 
        
    
        /// <summary>
    	/// 类型
    	/// </summary>
        
    	public Dnckyqtype DncKyqTpye { get; set; } 
        public System.Int32 DncKyqTpyeId { get; set; } 
    
        /// <summary>
    	/// 类型
    	/// </summary>
        
   
        public System.String DncKyqTpye_Name { get; set; }


        /// <summary>
        /// 测点值
        /// </summary>


        public System.String Pval { get; set; }


        /// <summary>
        /// 类型
        /// </summary>


        public System.Single Point_Val { get; set; }


        /// <summary>
        /// 锅炉ID
        /// </summary>

        public Dncboiler DncBoiler { get; set; } 
        public System.Int32 DncBoilerId { get; set; } 
    
        /// <summary>
    	/// 锅炉描述
    	/// </summary>
        
   
        public System.String DncBoiler_Name { get; set; }
        /// <summary>
        /// 空预器Id
        /// </summary>

        public Dnckyq DncKyq { get; set; }
        public System.Int32 DncKyqId { get; set; }

        /// <summary>
        /// 
        /// </summary>


        public System.String DncKyq_Name { get; set; }

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
