﻿CREATE TABLE [dbo].[Racun]
(
	[RacunId] INT Identity(1,1) NOT NULL PRIMARY KEY, 
    [Fakturisao] INT NOT NULL, 
    [Odobrio] INT NOT NULL, 
    [Sifra] INT NOT NULL, 
    [Vrijeme] DATETIME NOT NULL, 
    CONSTRAINT [FK_RacunProdavac] FOREIGN KEY ([Fakturisao]) REFERENCES [Uposlenik]([UposlenikId]), 
    CONSTRAINT [FK_RacunMenadzer] FOREIGN KEY ([Odobrio]) REFERENCES [Uposlenik]([UposlenikId])
)
