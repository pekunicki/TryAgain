using TryAgain.Persistance.Entity;

namespace TryAgain.Persistance.Repository
{
    internal interface ITeacherRepository
    {
        Teacher GetTeacherByFirstNameAndLastName(string firstName, string lastName);
        Teacher GetTeacherById(int id);
    }
}