CREATE TABLE Students (
StudentID INT PRIMARY KEY,
Name NVARCHAR(20))

INSERT INTO Students (StudentID,Name)
VALUES
(1,'Mila'),
(2,'Toni'),
(3,'Ron')

CREATE TABLE Exams (
ExamID INT PRIMARY KEY,
Name NVARCHAR(20))

INSERT INTO Exams (ExamID,Name)
VALUES
(101,'SpringMVC'),
(102,'Neo4j'),
(103,'Oracle 11g')

CREATE TABLE StudentsExams (
StudentID INT PRIMARY KEY
ExamID INT)

ALTER TABLE StudentsExams
ADD CONSTRAINT FK_StudentsExams_Exams
FOREIGN KEY (ExamID)
REFERENCES Exams(ExamID)