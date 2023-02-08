CREATE OR ALTER FUNCTION udf_ClientWithCigars(@name VARCHAR(50))
	RETURNS INT 
	BEGIN
		RETURN
	(SELECT count(c.Id) FROM Cigars c
		JOIN ClientsCigars cc ON c.Id = cc.CigarId
		JOIN Clients ct ON cc.ClientId = ct.Id
		WHERE ct.FirstName = @name)
	END

SELECT dbo.udf_ClientWithCigars('Betty')
