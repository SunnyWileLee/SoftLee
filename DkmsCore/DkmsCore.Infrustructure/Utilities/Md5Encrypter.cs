using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace DkmsCore.Infrustructure.Utilities
{
    class Md5Encrypter : IMd5Encrypter
    {
        public string Encrypt(string input)
        {
            using (var md5 = MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
                var strResult = BitConverter.ToString(result);
                return strResult.Replace("-", "");
            }
        }
    }
}
