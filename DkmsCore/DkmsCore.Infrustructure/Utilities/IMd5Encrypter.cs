using System;
using System.Collections.Generic;
using System.Text;

namespace DkmsCore.Infrustructure.Utilities
{
    public interface IMd5Encrypter
    {
        string Encrypt(string input);
    }
}
