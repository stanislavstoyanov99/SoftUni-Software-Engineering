CREATE PROC usp_ExcludeFromSchool(@StudentId INT)
AS
BEGIN
	DECLARE @student INT = (SELECT s.Id
							  FROM Students AS s
							 WHERE s.Id = @StudentId);

	IF(@student IS NULL)
	BEGIN
		RAISERROR('This school has no student with the provided id!', 16, 1);
	END

	DELETE FROM StudentsExams
		  WHERE StudentId IN (SELECT s.Id
								FROM Students AS s
							   WHERE s.Id = @StudentId);

	DELETE FROM StudentsSubjects
	      WHERE StudentId IN (SELECT s.Id
								FROM Students AS s
							   WHERE s.Id = @StudentId);

    DELETE FROM StudentsTeachers
	      WHERE StudentId IN (SELECT s.Id
								FROM Students AS s
							   WHERE s.Id = @StudentId);
    DELETE FROM Students
	      WHERE Id = @StudentId;
END

GO

EXEC dbo.usp_ExcludeFromSchool 1

SELECT COUNT(*) FROM Students