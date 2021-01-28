using System;
using WHCH.Api.Entities.Enums;
using static WHCH.Api.Entities.Enums.CommonEnum;

namespace WHCH.Api.ViewModels.Rbac.Dncboiler
{
	public class DncboilerCreateViewModel
	{
    
        public System.Int32 Id = 0;


        /// <summary>
        /// 序号
        /// </summary>

        /// <summary>
        /// 运行状态（0：停机 1：运行）
        /// </summary>


        public System.Int32 NowStatus { get; set; }


        /// <summary>
        /// 状态更新时间
        /// </summary>


        public DateTime? Sta_time { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String K_Name_kw { get; set; } 
    	
	
    
        /// <summary>
    	/// 最新同步时间
    	/// </summary>
        public DateTime? Syntime { get; set; } 
    	
	
    
        /// <summary>
    	/// 
    	/// </summary>
        public System.String Remarks { get; set; } 
    	
	
    
        /// <summary>
    	/// 额定负荷（MW）
    	/// </summary>
        public System.Int32 Edfh { get; set; }

        /// <summary>
        /// 巡测取值数
        /// </summary>
        public System.Int32 CircleNum { get; set; }

        /// <summary>
        /// 是否可用(0:禁用,1:可用)
        /// </summary>
        public Status Status { get; set; }
        /// <summary>
        /// 是否已删
        /// </summary>
        public IsDeleted IsDeleted { get; set; }

        public System.Int32 Ch_Run { get; set; }
        public DateTime? Ch_StartTime { get; set; }
        public DateTime? Ch_EndTime { get; set; }
    }
}
