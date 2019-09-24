CREATE VIEW     Vw_QuarterlyReport AS
 SELECT TOP(30) EmployeeID,
                Salary,
	            DATEPART(QUARTER, HireDate) AS [Quarter],
	            DATEPART(MONTH, HireDate) AS [Month],
	            DATEPART(YEAR, HireDate) AS [Year],
	            DATEPART(Day, HireDate) AS [Day]
       FROM     Employees
   ORDER BY     SALARY 
       DESC
     SELECT     * 
	   FROM     Vw_QuarterlyReport