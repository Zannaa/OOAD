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



INSERT INTO Film VALUES ('The A-Team', 59932)
INSERT INTO Film VALUES ('Shutter Island', 65618)
INSERT INTO Film VALUES ('A Beuatiful Mind', 17895)
INSERT INTO Film VALUES ('The Perks Of Being a Follower', 54823)
INSERT INTO Film VALUES ('Blue Valentine', 96852)


INSERT INTO Sala VALUES (1, 100)
INSERT INTO Sala VALUES (5, 60)
INSERT INTO Sala VALUES (6, 80)
INSERT INTO Sala VALUES (4, 150)
INSERT INTO Sala VALUES (2, 80)

INSERT INTO ObicniKupac VALUES ('Adnan', 'Ahmethodzic', 'dhd9amv4n7')
INSERT INTO ObicniKupac VALUES ('Zana', 'Tatar', 'sg9sg72s54')
INSERT INTO ObicniKupac VALUES ('Arnela', 'Tumbul', '1h5d2r3t6u')
INSERT INTO ObicniKupac VALUES ('Lejla', 'Sukman', 'rg9pg76s63')
INSERT INTO ObicniKupac VALUES ('Amina', 'Imamovic', 'q6rf89zh1k')

INSERT INTO Clan VALUES ('Adna', 'Colpa', '5dsga53253', '20140603 20:00:00 PM')
INSERT INTO Clan VALUES ('Azra', 'Mahmutovic', 'g834gdsg34', '20140603 20:00:00 PM')
INSERT INTO Clan VALUES ('Hana', 'Tatar', '3g5z8t6d8u', '20140603 20:00:00 PM')
INSERT INTO Clan VALUES ('Kenan', 'Salihović', '1jkli56bn4', '20140603 20:00:00 PM')
INSERT INTO Clan VALUES ('Mirza', 'Behrem', 'k6l4j23k5o', '20140603 20:00:00 PM')

INSERT INTO Projekcija VALUES ('20140603 18:00:00 PM', '20140603 20:00:00 PM', 3, 1, 1)
INSERT INTO Projekcija VALUES ('20140605 20:00:00 PM', '20140605 22:00:00 PM', 4, 1, 2)
INSERT INTO Projekcija VALUES ('20140606 18:00:00 PM', '20140603 20:00:00 PM', 3, 1, 1)
INSERT INTO Projekcija VALUES ('20140607 20:00:00 PM', '20140605 22:00:00 PM', 4, 1, 2)
INSERT INTO Projekcija VALUES ('20140608 18:00:00 PM', '20140603 20:00:00 PM', 3, 1, 1)

INSERT INTO Uposlenik VALUES ('Nađa', 'Đelmo', '1111111111111' , 0.5, null, null ,'061499300', null ) 
INSERT INTO Uposlenik VALUES ('Haris', 'Sukman', '6666666666666' , 0.5, 1, null , null, null ) 
INSERT INTO Uposlenik VALUES ('Maida', 'Gusic', '9874563215486' , 0.8, null, null ,'061111222', null ) 
INSERT INTO Uposlenik VALUES ('Nađa', 'Đelmo', '1234567891234' , 0.8, null, null ,null, 20000 ) 
INSERT INTO Uposlenik VALUES ('Almedina', 'Kevric', '2365984236589' , 0.5, null, null ,'06155577', null )

INSERT INTO Rezervacija VALUES (  5,1,null,5 )
INSERT INTO Rezervacija VALUES (  4,null,2,4 )
INSERT INTO Rezervacija VALUES (  2,2,null,3 )
INSERT INTO Rezervacija VALUES (  1,null,1,2 )
INSERT INTO Rezervacija VALUES (  3,3,null,1 ) 

INSERT INTO  Obracun VALUES ('20140603 18:00:00 PM', 4,1)
INSERT INTO  Obracun VALUES ('20140603 18:00:00 PM', 4,2)
INSERT INTO  Obracun VALUES ('20140603 18:00:00 PM', 4,5)
INSERT INTO  Obracun VALUES ('20140603 18:00:00 PM', 4,1)
INSERT INTO  Obracun VALUES ('20140603 18:00:00 PM', 4,2)

INSERT INTO Karta VALUES (2,2, 1, 3, '8596358742', '20140603 18:00:00 PM' , null)
INSERT INTO Karta VALUES (null,2, 5, 3, '8596325874', '20140605 20:00:00 PM' , 1)
INSERT INTO Karta VALUES (null,3, 1, 3, '2546987125', '20140606 18:00:00 PM' , 2)
INSERT INTO Karta VALUES (3,3, 3, 3, '659321485', '20140606 18:00:00 PM' , null)
INSERT INTO Karta VALUES (1,2, 1, 3, '2546987136', '20140603 18:00:00 PM' , null)

INSERT INTO PrehrambeniProdukt VALUES ('coca-cola', 2)
INSERT INTO PrehrambeniProdukt VALUES ('pop-corn b', 2)
INSERT INTO PrehrambeniProdukt VALUES ('pop-corn s', 1)
INSERT INTO PrehrambeniProdukt VALUES ('juice', 2.5)
INSERT INTO PrehrambeniProdukt VALUES ('chips', 2.5)