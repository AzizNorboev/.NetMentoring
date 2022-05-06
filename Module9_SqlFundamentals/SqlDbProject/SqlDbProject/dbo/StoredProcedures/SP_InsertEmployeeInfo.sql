-- TASK 3 Stored Procedure
CREATE PROCEDURE [dbo].[SP_InsertEmployeeInfo] 
(
@EmployeeName nvarchar(100) = NULL, 
@FirstName nvarchar(50) = NULL,
@LastName nvarchar(50) = NULL,
@CompanyName nvarchar(20) = NULL,
@Position nvarchar(50) = NULL,
@Street nvarchar(50) = NULL,
@City nvarchar(20) = NULL,
@State nvarchar(50) = NULL,
@ZipCode nvarchar(50) = NULL
)
AS
IF(@FirstName IS NULL)
	BEGIN
		RAISERROR('Invalid parameter: @FirstName cannot be NULL', 18, 0)
		RETURN
	END
IF(@FirstName = '')
	BEGIN
		RAISERROR('Invalid parameter: @FirstName cannot be EMPTY', 18, 0)
		RETURN
	END
 DECLARE @AddressId INT;
 DECLARE @PersonId INT;

 INSERT INTO Address values(@Street, @City, @State, @ZipCode) SET @AddressId = @@IDENTITY;
 INSERT INTO Person(FirstName, LastName) values(@FirstName, @LastName) SET @PersonId = @@IDENTITY;

 INSERT INTO Employee(AddressId, PersonId, CompanyName, Position, EmployeeName) 
 VALUES(@AddressId, @PersonId, @CompanyName, @Position, @EmployeeName);