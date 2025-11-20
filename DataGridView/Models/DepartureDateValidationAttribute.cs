using System;
using System.ComponentModel.DataAnnotations;

namespace DataGridView.Models
{
    /// <summary>
    /// Атрибут валидации для проверки даты вылета
    /// </summary>
    public class DepartureDateValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime date)
            {
                if (date < DateTime.Today)
                {
                    return new ValidationResult("Дата вылета не может быть в прошлом",
                                              new[] { validationContext.MemberName });
                }

                if (date > DateTime.Today.AddYears(2))
                {
                    return new ValidationResult("Дата вылета не может быть более чем на 2 года вперед",
                                              new[] { validationContext.MemberName });
                }
            }

            return ValidationResult.Success;
        }
    }
}