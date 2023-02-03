DELETE TouristsBonusPrizes WHERE BonusPrizeId in (
	SELECT Id FROM BonusPrizes)
DELETE BonusPrizes WHERE Name = 'Sleeping bag'