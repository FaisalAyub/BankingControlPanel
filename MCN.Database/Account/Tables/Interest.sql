CREATE TABLE [Account].[Interest] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Title]       NVARCHAR (MAX) NULL,
    [Paid]        BIT            NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    [Cost]        FLOAT (53)     NOT NULL,
    [Type]        NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Interest] PRIMARY KEY CLUSTERED ([Id] ASC)
);

