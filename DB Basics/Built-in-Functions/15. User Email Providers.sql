SELECT Username, 
SUBSTRING(Email, PATINDEX('%@%',Email) + 1,LEN(Email)) as EmailProvider
FROM Users
ORDER BY EmailProvider,Username