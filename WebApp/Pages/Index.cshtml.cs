using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Azure.AI.OpenAI;
using Azure.Core;
using Azure;

using System.Text.Json;

namespace WebApp.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    private Uri _uri = new Uri("https://openaiservicekr.openai.azure.com/");
    private String _key = "";
    private AzureKeyCredential _creds;
    private OpenAIClient _client;

    String myRequest = "Tell me something about the new world order.";

    public IndexModel(ILogger<IndexModel> logger)
    {
        _creds = new AzureKeyCredential(_key);
        _logger = logger;
        _client = new OpenAIClient(_uri, _creds);
    }

    public void OnGet()
    {

    }

    public async Task OnPost(string prompt, string model) {

        OpenAiModel m = new OpenAiModel();
        m.prompt = new[] {
            prompt
        };
        m.model = model;
        // m.logit_bias = null;
        m.max_tokens = 420;
        m.temperature = 0.2;
        m.n = 2;
        m.logprobs = 2;
        m.echo = true;
        m.cache_level = 1;
        m.presence_penalty = 1;
        m.frequency_penalty = 1;
        m.best_of = 10;

        var req = RequestContent.Create(m);
        Response response = await _client.GetCompletionsAsync("GPT", req);
        JsonElement result = JsonDocument.Parse(response.ContentStream!).RootElement;
        
        OpenAiResponse openAiResponse = new OpenAiResponse();
        ChoicesModel choicesModel = new ChoicesModel();
        choicesModel.text = result.GetProperty("choices")[0].GetProperty("text").ToString();
        choicesModel.index = result.GetProperty("choices")[0].GetProperty("index").ToString();
        choicesModel.logprobs = result.GetProperty("choices")[0].GetProperty("logprobs").GetProperty("tokens")[0].ToString();
        choicesModel.finish_reason = result.GetProperty("choices")[0].GetProperty("finish_reason").ToString();

        openAiResponse.choices = choicesModel;
        openAiResponse.created = result.GetProperty("created").ToString();
        openAiResponse.id = result.GetProperty("id").ToString();
        openAiResponse.obj = result.GetProperty("object").ToString();
        openAiResponse.model = result.GetProperty("model").ToString();
        openAiResponse.usage = new {
            completion_tokens = result.GetProperty("usage").GetProperty("completion_tokens").ToString(),
            prompt_tokens = result.GetProperty("usage").GetProperty("prompt_tokens").ToString(),
            total_tokens = result.GetProperty("usage").GetProperty("total_tokens").ToString()
        };
        Console.WriteLine("posted");
        ViewData["openAiResponseModel"] = openAiResponse;
        Console.WriteLine(openAiResponse.choices.text);
        
    }
}
