using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NFSe.Security
{
    public static class Cryptography
    {
        private const string key = "#S@Ss#kA321#$f%fk@#a@@smvjsKKjsDSA3$$";
        public static string Decrypt(string cipher)
        {
            try
            {
                byte[] clearBytes = Convert.FromBase64String(cipher);
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] md5Bytes = md5.ComputeHash(Encoding.Unicode.GetBytes(key));
                string encryptedText = "";
                TripleDES des = new TripleDESCryptoServiceProvider();
                des.KeySize = 128;
                des.Mode = CipherMode.CBC;
                des.Padding = PaddingMode.PKCS7;
                byte[] ivBytes = new byte[8];
                des.Key = md5Bytes;
                des.IV = ivBytes;
                ICryptoTransform ct = des.CreateDecryptor();
                byte[] resultArray = ct.TransformFinalBlock(clearBytes, 0, clearBytes.Length);
                encryptedText = Encoding.Unicode.GetString(resultArray);
                return encryptedText;
            }
            catch (Exception exception)
            {
                return "";
            }
        }
        public static string Encrypt(string clearText)
        {
            try
            {
                string encryptedText = "";
                MD5 md5 = new MD5CryptoServiceProvider();
                TripleDES des = new TripleDESCryptoServiceProvider();
                des.KeySize = 128;
                des.Mode = CipherMode.CBC;
                des.Padding = PaddingMode.PKCS7;

                byte[] md5Bytes = md5.ComputeHash(Encoding.Unicode.GetBytes(key));

                byte[] ivBytes = new byte[8];


                des.Key = md5Bytes;

                des.IV = ivBytes;

                byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);

                ICryptoTransform ct = des.CreateEncryptor();
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    encryptedText = Convert.ToBase64String(ms.ToArray());
                }
                return encryptedText;
            }
            catch (Exception exception)
            {
                return "";
            }
        }
    }
}
