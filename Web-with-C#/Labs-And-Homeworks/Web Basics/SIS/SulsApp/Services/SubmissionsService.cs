namespace SulsApp.Services
{
    using System;
    using System.Linq;

    using Data;
    using Models;

    public class SubmissionsService : ISubmissionsService
    {
        private readonly ApplicationDbContext db;
        private readonly Random random;

        public SubmissionsService(ApplicationDbContext db, Random random)
        {
            this.db = db;
            this.random = random;
        }

        public void CreateSubmission(string code, string problemId, string userId)
        {
            var problem = this.db.Problems.FirstOrDefault(x => x.Id == problemId);

            var submission = new Submission
            {
                AchievedResult = random.Next(0, problem.Points + 1),
                CreatedOn = DateTime.UtcNow,
                Code = code,
                UserId = userId,
                ProblemId = problemId
            };

            this.db.Submissions.Add(submission);
            this.db.SaveChanges();
        }

        public void DeleteSubmission(string submissionId)
        {
            var submission = this.db.Submissions.FirstOrDefault(x => x.Id == submissionId);
            this.db.Submissions.Remove(submission);
            this.db.SaveChanges();
        }
    }
}
