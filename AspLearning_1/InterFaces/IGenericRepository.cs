using AspLearning_1.Entites;
using System.Linq.Expressions;

namespace AspLearning_1.InterFaces;
public interface IGenericRepository<T> where T : class
{
    void Add(T entities);

    void Update(T entities);

    void Delete(T entities);

    void RemoveRange(IEnumerable<T> entities);

    T GetById(int id);

    List<T> GetAll();
    List<T> GetAll(Expression<Func<T,bool>>Predicate);

    bool Any(Expression<Func<T, bool>> Predicate);

    
    bool SaveChange();

}