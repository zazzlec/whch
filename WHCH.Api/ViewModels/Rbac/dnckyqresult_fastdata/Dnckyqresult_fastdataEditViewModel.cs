using System;
using WHCH.Api.Entities.Enums;
using static WHCH.Api.Entities.Enums.CommonEnum;

namespace WHCH.Api.ViewModels.Rbac.Dnckyqresult_fastdata
{
	public class Dnckyqresult_fastdataEditViewModel
	{
    
    
    
        /// <summary>
    	/// 
    	/// </summary>
        public System.Int32 Id { get; set; } 
	
    
        /// <summary>
    	/// 实际时间
    	/// </summary>
        public DateTime? RealTime { get; set; } 
	
    
        /// <summary>
    	/// 备注
    	/// </summary>
        public System.String Remark { get; set; } 
	
    
        /// <summary>
    	/// 锅炉ID
    	/// </summary>
    	public System.String DncBoiler { get; set; } 
	
    
        /// <summary>
    	/// 锅炉描述
    	/// </summary>
        public System.String DncBoiler_Name { get; set; } 
	
    
        /// <summary>
    	/// 漏风控制系统运行状态
    	/// </summary>
        public System.Int32 Lcs_Status { get; set; } 
	
    
        /// <summary>
    	/// 空预器运行电流
    	/// </summary>
        public System.Single Kyq_Run_Dl_Val { get; set; } 
	
    
        /// <summary>
    	/// 空气预热器转速
    	/// </summary>
        public System.Single Kyq_Speed_Val { get; set; } 
	
    
        /// <summary>
    	/// 运行密封间隙
    	/// </summary>
        public System.Single Mfjx_Val { get; set; } 
	
    
        /// <summary>
    	/// 烟气出口氧量
    	/// </summary>
        public System.Single Gas_O2_Out_Val { get; set; } 
	
    
        /// <summary>
    	/// 烟气入口氧量
    	/// </summary>
        public System.Single Gas_O2_In_Val { get; set; } 
	
    
        /// <summary>
    	/// 漏风率
    	/// </summary>
        public System.Single Wind_Out_Radio_Val { get; set; } 
	
    
        /// <summary>
    	/// 烟气侧入口压力
    	/// </summary>
        public System.Single Gas_Press_In_Val { get; set; } 
	
    
        /// <summary>
    	/// 烟气侧出口压力
    	/// </summary>
        public System.Single Gas_Press_Out_Val { get; set; } 
	
    
        /// <summary>
    	/// 一次风进口压力
    	/// </summary>
        public System.Single Wind1_Press_In_Val { get; set; } 
	
    
        /// <summary>
    	/// 一次风出口压力
    	/// </summary>
        public System.Single Wind1_Press_Out_Val { get; set; } 
	
    
        /// <summary>
    	/// 二次风进口压力
    	/// </summary>
        public System.Single Wind2_Press_In_Val { get; set; } 
	
    
        /// <summary>
    	/// 二次风出口压力
    	/// </summary>
        public System.Single Wind2_Press_Out_Val { get; set; } 
	
    
        /// <summary>
    	/// 烟气侧阻力
    	/// </summary>
        public System.Single Res_Gas_Val { get; set; } 
	
    
        /// <summary>
    	/// 一次风空气阻力
    	/// </summary>
        public System.Single Res_Wind1_Val { get; set; } 
	
    
        /// <summary>
    	/// 二次风空气阻力
    	/// </summary>
        public System.Single Res_Wind2_Val { get; set; } 
	
    
        /// <summary>
    	/// 热端吹灰器蒸汽压力
    	/// </summary>
        public System.Single Chq_Press_Hot_Val { get; set; } 
	
    
        /// <summary>
    	/// 冷端吹灰器蒸汽压力
    	/// </summary>
        public System.Single Chq_Press_Cold_Val { get; set; } 
	
    
        /// <summary>
    	/// 热端吹灰器蒸汽温度
    	/// </summary>
        public System.Single Chq_Temp_Hot_Val { get; set; } 
	
    
        /// <summary>
    	/// 冷端吹灰器蒸汽温度
    	/// </summary>
        public System.Single Chq_Temp_Cold_Val { get; set; } 
	
    
        /// <summary>
    	/// 高压水水泵运行压力
    	/// </summary>
        public System.Single Gysb_Press_Val { get; set; } 
	
    
        /// <summary>
    	/// 空预器Id
    	/// </summary>
    	public System.String DncKyq { get; set; } 
	
    
        /// <summary>
    	/// 
    	/// </summary>
        public System.String DncKyq_Name { get; set; } 
	
    
        /// <summary>
    	/// 减速箱温度
    	/// </summary>
        public System.Single ReductionBoxTemperature { get; set; } 
	
    
        /// <summary>
    	/// 环境温度
    	/// </summary>
        public System.Single EnvironmentTemperature { get; set; } 
	
    
        /// <summary>
    	/// lcs运行模式
    	/// </summary>
        public System.Int32 LcsRunMode { get; set; } 
	
    
        /// <summary>
    	/// 1号扇形板位置

    	/// </summary>
        public System.Single FanShapedPlateP1 { get; set; } 
	
    
        /// <summary>
    	/// 2号扇形板位置
    	/// </summary>
        public System.Single FanShapedPlateP2 { get; set; } 
	
    
        /// <summary>
    	/// 3号扇形板位置
    	/// </summary>
        public System.Single FanShapedPlateP3 { get; set; } 
	
    
        /// <summary>
    	/// 1号扇形板状态
    	/// </summary>
        public System.Int32 FanShapedPlateS1 { get; set; } 
	
    
        /// <summary>
    	/// 2号扇形板状态
    	/// </summary>
        public System.Int32 FanShapedPlateS2 { get; set; } 
	
    
        /// <summary>
    	/// 3号扇形板状态
    	/// </summary>
        public System.Int32 FanShapedPlateS3 { get; set; } 
	
    
        /// <summary>
    	/// 1号提升装置状态
    	/// </summary>
        public System.Int32 LiftingDeviceS1 { get; set; } 
	
    
        /// <summary>
    	/// 2号提升装置状态
    	/// </summary>
        public System.Int32 LiftingDeviceS2 { get; set; } 
	
    
        /// <summary>
    	/// 3号提升装置状态

    	/// </summary>
        public System.Int32 LiftingDeviceS3 { get; set; } 
	
	
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
