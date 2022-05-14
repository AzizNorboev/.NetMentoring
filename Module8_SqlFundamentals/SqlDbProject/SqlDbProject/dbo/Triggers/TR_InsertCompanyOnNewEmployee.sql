-- TASK 4 TRIGGER

CREATE TRIGGER Trg_InsertCompanyAfterNewEmployee
ON Employee
AFTER INSERT
AS
BEGIN
    INSERT INTO Company(
       Name,
	   AddressId
    )
	SELECT
       e.CompanyName,
	   e.AddressId
    FROM
        Employee e where e.Id=@@IDENTITY
   
END