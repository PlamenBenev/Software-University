SELECT TOP (5) c.CountryName, r.RiverName FROM Countries c
LEFT JOIN CountriesRivers cr ON CR.CountryCode = C.CountryCode
LEFT JOIN Rivers r ON R.Id = cr.RiverId
WHERE c.ContinentCode = 'AF'
ORDER BY c.CountryName