CREATE DATABASE Tutorial
GO

USE Tutorial
GO

CREATE SCHEMA TutorialAppSchema
GO

CREATE TABLE TutorialAppSchema.Computer
(
	ComputerId INT IDENTITY(1,1) PRIMARY KEY -- auto incrementing id starting at 1 by 1
	, Motherboard NVARCHAR(50) -- CHAR vs VARCHAR vs NVARCHAR (non-unicode), VARCHAR saves more space
	, CPUCores INT
	, HasWifi BIT -- Boolean
	, HasLTE BIT
	, ReleaseDate DATETIME
	, Price DECIMAL(18,4) -- FLOAT vs DOUBLE
	, VideoCard NVARCHAR(50)
)

-- ALTER TABLE TutorialAppSchema.Computer
-- ADD ReleaseDate DATETIME; -- datetime2, takes up more space but more accurate

SELECT * FROM TutorialAppSchema.Computer

-- SET IDENTITY_INSERT TutorialAppSchema.Computer ON

INSERT INTO TutorialAppSchema.Computer (
	[CPUCores],
	[Motherboard],
	[HasWifi],
	[HasLTE],
	[ReleaseDate],
	[Price],
	[VideoCard]
) VALUES (
	'Sample-Motherboard',
	4,
	1,
	0,
	'2022-01-01',
	1000,
	'Sample-Videocard'
);

DELETE FROM TutorialAppSchema.Computer WHERE ComputerId = 3;

UPDATE TutorialAppSchema.Computer SET CPUCores = 4; -- set to every single row, or append WHERE ComputerId = 2;
-- WHERE ReleaseDate < '2017-01-01';

SELECT *, ISNULL([CPUCores], 4) AS CPUCores FROM TutorialAppSchema.Computer; -- default value if CPUCores is null, also provide an alias

SELECT [Motherboard],
	[CPUCores],
	[HasWifi],
	[HasLTE],
	[ReleaseDate],
	[Price],
	[VideoCard]
FROM TutorialAppSchema.Computer
ORDER BY HasWifi DESC, ReleaseDATE DESC