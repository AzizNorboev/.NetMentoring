﻿/*
Deployment script for SqlIntroMentoring

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "SqlIntroMentoring"
:setvar DefaultFilePrefix "SqlIntroMentoring"
:setvar DefaultDataPath "C:\Users\Aziz_Norboev\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"
:setvar DefaultLogPath "C:\Users\Aziz_Norboev\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [master];


GO

IF (DB_ID(N'$(DatabaseName)') IS NOT NULL) 
BEGIN
    ALTER DATABASE [$(DatabaseName)]
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [$(DatabaseName)];
END

GO
PRINT N'Creating database $(DatabaseName)...'
GO
CREATE DATABASE [$(DatabaseName)]
    ON 
    PRIMARY(NAME = [$(DatabaseName)], FILENAME = N'$(DefaultDataPath)$(DefaultFilePrefix)_Primary.mdf')
    LOG ON (NAME = [$(DatabaseName)_log], FILENAME = N'$(DefaultLogPath)$(DefaultFilePrefix)_Primary.ldf') COLLATE SQL_Latin1_General_CP1_CI_AS
GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
USE [$(DatabaseName)];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                NUMERIC_ROUNDABORT OFF,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                CURSOR_CLOSE_ON_COMMIT OFF,
                AUTO_CREATE_STATISTICS ON,
                AUTO_SHRINK OFF,
                AUTO_UPDATE_STATISTICS ON,
                RECURSIVE_TRIGGERS OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ALLOW_SNAPSHOT_ISOLATION OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET READ_COMMITTED_SNAPSHOT OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_UPDATE_STATISTICS_ASYNC OFF,
                PAGE_VERIFY NONE,
                DATE_CORRELATION_OPTIMIZATION OFF,
                DISABLE_BROKER,
                PARAMETERIZATION SIMPLE,
                SUPPLEMENTAL_LOGGING OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET TRUSTWORTHY OFF,
        DB_CHAINING OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET HONOR_BROKER_PRIORITY OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET FILESTREAM(NON_TRANSACTED_ACCESS = OFF),
                CONTAINMENT = NONE 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CREATE_STATISTICS ON(INCREMENTAL = OFF),
                MEMORY_OPTIMIZED_ELEVATE_TO_SNAPSHOT = OFF,
                DELAYED_DURABILITY = DISABLED 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE (QUERY_CAPTURE_MODE = ALL, DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_PLANS_PER_QUERY = 200, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 367), MAX_STORAGE_SIZE_MB = 100) 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE = OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
    END


GO
IF fulltextserviceproperty(N'IsFulltextInstalled') = 1
    EXECUTE sp_fulltext_database 'enable';


GO
PRINT N'Creating Table [dbo].[Address]...';


GO
CREATE TABLE [dbo].[Address] (
    [Id]      INT           IDENTITY (1, 1) NOT NULL,
    [Street]  NVARCHAR (50) NOT NULL,
    [City]    NVARCHAR (20) NULL,
    [State]   NVARCHAR (50) NULL,
    [ZipCode] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[Company]...';


GO
CREATE TABLE [dbo].[Company] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (20) NOT NULL,
    [AddressId] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[Employee]...';


GO
CREATE TABLE [dbo].[Employee] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [AddressId]    INT            NOT NULL,
    [PersonId]     INT            NOT NULL,
    [CompanyName]  NVARCHAR (100) NOT NULL,
    [Position]     NVARCHAR (30)  NULL,
    [EmployeeName] NVARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[Person]...';


GO
CREATE TABLE [dbo].[Person] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [FirstName] NVARCHAR (50) NOT NULL,
    [LastName]  NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Company_Address]...';


GO
ALTER TABLE [dbo].[Company]
    ADD CONSTRAINT [FK_Company_Address] FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Address] ([Id]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Employee_Address]...';


GO
ALTER TABLE [dbo].[Employee]
    ADD CONSTRAINT [FK_Employee_Address] FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Address] ([Id]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Employee_Person]...';


GO
ALTER TABLE [dbo].[Employee]
    ADD CONSTRAINT [FK_Employee_Person] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person] ([Id]);


GO
PRINT N'Creating Trigger [dbo].[Trg_InsertCompanyAfterNewEmployee]...';


GO
-- TASK 4 TRIGGER

CREATE TRIGGER Trg_InsertCompanyAfterNewEmployee
ON Employee
AFTER INSERT
AS
BEGIN
    INSERT INTO Companies(
       Name,
	   AddressId
    )
	SELECT
       e.CompanyName,
	   e.AddressId
    FROM
        Employee e where e.Id=@@IDENTITY
   
END
GO
PRINT N'Creating View [dbo].[EmployeeInfo]...';


GO
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
GO
PRINT N'Creating Procedure [dbo].[SP_InsertEmployeeInfo]...';


GO
-- TASK 3 Stored Procedure
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

GO
DECLARE @VarDecimalSupported AS BIT;

SELECT @VarDecimalSupported = 0;

IF ((ServerProperty(N'EngineEdition') = 3)
    AND (((@@microsoftversion / power(2, 24) = 9)
          AND (@@microsoftversion & 0xffff >= 3024))
         OR ((@@microsoftversion / power(2, 24) = 10)
             AND (@@microsoftversion & 0xffff >= 1600))))
    SELECT @VarDecimalSupported = 1;

IF (@VarDecimalSupported > 0)
    BEGIN
        EXECUTE sp_db_vardecimal_storage_format N'$(DatabaseName)', 'ON';
    END


GO
PRINT N'Update complete.';


GO