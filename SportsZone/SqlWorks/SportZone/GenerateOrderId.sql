-- Create a view to store the Generated GUID
CREATE VIEW VW_NewGUID AS SELECT NEWID() AS New_ID;

--Create a function to get the GUID from the View table
CREATE FUNCTION GetNewGUID()
RETURNS UNIQUEIDENTIFIER
AS BEGIN
   RETURN (SELECT NEW_ID FROM VW_NewGUID)
END;

-- Function to generate a random component
CREATE FUNCTION GenerateRandomComponent()
RETURNS VARCHAR(4)
AS
BEGIN
    DECLARE @Random VARCHAR(4);
    SET @Random = LEFT(dbo.GetNewGUID(), 4); -- Generates a random string of 4 characters
    RETURN @Random;
END;

-- Procedure to insert a new order
CREATE PROCEDURE InsertNewOrder
	@CustomerID VARCHAR(255),
	@Status VARCHAR(255) = 'Placed',
	@PaymentID INT,
	@ShippingID INT,
	@CartID INT = NULL,
	@CreatedBy VARCHAR(255),
	@ProductID INT = NULL,
	@Quantity INT = NULL
AS
BEGIN
    DECLARE @OrderID VARCHAR(255);
    DECLARE @Timestamp VARCHAR(255);
	DECLARE @TotalAmount DECIMAL(10,2);

    -- Generate a timestamp component
    SET @Timestamp = REPLACE(CONVERT(VARCHAR, GETDATE(), 120), '-', '');
    SET @Timestamp = REPLACE(@Timestamp, ' ', '');
    SET @Timestamp = REPLACE(@Timestamp, ':', '');

    -- Generate a random component
    DECLARE @RandomComponent VARCHAR(4);
    SET @RandomComponent = dbo.GenerateRandomComponent();

    -- Calculate an incremental number based on existing orders
    DECLARE @Increment INT;
    SELECT @Increment = COALESCE(MAX(RIGHT(OrderID, 4)), 0) + 1 FROM [Order];

    -- Concatenate components to create the order ID
    SET @OrderID = 'SPRTZN-' + @Timestamp + '-'  + @RandomComponent + '-'+RIGHT('0000' + CAST(@Increment AS VARCHAR(4)), 4) ;

	--Calculating the Total Cart Amount
	IF @CartID IS NOT NULL
	BEGIN
		--Have to write the code snippet for moving CartItem into the OrderItem

		SET @TotalAmount = dbo.EvaluateCartTotal(@CartID)
		UPDATE [Cart] SET [IsEnabled]=0;
	END
	ELSE
	BEGIN
		SET @TotalAmount = [dbo].CalculateTotalAmount(@ProductID,@Quantity);
	END;

	--Insert the order into the Orders table
    INSERT INTO [Order] ([OrderID],[CustomerID], [OrderDate],[Status],[TotalAmount],[PaymentID],[ShippingID],[CartID],[CreatedBY],[CreatedDate],[UpdatedBy],[UpdatedDate]) 
    VALUES (@OrderID,@CustomerID,GETDATE(),@Status,@TotalAmount,@PaymentID,@ShippingID,@CartID,@CreatedBy,GETDATE(),@CreatedBy,GETDATE() );   
	
	--Insert the Ordered Items into the OrderItem table
	IF @ProductID IS NOT NULL
	BEGIN
		EXECUTE InsertOrderItem @OrderID=@OrderID,@ProductID=@ProductID,@Quantity=@Quantity,@CreatedBy=@CreatedBy;
		EXECUTE UpdateTotalStock @ProductID =@ProductID,@Quantity = @Quantity;
	END
	ELSE
	BEGIN
		EXECUTE InsertMultipleOrderItem @OrderID = @OrderID,@CartID = @CartID,@CreatedBy = @CreatedBy; 
	END;

	--update the stock total in the Product table
	

END;

--customer ordering via Buy Now option
EXECUTE InsertNewOrder @CustomerID = 'User 1',@Status = 'Placed',@PaymentID = 1,@ShippingID=1,@CreatedBy='User 1',@ProductID=1,@Quantity=5;

--customer ordering via Cart option
EXECUTE InsertNewOrder @CustomerID = 'User 1',@Status = 'Placed',@PaymentID = 1,@ShippingID=1,@CartID=2,@CreatedBy='User 1';


--dropping a stored procedure
DROP PROCEDURE InsertNewOrder;

--TESTING

--calling a GetNewGUID method
BEGIN
DECLARE @RandomComponent VARCHAR(255);
SET @RandomComponent = [dbo].GetNewGUID();
PRINT(@RandomComponent);
END;

--calling a GenerateRandomComponent method
BEGIN
DECLARE @RandomComponent VARCHAR(4);
SET @RandomComponent = [dbo].GenerateRandomComponent();
PRINT(@RandomComponent);
END;


SELECT GETDATE() AS CurrentDateTime;

SELECT REPLACE(CONVERT(VARCHAR, GETDATE(), 120), '-', '') AS CurrentDateTimeRoundedToSeconds;
SELECT REPLACE(REPLACE(CONVERT(VARCHAR, GETDATE(), 120), '-', ''),' ','') AS CurrentDatetimeRemovedWhiteSpaces;
SELECT REPLACE(REPLACE(REPLACE(CONVERT(VARCHAR, GETDATE(), 120), '-', ''),' ',''),':','') AS TimeStampWithoutSpecailCharacter;

SELECT RandomComponent = LEFT((select new_id from getNewID),4);

SELECT CONCAT('SPRTZN','-',REPLACE(REPLACE(REPLACE(CONVERT(VARCHAR, GETDATE(), 120), '-', ''),' ',''),':',''),'-',LEFT((select new_id from getNewID),4),'-');

