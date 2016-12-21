using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIManage.Responses
{
    /// <summary>
    /// 文件上传回应信息
    /// </summary>
    public class UploadFilesResponse : Response
    {
        /// <summary>
        /// 文件类型，分别有图片（image）、语音（voice）、视频（video）和缩略图（thumb，主要用于视频与音乐格式的缩略图） 
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 文件上传后，获取时的唯一标识 
        /// </summary>
        public string FileId { get; set; }

        /// <summary>
        /// 文件上传时间戳
        /// </summary>
        public string CreatedAt { get; set; }
    }
}
