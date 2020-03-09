SET IDENTITY_INSERT [dbo].[Nationalities] ON 

INSERT [dbo].[Nationalities] 
	([Id], [CreationDate], [ModificationDate], [IsActive], [DeletedAt], [Name]) 
VALUES 
	(1, SYSDATETIME(), NULL, 1, NULL, 'Polish'),
	(2, SYSDATETIME(), NULL, 1, NULL, 'English'),
	(3, SYSDATETIME(), NULL, 1, NULL, 'American'),
	(4, SYSDATETIME(), NULL, 1, NULL, 'French')

SET IDENTITY_INSERT [dbo].[Nationalities] OFF
