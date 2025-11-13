namespace AspLearning_1.Context;
using AspLearning_1.Entites;

using Microsoft.EntityFrameworkCore;

public class Mycontext(DbContextOptions<Mycontext> options) : DbContext(options)
{
    public DbSet<Course> Courses => this.Set<Course>();
    public DbSet<User> Users => this.Set<User>();
    public DbSet<Catagory> Catagories => this.Set<Catagory>();

    public DbSet<Book> Books => this.Set<Book>();
    public DbSet<Author> Author => this.Set<Author>();


    public DbSet<BookCatagory> BookCatagories => this.Set<BookCatagory>();



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
   

        modelBuilder.Entity<Author>().HasMany(x => x.Courses).WithOne(x => x.Author)
            .HasForeignKey(x => x.AuthorId).OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Student>().HasOne(x => x.StudentAddress).WithOne(x => x.Student)
            .HasForeignKey<StudentAddress>(x => x.studenetId).HasPrincipalKey<Student>(x=>x.Id);

        //many to many
        modelBuilder.Entity<BookCatagory>().HasKey(x => new { x.BookId, x.CatagoryId });

        modelBuilder.Entity<BookCatagory>().HasOne(x => x.Book).WithMany(x => x.BookCatagories)
            .HasForeignKey(x => x.BookId);

        modelBuilder.Entity<BookCatagory>().HasOne(x => x.Catagory).WithMany(x => x.BookCatagories)
            .HasForeignKey(x => x.CatagoryId);

        base.OnModelCreating(modelBuilder);
    }
}
