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
        public System.Double Cw_High { get; set; }
        public System.Double Cw_Low { get; set; }
        public System.Double Bw_dg { get; set; }
        public System.Double Bw_pg { get; set; }
        public System.Double Bw_gg { get; set; }


        /// <summary>
        /// 锅炉名称
        /// </summary>
        public System.String K_Name_kw { get; set; } 
    	
	
    
        /// <summary>
    	/// 最新同步时间
    	/// </summary>
        public DateTime? Syntime { get; set; } 
    	
	
    
        /// <summary>
    	/// 备注
    	/// </summary>
        public System.String Remarks { get; set; } 
    	
	
    
        /// <summary>
    	/// 额定负荷（MW）
    	/// </summary>
        public System.Int32 Edfh { get; set; } 
    	
	
    
        /// <summary>
    	/// 运行状态（0：停机 1：运行）
    	/// </summary>
        public System.Int32 NowStatus { get; set; } 
    	
	
    
        /// <summary>
    	/// 吹灰列表清空负荷
    	/// </summary>
        public System.Int32 Fh_Chlistrun { get; set; } 
    	
	
    
        /// <summary>
    	/// 是否正在执行吹灰
    	/// </summary>
        public System.Int32 Ch_Run { get; set; } 
    	
	
    
        /// <summary>
    	/// 吹灰开始时间
    	/// </summary>
        public DateTime? Ch_StartTime { get; set; } 
    	
	
    
        /// <summary>
    	/// 吹灰结束时间
    	/// </summary>
        public DateTime? Ch_EndTime { get; set; } 
    	
	
    
        /// <summary>
    	/// 正平衡效率
    	/// </summary>
        public System.Double Positive { get; set; } 
    	
	
    
        /// <summary>
    	/// 反平衡效率
    	/// </summary>
        public System.Double Counter { get; set; } 
    	
	
	
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
