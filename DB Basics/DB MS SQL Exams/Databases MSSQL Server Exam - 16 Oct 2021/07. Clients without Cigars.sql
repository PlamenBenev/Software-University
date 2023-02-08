SELECT ct.Id, CONCAT(ct.FirstName,' ',ct.LastName) AS ClientName,ct.Email
FROM Clients ct
LEFT JOIN ClientsCigars cc ON cc.ClientId = ct.Id
LEFT JOIN Cigars cs ON cs.Id = cc.CigarId
WHERE cc.ClientId IS NULL
ORDER BY ClientName