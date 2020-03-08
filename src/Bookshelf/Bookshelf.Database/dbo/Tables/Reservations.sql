CREATE TABLE [dbo].[Reservations] (
    [Id]                   INT           IDENTITY (1, 1) NOT NULL,
    [CreationDate]         DATETIME2 (7) NOT NULL,
    [ModificationDate]     DATETIME2 (7) NULL,
    [IsActive]             BIT           NOT NULL,
    [DeletedAt]            DATETIME2 (7) NULL,
    [PieceId]              INT           NOT NULL,
    [UserId]               INT           NOT NULL,
    [ReservationTimestamp] DATETIME2 (7) NULL,
    CONSTRAINT [PK_Reservations] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Reservations_Pieces_PieceId] FOREIGN KEY ([PieceId]) REFERENCES [dbo].[Pieces] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Reservations_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Reservations_UserId]
    ON [dbo].[Reservations]([UserId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Reservations_PieceId]
    ON [dbo].[Reservations]([PieceId] ASC);

