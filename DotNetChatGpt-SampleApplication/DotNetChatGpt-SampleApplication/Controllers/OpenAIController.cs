using Microsoft.AspNetCore.Mvc;
using OpenAI_API;
using OpenAI_API.Completions;

namespace DotNetChatGpt_SampleApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenAIController : ControllerBase
    {
        [HttpGet]
        [Route("ChatGpt")]
        public async Task<IActionResult>ChatGpt(string query)
        {
            string result=string.Empty;
            var openAi = new OpenAIAPI("ApiKey"); // Pass your Api Key
            CompletionRequest completionRequest=new CompletionRequest();
            completionRequest.Prompt=query;
            completionRequest.Model = OpenAI_API.Models.Model.DavinciText;
            completionRequest.MaxTokens=1024;
            var completions = await openAi.Completions.CreateCompletionAsync(completionRequest);
            foreach(var completion in completions.Completions)
            {
                result += completion.Text;
            }
            return Ok(result);
        }
    }
}
