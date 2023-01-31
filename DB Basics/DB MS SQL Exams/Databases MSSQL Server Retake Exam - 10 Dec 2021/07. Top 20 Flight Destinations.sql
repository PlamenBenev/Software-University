SELECT TOP (20) fd.id AS DestinationId,Start,p.FullName,
	a.AirportName,TicketPrice
FROM FlightDestinations fd
JOIN Passengers p ON fd.PassengerId = p.Id
JOIN Airports a ON fd.AirportId = a.Id
WHERE DAY(Start) % 2 = 0
ORDER BY TicketPrice DESC,a.AirportName