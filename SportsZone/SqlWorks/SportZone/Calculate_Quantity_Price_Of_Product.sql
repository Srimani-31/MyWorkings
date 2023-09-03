CREATE FUNCTION CalculateTotalAmount(
	@ProductID INT,
	@Quantity INT)
RETURNS DECIMAL(10,2)
AS 
BEGIN
	 DECLARE @TotalPrice DECIMAL(10,2);
	SELECT @TotalPrice = Price FROM Product WHERE ProductID = @ProductID;
	SET @TotalPrice = @Quantity	* @TotalPrice;
	RETURN @TotalPrice
END;


DROP FUNCTION CalculateTotalAmount;

--calling a GetNewGUID method
BEGIN
DECLARE @TotalAmount DECIMAL(10,2);
SET @TotalAmount = [dbo].CalculateTotalAmount(1,2);
PRINT(@TotalAmount);
END;
