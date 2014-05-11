CREATE TABLE [dbo].[Projekcija]
(
	[Id] INT Identity(1,1) NOT NULL PRIMARY KEY, 
    [Pocetak] DATETIME NOT NULL, 
    [Kraj] DATETIME NOT NULL, 
    [Cijena] FLOAT NOT NULL, 
    [SalaID] INT NOT NULL, 
    [FilmID] INT NOT NULL, 
    CONSTRAINT [FK_ProjekcijaSala] FOREIGN KEY ([SalaID]) REFERENCES [Sala]([Id]), 
    CONSTRAINT [FK_ProjekcijaFilm] FOREIGN KEY ([FilmID]) REFERENCES [Film]([Id])
)
