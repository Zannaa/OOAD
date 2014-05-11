CREATE TABLE [dbo].[Film]
(
	[Id] INT Identity(1,1) NOT NULL PRIMARY KEY, 
    [Naziv] NVARCHAR(50) NOT NULL, 
    [Sifra] NCHAR(15) NOT NULL
)
