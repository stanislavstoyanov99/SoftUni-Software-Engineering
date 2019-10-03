-- First Solution
SELECT SUM([Result].Diff) 
    AS [SumDifference]
  FROM (
         SELECT DepositAmount - (
		                          SELECT DepositAmount 
								    FROM WizzardDeposits 
									  AS w 
								   WHERE w.Id = wd.Id + 1
								) 
		     AS Diff
		   FROM WizzardDeposits 
		     AS wd
	    )
	AS [Result]

-- Second Solution
SELECT SUM([Difference]) 
    AS [SumDifference] 
  FROM (
        SELECT FirstName AS [Host Wizard FirstName],
               DepositAmount AS [Host Wizard Deposit Amount],
        	   LEAD(FirstName) OVER (ORDER BY Id) AS [Guest Wizard],
        	   LEAD(DepositAmount) OVER (ORDER BY Id) AS [Guest Wizard Deposit],
        	   DepositAmount - LEAD(DepositAmount) OVER (ORDER BY Id) AS [Difference]
          FROM WizzardDeposits
	   ) 
    AS DiffTable