CREATE OR ALTER PROC usp_AnnualRewardLottery(@TouristName VARCHAR(50))
AS 
BEGIN
	IF (SELECT 
		COUNT(t.Id) AS Reward
			FROM Tourists T
			JOIN SitesTourists st ON t.Id = st.TouristId
			JOIN Sites S ON s.Id = st.SiteId
			WHERE @TouristName = t.Name) >= 100
			BEGIN
				UPDATE Tourists
				SET Reward = 'Gold badge'
				WHERE Name = @TouristName
			END
	ELSE IF (SELECT 
		COUNT(t.Id) AS Reward
			FROM Tourists T
			JOIN SitesTourists st ON t.Id = st.TouristId
			JOIN Sites S ON s.Id = st.SiteId
			WHERE @TouristName = t.Name) >= 50
			BEGIN
				UPDATE Tourists
				SET Reward = 'Silver badge'
				WHERE Name = @TouristName
			END
	ELSE IF (SELECT 
		COUNT(t.Id) AS Reward
			FROM Tourists T
			JOIN SitesTourists st ON t.Id = st.TouristId
			JOIN Sites S ON s.Id = st.SiteId
			WHERE @TouristName = t.Name) >= 25
			BEGIN
				UPDATE Tourists
				SET Reward = 'Bronze badge'
				WHERE Name = @TouristName
			END
	SELECT Name,Reward FROM Tourists WHERE Name = @TouristName
END

EXEC usp_AnnualRewardLottery 'Gerhild Lutgard'