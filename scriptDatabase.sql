DROP TABLE IF EXISTS cas ;
CREATE TABLE cas (id_cas_cas SERIAL NOT NULL,
etat_actuel_cas CHAR(100),
hopital_id_hopital_hopital INTEGER,
personne_id_personne_personne INTEGER,
PRIMARY KEY (id_cas_cas));

DROP TABLE IF EXISTS historique_cas ;
CREATE TABLE historique_cas (id_historique_historique_cas SERIAL NOT NULL,
date_detection_historique_cas DATE,
date_maj_historique_cas DATE,
etat_cas_historique_cas CHAR(100),
souche_virus_historique_cas CHAR(50),
id_cas_cas INTEGER,
PRIMARY KEY (id_historique_historique_cas));

DROP TABLE IF EXISTS traitement ;
CREATE TABLE traitement (id_traitement_traitement SERIAL NOT NULL,
nom_traitement_traitement CHAR(100),
type_traitement_traitement CHAR(100),
PRIMARY KEY (id_traitement_traitement));

DROP TABLE IF EXISTS pathologie ;
CREATE TABLE pathologie (id_pathologie_pathologie SERIAL NOT NULL,
nom_pathologie_pathologie CHAR(100),
type_pathologie_pathologie CHAR(100),
PRIMARY KEY (id_pathologie_pathologie));

DROP TABLE IF EXISTS symptome ;
CREATE TABLE symptome (id_symptome_symptome SERIAL NOT NULL,
nom_symptome_symptome CHAR(100),
type_symptome_symptome CHAR(100),
PRIMARY KEY (id_symptome_symptome));

DROP TABLE IF EXISTS hopital ;
CREATE TABLE hopital (id_hopital_hopital SERIAL NOT NULL,
nom_hopital CHAR(100),
nombre_lits_hopital SMALLINT,
nombre_lits_reanimation_hopital SMALLINT,
id_localisation_localisation INTEGER,
PRIMARY KEY (id_hopital_hopital));

DROP TABLE IF EXISTS localisation ;
CREATE TABLE localisation (id_localisation_localisation SERIAL NOT NULL,
region_localisation CHAR(100),
departement_localisation SMALLINT,
ville_localisation CHAR(100),
PRIMARY KEY (id_localisation_localisation));

DROP TABLE IF EXISTS personne ;
CREATE TABLE personne (id_personne_personne SERIAL NOT NULL,
age_personne SMALLINT,
sexe_personne BOOL,
identifiant_personne CHAR(32),
date_vaccin_1_personne DATE,
date_vaccin_2_personne DATE,
ethnie_personne CHAR(100),
id_localisation_localisation INTEGER,
vaccin_id_vaccin_vaccin INTEGER,
PRIMARY KEY (id_personne_personne));

DROP TABLE IF EXISTS effet_secondaire ;
CREATE TABLE effet_secondaire (id_effet_effet_secondaire SERIAL NOT NULL,
nom_effet_effet_secondaire CHAR(100),
type_effet_effet_secondaire CHAR(100),
PRIMARY KEY (id_effet_effet_secondaire));

DROP TABLE IF EXISTS vaccin ;
CREATE TABLE vaccin (id_vaccin_vaccin SERIAL NOT NULL,
nom_vaccin_vaccin CHAR(100),
type_vaccin_vaccin CHAR(100),
fabricant_vaccin CHAR(100),
PRIMARY KEY (id_vaccin_vaccin));

DROP TABLE IF EXISTS est_diagnostique ;
CREATE TABLE est_diagnostique (id_symptome_symptome SERIAL NOT NULL,
id_cas_cas INTEGER NOT NULL,
PRIMARY KEY (id_symptome_symptome,
 id_cas_cas));

DROP TABLE IF EXISTS ayant_les_pathologies ;
CREATE TABLE ayant_les_pathologies (id_pathologie_pathologie SERIAL NOT NULL,
id_cas_cas INTEGER NOT NULL,
PRIMARY KEY (id_pathologie_pathologie,
 id_cas_cas));

DROP TABLE IF EXISTS recoit_le_traitement ;
CREATE TABLE recoit_le_traitement (id_traitement_traitement SERIAL NOT NULL,
id_cas_cas INTEGER NOT NULL,
PRIMARY KEY (id_traitement_traitement,
 id_cas_cas));

DROP TABLE IF EXISTS ressent_effet_secondaire ;
CREATE TABLE ressent_effet_secondaire (id_effet_effet_secondaire SERIAL NOT NULL,
id_personne_personne INTEGER NOT NULL,
PRIMARY KEY (id_effet_effet_secondaire,
 id_personne_personne));

ALTER TABLE cas ADD CONSTRAINT FK_cas_hopital_id_hopital_hopital FOREIGN KEY (hopital_id_hopital_hopital) REFERENCES hopital (id_hopital_hopital);

ALTER TABLE cas ADD CONSTRAINT FK_cas_personne_id_personne_personne FOREIGN KEY (personne_id_personne_personne) REFERENCES personne (id_personne_personne);
ALTER TABLE historique_cas ADD CONSTRAINT FK_historique_cas_id_cas_cas FOREIGN KEY (id_cas_cas) REFERENCES cas (id_cas_cas);
ALTER TABLE hopital ADD CONSTRAINT FK_hopital_id_localisation_localisation FOREIGN KEY (id_localisation_localisation) REFERENCES localisation (id_localisation_localisation);

ALTER TABLE personne ADD CONSTRAINT FK_personne_id_localisation_localisation FOREIGN KEY (id_localisation_localisation) REFERENCES localisation (id_localisation_localisation);
ALTER TABLE personne ADD CONSTRAINT FK_personne_vaccin_id_vaccin_vaccin FOREIGN KEY (vaccin_id_vaccin_vaccin) REFERENCES vaccin (id_vaccin_vaccin);
ALTER TABLE est_diagnostique ADD CONSTRAINT FK_est_diagnostique_id_symptome_symptome FOREIGN KEY (id_symptome_symptome) REFERENCES symptome (id_symptome_symptome);
ALTER TABLE est_diagnostique ADD CONSTRAINT FK_est_diagnostique_id_cas_cas FOREIGN KEY (id_cas_cas) REFERENCES cas (id_cas_cas);
ALTER TABLE ayant_les_pathologies ADD CONSTRAINT FK_ayant_les_pathologies_id_pathologie_pathologie FOREIGN KEY (id_pathologie_pathologie) REFERENCES pathologie (id_pathologie_pathologie);
ALTER TABLE ayant_les_pathologies ADD CONSTRAINT FK_ayant_les_pathologies_id_cas_cas FOREIGN KEY (id_cas_cas) REFERENCES cas (id_cas_cas);
ALTER TABLE recoit_le_traitement ADD CONSTRAINT FK_recoit_le_traitement_id_traitement_traitement FOREIGN KEY (id_traitement_traitement) REFERENCES traitement (id_traitement_traitement);
ALTER TABLE recoit_le_traitement ADD CONSTRAINT FK_recoit_le_traitement_id_cas_cas FOREIGN KEY (id_cas_cas) REFERENCES cas (id_cas_cas);
ALTER TABLE ressent_effet_secondaire ADD CONSTRAINT FK_ressent_effet_secondaire_id_effet_effet_secondaire FOREIGN KEY (id_effet_effet_secondaire) REFERENCES effet_secondaire (id_effet_effet_secondaire);
ALTER TABLE ressent_effet_secondaire ADD CONSTRAINT FK_ressent_effet_secondaire_id_personne_personne FOREIGN KEY (id_personne_personne) REFERENCES personne (id_personne_personne);

CREATE INDEX nom_hopital_index ON hopital (nom_hopital);
