--Calculate the cart total

CREATE FUNCTION EvaluateCartTotal (@CartID INT)
RETURNS DECIMAL(10, 2)
AS
BEGIN
    DECLARE @Total DECIMAL(10, 2)

    SELECT @Total = SUM(TotalPrice)
    FROM CartItem
    WHERE CartID = @CartID

    RETURN @Total
END;

--dropping a function
DROP FUNCTION EvaluateCartTotal;