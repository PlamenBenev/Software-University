CREATE OR ALTER PROC usp_SearchByTaste(@taste VARCHAR(50))
	AS
	SELECT c.CigarName,
	CONCAT('$',c.PriceForSingleCigar) AS Price,
	t.TasteType,
	b.BrandName,
	CONCAT(s.Length,' cm') AS CigarLength,
	CONCAT(s.RingRange,' cm') AS CigarRingRange
	FROM Cigars c
	JOIN Tastes t ON t.Id = c.TastId
	JOIN Brands b ON b.Id = c.BrandId
	JOIN Sizes s ON s.Id = c.SizeId
	WHERE @taste = t.TasteType
	ORDER BY s.Length,s.RingRange DESC

EXEC usp_SearchByTaste 'Woody'