CREATE TABLE [dbo].[RadnoVrijeme]
(
	[RadnoVrijemeId] INT Identity(1,1) NOT NULL PRIMARY KEY, 
    [Pocetak] DATETIME NOT NULL, 
    [Kraj] DATETIME NOT NULL, 
    [RadnaEvidencijaID] INT NOT NULL, 
    CONSTRAINT [FK_RadnoVrijeme_RadnaEvidencija] FOREIGN KEY ([RadnaEvidencijaID]) REFERENCES [RadnaEvidencija]([RadnaEvidencijaId])
)
