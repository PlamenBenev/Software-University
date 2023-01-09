CREATE VIEW V_EmployeesHiredAfter200 AS
SELECT FirstName,LastName FROM Employees
WHERE (SELECT YEAR(HireDate)) > 2000