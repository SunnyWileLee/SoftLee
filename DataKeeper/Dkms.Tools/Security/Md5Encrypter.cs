using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Dkms.Tools.Security
{
    class Md5Encrypter : IMd5Encrypter
    {
        public string Encrypt(string input)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                byte[] result = Encoding.Default.GetBytes(input);
                byte[] output = md5.ComputeHash(result);
                return BitConverter.ToString(output).Replace("-", "");
            }
        }
    }
}
