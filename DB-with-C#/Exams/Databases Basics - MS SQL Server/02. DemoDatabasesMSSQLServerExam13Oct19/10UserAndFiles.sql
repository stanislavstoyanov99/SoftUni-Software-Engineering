SELECT u.Username, 
       AVG(f.Size) AS [Size]
FROM Commits AS c
     RIGHT JOIN Users AS u ON c.ContributorId = u.Id
     RIGHT JOIN Files AS f ON c.Id = f.CommitId
GROUP BY u.Username
ORDER BY AVG(f.Size) DESC, 
         u.Username