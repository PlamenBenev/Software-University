SELECT TOP (5) E.EmployeeID, E.FirstName, p.Name AS ProjectName
FROM Employees AS e 
JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE P.StartDate > YEAR(2002) AND P.StartDate > MONTH(08) AND P.StartDate > DAY(13)
AND p.EndDate IS NULL
ORDER BY e.EmployeeID