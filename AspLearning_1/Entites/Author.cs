namespace AspLearning_1.Entites;

using AspLearning_1.Attrebutes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Author
{
    [Key]
    public int Id { get;  set; }

    [Range(10,80,ErrorMessage = "dd")]
    public int Age { get; set; }

    public string  Name { get; set; }
    [ValidationEmailAttribute("Gmail.com","dddd")]
    public string  Email { get; set; }



    [InverseProperty("Author")]
    public ICollection<Course> Courses { get; set; } = new List<Course>();
}