SELECT TOP (50) s.EmployeeID,
CONCAT(S.FirstName,' ',s.LastName) AS EmployeeName,
CONCAT(e.FirstName,' ',e.LastName) AS ManagerName, 
d.Name AS DepartmentName
FROM Employees AS e
JOIN Employees AS s ON e.EmployeeID = s.ManagerID
JOIN Departments AS d ON s.DepartmentID = d.DepartmentID
ORDER BY EmployeeID