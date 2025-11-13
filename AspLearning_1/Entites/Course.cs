namespace AspLearning_1.Entites;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;


public class Course()
{
    [Key] public int id { get; set; }

    public  string Titele { get; set; }
    public  int AuthorId { get; set; }
    public  int  Level { get; set; }
    public  float FullPrice { get; set; } =0;

    public Author Author { get; set; }  // Navigation property


}