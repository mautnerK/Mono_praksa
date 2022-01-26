CREATE TABLE Student(
	Id INT PRIMARY KEY,
	Name VARCHAR(20),
	Surname VARCHAR(30),
	Address VARCHAR(30),	
)


CREATE TABLE College(
	Id INT,
	Name VARCHAR(50),
	Address VARCHAR(50)
	PRIMARY KEY(Id),
	StudentId INT FOREIGN KEY REFERENCES Student(Id)
)



INSERT INTO Student(Id,Name,Surname,Address) VALUES (1,'Karlo','Mautner','Vukovarska142');
INSERT INTO Student(Id,Name,Surname,Address) VALUES (2,'Zvonimir','Pajeska','Zagrebacka1');
INSERT INTO Student(Id,Name,Surname,Address) VALUES (3,'Filip','Mautner','Istarska13');
INSERT INTO Student(Id,Name,Surname,Address) VALUES (4,'Marko','Gotovac','Sveara3');

INSERT INTO College(Id,Name,Address,StudentId) VALUES (1,'FERIT','Trpimirova',1);
INSERT INTO College(Id,Name,Address,StudentId) VALUES (2,'MATHOS','Strossmayera',2);
INSERT INTO College(Id,Name,Address,StudentId) VALUES (3,'PRAVOS','Radica',3);


SELECT * FROM Student;
SELECT * FROM College;

