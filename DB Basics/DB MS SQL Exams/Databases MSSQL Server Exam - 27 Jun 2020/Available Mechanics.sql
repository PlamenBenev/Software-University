SELECT CONCAT(FirstName, ' ' + LastName) AS Available
FROM Mechanics
WHERE MechanicId NOT IN
(
    SELECT DISTINCT
           m.MechanicId
    FROM Mechanics AS m
         JOIN Jobs AS j ON j.MechanicId = m.MechanicId
    WHERE j.Status = 'In Progress'
)
ORDER BY MechanicId;