USE [StoreSample]
GO
/****** Object:  StoredProcedure [Sales].[CreateOrder]    Script Date: 1/07/2022 7:34:17 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Gustavo Moreno>
-- Create date: <Create Date, 2022-06-30 ,>
-- Description:	<Description, permite ingresar una nueva orden y agregar un producto a dicha orden>
-- Use Example
-- EXEC Sales.GetNextPredicatedOrder
-- =============================================
CREATE PROCEDURE [Sales].[GetNextPredicatedOrder]
AS
BEGIN
	DECLARE @NextPredicatedOrder datetime
	DECLARE @OldOrderDate datetime = NULL;
	DECLARE @CurrentOrderDate datetime = NULL;
	DECLARE @PromDays int = 0;
	DECLARE @Count int = 0;
	DECLARE @cusid int = 0;
	IF OBJECT_ID('tempdb..#TemOrdersCustomers') IS NOT NULL DROP TABLE #TemRequestFiles;
	CREATE TABLE #TemOrdersCustomers(
		CustomerId int,
		CustomerName nvarchar(20),
		LastOrderDate datetime,
		NextPredicatedOrder datetime NULL
	);

	INSERT INTO #TemOrdersCustomers
	SELECT C.custid CustomerId, C.companyname CustomerName, MAX(O.orderdate) LastOrderDate, NULL
	FROM Sales.Orders O
	INNER JOIN Sales.Customers C ON C.custid = O.custid
	GROUP BY C.custid, C.companyname;

	DECLARE TemOrdersCustomers_Cursor CURSOR FOR
	SELECT CustomerId FROM #TemOrdersCustomers;
	OPEN TemOrdersCustomers_Cursor
	FETCH NEXT FROM TemOrdersCustomers_Cursor INTO @cusid
	WHILE @@FETCH_STATUS = 0
	BEGIN
		DECLARE Orders_Cursor CURSOR FOR
		SELECT orderdate FROM Sales.Orders
		WHERE custid = @cusid
		ORDER BY orderdate ASC;
		OPEN Orders_Cursor
		FETCH NEXT FROM Orders_Cursor INTO @CurrentOrderDate
		WHILE @@FETCH_STATUS = 0
		BEGIN
			IF(@OldOrderDate IS NULL)
			BEGIN
				SET @OldOrderDate = @CurrentOrderDate
			END
			ELSE
			BEGIN
				SET @PromDays = (@PromDays + DATEDIFF(DAY, @OldOrderDate, @CurrentOrderDate))
				SET @Count = @Count + 1
				SET @OldOrderDate = @CurrentOrderDate
			END
			FETCH NEXT FROM Orders_Cursor INTO @CurrentOrderDate
		END
		CLOSE Orders_Cursor
		DEALLOCATE Orders_Cursor

		SET @NextPredicatedOrder = DATEADD(DAY, (@PromDays/@Count), @OldOrderDate);

		UPDATE #TemOrdersCustomers SET NextPredicatedOrder = @NextPredicatedOrder WHERE CustomerId = @cusid;

		FETCH NEXT FROM TemOrdersCustomers_Cursor INTO @cusid
	END
	CLOSE TemOrdersCustomers_Cursor
	DEALLOCATE TemOrdersCustomers_Cursor

	SELECT * FROM #TemOrdersCustomers;

END
