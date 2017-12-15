using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace REMindAP.Core.Validators
{
    public class DateAttribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime date;
            if (value != null && DateTime.TryParse(value.ToString(), out date))
                return ValidationResult.Success;

            return new ValidationResult("Wrong date format");
        }
    }
}
