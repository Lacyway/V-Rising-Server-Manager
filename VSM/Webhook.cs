using System.Collections.Generic;
using System.Net.Http;
using System.Windows.Forms;

public class dWebhook : HttpClient
{
    private readonly HttpClient dWebClient;
    private static List<KeyValuePair<string, string>> discordValues = new List<KeyValuePair<string, string>>();
    public string? WebHook { get; set; }
    public string? UserName { get; set; } = "V Rising Server Manager";
    public string? ProfilePicture { get; set; } = "https://i.imgur.com/EP0jIoZ.png";

    public dWebhook()
    {
        dWebClient = new HttpClient();
    }

    public void SendMessage(string msgSend)
    {
        try
        {
            discordValues.Add(new KeyValuePair<string, string>("username", UserName));
            discordValues.Add(new KeyValuePair<string, string>("avatar_url", ProfilePicture));
            discordValues.Add(new KeyValuePair<string, string>("content", msgSend));

            FormUrlEncodedContent content = new FormUrlEncodedContent(discordValues);

            dWebClient.PostAsync(WebHook, content);
            discordValues.Clear();
        }
        catch (System.InvalidOperationException)
        {
            //Do nothing
        }
    }
}