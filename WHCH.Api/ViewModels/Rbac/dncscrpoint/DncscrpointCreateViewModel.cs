using System;
using WHCH.Api.Entities.Enums;
using static WHCH.Api.Entities.Enums.CommonEnum;

namespace WHCH.Api.ViewModels.Rbac.Dncscrpoint
{
	public class DncscrpointCreateViewModel
	{
    
        public System.Int32 Id = 0;

        public System.String CheckPerson { get; set; }
        public DateTime? CheckTime { get; set; }
        /// <summary>
        /// 序号
        /// </summary>

        /// <summary>
        /// 实际时间
        /// </summary>


        public DateTime? RealTime { get; set; }


        /// <summary>
        /// 入口O2
        /// </summary>


        public System.Double O2_in { get; set; }


        /// <summary>
        /// 入口NOx
        /// </summary>


        public System.Double Nox_in { get; set; }


        /// <summary>
        /// 出口O2
        /// </summary>


        public System.Double O2_out { get; set; }


        /// <summary>
        /// 出口NOx
        /// </summary>


        public System.Double Nox_out { get; set; }


        /// <summary>
        /// 氨逃逸率
        /// </summary>


        public System.Double Nh3out { get; set; }


        /// <summary>
        /// 脱硝效率
        /// </summary>


        public System.Double Scr_ratio { get; set; }


        /// <summary>
        /// 催化剂寿命
        /// </summary>


        public System.Double Catalysts_life { get; set; }


        /// <summary>
        /// 调整建议
        /// </summary>


        public System.String Advice { get; set; }

        /// <summary>
        /// 点位ID
        /// </summary>
        public System.Int32 NameId_Val { get; set; } 
    	
	
    
        /// <summary>
    	/// 点位名称
    	/// </summary>
        public System.String K_Name_kw { get; set; } 
    	
	
    
        /// <summary>
    	/// X坐标
    	/// </summary>
        public System.Int32 X_axis_Val { get; set; } 
    	
	
    
        /// <summary>
    	/// Y坐标
    	/// </summary>
        public System.Int32 Y_axis_Val { get; set; } 
    	
	
    
        /// <summary>
    	/// 备注
    	/// </summary>
        public System.String Remarks { get; set; } 
    	
	
    
        /// <summary>
    	/// 当前状态
    	/// </summary>
        public System.Int32 NowStatus { get; set; } 
    	
	
    
        /// <summary>
    	/// 锅炉ID
    	/// </summary>
    	public System.String DncBoiler { get; set; } 
    	
	
    
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
