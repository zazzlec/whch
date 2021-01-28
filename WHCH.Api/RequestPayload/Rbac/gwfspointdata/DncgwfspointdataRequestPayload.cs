
using static WHCH.Api.Entities.Enums.CommonEnum;

namespace WHCH.Api.RequestPayload.Rbac.Gwfspointdata
{
    /// <summary>
    /// 
    /// </summary>
    public class DncgwfspointdataRequestPayload : RequestPayload
    {
        /// <summary>
        /// 是否已被删除
        /// </summary>
        public IsDeleted IsDeleted { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public Status Status { get; set; }
        public string d1 { get; set; }
        public string d2 { get; set; }
        public string nid { get; set; }
    }
}






