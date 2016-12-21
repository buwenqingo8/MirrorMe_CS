using APIManage.Domain;

namespace APIManage
{
    public class SysAPIGlobal
    {
        private static AppInfo _app = new AppInfo();
        /// <summary>
        /// app应用信息
        /// </summary>
        public static AppInfo App
        {
              
            get { return SysAPIGlobal._app; }
            set { SysAPIGlobal._app = value; }
        }

        private static ApiInfo _apii = new ApiInfo();
        /// <summary>
        /// 接口信息
        /// </summary>
        public static ApiInfo Apii
        {
            get { return SysAPIGlobal._apii; }
            set { SysAPIGlobal._apii = value; }
        }
    }
}
