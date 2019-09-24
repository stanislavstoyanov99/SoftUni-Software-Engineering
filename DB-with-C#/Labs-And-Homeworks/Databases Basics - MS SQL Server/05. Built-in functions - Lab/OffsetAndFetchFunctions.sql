    SELECT   EmployeeID, FirstName, LastName       
      FROM   Employees
  ORDER BY   EmployeeID
    OFFSET   4 ROWS -- OFFSET skips rows
FETCH NEXT 11 ROWS ONLY -- FETCH takes rows