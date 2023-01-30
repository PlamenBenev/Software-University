SELECT CONCAT(o.Name,'-',a.Name) AS OwnersAnimals,
o.PhoneNumber,ac.CageId
FROM Owners o
JOIN Animals a ON o.Id = a.OwnerId
JOIN AnimalTypes aty ON aty.Id = a.AnimalTypeId
JOIN AnimalsCages ac ON ac.AnimalId = a.Id
WHERE aty.AnimalType = 'mammals'
ORDER BY O.Name,A.Name DESC