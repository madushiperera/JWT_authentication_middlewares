using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

public class UsernameValidationAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        string username = value as string;
        if (string.IsNullOrEmpty(username))
        {
            return new ValidationResult("Username is required.");
        }

        // Use regular expression to match only characters and numbers
        if (!Regex.IsMatch(username, @"^[a-zA-Z0-9]+$"))
        {
            return new ValidationResult("Username can only contain characters and numbers.");
        }

        return ValidationResult.Success;
    }
}

/*public class NameValidationAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value == null || string.IsNullOrEmpty(value.ToString()))
        {
            return ValidationResult.Success;
        }


        string name = value as string;
        // Use regular expression to match only characters
        if (!Regex.IsMatch(name, @"^[a-zA-Z]+$"))
        {
            return new ValidationResult($"{validationContext.DisplayName} can only contain characters.");
        }

        return ValidationResult.Success;
    }
}*/

public class NameValidationAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        // Check if the value is null or empty
        if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
        {
            // If the value is null or empty, return success
            return ValidationResult.Success;
        }

        string name = value as string;

        // Use regular expression to match only characters
        if (!Regex.IsMatch(name, @"^[a-zA-Z]+$"))
        {
            return new ValidationResult($"{validationContext.DisplayName} can only contain characters.");
        }

        return ValidationResult.Success;
    }
}


public class EmailValidationAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        string email = value as string;
        if (string.IsNullOrEmpty(email))
        {
            return new ValidationResult("Email address is required.");
        }

        // Use .NET's built-in EmailAddressAttribute for email validation
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            if (addr.Address != email)
            {
                throw new Exception();
            }
        }
        catch
        {
            return new ValidationResult("Invalid email address.");
        }

        return ValidationResult.Success;
    }
}
