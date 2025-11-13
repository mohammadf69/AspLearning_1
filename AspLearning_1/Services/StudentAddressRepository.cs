using AspLearning_1.Entites;

namespace AspLearning_1.Services;
using AspLearning_1.Context;
using AspLearning_1.InterFaces;

public class StudentAddressRepository(Mycontext context) :GenericRepository<StudentAddress>(context),IStudentAddressRepository
{
    
}