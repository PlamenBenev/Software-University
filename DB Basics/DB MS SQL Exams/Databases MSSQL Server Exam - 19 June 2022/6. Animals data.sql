SELECT Name,at.AnimalType, BirthDate
FROM Animals A
JOIN AnimalTypes at ON A.Id = at.Id