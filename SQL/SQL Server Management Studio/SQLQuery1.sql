CREATE DATABASE CigarShop

USE CigarShop

--DDL
CREATE TABLE [Sizes]
			 (
				[Id] INT PRIMARY KEY IDENTITY,
				[Length] INT CHECK ([Length] >= 10 AND [Length] <= 25) NOT NULL,
				[RingRange] DECIMAL(10,2) CHECK ([RingRange] >= 1.5 AND [RingRange] <= 7.5) NOT NULL,
			 )

CREATE TABLE [Tastes]
			 (
				[Id] INT PRIMARY KEY IDENTITY,
				[TasteType] VARCHAR(20) NOT NULL,
				[TasteStrength] VARCHAR(15) NOT NULL,
				[ImageURL] NVARCHAR(100) NOT NULL,
	   	     )

CREATE TABLE [Brands]
			 (
				[Id] INT PRIMARY KEY IDENTITY,
				[BrandName] VARCHAR(30) UNIQUE NOT NULL,
				[BrandDescription] VARCHAR(MAX)
			 )

CREATE TABLE [Cigars]
			 (
				[Id] INT PRIMARY KEY IDENTITY NOT NULL,
				[CigarName] VARCHAR(80) NOT NULL,
				[BrandId] INT FOREIGN KEY REFERENCES Brands(Id) NOT NULL,
				[TastId] INT FOREIGN KEY REFERENCES Tastes(Id) NOT NULL,
				[SizeId] INT FOREIGN KEY REFERENCES Sizes(Id) NOT NULL,
				[PriceForSingleCigar] MONEY NOT NULL,
				[ImageURL] NVARCHAR(100) NOT NULL
			 )

CREATE TABLE [Addresses]
			 (
				[Id] INT PRIMARY KEY IDENTITY,
				[Town] VARCHAR(30) NOT NULL,
				[Country] NVARCHAR(30) NOT NULL,
				[Streat] NVARCHAR(30) NOT NULL,
				[ZIP] VARCHAR(20) NOT NULL
			 )

CREATE TABLE [Clients]
			 (
				[Id] INT PRIMARY KEY IDENTITY,
				[FirstName] NVARCHAR(30) NOT NULL,
				[LastName] NVARCHAR(30) NOT NULL,
				[Email] NVARCHAR(50) NOT NULL,
				[AddressId] INT FOREIGN KEY REFERENCES Addresses(Id) NOT NULL 
			 )

CREATE TABLE [ClientsCigars]
			 (
				[ClientId] INT FOREIGN KEY REFERENCES Clients(Id) NOT NULL,
				[CigarId] INT FOREIGN KEY REFERENCES Cigars(Id) NOT NULL,
				PRIMARY KEY ([ClientId],[CigarId])
			 )

--02. Insert

INSERT INTO [Cigars]([CigarName],[BrandId],[TastId],[SizeId],[PriceForSingleCigar],[ImageURL])
     VALUES ('COHIBA ROBUSTO',9,1,5,15.50,'cohiba-robusto-stick_18.jpg'),
		    ('COHIBA SIGLO I',9,1,10,410.00,'cohiba-siglo-i-stick_12.jpg'),
			('HOYO DE MONTERREY LE HOYO DU MAIRE',14,5,11,7.50,'hoyo-du-maire-stick_17.jpg'),
			('HOYO DE MONTERREY LE HOYO DE SAN JUAN',14,4,15,32.00,'hoyo-de-san-juan-stick_20.jpg'),
			('TRINIDAD COLONIALES',2,3,8,85.21,'trinidad-coloniales-stick_30.jpg')

INSERT INTO Addresses(Town,Country,Streat,ZIP)
     VALUES ('Sofia','Bulgaria','18 Bul. Vasil levski',1000),
		    ('Athens','Greece','4342 McDonald Avenue',10435),
			('Zagreb','Croatia','4333 Lauren Drive',10000)


--03. Update

   UPDATE [Cigars]
	  SET [PriceForSingleCigar] = (0.2*[PriceForSingleCigar]) + [PriceForSingleCigar]
    WHERE [TastId] = (SELECT [Id]
	                    FROM [Tastes]
						WHERE [TasteType] = 'Spicy')

	UPDATE [Brands]
	   SET [BrandDescription] = 'New description'
	 WHERE [BrandDescription] IS NULL

--04. Delete
DELETE FROM [Clients] WHERE [AddressId] IN (SELECT [Id]
											  FROM [Addresses]
                                             WHERE SUBSTRING([Country],1,1) = 'C')

DELETE FROM [Addresses] WHERE SUBSTRING([Country],1,1) = 'C'


--05. Cigars by Price

  SELECT [CigarName], [PriceForSingleCigar], [ImageURL]
    FROM [Cigars]
ORDER BY [PriceForSingleCigar] ASC, [CigarName] DESC

--06. Cigars by Taste

  SELECT [c].[Id],[c].[CigarName],[c].[PriceForSingleCigar],[t].[TasteType],[t].[TasteStrength]
    FROM [Cigars]
	  AS [c]
    JOIN [Tastes]
	  AS [t]
	  ON [c].[TastId] = [t].[Id]
   WHERE [t].[TasteType] = 'Earthy' OR [t].[TasteType] = 'Woody'
ORDER BY [PriceForSingleCigar] DESC

--07. Clients without Cigars

  SELECT [c].[Id],[c].[FirstName]+' '+[c].[LastName]
      AS [ClientName],[c].[Email]
    FROM [Clients]
	  AS [c]
LEFT JOIN [ClientsCigars]
	  AS [cc]
	  ON [c].[Id] = [cc].[ClientId]
   WHERE [cc].[ClientId] IS NULL
  ORDER BY [ClientName] ASC

--08. First 5 Cigars

ALTER TABLE [Cigars]
ALTER COLUMN [PriceForSingleCigar] DECIMAL(18,2)

ALTER TABLE [Sizes]
ALTER COLUMN [RingRange] DECIMAL(3,2)


   SELECT [c].[CigarName],[c].[PriceForSingleCigar],[c].[ImageURL]
     FROM [Cigars]
	   AS [c]
RIGHT JOIN [Sizes]
	   AS [s]
	   ON [c].[SizeId] = [s].[Id]
    WHERE ([s].[Length] >= 12 AND [c].[CigarName] LIKE '%ci%') 
	   OR ([c].[PriceForSingleCigar] > 50 AND [s].[RingRange] > 2.55)
 ORDER BY [c].[CigarName] ASC, [c].[PriceForSingleCigar] DESC

      SELECT TOP(5)[c].[CigarName],[c].[PriceForSingleCigar],[c].[ImageURL]
        FROM [Sizes]
          AS [s]
        JOIN [Cigars]
	      AS [c]
	      ON [s].[Id] = [c].[SizeId]
       WHERE [s].[Length] >= 12 AND [c].[CigarName] LIKE '%ci%' OR
	         [s].[RingRange] >= 2.55 AND [c].[PriceForSingleCigar] >= 50
    ORDER BY [c].[CigarName] ASC, [c].[PriceForSingleCigar] DESC

--09. Clients with ZIP Codes

   SELECT [c].[FirstName]+' '+[c].[LastName]
      AS [FullName],[a].[Country],[a].[ZIP], CONCAT('$',MAX([cig].[PriceForSingleCigar]))
     FROM [Clients]
	   AS [c]
	 JOIN [Addresses]
	   AS [a]
	   ON [c].[AddressId] = [a].[Id]
	   JOIN [ClientsCigars]
	   AS [cc]
	   ON [c].[Id] = [cc].[ClientId]
	 JOIN [Cigars]
	   AS [cig]
	   ON [cc].[CigarId] = [cig].[Id]
    WHERE [a].[ZIP] NOT LIKE '%[^0-9]%'
 GROUP BY [c].[FirstName],[c].[LastName],[a].[Country],[a].[ZIP]
 ORDER BY [FullName] ASC


--10. Cigars by Size

   SELECT [c].[LastName], AVG([s].[Length])
       AS [CiagrLength], CEILING (AVG([s].[RingRange]))
	   AS [CiagrRingRange]
     FROM [Clients]
	   AS [c]
	 JOIN [ClientsCigars]
	   AS [cc]
	   ON [c].[Id] = [cc].[ClientId]
	 JOIN [Cigars]
	   AS [cig]
	   ON [cc].[CigarId] = [cig].[Id]
	 JOIN [Sizes]
	   AS [s]
	   ON [cig].[SizeId] = [s].[Id]
 GROUP BY [c].[LastName]
 ORDER BY AVG([s].[Length]) DESC



 --11. Client with Cigars
 GO
 CREATE FUNCTION udf_ClientWithCigars(@name NVARCHAR(30))
 RETURNS INT
		   BEGIN
		   DECLARE @result INT
		   SET @result = (SELECT COUNT([cc].[CigarId])
                            FROM  [Clients]
                              AS [c]
                            JOIN [ClientsCigars]
                              AS [cc]
	                          ON [c].[Id] = [cc].[ClientId]
                           WHERE [c].[FirstName] = @name)
			RETURN @result
		   END
GO
SELECT dbo.udf_ClientWithCigars('Betty')

--12. Search for Cigar with Specific Taste
GO
CREATE PROC usp_SearchByTaste(@taste VARCHAR(20))
         AS 
	  BEGIN
			SELECT [c].[CigarName], CONCAT('$',[c].[PriceForSingleCigar])
			    AS [Price], [t].[TasteType],[b].[BrandName], CONCAT([s].[Length], ' cm')
				AS [CigarLength], CONCAT ([s].[RingRange], ' cm')
				AS [CigarRingRange]
              FROM [Cigars]
                AS [c]
              JOIN [Tastes]
                AS [t]
	            ON [c].[TastId] = [t].[Id]
              JOIN [Sizes]
                AS [s]
	            ON [c].[SizeId] = [s].[Id]
			  JOIN [Brands]
			    AS [b]
				ON [c].[BrandId] = [b].[Id]
             WHERE [t].[TasteType] = @taste
          ORDER BY [CigarLength] ASC,[CigarRingRange] DESC
	    END

EXEC usp_SearchByTaste 'Woody'