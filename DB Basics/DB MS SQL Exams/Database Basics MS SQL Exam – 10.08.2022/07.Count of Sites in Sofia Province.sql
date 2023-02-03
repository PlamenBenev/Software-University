SELECT l.Province,l.Municipality,l.Name,
	COUNT(s.Id) AS CountOfSites
FROM Locations l
JOIN Sites s ON s.LocationId = l.Id
WHERE l.Province = 'Sofia'
GROUP BY l.Province,l.Municipality,l.Name
ORDER BY CountOfSites DESC, l.Name 