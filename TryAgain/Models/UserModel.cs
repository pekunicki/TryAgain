namespace TryAgain.Models
{
    public class UserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Id { get; set; }
        public string FullName => $"{FirstName} {LastName}";
    }
}