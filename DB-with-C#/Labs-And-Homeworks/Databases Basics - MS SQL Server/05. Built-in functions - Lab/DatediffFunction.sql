SELECT EmployeeId, FirstName, LastName,
       DATEDIFF(YEAR, HireDate, GETDATE())
    AS [Years in service]
  FROM Employees  