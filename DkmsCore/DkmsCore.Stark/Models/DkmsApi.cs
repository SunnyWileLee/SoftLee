using System;
using System.Collections.Generic;
using System.Text;

namespace DkmsCore.Stark.Models
{
    public class DkmsApi : DkmsServer
    {
        public string Service { get; set; }

        public string BuildUrl(string query)
        {
            return $"http://{Host}/{Service}{query}";
        }
    }
}
