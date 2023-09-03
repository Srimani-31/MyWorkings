-- Create a table to store orders
CREATE TABLE Orders (
    OrderID VARCHAR(50) PRIMARY KEY,
    OrderDate DATETIME,
    -- Other order detailsll
);

create view getNewID as select newid() as new_id

create function myfunction ()
returns uniqueidentifier
as begin
   return (select new_id from getNewID)
end
-- Function to generate a random component
CREATE FUNCTION GenerateRandomComponent()
RETURNS VARCHAR(4)
AS
BEGIN
    DECLARE @Random VARCHAR(4);
    SET @Random = LEFT(dbo.myfunction(), 4); -- Generates a random string of 10 characters
    RETURN @Random;
END;



-- Procedure to insert a new order
CREATE PROCEDURE InsertOrder
	@Status VARCHAR(255) ,
	@TotalAmount DECIMAL(10,2),
	@PaymentID INT,
	@ShippingID INT,
	@CreatedBy VARCHAR(255),
    -- Other order details as parameters
AS
BEGIN
    DECLARE @OrderID VARCHAR(255);
    DECLARE @Timestamp VARCHAR(255);

    -- Generate a timestamp component
    SET @Timestamp = REPLACE(CONVERT(VARCHAR, GETDATE(), 120), '-', '');
    SET @Timestamp = REPLACE(@Timestamp, ' ', '');
    SET @Timestamp = REPLACE(@Timestamp, ':', '');

    -- Generate a random component
    DECLARE @RandomComponent VARCHAR(4);
    SET @RandomComponent = dbo.GenerateRandomComponent();

    -- Calculate an incremental number based on existing orders
    DECLARE @Increment INT;
    SELECT @Increment = COALESCE(MAX(RIGHT(OrderID, 4)), 0) + 1 FROM Orders;

    -- Concatenate components to create the order ID
    SET @OrderID = 'SPRTZN-' + @Timestamp + '-'  + @RandomComponent + '-'+RIGHT('0000' + CAST(@Increment AS VARCHAR(4)), 4) ;
	 -- Insert the order into the Orders table
    INSERT INTO Orders (OrderID, OrderDate /* Other order details */) 
    VALUES (@OrderID, GETDATE() /* Other order values */);
   
END;

select * from Orders;
select * from getNewID;
exec InsertOrder;

insert into Orders values('FLPKT-20230828093645-ABCD-2378',GETDATE());

drop function GenerateRandomComponent
drop procedure dbo.InsertOrder
drop table Orders
drop function dbo.myfunction

use Test

SELECT GETDATE() AS CurrentDateTime;

SELECT REPLACE(CONVERT(VARCHAR, GETDATE(), 120), '-', '') AS CurrentDateTimeRoundedToSeconds;
SELECT REPLACE(REPLACE(CONVERT(VARCHAR, GETDATE(), 120), '-', ''),' ','') AS CurrentDatetimeRemovedWhiteSpaces;
SELECT REPLACE(REPLACE(REPLACE(CONVERT(VARCHAR, GETDATE(), 120), '-', ''),' ',''),':','') AS TimeStampWithoutSpecailCharacter;

SELECT RandomComponent = LEFT((select new_id from getNewID),4);

SELECT CONCAT('SPRTZN','-',REPLACE(REPLACE(REPLACE(CONVERT(VARCHAR, GETDATE(), 120), '-', ''),' ',''),':',''),'-',LEFT((select new_id from getNewID),4),'-');