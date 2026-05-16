using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RandomIfsExercs.Extensions
{
    public class JsonExtension
    {
        public static void SaveUsers(Dictionary<string, string> users)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "users.json");
            string json = UsersJsonSerializer(users);
            File.WriteAllText(path, json);
        }

        public static string UsersJsonSerializer(Dictionary<string, string> users)
        {
            string res = JsonSerializer.Serialize(users, new JsonSerializerOptions
            {
                WriteIndented = true,
            });
            return res;
        }
    }
}
