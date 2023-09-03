--creating database for the application
CREATE DATABASE [SportsZoneDB]

--Dropping a database
DROP DATABASE [SportsZoneDB]

--activating the database
USE [SportsZoneDB]

--creating tables

--creating the customer table
CREATE TABLE [Customer] (
	[Email] VARCHAR(255) PRIMARY KEY NOT NULL,
	[FirstName] VARCHAR(255) NOT NULL,
	[LastName] VARCHAR(255) NOT NULL,
	[ContactNumber] VARCHAR(255) NOT NULL,
	[Address] VARCHAR(255) NULL,
	[City] VARCHAR(255) NULL,
	[Country] VARCHAR(255) NULL,
	[ZipCode] VARCHAR(255) NULL,
	[ProfilePhoto] VARCHAR(MAX) NULL,
	[CreatedBy] VARCHAR(255) NOT NULL,
	[CreatedDate] DATETIME DEFAULT GETDATE() NOT NULL,
	[UpdatedBy] VARCHAR(255) NOT NULL,
	[UpdatedDate] DATETIME DEFAULT GETDATE() NOT NULL
);	

--Creating the Security table with a foreign key reference to the Customer (weak entity)
CREATE TABLE [Security] (
	[Email] VARCHAR(255) PRIMARY KEY NOT NULL,
	[Password] VARBINARY(MAX) NOT NULL,
	[SecurityQuestion] VARCHAR(MAX) NOT NULL,
	[Answer] VARBINARY(MAX) NOT NULL,
	[CreatedBy] VARCHAR(255) NOT NULL,
	[CreatedDate] DATETIME DEFAULT GETDATE() NOT NULL,
	[UpdatedBy] VARCHAR(255) NOT NULL,
	[UpdatedDate] DATETIME DEFAULT GETDATE() NOT NULL
	FOREIGN KEY (Email) REFERENCES [Customer](Email)
);	

--Creating the Categroy table  
CREATE TABLE [Category] (
	[CategoryID] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[CategoryName] VARCHAR(MAX) NOT NULL,
	[Description] VARCHAR(MAX) NULL,
	[CreatedBy] VARCHAR(255) NOT NULL,
	[CreatedDate] DATETIME DEFAULT GETDATE() NOT NULL,
	[UpdatedBy] VARCHAR(255) NOT NULL,
	[UpdatedDate] DATETIME DEFAULT GETDATE() NOT NULL
);	

--creating the Product table with reference of Category table
CREATE TABLE [Product] (
	[ProductID] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[ProductName] VARCHAR(MAX) NOT NULL,
	[ProductImage] VARCHAR(MAX) NOT NULL,
	[StockCount] INT NOT NULL,
	[Price] DECIMAL(10,2) NOT NULL,
	[CategoryID] INT NOT NULL,
	[CreatedBy] VARCHAR(255) NOT NULL,
	[CreatedDate] DATETIME DEFAULT GETDATE() NOT NULL,
	[UpdatedBy] VARCHAR(255) NOT NULL,
	[UpdatedDate] DATETIME DEFAULT GETDATE() NOT NULL,
	FOREIGN KEY ([CategoryID]) REFERENCES [Category]([CategoryID])
);

--Creating the Cart table with reference to Customer table
CREATE TABLE [Cart] (
	[CartID] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[BelongsTo] VARCHAR(255) NOT NULL,
	[IsEnabled] BIT NOT NULL DEFAULT 1,
	[CreatedBy] VARCHAR(255) NOT NULL,
	[CreatedDate] DATETIME DEFAULT GETDATE() NOT NULL,
	[UpdatedBy] VARCHAR(255) NOT NULL,
	[UpdatedDate] DATETIME DEFAULT GETDATE() NOT NULL,
	FOREIGN KEY ([BelongsTo]) REFERENCES [Customer]([Email])
);

--Creating the CartItem table with reference to Cart table and Product table
CREATE TABLE [CartItem] (
	[CartItemID] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[CartID] INT NOT NULL,
	[ProductID] INT NOT NULL,
	[Quantity] INT NOT NULL,
	[TotalPrice] DECIMAL(10,2) NOT NULL,
	[CreatedBy] VARCHAR(255) NOT NULL,
	[CreatedDate] DATETIME DEFAULT GETDATE() NOT NULL,
	[UpdatedBy] VARCHAR(255) NOT NULL,
	[UpdatedDate] DATETIME DEFAULT GETDATE() NOT NULL,
	FOREIGN KEY ([CartID]) REFERENCES [Cart]([CartID]),
	FOREIGN KEY () REFERENCES [Product]([ProductID])
);

--creating the Shipping table with reference to Customer table
CREATE TABLE [Shipping] (
	[ShippingID] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Address] VARCHAR(255) NOT NULL,
	[City] VARCHAR(255) NOT NULL,
	[Country] VARCHAR(255) NOT NULL,
	[ZipCode] VARCHAR(255) NOT NULL,
	[Landmark] VARCHAR(255) NOT NULL,
	[BelongsTo] VARCHAR(255) NOT NULL,
	[CreatedBy] VARCHAR(255) NOT NULL,
	[CreatedDate] DATETIME DEFAULT GETDATE() NOT NULL,
	[UpdatedBy] VARCHAR(255) NOT NULL,
	[UpdatedDate] DATETIME DEFAULT GETDATE() NOT NULL,
	FOREIGN KEY ([BelongsTo]) REFERENCES [Customer]([Email])
);	

--Creating the Payment table
CREATE TABLE [Payment] (
	[PaymentID] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[PaymentType] VARCHAR(255) NOT NULL,
	[CreatedBy] VARCHAR(255) NOT NULL,
	[CreatedDate] DATETIME DEFAULT GETDATE() NOT NULL,
	[UpdatedBy] VARCHAR(255) NOT NULL,
	[UpdatedDate] DATETIME DEFAULT GETDATE() NOT NULL
);	

--Creating the Order table with reference to Customer, Cart, Payment, Shipping
CREATE TABLE [Order] (
	[OrderID] VARCHAR(255) PRIMARY KEY NOT NULL,
	[CustomerID] VARCHAR(255) NOT NULL,
	[OrderDate] DATETIME NOT NULL,
	[Status] VARCHAR(255) NOT NULL DEFAULT 'Placed',
	[TotalAmount] DECIMAL(10,2) NOT NULL,
	[PaymentID] INT NOT NULL,
	[ShippingID] INT NOT NULL,
	[CartID] INT NULL,
	[CreatedBy] VARCHAR(255) NOT NULL,
	[CreatedDate] DATETIME DEFAULT GETDATE() NOT NULL,
	[UpdatedBy] VARCHAR(255) NOT NULL,
	[UpdatedDate] DATETIME DEFAULT GETDATE() NOT NULL,
	FOREIGN KEY ([CustomerID]) REFERENCES [Customer](Email),
	FOREIGN KEY ([ShippingID]) REFERENCES [Shipping](ShippingID),
	FOREIGN KEY ([PaymentID]) REFERENCES [Payment]([PaymentID]),
	FOREIGN KEY ([CartID]) REFERENCES [Cart]([CartID])
);	

--Creating the OredItem table with reference to Order, Product
CREATE TABLE [OrderITem] (
	[OrderITemID] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[OrderID]  VARCHAR(255) NOT NULL,
	[ProductID] INT NOT NULL,
	[Quantity] INT NOT NULL,
	[TotalPrice] DECIMAL(10,2) NOT NULL,
	[CreatedBy] VARCHAR(255) NOT NULL,
	[CreatedDate] DATETIME DEFAULT GETDATE() NOT NULL,
	[UpdatedBy] VARCHAR(255) NOT NULL,
	[UpdatedDate] DATETIME DEFAULT GETDATE() NOT NULL,
	FOREIGN KEY ([OrderID]) REFERENCES [Order]([OrderID]),
	FOREIGN KEY (ProductID) REFERENCES [Product](ProductID)
);

