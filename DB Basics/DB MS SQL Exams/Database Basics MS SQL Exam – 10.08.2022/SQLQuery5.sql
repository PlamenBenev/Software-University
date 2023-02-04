CREATE OR ALTER PROC usp_AnnualRewardLottery(@TouristName VARCHAR(50))
	AS 
	SELECT t.Name,
		(
			SELECT COUNT(s.Id))


			FROM Tourists T
			JOIN SitesTourists st ON t.Id = st.TouristId
			JOIN Sites S ON s.Id = st.SiteId
			WHERE @TouristName = t.Name