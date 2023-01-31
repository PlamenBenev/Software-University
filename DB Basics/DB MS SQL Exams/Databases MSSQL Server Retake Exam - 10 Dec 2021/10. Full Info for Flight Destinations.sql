SELECT ap.AirportName,fd.Start AS DayTime,
	fd.TicketPrice,p.FullName,
	ac.Manufacturer,ac.Model
FROM FlightDestinations fd
JOIN Airports ap ON fd.AirportId = ap.Id
JOIN Passengers p ON fd.PassengerId = p.Id
JOIN Aircraft ac ON fd.AircraftId = ac.Id
WHERE (DATEPART(HOUR,fd.Start) BETWEEN 6 AND 20)
AND fd.TicketPrice > 2500
ORDER BY ac.Model