-- Crear base de datos solo si no existe
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'GoodHamburger')
BEGIN
    CREATE DATABASE GoodHamburger;
END
GO

USE GoodHamburger;
GO

-----------------------------------------------------------
-- TABLAS MAESTRAS
-----------------------------------------------------------

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

-----------------------------------------------------------
-- TABLAS DE ORDENES Y DETALLES
-----------------------------------------------------------

-- Crear tabla Orders solo si no existe
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Orders' AND xtype='U')
BEGIN
    CREATE TABLE Orders (
        Id VARCHAR(50) PRIMARY KEY,
        Total FLOAT
    );
END
GO

-- Crear tabla Purchases solo si no existe
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

-----------------------------------------------------------
-- DATOS INICIALES
-----------------------------------------------------------

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

-- Insertar registros en Orders solo si no existen
IF NOT EXISTS (SELECT 1 FROM Orders)
BEGIN
    INSERT INTO Orders (Id, Total) VALUES
    ('11111111-aaaa-4444-bbbb-000000000001', 7.0),  -- Pedido con un sandwich y un extra
    ('22222222-bbbb-5555-cccc-000000000002', 9.5); -- Pedido con otro sandwich y 2 extras
END
GO

-- Insertar registros en Purchases solo si no existen
IF NOT EXISTS (SELECT 1 FROM Purchases)
BEGIN
    INSERT INTO Purchases (Id, OrderId, ItemTypeId, ProductId, Quantity, UnitPrice, SubTotal) VALUES
    -- Orden 1: Burger + Fries
    ('a1a1a1a1-aaaa-1111-bbbb-000000000001', '11111111-aaaa-4444-bbbb-000000000001', '1', '08d212ed-c3aa-432b-8aed-74c9269abd01', 1, 5.0, 5.0),
    ('a1a1a1a1-aaaa-1111-bbbb-000000000002', '11111111-aaaa-4444-bbbb-000000000001', '2', '8e85d72f-8fc9-43c2-9667-62af9520686b', 1, 2.0, 2.0),

    -- Orden 2: Bacon + Fries + Soft drink
    ('b2b2b2b2-bbbb-2222-cccc-000000000001', '22222222-bbbb-5555-cccc-000000000002', '1', 'b4a7c952-21f1-47bc-b403-64c88aae6d61', 1, 7.0, 7.0),
    ('b2b2b2b2-bbbb-2222-cccc-000000000002', '22222222-bbbb-5555-cccc-000000000002', '2', '8e85d72f-8fc9-43c2-9667-62af9520686b', 1, 2.0, 2.0),
    ('b2b2b2b2-bbbb-2222-cccc-000000000003', '22222222-bbbb-5555-cccc-000000000002', '2', '798fc00b-8727-46a0-8dd1-4d0c24784271', 1, 2.5, 2.5);
END
GO
