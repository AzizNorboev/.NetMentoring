-- TASK 2 - CREATE VIEW
CREATE VIEW [dbo].[EmployeeInfo] 
	AS SELECT TOP 3 e.Id, 
	ISNULL(e.EmployeeName, CONCAT(p.FirstName, ' ', p.LastName)) AS 'EmployeeFullName',
	CONCAT(a.ZipCode, '_', a.State, ', ', a.City, '-', a.Street) AS 'EmployeeFullAddress',
	CONCAT(e.CompanyName, ' ', e.Position) AS 'EmployeeCompanyInfo'
	FROM Employee e
	JOIN Person p on p.Id=e.PersonId
	JOIN Address a on a.Id=e.AddressId
	ORDER BY a.City