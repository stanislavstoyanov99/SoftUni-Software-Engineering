CREATE FUNCTION udf_ExamGradesToUpdate(@studentId INT, @grade DECIMAL(3, 2))
RETURNS NVARCHAR(100)
AS
BEGIN
     DECLARE @resultMessage NVARCHAR(100);

     DECLARE @student INT =
     (
         SELECT s.Id
         FROM Students AS s
         WHERE s.Id = @studentId
     );

     IF(@student IS NULL)
         BEGIN
             SET @resultMessage = 'The student with provided id does not exist in the school!';
             RETURN @resultMessage;
         END;

     IF(@grade > 6)
         BEGIN
             SET @resultMessage = 'Grade cannot be above 6.00!';
             RETURN @resultMessage;
         END;

     DECLARE @countOfGrades INT =
     (
         SELECT COUNT(se.Grade)
         FROM Students AS s
              JOIN StudentsExams AS se ON se.StudentId = s.Id
         WHERE(s.Id = @studentId)
              AND (se.Grade BETWEEN @grade AND @grade + 0.5)
     );

     DECLARE @studentName NVARCHAR(50) =
         (
             SELECT s.FirstName
             FROM Students AS s
             WHERE s.Id = @student
         );

     SET @resultMessage = CONCAT('You have to update ', @countOfGrades, ' grades for the student ', @studentName);

     RETURN @resultMessage;
END;

GO

SELECT dbo.udf_ExamGradesToUpdate(12, 5.50)