SELECT s.Name,l.Name,s.Establishment,c.Name
FROM Locations l
JOIN Sites s ON s.LocationId = l.Id
JOIN Categories c ON s.CategoryId = c.Id
ORDER BY c.Name DESC,l.Name,s.Name