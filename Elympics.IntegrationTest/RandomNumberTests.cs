namespace Elympics.IntegrationTest;

public class RandomNumberTests
{
    [Fact]
    public async Task RandomNumber_WhenCalled_ShoudReturnNumber()
    {
        // Arrange
        var client = new HttpClient();

        // Act
        var response = await client.PostAsync("http://localhost:5000/random-number", null);

        // Assert
        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadAsStringAsync();
        var integers = JsonSerializer.Deserialize<int[]>(result);

        Assert.NotNull(integers);
        Assert.NotEmpty(integers);
    }
}