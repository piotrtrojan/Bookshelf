CREATE TABLE [dbo].[Nationalities]
(
	[Id]               INT            IDENTITY (1, 1) NOT NULL,
    [CreationDate]     DATETIME2 (7)  NOT NULL,
    [ModificationDate] DATETIME2 (7)  NULL,
    [IsActive]         BIT            NOT NULL,
    [DeletedAt]        DATETIME2 (7)  NULL,
	[Name]             NVARCHAR (MAX) NULL,
	CONSTRAINT [PK_Nationalities] PRIMARY KEY CLUSTERED ([Id] ASC)
)
