INSERT INTO Customers.CustomerType
(
	EnumKey
,	[Description]
,	IsActive
)
VALUES
	('Individual', 'Individual', 1)
,	('Business', 'Business', 1)
,	('Charity', 'Charity', 1)
GO


INSERT INTO Groceries.UnitType
( 
	EnumKey, 
	[Description], 
	IsActive
)
VALUES
	('Each', 'Each', 1)
,	('Weight', 'Weight', 1);
GO

INSERT INTO Groceries.CategoryType
(
	EnumKey
,	[Description]
, 	IsActive
)
VALUES 
	('Produce', 'Produce', 1)
,	('Meat', 'Meat', 1)
,	('Frozen', 'Frozen', 1)
,	('Dairy', 'Dairy', 1)
,	('Deli', 'Deli', 1)
,	('Grocery', 'Grocery', 1);
GO