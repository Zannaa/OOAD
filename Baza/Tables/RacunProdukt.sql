CREATE TABLE [dbo].[RacunProdukt]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [RacunID] INT NOT NULL, 
    [ProduktID] INT Identity(1,1) NOT NULL, 
    CONSTRAINT [FK_Racun] FOREIGN KEY ([RacunID]) REFERENCES [Racun]([Id]), 
    CONSTRAINT [FK_Produkt] FOREIGN KEY ([ProduktID]) REFERENCES [PrehrambeniProdukt]([Id])
)
