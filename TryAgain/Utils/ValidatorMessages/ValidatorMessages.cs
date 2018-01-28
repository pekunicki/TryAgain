
namespace TryAgain.Utils.ValidatorMessages
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

        public static string NotExistsInDatabase(string fieldName)
        {
            var propertyName = GetPropertyName(fieldName);
            return $"Podana wartość w polu {propertyName} nie istnieje w bazie danych.";
        }

        public static string InvalidTimeValueMessage(string fieldName)
        {
            var propertyName = GetPropertyName(fieldName);
            return $"Pole {propertyName} zawiera nieprawidłowy format. Dozwolony formaty to HH:MM lub HH:MM:SS.";
        }

        public static string ShouldBeGreaterThan(string oppositeField, string fieldName)
        {
            var propertyName = GetPropertyName(fieldName);
            return $"Pole {propertyName} powinno zawierać większą wartość niż {oppositeField}";
        }

        private static string GetPropertyName(string fieldName)
        {
            return string.IsNullOrWhiteSpace(fieldName) ? "{PropertyName}" : fieldName;
        }
    }
}
