CREATE TABLE [dbo].[Subjekt]
(
	[Ico] INT NOT NULL PRIMARY KEY, 
    [Nazev] NVARCHAR(60) NULL, 
    [Ulice] NVARCHAR(60) NULL, 
    [Obec] NVARCHAR(60) NULL, 
    [Psc] NCHAR(5) NULL, 
    [Poznamka] NVARCHAR(MAX) NULL, 
    [Vlozeno] DATETIME NULL
)
