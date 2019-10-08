-- First solution
SELECT TOP (5) [TempResult].CountryName, 
               [TempResult].[HighestPeakElevation], 
               [TempResult].[LongestRiverLength]
FROM
(
    SELECT c.CountryName, 
           p.Elevation AS [HighestPeakElevation], 
           r.[Length] AS [LongestRiverLength], 
           DENSE_RANK() OVER(PARTITION BY c.CountryName
           ORDER BY p.Elevation DESC) AS [ElevationRank], 
           DENSE_RANK() OVER(PARTITION BY c.CountryName
           ORDER BY r.[Length] DESC) AS [RiverRank]
    FROM MountainsCountries AS mp
         LEFT JOIN Peaks AS p ON mp.MountainId = p.MountainId
         LEFT JOIN Countries AS c ON mp.CountryCode = c.CountryCode
         LEFT JOIN CountriesRivers AS cr ON mp.CountryCode = cr.CountryCode
         LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
    GROUP BY c.CountryName, 
             p.Elevation, 
             r.[Length]
) AS [TempResult]
WHERE [ElevationRank] = 1
      AND [RiverRank] = 1
ORDER BY [TempResult].[HighestPeakElevation] DESC, 
         [TempResult].[LongestRiverLength] DESC, 
         [TempResult].CountryName

-- Second Solution
SELECT TOP (5) c.CountryName, 
               MAX(p.Elevation) AS [HighestPeakElevation], 
               MAX(r.[Length]) AS [LongestRiverLength]
FROM MountainsCountries AS mp
     LEFT JOIN Peaks AS p ON mp.MountainId = p.MountainId
     LEFT JOIN Countries AS c ON mp.CountryCode = c.CountryCode
     LEFT JOIN CountriesRivers AS cr ON mp.CountryCode = cr.CountryCode
     LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
GROUP BY c.CountryName
ORDER BY [HighestPeakElevation] DESC, 
         [LongestRiverLength] DESC, 
         c.CountryName