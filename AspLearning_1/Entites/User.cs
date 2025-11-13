namespace AspLearning_1.Entites;
public class User
{
    // 🆔 مشخصات پایه
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    // 📧 اطلاعات تماس
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;

    // 🔐 امنیت و ورود
    public string UserName { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public bool IsEmailConfirmed { get; set; } = false;
    public string Role { get; set; } = "User"; // User, Admin, etc.

    // 📅 متا دیتا
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? LastLogin { get; set; }

    // ⚙️ چیزای اضافی
    public bool IsActive { get; set; } = true;
    public string ProfilePictureUrl { get; set; } = string.Empty;
}
