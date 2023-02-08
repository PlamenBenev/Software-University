SELECT ct.LastName,
	AVG(s.Length) AS CiagrLength,
	CEILING(AVG(s.RingRange)) AS CiagrRingRange
FROM Clients ct
 JOIN ClientsCigars cc ON cc.ClientId = ct.Id
 JOIN Cigars cs ON cc.CigarId = cs.Id
 JOIN Sizes s ON s.Id = cs.SizeId
WHERE cc.CigarId IS NOT NULL
GROUP BY ct.LastName
ORDER BY CiagrLength DESC