Use UserRegistration


DECLARE @id INT, @c_name NVARCHAR(50), @city NVARCHAR(50)  
   
--Declare and set counter.  
DECLARE @Counter INT  
SET @Counter = 1  
   
--Declare a cursor  
DECLARE PrintCustomers CURSOR  
FOR  
SELECT id, c_name, city FROM customer  
  
--Open cursor  
OPEN PrintCustomers  
   
--Fetch the record into the variables.  
FETCH NEXT FROM PrintCustomers INTO  
@id, @c_name, @city  
  
--LOOP UNTIL RECORDS ARE AVAILABLE.  
WHILE @@FETCH_STATUS = 0  
    BEGIN  
        IF @Counter = 1  
        BEGIN  
            PRINT 'id' + CHAR(9) + 'c_name' + CHAR(9) + CHAR(9) + 'city'  
            PRINT '--------------------------'  
        END  
   
        --Print the current record  
        PRINT CAST(@id AS NVARCHAR(10)) + CHAR(9) + @c_name + CHAR(9) + CHAR(9) + @city  
      
        --Increment the counter variable  
        SET @Counter = @Counter + 1  
   
        --Fetch the next record into the variables.  
        FETCH NEXT FROM PrintCustomers INTO  
        @id, @c_name, @city  
    END  
   
--Close the cursor  
CLOSE PrintCustomers  
  
--Deallocate the cursor  
DEALLOCATE PrintCustomers  
