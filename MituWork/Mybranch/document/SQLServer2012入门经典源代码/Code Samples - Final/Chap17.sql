USE AdventureWorksDW
GO

SELECT FIS.ProductKey, SUM(FIS.OrderQuantity) SumOrderQuantity
FROM FactInternetSales FIS
JOIN DimPromotion DPR
  ON FIS.PromotionKey = DPR.PromotionKey
WHERE EnglishPromotionType <> 'Volume Discount'
GROUP BY FIS.ProductKey


CREATE NONCLUSTERED INDEX ixFIS_PromotionKey
ON [dbo].[FactInternetSales] ([PromotionKey])
INCLUDE ([ProductKey],[OrderQuantity])


SELECT FIS.ProductKey, SUM(FIS.OrderQuantity) SumOrderQuantity
FROM FactInternetSales FIS
LEFT JOIN DimPromotion DPR
  ON FIS.PromotionKey = DPR.PromotionKey
WHERE DPR.EnglishPromotionType <> 'Volume Discount'
  OR DPR.PromotionKey IS NULL
GROUP BY FIS.ProductKey
