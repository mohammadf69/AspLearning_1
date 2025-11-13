namespace AspLearning_1.Services;
using AspLearning_1.Context;
using AspLearning_1.InterFaces;

using Microsoft.EntityFrameworkCore;

public class UnitOfWork(Mycontext context): IUnitOfWork
{
    public IGenericRepository<T> Repository<T>() where T : class

    {
       return new GenericRepository<T>(context);
    }

    public int Complete()
    {
       return  context.SaveChanges();
    }



    public DbContext Context => context;
}