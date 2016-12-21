using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using CryptClass;
using System.Security.Cryptography;//3DES 相关加解密 直接引用进工程，在这里USING就行

namespace Util
{
    public static  class RSA_3DES 
    {
        private const string _fileDll = @"RSADLL.dll";
        [DllImport(_fileDll, EntryPoint = "_RSAEncryptString@16", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void RSAEncryptString(char[] sInput, char[] mn, char[] me, StringBuilder cipher);


        private static void button1_Click(string sInputPara,string KeyE, string KeyN)
        {
            
            Encoding encode = Encoding.Default;
            byte[] bInputPara = encode.GetBytes(sInputPara);
            byte[] bKeyE = encode.GetBytes(KeyE);
            byte[] bKeyN = encode.GetBytes(KeyN);

            StringBuilder sInputTmp = new StringBuilder(5000);

            RSAEncryptString(encode.GetChars(bInputPara), encode.GetChars(bKeyN), encode.GetChars(bKeyE), sInputTmp);

        string textBox5= sInputTmp.ToString();
        }

        //加密
        public static string EncryStr3DES(string sKey, string sInputPara)
        {
  
            Crypt Cy = new Crypt();//实例化DLL中的一个类
            Cy.Des();//调用它的一个函数，要初始化一系列参数
            string sOutputPara = Cy.EncryStr3DES(sInputPara, sKey);//开始加解密吧

            return sOutputPara;
        }

        public  static string encryptMD5(string value)
        {
            byte[] result = Encoding.Default.GetBytes(value);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            string outstr = BitConverter.ToString(output).Replace("-", "");
            return outstr;
        }

        //解密
        public static string DecryStr3DES(string sKey, string sInputPara)
        {
 
            Crypt Cy = new Crypt();//实例化DLL中的一个类
            Cy.Des();//调用它的一个函数，要初始化一系列参数
            string sOutputPara = Cy.DecryStr3DES(sInputPara, sKey);//开始加解密吧
            return  sOutputPara;

        }


    }
}
