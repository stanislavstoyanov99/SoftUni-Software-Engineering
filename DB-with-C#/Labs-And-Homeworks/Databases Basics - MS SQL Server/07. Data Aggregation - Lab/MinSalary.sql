  SELECT e.DepartmentID,
     MIN(e.Salary) AS [Min Salary]
    FROM Employees AS e
GROUP BY e.DepartmentID
ORDER BY e.DepartmentID