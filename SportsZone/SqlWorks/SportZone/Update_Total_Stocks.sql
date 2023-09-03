CREATE PROCEDURE UpdateTotalStock
	@ProductID INT,
	@Quantity INT
AS
BEGIN
	DECLARE @AvailStock INT;
	SELECT @AvailStock = [StockCount] FROM [Product];
	UPDATE [Product] SET [StockCount] = @AvailStock - @Quantity WHERE [ProductID] = @ProductID;
END;

EXECUTE UpdateTotalStock @ProductID = 1,@Quantity = 12;

DROP PROCEDURE UpdateTotalStock;