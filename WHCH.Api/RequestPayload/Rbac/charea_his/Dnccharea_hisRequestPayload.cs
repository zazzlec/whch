
using static WHCH.Api.Entities.Enums.CommonEnum;

namespace WHCH.Api.RequestPayload.Rbac.Charea_his
{
    /// <summary>
    /// 
    /// </summary>
    public class Dnccharea_hisRequestPayload : RequestPayload
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

    }
}






