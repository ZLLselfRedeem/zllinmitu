USE AdventureWorksDW
GO

SELECT
  YEAR(OrderDate) OrderYear,
  FORMAT( OrderDate, 'MMMM', 'en-US' ) OrderMonth,
  SUM(ExtendedAmount) SumExtendedAmount
FROM FactInternetSales
GROUP BY YEAR(OrderDate), FORMAT( OrderDate, 'MMMM', 'en-US' )
ORDER BY SUM(ExtendedAmount) DESC

SELECT PivotOrders.*
FROM (
  SELECT
    YEAR(OrderDate) OrderYear,
    FORMAT( OrderDate, 'MMMM', 'en-US' ) OrderMonth,
    ExtendedAmount
  FROM FactInternetSales
) FormattedOrders
PIVOT (
  SUM(ExtendedAmount)
  FOR OrderMonth IN (
    [January],[February],[March],[April],[May],[June],
    [July],[August],[September],[October],[November],[December]
  )
) PivotOrders


SELECT DISTINCT DST.SalesTerritoryRegion, 
  EOMONTH(OrderDate) OrderEndOfMonth,
  SUM(ExtendedAmount) OVER 
    (PARTITION BY SalesTerritoryRegion, EOMONTH(OrderDate)) RegionMonthSales,
  SUM(ExtendedAmount) OVER 
    (PARTITION BY SalesTerritoryRegion) RegionSales,
  SUM(ExtendedAmount) OVER 
    (PARTITION BY EOMONTH(OrderDate)) MonthSales,
  SUM(ExtendedAmount) OVER 
    (PARTITION BY SalesTerritoryRegion, EOMONTH(OrderDate)) /
    SUM(ExtendedAmount) OVER 
      (PARTITION BY SalesTerritoryRegion) RegionSalesPct,
  SUM(ExtendedAmount) OVER 
    (PARTITION BY SalesTerritoryRegion, EOMONTH(OrderDate)) /
    SUM(ExtendedAmount) OVER 
      (PARTITION BY EOMONTH(OrderDate)) MonthSalesPct
FROM FactInternetSales FIS
JOIN DimSalesTerritory DST
  ON FIS.SalesTerritoryKey = DST.SalesTerritoryKey
ORDER BY SalesTerritoryRegion, OrderEndOfMonth;


WITH MonthTerritorySales AS (
SELECT DST.SalesTerritoryRegion, 
  EOMONTH(OrderDate) OrderEndOfMonth,
  SUM(ExtendedAmount) RegionMonthSales
FROM FactInternetSales FIS
JOIN DimSalesTerritory DST
  ON FIS.SalesTerritoryKey = DST.SalesTerritoryKey
GROUP BY DST.SalesTerritoryRegion, EOMONTH(OrderDate)
)
SELECT SalesTerritoryRegion, OrderEndOfMonth, RegionMonthSales,
  SUM(RegionMonthSales) OVER (
    PARTITION BY SalesTerritoryRegion 
    ORDER BY OrderEndOfMonth ROWS UNBOUNDED PRECEDING) RunningTotal,
  AVG(RegionMonthSales) OVER (
    PARTITION BY SalesTerritoryRegion 
    ORDER BY OrderEndOfMonth ROWS 6 PRECEDING) SixMonthMovingAverage
FROM MonthTerritorySales


SELECT YEAR(SaleDate) SaleYear,
    DATEPART(QUARTER, SaleDate) SaleQuarter,
    MONTH(SaleDate) SaleMonth,
    SUM(Quantity) TotalSold
FROM FactSales FS
GROUP BY ROLLUP (YEAR(SaleDate), DATEPART(QUARTER, SaleDate), MONTH(SaleDate))


CREATE TABLE FactChocolateSales (
    SaleDate DATE,
    Region VARCHAR(15),
    Product VARCHAR(25),
    Quantity INT
);

INSERT FactChocolateSales (SaleDate, Region, Product, Quantity)
VALUES
    ('2012-01-10','Portland','Salted Caramels',12590),
    ('2012-01-31','Seattle','Venezuelan Truffles',1770),
    ('2012-02-10','Portland','Salted Caramels',15250),
    ('2012-02-12','Portland','Rose Caramels',5400),
    ('2012-03-08','Seattle','Salted Caramels',1310),
    ('2012-03-10','Portland','Venezuelan Truffles',180);

SELECT YEAR(SaleDate) SaleYear,
    DATEPART(QUARTER, SaleDate) SaleQuarter,
    MONTH(SaleDate) SaleMonth,
    SUM(Quantity) TotalSold
FROM FactChocolateSales FS
GROUP BY ROLLUP (YEAR(SaleDate), DATEPART(QUARTER, SaleDate), MONTH(SaleDate))

SELECT Region, Product,
    SUM(Quantity) TotalSold
FROM FactChocolateSales FS
GROUP BY CUBE (Product, Region)


SELECT YEAR(SaleDate) [Year], DATEPART(QUARTER, SaleDate) Quarter, 
  EOMONTH(SaleDate) [EndOfMonth], Region, Product, SUM(Quantity) TotalSold
FROM FactChocolateSales
GROUP BY GROUPING SETS (
  (), --Total Summary
  (Region), --Region only
  (Product), --Product only
  (YEAR(SaleDate), Region), --Year / region combinations
  (YEAR(SaleDate), Product), --Year / Product combinations
  (YEAR(SaleDate), DATEPART(QUARTER, SaleDate), Region), --etc.
  (YEAR(SaleDate), DATEPART(QUARTER, SaleDate), Product), --etc.
  (YEAR(SaleDate), DATEPART(QUARTER, SaleDate), EOMONTH(SaleDate), Region, Product),
  (YEAR(SaleDate), DATEPART(QUARTER, SaleDate), EOMONTH(SaleDate), Region),
  (YEAR(SaleDate), DATEPART(QUARTER, SaleDate), EOMONTH(SaleDate), Product)
)


 
