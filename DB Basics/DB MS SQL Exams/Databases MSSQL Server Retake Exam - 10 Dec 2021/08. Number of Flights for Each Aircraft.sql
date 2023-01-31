SELECT ac.Id AS AircraftId,ac.Manufacturer,ac.FlightHours,
COUNT(FD.AircraftId) AS FlightDestinationCount,
ROUND(AVG(fd.TicketPrice),2) AS AvgPrice
FROM Aircraft ac
JOIN FlightDestinations fd ON fd.AircraftId = ac.Id
GROUP BY ac.Id,ac.Manufacturer,ac.FlightHours
HAVING COUNT(FD.AircraftId) > 1
ORDER BY FlightDestinationCount DESC,ac.Id

