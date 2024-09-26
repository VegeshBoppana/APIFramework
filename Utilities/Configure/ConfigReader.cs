using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Utilities.Configure
{
    public class ConfigReader
    {
        public static TestSettings GetConfig(string configPath)
        {
            return JsonConvert.DeserializeObject<TestSettings>(File.ReadAllText(configPath));
        }
    }
}