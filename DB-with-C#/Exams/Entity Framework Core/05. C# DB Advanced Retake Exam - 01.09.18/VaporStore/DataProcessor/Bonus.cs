namespace VaporStore.DataProcessor
{
    using System.Linq;

    using Data;

	public static class Bonus
	{
        private const string UserNotFound = "User {0} not found";
        private const string EmailAlreadyTaken = "Email {0} is already taken";
        private const string ChangedEmailSuccessfully = "Changed {0}'s email successfully";

        public static string UpdateEmail(VaporStoreDbContext context, string username, string newEmail)
		{
            string resultMessage = string.Empty;

            var user = context.Users
                .FirstOrDefault(u => u.Username == username);

            if (user == null)
            {
                resultMessage = string.Format(UserNotFound, username);
            }
            else
            {
                var userWithEmail = context.Users
                    .FirstOrDefault(u => u.Email == newEmail);

                if (userWithEmail != null)
                {
                    resultMessage = string.Format(EmailAlreadyTaken, newEmail);
                }
                else
                {
                    user.Email = newEmail;
                    resultMessage = string.Format(ChangedEmailSuccessfully, username);
                }
            }

            return resultMessage;
		}
	}
}
