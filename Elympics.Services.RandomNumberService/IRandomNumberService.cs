public interface IRandomNumberService {
    Task AddNumber();
    Task<IEnumerable<int>> GetRandomNumbers();
}