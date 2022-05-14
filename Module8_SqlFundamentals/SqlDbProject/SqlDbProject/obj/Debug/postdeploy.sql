/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

Insert into Person(FirstName, LastName) values ('Jack', 'Sparrow')
Insert into Person(FirstName, LastName) values ('Aziz', 'Norboev')
Insert into Person(FirstName, LastName) values ('Sherlok', 'Holmes')

insert into Address(Street, City, State, Zipcode) values('Boston Street', 'Boston', 'Massachusetts', '456')
insert into Address(Street, City, State, Zipcode) values('Portland Street', 'Portland', 'Oregon', '395')
insert into Address(Street, City, State, Zipcode) values('Baker Street', 'London', 'The UK', '712')


insert into Company(Name, AddressId) values('Company 1', 1)
insert into Company(Name, AddressId) values('Company 2', 2)
insert into Company(Name, AddressId) values('Company 3', 3)

insert into Employee(AddressId, PersonId, CompanyName, Position, EmployeeName) values(1, 1, 'Company 1', 'developer', 'Jack-Sparrow')
insert into Employee(AddressId, PersonId, CompanyName, Position, EmployeeName) values(2, 2, 'Company 2', 'manager', 'John-Wick')
insert into Employee(AddressId, PersonId, CompanyName, Position, EmployeeName) values(3, 3, 'Company 3', 'QA engineer', 'David Smith')
GO
