SELECT 
	SUBSTRING(t.Name,CHARINDEX(' ',t.name),LEN(t.name)) AS LastName,
	t.Nationality,
	t.Age,
	t.PhoneNumber
FROM Tourists t
JOIN SitesTourists st ON t.Id = st.TouristId
JOIN Sites s ON s.Id = st.SiteId
JOIN Categories c ON  s.CategoryId = c.Id
WHERE c.Name = 'History and archaeology'
GROUP BY t.Name,t.Nationality,t.Age,t.PhoneNumber
ORDER BY LastName