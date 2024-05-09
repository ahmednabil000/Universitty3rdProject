

using System.ComponentModel.DataAnnotations;

public class DateValidationAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        var userDate = (DateTime)value;

        if (userDate < DateTime.Now) return false;

        return true;
    }
}