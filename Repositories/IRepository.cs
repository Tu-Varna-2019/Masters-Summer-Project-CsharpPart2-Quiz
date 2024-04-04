namespace Masters_Summer_Project_CsharpPart2_Quiz.Repositories;

public interface IRepository<T> where T : class
{
    public Task DeleteCommand(T entity);
    public Task<T> UpdateCommand(T entity);
    public Task<T> CreateCommand(T entity);
    public Task<T> GetById(int id);
    public Task<IEnumerable<T>> GetAll();
}
