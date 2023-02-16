SELECT Username,c.Name AS CategoryName
FROM Users u
JOIN Reports r ON r.UserId = u.Id
JOIN Categories c ON r.CategoryId = c.Id
WHERE FORMAT(U.Birthdate,'dd-mm') =  FORMAT(r.OpenDate,'dd-mm')
ORDER BY u.Username,c.Name