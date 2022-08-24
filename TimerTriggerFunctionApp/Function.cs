using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace TimerTriggerFunctionApp
{
    public class Function
    {
        [FunctionName("ReplaceUsers")]
        public async Task Run([TimerTrigger("0 */5 * * * *")] TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");


            string keyVaultName = Environment.GetEnvironmentVariable("KEY_VAULT_NAME");
            string keyVaultSecretName = Environment.GetEnvironmentVariable("KEY_VAULT_SECRET_NAME");
            var kvUri = $"https://{keyVaultName}.vault.azure.net/";

            var client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());

            var secret = await client.GetSecretAsync(keyVaultSecretName);



            var users = Helper.GetGroupMembers(log);
        }
    }
}
