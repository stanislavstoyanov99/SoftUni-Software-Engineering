namespace SulsApp.Services
{
    using System.Collections.Generic;

    using ViewModels.Home;
    using ViewModels.Problems;

    public interface IProblemsService
    {
        void CreateProblem(string name, int points);

        IEnumerable<IndexProblemViewModel> GetProblems();

        DetailsViewModel GetDetailsProblems(string id);
    }
}
