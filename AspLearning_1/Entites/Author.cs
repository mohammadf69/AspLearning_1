namespace AspLearning_1.Entites;

using AspLearning_1.Attrebutes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Author:IValidatableObject
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

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var split = Email.Split('@');
      var result =  string.Equals(split[1], "Gamil.com", StringComparison.CurrentCulture);
      if (result) yield return new ValidationResult("Insert Key Value");
    }
}