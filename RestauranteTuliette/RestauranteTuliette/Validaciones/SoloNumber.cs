using System.ComponentModel.DataAnnotations;

namespace RestauranteTuliette.Validaciones
{
    public class SoloNumber: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                bool esNumero = true;
                string cadena = value.ToString();

                foreach (char caracter in cadena)
                {
                    if (!Char.IsDigit(caracter))
                    {
                        esNumero = false;
                        break;
                    }
                }

                if (esNumero)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Este campo debe contener solo números, por favor corrija.");
                }
            }
            else
            {
                return new ValidationResult("Este campo está vacío");
            }
        }
    }
}
