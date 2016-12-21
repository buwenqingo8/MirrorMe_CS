
namespace APIManage.Domain
{
    /// <summary>
    /// AppId信息
    /// </summary>
    public class AppInfo
    {
        private string _machineId = "164";
        /// <summary>
        /// 机器号
        /// </summary>
        public string MachineId
        {
            get { return _machineId; }
            set { _machineId = value; }
        }

        private string _shopName = "商家测试帐号_翠柏路";
        /// <summary>
        /// 店铺名
        /// </summary>
        public string ShopName
        {
            get { return _shopName; }
            set { _shopName = value; }
        }

        private string _shopId = "19";
        /// <summary>
        /// 店铺id(相对于商家,店铺是下属分店)
        /// </summary>
        public string ShopId
        {
            get { return _shopId; }
            set { _shopId = value; }
        }

        private string _parentShopId = "18";
        /// <summary>
        /// 商家id
        /// </summary>
        public string ParentShopId
        {
            get { return _parentShopId; }
            set { _parentShopId = value; }
        }
    }
}
