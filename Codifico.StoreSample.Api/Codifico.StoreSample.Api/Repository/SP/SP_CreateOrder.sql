-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Gustavo Moreno>
-- Create date: <Create Date, 2022-06-30 ,>
-- Description:	<Description, permite ingresar una nueva orden y agregar un producto a dicha orden>
-- Use Example
/* EXEC Sales.CreateOrder @empid = 5, @shipperid = 3, @shipname = 'Ship to 85-B', @shipaddress = '6789 rue de lAbbaye 2', @shipcity = 'Reims'
						  , @orderdate='2022-07-01T04:02:05.714Z', @requireddate = '2022-07-01T04:02:05.714Z'
                        , @shippeddate='2022-07-01T04:02:05.714Z', @freight= 32.40, @shipcountry = 'France'
                        , @productid = 11, @unitprice= 15.00, @qty = 10, @discount = 0.00
*/
-- =============================================
CREATE PROCEDURE Sales.CreateOrder 
	@empid int,
	@shipperid int,
	@shipname nvarchar(40), 
	@shipaddress nvarchar(60),
	@shipcity nvarchar(15),
	@orderdate datetime,
	@requireddate datetime,
	@shippeddate datetime,
	@freight money,
	@shipcountry nvarchar(15),
	@productid int,
	@unitprice money,
	@qty smallint,
	@discount numeric(18,2),
	@custid int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	SET NOCOUNT ON;
	DECLARE @newOrderId int;
	INSERT INTO Sales.Orders(empid, shipperid, shipname, shipaddress, shipcity, orderdate, requireddate, shippeddate, freight, shipcountry,custid)
	VALUES(@empid, @shipperid, @shipname, @shipaddress, @shipcity, @orderdate, @requireddate, @shippeddate, @freight, @shipcountry, @custid);

	SELECT @newOrderId = @@IDENTITY;
	INSERT INTO Sales.OrderDetails(orderid, productid, unitprice, qty, discount)
	VALUES (@newOrderId, @productid, @unitprice, @qty, @discount)

	SELECT orderid
	, empid
	, shipperid
	, shipname
	, shipaddress
	, shipcity
	, orderdate
	, requireddate
	, shippeddate
	, freight
	, shipcountry
	FROM Sales.Orders
	WHERE orderid = @newOrderId

END
GO
