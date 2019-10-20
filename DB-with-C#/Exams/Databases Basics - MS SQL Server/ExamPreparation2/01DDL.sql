CREATE DATABASE School

CREATE TABLE Students (
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(30) NOT NULL,
MiddleName NVARCHAR(25),
LastName NVARCHAR(30) NOT NULL,
Age INT,
CHECK (Age BETWEEN 5 AND 100),
[Address] NVARCHAR(50),
Phone NCHAR(10)
)

CREATE TABLE Subjects (
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(20) NOT NULL,
Lessons INT NOT NULL,
CHECK (Lessons > 0)
)

CREATE TABLE StudentsSubjects (
Id INT PRIMARY KEY IDENTITY,
StudentId INT NOT NULL,
SubjectId INT NOT NULL,
Grade DECIMAL(3, 2) NOT NULL,
CHECK (Grade BETWEEN 2 AND 6),
CONSTRAINT FK_StudentsSubjects_Students
FOREIGN KEY (StudentId) REFERENCES Students(Id),
CONSTRAINT FK_StudentsSubjects_Subjects
FOREIGN KEY (SubjectId) REFERENCES Subjects(Id)
)

CREATE TABLE Exams (
Id INT PRIMARY KEY IDENTITY,
[Date] DATETIME,
SubjectId INT NOT NULL,
CONSTRAINT FK_Exams_Subjects
FOREIGN KEY (SubjectId) REFERENCES Subjects(Id)
)

CREATE TABLE StudentsExams (
StudentId INT NOT NULL,
ExamId INT NOT NULL,
Grade DECIMAL(3, 2) NOT NULL,
CHECK (Grade BETWEEN 2 AND 6),
CONSTRAINT PK_StudentsExams
PRIMARY KEY (StudentId, ExamId),
CONSTRAINT FK_StudentsExams_Students
FOREIGN KEY (StudentId) REFERENCES Students(Id),
CONSTRAINT FK_StudentsExams_Exams
FOREIGN KEY (ExamId) REFERENCES Exams(Id)
)

CREATE TABLE Teachers (
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(20) NOT NULL,
LastName NVARCHAR(20) NOT NULL,
[Address] NVARCHAR(20) NOT NULL,
Phone CHAR(10),
SubjectId INT NOT NULL,
CONSTRAINT FK_Teachers_Subjects
FOREIGN KEY (SubjectId) REFERENCES Subjects(Id)
)

CREATE TABLE StudentsTeachers (
StudentId INT NOT NULL,
TeacherId INT NOT NULL,
CONSTRAINT PK_StudentsTeachers
PRIMARY KEY (StudentId, TeacherId),
CONSTRAINT FK_StudentsTeachers_Students
FOREIGN KEY (StudentId) REFERENCES Students(Id),
CONSTRAINT FK_StudentsTeachers_Teachers
FOREIGN KEY (TeacherId) REFERENCES Teachers(Id)
)