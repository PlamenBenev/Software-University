SELECT c.CountryCode, m.MountainRange, p.PeakName, p.Elevation 
FROM Countries c
JOIN MountainsCountries mc ON mc.CountryCode = c.CountryCode
JOIN Mountains m ON mc.MountainId = m.Id
JOIN Peaks p ON p.MountainId = m.Id
WHERE p.Elevation > 2835 AND c.CountryCode = 'BG'
ORDER BY Elevation DESC