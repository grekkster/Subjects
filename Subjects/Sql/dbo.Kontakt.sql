CREATE TABLE [dbo].[Kontakt] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [Jmeno]         NVARCHAR (60) NOT NULL,
    [Prijmeni]      NVARCHAR (60) NOT NULL,
    [DatumNarozeni] DATE          NOT NULL,
    [Telefon]       NVARCHAR (16) NULL,
    [Vlozeno]       DATETIME      NULL,
    [Ico]           INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Kontakt_Subjekt] FOREIGN KEY ([Ico]) REFERENCES [dbo].[Subjekt] ([Ico])
);

