SELECT  ProjectID,
        [Name], ISNULL(CAST(EndDate AS VARCHAR), 'Not Finished') AS [Date]
  FROM  Projects