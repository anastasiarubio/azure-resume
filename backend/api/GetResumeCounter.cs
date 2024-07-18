using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace My.Function
{
    public static class GetResumeCounter
    {
        private readonly ILogger<GetResumeCounter> _logger;

        public GetResumeCounter(ILogger<GetResumeCounter> logger)
        {
            _logger = logger;
        }

        [Function("GetResumeCounter")]
        //[CosmosDBOutput(databaseName:"AzureResume", containerName:"Counter", CreateIfNotExists =true, Connection ="AzureResumeConnectionString")]
        public static MultiResponse Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req,
            [CosmosDBInput(databaseName:"AzureResume", containerName:"Counter", Connection ="AzureResumeConnectionString", Id ="1", PartitionKey = "1")] Counter counter,
            [CosmosDBOutput(databaseName:"AzureResume", containerName:"Counter", Connection ="AzureResumeConnectionString", PartitionKey = "1")] out Counter updatedCounter,
            //[CosmosDBOutput(databaseName:"AzureResume", containerName:"Counter", CreateIfNotExists =false, ContainerThroughput =1, Connection ="AzureResumeConnectionString", PartitionKey = "1")] out Counter updatedCounter
            
            ILogger log)

        {
            _log.LogInformation("C# HTTP trigger function processed a request.");

            updatedCounter = counter;
            updatedCounter.Count += 1;

            var jsonToRetun = JsonConvert.SerializeObject(counter);

            return new HttpResponseMessage(System.Net.HttpStatusCode.OK)

            {
                Content = new StringContent(jsonToRetun,Encoding.UTF8, "application/json")
            };
        }
    }
}
