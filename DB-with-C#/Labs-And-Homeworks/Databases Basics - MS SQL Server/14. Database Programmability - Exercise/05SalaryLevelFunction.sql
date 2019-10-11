CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS NVARCHAR(10)
AS
BEGIN
	DECLARE @salaryLevel NVARCHAR(10);
	IF(@salary < 30000)
		BEGIN
			SET @salaryLevel = 'Low'
		END
	ELSE IF(@salary >= 30000 AND @salary <= 50000)
		BEGIN
			SET @salaryLevel = 'Average'
		END
	ELSE
		BEGIN
			SET @salaryLevel = 'High'
		END
	RETURN @salaryLevel
END
GO
SELECT e.Salary,
       dbo.ufn_GetSalaryLevel(e.Salary) AS [Salary Level]
  FROM Employees AS e