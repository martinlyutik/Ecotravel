SELECT * FROM Users

CREATE TABLE Managers
(
	id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	fio VARCHAR(150) NOT NULL,
	number VARCHAR(50) NOT NULL,
	email VARCHAR(50) NOT NULL,
	loginn VARCHAR(50) NOT NULL,
	passwrd VARCHAR(50) NOT NULL
)

DROP TABLE Managers

CREATE TABLE Country
(
	id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	namme VARCHAR(50) NOT NULL,
	visayn VARCHAR(50) NOT NULL
)

INSERT INTO Country
(namme, visayn)
VALUES
('Болгария','Да'),
('Казахстан','Нет'),
('Швеция','Да')

INSERT INTO City
(id_country, namme)
VALUES
('2','Абай'),
('2','Акколь'),
('1','София'),
('1','Варна'),
('3','Гренна')

SELECT * FROM Country

UPDATE Country SET namme = 'Венгрия' WHERE id = 6

CREATE TABLE City
(
	id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	id_country INT NOT NULL,
	namme VARCHAR(50) NOT NULL,
	FOREIGN KEY (id_country) REFERENCES Country (id) ON DELETE CASCADE
)

DROP TABLE City

DROP TABLE Country

CREATE TABLE Vid
(
	id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	namme VARCHAR(50)
)

INSERT INTO Vid
(namme)
VALUES
('Отель'),
('Хостел'),
('Апартаменты')

CREATE TABLE Typpe
(
	id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	namme VARCHAR(50) NOT NULL
)

INSERT INTO Typpe
(namme)
VALUES
('Путешествие'),
('Оздоровление'),
('Гастрономический интерес')

CREATE TABLE Vid_Transp
(
	id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	namme VARCHAR(50) NOT NULL
)

INSERT INTO Vid_Transp
(namme)
VALUES
('Автобус'),
('Троллейбус'),
('Трамвай'),
('Метро'),
('Такси'),
('Поезд'),
('Каршеринг')

DROP TABLE Vid_Transp

DROP TABLE Cost_Transp

CREATE TABLE Cost_Transp
(
	cost INT NOT NULL,
	service_level VARCHAR(50) NOT NULL,
	id_vid_transp INT NOT NULL,
	id_city INT NOT NULL,
	FOREIGN KEY (id_vid_transp) REFERENCES Vid_Transp (id) ON DELETE CASCADE,
	FOREIGN KEY (id_city) REFERENCES City (id) ON DELETE CASCADE
)

DROP TABLE Cost_Transp

INSERT INTO Cost_Transp
(cost, service_level, id_vid_transp, id_city)
VALUES
('5','3/5','1','1'),
('5','3/5','2','1'),
('5','3/5','3','1'),
('2','3/5','1','2'),
('3','3/5','1','3')

CREATE TABLE Razmesch
(
	id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	namme VARCHAR(50) NOT NULL,
	adress VARCHAR(50) NOT NULL,
	service_level VARCHAR(50) NOT NULL,
	cost_per_day INT NOT NULL,
	id_vid INT NOT NULL,
	id_city INT NOT NULL,
	FOREIGN KEY (id_vid) REFERENCES Vid(id) ON DELETE CASCADE,
	FOREIGN KEY (id_city) REFERENCES City(id) ON DELETE CASCADE
)

DROP TABLE Razmesch

INSERT INTO Razmesch
(namme, adress, service_level, cost_per_day, id_vid, id_city)
VALUES
('Отель Элеон','Красноармейская 4','Все включено','300','1','1'),
('Хостел Швеция','Швицлиан 34','Койко-место','20','2','5'),
('Отель Звезда','Нечипоренко 8','Завтраки','90','1','2'),
('Квартира 8','Постбулг 14','Самообслуживание','100','3','4')

CREATE TABLE ticket
(
	id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	id_city INT NOT NULL,
	id_vid INT NOT NULL,
	id_vid_transp INT NOT NULL,
	id_typpe INT NOT NULL,
	date_podachi VARCHAR(50) NOT NULL,
	date_start VARCHAR(50) NOT NULL,
	day_count INT NOT NULL,
	putevka_count INT NOT NULL,
	statuss VARCHAR(50),
	id_user INT NOT NULL,
	FOREIGN KEY (id_city) REFERENCES City(id) ON DELETE CASCADE,
	FOREIGN KEY (id_vid) REFERENCES Vid(id) ON DELETE CASCADE,
	FOREIGN KEY (id_vid_transp) REFERENCES Vid_Transp(id) ON DELETE CASCADE,
	FOREIGN KEY (id_typpe) REFERENCES Typpe(id) ON DELETE CASCADE,
	FOREIGN KEY (id_user) REFERENCES Users(id) ON DELETE CASCADE
)

DROP TABLE ticket

DROP TABLE Vid

DROP TABLE Vid_Transp

DROP TABLE Typpe

DROP TABLE Country

DROP TABLE City

CREATE TABLE Obrasch
(
	id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	date_time DATETIME NOT NULL,
	textt TEXT NOT NULL,
	obr_type VARCHAR(50) NOT NULL,
	comment TEXT NOT NULL,
	prefered_tour TEXT NOT NULL,
	id_user INT NOT NULL,
	id_mng INT NOT NULL,
	FOREIGN KEY (id_user) REFERENCES Users(id) ON DELETE CASCADE,
	FOREIGN KEY (id_mng) REFERENCES Managers(id) ON DELETE CASCADE
)

DROP TABLE Obrasch