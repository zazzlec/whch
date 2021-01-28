using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WHCH.Api.Entities.Enums.CommonEnum;

namespace WHCH.Api.Entities
{
	[Serializable]
	public class Dnckyqconfig
	{
        /// <summary>
        /// 温差
        /// </summary>


        public System.Single TemperatureDifference { get; set; }
        /// <summary>
        /// 漏风率偏大值
        /// </summary>


        public System.Single Lfl_High_Val { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Key,Required]
   
        public System.Int32 Id { get; set; } 
        
    
        /// <summary>
    	/// 空预器额定电流
    	/// </summary>
        
   
        public System.Single Eddl_Val { get; set; } 
        
    
        /// <summary>
    	/// 支承轴承油温偏高值
    	/// </summary>
        
   
        public System.Single Zczc_Oiltemp_Warn_Val { get; set; } 
        
    
        /// <summary>
    	/// 支承轴承油温偏报警值
    	/// </summary>
        
   
        public System.Single Zczc_Oiltemp_High_Val { get; set; } 
        
    
        /// <summary>
    	/// 导向轴承油温偏高值
    	/// </summary>
        
   
        public System.Single Dxzc_Oiltemp_Warn_Val { get; set; } 
        
    
        /// <summary>
    	/// 导向轴承油温报警值
    	/// </summary>
        
   
        public System.Single Dxzc_Oiltemp_High_Val { get; set; } 
        
    
        /// <summary>
    	/// 支承/导向轴承润滑油压差
    	/// </summary>
        
   
        public System.Single Oil_Press_Dif_Val { get; set; } 
        
    
        /// <summary>
    	/// 空气预热器转速下限报警值
    	/// </summary>
        
   
        public System.Single Kyq_Speed_Low_Val { get; set; } 
        
    
        /// <summary>
    	/// 密封间隙检测
    	/// </summary>
        
   
        public System.Int32 Mfjx_Test { get; set; } 
        
    
        /// <summary>
    	/// 漏风率设计值
    	/// </summary>
        
   
        public System.Single Ifl_Design_Val { get; set; } 
        
    
        /// <summary>
    	/// 热端吹灰器蒸汽压力上限
    	/// </summary>
        
   
        public System.Single Hot_Chq_Press_High_Val { get; set; } 
        
    
        /// <summary>
    	/// 热端吹灰器蒸汽压力下限
    	/// </summary>
        
   
        public System.Single Hot_Chq_Press_Low_Val { get; set; } 
        
    
        /// <summary>
    	/// 冷端吹灰器蒸汽压力上限
    	/// </summary>
        
   
        public System.Single Cold_Chq_Press_High_Val { get; set; } 
        
    
        /// <summary>
    	/// 冷端吹灰器蒸汽压力下限
    	/// </summary>
        
   
        public System.Single Cold_Chq_Press_Low_Val { get; set; } 
        
    
        /// <summary>
    	/// 吹灰器蒸汽温度下限
    	/// </summary>
        
   
        public System.Single Chq_Temp_Low_Val { get; set; } 
        
    
        /// <summary>
    	/// 高压水水泵压力上限
    	/// </summary>
        
   
        public System.Single Gysb_Press_High_Val { get; set; } 
        
    
        /// <summary>
    	/// 高压水水泵压力下限
    	/// </summary>
        
   
        public System.Single Gysb_Press_Low_Val { get; set; }



        /// <summary>
        /// 烟空气阻力偏大值
        /// </summary>
        public System.Single Gasair_Res_High_Val { get; set; }


        /// <summary>
        /// 烟空气阻力初始值
        /// </summary>
        public System.Single Gasair_Res_Ini_Val { get; set; }

        /// <summary>
        /// 沉积区域A
        /// </summary>


        public System.Single CJQY_A { get; set; }


        /// <summary>
        /// 沉积区域B
        /// </summary>


        public System.Single CJQY_B { get; set; }


        /// <summary>
        /// 沉积区域K
        /// </summary>


        public System.Single CJQY_K { get; set; }


        /// <summary>
        /// 沉积区域峰值
        /// </summary>


        public System.Single CJQY_Up { get; set; }


        /// <summary>
        /// 沉积区域谷值
        /// </summary>


        public System.Single CJQY_Down { get; set; }


        /// <summary>
        /// 效率下限
        /// </summary>
        public System.Single Xl_Low { get; set; }

        /// <summary>
        /// 寿命下限
        /// </summary>
        public System.Single Life_Low { get; set; }

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
        /// 是否可用(0:禁用,1:可用)
        /// </summary>
        public Status Status { get; set; }
        /// <summary>
        /// 是否已删
        /// </summary>
        public IsDeleted IsDeleted { get; set; }
		
	}
}
