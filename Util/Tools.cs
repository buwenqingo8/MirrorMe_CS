using System;
using System.Text;
using System.Web.Script.Serialization;

namespace Util
{
    /// <summary>
    /// 辅助工具类
    /// </summary>
    public class Tools
    {
        /// <summary>
        /// datetime转换成unixtime
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static long ConvertDateTimeInt(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (long)(time - startTime).TotalSeconds;
        }

        /// <summary>
        /// 将Unix时间戳转换为DateTime类型时间
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateTime ConvertIntDateTime(double d)
        {
            System.DateTime time = System.DateTime.MinValue;
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            time = startTime.AddSeconds(d);
            return time;
        }

        /// <summary>
        /// 时间戳
        /// </summary>
        public static string DateTimeStamp
        {
            get
            {
                return Convert.ToString((long)(DateTime.Now - TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1))).TotalSeconds);
            }
        }

        /// <summary>
        /// 创建订单号(会员充值在本地生成订单号)
        /// </summary>
        /// <returns></returns>
        public static string GetOrderNum(string MachineId)
        {
            StringBuilder orderNum = new StringBuilder();
            orderNum.Append(((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000).ToString());
            orderNum.Append(Convert.ToString(MachineId.GetHashCode(), 16));
            return (orderNum.ToString().ToLower());
        }

       
    }
}
