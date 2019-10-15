CREATE TABLE Logs (
LogId INT PRIMARY KEY IDENTITY,
AccountId INT NOT NULL,
OldSum DECIMAL(15, 2) NOT NULL,
NewSum DECIMAL(15, 2) NOT NULL,
CONSTRAINT FK_Logs_Accounts
FOREIGN KEY (AccountId) REFERENCES Accounts(Id)
)

GO

CREATE TRIGGER tr_SumUpdate ON Accounts
FOR UPDATE
AS
     IF EXISTS
     (
         SELECT *
           FROM Inserted
     )
         -- UPDATE Statement is executed
         INSERT INTO Logs(AccountId, OldSum, NewSum)
              SELECT d.Id, 
                     d.Balance, 
                     i.Balance
                FROM Deleted AS d
                     INNER JOIN Inserted AS i ON i.Id = d.Id;

GO

UPDATE Accounts 
   SET Balance = 113.12
 WHERE Accounts.Id = 1