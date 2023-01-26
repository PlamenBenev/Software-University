SELECT CONCAT(FirstName,' ',LastName) AS Mechanic, 
AVG(DATEDIFF(DAY,j.IssueDate,j.FinishDate))  AS AverageDays
FROM Mechanics m
JOIN Jobs j ON m.MechanicId = j.MechanicId
Group by FirstName,LastName,m.MechanicId
ORDER BY m.MechanicId