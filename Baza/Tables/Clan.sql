CREATE TABLE [dbo].[Clan]
(
	[Id] INT Identity(1,1) NOT NULL PRIMARY KEY, 
    [Ime] NVARCHAR(50) NOT NULL, 
    [Prezime] NVARCHAR(50) NOT NULL, 
    [Sifra] NCHAR(20) NOT NULL, 
    [Clanstvo] DATETIME NOT NULL
)
