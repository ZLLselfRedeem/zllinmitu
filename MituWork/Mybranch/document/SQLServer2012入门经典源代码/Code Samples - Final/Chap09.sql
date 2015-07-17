CREATE TABLE MyTableKeyExample
(
   Column1   int IDENTITY
     PRIMARY KEY NONCLUSTERED,
   Column2   int
)

SELECT *
FROM [Production].[TransactionHistory]
WHERE ReferenceOrderLineID = 0
    AND ReferenceOrderID BETWEEN 41500 AND 42000;

SELECT *
FROM [Production].[TransactionHistory]
WHERE ReferenceOrderLineID BETWEEN 0 AND 2
    AND ReferenceOrderID = 41599;

CREATE NONCLUSTERED INDEX 
    [IX2_TransactionHistory_ReferenceOrderLineID_ReferenceOrderID] 
ON [Production].[TransactionHistory]
(
    [ReferenceOrderLineID] ASC,
    [ReferenceOrderID] ASC
	
);

ALTER INDEX [IX_TransactionHistory_ReferenceOrderID_ReferenceOrderLineID] 
ON [Production].[TransactionHistory] REBUILD;

SELECT SpecialOfferID, COUNT(*) OrderCount
FROM Sales.SalesOrderDetail
GROUP BY SpecialOfferID
ORDER BY COUNT(*) DESC

CREATE INDEX ix_SalesOrderDetail_ProductID_filt_SpecialOffers
ON Sales.SalesOrderDetail (ProductID)
WHERE SpecialOfferID > 1;

SELECT ProductID, Name
FROM Production.Product
WHERE ISNULL(SellEndDate, '99991231') >= GETDATE()

DECLARE @db_id SMALLINT;
DECLARE @object_id INT;
SET @db_id = DB_ID(N'AdventureWorks');
SET @object_id = OBJECT_ID(N'AdventureWorks.Sales.SalesOrderDetail');
SELECT database_id, object_id, index_id, index_depth, avg_fragmentation_in_percent,
page_count
FROM sys.dm_db_index_physical_stats(@db_id,@object_id,NULL,NULL,NULL);

ALTER INDEX PK_SalesOrderDetail_SalesOrderID_SalesOrderDetailID
  ON Sales.SalesOrderDetail
    REBUILD WITH (FILLFACTOR = 100)

