using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game___Capture.SaveResults
{
    static class Saves
    {
        public static Dictionary<string, Dictionary<string, object>> Dictionary { get; private set; } = new();

        public static void CheckAddUser()
        {
            Deserialize();
            if (!Dictionary.ContainsKey(Environment.UserName))
            {
                Dictionary.Add(Environment.UserName, new());
                Dictionary[Environment.UserName].Add("Score", 0);
            }
        }

        public static void Serialize()
        {
            string json = JsonConvert.SerializeObject(Dictionary);

            File.WriteAllText("Saves.json", json);
        }

        public static void Deserialize()
        {
            string json = File.ReadAllText("Saves.json");

            Dictionary = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, object>>>(json);
        }
    }
}
