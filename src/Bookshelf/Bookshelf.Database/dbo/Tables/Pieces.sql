CREATE TABLE [dbo].[Pieces] (
    [Id]               INT           IDENTITY (1, 1) NOT NULL,
    [CreationDate]     DATETIME2 (7) NOT NULL,
    [ModificationDate] DATETIME2 (7) NULL,
    [IsActive]         BIT           NOT NULL,
    [DeletedAt]        DATETIME2 (7) NULL,
    [Barcode]          INT           NULL,
    [BookId]           INT           NOT NULL,
    [Status]           INT           NOT NULL,
    [MaxLoanDays]      INT           NULL,
    CONSTRAINT [PK_Pieces] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Pieces_Books_BookId] FOREIGN KEY ([BookId]) REFERENCES [dbo].[Books] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Pieces_BookId]
    ON [dbo].[Pieces]([BookId] ASC);

