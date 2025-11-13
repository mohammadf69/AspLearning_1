namespace AspLearning_1.Entites;
public class Book
{
    public int BookId { get; set; }
    public string Title { get; set; }
    public string Aouher { get; set; }

    public int Level { get; set; }
    public ICollection<BookCatagory> BookCatagories { get; set; }
}   