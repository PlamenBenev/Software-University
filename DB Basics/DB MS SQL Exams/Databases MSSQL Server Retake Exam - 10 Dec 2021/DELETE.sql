DELETE FlightDestinations WHERE PassengerId in 
	(SELECT p.Id from Passengers p
	WHERE p.Id = PassengerId
	GROUP BY p.Id
	HAVING COUNT(FullName) <= 10)

DELETE Passengers WHERE FullName in (
	SELECT FullName 
	FROM Passengers 
	GROUP BY FullName
	HAVING COUNT(FullName) <= 10)