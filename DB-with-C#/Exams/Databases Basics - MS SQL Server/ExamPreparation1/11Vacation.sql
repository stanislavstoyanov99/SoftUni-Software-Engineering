CREATE FUNCTION udf_CalculateTickets(@origin NVARCHAR(50), @destination NVARCHAR(50), @peopleCount INT)
RETURNS NVARCHAR(50)
AS
BEGIN
     DECLARE @resultMessage NVARCHAR(50);

     DECLARE @currentOriginId INT=
     (
         SELECT f.Id
         FROM Flights AS f
         WHERE f.Origin = @origin
     );

     DECLARE @currentDestinationId INT=
     (
         SELECT f.Id
         FROM Flights AS f
         WHERE f.Destination = @destination
     );

     IF(@peopleCount <= 0)
         BEGIN
              SET @resultMessage = 'Invalid people count!';
              RETURN @resultMessage;
         END;

     IF((@currentOriginId IS NULL) OR (@currentDestinationId IS NULL))
         BEGIN
              SET @resultMessage = 'Invalid flight!';
              RETURN @resultMessage;
         END;

     DECLARE @totalPrice DECIMAL(15, 2) =
         (
             SELECT t.Price
             FROM Tickets AS t
                  JOIN Flights AS f ON f.Id = t.FlightId
             WHERE f.Origin = @origin
                   AND f.Destination = @destination
         ) * @peopleCount;

     SET @resultMessage = CONCAT('Total price ', @totalPrice);

     RETURN @resultMessage;
END;
GO

SELECT dbo.udf_CalculateTickets('Kolyshley', 'Rancabolang', 33)
SELECT dbo.udf_CalculateTickets('Kolyshley', 'Rancabolang', -1)
SELECT dbo.udf_CalculateTickets('Invalid', 'Rancabolang', 33)
SELECT dbo.udf_CalculateTickets('Rancabolang', 'Invalid', 33)