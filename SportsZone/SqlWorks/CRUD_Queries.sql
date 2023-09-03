INSERT INTO [Customer] ([Email], [FirstName], [LastName], [ContactNumber], [Address], [City],[Country],[ZipCode],[ProfilePhoto],[CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate])
VALUES
    ('User 1','First','Last','1212','Kingston Street','Washington','United States','61321','image.jpg','User1', '2023-08-30 10:00:00', 'User1', '2023-08-30 10:00:00');

INSERT INTO [Product] ([ProductName], [ProductImage], [StockCount], [Price], [CategoryID], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate])
VALUES
    ('Product A', 'product_a.jpg', 100, 500, 1, 'User1', '2023-08-30 10:00:00', 'User1', '2023-08-30 10:00:00');

INSERT INTO [Category] ([CategoryName],[Description], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate])
VALUES
    ( 'Footwear', 'Contains all footwear sports items',  'User1', '2023-08-30 10:00:00', 'User1', '2023-08-30 10:00:00');

INSERT INTO [Cart] ( [BelongsTo], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate])
VALUES
    (  'User 1','User1', '2023-08-30 10:00:00', 'User1', '2023-08-30 10:00:00');
--Insert into CartItem table via stored procedure
EXEC InsertCartItem @CartID = 2,@ProductID = 1,@Quantity =2,@CreatedBy = 'User 1',@UpdatedBy = 'User 2';


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
