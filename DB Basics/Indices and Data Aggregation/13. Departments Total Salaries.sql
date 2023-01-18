SELECT DepartmentID,SUM(e.Salary) 
FROM Employees e
GROUP BY DepartmentID
ORDER BY DepartmentID