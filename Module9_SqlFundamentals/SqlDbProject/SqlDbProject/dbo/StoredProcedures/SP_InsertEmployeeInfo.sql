﻿-- TASK 3 Stored Procedure
CREATE PROCEDURE SP_InsertEmployeeInfo 
@EmployeeName nvarchar(100) = NULL, 
@FirstName nvarchar(50),
@LastName nvarchar(50),
@CompanyName nvarchar(20),
@Position nvarchar(50) = NULL,
@Street nvarchar(50),
@City nvarchar(20) = NULL,
@State nvarchar(50) = NULL,
@ZipCode nvarchar(50) = NULL
AS
 DECLARE @AddressId INT;
 DECLARE @PersonId INT;

 INSERT INTO Address values(@Street, @City, @State, @ZipCode) SET @AddressId = @@IDENTITY;
 INSERT INTO Person(FirstName, LastName) values(@FirstName, @LastName) SET @PersonId = @@IDENTITY;

 INSERT INTO Employee(AddressId, PersonId, CompanyName, Position, EmployeeName) values(@AddressId, @PersonId, @CompanyName, @Position, @EmployeeName);

GO