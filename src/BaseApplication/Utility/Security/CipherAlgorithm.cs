using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Security
{
    public class CipherAlgorithm : ICipherAlgorithm
    {

        private readonly string Key = "cWEZHgD$MFy?R=eE5-J9wQsz47Fdje+6";
        private readonly string SepratorChars = "$$$";

        public CipherAlgorithm()
        {
            
        }

        public string DecryptString(string cipherText)
        {
            string plainText = "";
            byte[] iv = new byte[16];
            try
            {
                byte[] buffer = Convert.FromBase64String(cipherText);

                using (Aes aes = Aes.Create())
                {
                    aes.Key = Encoding.UTF8.GetBytes(Key);
                    aes.IV = iv;
                    ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                    using (MemoryStream memoryStream = new MemoryStream(buffer))
                    {
                        using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                            {
                                plainText = streamReader.ReadToEnd();
                            }
                        }
                    }
                }
                var stringVal = plainText.Split(SepratorChars);
                if (stringVal.Length != 2 || CalculateCheckSum(stringVal[0]) != stringVal[1])
                    return "";
                return stringVal[0];
            }
            catch (Exception)
            {

            }
            return "";
        }

        public string EncryptString(string plainText)
        {
            byte[] iv = new byte[16];
            byte[] array;

            try
            {
                using (Aes aes = Aes.Create())
                {
                    aes.Key = Encoding.UTF8.GetBytes(Key);
                    aes.IV = iv;

                    ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                            {
                                string plainTextToEncrypt = plainText + SepratorChars + CalculateCheckSum(plainText);
                                streamWriter.Write(plainTextToEncrypt);
                            }

                            array = memoryStream.ToArray();
                        }
                    }
                }

                return Convert.ToBase64String(array);
            }
            catch (Exception)
            {
            }
            return "";
        }


        private string CalculateCheckSum(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                return BitConverter.ToString(
                  md5.ComputeHash(Encoding.UTF8.GetBytes(input))
                ).Replace("-", String.Empty);
            }
        }
    }
}
