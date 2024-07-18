using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Resume.Function
{
    public class GetResumeCounterNew
    {
        private readonly ILogger<GetResumeCounterNew> _logger;

        public GetResumeCounterNew(ILogger<GetResumeCounterNew> logger)
        {
            _logger = logger;
        }

        [Function("GetResumeCounterNew")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult("Welcome to Azure Functions!");
        }
    }
}
