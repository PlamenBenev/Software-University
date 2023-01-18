SELECT DepositGroup,IsDepositExpired,AVG(DepositInterest) AS AverageInterest
FROM WizzardDeposits 
WHERE DepositExpirationDate >= '1985-01-01'
GROUP BY IsDepositExpired,DepositGroup
ORDER BY DepositGroup DESC, IsDepositExpired