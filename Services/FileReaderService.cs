using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CustomerViewerAPI.Models;
using Newtonsoft.Json;

namespace CustomerViewerAPI.Services
{
    public class FileReaderService
    {
        public static Config GetDbConfig()
        {
            const string file = "./Config/Config.json";
            string data = File.ReadAllText(file);
            return JsonConvert.DeserializeObject<Config>(data);
        }
    }
}
