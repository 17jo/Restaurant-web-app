SET IDENTITY_INSERT Dezert ON;
INSERT INTO Dezert(ID, ImeDezerta, Cena, RestoranID) VALUES (1,'sladoled', 50, 1);
INSERT INTO Dezert(ID, ImeDezerta, Cena, RestoranID) VALUES (2,'palacinka', 180,1);
INSERT INTO Dezert(ID, ImeDezerta, Cena, RestoranID) VALUES (3,'trilece', 150,2);
INSERT INTO Dezert(ID, ImeDezerta, Cena, RestoranID) VALUES (4,'cheesecake', 160,2);
INSERT INTO Dezert(ID, ImeDezerta, Cena, RestoranID) VALUES (5,'banana split', 250,1);
INSERT INTO Dezert(ID, ImeDezerta, Cena, RestoranID) VALUES (6,'dobos torta', 180,2);
INSERT INTO Dezert(ID, ImeDezerta, Cena, RestoranID) VALUES (7,'vocni kup', 250,1);

SET IDENTITY_INSERT Dezert OFF;

SET IDENTITY_INSERT Jela ON;

INSERT INTO Jela(ID, ImeJela, Cena, RestoranID) VALUES (1,'lazanje',510,1);
INSERT INTO Jela(ID, ImeJela, Cena, RestoranID) VALUES (2,'cezar salata',360,2);
INSERT INTO Jela(ID, ImeJela, Cena, RestoranID) VALUES (3,'tortilja',380,1);
INSERT INTO Jela(ID, ImeJela, Cena, RestoranID) VALUES (4,'burito',470,1);
INSERT INTO Jela(ID, ImeJela, Cena, RestoranID) VALUES (5,'pica margarita',630,2);
INSERT INTO Jela(ID, ImeJela, Cena, RestoranID) VALUES (6,'kapricoza',980,1);
INSERT INTO Jela(ID, ImeJela, Cena, RestoranID) VALUES (10,'sopska salata',220,2);
INSERT INTO Jela(ID, ImeJela, Cena, RestoranID) VALUES (11,'pohovana piletina',560,1);
INSERT INTO Jela(ID, ImeJela, Cena, RestoranID) VALUES (12,'tuna',550,1);

SET IDENTITY_INSERT Jela OFF;

SET IDENTITY_INSERT Pice ON;

INSERT INTO Pice(ID, ImePica, Cena, RestoranID) VALUES (1,'limunada',150,1);
INSERT INTO Pice(ID, ImePica, Cena, RestoranID) VALUES (2,'pomorandza',240,1);
INSERT INTO Pice(ID, ImePica, Cena, RestoranID) VALUES (3,'coca-cola',165,1);
INSERT INTO Pice(ID, ImePica, Cena, RestoranID) VALUES (4,'fanta',165,2);
INSERT INTO Pice(ID, ImePica, Cena, RestoranID) VALUES (5,'sprite',165,1);
INSERT INTO Pice(ID, ImePica, Cena, RestoranID) VALUES (6,'cedevita',120,1);
INSERT INTO Pice(ID, ImePica, Cena, RestoranID) VALUES (7,'jelen pivo',190,1);
INSERT INTO Pice(ID, ImePica, Cena, RestoranID) VALUES (8,'vino',150,2);
INSERT INTO Pice(ID, ImePica, Cena, RestoranID) VALUES (9,'kafa',90,1);
INSERT INTO Pice(ID, ImePica, Cena, RestoranID) VALUES (10,'caj',100,1);
INSERT INTO Pice(ID, ImePica, Cena, RestoranID) VALUES (11,'topla cokolada',130,2);
INSERT INTO Pice(ID, ImePica, Cena, RestoranID) VALUES (12,'plazma shake',150,1);
INSERT INTO Pice(ID, ImePica, Cena, RestoranID) VALUES (13,'sok sumsko voce',150,1);
  
SET IDENTITY_INSERT Pice OFF;

SET IDENTITY_INSERT Restoran ON;

INSERT INTO Restoran(ID, ImeRestorana) VALUES (1,'Elit');
INSERT INTO Restoran(ID, ImeRestorana) VALUES (2,'Puzle');

  
SET IDENTITY_INSERT Restoran OFF;

