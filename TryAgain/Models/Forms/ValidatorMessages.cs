
namespace TryAgain.Models.Forms
{
    internal class ValidatorMessages
    {
        public static string EmptyValueMessage(string fieldName)
        {
            return $"Pole {fieldName} nie może być puste.";
        }

        public static string InvalidValueMessage(string fieldName)
        {
            return $"Pole {fieldName} zawiera nieprawidłową wartość.";
        }

        public static string InvalidTimeValueMessage(string fieldName)
        {
            return $"Pole {fieldName} zawiera nieprawidłowy format. Dozwolony format to HH:MM.";
        }
    }
}
