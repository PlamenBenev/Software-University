SELECT TOP (50) e.EmployeeID,e.JobTitle,a.AddressID ,a.AddressText
FROM Employees as e JOIN Addresses as a ON a.AddressID = e.AddressID
ORDER BY a.AddressID