namespace AspLearning_1.Services;
using System.Linq.Expressions;

using AspLearning_1.Context;
using AspLearning_1.Entites;
using AspLearning_1.InterFaces;

public class CourseRepository(Mycontext context):GenericRepository<Course>(context ), ICourseRepository
{
    private readonly Mycontext _context = context;

  

    public List<Course> getAll()
    {
      return  this._context.Courses.ToList();
    }

    public List<Course> getAll(Expression<Func<Course, bool>> Predicate)
    {
        return this._context.Courses.Where(predicate:Predicate).ToList();
    }

    public List<Course> GetTopSellingCourse(int count)
    {
       return this._context.Courses.OrderBy(x => x.FullPrice ).Take(count).ToList();
    }   
}