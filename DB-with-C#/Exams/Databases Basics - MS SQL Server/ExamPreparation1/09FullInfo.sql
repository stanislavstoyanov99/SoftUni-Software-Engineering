SELECT CONCAT(p.FirstName, ' ', p.LastName) AS [Full Name],
       pl.[Name],
	   CONCAT(f.Origin, ' - ', f.Destination) AS [Trip],
	   lt.[Type]
  FROM Passengers AS p
	   JOIN Tickets AS t ON p.Id = t.PassengerId
	   JOIN Flights AS f ON f.Id = t.FlightId
	   JOIN Planes AS pl ON pl.Id = f.PlaneId
	   JOIN Luggages AS l ON l.PassengerId = p.Id
	   JOIN LuggageTypes AS lt ON lt.Id = l.LuggageTypeId