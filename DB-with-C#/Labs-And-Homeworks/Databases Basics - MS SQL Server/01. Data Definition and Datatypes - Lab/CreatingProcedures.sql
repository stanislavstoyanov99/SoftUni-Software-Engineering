-- Creating Procedures

CREATE PROC p_AddAccount @ClientId INT, @AccountTypeId INT AS
INSERT INTO Accounts (ClientId, AccountTypeId)
VALUES (@ClientId, @AccountTypeId)

-- Executing Procedure
EXEC p_AddAccount 2, 2
