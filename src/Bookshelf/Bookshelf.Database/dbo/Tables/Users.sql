CREATE TABLE [dbo].[Users] (
    [Id]               INT              IDENTITY (1, 1) NOT NULL,
    [CreationDate]     DATETIME2 (7)    NOT NULL,
    [ModificationDate] DATETIME2 (7)    NULL,
    [IsActive]         BIT              NOT NULL,
    [DeletedAt]        DATETIME2 (7)    NULL,
    [AspNetGuid]       UNIQUEIDENTIFIER NOT NULL,
    [FirstName]        NVARCHAR (MAX)   NULL,
    [LastName]         NVARCHAR (MAX)   NULL,
    [Email]            NVARCHAR(MAX)    NOT NULL, 
    [CardId]           INT              NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC)
);

