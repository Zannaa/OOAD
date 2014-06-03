/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/



INSERT INTO Film VALUES ('Eternal Sunshine of a Spotless Mind', 57345)
INSERT INTO Film VALUES ('The A-Team', 59932)
INSERT INTO Film VALUES ('Rambo', 34596)

INSERT INTO Sala VALUES (1, 100)
INSERT INTO Sala VALUES (5, 60)
INSERT INTO Sala VALUES (6, 80)

INSERT INTO ObicniKupac VALUES ('Adnan', 'Ahmethodzic', 'dhd9amv4n7')
INSERT INTO ObicniKupac VALUES ('Zana', 'Tatar', 'sg9sg72s54')

INSERT INTO Clan VALUES ('Adna', 'Colpa', '5dsga53253', '01/01/2013')
INSERT INTO Clan VALUES ('Azra', 'Mahmutovic', 'g834gdsg34', '11/11/2012')

INSERT INTO Projekcija VALUES ('20140603 18:00:00 PM', '20140603 18:00:00 PM', 3, 1, 1)
INSERT INTO Projekcija VALUES ('20140605 20:00:00 PM', '20140605 20:00:00 PM', 4, 1, 2)




