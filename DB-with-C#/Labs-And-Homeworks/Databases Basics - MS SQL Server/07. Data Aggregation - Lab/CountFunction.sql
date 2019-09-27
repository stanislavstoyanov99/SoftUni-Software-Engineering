  SELECT e.DepartmentName AS [Department Name],
	     COUNT(e.Salary) 
	  AS [Salary Count]
    FROM Employees 
	  AS e
GROUP BY e.DepartmentName
ORDER BY e.DepartmentName