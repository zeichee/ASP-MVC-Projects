CREATE TABLE [dbo].[PersonalInfo] (
    [ID]         INT           IDENTITY (1, 1) NOT NULL,
    [lastName]   NVARCHAR (30) NOT NULL,
    [firstName]  NVARCHAR (30) NOT NULL,
    [middleName] NVARCHAR (30) NOT NULL,
    CONSTRAINT [PK_dbo.PersonalInfo] PRIMARY KEY CLUSTERED ([ID] ASC)
);

