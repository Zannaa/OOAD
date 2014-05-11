CREATE TABLE [dbo].[Uposlenik]
(
	[Id] INT Identity(1,1) NOT NULL PRIMARY KEY, 
    [Ime] NVARCHAR(50) NOT NULL, 
    [Prezime] NVARCHAR(50) NOT NULL, 
    [Jmbg] NCHAR(13) NOT NULL, 
    [Koeficijent] FLOAT NOT NULL, 
    [Pult] INT NULL, 
    [Obuka] NVARCHAR(50) NULL, 
    [Telefon] NVARCHAR(50) NULL, 
    [Budzet] FLOAT NULL, 
    CONSTRAINT [UNQ_Uposlenik_Jmbg] UNIQUE ([Jmbg])
)
