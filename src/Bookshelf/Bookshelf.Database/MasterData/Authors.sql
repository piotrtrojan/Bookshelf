SET IDENTITY_INSERT [dbo].[Authors] ON 

INSERT [dbo].[Authors] 
	([Id], [CreationDate], [ModificationDate], [IsActive], [DeletedAt], [FirstName], [LastName], [NationalityId]) 
VALUES 
	(1, SYSDATETIME(), NULL, 1, NULL, N'Adam', N'Mickiewicz', 1),
	(2, SYSDATETIME(), NULL, 1, NULL, N'Juliusz', N'Słowacki', 1),
	(3, SYSDATETIME(), NULL, 1, NULL, N'Cyprian Kamil', N'Norwid', 1),
	(4, SYSDATETIME(), NULL, 1, NULL, N'Andrzej', N'Sapkowski', 1)

SET IDENTITY_INSERT [dbo].[Authors] OFF
