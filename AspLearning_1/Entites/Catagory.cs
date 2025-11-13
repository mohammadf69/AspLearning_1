namespace AspLearning_1.Entites;
public class Catagory
{
    public int Id { get; set; }
    public string Name  { get; set; }

    public ICollection<BookCatagory> BookCatagories { get; set; }
}