CREATE OR ALTER PROC usp_GetEmployeesFromTown (@townName NVARCHAR(50))
AS 
BEGIN
	SELECT e.FirstName, e.LastName 
	FROM Towns t
	JOIN Addresses a ON a.TownID = t.TownID
	JOIN Employees e ON a.AddressID = e.AddressID
	WHERE t.Name = @townName
END

	EXEC dbo.usp_GetEmployeesFromTown 'Sofia'