SELECT TOP (50) e.FirstName,e.LastName,t.Name ,a.AddressText
FROM Employees as e
JOIN Addresses as a ON e.AddressID = a.AddressID
JOIN Towns as t ON t.TownID = a.TownID
ORDER BY e.FirstName,e.LastName