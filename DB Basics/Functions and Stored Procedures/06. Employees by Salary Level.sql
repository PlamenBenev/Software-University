CREATE OR ALTER PROC usp_EmployeesBySalaryLevel (@param VARCHAR(50))
AS
	BEGIN
		SELECT FirstName,LastName FROM Employees
		WHERE dbo.ufn_GetSalaryLevel(Salary) = @param
	END

EXEC dbo.usp_EmployeesBySalaryLevel 'High'