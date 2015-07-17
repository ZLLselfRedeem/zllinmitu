/* This next statement is going to use code to
** change the “current” database to AdventureWorks.
** This makes certain, right in the code, that you are going
** to the correct database.
*/

USE AdventureWorks;

/* This next statement declares your working table.
** This particular table is actually a variable we you are declaring
** on the fly.
*/

DECLARE @MyTable Table
(
   SalesOrderID      int,
   CustomerID        char(5)
);

/* Now that you we have your table variable, youwe’re ready
** to populate it with data from your SELECT statement.
** Note that you we could just as easily insert the 
** data into a permanent table (instead of a table variable).
*/
INSERT INTO @MyTable
   SELECT SalesOrderID, CustomerID
   FROM AdventureWorks.Sales.SalesOrderHeader
   WHERE SalesOrderID BETWEEN 44000 AND 44010;

-- Finally, let’s make sure that the data was inserted like youwe think
SELECT * 
FROM @MyTable;
