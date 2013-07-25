using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Security.Cryptography;
using System.Text;

/// <summary>
/// Security 的摘要描述
/// </summary>
public class Security
{
	public Security()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}
    public class DES
    {
        /// <summary>
        /// 加密金鑰，長度必須為 8 個 ASCII 字元
        /// </summary>
        private static string strKey = "marsen.l";

        public static string StrKey
        {
            get { return Security.DES.strKey; }
            set { Security.DES.strKey = value; }
        }
        /// <summary>
        /// 金鑰向量，長度必須為 8 個 ASCII 字元
        /// </summary>
        private static string strIV = "mproject";

        public static string StrIV
        {
            get { return Security.DES.strIV; }
            set { Security.DES.strIV = value; }
        }

        /// <summary>字串編碼</summary>
        /// <param name="strSource">原始字串</param>
        /// <returns>編碼後的結果字串</returns>
        public static string enCrypt(string strSource)
        {
            MemoryStream ms = new MemoryStream();
            DESCryptoServiceProvider key = new DESCryptoServiceProvider();
            CryptoStream encStream = new CryptoStream(ms, key.CreateEncryptor(Encoding.Default.GetBytes(strKey), Encoding.Default.GetBytes(strIV)), CryptoStreamMode.Write);
            StreamWriter sw = new StreamWriter(encStream);
            sw.WriteLine(strSource);
            sw.Close();
            encStream.Close();
            byte[] buffer = ms.ToArray();
            ms.Close();
            return Convert.ToBase64String(buffer);
        }

        /// <summary>字串解碼</summary>
        /// <param name="strSource">加密過的字串</param>
        /// <returns>解碼後的結果字串</returns>
        public static string deCrypt(string strSource)
        {
            MemoryStream ms = new MemoryStream(Convert.FromBase64String(strSource));
            DESCryptoServiceProvider key = new DESCryptoServiceProvider();
            CryptoStream encStream = new CryptoStream(ms, key.CreateDecryptor(Encoding.Default.GetBytes(strKey), Encoding.Default.GetBytes(strIV)), CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(encStream);
            string val = sr.ReadLine();
            sr.Close();
            encStream.Close();
            ms.Close();

            return val;
        }
    }

    public class AES
    {
        /// <summary>
        /// 加密金鑰，長度必須為 16 個 ASCII 字元
        /// </summary>
        private static string strKey = "codebymarsen.lin";

        public static string StrKey
        {
            get { return Security.AES.strKey; }
            set { Security.AES.strKey = value; }
        }
        /// <summary>
        /// 金鑰向量，長度必須為 16 個 ASCII 字元
        /// </summary>
        private static string strIV = "ABCDEFGHIJKLMNOP";

        public static string StrIV
        {
            get { return Security.AES.strIV; }
            set { Security.AES.strIV = value; }
        }

        /// <summary>字串編碼</summary>
        /// <param name="strSource">原始字串</param>
        /// <returns>編碼後的結果字串</returns>
        public static string enCrypt(string strSource)
        {
            MemoryStream ms = new MemoryStream();
            AesCryptoServiceProvider key = new AesCryptoServiceProvider();
            CryptoStream encStream = new CryptoStream(ms, key.CreateEncryptor(Encoding.Default.GetBytes(strKey), Encoding.Default.GetBytes(strIV)), CryptoStreamMode.Write);
            StreamWriter sw = new StreamWriter(encStream);
            sw.WriteLine(strSource);
            sw.Close();
            encStream.Close();
            byte[] buffer = ms.ToArray();
            ms.Close();
            return Convert.ToBase64String(buffer);
        }

        /// <summary>字串解碼</summary>
        /// <param name="strSource">加密過的字串</param>
        /// <returns>解碼後的結果字串</returns>
        public static string deCrypt(string strSource)
        {
            MemoryStream ms = new MemoryStream(Convert.FromBase64String(strSource));
            AesCryptoServiceProvider key = new AesCryptoServiceProvider();
            CryptoStream encStream = new CryptoStream(ms, key.CreateDecryptor(Encoding.Default.GetBytes(strKey), Encoding.Default.GetBytes(strIV)), CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(encStream);
            string val = sr.ReadLine();
            sr.Close();
            encStream.Close();
            ms.Close();

            return val;
        }
    }
    /// <summary>
    /// 不可逆性，通常用於確保資訊傳輸完整一致 因其不可逆性，所以只有加密的函式，沒有解密的函式
    /// </summary>
    [Obsolete("MD5加密安全性已降低,隨著電腦運算能力提高,已可人為找到「碰撞」。")]
    public class MD5
    {
        /// <summary>字串編碼</summary>
        /// <param name="strSource">原始字串</param>
        /// <returns>編碼後的結果字串</returns>
        public static string enCrypt(string strSource)   
        {   
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] b = md5.ComputeHash(Encoding.UTF8.GetBytes(strSource));   
            return BitConverter.ToString(b).Replace("-", string.Empty);   
        }
    }
}