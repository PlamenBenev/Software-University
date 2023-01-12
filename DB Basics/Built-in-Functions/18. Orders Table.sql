CREATE TABLE S(ID INT PRIMARY KEY, ProductName VARCHAR(50),OrderDate DATE)

INSERT INTO S (ID,ProductName,OrderDate)
VALUES
(1,'Butter',CONVERT(smalldatetime,'2016/09/19 00:00:00.000')),
(2,'Milk',CONVERT(smalldatetime,'2016/09/30 00:00:00.000')),
(3,'Cheese',CONVERT(smalldatetime,'2016/09/04 00:00:00.000')),
(4,'Bread',CONVERT(smalldatetime,'2015/12/20 00:00:00.000')),
(5,'Tomatoes',CONVERT(smalldatetime,'2015/12/30 00:00:00.000'))

SELECT ID,ProductName,OrderDate,
    DATEADD(DAY,3,OrderDate) AS [Pay Due],
    DATEADD(MONTH,1,OrderDate) AS [Deliver Due]
	FROM S