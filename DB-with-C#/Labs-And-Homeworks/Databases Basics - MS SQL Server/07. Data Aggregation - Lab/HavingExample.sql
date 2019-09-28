  SELECT d.[Name] AS DepartmentName,
     SUM (Salary) AS TotalSalary
    FROM Employees AS e
    JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
GROUP BY d.[Name]
  HAVING SUM(e.Salary) >= 15000
ORDER BY TotalSalary 
    DESC