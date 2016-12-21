using APIManage.Responses;
using System.Collections.Generic;

namespace APIManage.Requests
{
    /// <summary>
    /// 多媒体文件下载请求
    /// </summary>
    public class DownloadFilesRequest : RequestBase<DownloadFilesResponse>, IRequest<DownloadFilesResponse>
    {
        /// <summary>
        /// 调用接口凭证 
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// 文件ID
        /// </summary>
        public string FileId { get; set; }

        /// <summary>
        /// 下载后保存目录
        /// </summary>
        public string SaveDir { get; set; }

        public RequestType Type
        {
            get { throw new System.NotImplementedException(); }
        }

        public string GetReqUrl
        {
            get { throw new System.NotImplementedException(); }
        }

        public IDictionary<string, string> GetParameters()
        {
            throw new System.NotImplementedException();
        }

        public void Validate()
        {
            throw new System.NotImplementedException();
        }

        public DownloadFilesResponse ParseHtmlToResponse(string body)
        {
            DownloadFilesResponse response = new DownloadFilesResponse();
            response.Body = body;

            //if (true)
            //{
            //    response.SaveFilePath = body.Trim();
            //}
            //else
            //{
            //    response.ErrInfo = new Domain.ErrInfo() { ErrMsg = "" };
            //}
            return response;
        }

    }
}
