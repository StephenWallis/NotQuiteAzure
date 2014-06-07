/*
Deployment script for ClaimsReporting
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "ClaimsReporting"
:setvar DefaultDataPath ""
:setvar DefaultLogPath ""

GO
:on error exit
GO
USE [master]
GO
IF (DB_ID(N'$(DatabaseName)') IS NOT NULL
    AND DATABASEPROPERTYEX(N'$(DatabaseName)','Status') <> N'ONLINE')
BEGIN
    RAISERROR(N'The state of the target database, %s, is not set to ONLINE. To deploy to this database, its state must be set to ONLINE.', 16, 127,N'$(DatabaseName)') WITH NOWAIT
    RETURN
END

GO
IF (DB_ID(N'$(DatabaseName)') IS NOT NULL) 
BEGIN
    ALTER DATABASE [$(DatabaseName)]
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [$(DatabaseName)];
END

GO
PRINT N'Creating $(DatabaseName)...'
GO
CREATE DATABASE [$(DatabaseName)] COLLATE SQL_Latin1_General_CP1_CI_AS
GO
EXECUTE sp_dbcmptlevel [$(DatabaseName)], 100;


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
                RECOVERY FULL,
                CURSOR_CLOSE_ON_COMMIT OFF,
                AUTO_CREATE_STATISTICS ON,
                AUTO_SHRINK OFF,
                AUTO_UPDATE_STATISTICS ON,
                RECURSIVE_TRIGGERS OFF 
            WITH ROLLBACK IMMEDIATE;
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE OFF 
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
            SET READ_COMMITTED_SNAPSHOT OFF;
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
USE [$(DatabaseName)]
GO
IF fulltextserviceproperty(N'IsFulltextInstalled') = 1
    EXECUTE sp_fulltext_database 'enable';


GO
/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

GO
PRINT N'Creating [dbo].[Call]...';


GO
CREATE TABLE [dbo].[Call] (
    [phone_number] NVARCHAR (255) NOT NULL,
    [custNo]       NVARCHAR (255) NOT NULL,
    CONSTRAINT [pk_Call] PRIMARY KEY CLUSTERED ([phone_number] ASC, [custNo] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
) ON [PRIMARY];


GO
PRINT N'Creating [dbo].[Claims]...';


GO
CREATE TABLE [dbo].[Claims] (
    [claim_ID]  NVARCHAR (255) NOT NULL,
    [cust_ID]   NVARCHAR (255) NOT NULL,
    [longatude] NVARCHAR (255) NOT NULL,
    [latitude]  NVARCHAR (255) NOT NULL,
    [policy_ID] NVARCHAR (255) NOT NULL,
    PRIMARY KEY CLUSTERED ([claim_ID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
) ON [PRIMARY];


GO
PRINT N'Creating [dbo].[Customers]...';


GO
CREATE TABLE [dbo].[Customers] (
    [cust_ID]    NVARCHAR (255) NOT NULL,
    [custNo]     INT            NULL,
    [Name]       VARCHAR (255)  NOT NULL,
    [DOB]        DATE           NULL,
    [home_phone] NVARCHAR (255) NULL,
    [work_phone] NVARCHAR (255) NULL,
    [address]    NVARCHAR (255) NULL,
    [email]      NVARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([cust_ID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);


GO
PRINT N'Creating [dbo].[Policy]...';


GO
CREATE TABLE [dbo].[Policy] (
    [policy_ID]     NVARCHAR (255) NOT NULL,
    [vehicle_make]  NVARCHAR (255) NULL,
    [vehicle_model] NVARCHAR (255) NULL,
    [registration]  NVARCHAR (255) NOT NULL,
    [custNo]        NVARCHAR (255) NOT NULL,
    PRIMARY KEY CLUSTERED ([policy_ID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
) ON [PRIMARY];


GO
-- Refactoring step to update target server with deployed transaction logs
CREATE TABLE  [dbo].[__RefactorLog] (OperationKey UNIQUEIDENTIFIER NOT NULL PRIMARY KEY)
GO
sp_addextendedproperty N'microsoft_database_tools_support', N'refactoring log', N'schema', N'dbo', N'table', N'__RefactorLog'
GO

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

/*Customers*/
SET DATEFORMAT DMY

INSERT INTO Customers(cust_ID, custNo, Name, DOB, home_phone, work_phone, address, email)
VALUES("1079607", 0, "Bob Jones", "12/3/1982", "03 312 8967", "03 345 8077", "128 Random Street, RD24, Kaiapoi, 1895", "bob.jones@hotmail.com");

INSERT INTO Customers(cust_ID, custNo, Name, DOB, home_phone, work_phone, address, email)
VALUES("2349981", 1, "Steve Hadwin", "12/9/1966", "03 313 4502", "03 344 7867", "Northwood Towers, Ashburton, 7098", "steve.hadwin@hotmail.com");

INSERT INTO Customers(cust_ID, custNo, Name, DOB, home_phone, work_phone, address, email)
VALUES("1098767", 2, "Tanya Smith", "12/3/1967", "03 312 7810", "03 365 0098", "16 Westbourne Street, Ashburton, 9087", "tanya1203@hotmail.com");

/*Policy*/
INSERT INTO Policy(policy_ID, cust_ID, vehicle_make, vehicle_model, registration)
VALUES("1079607M01", "1079607", "Skoda", "Fabia", "EUH509")

INSERT INTO Policy(policy_ID, cust_ID, vehicle_make, vehicle_model, registration)
VALUES("1079607M02", "1079607", "Toyota", "Hilux Surf", "EBY567")

INSERT INTO Policy(policy_ID, cust_ID, vehicle_make, vehicle_model, registration)
VALUES("1079607M03", "1079607", "Vauxhall", "Astra", "EDF524")

INSERT INTO Policy(policy_ID, cust_ID, vehicle_make, vehicle_model, registration)
VALUES("2349981M01", "2349981", "Hyundai", "Santa Fe", "EEE443")

INSERT INTO Policy(policy_ID, cust_ID, vehicle_make, vehicle_model, registration)
VALUES("1098767M01", "1098767", "Toyota", "Starlet", "LTK007")

INSERT INTO Policy(policy_ID, cust_ID, vehicle_make, vehicle_model, registration)
VALUES("1098767M02", "1098767", "Porche", "911", "ALG800")

/*Claims*/

INSERT INTO Claims(policy_ID, claim_ID, cust_ID)
VALUES("1079607M02","1079607C01","1079607")

INSERT INTO Claims(policy_ID, claim_ID, cust_ID)
VALUES("2349981M01","2349981C01","2349981")

/*Calls*/

INSERT INTO Call(cust_ID, phone_number)
VALUES("1079607", "027 334 9987");

INSERT INTO Call(cust_ID, phone_number)
VALUES("2349981", "03 477 8800");


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
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
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET MULTI_USER 
    WITH ROLLBACK IMMEDIATE;


GO
