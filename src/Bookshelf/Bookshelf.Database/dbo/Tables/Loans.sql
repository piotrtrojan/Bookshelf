CREATE TABLE [dbo].[Loans] (
    [Id]               INT           IDENTITY (1, 1) NOT NULL,
    [CreationDate]     DATETIME2 (7) NOT NULL,
    [ModificationDate] DATETIME2 (7) NULL,
    [IsActive]         BIT           NOT NULL,
    [DeletedAt]        DATETIME2 (7) NULL,
    [PieceId]          INT           NOT NULL,
    [UserId]           INT           NOT NULL,
    [BookingTimestamp] DATETIME2 (7) NULL,
    [PickupTimestamp]  DATETIME2 (7) NULL,
    [ReturnTimestamp]  DATETIME2 (7) NULL,
    CONSTRAINT [PK_Loans] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Loans_Pieces_PieceId] FOREIGN KEY ([PieceId]) REFERENCES [dbo].[Pieces] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Loans_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Loans_UserId]
    ON [dbo].[Loans]([UserId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Loans_PieceId]
    ON [dbo].[Loans]([PieceId] ASC);

