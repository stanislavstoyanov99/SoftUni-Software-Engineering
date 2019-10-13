GO
CREATE FUNCTION udf_UserTotalCommits(@username NVARCHAR(MAX))
RETURNS INT
AS
     BEGIN
         DECLARE @countOfCommits INT;

         SET @countOfCommits =
         (
             SELECT COUNT(c.ContributorId)
             FROM Users AS u
                  JOIN Commits AS c ON u.Id = c.ContributorId
             WHERE u.[Username] = @username
         );

         RETURN @countOfCommits;
     END

GO
SELECT dbo.udf_UserTotalCommits('UnderSinduxrein') AS [Result]