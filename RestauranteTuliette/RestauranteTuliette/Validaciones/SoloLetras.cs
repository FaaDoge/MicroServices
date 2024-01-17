using System.ComponentModel.DataAnnotations;

namespace RestauranteTuliette.Validaciones
{
    public class SoloLetras : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                bool bandera = false;
                string cadena = value.ToString();
                for (int i = 0; i < cadena.Length; i++)
                {
                    char letra = cadena[i];
                    if (Char.IsLetter(letra) || Char.IsWhiteSpace(letra))
                    {
                        bandera = true;
                    }
                    else
                    {
                        bandera = false;
                        break;
                    }
                }
                if (bandera == true)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Este campo debe ser solamente letras, corrija");
                }
            }
            else
            {
                return new ValidationResult("Este campo esta vacio");
            }
        }
    }
}
