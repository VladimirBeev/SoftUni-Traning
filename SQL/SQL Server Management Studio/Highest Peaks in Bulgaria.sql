SELECT mc.CountryCode,m.MountainRange,p.PeakName,p.Elevation
FROM [MountainsCountries] AS mc
JOIN [Mountains] AS m ON m.Id = mc.MountainId AND mc.CountryCode = 'BG'
JOIN [Peaks] AS p ON (m.Id = p.MountainId AND p.Elevation > 2835)
ORDER BY p.Elevation DESC