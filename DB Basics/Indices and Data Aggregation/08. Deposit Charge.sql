SELECT DepositGroup, MagicWandCreator, Min(DepositCharge) AS MinDepositCharge
FROM WizzardDeposits
GROUP BY DepositGroup,MagicWandCreator
ORDER BY MagicWandCreator, DepositGroup