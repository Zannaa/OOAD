CREATE TABLE [dbo].[ObicniKupac]
(
	[ObicniKupacId] INT Identity(1,1) NOT NULL PRIMARY KEY, 
    [Ime] NVARCHAR(50) NOT NULL, 
    [Prezime] NVARCHAR(50) NOT NULL, 
    [Kod] NCHAR(15) NOT NULL
)
