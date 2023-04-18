using System.Text;
using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace RESTApplication.Controllers;

[ApiController]
[Route("[controller]")]
public class SimpleController : ControllerBase
{
    

    [HttpGet(Name = "GetString")]
    public JsonResult GetString()
    {

        
        return new JsonResult("this is string request");

    }

    
        
    // [HttpPost(Name = "PostMap")]
    // public string PrintMap(Dictionary<string, string> inputMap)
    // {
    //     foreach (var key in inputMap.Keys)
    //     {
    //         Console.WriteLine("Key is:" + key);
    //         Console.WriteLine("Value is:" + inputMap[key]);
    //     }
    //
    //
    //     return "Accepted";
    // }
    
    [HttpPost]
    public async Task<string?> LoginToPF(JsonObject postBody)
    {
        HttpClient client = new HttpClient();

        HttpResponseMessage result;
        StringContent content = new (postBody.ToJsonString());
        content.Headers.Remove("Content-Type");
        content.Headers.Add("Content-Type", "application/json");
        content.Headers.Add("Client", "10553");
        content.Headers.Add("Authorization", "Bearer " + token);


        result = await client.PostAsync("https://restapi.plusofon.ru/api/v1/login", content);
        string strResult = await result.Content.ReadAsStringAsync();

        Console.WriteLine(strResult.Normalize());
        return strResult;
    }
    
    
    
}