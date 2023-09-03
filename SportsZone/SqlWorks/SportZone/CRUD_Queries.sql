INSERT INTO [Customer] ([Email], [FirstName], [LastName], [ContactNumber], [Address], [City],[Country],[ZipCode],[ProfilePhoto],[CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate])
VALUES
    ('User 1','First','Last','1212','Kingston Street','Washington','United States','61321','image.jpg','User1', '2023-08-30 10:00:00', 'User1', '2023-08-30 10:00:00');

INSERT INTO [Security] ([Email], [Password], [SecurityQuestion], [Answer], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate])
VALUES('User 1', CONVERT(VARBINARY(MAX),'user1'),'What is your mother''s maiden name?', CONVERT(VARBINARY(MAX),'Shanthi'), 'User 1', GETDATE(), 'User 1', GETDATE());


INSERT INTO [Category] ([CategoryName],[Description], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate])
VALUES
    ( 'Footwear', 'Contains all footwear sports items',  'User1', '2023-08-30 10:00:00', 'User1', '2023-08-30 10:00:00');

INSERT INTO [Product] ([ProductName], [ProductImage], [StockCount], [Price], [CategoryID], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate])
VALUES
    ('Product B', 'product_b.jpg', 500, 1500, 1, 'User1', GETDATE(), 'User1',GETDATE());

INSERT INTO [Cart] ( [BelongsTo], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate])
VALUES
    (  'User 1','User1', '2023-08-30 10:00:00', 'User1', '2023-08-30 10:00:00');

INSERT INTO [Shipping]([Address],[City],[Country],[ZipCode],[Landmark],[BelongsTo],[CreatedBy],[CreatedDate],[UpdatedBy],[UpdatedDate])
VALUES ('Lalgudi','Trichy','India','632123','Sivan temple','User 1','User 1',GETDATE(),'User 1',GETDATE());

INSERT INTO [Payment] ([PaymentType],[CreatedBy],[CreatedDate],[UpdatedBy],[UpdatedDate])
VALUES ('Cash on Delivery','User 1',GETDATE(),'User 1',GETDATE());

--Insert into CartItem table via stored procedure
EXEC InsertCartItem @CartID = 1,@ProductID = 1,@Quantity =5,@CreatedBy = 'User 1';
EXEC InsertCartItem @CartID = 1,@ProductID = 2,@Quantity =15,@CreatedBy = 'User 1';



--customer ordering via Buy Now option
EXECUTE InsertNewOrder @CustomerID = 'User 1',@Status = 'Placed',@PaymentID = 1,@ShippingID=2,@CreatedBy='User 1',@ProductID=1,@Quantity=15;

--customer ordering via Cart option
EXECUTE InsertNewOrder @CustomerID = 'User 1',@Status = 'Placed',@PaymentID = 1,@ShippingID=2,@CartID=1,@CreatedBy='User 1';



SELECT * FROM [Customer];
SELECT * FROM [Security];
SELECT * FROM [Category];
SELECT * FROM [Product];
SELECT * FROM [Cart];
SELECT * FROM [CartItem];
SELECT * FROM [Shipping];
SELECT * FROM [Payment];
SELECT * FROM [Order];
SELECT * FROM [OrderItem];

UPDATE [Cart] SET IsEnabled = 1 ;

DROP TABLE [OrderItem];

--Insert cartitem to orderitem
SELECT [ProductID],[Quantity],[TotalPrice],[CreatedBy] FROM [CartItem] WHERE [CartID]=3;

INSERT INTO [OrderItem] SELECT [ProductID],[Quantity],[TotalPrice],[CreatedBy] FROM [CartItem] WHERE [CartID]=3;

INSERT INTO [OrderItem] ([OrderID],[ProductID], [Quantity], [TotalPrice], [CreatedBy],[CreatedDate],[UpdatedBy],[UpdatedDate])
SELECT  o.[OrderID],ci.[ProductID], ci.[Quantity], ci.[TotalPrice],o.[CustomerID],GETDATE(),o.[CustomerID],GETDATE()
FROM CartItem ci
JOIN Cart c ON ci.CartID = c.CartID
JOIN [Order] o ON c.[BelongsTo] = o.[OrderID];

--generating last four digits of the orderid
 SELECT Increment = COALESCE(MAX(RIGHT(OrderID, 4)), 0) + 1 FROM [Order]


 drop view VW_NewGUID

 drop view VW_Product