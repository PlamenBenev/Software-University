SELECT p.FullName,
COUNT(fd.PassengerId) AS CountOfAircraft,
SUM(fd.TicketPrice) AS TotalPayed
FROM Passengers p
JOIN FlightDestinations fd ON fd.PassengerId = p.id
GROUP BY p.FullName
HAVING COUNT(fd.PassengerId) > 1 AND CHARINDEX('a',FullName,2) = 2
ORDER BY p.FullName