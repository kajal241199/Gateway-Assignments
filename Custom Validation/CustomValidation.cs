using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SignupWithLogin.Custom_Validation
{
    public class CustomValidation
    {
    }
    public sealed class ValidBirthDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime _birthJoin = Convert.ToDateTime(value);
            DateTime minDate = Convert.ToDateTime("01-25-1970");
            DateTime maxDate = Convert.ToDateTime("01-25-1998");

            if (_birthJoin > minDate && _birthJoin < maxDate)
                return ValidationResult.Success;
            else
                return new ValidationResult(ErrorMessage);
        }
    }
}