-- Creating Transactions Table and a Trigger

CREATE TABLE Transactions (
Id INT PRIMARY KEY IDENTITY,
AccountId INT FOREIGN KEY REFERENCES Accounts(Id),
OldBalance DECIMAL(15, 2) NOT NULL,
NewBalance DECIMAL(15, 2) NOT NULL,
Amount AS NewBalance - OldBalance,
[DateTime] DATETIME2
)

CREATE TRIGGER tr_Transaction ON Accounts
AFTER UPDATE
AS
  INSERT INTO Transactions (AccountId, OldBalance, NewBalance, [DateTime])
  SELECT inserted.Id, deleted.Balance, inserted.Balance, GETDATE() FROM inserted
  JOIN deleted ON inserted.Id = deleted.Id

EXEC p_Deposit 1, 25.00

EXEC p_Deposit 1, 40.00

EXEC p_Withdraw 2, 200.00

EXEC p_Deposit 4, 180.00

-- Activating Trigger when Updating data
UPDATE Accounts
SET Balance = 200
WHERE Id = 1;