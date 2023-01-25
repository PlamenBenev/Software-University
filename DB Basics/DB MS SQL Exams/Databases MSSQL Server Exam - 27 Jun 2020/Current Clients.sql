SELECT CONCAT(FirstName,' ',LastName) AS Client, 
DATEDIFF(day,IssueDate,'2017/04/24') as DaysGoing, Status
FROM Clients c 
JOIN Jobs j ON c.ClientId = j.ClientId
WHERE j.Status != 'Finished'
ORDER BY DaysGoing DESC, c.ClientId