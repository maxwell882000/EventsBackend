using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using EventsBookingBackend.Application.Common.Exceptions;

namespace EventsBookingBackend.Application.Common.Validations;

public class PhoneAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (!IsValid(value))
        {
            throw new AppValidationException("Invalid phone number");
        }

        return null;
    }

    public override bool IsValid(object? value)
    {
        if (value is null) return true;

        if (value.ToString() == string.Empty) return true;

        var pattern = @"^\+998\d{9}$";

        return Regex.IsMatch(value.ToString(), pattern);
    }
}