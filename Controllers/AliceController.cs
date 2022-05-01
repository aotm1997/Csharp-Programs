using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AliceHook.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AliceHook.Controllers
{
    [ApiController]
    [Route(template: "/")]
    public class AliceController : ControllerBase
    {
        private static readonly JsonSerializerSettings ConverterSettings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            }
        };
        
        [HttpGet]
        public string Get()
        {
            return "It works!";
        }
        
        [HttpPost]
        public Task Post()
        {
           using var reader = new StreamReader(request.Body);
        }
    }
}