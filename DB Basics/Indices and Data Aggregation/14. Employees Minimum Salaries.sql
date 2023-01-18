SELECT DepartmentID,MIN(e.Salary) AS MinimumSalary
FROM Employees e
WHERE (DepartmentID IN (2,5,7)) AND
HireDate > '2000-01-01'
GROUP BY DepartmentID