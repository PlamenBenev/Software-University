CREATE OR ALTER FUNCTION udf_GetTouristsCountOnATouristSite (@Site VARCHAR(50))
	RETURNS INT 
		BEGIN
		RETURN
			(SELECT COUNT(t.Id) 
			FROM Tourists T
			JOIN SitesTourists st ON t.Id = st.TouristId
			join Sites S ON s.Id = st.SiteId
			WHERE @Site = s.Name)
		END

SELECT dbo.udf_GetTouristsCountOnATouristSite ('Regional History Museum – Vratsa')
