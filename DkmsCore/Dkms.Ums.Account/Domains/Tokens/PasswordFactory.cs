using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dkms.Ums.Account.Repositories;
using DkmsCore.Infrustructure.Utilities;

namespace Dkms.Ums.Account.Domains.Tokens
{
    public class PasswordFactory : IPasswordFactory
    {
        private readonly IMd5Encrypter _md5Encrypter;

        public readonly List<char> Words = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

        public PasswordFactory(IMd5Encrypter md5Encrypter)
        {
            _md5Encrypter = md5Encrypter;
        }

        private string CreateSalt()
        {
            StringBuilder sb = new StringBuilder { };
            var random = new Random();
            var length = Words.Count;
            for (int i = 0; i < 20; i++)
            {
                sb.Append(Words[random.Next(0, length)]);
            }
            var salt = sb.ToString();
            return _md5Encrypter.Encrypt(salt);
        }

        public bool VerifyPassword(AccountEntity account, string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return false;
            }
            return account.Password.Equals(_md5Encrypter.Encrypt(password + account.Salt));
        }

        public string CreatePassword(string password, out string salt)
        {
            salt = CreateSalt();
            return _md5Encrypter.Encrypt(password + salt);
        }
    }
}
