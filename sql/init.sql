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
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Orders' AND xtype='U')
BEGIN
    CREATE TABLE Orders (
        Id VARCHAR(50) PRIMARY KEY,
        OrderDate DATETIME DEFAULT GETDATE(),
        CustomerName VARCHAR(100),
        Total FLOAT
    );
END
GO

-- Crear tabla OrderDetails solo si no existe
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='OrderDetails' AND xtype='U')
BEGIN
    CREATE TABLE OrderDetails (
        Id VARCHAR(50) PRIMARY KEY,
        OrderId VARCHAR(50),
        ItemTypeId VARCHAR(50),
        ItemId VARCHAR(50),
        Quantity INT,
        UnitPrice FLOAT,
        SubTotal FLOAT,
        FOREIGN KEY (OrderId) REFERENCES Orders(Id),
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

-- Insertar ejemplo de orden si no existe
IF NOT EXISTS (SELECT 1 FROM Orders)
BEGIN
    INSERT INTO Orders (Id, CustomerName, Total)
    VALUES ('f37d0aec-f9a3-452f-9323-397baef5e763', 'Ricardo Cedeno', 17.0);

    INSERT INTO OrderDetails (Id, OrderId, ItemTypeId, ItemId, Quantity, UnitPrice, SubTotal)
    VALUES 
        (NEWID(), 'f37d0aec-f9a3-452f-9323-397baef5e763', '1', '08d212ed-c3aa-432b-8aed-74c9269abd01', 2, 5.0, 10.0),
        (NEWID(), 'f37d0aec-f9a3-452f-9323-397baef5e763', '2', '8e85d72f-8fc9-43c2-9667-62af9520686b', 2, 2.0, 4.0),
        (NEWID(), 'f37d0aec-f9a3-452f-9323-397baef5e763', '2', '798fc00b-8727-46a0-8dd1-4d0c24784271', 1, 2.5, 2.5);
END
GO
