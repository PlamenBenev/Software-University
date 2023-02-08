UPDATE Cigars
	SET PriceForSingleCigar += PriceForSingleCigar *  0.2
	WHERE TastId = 
		(SELECT Id FROM Tastes t WHERE t.TasteType = 'Spicy')

UPDATE Brands
	SET BrandDescription = 'New description' WHERE BrandDescription IS NULL