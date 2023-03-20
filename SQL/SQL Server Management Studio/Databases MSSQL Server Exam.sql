CREATE DATABASE NationalTouristSitesOfBulgaria

USE NationalTouristSitesOfBulgaria

--01. DDL
CREATE TABLE [Categories]
			 (
				[Id] INT PRIMARY KEY IDENTITY,
				[Name] VARCHAR(50) NOT NULL
			 )

CREATE TABLE [Locations]
			 (
				[Id] INT PRIMARY KEY IDENTITY,
				[Name] VARCHAR(50) NOT NULL,
				[Municipality] VARCHAR(50),
				[Province] VARCHAR(50)
			 )

CREATE TABLE [Sites]
			 (
				[Id] INT PRIMARY KEY IDENTITY,
				[Name] VARCHAR(100) NOT NULL,
				[LocationId] INT FOREIGN KEY REFERENCES [Locations](Id) NOT NULL,
				[CategoryId] INT FOREIGN KEY REFERENCES [Categories](Id) NOT NULL,
				[Establishment] VARCHAR(15)
			 )

CREATE TABLE [Tourists]
			 (
				[Id] INT PRIMARY KEY IDENTITY,
				[Name] VARCHAR(50) NOT NULL,
				[Age] INT CHECK ([Age] >= 0 AND [Age] <= 120) NOT NULL,
				[PhoneNumber] VARCHAR(20) NOT NULL,
				[Nationality] VARCHAR(30) NOT NULL,
				[Reward] VARCHAR(20)
			 )

CREATE TABLE [SitesTourists]
			 (
				[TouristId] INT FOREIGN KEY REFERENCES [Tourists](Id) NOT NULL,
				[SiteId] INT FOREIGN KEY REFERENCES [Sites](Id) NOT NULL,
				PRIMARY KEY ([TouristId],[SiteId])
			 )

CREATE TABLE [BonusPrizes]
			 (
				[Id] INT PRIMARY KEY IDENTITY,
				[Name] VARCHAR(50) NOT NULL
			 )

CREATE TABLE [TouristsBonusPrizes]
			 (
				[TouristId] INT FOREIGN KEY REFERENCES [Tourists](Id) NOT NULL,
				[BonusPrizeId] INT FOREIGN KEY REFERENCES [BonusPrizes](Id) NOT NULL,
				PRIMARY KEY ([TouristId],[BonusPrizeId])
			 )

--02. Insert

INSERT INTO [Tourists] ([Name], [Age], [PhoneNumber], [Nationality], [Reward])
     VALUES	('Borislava Kazakova', 52, '+359896354244', 'Bulgaria', NULL),
		    ('Peter Bosh', 48, '+447911844141', 'UK', NULL),
			('Martin Smith', 29, '+353863818592', 'Ireland', 'Bronze badge'),
			('Svilen Dobrev', 49, '+359986584786', 'Bulgaria', 'Silver badge'),
			('Kremena Popova', 38, '+359893298604', 'Bulgaria', NULL)

INSERT INTO [Sites] ([Name], [LocationId], [CategoryId], [Establishment])
     VALUES	('Ustra fortress', 90, 7, 'X'),
		    ('Karlanovo Pyramids', 65, 7, NULL),
			('The Tomb of Tsar Sevt', 63, 8, 'V BC'),
			('Sinite Kamani Natural Park', 17, 1, NULL),
			('St. Petka of Bulgaria – Rupite', 92, 6, '1994')

--03. Update

UPDATE [Sites]
SET [Establishment] = '(not defined)'
WHERE [Establishment] IS NULL

--04. Delete

DELETE FROM [TouristsBonusPrizes] WHERE [BonusPrizeId] = (SELECT [Id] FROM [BonusPrizes] WHERE [Name] = 'Sleeping bag')
DELETE FROM [BonusPrizes] WHERE [Name] = 'Sleeping bag'

--05. Tourists

   SELECT [Name],[Age],[PhoneNumber],[Nationality]
     FROM [Tourists]
 ORDER BY [Nationality] ASC, [Age] DESC, [Name] ASC

 --06. Sites with Their Location and Category

	 SELECT [s].[Name],[l].[Name],[s].Establishment,[c].[Name]
	   FROM [Sites]
		 AS [s]
	   JOIN [Locations]
		 AS [l]
		 ON [s].[LocationId] = [l].[Id]
	   JOIN [Categories]
		 AS [c]
		 ON [s].[CategoryId] = [c].Id
   ORDER BY [c].[Name] DESC, [l].[Name] ASC, [s].[Name] ASC

--07. Count of Sites in Sofia Province

   SELECT [Id]
     FROM [Locations]
	WHERE [Province] = 'Sofia'

	SELECT [l].[Province],[l].[Municipality],[l].[Name],COUNT(*) 
	    AS [CountOfSites]
	  FROM [Sites]
	    AS [s]
	 JOIN [Locations]
	   AS [l]
	   ON [s].[LocationId] = [l].[Id]
    WHERE [s].[LocationId] IN (SELECT [Id]
								 FROM [Locations]
	                            WHERE [Province] = 'Sofia'
							   )
GROUP BY [l].[Province],[l].[Municipality],[l].[Name]
ORDER BY COUNT(*) DESC, [l].[Name]

--08. Tourist Sites established BC

   SELECT [s].[Name],[l].[Name],[l].[Municipality],[l].[Province],[s].[Establishment]
     FROM [Sites]
	   AS [s]
	 JOIN [Locations]
	   AS [l]
	   ON [s].[LocationId] = [l].[Id]
    WHERE SUBSTRING([l].[Name], 1, 1) NOT IN ('D','B','M') AND [s].[Establishment] LIKE '%BC%'
 ORDER BY [s].[Name] ASC

 --09. Tourists with their Bonus Prizes

    SELECT [t].[Name],[t].[Age],[t].[PhoneNumber],[t].[Nationality], 
			CASE
				WHEN [tbp].[TouristId] IS NULL THEN '(no bonus prize)'
				ELSE [bp].[Name]
			END
		AS [Reward]
	  FROM [Tourists]
	    AS [t]
 LEFT JOIN [TouristsBonusPrizes]
	    AS [tbp]
		ON [t].[Id] = [tbp].[TouristId]
 LEFT JOIN [BonusPrizes]
	    AS [bp]
		ON [tbp].[BonusPrizeId] = [bp].[Id]
  ORDER BY [t].[Name] ASC

--10. Tourists visiting History & Archaeology sites

    SELECT DISTINCT(SUBSTRING([t].[Name],CHARINDEX(' ',[t].[Name])+1,LEN([t].[Name])))
	    AS [LastName],
		   [t].[Nationality],
		   [t].[Age],
		   [t].[PhoneNumber]
	  FROM [Tourists]
	    AS [t]
      JOIN [SitesTourists]
	    AS [st]
		ON [t].[Id] = [st].[TouristId]
      JOIN [Sites]
	    AS [s]
		ON [st].[SiteId] = [s].[Id]
	  JOIN [Categories]
	    AS [c]
	    ON [s].[CategoryId] = [c].[Id]
     WHERE [s].[CategoryId] = ( SELECT [Id]
	                              FROM [Categories]
								 WHERE [Name] = 'History and archaeology'
							   )
 ORDER BY [LastName] ASC

 --11. Tourists Count on a Tourist Site
 go
 CREATE FUNCTION udf_GetTouristsCountOnATouristSite (@Site VARCHAR(100))
         RETURNS INT
		 BEGIN
			DECLARE @counts INT
			SET @counts = (SELECT COUNT(*)
						   FROM [SitesTourists]
							 AS [st]
						   JOIN [Sites]
							 AS [s]
							 ON [st].[SiteId] = [s].[Id]
						  WHERE [s].[Name] = @Site
						  )
		RETURN @counts
		   END
go
SELECT dbo.udf_GetTouristsCountOnATouristSite ('Regional History Museum – Vratsa')
SELECT dbo.udf_GetTouristsCountOnATouristSite ('Samuil’s Fortress')

--12. Annual Reward Lottery

GO
   CREATE PROC usp_AnnualRewardLottery(@TouristName VARCHAR(50))
            AS
			BEGIN
				DECLARE @countSites INT
				SET @countSites = ( SELECT COUNT(*)
								  FROM [Tourists]
									AS [t]
								  JOIN [SitesTourists]
									AS [st]
									ON [t].[Id] = [st].[TouristId]
								 WHERE [t].[Name] = @TouristName
							   )
				UPDATE [Tourists]
				SET [Reward] = CASE 
							  WHEN @countSites >= 100 THEN 'Gold badge'
							  WHEN @countSites >= 50 THEN 'Silver badge'
							  WHEN @countSites >= 25 THEN 'Bronze badge'
							  ELSE [Reward]
						   END
				WHERE [Name] = @TouristName

				SELECT DISTINCT[Name],[Reward]
				FROM [Tourists]
				WHERE [Name] = @TouristName
			END

			EXEC usp_AnnualRewardLottery 'Gerhild Lutgard'
  --GROUP BY [t].[Name]