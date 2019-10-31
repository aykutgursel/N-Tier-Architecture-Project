using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace web.GurselFramework.Framework.Helper
{
    public class CryptoHelper
    {
        private const string ActionKey = "EA81AA1D5FC1EC53E84F30AA746139EEBAFF8A9B76638895";
        private const string ActionIv = "87AF7EA221F3FFF5";

        private static readonly TripleDESCryptoServiceProvider _des3;

        static CryptoHelper()
        {
            _des3 = new TripleDESCryptoServiceProvider { Mode = CipherMode.CBC };
        }

        public static string GenerateKey()
        {
            _des3.GenerateKey();
            return BytesToHex(_des3.Key);
        }

        public static string GenerateIv()
        {
            _des3.GenerateIV();
            return BytesToHex(_des3.IV);
        }

        private static byte[] HexToBytes(string hex)
        {
            var bytes = new byte[hex.Length / 2];
            for (var i = 0; i < hex.Length / 2; i++)
            {
                var code = hex.Substring(i * 2, 2);
                bytes[i] = byte.Parse(code, System.Globalization.NumberStyles.HexNumber);
            }

            return bytes;
        }

        private static string BytesToHex(IEnumerable<byte> bytes)
        {
            var hex = new StringBuilder();
            foreach (var temp in bytes)
            {
                hex.AppendFormat("{0:X2}", temp);
            }

            return hex.ToString();
        }

        public static string Encrypt(string data, string key, string iv)
        {
            var bdata = Encoding.UTF8.GetBytes(data);
            var bkey = HexToBytes(key);
            var biv = HexToBytes(iv);

            var stream = new MemoryStream();
            var encStream = new CryptoStream(stream,
                _des3.CreateEncryptor(bkey, biv), CryptoStreamMode.Write);

            encStream.Write(bdata, 0, bdata.Length);
            encStream.FlushFinalBlock();
            encStream.Close();

            return BytesToHex(stream.ToArray());
        }

        public static string Decrypt(string data, string key, string iv)
        {
            var bdata = HexToBytes(data);
            var bkey = HexToBytes(key);
            var biv = HexToBytes(iv);

            var stream = new MemoryStream();
            var encStream = new CryptoStream(stream,
                _des3.CreateDecryptor(bkey, biv), CryptoStreamMode.Write);

            encStream.Write(bdata, 0, bdata.Length);
            encStream.FlushFinalBlock();
            encStream.Close();

            return Encoding.UTF8.GetString(stream.ToArray());
        }

        public static string Encrypt(string data)
        {
            try
            {
                return data.IsNull() ? data : Encrypt(data, ActionKey, ActionIv);
            }
            catch
            {

            }

            return string.Empty;
        }

        public static string Decrypt(string data)
        {
            try
            {
                return data.IsNull() ? data : Decrypt(data, ActionKey, ActionIv);
            }
            catch (Exception ex)
            {
                string a = ex.Message;
            }

            return string.Empty;
        }
    }
}
