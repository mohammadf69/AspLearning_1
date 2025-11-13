namespace AspLearning_1.Services;
using AspLearning_1.Context;
using AspLearning_1.Entites;
using AspLearning_1.InterFaces;

public class StudentRepository(Mycontext context) :GenericRepository<Student>(context),IStudentRepository
{
    
}