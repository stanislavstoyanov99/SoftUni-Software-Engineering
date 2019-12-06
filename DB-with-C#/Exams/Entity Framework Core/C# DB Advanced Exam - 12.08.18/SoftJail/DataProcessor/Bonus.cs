namespace SoftJail.DataProcessor
{
    using System;
    using System.Linq;

    using Data;

    public class Bonus
    {
        private const string SentencedToLife =
            "Prisoner {0} is sentenced to life";

        private const string ReleasedPrisoner =
            "Prisoner {0} released";

        public static string ReleasePrisoner(SoftJailDbContext context, int prisonerId)
        {
            var prisoner = context.Prisoners.FirstOrDefault(p => p.Id == prisonerId);

            string resultMessage = string.Empty;

            if (prisoner.ReleaseDate == null)
            {
                resultMessage = String.Format(SentencedToLife, prisoner.FullName);
            }
            else
            {
                prisoner.ReleaseDate = DateTime.Now.Date;
                prisoner.CellId = null;

                context.Prisoners.Update(prisoner);
                context.SaveChanges();

                resultMessage = string.Format(ReleasedPrisoner, prisoner.FullName);
            }

            return resultMessage;
        }
    }
}
