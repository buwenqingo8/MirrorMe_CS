using APIManage;
using APIManage.Domain;

namespace APIManage.Responses
{
    public class LoginResponse : Response
    {
        public AppInfo AppInfo { get; set; }
    }
}
