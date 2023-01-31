CREATE OR ALTER PROC usp_SearchByAirportName (@airportName VARCHAR(70))
	AS 
	SELECT ap.AirportName,p.FullName,
		(CASE 
			WHEN 
			fd.TicketPrice <= 400 
				THEN 'Lower'
			WHEN 
			fd.TicketPrice > 400 AND FD.TicketPrice <= 1500 
				THEN 'Medium'
			WHEN fd.TicketPrice > 1500
				THEN 'High'
		END) AS LevelOfTickerPrice,
		ac.Manufacturer,
		ac.Condition,
		aty.TypeName
	FROM FlightDestinations fd
	JOIN Passengers p ON fd.PassengerId = p.id
	JOIN Airports ap ON fd.AirportId = ap.Id
	JOIN Aircraft ac ON fd.AircraftId = ac.Id
	JOIN AircraftTypes aty ON aty.Id = ac.TypeId
	WHERE @airportName = ap.AirportName
	ORDER BY ac.Manufacturer, p.FullName

EXEC usp_SearchByAirportName 'Sir Seretse Khama International Airport'