using System;
using WHCH.Api.Entities.Enums;
using static WHCH.Api.Entities.Enums.CommonEnum;

namespace WHCH.Api.ViewModels.Rbac.Dncexpandgroup
{
	public class DncexpandgroupEditViewModel
	{

        /// <summary>
        /// 分组名称
        /// </summary>


        public System.String K_Name_kw { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        public System.Int32 Id { get; set; } 
	
    
        /// <summary>
    	/// 组别
    	/// </summary>
        public System.Int32 GroupId { get; set; } 
	
    
        /// <summary>
    	/// X轴膨胀异常值
    	/// </summary>
        public System.Double X_errornum { get; set; } 
	
    
        /// <summary>
    	/// Y轴膨胀异常值
    	/// </summary>
        public System.Double Y_errornum { get; set; } 
	
    
        /// <summary>
    	/// Z轴膨胀异常值
    	/// </summary>
        public System.Double Z_errornum { get; set; } 
	
    
        /// <summary>
    	/// 备注
    	/// </summary>
        public System.String Remarks { get; set; } 
	
    
        /// <summary>
    	/// 锅炉ID
    	/// </summary>
    	public System.String Dncboiler { get; set; } 
	
    
        /// <summary>
    	/// 锅炉名称
    	/// </summary>
        public System.String Dncboiler_Name { get; set; } 
	
	
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
