using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using UserCRUD.FuncApp.Services;

namespace UserCRUD.Function
{
    public class ListHttpTrigger
    {
        private ICRUDService _service;
        public ListHttpTrigger(ICRUDService service)
        {
            _service = service;
        }
        [FunctionName("list-dummy")]
        public async Task<IActionResult> RunDummy(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "list-dummy")] HttpRequest req, 
            ILogger log)
        {
            var user = new List<User>(){new User(){Name="Madan",Password="Test@123"}};
            return new OkObjectResult(user);
        }
        [FunctionName("list")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "list")] HttpRequest req, 
            ILogger log)
        {
            var user = await _service.ListAsync();
            return new OkObjectResult(user);
        }
    }
}
