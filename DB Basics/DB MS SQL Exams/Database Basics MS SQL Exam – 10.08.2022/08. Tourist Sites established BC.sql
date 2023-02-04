SELECT s.Name,l.Name,l.Municipality,l.Province,s.Establishment
FROM Sites s
JOIN Locations l ON s.LocationId = l.Id
WHERE l.Name NOT LIKE '[BMD]%'
AND s.Establishment LIKE '%BC'
ORDER BY s.Name