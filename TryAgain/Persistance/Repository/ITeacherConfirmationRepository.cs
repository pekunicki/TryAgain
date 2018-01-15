using TryAgain.Models.Constants;
using TryAgain.Persistance.Entity;

namespace TryAgain.Persistance.Repository
{
    internal interface ITeacherConfirmationRepository
    {
        TeacherConfirmation Create(TeacherConfirmation confirmation);
        TeacherConfirmation GetTeacherConfirmationByLink(string link);
        TeacherConfirmation UpdateTeacherConfirmation(string id, ConfirmationState newState);
    }
}