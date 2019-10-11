CREATE PROC usp_GetEmployeesSalaryAboveNumber(@inputNumber DECIMAL(18, 4))
AS
	SELECT e.FirstName,
	       e.LastName
	  FROM Employees AS e
	 WHERE e.Salary >= @inputNumber

-- Executing user-defined stored procedure
GO
EXEC dbo.usp_GetEmployeesSalaryAboveNumber 48100