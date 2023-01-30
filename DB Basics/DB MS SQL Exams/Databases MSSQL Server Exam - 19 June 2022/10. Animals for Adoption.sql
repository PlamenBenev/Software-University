SELECT a.Name,YEAR(a.BirthDate) as BirthYear,aty.AnimalType
FROM Animals a
JOIN AnimalTypes aty ON a.AnimalTypeId = aty.Id
WHERE aty.AnimalType != 'Birds'
AND a.OwnerId IS NULL
AND YEAR(a.BirthDate) >= 2018
ORDER BY a.Name