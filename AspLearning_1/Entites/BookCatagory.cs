namespace AspLearning_1.Entites;
public class BookCatagory
{
    public int BookId { get; set; }
    public Book Book { get; set; }

    public int CatagoryId { get; set; }
    public Catagory  Catagory { get; set; }
}