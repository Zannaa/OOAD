CREATE TABLE [dbo].[Karta]
(
	[KartaId] INT Identity(1,1) NOT NULL PRIMARY KEY, 
    [ObicniKupacID] INT NULL, 
    [ProjekcijaID] INT NOT NULL, 
    [Fakturisao] INT NOT NULL, 
    [Odobrio] INT NOT NULL, 
    [Sifra] BIGINT NOT NULL, 
    [Vrijeme] DATETIME NOT NULL, 
    [ClanID] INT NULL, 
    CONSTRAINT [FK_KartaKupac] FOREIGN KEY ([ObicniKupacID]) REFERENCES [ObicniKupac]([ObicniKupacId]), 
    CONSTRAINT [FK_KartaClan] FOREIGN KEY ([ClanID]) REFERENCES [Clan]([ClanId]), 
    CONSTRAINT [FK_KartaProjekcija] FOREIGN KEY ([ProjekcijaID]) REFERENCES [Projekcija]([ProjekcijaId]), 
    CONSTRAINT [FK_KartaProdavac] FOREIGN KEY ([Fakturisao]) REFERENCES [Uposlenik]([UposlenikId]), 
    CONSTRAINT [FK_KartaMenadzer] FOREIGN KEY ([Odobrio]) REFERENCES [Uposlenik]([UposlenikId]),



)
