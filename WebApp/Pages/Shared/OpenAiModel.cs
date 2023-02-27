namespace WebApp.Pages;

public class OpenAiModel {

    
    public String[]? prompt {get; set;}
    public int? max_tokens {get; set;} = 420; // response length
    public double? temperature {get; set;} = 0.2; 
    public int? top_p {get; set;}
    // public Dictionary<string, int>? logit_bias {get; set;}
    // public string? user {get; set;}
    public int? n {get; set;} = 2; 
    public int? logprobs {get; set;}
    public string? model {get; set;} = "text-davinci-003"; // gpt3.0 model
    public bool? echo {get; set;} = true;
    public string? stop {get; set;}
    public string? completion_config {get; set;}
    public int? cache_level {get; set;}
    public int? presence_penalty {get; set;} = 1;
    public int? frequency_penalty {get; set;} = 1;
    public int? best_of {get; set;} = 10;
}