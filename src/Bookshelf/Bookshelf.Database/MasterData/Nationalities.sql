SET IDENTITY_INSERT [dbo].[Nationalities] ON 

INSERT [dbo].[Nationalities] 
	([Id], [CreationDate], [ModificationDate], [IsActive], [DeletedAt], [Name]) 
VALUES 
	(1, SYSDATETIME(), NULL, 1, NULL, N'Polish'),
	(2, SYSDATETIME(), NULL, 1, NULL, N'English'),
	(3, SYSDATETIME(), NULL, 1, NULL, N'American'),
	(4, SYSDATETIME(), NULL, 1, NULL, N'French')

SET IDENTITY_INSERT [dbo].[Nationalities] OFF
