-- Create database
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'GoodHamburger')
BEGIN
    CREATE DATABASE GoodHamburger;
END
GO

USE GoodHamburger;
GO

-----------------------------------------------------------
-- TABLES
-----------------------------------------------------------


IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='ItemTypes' AND xtype='U')
BEGIN
    CREATE TABLE ItemTypes (
        Id VARCHAR(50) PRIMARY KEY,
        ItemName VARCHAR(100)
    );
END
GO


IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Sandwiches' AND xtype='U')
BEGIN
    CREATE TABLE Sandwiches (
        Id VARCHAR(50) PRIMARY KEY,
        SandwichName VARCHAR(50),
        Price FLOAT
    );
END
GO


IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Extras' AND xtype='U')
BEGIN
    CREATE TABLE Extras (
        Id VARCHAR(50) PRIMARY KEY,
        ExtraName VARCHAR(50),
        Price FLOAT
    );
END
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Orders' AND xtype='U')
BEGIN
    CREATE TABLE Orders (
        Id VARCHAR(50) PRIMARY KEY,
        Total FLOAT
    );
END
GO


IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Purchases' AND xtype='U')
BEGIN
CREATE TABLE Purchases (
    Id VARCHAR(50) PRIMARY KEY,
    OrderId VARCHAR(50),
    ItemTypeId VARCHAR(50),
    ProductId VARCHAR(50),
    Quantity INT,
    UnitPrice FLOAT,
    SubTotal FLOAT,
    FOREIGN KEY (OrderId) REFERENCES Orders(Id) ON DELETE CASCADE,
    FOREIGN KEY (ItemTypeId) REFERENCES ItemTypes(Id)
);
END
GO

IF NOT EXISTS (SELECT 1 FROM ItemTypes)
BEGIN
    INSERT INTO ItemTypes (Id, ItemName) VALUES
    ('1', 'Sandwich'),
    ('2', 'Extra');
END
GO


IF NOT EXISTS (SELECT 1 FROM Sandwiches)
BEGIN
    INSERT INTO Sandwiches (Id, SandwichName, Price) VALUES
    ('08d212ed-c3aa-432b-8aed-74c9269abd01', 'Burger', 5.0),
    ('803f106f-38cf-4c2e-8670-61b4f91af064', 'Egg', 4.5),
    ('b4a7c952-21f1-47bc-b403-64c88aae6d61', 'Bacon', 7.0);
END
GO


IF NOT EXISTS (SELECT 1 FROM Extras)
BEGIN
    INSERT INTO Extras (Id, ExtraName, Price) VALUES
    ('8e85d72f-8fc9-43c2-9667-62af9520686b', 'Fries', 2.0),
    ('798fc00b-8727-46a0-8dd1-4d0c24784271', 'Soft drink', 2.5);
END
GO


IF NOT EXISTS (SELECT 1 FROM Orders)
BEGIN
    INSERT INTO Orders (Id, Total) VALUES
    ('ff19e4e6-236e-4dd9-8b7e-3b113b8adef2', 5)
END
GO


IF NOT EXISTS (SELECT 1 FROM Purchases)
BEGIN
    INSERT INTO Purchases (Id, OrderId, ItemTypeId, ProductId, Quantity, UnitPrice, SubTotal) VALUES

    ('a75592dc-582d-41df-9319-292fec63cdf4', 'ff19e4e6-236e-4dd9-8b7e-3b113b8adef2', '2', '798fc00b-8727-46a0-8dd1-4d0c24784271', 1, 2.5, 2.5),
    ('b7f40023-c73c-4fc2-ba01-749c32695497', 'ff19e4e6-236e-4dd9-8b7e-3b113b8adef2', '1', '08d212ed-c3aa-432b-8aed-74c9269abd01', 1, 5, 5)
END
GO
