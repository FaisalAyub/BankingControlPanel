CREATE TABLE [dbo].[UserMultiFactors] (
    [ID]         INT            IDENTITY (1, 1) NOT NULL,
    [UserID]     INT            NOT NULL,
    [AccessIP]   NVARCHAR (MAX) NULL,
    [EmailToken] NVARCHAR (MAX) NULL,
    [CreatedOn]  DATETIME2 (7)  NULL,
    [UpdatedOn]  DATETIME2 (7)  NULL,
    CONSTRAINT [PK_UserMultiFactors] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_UserMultiFactors_Users_UserID] FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([ID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_UserMultiFactors_UserID]
    ON [dbo].[UserMultiFactors]([UserID] ASC);

