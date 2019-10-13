SELECT TOP (5) r.Id, 
       r.[Name], 
       COUNT(c.Id) AS [Commits]
FROM Repositories AS r
     JOIN Commits AS c ON r.Id = c.RepositoryId
     JOIN RepositoriesContributors AS rc ON r.Id = rc.RepositoryId
GROUP BY r.Id, 
         r.[Name]
ORDER BY COUNT(c.Id) DESC, 
         r.Id, 
         r.[Name]

SELECT * FROM Commits
SELECT * FROM Repositories