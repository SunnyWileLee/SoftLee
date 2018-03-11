using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Infrustructure.Utilities
{
    public interface IMd5Encrypter
    {
        string Encrypt(string input);
    }
}
