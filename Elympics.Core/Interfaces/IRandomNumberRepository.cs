public interface IRandomumberRepository {
    Task AddRandomNumber(int number);

    Task<IEnumerable<int>> GetRandomNumbers(int numbersToTake);
}