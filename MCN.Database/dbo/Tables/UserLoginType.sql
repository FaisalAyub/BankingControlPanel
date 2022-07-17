CREATE TABLE [dbo].[UserLoginType] (
    [UserLoginTypeId] INT            IDENTITY (1, 1) NOT NULL,
    [UserLoginName]   NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_UserLoginType] PRIMARY KEY CLUSTERED ([UserLoginTypeId] ASC)
);

