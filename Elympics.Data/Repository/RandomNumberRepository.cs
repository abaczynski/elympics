
using Elympics.Data;
using Microsoft.EntityFrameworkCore;
using static Elympics.Data.RandomNumberDbContext;

public class RandomNumberRepository : IRandomumberRepository
{
    private readonly RandomNumberDbContext _context;
    public RandomNumberRepository(RandomNumberDbContext context)
    {
        _context = context;
    }
    public async Task AddRandomNumber(int number)
    {
        await _context.AddAsync(new RandomNumber(){NumberValue = number});
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<int>> GetRandomNumbers(int numbersToTake)
    {
        var result =  await _context.Numbers.Take(numbersToTake).AsNoTracking().ToListAsync();

        return result.Select(x => x.NumberValue).AsEnumerable();
    }
}