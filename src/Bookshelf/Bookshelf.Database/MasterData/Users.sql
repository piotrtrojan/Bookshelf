SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] 
	([Id], [CreationDate], [ModificationDate], [IsActive], [DeletedAt], [AspNetGuid], [Email], [FirstName], [LastName], [CardId], [NationalityId]) 
VALUES 
	(1, SYSDATETIME(), NULL, 1, NULL, N'00cffbea-3893-4866-8d01-08d7c2ecb204', N'admin@bookshelf.com', N'Root', N'Admin', 1, 1)

SET IDENTITY_INSERT [dbo].[Users] OFF
