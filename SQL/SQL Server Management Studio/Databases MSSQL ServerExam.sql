CREATE DATABASE [Airport]

USE [Airport]

--01. DDL
CREATE TABLE [Passengers]
			 (
				[Id] INT PRIMARY KEY IDENTITY,
				[FullName] VARCHAR(100) UNIQUE NOT NULL,
				[Email] VARCHAR(50) UNIQUE NOT NULL
			 )

CREATE TABLE [Pilots]
			 (
				[Id] INT PRIMARY KEY IDENTITY,
				[FirstName] VARCHAR(30) UNIQUE NOT NULL,
				[LastName] VARCHAR(30) UNIQUE NOT NULL,
				[Age] TINYINT CHECK ([Age] >= 21 AND [Age] <= 62) NOT NULL,
				[Rating] FLOAT CHECK ([Rating] >= 0.0 AND [Rating] <= 10.0)
			 )

CREATE TABLE [AircraftTypes]
			 (
				[Id] INT PRIMARY KEY IDENTITY,
				[TypeName] VARCHAR(30) UNIQUE NOT NULL,
			 )

CREATE TABLE [Aircraft]
			 (
				[Id] INT PRIMARY KEY IDENTITY,
				[Manufacturer] VARCHAR(25) NOT NULL,
				[Model] VARCHAR(30) NOT NULL,
				[Year] INT NOT NULL,
				[FlightHours] INT,
				[Condition] CHAR NOT NULL,
				[TypeId] INT FOREIGN KEY REFERENCES [AircraftTypes]([Id]) NOT NULL
			 )

CREATE TABLE [PilotsAircraft]
			 (
				[AircraftId] INT FOREIGN KEY REFERENCES [Aircraft]([Id]),
				[PilotId] INT FOREIGN KEY REFERENCES [Pilots]([Id]),
				PRIMARY KEY ([AircraftId],[PilotId])
			 )

CREATE TABLE [Airports]
			 (
				[Id] INT PRIMARY KEY IDENTITY,
				[AirportName] VARCHAR(70) UNIQUE NOT NULL,
				[Country] VARCHAR(100) UNIQUE NOT NULL,
			 )

CREATE TABLE [FlightDestinations]
			 (
				[Id] INT PRIMARY KEY IDENTITY,
				[AirportId] INT FOREIGN KEY REFERENCES [Airports]([Id]) NOT NULL,
				[Start] DATETIME NOT NULL,
				[AircraftId] INT FOREIGN KEY REFERENCES [Aircraft]([Id]) NOT NULL,
				[PassengerId] INT FOREIGN KEY REFERENCES [Passengers]([Id]) NOT NULL,
				[TicketPrice] DECIMAL(18,2) DEFAULT 15 NOT NULL
			 )

--02. Insert
INSERT INTO [Passengers]([FullName],[Email])
SELECT [FirstName]+' '+[LastName]
    AS [FullName],
		[FirstName]+[LastName]+'@gmail.com'
	AS [Email]
  FROM [Pilots]
 WHERE [Id] BETWEEN 5 AND 15
 
 --03. Update

   UPDATE [Aircraft]
	  SET [Condition] = 'A'
    WHERE ([Condition] = 'B' OR [Condition] = 'C') AND
	      ([FlightHours] IS NULL OR [FlightHours] <= 100) AND 
	      [Year] >= 2013

--04. Delete

DELETE  FROM [Passengers] WHERE LEN([FullName]) <= 10

--05. Aircraft

   SELECT [Manufacturer],[Model],[FlightHours],[Condition]
     FROM [Aircraft]
 ORDER BY [FlightHours] DESC

 --06. Pilots and Aircraft

    SELECT [p].[FirstName],[p].[LastName],[a].[Manufacturer],[a].[Model],[a].[FlightHours]
	  FROM [Pilots]
	    AS [p]
	  JOIN [PilotsAircraft]
	    AS [pa]
		ON [p].[Id] = [pa].[PilotId]
	  JOIN [Aircraft]
	    AS [a]
		ON [pa].[AircraftId] = [a].[Id]
	 WHERE ([a].[FlightHours] = NULL) OR ([a].[FlightHours] <= 304)
  ORDER BY [a].[FlightHours] DESC , [p].[FirstName] ASC

--07. Top 20 Flight Destinations

    SELECT 
	   TOP (20)[fd].[Id]
	    AS [DestinationId],
		   [fd].[Start],
		   [p].[FullName],
		   [a].[AirportName],
		   [fd].[TicketPrice]
	  FROM [FlightDestinations]
	    AS [fd]
      JOIN [Passengers]
	    AS [p]
		ON [fd].[PassengerId] = [p].[Id]
      JOIN [Airports]
	    AS [a]
		ON [fd].[AirportId] = [a].[Id]
	 WHERE DAY([fd].[Start]) % 2 = 0
  ORDER BY [fd].[TicketPrice] DESC, [a].[AirportName] ASC

--08. Number of Flights for Each Aircraft 

   SELECT [a].[Id],[a].[Manufacturer],[a].[FlightHours], 
    COUNT ([fd].[AircraftId]) 
	   AS [FlightDestinationsCount],
	  ROUND(AVG ([fd].[TicketPrice]),2)
	   AS [AvgPrice]
     FROM [Aircraft]
	   AS [a]
	 JOIN [FlightDestinations]
	   AS [fd]
	   ON [a].[Id] = [fd].[AircraftId]
 GROUP BY [a].[Id],[a].[Manufacturer],[a].[FlightHours]
   HAVING COUNT ([fd].[AircraftId]) >= 2
 ORDER BY COUNT ([fd].[AircraftId]) DESC, [a].[Id] ASC

 --09. Regular Passengers

   SELECT [p].[FullName], COUNT([fd].[PassengerId]),SUM([fd].[TicketPrice])
     FROM [Passengers]
	   AS [p]
	 JOIN [FlightDestinations]
	   AS [fd]
	   ON [p].[Id] = [fd].[PassengerId]
    WHERE SUBSTRING([p].[FullName],2,1) = 'a'
 GROUP BY [p].[FullName]
   HAVING COUNT([fd].[PassengerId]) > 1
 ORDER BY [p].[FullName]

 --10. Full Info for Flight Destinations


   SELECT [a].[AirportName],
          [fd].[Start],
		  [fd].[TicketPrice],
		  [p].[FullName],
		  [ar].[Manufacturer],
		  [ar].[Model]
     FROM [Airports]
	   AS [a]
	 JOIN [FlightDestinations]
	   AS [fd]
	   ON [a].[Id] = [fd].[AirportId]
	 JOIN [Passengers]
	   AS [p]
	   ON [p].[Id] = [fd].[PassengerId]
	 JOIN [Aircraft]
	   AS [ar]
	   ON [ar].[Id] = [fd]. [AircraftId]
    WHERE (CAST([fd].[Start] AS TIME) BETWEEN '06:00' AND '20:00') AND
		  [fd].[TicketPrice] > 2500
 ORDER BY [ar].[Model] ASC

 --11.Find all Destinations by Email Address
 GO
 CREATE FUNCTION udf_FlightDestinationsByEmail (@email VARCHAR(50))
         RETURNS INT
		   BEGIN
				DECLARE @id INT
				SET @id = (SELECT [Id]
						    FROM [Passengers]
                           WHERE [Email]  = @email)
				DECLARE @result INT
				SET @result =	(SELECT COUNT(*)
					            FROM [FlightDestinations]
                               WHERE [PassengerId] = @id)
				RETURN @result
		     END
GO

SELECT dbo.udf_FlightDestinationsByEmail ('PierretteDunmuir@gmail.com')
SELECT dbo.udf_FlightDestinationsByEmail('Montacute@gmail.com')			
SELECT dbo.udf_FlightDestinationsByEmail('MerisShale@gmail.com')
GO
-- 12.Full Info for Airports
CREATE PROC usp_SearchByAirportName  (@airportName VARCHAR(70))
         AS 
	  BEGIN
			SELECT [a].[AirportName],[p].[FullName],CASE
		WHEN([fd].[TicketPrice] <= 400) THEN 'Low'
		WHEN([fd].[TicketPrice] > 400 AND [fd].[TicketPrice] <=1500) THEN 'Medium'
		ELSE 'High'
		END
		AS [LevelOfTickerPrice],
		[ac].[Manufacturer],
		[ac].[Condition],
		[at].[TypeName]
  FROM [FlightDestinations]
    AS [fd]
  JOIN [Airports]
    AS [a]
	ON [a].[Id] = [fd].[AirportId]
  JOIN [Aircraft]
    AS [ac]
	ON [fd].[AircraftId] = [ac].[Id]
  JOIN [Passengers]
    AS [p]
	ON [p].[Id] = [fd].[PassengerId]
  JOIN [AircraftTypes]
    AS [at]
	ON [at].[Id] = [ac].TypeId
 WHERE [a].AirportName = @airportName
 ORDER BY [ac].[Manufacturer] ASC,[p].[FullName]
	    END
GO

EXEC usp_SearchByAirportName 'Sir Seretse Khama International Airport'

