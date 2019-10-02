-- First solution
SELECT TOP(2) DepositGroup
      FROM    WizzardDeposits AS w
  GROUP BY    w.DepositGroup
  ORDER BY    AVG(MagicWandSize)

-- Second solution
SELECT DepositGroup 
  FROM (
		 SELECT TOP(2) DepositGroup,
                AVG (MagicWandSize) AS [AverageWandSize]
               FROM WizzardDeposits AS w
           GROUP BY w.DepositGroup
           ORDER BY [AverageWandSize]
	   )
    AS  [TemporaryTable]

