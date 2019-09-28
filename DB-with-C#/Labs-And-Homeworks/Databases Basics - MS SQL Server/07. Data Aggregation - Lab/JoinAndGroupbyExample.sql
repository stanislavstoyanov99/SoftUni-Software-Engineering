  SELECT d.[Name] AS DepartmentName,
   COUNT (Salary) AS SalaryCount
    FROM Employees AS e
    JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
GROUP BY d.[Name]
ORDER BY SalaryCount
