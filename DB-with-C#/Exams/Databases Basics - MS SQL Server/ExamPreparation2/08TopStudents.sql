SELECT TOP (10) s.FirstName AS [First Name], 
                s.LastName AS [Last Name], 
                CAST(AVG(se.Grade) AS DECIMAL(3, 2)) AS [Grade]
FROM Students AS s
     JOIN StudentsExams AS se ON se.StudentId = s.Id
GROUP BY s.FirstName, 
         s.LastName
ORDER BY AVG(se.Grade) DESC, 
         [First Name], 
         [Last Name]