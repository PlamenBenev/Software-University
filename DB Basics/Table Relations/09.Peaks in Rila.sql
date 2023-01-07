SELECT m.MountainRange,p.PeakName,p.Elevation FROM Peaks as p
	JOIN Mountains as m ON  p.MountainId = m.Id
	WHERE M.MountainRange = 'Rila'
		 ORDER BY Elevation DESC
			