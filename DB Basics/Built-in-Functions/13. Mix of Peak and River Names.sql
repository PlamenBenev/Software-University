SELECT PeakName,RiverName, 
LOWER(
	CONCAT(
		SUBSTRING(PeakName,1,LEN(PeakName)),
		SUBSTRING(RiverName,2,LEN(Rivername))
		)) AS Mix
FROM Peaks AS p JOIN Rivers AS r ON
		LEFT(r.RiverName,1) = RIGHT(p.PeakName,1)
	ORDER BY Mix
