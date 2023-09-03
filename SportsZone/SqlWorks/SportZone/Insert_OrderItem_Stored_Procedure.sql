--Transfer the all the ordered Cart item into the Product table
CREATE PROCEDURE InsertOrderItem
	@OrderID VARCHAR(255),
	@ProductID INT,
	@Quantity INT,
	@CreatedBy VARCHAR(255)
AS 
BEGIN
	 DECLARE @TotalPrice DECIMAL(10,2);
	SELECT @TotalPrice = Price FROM Product WHERE ProductID = @ProductID;
	SET @TotalPrice = @Quantity	* @TotalPrice;
	INSERT INTO [OrderItem] ([OrderId] ,[ProductID],[Quantity], [TotalPrice],[CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate])
VALUES
    (@OrderID, @ProductID, @Quantity,@TotalPrice, @CreatedBy, GETDATE(), @CreatedBy,GETDATE());
END;

EXECUTE InsertOrderItem @OrderID='SPRTZN-20230831210045-992C-0006',@ProductID=1,@Quantity=3,@CreatedBy='User 1';


DROP PROCEDURE InsertOrderItem;

