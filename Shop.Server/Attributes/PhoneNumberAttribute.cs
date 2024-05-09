using System;
using System.ComponentModel.DataAnnotations;

public class PhoneNumberAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        if (value == null) return false;

        var phone = value as string;

        if (IsPhoneNumberValid(phone)) return true;

        return false;
    }
    private bool IsPhoneNumberValid(string phoneNumber)
    {
        if (phoneNumber.Length == 11 && (phoneNumber.StartsWith("011") || phoneNumber.StartsWith("012") || phoneNumber.StartsWith("010") || phoneNumber.StartsWith("015")))
        {
            return true;
        }

        return false;
    }
}