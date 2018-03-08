using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace AutoBid.Cloud.Controllers
{
    public class ClientController : ApiController
    {
        [HttpGet]
        public int Version()
        {
            return int.Parse(ConfigurationManager.AppSettings["ClientVersion"]);
        }

        [HttpGet]
        public IHttpActionResult Updates(int version)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Client", $"{version}.zip");
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            FileStream fileStream = File.OpenRead(filePath);
            httpResponseMessage.Content = new StreamContent(fileStream);
            httpResponseMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            httpResponseMessage.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = $"{version}.zip"
            };
            return ResponseMessage(httpResponseMessage);
        }
    }
}