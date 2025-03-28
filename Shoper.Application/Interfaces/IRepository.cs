using System.Linq.Expressions;

namespace ShoperApplication.Interfaces;

public interface IRepository<T>  where T : class
{
    Task<List<T>> GetAllAsync();//T değişkeninden tüm listi almak için kullanıyoruz.
    Task<T> GetByIdAsync(int id);//id ye göre sorgu ile data getirir
    Task  CreateAsync(T entity);
    Task  UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<T>GetByFilterAsync(Expression<Func<T, bool>>filter);
    
    Task<List<T>>GetTakeAsync(int piece);
    
}