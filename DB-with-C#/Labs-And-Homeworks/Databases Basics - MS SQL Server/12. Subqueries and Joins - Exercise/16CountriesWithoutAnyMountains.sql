SELECT COUNT(c.CountryCode) AS [CountryCode]
FROM MountainsCountries AS mc
     JOIN Mountains AS m ON mc.MountainId = m.Id
     RIGHT JOIN Countries AS c ON mc.CountryCode = c.CountryCode
WHERE mc.MountainId IS NULL