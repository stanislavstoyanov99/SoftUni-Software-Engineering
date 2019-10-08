SELECT TOP (5) c.CountryName AS [Country], 
               IIF(p.PeakName IS NULL, '(no highest peak)', p.PeakName) AS [Highest Peak Name], 
               IIF(MAX(p.Elevation) IS NULL, 0, MAX(p.Elevation)) AS [Highest Peak Elevation], 
               IIF(m.MountainRange IS NULL, '(no mountain)', m.MountainRange) AS [Mountain]
FROM MountainsCountries AS mp
     RIGHT JOIN Mountains AS m ON mp.MountainId = m.Id
     RIGHT JOIN Peaks AS p ON mp.MountainId = p.MountainId
     RIGHT JOIN Countries AS c ON mp.CountryCode = c.CountryCode
GROUP BY c.CountryName, 
         p.PeakName, 
         m.MountainRange
ORDER BY c.CountryName, 
         p.PeakName