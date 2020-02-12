namespace SulsApp.ViewModels.Problems
{
    using System;

    public class ProblemSubmissionViewModel
    {
        public string Username { get; set; }

        public int AchievedResult { get; set; }

        public int MaxPoints { get; set; }

        public DateTime CreatedOn { get; set; }

        public string SubmissionId { get; set; }
    }
}
