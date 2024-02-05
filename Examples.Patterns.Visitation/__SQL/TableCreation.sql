--	MS-SQL creation script
USE [Bytz.Visitation]
GO

CREATE SCHEMA Customers AUTHORIZATION dbo;
GO

CREATE TABLE Customers.CustomerType
(
	CustomerTypeId	TINYINT				NOT NULL	IDENTITY(1, 1)
													CONSTRAINT PK_Customers_CustomerType
													PRIMARY KEY
,	EnumKey			VARCHAR(40)			NOT NULL	CONSTRAINT UQ_Customers_CustomerType_EnumKey
													UNIQUE
,	[Description]	VARCHAR(100)		NOT NULL
,	IsActive		BIT					NOT NULL
);
GO

CREATE TABLE Customers.Customer
(
	CustomerId		INT					NOT NULL	IDENTITY(1, 1)
													CONSTRAINT PK_Customers_Customer
													PRIMARY KEY
,	CustomerTypeId	TINYINT				NOT NULL	CONSTRAINT FK_Customers_Customer__Customers_CustomerType
													REFERENCES Customers.CustomerType(CustomerTypeId)
,	CustomerName	VARCHAR(100)		NOT NULL
,	CreatedOn		DATETIME			NOT NULL	
);
GO

CREATE NONCLUSTERED INDEX IX_CustomerTypeId ON Customers.Customer(CustomerTypeId);
GO

CREATE SCHEMA Groceries AUTHORIZATION dbo;
GO

CREATE TABLE Groceries.CategoryType
(
	CategoryTypeId	TINYINT				NOT NULL	IDENTITY(1, 1)
													CONSTRAINT PK_Groceries_CategoryType
													PRIMARY KEY 
,	EnumKey			VARCHAR(40)			NOT NULL	CONSTRAINT UQ_Groceries_CategoryType_EnumKey
													UNIQUE
,	[Description]	VARCHAR(100)		NOT NULL
,	IsActive		BIT					NOT NULL
);
GO

CREATE TABLE Groceries.UnitType
(
	UnitTypeId		TINYINT				NOT NULL	IDENTITY(1, 1)
													CONSTRAINT PK_Groceries_UnitType
													PRIMARY KEY 
,	EnumKey			VARCHAR(40)			NOT NULL	CONSTRAINT UQ_Groceries_UnitType_EnumKey
													UNIQUE
,	[Description]	VARCHAR(100)		NOT NULL
,	IsActive		BIT					NOT NULL
);
GO

CREATE TABLE Groceries.GroceryItem
(
	GroceryItemId	INT					NOT NULL	IDENTITY(1, 1)
													CONSTRAINT PK_Groceries_GroceryItem
													PRIMARY KEY
,	CategoryTypeId	TINYINT				NOT NULL	CONSTRAINT FK_Groceries_GroceryItem__Groceries_CategoryType
													REFERENCES Groceries.CategoryType(CategoryTypeId)
,	UnitTypeId		TINYINT				NOT NULL	CONSTRAINT FK_Groceries_GroceryItem__Groceries_UnitType
													REFERENCES Groceries.UnitType(UnitTypeId)
,	Price			MONEY				
);
GO

CREATE NONCLUSTERED	INDEX IX_Groceries_GroceryItem_CategoryTypeId ON Groceries.GrocseryItem(CategoryTypeId);
CREATE NONCLUSTERED INDEX IX_Groceries_GroceryItem_UnitTypeId ON Groceries.GroceryItem(UnitTypeId);
GO

CREATE SCHEMA Orders AUTHORIZATION dbo;
GO

CREATE TABLE Orders.[Order]
(
	OrderId			INT					NOT NULL	IDENTITY(1, 1)
													CONSTRAINT PK_Orders_Order
													PRIMARY KEY
,	CustomerId		INT					NOT NULL	CONSTRAINT FK_Orders_Order__Customers_Customer
													REFERENCES Customers.Customer(CustomerId)
,	SubTotal		MONEY				NOT NULL
,	Discount		MONEY				NOT NULL
,	TotalTax		MONEY				NOT NULL
,	Total			MONEY				NOT NULL
,	OrderedOn		DATETIME			NOT NULL
);

CREATE NONCLUSTERED INDEX IX_Orders_Order_CustomerId ON Orders.[Order](CustomerId);
GO

CREATE TABLE Orders.OrderDetail
(
	OrderDetailId	INT					NOT NULL	IDENTITY(1, 1)
													CONSTRAINT PK_Orders_OrderDetail
													PRIMARY KEY
,	OrderId			INT					NOT NULL	CONSTRAINT FK_Orders_OrderDetail__Orders_Order
													REFERENCES Orders.[Order](OrderId)
,	GroceryItemId	INT					NOT NULL	CONSTRAINT FK_Orders_OrderDetail__Groceries_GroceryItem
													REFERENCES Groceries.GroceryItem(GroceryItemId)
,	Quantity		INT					NOT NULL
,,	Price			MONEY				NOT NULL
,,	Total			MONEY				NOT NULL
,	OrderedOn		DATETIME			NOT NULL
);
GO

CREATE NONCLUSTERED INDEX IX_Orders_OrderDetail_OrderId ON Orders.OrderDetail(OrderId);
CREATE NONCLUSTERED INDEX IX_Orders_OrderDetail_GroceryItemId ON Orders.OrderDetail(GroceryItemId);
GO