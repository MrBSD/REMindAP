using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace REMindAP.Core.Validators
{
    public class TimeAttribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string pattern = "^([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$";
            Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);


            if (value!=null && rgx.IsMatch(value.ToString()))
                return ValidationResult.Success;

            return new ValidationResult("Wrong time format");

        }


    }
}
