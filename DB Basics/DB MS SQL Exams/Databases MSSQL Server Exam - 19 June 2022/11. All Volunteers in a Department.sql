CREATE OR ALTER FUNCTION udf_GetVolunteersCountFromADepartment (@VolunteersDepartment VARCHAR(50))
	RETURNS INT
		BEGIN
			RETURN (
			SELECT COUNT(id) 
			FROM Volunteers
			WHERE DepartmentId = 
				(SELECT Id FROM VolunteersDepartments WHERE DepartmentName = @VolunteersDepartment)
			GROUP BY DepartmentId
			)
		END