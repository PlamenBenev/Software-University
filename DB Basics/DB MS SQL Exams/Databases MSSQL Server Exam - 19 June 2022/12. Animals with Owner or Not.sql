CREATE OR ALTER PROC usp_AnimalsWithOwnersOrNot(@AnimalName VARCHAR(50))
	AS 
	SELECT a.name,ISNULL(o.Name,'For adoption') as OwnersName
	FROM Animals a
	LEFT JOIN Owners o ON a.OwnerId = o.Id
	WHERE @AnimalName = a.Name
	
EXEC usp_AnimalsWithOwnersOrNot 'Pumpkinseed Sunfish'