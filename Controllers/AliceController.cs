using Microsoft.AspNetCore.Mvc;
using System.IO;
using AliceHook.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
namespace AliceHook.Controllers
{
    [ApiController]
    [Route(template: "/")]
    private static readonly JsonSerializerSettings ConverterSettings = new JsonSerializerSettings
    {
        ContractResolver = new DefaultContractResolver
        {
            NamingStrategy = new SnakeCaseNamingStrategy()
        }
    }
    public class AliceController : ControllerBase
    {   
        [HttpGet]
        public string Get()
        {
            return "It works!";
        }
    }
        [HttpPost]
        public Task Post()
        {
            using var reader = new StreamReader(Request.Body);
            var body = reader.ReadToEnd();
            var aliceRequest = Json.Convert.DeserializeObject<AliceRequest>(body, ConverterSettings);
            var aliceResponse = new AliceResponse(aliceRequest)
            {
                Response = Text = "Привет";
            }
            var stringResponse = JsonConvert.SerializeObject(aliceResponse, ConverterSettings);
            return Response.WriteAsync(stringResponse);
        }
}