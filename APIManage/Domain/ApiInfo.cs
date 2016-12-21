using System.Xml.Serialization;

namespace APIManage.Domain
{
    public class ApiInfo
    {
        private int _timeout = 5000;
        public int Timeout
        {
            get { return _timeout; }
            set { _timeout = value; }
        }

        //会员签名
        private string _CommonCode = "yCt6bSNhbcYVIg";
        public string CommonCode
        {
            get { return _CommonCode; }
            set { _CommonCode = value; }
        }

        private string _SpecialCode = "*#06#8e";
        public string SpecialCode
        {
            get { return _SpecialCode; }
            set { _SpecialCode = value; }
        }

        private string _PublicKey = "8er45fUfD15545qwwt23G";
        public string PublicKey
        {
            get { return _PublicKey; }
            set { _PublicKey = value; }
        }

     
    }
}
