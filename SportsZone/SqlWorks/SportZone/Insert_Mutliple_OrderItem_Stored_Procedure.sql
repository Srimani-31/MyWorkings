--Transfer all the ordered Cart item into the Product table
CREATE PROCEDURE InsertMultipleOrderItem
	@OrderID VARCHAR(255),
	@CartID INT,
	@CreatedBy VARCHAR(255)
AS 
BEGIN
	INSERT INTO [OrderItem] ([OrderID],[ProductID], [Quantity], [TotalPrice], [CreatedBy],[CreatedDate],[UpdatedBy],[UpdatedDate])
	SELECT  @OrderID,[ProductID], [Quantity], [TotalPrice],@CreatedBy,GETDATE(),@CreatedBy,GETDATE()
	FROM CartItem WHERE [CartID] = @CartID;
END;

DROP PROCEDURE InsertOrderItem;

PRINT(GETDATE());