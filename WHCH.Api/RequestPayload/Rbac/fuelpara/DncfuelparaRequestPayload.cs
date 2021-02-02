
using static WHCH.Api.Entities.Enums.CommonEnum;

namespace WHCH.Api.RequestPayload.Rbac.Fuelpara
{
    /// <summary>
    /// 
    /// </summary>
    public class DncfuelparaRequestPayload : RequestPayload
    {
        /// <summary>
        /// 是否已被删除
        /// </summary>
        public IsDeleted IsDeleted { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public Status Status { get; set; }
    }
}






