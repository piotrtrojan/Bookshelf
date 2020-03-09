SET IDENTITY_INSERT [dbo].[Books] ON 

INSERT [dbo].[Books] 
	([Id], [CreationDate], [ModificationDate], [IsActive], [DeletedAt], [AuthorId], [Title], [Pages], [MaxLoanDays])
VALUES 
	(1, SYSDATETIME(), NULL, 1, NULL, 1, N'Pan Tadeusz', 123, NULL),
	(2, SYSDATETIME(), NULL, 1, NULL, 1, N'Sonety Krymskie', 120, NULL),
	(3, SYSDATETIME(), NULL, 1, NULL, 1, N'Konrad Wallenrod', 80, NULL),
	(4, SYSDATETIME(), NULL, 1, NULL, 2, N'Kordian', 240, NULL),
	(5, SYSDATETIME(), NULL, 1, NULL, 2, N'Balladyna', 74, NULL),
	(6, SYSDATETIME(), NULL, 1, NULL, 1, N'Romantyczność', 10, NULL),
	(7, SYSDATETIME(), NULL, 1, NULL, 1, N'Świteź', 10, NULL),
	(8, SYSDATETIME(), NULL, 1, NULL, 1, N'Świtezianka', 15, NULL),
	(9, SYSDATETIME(), NULL, 1, NULL, 1, N'Grażyna', 20, NULL),
	(10, SYSDATETIME(), NULL, 1, NULL, 1, N'Oda do młodości', 1, NULL),
	(11, SYSDATETIME(), NULL, 1, NULL, 1, N'Do Matki Polki', 1, NULL),
	(12, SYSDATETIME(), NULL, 1, NULL, 1, N'Ryduta Ordona', 1, NULL),
	(13, SYSDATETIME(), NULL, 1, NULL, 1, N'Zima miejska', 1, NULL),
	(14, SYSDATETIME(), NULL, 1, NULL, 1, N'Farys', 13, NULL),
	(15, SYSDATETIME(), NULL, 1, NULL, 1, N'Polały się łzy', 15, NULL),
	(16, SYSDATETIME(), NULL, 1, NULL, 1, N'Konfederaci barscy', 19, NULL)


SET IDENTITY_INSERT [dbo].[Books] OFF
