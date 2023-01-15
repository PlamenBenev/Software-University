SELECT s.EmployeeID,s.FirstName, s.ManagerID, e.FirstName 
FROM Employees AS e
JOIN Employees AS s ON e.EmployeeID = s.ManagerID
WHERE s.ManagerID = 3 OR s.ManagerID = 7
ORDER BY EmployeeID