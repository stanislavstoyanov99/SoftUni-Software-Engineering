CREATE PROC usp_GetHoldersFullName
AS
	SELECT CONCAT(ah.FirstName, ' ', ah.LastName) AS [Full Name]
	  FROM AccountHolders AS ah

EXEC dbo.usp_GetHoldersFullName