SELECT 
    CASE WHEN COALESCE(e.FirstName,e.LastName) IS NOT NULL
THEN CONCAT(e.FirstName,' ',e.LastName)
ELSE
'None'
END AS Employee,
    ISNULL(D.Name, 'None') AS DepartmentName,
    ISNULL(C.Name, 'None') AS CategoryName,
    ISNULL(R.Description, 'None') AS ReportDescription,
    Format(ISNULL(R.OpenDate, 'None'), 'dd.MM.yyyy') AS OpenDate,
    ISNULL(S.Label, 'None') AS StatusLabel,
    ISNULL(U.Name, 'None') AS UserName
FROM Reports R
LEFT JOIN Employees E ON R.EmployeeId = E.Id
LEFT JOIN Departments D ON E.DepartmentId = D.Id
LEFT JOIN Categories C ON R.CategoryId = C.Id
LEFT JOIN Status S ON R.StatusId = S.Id
LEFT JOIN Users U ON R.UserId = U.Id
ORDER BY 
    E.FirstName DESC,
    E.LastName DESC,
    D.Name ASC,
    C.Name ASC,
    R.Description ASC,
    R.OpenDate ASC,
    S.Label ASC,
    U.Name ASC
