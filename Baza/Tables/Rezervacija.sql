CREATE TABLE [dbo].[Rezervacija]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Sjediste] INT NOT NULL, 
    [ClanID] INT NULL, 
    [ObicniKupacID] INT NULL, 
    [ProjekcijaID] INT NOT NULL, 
    CONSTRAINT [FK_RezervacijaClan] FOREIGN KEY ([ClanID]) REFERENCES [Clan]([Id]), 
    CONSTRAINT [FK_RezervacijaObicniKupac] FOREIGN KEY ([ObicniKupacID]) REFERENCES [ObicniKupac]([Id]), 
    CONSTRAINT [FK_RezervacijaProjekcija] FOREIGN KEY ([ProjekcijaID]) REFERENCES [Projekcija]([Id])
)
