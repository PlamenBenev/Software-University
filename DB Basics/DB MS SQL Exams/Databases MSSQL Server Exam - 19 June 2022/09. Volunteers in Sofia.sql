SELECT v.Name, v.PhoneNumber,SUBSTRING(v.Address,
CHARINDEX(',',v.Address) + 2,
LEN(v.Address))
FROM Volunteers v
JOIN VolunteersDepartments vd ON vd.Id = v.DepartmentId
WHERE vd.DepartmentName = 'Education program assistant'
AND v.Address LIKE '%Sofia%'
ORDER BY v.Name