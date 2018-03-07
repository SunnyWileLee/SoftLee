using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AutoBid.Update
{
    class UpdateService
    {
        private readonly ApiHttpExecutor apiHttpExecutor = new ApiHttpExecutor { };
        public const string VersionXml = "bidder.xml";

        public bool Update()
        {
            var currentVersion = GetCurrentVersion();
            Console.WriteLine($"当前版本{currentVersion.ToString()}");
            var newVersion = GetNewVersion();
            Console.WriteLine($"最新版本{newVersion.ToString()}");
            if (currentVersion >= newVersion)
            {
                Console.WriteLine("不需要更新");
                return true;
            }
            Console.WriteLine("开始更新");
            var filename = Download(newVersion.ToString());
            if (string.IsNullOrEmpty(filename))
            {
                Console.WriteLine("下载失败");
                return false;
            }
            Console.WriteLine("下载完成,开始提取文件");
            try
            {
                var updateDirectory = $"{AppDomain.CurrentDomain.BaseDirectory}update\\";
                if (!Directory.Exists(updateDirectory))
                {
                    Directory.CreateDirectory(updateDirectory);
                }
                ZipFile.ExtractToDirectory(filename, updateDirectory); //解压
                var files = Directory.GetFiles(updateDirectory);
                foreach (var file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    var name = fileInfo.Name;
                    string destFileName = $"{AppDomain.CurrentDomain.BaseDirectory}{name}";
                    if (File.Exists(destFileName))
                    {
                        File.Delete(destFileName);
                    }
                    File.Move(file, destFileName);
                }
                Directory.Delete(updateDirectory);
                File.Delete(filename);
                Console.WriteLine("更新完成");
                UpdateCurrentVersion(newVersion);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"更新失败:{ex.Message}");
                return false;
            }
        }

        private int GetNewVersion()
        {
            var version = apiHttpExecutor.Get($"{ApiHttpExecutor.ApiDomian}/Client/Version");
            return int.Parse(version);
        }

        private void UpdateCurrentVersion(int version)
        {
            XDocument xml = XDocument.Load(VersionXml);
            xml.Root.Element("Version").Value = version.ToString();
            xml.Save(VersionXml);
        }

        private int GetCurrentVersion()
        {
            XDocument xml = XDocument.Load(VersionXml);
            var version = xml.Root.Element("Version").Value;
            return int.Parse(version);
        }

        private string Download(string newVersion)
        {
            try
            {
                var url = $"{ApiHttpExecutor.ApiDomian}/Client/Updates?version={newVersion}";
                // 设置参数
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "GET";
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                Stream responseStream = response.GetResponseStream();
                //创建本地文件写入流
                //Stream stream = new FileStream(tempFile, FileMode.Create);
                byte[] bArr = new byte[1024];
                int size = responseStream.Read(bArr, 0, (int)bArr.Length);
                var disposition = response.Headers["Content-Disposition"];
                var filename = disposition.Split(';').FirstOrDefault(s => s.Trim().StartsWith("filename")).Split('=')[1];
                FileStream fs = new FileStream(filename, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                while (size > 0)
                {
                    fs.Write(bArr, 0, size);
                    size = responseStream.Read(bArr, 0, (int)bArr.Length);
                }
                fs.Close();
                responseStream.Close();
                return filename;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }

        }
    }
}
