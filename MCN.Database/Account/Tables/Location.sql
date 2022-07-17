CREATE TABLE [Account].[Location] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Address]   NVARCHAR (MAX) NULL,
    [Latitude]  FLOAT (53)     NOT NULL,
    [Longitude] FLOAT (53)     NOT NULL,
    [UserId]    INT            NOT NULL,
    CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Location_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([ID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Location_UserId]
    ON [Account].[Location]([UserId] ASC);

