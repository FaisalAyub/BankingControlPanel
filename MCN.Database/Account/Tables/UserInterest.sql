CREATE TABLE [Account].[UserInterest] (
    [InterestId] INT NOT NULL,
    [UserId]     INT NOT NULL,
    [LocationId] INT DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_UserInterest] PRIMARY KEY CLUSTERED ([UserId] ASC, [InterestId] ASC),
    CONSTRAINT [FK_UserInterest_Interest_InterestId] FOREIGN KEY ([InterestId]) REFERENCES [Account].[Interest] ([Id]),
    CONSTRAINT [FK_UserInterest_Location_LocationId] FOREIGN KEY ([LocationId]) REFERENCES [Account].[Location] ([Id]),
    CONSTRAINT [FK_UserInterest_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([ID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_UserInterest_InterestId]
    ON [Account].[UserInterest]([InterestId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_UserInterest_LocationId]
    ON [Account].[UserInterest]([LocationId] ASC);

