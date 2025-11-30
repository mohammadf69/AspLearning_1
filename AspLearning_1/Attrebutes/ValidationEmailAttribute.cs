using System.ComponentModel.DataAnnotations;

namespace AspLearning_1.Attrebutes;

public class ValidationEmailAttribute(string allowDomain,string errorMessage):ValidationAttribute
{
    private readonly string _allowDomain = allowDomain;
    private readonly string _errorMessage = errorMessage;


    public override bool IsValid(object? value)
    {
        var split = value?.ToString()!.Split('@');

        return string.Equals(split[1], this._allowDomain, StringComparison.CurrentCulture);
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var split = value?.ToString()!.Split('@');
        var result = string.Equals(split[1], this._allowDomain, StringComparison.CurrentCulture);
        if(result)return ValidationResult.Success;
        return new ValidationResult(string.Format(ErrorMessage ?? "..."));
        
    }
}