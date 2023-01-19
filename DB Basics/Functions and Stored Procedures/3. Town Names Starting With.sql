CREATE OR ALTER PROC usp_GetTownsStartingWith (@strng NVARCHAR(50)) AS
 BEGIN
	SELECT Name FROM Towns
	WHERE LEFT(Name,LEN(@strng)) = @strng
END

	EXEC dbo.usp_GetTownsStartingWith b