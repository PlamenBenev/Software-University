SELECT TOP (5) c.CigarName,c.PriceForSingleCigar,c.ImageURL
FROM Cigars c
JOIN Sizes s ON c.SizeId = s.Id
WHERE s.Length >= 12 AND (c.CigarName LIKE '%ci%' or c.PriceForSingleCigar >= 50)
	AND s.RingRange > 2.55
ORDER BY c.CigarName,c.PriceForSingleCigar DESC