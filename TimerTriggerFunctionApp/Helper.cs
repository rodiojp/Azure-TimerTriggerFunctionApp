using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TimerTriggerFunctionApp
{
    public class Helper
    {
        public static string GetEnvironmentVariable(string name)
        {
            return System.Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Process);
        }

        public static async Task<Dictionary<string, string>> GetGroupMembers(ILogger log)
        {
            const string name = "CLIENT-SECRET";
            var clientSecret = GetEnvironmentVariable(name);
            var ret = new Dictionary<string, string>();
            ret.Add(name, clientSecret);
            return ret;
        }
    }
}