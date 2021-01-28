using System;
using WHCH.Api.Entities.Enums;
using static WHCH.Api.Entities.Enums.CommonEnum;

namespace WHCH.Api.ViewModels.Rbac.Dncgwfspointdata
{
	public class DncgwfspointdataEditViewModel
	{
        /// <summary>
        /// 腐蚀风险率（%）
        /// </summary>


        public System.Double Fsrisk { get; set; }


        /// <summary>
        /// 水冷壁寿命（%）
        /// </summary>


        public System.Double Slblife { get; set; }
        public System.String Remarks { get; set; }
        public System.Int32 NameId_Val { get; set; }
        /// <summary>
    	/// 序号
    	/// </summary>
        public System.Int32 Id { get; set; } 
	
    
        /// <summary>
    	/// 点位ID
    	/// </summary>
    	//public System.String DncGwfspoint { get; set; } 
	
    
        /// <summary>
    	/// 实际时间
    	/// </summary>
        public DateTime? RealTime { get; set; } 
	
    
        /// <summary>
    	/// H2S测点值
    	/// </summary>
        public System.Double H2s { get; set; } 
	
    
        /// <summary>
    	/// 锅炉ID
    	/// </summary>
    	public System.String DncBoiler { get; set; } 
	
    
        /// <summary>
    	/// 锅炉名称
    	/// </summary>
        public System.String DncBoiler_Name { get; set; } 
	
    
        /// <summary>
    	/// 调整建议
    	/// </summary>
        public System.String Advice { get; set; } 
	
    
        /// <summary>
    	/// 调整确认时间
    	/// </summary>
        public DateTime? CheckTime { get; set; } 
	
    
        /// <summary>
    	/// 确认人
    	/// </summary>
        public System.String CheckPerson { get; set; } 
	
	
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
