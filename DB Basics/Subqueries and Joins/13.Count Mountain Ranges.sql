SELECT C.CountryCode, COUNT(m.MountainRange) AS MountainRanges
FROM Countries c
JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
JOIN Mountains m ON m.Id = mc.MountainId
WHERE c.CountryCode = 'BG' OR c.CountryCode = 'RU' OR c.CountryCode = 'US'
GROUP BY c.CountryCode