CREATE TABLE [Directors](
	[Id] INT PRIMARY KEY,
	[DirectorName] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(MAX)
)

INSERT INTO	[Directors]([Id],[DirectorName])
	VALUES	(1,'Alfred Hitchcock'),
			(2,'Orson Welles'),
			(3,'John Ford'),
			(4,'Howard Hawks'),
			(5,'Martin Scorsese')

CREATE TABLE [Genres](
	[Id] INT PRIMARY KEY,
	[GenreName] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(MAX)
)

INSERT INTO [Genres]([Id],[GenreName])
	VALUES	(1,'Action'),
			(2,'Comedy'),
			(3,'Documentary'),
			(4,'Drama'),
			(5,'Fantasy')

CREATE TABLE [Categories](
	[Id] INT PRIMARY KEY,
	[CategoryName] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(MAX)
)

INSERT INTO [Categories]([Id],[CategoryName])
	VALUES	(1,'monochrome negative'),
			(2,'monochrome transparency'),
			(3,'colour negative'),
			(4,'colour transparency'),
			(5,'hubav film')

CREATE TABLE [Movies](
	[Id] INT PRIMARY KEY,
	[Title] NVARCHAR(50) NOT NULL,
	[DirectorId] INT NOT NULL,
	[CopyrightYear] INT NOT NULL,
	[Length] TIME NOT NULL,
	[GenreId] INT NOT NULL,
	[CategoryId]INT NOT NULL,
	[Rating] INT,
	[Notes] NVARCHAR(MAX)
)

INSERT INTO [Movies] ([Id],[Title],[DirectorId],[CopyrightYear],[Length],[GenreId],[CategoryId])
	VALUES	(1,'Psycho',1,1960,'01:49:00',3,1),
			(2,'Scarface',4,1983,'02:50:00',1,4),
			(3,'The Aviator',5,2004,'02:50:00',4,4),
			(4,'Goodfellas',5,1990,'02:25:00',4,4),
			(5,'The Wolf of Wall Street',5,2013,'03:00:00',4,4)