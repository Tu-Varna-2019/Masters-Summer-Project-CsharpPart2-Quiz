using Masters_Summer_Project_CsharpPart2_Quiz.Repositories;
using Masters_Summer_Project_CsharpPart2_Quiz.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Masters_Summer_Project_CsharpPart2_Quiz;

public class Repository<T> : IRepository<T> where T : class
{

    protected readonly QuizDBContext _context;

    public Repository(QuizDBContext context)
    {
        _context = context;
    }

    public async Task<T> CreateCommand(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<T> UpdateCommand(T entity)
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();

        return entity;
    }


    public async Task DeleteCommand(T entity)
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<T> GetById(int id)
    {
        return await _context.Set<T>().FindAsync(id) ?? throw new ArgumentException("Entity not found");
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _context.Set<T>().ToListAsync();
    }



}
