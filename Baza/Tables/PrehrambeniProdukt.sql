CREATE TABLE [dbo].[PrehrambeniProdukt]
(
	[Id] INT Identity(1,1) NOT NULL PRIMARY KEY, 
    [Tip] NVARCHAR(50) NOT NULL, 
    [Cijena] FLOAT NOT NULL
)
