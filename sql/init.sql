-- Crear base de datos solo si no existe
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'GoodHamburger')
BEGIN
    CREATE DATABASE GoodHamburger;
END
GO

USE GoodHamburger;
GO

-- Crear tabla ItemTypes solo si no existe
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='ItemTypes' AND xtype='U')
BEGIN
    CREATE TABLE ItemTypes (
        Id VARCHAR(50) PRIMARY KEY,
        ItemName VARCHAR(100)
    );
END
GO

-- Crear tabla Sandwiches solo si no existe
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Sandwiches' AND xtype='U')
BEGIN
    CREATE TABLE Sandwiches (
        Id VARCHAR(50) PRIMARY KEY,
        SandwichName VARCHAR(50),
        Price FLOAT
    );
END
GO

-- Crear tabla Extras solo si no existe
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Extras' AND xtype='U')
BEGIN
    CREATE TABLE Extras (
        Id VARCHAR(50) PRIMARY KEY,
        ExtraName VARCHAR(50),
        Price FLOAT
    );
END
GO

-- Crear tabla Orders solo si no existe

-- Crear tabla OrderDetails solo si no existe
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Orders' AND xtype='U')
BEGIN
    CREATE TABLE Orders (
        Id VARCHAR(50) PRIMARY KEY,
        ItemTypeId VARCHAR(50),
        ProductId VARCHAR(50),
        Quantity INT,
        UnitPrice FLOAT,
        SubTotal FLOAT,
        FOREIGN KEY (ItemTypeId) REFERENCES ItemTypes(Id)
    );
END
GO

-- Insertar registros en ItemTypes solo si no existen
IF NOT EXISTS (SELECT 1 FROM ItemTypes)
BEGIN
    INSERT INTO ItemTypes (Id, ItemName) VALUES
    ('1', 'Sandwich'),
    ('2', 'Extra');
END
GO

-- Insertar registros en Sandwiches solo si no existen
IF NOT EXISTS (SELECT 1 FROM Sandwiches)
BEGIN
    INSERT INTO Sandwiches (Id, SandwichName, Price) VALUES
    ('08d212ed-c3aa-432b-8aed-74c9269abd01', 'Burger', 5.0),
    ('803f106f-38cf-4c2e-8670-61b4f91af064', 'Egg', 4.5),
    ('b4a7c952-21f1-47bc-b403-64c88aae6d61', 'Bacon', 7.0);
END
GO

-- Insertar registros en Extras solo si no existen
IF NOT EXISTS (SELECT 1 FROM Extras)
BEGIN
    INSERT INTO Extras (Id, ExtraName, Price) VALUES
    ('8e85d72f-8fc9-43c2-9667-62af9520686b', 'Fries', 2.0),
    ('798fc00b-8727-46a0-8dd1-4d0c24784271', 'Soft drink', 2.5);
END
GO

IF NOT EXISTS (SELECT 1 FROM Orders)
BEGIN
INSERT INTO Orders (Id, ItemTypeId, ProductId, Quantity, UnitPrice, SubTotal) VALUES 
    ('7bb5d6bc-ce81-4bba-a5c3-1e10345753bc', '1', '08d212ed-c3aa-432b-8aed-74c9269abd01', 1, 5.0, 5.0),
    ('4775e09a-0aa1-44c5-88ed-2e401bd7a82e', '2', '8e85d72f-8fc9-43c2-9667-62af9520686b', 1, 2.0,2.0),
    ('cbcaceee-bfc2-4c25-9b3c-01fe4cd744e9', '2', '798fc00b-8727-46a0-8dd1-4d0c24784271', 1, 2.5, 2.5);
END
GO
