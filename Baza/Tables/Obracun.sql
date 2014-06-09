CREATE TABLE [dbo].[Obracun]
(
	[ObracunId] INT Identity(1,1) NOT NULL PRIMARY KEY, 
    [Datum] DATETIME NOT NULL, 
    [Obracunao] INT NOT NULL, 
    [UposlenikID] INT NOT NULL, 
    CONSTRAINT [FK_ObracunFinMenadzer] FOREIGN KEY ([Obracunao]) REFERENCES [Uposlenik]([UposlenikId]), 
    CONSTRAINT [FK_ObracunUposlenik] FOREIGN KEY ([UposlenikID]) REFERENCES [Uposlenik]([UposlenikId])
)
