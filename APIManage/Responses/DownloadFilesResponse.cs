using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIManage.Responses
{
    /// <summary>
    /// 文件下载回应信息
    /// </summary>
    public class DownloadFilesResponse : Response
    {
        /// <summary>
        /// 下载文件保存路径
        /// </summary>
        public string SaveFilePath { get; set; }
    }
}
