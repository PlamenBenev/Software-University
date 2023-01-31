SELECT p.FirstName,p.LastName,a.Manufacturer,a.Model,a.FlightHours
FROM Pilots p
JOIN PilotsAircraft pa ON pa.PilotId = p.Id
JOIN Aircraft a ON a.Id = pa.AircraftId
WHERE A.FlightHours != NULL OR a.FlightHours <= 304
ORDER BY A.FlightHours DESC, p.FirstName