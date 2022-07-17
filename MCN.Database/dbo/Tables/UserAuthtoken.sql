CREATE TABLE [dbo].[UserAuthtoken] (
    [ID]        INT            IDENTITY (1, 1) NOT NULL,
    [Authtoken] NVARCHAR (MAX) NULL,
    [AccessIP]  NVARCHAR (MAX) NULL,
    [UserID]    INT            NULL,
    [CreatedOn] DATETIME2 (7)  NULL,
    [UpdatedOn] DATETIME2 (7)  NULL,
    CONSTRAINT [PK_UserAuthtoken] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_UserAuthtoken_Users_UserID] FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([ID])
);


GO
CREATE NONCLUSTERED INDEX [IX_UserAuthtoken_UserID]
    ON [dbo].[UserAuthtoken]([UserID] ASC);

