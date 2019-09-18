-- Deposit Procedure

CREATE PROC p_Deposit @AccountId INT, @Amount DECIMAL(15, 2) AS
UPDATE Accounts
SET BALANCE += @Amount
WHERE Id = @AccountId

-- Executing Procedure
EXEC p_Deposit 1, 25
