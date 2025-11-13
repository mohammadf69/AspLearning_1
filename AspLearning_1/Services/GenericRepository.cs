using AspLearning_1.InterFaces;

namespace AspLearning_1.Services;
using System.Linq.Expressions;

using AspLearning_1.Context;
using AspLearning_1.Entites;

public class GenericRepository<T>(Mycontext context): IGenericRepository<T> where T : class
{
    public void Add(T entities)
    {
        context.Add(entities);
    }

    public void Update(T entities)
    {
        context.Update(entities);
    }

    public void Delete(T entities)
    {
        context.Remove(entities);
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
       context.RemoveRange(entities);
    }

    public T GetById(int id)
    {
      return  context.Set<T>().Find(id)! ; 
    }

    public List<T> GetAll()
    {
        return context.Set<T>().ToList();
    }

    public List<T> GetAll(Expression<Func<T, bool>> Predicate)
    {
        return context.Set<T>().Where(Predicate).ToList();
    }

    public bool Any(Expression<Func<T, bool>> Predicate)
    {
        return context.Set<T>().Any(Predicate);
    }

    public bool SaveChange()
    {
        return context.SaveChanges() > 0;
    }
}