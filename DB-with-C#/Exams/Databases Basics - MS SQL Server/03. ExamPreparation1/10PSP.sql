SELECT p.[Name] AS [Plane Name], 
       p.[Seats] AS [Seats], 
       COUNT(pa.Id) AS [Passengers Count]
FROM Planes AS p
     LEFT JOIN Flights AS f ON p.Id = f.PlaneId
     LEFT JOIN Tickets AS t ON f.Id = t.FlightId
     LEFT JOIN Passengers AS pa ON pa.Id = t.PassengerId
GROUP BY p.[Name], 
         p.[Seats]
ORDER BY COUNT(pa.Id) DESC, 
         [Plane Name], 
         p.[Seats]