namespace AspLearning_1.InterFaces;
using Microsoft.EntityFrameworkCore;

public interface IUnitOfWork
{
    public IGenericRepository<T> Repository<T>()
        where T : class; 

    public int Complete();


    DbContext Context { get; } 
}