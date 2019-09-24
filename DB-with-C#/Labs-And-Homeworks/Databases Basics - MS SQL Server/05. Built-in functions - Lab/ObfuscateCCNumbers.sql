CREATE VIEW vw_PublicPaymentInfo AS
SELECT Id,
       FirstName,
       LastName,
	   LEFT(PaymentNumber, 6) + REPLICATE('*', 6) AS PaymentNumber
  FROM Payments

SELECT * FROM vw_PublicPaymentInfo
