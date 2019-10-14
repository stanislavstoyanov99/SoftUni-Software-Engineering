CREATE PROC usp_DeleteEmployeesFromDepartment(@departmentId INT)
AS
	 -- Delete employees from the employees projects which are in the given department
	 DELETE FROM EmployeesProjects
	 WHERE EmployeeID IN (SELECT e.EmployeeID
	                        FROM Employees AS e 
						   WHERE e.DepartmentID = @departmentId);

	-- Set ManagerID to null for all managers in the given department
	 UPDATE Employees
	    SET ManagerID = NULL
	  WHERE ManagerID IN (SELECT e.EmployeeID
						    FROM Employees AS e
						   WHERE e.DepartmentID = @departmentId);

     -- Alter table Departments to allow ManagerID to be null
     ALTER TABLE Departments 
	 ALTER COLUMN ManagerID INT NULL;

	 -- Set ManagerId to null in Departments table to remove the relationship between Departments and Employees
	 UPDATE Departments
	    SET ManagerID = NULL
	  WHERE DepartmentID = @departmentId;

	  -- Delete all employees in the given department
     DELETE FROM Employees
     WHERE DepartmentID = @departmentId;

	 -- Delete all departments with the correspoding id
     DELETE FROM Departments
     WHERE DepartmentID = @departmentId;

	 -- Show the count of all employees in the department (should be 0 if delete statements are written correctly)
     SELECT COUNT(e.EmployeeID)
     FROM Employees AS e
     WHERE e.DepartmentID = @departmentId;

EXEC dbo.usp_DeleteEmployeesFromDepartment 1
