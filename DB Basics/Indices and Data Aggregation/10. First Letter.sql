SELECT LEFT(w.FirstName,1) AS FirstLetter
FROM WizzardDeposits W
WHERE W.DepositGroup = 'Troll Chest'
GROUP BY LEFT(w.FirstName,1)
ORDER BY FirstLetter