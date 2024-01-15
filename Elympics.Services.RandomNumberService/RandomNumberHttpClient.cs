using Newtonsoft.Json;

public class RandomNumberHttpClient
{
    private readonly HttpClient _client;
    public RandomNumberHttpClient(HttpClient client)
    {
        _client = client;
    }

    public async Task<int> GetRandomNumber(){
        var response = await _client.GetAsync("/random-number");
        var numberResponse = await response.Content.ReadAsStringAsync();
        var numberDeserialized =  JsonConvert.DeserializeObject<dynamic>(numberResponse);
        var number = numberDeserialized?.number;
        return number;
    }
}