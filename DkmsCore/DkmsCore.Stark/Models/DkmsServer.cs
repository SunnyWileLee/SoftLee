using System;
using System.Collections.Generic;
using System.Text;

namespace DkmsCore.Stark.Models
{
    public class DkmsServer
    {
        public string Host { get; set; }
        public int Port { get; set; }

        public override string ToString()
        {
            return $"{Host}:{Port}";
        }
    }
}
