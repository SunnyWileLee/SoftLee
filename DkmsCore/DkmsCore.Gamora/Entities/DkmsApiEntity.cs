using DkmsCore.Thor;
using System;
using System.Collections.Generic;
using System.Text;

namespace DkmsCore.Gamora.Entities
{
    public class DkmsApiEntity : DkmsEntity
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Service { get; set; }

        public string ToUrl(string query)
        {
            return $"http://{Host}:{Port}{Service}{query}";
        }
    }
}
