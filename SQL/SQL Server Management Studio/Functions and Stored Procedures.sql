--02. Employees with Salary Above Number
CREATE PROC usp_GetEmployeesSalaryAboveNumber (@Num DECIMAL(18,4))
         AS
      BEGIN
			SELECT [FirstName],[LastName]
			  FROM [Employees]
			 WHERE [Salary] >= @Num
		END

EXEC [dbo].[usp_GetEmployeesSalaryAboveNumber] 48100;
GO
--03. Town Names Starting With
CREATE PROC usp_GetTownsStartingWith (@Letter NVARCHAR(50))
         AS 
	  BEGIN
			SELECT [Name]
				AS [Town]
			  FROM [Towns]
			 WHERE LEFT([Name],  LEN(@Letter)) = @Letter
		END
EXEC [dbo].[usp_GetTownsStartingWith] b;
GO
--04. Employees from Town

CREATE PROC [usp_GetEmployeesFromTown] @Town NVARCHAR(50)
         AS
	  BEGIN
			SELECT [e].[FirstName], [e].[LastName]
			  FROM [Employees] 
			    AS [e]
			  JOIN [Addresses]
			    AS [a]
				ON [e].[AddressID]=[a].[AddressID]
			  JOIN [Towns]
			    AS [t]
				ON [a].[TownID]=[t].[TownID]
			 WHERE [t].[Name] = @Town
		END
EXEC [dbo].[usp_GetEmployeesFromTown] Sofia;
GO
--05. Salary Level Function 
  CREATE FUNCTION ufn_GetSalaryLevel (@Salary MONEY)        
RETURNS  NVARCHAR(10)
	           AS
            BEGIN
					DECLARE @salaryLevel VARCHAR(10)
					IF(@Salary < 30000)
						SET @salaryLevel = 'Low'
					ELSE IF(@Salary <= 50000)
						SET @salaryLevel = 'Average'
					ELSE
						SET @salaryLevel = 'High'
					 RETURN @salaryLevel
   
			 END

SELECT *,[dbo].[ufn_GetSalaryLevel]([Salary])
  FROM [Employees]
GO
--06. Employees by Salary Level
CREATE PROC [usp_EmployeesBySalaryLevel] @LevelSalary NVARCHAR(10)
         AS
	  BEGIN
			SELECT [FirstName],[LastName]
			  FROM [Employees]
			 WHERE [dbo].[ufn_GetSalaryLevel]([Salary]) = @LevelSalary
	    END

EXEC [dbo].[usp_EmployeesBySalaryLevel] high;
GO

--07. Define Function

CREATE FUNCTION ufn_IsWordComprised (@setOfLetters NVARCHAR(50),  @word NVARCHAR(50))
    RETURNS BIT 
             AS
		  BEGIN
				DECLARE @wordIndex INT = 1;
				  WHILE (@wordIndex <= LEN(@word))
				  BEGIN
						DECLARE @currentCharacter CHAR = SUBSTRING (@word,@wordIndex,1);
						     IF CHARINDEX(@currentCharacter,@setOfLetters) = 0
						  BEGIN 
								RETURN 0;
							END
							SET @wordIndex += 1;
				    END
					RETURN 1;
		    END
GO
SELECT [dbo].[ufn_IsWordComprised]('oistmiahf','halves')
GO
--08. *Delete Employees and Departments
CREATE PROC [usp_DeleteEmployeesFromDepartment] (@departmentId INT)
         AS
	  BEGIN 
		   DECLARE @employeesToDelete TABLE ([Id]INT)
	   INSERT INTO @employeesToDelete
		    SELECT [EmployeeID]
			  FROM [Employees]
			 WHERE [DepartmentID] = @departmentId

			DELETE 
			  FROM [EmployeesProjects]
			 WHERE [EmployeeID] IN (SELECT * FROM @employeesToDelete)

			ALTER TABLE [Departments]
			ALTER COLUMN [ManagerID] INT NULL;

			UPDATE [Departments]
			   SET [ManagerID] = NULL
			 WHERE [ManagerID] IN (SELECT * FROM @employeesToDelete)

			UPDATE [Employees]
			   SET [ManagerID] = NULL
			 WHERE [ManagerID] IN (SELECT * FROM @employeesToDelete)


			 DELETE 
			  FROM [Employees]
			 WHERE [DepartmentID] = @departmentId

			DELETE 
			  FROM [Departments]
			 WHERE @departmentId = [DepartmentID]
			 

			SELECT COUNT(*)
			  FROM [Employees]
			 WHERE [DepartmentID] = @departmentId
	    END
GO
EXEC [dbo].[usp_DeleteEmployeesFromDepartment] 1

--09. Find Full Name
CREATE PROC usp_GetHoldersFullName
         AS
	  BEGIN
			SELECT [FirstName]+' '+[LastName] 
			    AS [Full Name]
			  FROM [AccountHolders]
	    END
EXEC dbo.usp_GetHoldersFullName
--10. People with Balance Higher Than 
GO

CREATE PROC [usp_GetHoldersWithBalanceHigherThan] @Number MONEY
    AS
 BEGIN
	SELECT [FirstName],[LastName]
	  FROM [AccountHolders]
		AS [ah]
	  JOIN [Accounts]
		AS [a]
		ON [ah].[Id] = [a].[AccountHolderId]
  GROUP BY [FirstName],[LastName]
    HAVING SUM([Balance]) > @Number
  ORDER BY [FirstName],[LastName]
  END
  GO
  --11. Future Value Function
        CREATE FUNCTION [ufn_CalculateFutureValue] (@sum DECIMAL, @rate FLOAT,@years INT)
		RETURNS MONEY
		             AS
					 BEGIN
						DECLARE @total MONEY
						SET @total = @sum*(POWER(@rate+1,@years))
						RETURN @total
					   END
SELECT dbo.ufn_CalculateFutureValue(1000, 0.10, 5)
