CREATE FUNCTION udf_FlightDestinationsByEmail(@email NVARCHAR(50))
	RETURNS INT
	BEGIN
		RETURN (SELECT COUNT(fd.PassengerId) 
		FROM FlightDestinations fd
		JOIN Passengers p ON fd.PassengerId = p.Id
		WHERE p.Email = @email)
	END

SELECT dbo.udf_FlightDestinationsByEmail ('PierretteDunmuir@gmail.com')