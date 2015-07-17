USE AccountingChapter10;
GO

CREATE VIEW CustomerPhoneList_vw
AS
   SELECT CustomerName, Contact, Phone
   FROM Customers;

GO

SELECT * FROM CustomerPhoneList_vw;

SELECT * FROM Customers;

USE AccountingChapter10;
GO

CREATE VIEW Employees_vw
AS
SELECT   EmployeeID,
         FirstName,
         MiddleInitial,
         LastName,
         Title,
         HireDate,
         TerminationDate,
         ManagerEmpID,
         Department
FROM Employees;

GO

SELECT *
FROM Employees_vw;

GO

CREATE VIEW CurrentEmployees_vw
AS
SELECT   EmployeeID,
         FirstName,
         MiddleInitial,
         LastName,
         Title,
         HireDate,
         ManagerEmpID,
         Department
FROM Employees
WHERE TerminationDate IS NULL;

GO

SELECT   EmployeeID,
         FirstName,
         LastName,
         TerminationDate
FROM Employees;

SELECT   EmployeeID,
         FirstName,
         LastName
FROM CurrentEmployees_vw;

USE AdventureWorks
GO

CREATE VIEW CustomerOrders_vw
AS
SELECT sc.AccountNumber,
       soh.SalesOrderID,
       soh.OrderDate,
       sod.ProductID,
       pp.Name,
       sod.OrderQty,
       sod.UnitPrice,
       sod.UnitPriceDiscount * sod.UnitPrice * sod.OrderQty AS TotalDiscount,
       sod.LineTotal
FROM   Sales.Customer AS sc
INNER JOIN Sales.SalesOrderHeader AS soh
      ON sc.CustomerID = soh.CustomerID
INNER JOIN Sales.SalesOrderDetail AS sod
      ON soh.SalesOrderID = sod.SalesOrderID
INNER JOIN Production.Product AS pp
      ON sod.ProductID = pp.ProductID;

GO

SELECT *
FROM CustomerOrders_vw;

SELECT AccountNumber, LineTotal
FROM CustomerOrders_vw
WHERE OrderDate = '01/07/2006';

USE AdventureWorks
GO

CREATE VIEW YesterdaysOrders_vw
AS
SELECT sc.AccountNumber,
       soh.SalesOrderID,
       soh.OrderDate,
       sod.ProductID,
       pp.Name,
       sod.OrderQty,
       sod.UnitPrice,
       sod.UnitPriceDiscount * sod.UnitPrice * sod.OrderQty AS TotalDiscount,
       sod.LineTotal
FROM   Sales.Customer AS sc
INNER JOIN   Sales.SalesOrderHeader AS soh
      ON sc.CustomerID = soh.CustomerID
INNER JOIN   Sales.SalesOrderDetail AS sod
      ON soh.SalesOrderID = sod.SalesOrderID
INNER JOIN Production.Product AS pp
      ON sod.ProductID = pp.ProductID
WHERE CAST(soh.OrderDate AS Date) = 
      CAST(DATEADD(day,-1,GETDATE()) AS Date);

GO

USE AdventureWorks

GO

UPDATE Sales.SalesOrderHeader
SET OrderDate = CAST(DATEADD(day,-1,GETDATE()) AS Date),
    DueDate = CAST(DATEADD(day,11,GETDATE()) AS Date),
    ShipDate = CAST(DATEADD(day,6,GETDATE()) AS Date)
WHERE Sales.SalesOrderHeader.SalesOrderID BETWEEN 43659 AND 43662; 

SELECT AccountNumber, SalesOrderID, OrderDate FROM YesterdaysOrders_vw;


GO

CREATE VIEW PortlandAreaAddresses_vw
AS
SELECT AddressID,
       AddressLine1,
       City,
       StateProvinceID,
       PostalCode,
       ModifiedDate
FROM Person.Address
WHERE PostalCode LIKE '970%'
   OR PostalCode LIKE '971%'
   OR PostalCode LIKE '972%'
   OR PostalCode LIKE '986[6-9]%'
WITH CHECK OPTION;

GO

UPDATE PortlandAreaAddresses_vw
SET PostalCode = '33333'  -- it was 97205
WHERE AddressID = 22;

UPDATE Person.Address
SET PostalCode = '33333'  -- it was 97205
WHERE AddressID = 22;

SELECT *
FROM sys.sql_modules
WHERE object_id = OBJECT_ID('dbo.YesterdaysOrders_vw');

GO

ALTER VIEW CustomerOrders_vw
WITH ENCRYPTION
AS
SELECT   sc.AccountNumber,
         soh.SalesOrderID,
         soh.OrderDate,
         sod.ProductID,
         pp.Name,
         sod.OrderQty,
         sod.UnitPrice,
         sod.UnitPriceDiscount * sod.UnitPrice * sod.OrderQty AS TotalDiscount,
         sod.LineTotal
FROM     Sales.Customer AS sc
INNER JOIN   Sales.SalesOrderHeader AS soh
      ON sc.CustomerID = soh.CustomerID
INNER JOIN   Sales.SalesOrderDetail AS sod
      ON soh.SalesOrderID = sod.SalesOrderID
INNER JOIN Production.Product AS pp
      ON sod.ProductID = pp.ProductID;

GO

EXEC sp_helptext CustomerOrders_vw

SELECT *
FROM sys.sql_modules
WHERE object_id = OBJECT_ID('dbo.CustomerOrders_vw');

GO

ALTER VIEW CustomerOrders_vw
WITH SCHEMABINDING
AS
SELECT   sc.AccountNumber,
         soh.SalesOrderID,
         soh.OrderDate,
         sod.ProductID,
         pp.Name,
         sod.OrderQty,
         sod.UnitPrice,
         sod.UnitPriceDiscount * sod.UnitPrice * sod.OrderQty AS TotalDiscount,
         sod.LineTotal
FROM     Sales.Customer AS sc
INNER JOIN   Sales.SalesOrderHeader AS soh
      ON sc.CustomerID = soh.CustomerID
INNER JOIN   Sales.SalesOrderDetail AS sod
      ON soh.SalesOrderID = sod.SalesOrderID
INNER JOIN Production.Product AS pp
      ON sod.ProductID = pp.ProductID;

GO

SELECT * FROM CustomerOrders_vw;

CREATE UNIQUE CLUSTERED INDEX ivCustomerOrders
ON CustomerOrders_vw(AccountNumber, SalesOrderID, ProductID);

SELECT COUNT(*) as RowsPerAccount 
FROM CustomerOrders_vw 
WHERE AccountNumber = 'AW00029722'

SELECT   soh.OrderDate,
         SUM(sod.OrderQty) TotalOrderQty,
         AVG(sod.UnitPrice) AveragePrice,
         AVG(sod.UnitPriceDiscount * sod.UnitPrice * sod.OrderQty) 
        AS AverageDiscount,
         SUM(sod.LineTotal) TotalSale
FROM     Sales.Customer AS sc
INNER JOIN   Sales.SalesOrderHeader AS soh
      ON sc.CustomerID = soh.CustomerID
INNER JOIN   Sales.SalesOrderDetail AS sod
      ON soh.SalesOrderID = sod.SalesOrderID
GROUP BY soh.OrderDate;

GO

CREATE VIEW CustomerTotalOrdersByDay_vw
WITH SCHEMABINDING
AS
SELECT   soh.OrderDate,
         SUM(sod.OrderQty) TotalOrderQty,
         AVG(sod.UnitPrice) AveragePrice,
         AVG(sod.UnitPriceDiscount * sod.UnitPrice * sod.OrderQty) 
        AS AverageDiscount,
         SUM(sod.LineTotal) TotalSale
FROM     Sales.Customer AS sc
INNER JOIN   Sales.SalesOrderHeader AS soh
      ON sc.CustomerID = soh.CustomerID
INNER JOIN   Sales.SalesOrderDetail AS sod
      ON soh.SalesOrderID = sod.SalesOrderID
GROUP BY soh.OrderDate;

GO

CREATE UNIQUE CLUSTERED INDEX ivCustomerOrdersAggregate
ON CustomerTotalOrdersByDay_vw(OrderDate);

GO

ALTER VIEW CustomerTotalOrdersByDay_vw
WITH SCHEMABINDING
AS
SELECT   soh.OrderDate,
         SUM(sod.OrderQty) TotalOrderQty,
         SUM(sod.UnitPrice) TotalUnitPrice,
         SUM(sod.UnitPriceDiscount * sod.UnitPrice * sod.OrderQty) 
        AS TotalDiscount,
         SUM(sod.LineTotal) TotalSale
FROM     Sales.Customer AS sc
INNER JOIN   Sales.SalesOrderHeader AS soh
      ON sc.CustomerID = soh.CustomerID
INNER JOIN   Sales.SalesOrderDetail AS sod
      ON soh.SalesOrderID = sod.SalesOrderID
GROUP BY soh.OrderDate;

GO

CREATE UNIQUE CLUSTERED INDEX ivCustomerOrdersAggregate
ON CustomerTotalOrdersByDay_vw(OrderDate);

GO

ALTER VIEW CustomerTotalOrdersByDay_vw
WITH SCHEMABINDING
AS
SELECT   soh.OrderDate,
         SUM(sod.OrderQty) TotalOrderQty,
         SUM(sod.UnitPrice) TotalUnitPrice,
         SUM(sod.UnitPriceDiscount * sod.UnitPrice * sod.OrderQty) 
        AS TotalDiscount,
         SUM(sod.LineTotal) TotalSale,
		     COUNT_BIG(*) TotalRows
FROM     Sales.Customer AS sc
INNER JOIN   Sales.SalesOrderHeader AS soh
      ON sc.CustomerID = soh.CustomerID
INNER JOIN   Sales.SalesOrderDetail AS sod
      ON soh.SalesOrderID = sod.SalesOrderID
GROUP BY soh.OrderDate;

GO


CREATE UNIQUE CLUSTERED INDEX ivCustomerOrdersAggregate
ON CustomerTotalOrdersByDay_vw(OrderDate);

