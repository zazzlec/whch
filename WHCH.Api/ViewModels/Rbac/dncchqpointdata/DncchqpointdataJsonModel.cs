using System;
using WHCH.Api.Entities.Enums;
using static WHCH.Api.Entities.Enums.CommonEnum;

namespace WHCH.Api.ViewModels.Rbac.Dncchqpointdata
{
	public class DncchqpointdataJsonModel
	{
    
    
    
        /// <summary>
    	/// 
    	/// </summary>
        public System.Int64 Id { get; set; } 
	
    
        /// <summary>
    	/// 吹灰器描述
    	/// </summary>
        public System.String Name_kw { get; set; } 
	
    
        /// <summary>
    	/// 备注
    	/// </summary>
        public System.String Remarks { get; set; } 
	
    
        /// <summary>
    	/// 锅炉ID
    	/// </summary>
    	public WHCH.Api.Entities.Dncboiler DncBoiler { get; set; } 
        public int DncBoilerId { get; set; } 
	
    
        /// <summary>
    	/// 锅炉名称
    	/// </summary>
        public System.String DncBoiler_Name { get; set; } 
	
    
        /// <summary>
    	/// 吹灰器状态id
    	/// </summary>
    	public WHCH.Api.Entities.Dncchstatus DncChstatus { get; set; } 
        public int DncChstatusId { get; set; } 
	
    
        /// <summary>
    	/// 吹灰器状态
    	/// </summary>
        public System.String DncChstatus_Name { get; set; } 
	
    
        /// <summary>
    	/// 上次吹灰结束时间
    	/// </summary>
        public DateTime? Lastchtime { get; set; } 
	
    
        /// <summary>
    	/// 位置：1水冷壁 2水平烟道 3尾部烟道
    	/// </summary>
        public System.Int32 Position { get; set; } 
	
    
        /// <summary>
    	/// 上次吹灰列表清空时差值
    	/// </summary>
        public System.Int32 Last_temp_dif_Val { get; set; } 
	
    
        /// <summary>
    	/// 当前温度差值
    	/// </summary>
        public System.Int32 Now_temp_dif_Val { get; set; } 
	
    
        /// <summary>
    	/// 水冷壁的层级
    	/// </summary>
        public System.Int32 Slb_floor_Val { get; set; } 
	
    
        /// <summary>
    	/// 水冷壁周期（1,2）
    	/// </summary>
        public System.Int32 Slb_circle_num { get; set; } 
	
    
        /// <summary>
    	/// 当前鳍片温度
    	/// </summary>
        public System.Int32 Now_temp_qp_Val { get; set; } 
	
    
        /// <summary>
    	/// 当前背火侧温度
    	/// </summary>
        public System.Int32 Now_temp_bh_Val { get; set; } 
	
    
        /// <summary>
    	/// 时间
    	/// </summary>
        public DateTime? Realtime { get; set; } 
	
	
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
