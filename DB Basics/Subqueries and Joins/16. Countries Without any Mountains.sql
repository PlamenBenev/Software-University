SELECT COUNT(c.CountryName) AS Count
FROM Countries c
LEFT JOIN MountainsCountries mc ON mc.CountryCode = c.CountryCode
LEFT JOIN Mountains m  ON mc.MountainId = m.Id
WHERE M.Id IS NULL