SELECT TOP (5) e.EmployeeID,e.JobTitle,a.AddressID ,a.AddressText
FROM Employees as e JOIN Addresses as a ON a.AddressID = e.EmployeeID
ORDER BY AddressID