
namespace TryAgain.Utils.ValidatiorMessages
{
    internal class ValidatorMessages
    {
        public static string EmptyValueMessage(string fieldName)
        {
            var propertyName = GetPropertyName(fieldName);
            return $"Pole {propertyName} nie może być puste.";
        }

        public static string InvalidValueMessage(string fieldName)
        {
            var propertyName = GetPropertyName(fieldName);
            return $"Pole {propertyName} zawiera nieprawidłową wartość.";
        }

        public static string InvalidTimeValueMessage(string fieldName)
        {
            var propertyName = GetPropertyName(fieldName);
            return $"Pole {propertyName} zawiera nieprawidłowy format. Dozwolony formaty to HH:MM lub HH:MM:SS.";
        }

        private static string GetPropertyName(string fieldName)
        {
            return string.IsNullOrWhiteSpace(fieldName) ? "{PropertyName}" : fieldName;
        }
    }
}
