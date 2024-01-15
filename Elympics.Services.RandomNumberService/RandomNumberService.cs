using Microsoft.Extensions.Configuration;

namespace Elympics.Services.RandomNumberService;
public class RandomNumberService : IRandomNumberService
{
    private readonly IRandomumberRepository _randomumberRepository;
    private readonly RandomNumberHttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public RandomNumberService(IRandomumberRepository randomumberRepository, RandomNumberHttpClient httpClient, IConfiguration configuration)
    {
        _randomumberRepository = randomumberRepository;
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task AddNumber()
    {
        var number = await _httpClient.GetRandomNumber();

        await _randomumberRepository.AddRandomNumber(number);
    }

    public async Task<IEnumerable<int>> GetRandomNumbers()
    {
        
        int numbersToTake;
        var envNumber = Environment.GetEnvironmentVariable("NumbersToTake");
        if(!int.TryParse(envNumber, out numbersToTake)){
            numbersToTake = int.Parse(_configuration.GetSection("Services")["NumbersToTake"]);
        }
        
        return await _randomumberRepository.GetRandomNumbers(numbersToTake);
    }
}
