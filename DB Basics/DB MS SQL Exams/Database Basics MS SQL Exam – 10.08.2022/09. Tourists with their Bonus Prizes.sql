SELECT t.Name,t.Age,t.PhoneNumber,t.Nationality,
(CASE
	WHEN bp.Name IS NULL THEN '(no bonus prize)' 
	ELSE BP.Name END
	) AS Rewards
FROM Tourists t
LEFT JOIN TouristsBonusPrizes tbp ON t.Id = tbp.TouristId
LEFT JOIN BonusPrizes bp ON tbp.BonusPrizeId = bp.Id
ORDER BY t.Name
