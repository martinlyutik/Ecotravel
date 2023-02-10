CREATE TABLE Users
(
	id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	namme VARCHAR(50) NOT NULL,
	surname VARCHAR(50) NOT NULL,
	otch VARCHAR(50) NOT NULL,
	passport VARCHAR(50) NOT NULL,
	visa VARCHAR(50) NOT NULL,
	email VARcHAR(50) NOT NULL,
	number VARCHAR(50) NOT NULL,
	passwrd VARCHAR(50) NOT NULL
)

DROP TABLE Users

SELECT * FROM Users

INSERT INTO Users
(namme, surname, otch, passport, visa, email, number, passwrd)
VALUES
('admin','admin','admin','admin','admin','admin','admin','admin')