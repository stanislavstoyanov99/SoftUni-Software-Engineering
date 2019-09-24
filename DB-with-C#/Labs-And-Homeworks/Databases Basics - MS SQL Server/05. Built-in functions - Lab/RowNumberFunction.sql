  SELECT ROW_NUMBER() OVER (
ORDER BY FirstName) 
         Id,
         FirstName, 
         LastName, 
         JobTitle
    FROM Employees