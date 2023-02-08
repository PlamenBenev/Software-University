SELECT CONCAT(ct.FirstName,' ',ct.LastName) AS FullName,
	a.Country,a.ZIP, CONCAT('$',MAX(cs.PriceForSingleCigar)) AS CigarPrice
FROM Clients ct
JOIN Addresses a ON ct.AddressId = a.Id
JOIN ClientsCigars cc ON ct.Id = cc.ClientId
JOIN Cigars cs ON cc.CigarId = cs.Id
WHERE ISNUMERIC(a.ZIP) = 1
GROUP BY ct.FirstName,ct.LastName,a.Country,a.ZIP
ORDER BY FullName