SELECT mp.CountryCode, 
       COUNT(m.Id) AS [MountainRanges]
FROM Mountains AS m
     JOIN MountainsCountries AS mp ON m.Id = mp.MountainId
WHERE mp.CountryCode IN('BG', 'RU', 'US')
GROUP BY mp.CountryCode