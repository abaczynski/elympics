using Microsoft.AspNetCore.Mvc;

namespace Elympics.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RandomNumberController : ControllerBase
{
    private readonly ILogger<RandomNumberController> _logger;

    private readonly IRandomNumberService _randomNumberService;

    public RandomNumberController(ILogger<RandomNumberController> logger, IRandomNumberService randomNumberService)
    {
        _logger = logger;
        _randomNumberService = randomNumberService;
    }

    [HttpPost]
    [Route("/random-number")]
    public async Task<IEnumerable<int>> GenerateRandomNumber()
    {
        await _randomNumberService.AddNumber();

        return await _randomNumberService.GetRandomNumbers();
    }
}
