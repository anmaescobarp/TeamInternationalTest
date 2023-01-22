using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TeamInternationalWeb.Tests
{
    public class ExpectedBehaviorsclass
    {
        public static List<Dictionary<string, string>> ExpectedBehaviors
        {
            get
            {
                string pathProject = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                int locationOfBinFolder = pathProject.IndexOf("bin");
                string jsonPath = pathProject.Remove(locationOfBinFolder) + "ExpectedResults.json";
                string jsonString = File.ReadAllText(jsonPath);
                List<Dictionary<string, string>> expectedBehaviorList = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(jsonString);
                return expectedBehaviorList;
            }
        }
    }
}
