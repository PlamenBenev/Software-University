INSERT INTO Passengers (FullName,Email)
	SELECT CONCAT(FirstName,' ',LastName) AS FullName,
	CONCAT(FirstName,LastName) + '@gmail.com' AS Email
	FROM Pilots
	WHERE Id >= 5 AND Id <= 15