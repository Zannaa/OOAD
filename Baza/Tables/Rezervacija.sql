CREATE TABLE [dbo].[Rezervacija]
(
	[RezervacijaId] INT Identity(1,1) NOT NULL PRIMARY KEY, 
    [Sjediste] INT NOT NULL, 
    [ClanID] INT NULL, 
    [ObicniKupacID] INT NULL, 
    [ProjekcijaID] INT NOT NULL, 
    CONSTRAINT [FK_RezervacijaClan] FOREIGN KEY ([ClanID]) REFERENCES [Clan]([ClanId]), 
    CONSTRAINT [FK_RezervacijaObicniKupac] FOREIGN KEY ([ObicniKupacID]) REFERENCES [ObicniKupac]([ObicniKupacId]), 
    CONSTRAINT [FK_RezervacijaProjekcija] FOREIGN KEY ([ProjekcijaID]) REFERENCES [Projekcija]([ProjekcijaId])
)
