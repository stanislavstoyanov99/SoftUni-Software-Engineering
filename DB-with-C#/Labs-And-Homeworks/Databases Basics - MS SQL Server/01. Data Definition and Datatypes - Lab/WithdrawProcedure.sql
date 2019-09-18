-- Withdraw Procedure

CREATE PROC p_Withdraw @AccountId INT, @Amount DECIMAL(15, 2) AS
BEGIN
  DECLARE @OldBalance DECIMAL(15, 2)
  SELECT @OldBalance = Balance FROM Accounts WHERE Id = @AccountId
  IF (@OldBalance - @Amount >= 0)
  BEGIN
    UPDATE Accounts
	SET BALANCE -= @Amount
	WHERE Id = @AccountId
  END
  ELSE
  BEGIN
    RAISERROR('Insufficient funds', 10, 1)
  END
END

-- Executing procedure
EXEC p_Withdraw 1, 175