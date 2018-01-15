using TryAgain.Models.ViewModels;

namespace TryAgain.Models.Creators
{
    public class CreatorApplicationViewModel
    {
        public static ApplicationViewModel CreateEmpty(string organizerName)
        {
            return new ApplicationViewModel
            {
                OrganizerFullName = organizerName,
                Date = new DateInApplicationViewModel(),
                Course = new CourseInApplicationViewModel()
            };
        }
    }
}

