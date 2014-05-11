CREATE TABLE [dbo].[RadnaEvidencija]
(
	[Id] INT Identity(1,1) NOT NULL PRIMARY KEY, 
    [UposlenikID] INT NOT NULL, 
    CONSTRAINT [FK_RadnaEvidencijaUposlenik] FOREIGN KEY ([UposlenikID]) REFERENCES [Uposlenik]([Id])
)
