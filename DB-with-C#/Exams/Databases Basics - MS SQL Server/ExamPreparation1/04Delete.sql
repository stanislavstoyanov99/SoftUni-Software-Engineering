DELETE 
  FROM Tickets
 WHERE FlightId IN (SELECT f.Id
					  FROM Flights AS f
					 WHERE f.Destination = 'Ayn Halagim')

 DELETE 
  FROM Flights
 WHERE Destination = 'Ayn Halagim'