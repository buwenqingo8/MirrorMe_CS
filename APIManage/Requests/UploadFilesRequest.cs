using APIManage.Responses;

using System.Collections.Generic;

namespace APIManage.Requests
{
    /// <summary>
    /// 上传多媒体文件请求
    /// </summary>
    public class UploadFilesRequest : RequestBase<UploadFilesResponse>, IRequest<UploadFilesResponse>
    {
        /// <summary>
        /// 调用接口凭证 
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// 媒体文件类型，分别有图片（image）、语音（voice）、视频（video）和缩略图（thumb）
        /// </summary>
        public string FileType { get; set; }

        /// <summary>
        /// 多媒体文件名
        /// </summary>
        public string FileName { get; set; }

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

        public UploadFilesResponse ParseHtmlToResponse(string body)
        {
            UploadFilesResponse response = new UploadFilesResponse();
            response.Body = body;

            //if (true)
            //{
            //    response.Type = JsonTools.GetJosnValue(body, "type");
            //    response.FileId = JsonTools.GetJosnValue(body, "media_id");
            //    response.FileId = JsonTools.GetJosnValue(body, "thumb_media_id");
            //    response.CreatedAt = JsonTools.GetJosnValue(body, "created_at");
            //}
            //else
            //{
            //    response.ErrInfo = new Domain.ErrInfo() { ErrMsg = "" };
            //}
            return response;
        }
    }
}
