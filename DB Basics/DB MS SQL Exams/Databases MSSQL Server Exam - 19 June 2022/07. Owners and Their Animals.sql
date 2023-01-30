SELECT TOP (5) o.Name as Owner, COUNT(a.OwnerId) AS CountOfAnimals
FROM animals a
JOIN Owners o ON o.Id = a.OwnerId
WHERE o.Id = a.OwnerId
GROUP BY o.Name
ORDER BY CountOfAnimals DESC,o.Name