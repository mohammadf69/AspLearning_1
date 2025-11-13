namespace AspLearning_1.Entites;
public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }

    public StudentAddress StudentAddress { get; set; }
}