CREATE TABLE [dbo].[BookTags] (
    [Id]     INT            IDENTITY (1, 1) NOT NULL,
    [BookId] INT            NOT NULL,
    [BookTags]  NVARCHAR (450) NULL,
    CONSTRAINT [PK_BookTags] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_BookTags_Books_BookId] FOREIGN KEY ([BookId]) REFERENCES [dbo].[Books] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_BookTags_Tag]
    ON [dbo].[BookTags]([Tag] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_BookTags_BookId]
    ON [dbo].[BookTags]([BookId] ASC);

