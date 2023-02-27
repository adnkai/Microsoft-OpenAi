namespace WebApp.Pages;

public class ChoicesModel {

    public String? text {get; set;} = null;
    public String? index {get; set;} = null;
    public dynamic? logprobs {get; set;} = null;
    public String? finish_reason {get; set;} = null;
   
}