using System;
using System.Text;

namespace Util
{
    /// <summary>
    /// 实现Base64加密解密
    /// 作者：
    /// 时间：2016
    /// </summary>
    public sealed class Base64
    {
//        图片的Base64编码：
//        System.IO.MemoryStream m = new System.IO.MemoryStream();
//System.Drawing.Bitmap bp = new System.Drawing.Bitmap(@“c:\demo.GIF”);
//bp.Save(m, System.Drawing.Imaging.ImageFormat.Gif);
//byte[]b= m.GetBuffer();
//string base64string=Convert.ToBase64String(b);

//        Base64字符串解码：
//        byte[] bt = Convert.FromBase64String(base64string);
//System.IO.MemoryStream stream = new System.IO.MemoryStream(bt);
//Bitmap bitmap = new Bitmap(stream);
//pictureBox1.Image = bitmap;

        /// <summary>
        /// Base64加密
        /// </summary>
        /// <param name="codeName">加密采用的编码方式</param>
        /// <param name="source">待加密的明文</param>
        /// <returns></returns>
        public static string EncodeBase64(Encoding encode, string source)
        {
            string strencode;
            byte[] bytes = encode.GetBytes(source);
            try
            {
                strencode = Convert.ToBase64String(bytes);
            }
            catch
            {
                strencode = source;
            }
            return strencode;
        }

        /// <summary>
        /// Base64加密，采用utf8编码方式加密
        /// </summary>
        /// <param name="source">待加密的明文</param>
        /// <returns>加密后的字符串</returns>
        public static string EncodeBase64(string source)
        {
            return EncodeBase64(Encoding.UTF8, source);
        }

        /// <summary>
        /// Base64解密
        /// </summary>
        /// <param name="codeName">解密采用的编码方式，注意和加密时采用的方式一致</param>
        /// <param name="result">待解密的密文</param>
        /// <returns>解密后的字符串</returns>
        public static string DecodeBase64(Encoding encode, string result)
        {
            string decode = "";
            byte[] bytes = Convert.FromBase64String(result);
            try
            {
                decode = encode.GetString(bytes);
            }
            catch
            {
                decode = result;
            }
            return decode;
        }

        /// <summary>
        /// Base64解密，采用utf8编码方式解密
        /// </summary>
        /// <param name="result">待解密的密文</param>
        /// <returns>解密后的字符串</returns>
        public static string DecodeBase64(string result)
        {
            return DecodeBase64(Encoding.UTF8, result);
        }
    }
}