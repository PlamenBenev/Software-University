SELECT CONCAT(e.FirstName,' ',e.LastName) AS Employee,
	D.Name AS Department,
	c.Name AS Category,
	r.Description,
	Format(r.OpenDate,'dd-mm-yyyy'),
	s.Label AS Status,
	u.Name AS [User]
FROM Employees e
LEFT JOIN Departments d ON e.DepartmentId = d.Id
LEFT JOIN Categories c ON c.DepartmentId = d.Id
LEFT JOIN Reports r ON c.Id = r.CategoryId
LEFT JOIN Status s ON r.StatusId = s.Id
LEFT JOIN Users u ON u.Age = r.UserId
GROUP BY e.FirstName,e.LastName,d.Name,c.Name,r.Description,
	r.OpenDate,s.Label
ORDER BY E.FirstName DESC,e.LastName DESC,
d.Name,c.Name,r.Description,r.OpenDate,s.Label,u.Name