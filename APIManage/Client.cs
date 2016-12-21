using APIManage.Requests;

using System;
using System.Collections.Generic;
using Util;

namespace APIManage
{
    public class Client : IClient
    {
        /// <summary>
        /// 执行API请求
        /// </summary>
        /// <typeparam name="T">对象</typeparam>
        /// <param name="request">具体的请求</param>
        /// <returns>对象</returns>
        public T Execute<T>(IRequest<T> request) where T : Response
        {
            try
            {
                string body = string.Empty;
                WebUtils webUtils = new WebUtils();

                request.Validate();
                switch (request.Type)
                {
                    case RequestType.Get:
                        body = webUtils.DoGet(request.GetReqUrl, request.GetParameters());
                        break;
                    case RequestType.Post:
                        body = webUtils.DoPost(request.GetReqUrl, request.GetParameters());
                        break;
                    case RequestType.Download:
                        string fileName = string.Empty;
                        string errHtml = string.Empty;
                        bool isSuc = webUtils.DownloadFile(request.GetReqUrl, (request as DownloadFilesRequest).SaveDir, out fileName, out errHtml);
                        if (isSuc)
                        {
                            body = fileName;
                        }
                        else
                        {
                            body = errHtml;
                        }
                        break;
                    case RequestType.Upload:
                        Dictionary<string, FileItem> files = new Dictionary<string, FileItem>();
                        FileItem fileItem = new FileItem((request as UploadFilesRequest).FileName);
                        files.Add(Guid.NewGuid().ToString(), fileItem);
                        body = webUtils.DoPost(request.GetReqUrl, request.GetParameters(), files);
                        break;
                    default:
                        break;
                }
                if (string.IsNullOrWhiteSpace(body)) return null;

                //解析获取的字符串
                return request.ParseHtmlToResponse(body);
            }
            catch (Exception ex)
            {
                return request.ParseHtmlToResponse("{\"Exception\":\"" + ex.Message + "\"}");
            }
        }
    }
}
