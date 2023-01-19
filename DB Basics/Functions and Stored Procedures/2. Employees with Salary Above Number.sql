CREATE PROC usp_GetEmployeesSalaryAboveNumber (@num DECIMAL(18,4)) AS
	SELECT FirstName,LastName FROM Employees
	WHERE Salary >= @num

	EXEC dbo.usp_GetEmployeesSalaryAboveNumber 48100