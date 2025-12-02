using System;
using System.ComponentModel.DataAnnotations;

public class ValidationEmailAttribute : ValidationAttribute
{
    private readonly string _allowDomain;

    public ValidationEmailAttribute(string allowDomain, string errorMessage)
    {
        if (string.IsNullOrWhiteSpace(allowDomain))
            throw new ArgumentException("allowDomain نمی‌تواند خالی باشد.", nameof(allowDomain));

        _allowDomain = allowDomain.Trim();
        ErrorMessage = errorMessage ?? "ایمیل نامعتبر است.";
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        // مقدار خالی را نامعتبر در نظر می‌گیریم (یا اگر خواستی می‌توانیم اجازه دهیم و بررسی را نکنیم)
        if (value is null)
            return new ValidationResult(ErrorMessage);

        var email = value.ToString()!.Trim();

        // بررسی ساده و امن برای وجود یک '@' و قسمت دامنه
        var parts = email.Split('@');
        if (parts.Length != 2 || string.IsNullOrWhiteSpace(parts[0]) || string.IsNullOrWhiteSpace(parts[1]))
            return new ValidationResult(ErrorMessage);

        // مقایسه دامنه (حساس به حروف نیست)
        if (!string.Equals(parts[1], _allowDomain, StringComparison.OrdinalIgnoreCase))
            return new ValidationResult(ErrorMessage);

        return ValidationResult.Success;
    }
}