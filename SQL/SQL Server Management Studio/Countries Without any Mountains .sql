    SELECT COUNT(*)AS [Count]
      FROM [Countries] AS e
 LEFT JOIN [MountainsCountries] AS mc
        ON e.CountryCode = mc.CountryCode
	 WHERE mc.MountainId IS NULL
