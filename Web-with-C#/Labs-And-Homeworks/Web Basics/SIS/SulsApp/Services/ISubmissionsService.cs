namespace SulsApp.Services
{
    using ViewModels.Submissions;

    public interface ISubmissionsService
    {
        void Create(string code, string problemId, string userId);

        void Delete(string submissionId);

        SubmissionViewModel GetProblem(string id);
    }
}
