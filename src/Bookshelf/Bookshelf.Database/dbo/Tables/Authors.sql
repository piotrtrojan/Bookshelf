CREATE TABLE [dbo].[Authors] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [CreationDate]     DATETIME2 (7)  NOT NULL,
    [ModificationDate] DATETIME2 (7)  NULL,
    [IsActive]         BIT            NOT NULL,
    [DeletedAt]        DATETIME2 (7)  NULL,
    [FirstName]        NVARCHAR (MAX) NULL,
    [LastName]         NVARCHAR (MAX) NULL,
    [NationalityId]    INT			  NOT NULL,
    CONSTRAINT [PK_Authors] PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_Authors_Nationalities_Id] FOREIGN KEY ([NationalityId]) REFERENCES [Nationalities]([Id])
);



