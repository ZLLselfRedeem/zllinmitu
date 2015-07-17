USE master
GO

IF EXISTS (SELECT * FROM sys.databases WHERE name = 'Accounting')
	DROP DATABASE Accounting;
GO

CREATE DATABASE Accounting
ON
  (NAME = 'Accounting',
   FILENAME = 'D:\sql_server\MSSQLSERVER\MSSQL11.MSSQLSERVER\MSSQL\DATA\AccountingC06Data.mdf',
   SIZE = 100MB,
   MAXSIZE = 100MB,
   FILEGROWTH = 5)
LOG ON
  (NAME = 'AccountingLog',
   FILENAME = 'D:\sql_server\MSSQLSERVER\MSSQL11.MSSQLSERVER\MSSQL\DATA\AccountingC06Log.ldf',
   SIZE = 5MB,
   MAXSIZE = 25MB,
   FILEGROWTH = 5MB);

GO

USE Accounting
GO

BEGIN TRY
CREATE TABLE Employees
(
   EmployeeID       int          IDENTITY  NOT NULL,
   FirstName        varchar(25)            NOT NULL,
   MiddleInitial    char(1)                NULL,
   LastName         varchar(25)            NOT NULL,
   Title            varchar(25)            NOT NULL,
   SSN              varchar(11)            NOT NULL,
   Salary           money                  NOT NULL,
   PriorSalary      money                  NOT NULL,
   LastRaise AS Salary - PriorSalary,
   HireDate         date                   NOT NULL,
   TerminationDate  date                   NULL,
   ManagerEmpID     int                    NOT NULL,
   Department       varchar(25)            NOT NULL,
   PreviousEmployer   varchar(30)   NULL,
   DateOfBirth     date       NULL,
   LastRaiseDate   date       NOT NULL  DEFAULT '2008-01-01'
)
END TRY
BEGIN CATCH
END CATCH






	

