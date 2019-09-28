  SELECT e.DepartmentName AS [Department Name],
	     MAX(e.Salary) 
	  AS [Max Salary]
    FROM Employees 
	  AS e
GROUP BY e.DepartmentName
ORDER BY e.DepartmentName