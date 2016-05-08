CREATE TABLE [dbo].[Students] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [name]     NVARCHAR (MAX) NOT NULL,
    [email]    NVARCHAR (MAX) NOT NULL,
    [ssn]      NVARCHAR (MAX) NOT NULL,
    [password] NVARCHAR (MAX) NOT NULL,
    [role] INT NOT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

