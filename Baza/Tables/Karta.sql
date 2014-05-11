CREATE TABLE [dbo].[Karta]
(
	[Id] INT Identity(1,1) NOT NULL PRIMARY KEY, 
    [ObicniKupacID] INT NULL, 
    [ProjekcijaID] INT NOT NULL, 
    [Fakturisao] INT NOT NULL, 
    [Odobrio] INT NOT NULL, 
    [Sifra] INT NOT NULL, 
    [Vrijeme] DATETIME NOT NULL, 
    [ClanID] INT NULL, 
    CONSTRAINT [FK_KartaKupac] FOREIGN KEY ([ObicniKupacID]) REFERENCES [ObicniKupac]([Id]), 
    CONSTRAINT [FK_KartaClan] FOREIGN KEY ([ClanID]) REFERENCES [Clan]([Id]), 
    CONSTRAINT [FK_KartaProjekcija] FOREIGN KEY ([ProjekcijaID]) REFERENCES [Projekcija]([Id]), 
    CONSTRAINT [FK_KartaProdavac] FOREIGN KEY ([Fakturisao]) REFERENCES [Uposlenik]([Id]), 
    CONSTRAINT [FK_KartaMenadzer] FOREIGN KEY ([Odobrio]) REFERENCES [Uposlenik]([Id]),



)
