CREATE TABLE People
(
  Id INT PRIMARY KEY IDENTITY,
  Name NVARCHAR(200) NOT NULL,
  Picture VARBINARY(max),
  Height REAL,
  Weight REAL,
  Gender CHAR(1) NOT NULL,
  Birthdate DATETIME NOT NULL,
  Biography TEXT
)

INSERT INTO People(Name, Picture, Height, Weight, Gender, Birthdate, Biography) VALUES
('Stanislav', 2000, 1.75, 67, 'm', 1999-30-06, 'Hello, my name is Stanislav'),
('Pesho', 3000, 1.95, 80, 'm', 2000-30-06, 'Hello, my name is Pesho'),
('Maria', 10000, 1.60, 45, 'f', 1997-20-06, 'Hello, my name is Maria'),
('Kiro', 4000, 1.80, 90, 'm', 2003-15-02, 'Hello, my name is Kiro and I am born in Pernik'),
('Lora', 5000, 1.70, 50, 'f', 1999-02-03, 'Hello, my name is Lora and I love Kiro')
