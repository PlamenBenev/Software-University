SELECT top (1) AVG(e.Salary) AS MinAverageSalary
FROM Employees as e
GROUP BY E.DepartmentID
ORDER BY MinAverageSalary