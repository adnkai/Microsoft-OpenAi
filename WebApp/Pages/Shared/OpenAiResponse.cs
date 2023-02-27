namespace WebApp.Pages;

public class OpenAiResponse {

    
    public String? id {get; set;} = null;
    public dynamic obj {get; set;}
    public String? created {get; set;} = null;
    public string? model {get; set;} = null;
    public ChoicesModel choices {get; set;}
    public dynamic usage {get; set;}
    
}