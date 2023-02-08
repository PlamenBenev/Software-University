SELECT c.Id,c.CigarName,c.PriceForSingleCigar,t.TasteType,t.TasteStrength
FROM Cigars c 
JOIN Tastes t ON c.TastId = t.Id
WHERE t.TasteType = 'Earthy' OR t.TasteType = 'Woody'
ORDER BY C.PriceForSingleCigar DESC