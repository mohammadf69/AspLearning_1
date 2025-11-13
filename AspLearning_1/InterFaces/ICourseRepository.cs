namespace AspLearning_1.InterFaces;
using AspLearning_1.Entites;
using System.Linq.Expressions;

public interface ICourseRepository:IGenericRepository<Course>
{
   
    List<Course> getAll();
    List<Course> getAll(Expression<Func<Course, bool>> Predicate);

    List<Course> GetTopSellingCourse(int count);
}