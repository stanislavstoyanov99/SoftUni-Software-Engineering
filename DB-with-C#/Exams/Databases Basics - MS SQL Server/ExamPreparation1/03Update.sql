UPDATE Tickets
   SET Price *= 1.13
 WHERE FlightId IN (SELECT f.Id
					  FROM Flights AS f
					 WHERE f.Destination = 'Carlsbad')