using System;
using System.Collections.Generic;
using System.Text;

namespace DkmsCore.Infrustructure.Webs
{
    public class DkmsException : Exception
    {
        public DkmsException()
        {

        }

        public DkmsException(string message)
            : base(message)
        {

        }

        public DkmsException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
