SELECT e.FirstName, e.LastName, e.HireDate, d.Name AS DeptName
FROM Employees AS e JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE (d.Name = 'Sales' OR d.Name = 'Finance')
AND e.HireDate > YEAR(1999)
ORDER BY E.HireDate