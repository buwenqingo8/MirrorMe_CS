
namespace APIManage.Domain
{
    /// <summary>
    /// 接口调用返回码以及返回信息实体类
    /// </summary>
    public class ErrInfo
    {

        /// <summary>
        /// 返回码
        /// </summary>
        public string ErrCode { get; set; }

        /// <summary>
        /// 返回信息
        /// </summary>
        public string ErrMsg { get; set; }

        /// <summary>
        /// 异常消息
        /// </summary>
        public string ExMsg { get; set; }
    }
}
