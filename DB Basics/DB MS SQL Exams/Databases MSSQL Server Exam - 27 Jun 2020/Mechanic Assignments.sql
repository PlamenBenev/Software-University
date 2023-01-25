SELECT CONCAT(FirstName,' ',LastName) AS Mechanic, status, IssueDate
FROM Mechanics m JOIN Jobs j ON m.MechanicId = j.MechanicId
ORDER BY m.MechanicId,j.IssueDate,j.JobId