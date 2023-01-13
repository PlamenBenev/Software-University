SELECT e.EmployeeID,e.FirstName,
CASE WHEN P.StartDate > '2005' THEN NULL ELSE P.Name END
FROM Employees AS e 
JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE E.EmployeeID = 24