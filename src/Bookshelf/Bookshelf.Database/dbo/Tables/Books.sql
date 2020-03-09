CREATE TABLE [dbo].[Books] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [CreationDate]     DATETIME2 (7)  NOT NULL,
    [ModificationDate] DATETIME2 (7)  NULL,
    [IsActive]         BIT            NOT NULL,
    [DeletedAt]        DATETIME2 (7)  NULL,
    [AuthorId]         INT            NOT NULL,
    [Title]            NVARCHAR (MAX) NULL,
    [Pages]            INT            NOT NULL,
    [MaxLoanDays]      INT            NULL,
    CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Books_Authors_AuthorId] FOREIGN KEY ([AuthorId]) REFERENCES [dbo].[Authors] ([Id])
);




GO
CREATE NONCLUSTERED INDEX [IX_Books_AuthorId]
    ON [dbo].[Books]([AuthorId] ASC);

