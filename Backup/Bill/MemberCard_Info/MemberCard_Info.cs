using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Runtime.Serialization.Json;
using System.IO;
using CoreHandle;

namespace Bill
{
    public class MemberCard_Info
    {
        //public static Store LoginByJobNumberNew(string serverUserName, string serverUserPwd, string machineId, string userName, string password, string mac, ref string errStr)
        //{
        //    try
        //    {
        //        WebClient client = new WebClient();
        //        string param = "jobNum=" + userName + "&jobPassword=" + password + "&machineId=" + machineId;
        //        param += "&username=" + serverUserName + "&password=" + serverUserPwd;
        //        client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
        //        byte[] postdata = Encoding.UTF8.GetBytes(param);
        //        Byte[] pageData = client.UploadData(APIConfig.plugLoginByJobNumberAjax, "POST", postdata);
        //        string pageHtml = Encoding.UTF8.GetString(pageData);

        //        //string jsonStr = @"{""fruits"":{""a"":""orange"",""b"":""banana"",""c"":""apple""},""name"":{""z"":""zhangsan"",""l"":""lisi""}}";
        //        JObject obj2 = (JObject)JsonConvert.DeserializeObject(pageHtml);
        //        DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Store));
        //        using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(obj2["data"].ToString())))
        //        {
        //            Store obj = js.ReadObject(ms) as Store;
        //            //Console.WriteLine(obj.fruits.a);
        //            return obj;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}
    }
}