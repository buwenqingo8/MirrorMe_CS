using APIManage.Domain;
using System.Collections.Generic;

namespace APIManage
{
    public interface IRequest<T> where T : Response
    {
        /// <summary>
        /// 获取请求方式
        /// </summary>
        RequestType Type { get; }

        /// <summary>
        /// 获取Api请求地址
        /// </summary>
        /// <returns></returns>
        string GetReqUrl { get; }

        /// <summary>
        /// 获取所有的Key-Value形式的文本请求参数字典。其中：
        /// Key: 请求参数名
        /// Value: 请求参数文本值
        /// </summary>
        /// <returns>文本请求参数字典</returns>
        IDictionary<string, string> GetParameters();

        /// <summary>
        /// 提前验证参数。
        /// </summary>
        void Validate();

        /// <summary>
        /// 将平台返回的HTML转化成MpResponse对象
        /// </summary>
        /// <param name="body">返回的HTML</param>
        /// <returns></returns>
        T ParseHtmlToResponse(string body);
    }

    public enum RequestType
    {
        Get,
        Post,
        Download,
        Upload,
    }
}
