CREATE TABLE [dbo].[Users] (
    [UserId]       INT            IDENTITY (1, 1) NOT NULL,
    [UserName]     NVARCHAR (50)  NULL,
    [PasswordHash] NVARCHAR (MAX) NULL,
    [Role]         NVARCHAR (20)  NULL,
    [Email]        NVARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC)
);


