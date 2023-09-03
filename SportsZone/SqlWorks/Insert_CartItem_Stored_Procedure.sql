CREATE PROCEDURE InsertCartItem
	@CartID INT,
	@ProductID INT,
	@Quantity INT,
	@CreatedBy VARCHAR(255),
	@UpdatedBy VARCHAR(255)
AS 
BEGIN
	 DECLARE @TotalPrice DECIMAL(10,2);
	SELECT @TotalPrice = Price FROM Product WHERE ProductID = @ProductID;
	SET @TotalPrice = @Quantity	* @TotalPrice;
	INSERT INTO [CartItem] ([CartID] ,[ProductID],[Quantity], [TotalPrice],[CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate])
VALUES
    (@CartID, @ProductID, @Quantity,@TotalPrice, @CreatedBy, GETDATE(), @UpdatedBy,GETDATE());

END;


EXEC InsertCartItem @CartID = 2,@ProductID = 1,@Quantity =2,@CreatedBy = 'User 1',@UpdatedBy = 'User 2';

DROP PROCEDURE InsertCartItem;

