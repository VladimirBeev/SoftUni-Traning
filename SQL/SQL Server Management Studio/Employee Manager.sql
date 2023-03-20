    SELECT e.EmployeeID,e.FirstName,e.ManagerID,d.[FirstName] AS [ManagerName]
	  FROM [Employees] AS e
	  JOIN [Employees] AS d ON e.ManagerID = d.EmployeeID
	 WHERE e.[ManagerID] IN (3,7)
	 ORDER BY e.[EmployeeID]