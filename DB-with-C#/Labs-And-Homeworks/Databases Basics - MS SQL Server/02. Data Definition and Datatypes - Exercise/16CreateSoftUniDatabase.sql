CREATE TABLE Towns (
  Id INT PRIMARY KEY IDENTITY,
  [Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Addresses (
  Id INT PRIMARY KEY IDENTITY,
  AddressText NVARCHAR(50) NOT NULL,
  TownId INT FOREIGN KEY REFERENCES Towns(Id)
)

CREATE TABLE Departments (
  Id INT PRIMARY KEY IDENTITY,
  [Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Employees (
  Id INT PRIMARY KEY IDENTITY,
  FirstName NVARCHAR(30) NOT NULL,
  MiddleName NVARCHAR(30) NOT NULL,
  LastName NVARCHAR(30) NOT NULL,
  JobTitle NVARCHAR(30) NOT NULL,
  DepartmentId INT FOREIGN KEY REFERENCES DEPARTMENTS(Id),
  HireDate DATE NOT NULL,
  Salary DECIMAL(10, 4) NOT NULL,
  AddressId INT FOREIGN KEY REFERENCES Addresses(Id)
)