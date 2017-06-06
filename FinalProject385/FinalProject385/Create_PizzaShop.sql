USE master
GO


IF DB_ID('PizzaShop') IS NOT NULL
DROP DATABASE PizzaShop
GO

CREATE DATABASE PizzaShop
GO 

USE PizzaShop
GO


--------------------------------------------------------------------------CREATE TABLES

CREATE TABLE [dbo].[Employees] (
    [EmployeeID] INT          IDENTITY (1, 1) NOT NULL,
    [FName]      VARCHAR (50) NOT NULL,
    [LName]      VARCHAR (50) NOT NULL,
    [Password]   VARCHAR (10) NOT NULL,
    [isAdmin]    BIT          NOT NULL,
    [Wage]       FLOAT (53)   NOT NULL,
    [UserName]   VARCHAR (10) NOT NULL
);

CREATE TABLE [dbo].[Orders] (
    [OrderID]          INT          IDENTITY (1, 1) NOT NULL,
    [EmployeeID]       INT          NOT NULL,
    [OrderTotal]       FLOAT (53)   NOT NULL,
    [CreditCardNumber] VARCHAR (50) NULL,
    [CustomerFName]    VARCHAR (50) NOT NULL,
    [CustomerLName]    VARCHAR (50) NOT NULL,
    [isPaid]           BIT          NOT NULL,
    [isDeleted]        BIT          NOT NULL
);

CREATE TABLE [dbo].[Pizza] (
    [PizzaID]   INT        IDENTITY (1, 1) NOT NULL,
    [OrderID]   INT        NOT NULL,
    [SizeID]    INT        NOT NULL,
    [isDeleted] BIT        NOT NULL,
    [Price]     FLOAT (53) NOT NULL
);

CREATE TABLE [dbo].[Sizes] (
    [SizeID]     INT          IDENTITY (1, 1) NOT NULL,
    [Size]       VARCHAR (10) NOT NULL,
    [PizzaPrice] FLOAT (53)   NOT NULL
);

CREATE TABLE [dbo].[Toppings] (
    [ToppingID]    INT          IDENTITY (1, 1) NOT NULL,
    [ToppingName]  VARCHAR (30) NOT NULL,
    [ToppingPrice] FLOAT (53)   NOT NULL
);


CREATE TABLE [dbo].[ToppingsForPizza] (
    [ToppingsForPizzaID] INT IDENTITY (1, 1) NOT NULL,
    [PizzaID]            INT NOT NULL,
    [ToppingID]          INT NOT NULL,
    [isDeleted]          BIT NOT NULL
);



------------------------------------------------------------------------------------INSERT INTO TABLES
INSERT INTO Sizes(Size, PizzaPrice)
VALUES ('Small',6.00), ('Medium',7.25), ('Large',8.50)

INSERT INTO Toppings(ToppingName, ToppingPrice)
VALUES ('Pepperoni', 1.50),
('Sausage', 1.40),
('Bacon', 1.30),
('Ham', 1.75),
('Pineapple', 1.25),
('Green Peppers', 1.40),
('Onions', 1.45),
('Black Olives', 1.25),
('Green Olives', 1.35),
('Anchovies', 1.75),
('Spinach', 1.50),
('Mushrooms', 1.45),
('Tomato', 1.65),
('Banana Peppers', 1.65),
('Jalapenos', 1.40)

INSERT INTO Employees(FName, LName,UserName, [Password], isAdmin, Wage)
VALUES ('Hannah', 'Thompson','PizzaAdmin', 'PizzaLove', 1, 10.00),
('Steve', 'Mitchel','b', 'SMitch', 0, 8.50),
('Johnny', 'Stamos','c', 'Stamos123', 0, 9.75)

-----------------------------------------------------------------------------------CREATE PROCEDURES
GO

/****** Object: SqlProcedure [dbo].[spAddOrder] Script Date: 5/6/2017 1:02:18 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE spAddOrder
@EmployeeID				int,
@OrderTotal				float,
@CreditCardNumber		varchar(50) = '',
@CustomerFName			varchar(50),
@CustomerLName			varchar(50),
@isPaid					bit = false,
@isDeleted				bit = false

AS
	SET NOCOUNT ON
INSERT INTO Orders (EmployeeID, OrderTotal, CreditCardNumber, CustomerFName, CustomerLName, isPaid, isDeleted)
VALUES (@EmployeeID, @OrderTotal, @CreditCardNumber, @CustomerFName, @CustomerLName, @isPaid, @isDeleted)
SELECT [OrderID] = @@IDENTITY

GO

/****** Object: SqlProcedure [dbo].[spAddPizza] Script Date: 5/6/2017 1:02:43 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE spAddPizza
	@OrderID int,
	@SizeID int,
	@isDeleted bit = 0,
	@Price float
AS
	SET NOCOUNT ON
		INSERT INTO Pizza(OrderID, SizeID, isDeleted, Price)
		Values(@OrderID, @SizeID, @isDeleted, @Price)
SELECT [PizzaID] = @@IDENTITY

GO

/****** Object: SqlProcedure [dbo].[spAddTopping] Script Date: 5/6/2017 1:02:52 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE spAddTopping
	@ToppingID		int,
	@PizzaID		int,
	@isDeleted		bit=0
AS
	SET NOCOUNT ON
	INSERT INTO ToppingsForPizza (PizzaID,  ToppingID, isDeleted)
	VALUES (@PizzaID, @ToppingID, @isDeleted)

GO

/****** Object: SqlProcedure [dbo].[spAddUpdateDeleteEmployees] Script Date: 5/6/2017 1:03:03 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[spAddUpdateDeleteEmployees]
		@EmployeeID			int,
		@FName				varchar(50),
		@LName				varchar(50),
		@Password			varchar(50),
		@isAdmin			bit = 0,
		@Wage				float,
		@UserName			varchar(50),
		@Delete				bit = 0

AS

	SET NOCOUNT ON


IF	(@EmployeeID = 0)	BEGIN	

	--no duplicate usernames
	IF NOT EXISTS(	SELECT NULL	FROM Employees WHERE [UserName] = @UserName) BEGIN

		INSERT INTO Employees(FName, LName, [Password], isAdmin, Wage, UserName)
		VALUES (@FName, @LName, @Password, @isAdmin, @Wage, @UserName)
					
		SELECT [success] = 1
	END ELSE BEGIN
	SELECT [success] = -1
END
END ELSE IF (@Delete = 1)		BEGIN
	
	--make sure the employee has no orders with their name on it
	IF NOT EXISTS(	SELECT NULL
					FROM Orders
					WHERE [EmployeeID] = @EmployeeID) BEGIN

						DELETE FROM Employees WHERE EmployeeID = @EmployeeID
						SELECT [EmployeeID] = 1
					END
	ELSE	BEGIN
		SELECT [EmployeeID] = -1
	END

END ELSE	BEGIN
	IF NOT EXISTS(SELECT NULL FROM Orders WHERE EmployeeID = @EmployeeID) BEGIN
		UPDATE Employees SET [FName] = @Fname, [LName] = @LName, [Password] = @Password, [isAdmin] = @isAdmin, [Wage] = @Wage
		WHERE UserName = @UserName
		SELECT [EmployeeID] = @EmployeeID
	END	ELSE	BEGIN
		SELECT [EmployeeID] = -1
	END
END

GO

/****** Object: SqlProcedure [dbo].[spAllOrders] Script Date: 5/6/2017 1:03:18 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE spAllOrders
AS
	SET NOCOUNT ON
SELECT *
FROM Orders

GO

/****** Object: SqlProcedure [dbo].[spDeleteOrder] Script Date: 5/6/2017 1:03:28 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE spDeleteOrder
@OrderID		int

AS
	SET NOCOUNT ON

IF NOT EXISTS(	SELECT NULL
				FROM Pizza
				WHERE OrderID = @OrderID) BEGIN
			DELETE FROM Orders
			WHERE OrderID = @OrderID
			SELECT [success] = 1
END ELSE BEGIN
SELECT [success] = -1
END

GO

/****** Object: SqlProcedure [dbo].[spDeletePizza] Script Date: 5/6/2017 1:03:37 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE spDeletePizza
	@PizzaID		int
AS
	SET NOCOUNT ON

	DELETE FROM ToppingsForPizza WHERE PizzaID = @PizzaID
	DELETE FROM Pizza WHERE PizzaID = @PizzaID
	SELECT [success] = 1

GO

/****** Object: SqlProcedure [dbo].[spEmployeeLogin] Script Date: 5/6/2017 1:03:45 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE spEmployeeLogin
	@UserName	varchar(50),
	@Password	varchar(50)
AS
	SET NOCOUNT ON
		SELECT EmployeeID, isAdmin
		FROM Employees
		WHERE UserName = @UserName AND [Password] = @Password

GO

/****** Object: SqlProcedure [dbo].[spGetActiveOrPastOrders] Script Date: 5/6/2017 1:03:53 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE spGetActiveOrPastOrders
	@isDeleted bit,
	@isPaid		bit
AS
	SET NOCOUNT ON
	SELECT *
	FROM Orders
	WHERE isDeleted = @isDeleted AND isPaid = @isPaid
RETURN 0

GO

/****** Object: SqlProcedure [dbo].[spGetEmployeeWage] Script Date: 5/6/2017 1:04:01 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE spGetEmployeeWage
AS
	SET NOCOUNT ON
	SELECT *
	FROM Employees
RETURN 0

GO

/****** Object: SqlProcedure [dbo].[spGetIncome] Script Date: 5/6/2017 1:04:11 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE spGetIncome
	AS
SET NOCOUNT ON

SELECT SUM(OrderTotal) AS Income
FROM Orders

GO

/****** Object: SqlProcedure [dbo].[spGetOrderTotal] Script Date: 5/6/2017 1:04:19 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE spGetOrderTotal
	@OrderID	int
AS
	SET NOCOUNT ON
	SELECT SUM(Price)
	FROM Pizza
	WHERE Pizza.OrderID = @OrderID

GO

/****** Object: SqlProcedure [dbo].[spGetPizzas] Script Date: 5/6/2017 1:04:29 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE spGetPizzas
@OrderID		int
AS
	SET NOCOUNT ON

SELECT PizzaID, Sizes.Size, Pizza.Price
FROM Pizza
	JOIN Sizes
		ON Pizza.SizeID = Sizes.SizeID
	JOIN Orders
		ON Pizza.OrderID = Orders.OrderID
WHERE Pizza.OrderID = @OrderID

GO

/****** Object: SqlProcedure [dbo].[spGetSizeCost] Script Date: 5/6/2017 1:04:37 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE spGetSizeCost
@SizeID		int

AS 
	SET NOCOUNT ON

SELECT PizzaPrice 
FROM Sizes
WHERE SizeID = @SizeID

GO

/****** Object: SqlProcedure [dbo].[spGetToppingPrice] Script Date: 5/6/2017 1:04:45 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE spGetToppingPrice
@ToppingName		varchar(50)

AS
	SET NOCOUNT ON
IF EXISTS (SELECT NULL FROM Toppings WHERE ToppingName = @ToppingName) BEGIN

	SELECT ToppingPrice
	FROM Toppings
	WHERE ToppingName = @ToppingName

END

GO

/****** Object: SqlProcedure [dbo].[spGetToppings] Script Date: 5/6/2017 1:04:54 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE spGetToppings
	@PizzaID		int
AS
	SET NOCOUNT ON
SELECT ToppingName 
FROM Toppings
	JOIN ToppingsForPizza
		ON Toppings.ToppingID = ToppingsForPizza.ToppingID
WHERE ToppingsForPizza.PizzaID = @PizzaID

GO

/****** Object: SqlProcedure [dbo].[spOrderCancelled] Script Date: 5/6/2017 1:05:03 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE spOrderCancelled
	@OrderID	int,
	@isDeleted		bit
AS
	SET NOCOUNT ON
UPDATE Orders SET isDeleted = @isDeleted
WHERE OrderID = @OrderID

GO

/****** Object: SqlProcedure [dbo].[spOrderPaid] Script Date: 5/6/2017 1:05:12 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE spOrderPaid
	@OrderID	int,
	@isPaid		bit
AS
	SET NOCOUNT ON
UPDATE Orders SET isPaid = @isPaid
WHERE OrderID = @OrderID

GO

/****** Object: SqlProcedure [dbo].[spRefundOrder] Script Date: 5/6/2017 1:05:32 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE spRefundOrder
	@OrderID int
AS
	SET NOCOUNT ON

IF EXISTS(SELECT NULL FROM Orders WHERE OrderID = @OrderID AND isPaid = 0)--If the order has not been paid
	BEGIN
		SELECT [success] = -1
	END

ELSE
	BEGIN
		UPDATE Orders
		SET isPaid = 0,
			isDeleted = 1
		WHERE OrderID = @OrderID
		SELECT [success] = 1
	END

RETURN 0

GO

/****** Object: SqlProcedure [dbo].[spUpdateCC] Script Date: 5/6/2017 1:05:42 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE spUpdateCC
@OrderID				int,
@CreditCardNumber		varchar(50) = 'CASH'
AS
	SET NOCOUNT ON
UPDATE Orders SET CreditCardNumber = @CreditCardNumber
WHERE OrderID =@OrderID

--checks if there are actually pizzas on the order
IF EXISTS(	SELECT NULL
			FROM Pizza
			WHERE OrderID = @OrderID) BEGIN
SELECT [success] = 1
END ELSE BEGIN
SELECT [success] = -1
END

GO

/****** Object: SqlProcedure [dbo].[spUpdateOrderTotal] Script Date: 5/6/2017 1:05:52 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE spUpdateOrderTotal
@OrderID		int,
@PizzaPrice		float
AS
	SET NOCOUNT ON
UPDATE Orders SET OrderTotal = OrderTotal + @PizzaPrice
WHERE OrderID = @OrderID

GO

/****** Object: SqlProcedure [dbo].[spUpdatePizzaPrice] Script Date: 5/6/2017 1:06:03 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE spUpdatePizzaPrice
	@PizzaID		int,
	@Price			float
AS
	UPDATE Pizza SET Price = @Price
	WHERE PizzaID = @PizzaID
