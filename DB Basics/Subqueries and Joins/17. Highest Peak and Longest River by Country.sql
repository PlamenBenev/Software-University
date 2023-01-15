SELECT TOP (5) c.CountryName, 
(MAX(P.Elevation)) AS HighestPeakElevation, 
(MAX(R.Length)) AS LongestRiverLength
FROM Countries c
	FULL JOIN MountainsCountries mc ON mc.CountryCode = c.CountryCode
	FULL JOIN Mountains m ON mc.MountainId = m.Id
	FULL JOIN Peaks p ON m.Id = p.MountainId
	FULL JOIN CountriesRivers cr ON c.CountryCode = cr.CountryCode
	FULL JOIN Rivers r ON r.Id = cr.RiverId
GROUP BY c.CountryName
ORDER BY HighestPeakElevation DESC,
LongestRiverLength DESC,
c.CountryName