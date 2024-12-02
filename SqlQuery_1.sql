CREATE DATABASE MediaLabDB;
GO

USE MediaLabDB;

CREATE TABLE [dbo].[Movies]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY,
	[Title] NVARCHAR(100) NOT NULL,
	[Director] NVARCHAR(100) NOT NULL,
	[Length] INT NOT NULL,
);

GO
CREATE TABLE [dbo].[Books]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY,
	[Title] NVARCHAR(100) NOT NULL,
	[Author] NVARCHAR(100) NOT NULL,
	[Pages] INT NOT NULL,
);
GO

INSERT INTO 
	[dbo].[Movies] ([Title], [Director], [Length]) 
VALUES 
	(N'Inception', N'Christopher Nolan', 148),
	(N'Interstellar', N'Christopher Nolan', 169),
	(N'Pulp Fiction', N'Quentin Tarantino', 154),
	(N'Fight Club', N'David Fincher', 139),
	(N'Forrest Gump', N'Robert Zemeckis', 142);

INSERT INTO 
	[dbo].[Books] ([Title], [Author], [Pages])
VALUES
	(N'Harry Potter and the Philosopher''s Stone', N'J.K. Rowling', 223),
	(N'Harry Potter and the Chamber of Secrets', N'J.K. Rowling', 251),
	(N'Harry Potter and the Prisoner of Azkaban', N'J.K. Rowling', 317),
	(N'Harry Potter and the Goblet of Fire', N'J.K. Rowling', 636),
	(N'Harry Potter and the Order of the Phoenix', N'J.K. Rowling', 766);

