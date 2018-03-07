using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AutoBid.Client.Utilities
{
    abstract class BaseHttpExecutor : IHttpExecutor
    {
        public virtual string Post(string url, string parameters)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                var buffer = Encoding.UTF8.GetBytes(parameters);
                request.ContentLength = buffer.Length;
                WrapperPostRequest(request);
                Stream myRequestStream = request.GetRequestStream();
                myRequestStream.Write(buffer, 0, buffer.Length);
                myRequestStream.Close();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                WrapperGetResponse(response);
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                string retString = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();
                return retString;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        protected abstract void WrapperPostRequest(HttpWebRequest request);
        protected abstract void WrapperPostResponse(HttpWebResponse response);

        public virtual TModel Post<TModel>(string url, string parameters)
        {
            var result = this.Post(url, parameters);
            if (string.IsNullOrEmpty(result))
            {
                return default(TModel);
            }
            return JsonConvert.DeserializeObject<TModel>(result);
        }

        public virtual string Get(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "Get";
                WrapperGetRequest(request);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                WrapperGetResponse(response);
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                string retString = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();
                return retString;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        protected abstract void WrapperGetRequest(HttpWebRequest request);

        protected abstract void WrapperGetResponse(HttpWebResponse response);

        public virtual TModel Get<TModel>(string url)
        {
            var result = this.Get(url);
            if (string.IsNullOrEmpty(result))
            {
                return default(TModel);
            }
            return JsonConvert.DeserializeObject<TModel>(result);
        }
    }
}
