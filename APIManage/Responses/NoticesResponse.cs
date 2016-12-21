using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APIManage.Responses
{
    public class NoticesResponse : Response
    {
        public class NoticeInfo
        {
            public string success { get; set; }
            public List<NoticeDetail> noticeList { get; set; }
        }

        public class NoticeDetail
        {
            /// <summary>
            /// 公告内容
            /// </summary>
            public string content { get; set; }

            /// <summary>
            /// 公告标题
            /// </summary>
            public string title { get; set; }

            /// <summary>
            /// 公告标题
            /// </summary>
            public string id { get; set; }

            /// <summary>
            /// 请求地址
            /// </summary>
            public string requestUrl { get; set; }


            /// <summary>
            /// 播放时长秒,0为无限
            /// </summary>
            public string duration
            {
                get;
                set;
            }
        }


        public NoticeInfo NoticeInfoP { get; set; }
        /// <summary>
        /// 是否有公告
        /// </summary>
        public bool HaveNotice
        {
            get
            {
                if (NoticeInfoP.noticeList.Count != 0)
                    return true;
                else
                    return false;
            }
        }
    }
}
