using TryAgain.Persistance.Entity;

namespace TryAgain.Persistance.Repository
{
    internal interface ICourseRepository
    {
        Course GetCourseByName(string name);
        Course GetCourseById(int id);
    }
}
