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

    /// <summary>
    /// 
    /// </summary>
    private static string strKey = "mark7319";
    /// <summary>
    /// 
    /// </summary>
    private static string strIV = "codeinCM";

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