SELECT * FROM Towns
WHERE NOT LEFT(Name,1) IN ('B','R','D')
ORDER BY Name