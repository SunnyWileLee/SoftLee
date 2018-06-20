using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DkmsCore.Avengers.Configs
{
    public class AppSettings : IAppSettings
    {
        public const string AppSettingsFile = "appsettings.json";

        public string AppId => Setting("AppId").Result;

        public string AppSecret => Setting("AppSecret").Result;

        public string GatewayHost => Setting("GatewayHost").Result;

        public async Task<string> Setting(string key)
        {
            var jsonString = await File.ReadAllTextAsync(AppSettingsFile);
            var json = JsonConvert.DeserializeObject<JObject>(jsonString);
            var value = json[key];
            return JsonConvert.SerializeObject(value);
        }
    }
}
