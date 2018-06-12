using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DkmsCore.Avengers.Net
{
    public class HttpExecuter : IHttpExecuter
    {
        public static List<string> DefaultHeaders = new List<string> {
            "Accept","Connection","KeepAlive","Content-Length","Content-Type","Expect",
            "Date","Host","IfModifiedSince","Referer","User-Agent","Transfer-Encoding"
        };

        public async Task<string> GetAsync(string url, Dictionary<string, string> headers = null)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Method = "GET";
            SetHeaders(request, headers);
            var response = await request.GetResponseAsync();
            using (var resStream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(resStream ?? Stream.Null, Encoding.UTF8))
                {
                    var responseContent = await reader.ReadToEndAsync();
                    return responseContent;
                }
            }
        }

        public async Task<string> PostAsync(string url, string parameters, Dictionary<string, string> headers = null)
        {

            byte[] byteArray = Encoding.UTF8.GetBytes(parameters); //转化
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;
            SetHeaders(request, headers);
            using (Stream reqStream = request.GetRequestStream())
            {
                reqStream.Write(byteArray, 0, byteArray.Length);//写入参数
            }
            using (var response = await request.GetResponseAsync())
            {
                using (var sr = new StreamReader(response.GetResponseStream() ?? Stream.Null, Encoding.UTF8))
                {
                    var responseContent = await sr.ReadToEndAsync();
                    return responseContent;
                }
            }
        }

        private void SetHeaders(HttpWebRequest request, Dictionary<string, string> headers)
        {
            if (headers == null || !headers.Any())
            {
                return;
            }
            foreach (var kvp in headers)
            {
                if (DefaultHeaders.Contains(kvp.Key))
                {
                    continue;
                }
                request.Headers.Add(kvp.Key, kvp.Value);
            };
        }
    }
}
