using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WHCH.Api.Entities.Enums.CommonEnum;

namespace WHCH.Api.Entities
{
	[Serializable]
	public class Dncchpoint_wrl
	{
    
    
    
        /// <summary>
    	/// 序号
    	/// </summary>
        [Key,Required]
   
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
    	/// 吹灰器ID
    	/// </summary>
        
    	public Dncchqpoint DncChqpoint { get; set; } 
        public System.Int32 DncChqpointId { get; set; } 
    
        /// <summary>
    	/// 
    	/// </summary>
        
   
        public System.String DncChqpoint_Name { get; set; } 
        
    
        /// <summary>
    	/// 吹灰区域ID
    	/// </summary>
        
    	public Dnccharea DncCharea { get; set; } 
        public System.Int32 DncChareaId { get; set; } 
    
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
        
    	public Dncboiler DncBoiler { get; set; } 
        public System.Int32 DncBoilerId { get; set; } 
    
        /// <summary>
    	/// 锅炉名称
    	/// </summary>
        
   
        public System.String DncBoiler_Name { get; set; } 
        
    
        /// <summary>
    	/// 吹灰类型ID
    	/// </summary>
        
    	public Dncchtype DncChtype { get; set; } 
        public System.Int32 DncChtypeId { get; set; } 
    
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
