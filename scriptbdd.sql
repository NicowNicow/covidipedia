DROP TABLE IF EXISTS cas ;
CREATE TABLE cas (id_cas_cas SERIAL NOT NULL,
date_detection_cas DATE,
date_admission_cas DATE,
date_sortie_cas DATE,
etat_patient_cas CHAR(20),
identifiant_cas CHAR(32),
hopital_id_hopital_hopital SERIAL,
personne_id_personne_personne SERIAL,
PRIMARY KEY (id_cas_cas));

DROP TABLE IF EXISTS hopital ;
CREATE TABLE hopital (id_hopital_hopital SERIAL NOT NULL,
nom_hopital CHAR(50),
nombre_lits_hopital SMALLINT,
nombre_lits_reanimation_hopital SMALLINT,
id_localisation_localisation INTEGER,
PRIMARY KEY (id_hopital_hopital));

DROP TABLE IF EXISTS localisation ;
CREATE TABLE localisation (id_localisation_localisation SERIAL NOT NULL,
region_localisation CHAR(50),
ville_localisation CHAR(50),
departement_localisation SMALLINT,
PRIMARY KEY (id_localisation_localisation));

DROP TABLE IF EXISTS symptomes ;
CREATE TABLE symptomes (id_symptome_symptomes SERIAL NOT NULL,
nom_symptome_symptomes CHAR(50),
PRIMARY KEY (id_symptome_symptomes));

DROP TABLE IF EXISTS vaccin ;
CREATE TABLE vaccin (id_vaccin_vaccin SERIAL NOT NULL,
nom_vaccin_vaccin CHAR(50),
type_vaccin_vaccin CHAR(50),
fabricant_vaccin CHAR(100),
PRIMARY KEY (id_vaccin_vaccin));

DROP TABLE IF EXISTS pathologie ;
CREATE TABLE pathologie (id_pathologie_pathologie SERIAL NOT NULL,
nom_pathologie_pathologie CHAR(50),
PRIMARY KEY (id_pathologie_pathologie));

DROP TABLE IF EXISTS personne ;
CREATE TABLE personne (id_personne_personne SERIAL NOT NULL,
age_personne SMALLINT,
date_vaccin_personne DATE,
sexe_personne BOOL,
id_localisation_localisation INTEGER,
vaccin_id_vaccin_vaccin SERIAL,
PRIMARY KEY (id_personne_personne));

DROP TABLE IF EXISTS effets_secondaires ;
CREATE TABLE effets_secondaires (id_effet_effets_secondaires SERIAL NOT NULL,
nom_effet_effets_secondaires CHAR(50),
PRIMARY KEY (id_effet_effets_secondaires));

DROP TABLE IF EXISTS est_diagnostique ;
CREATE TABLE est_diagnostique (id_cas_cas INTEGER NOT NULL,
id_symptome_symptomes INTEGER NOT NULL,
PRIMARY KEY (id_cas_cas,
 id_symptome_symptomes));

DROP TABLE IF EXISTS a_pathologie ;
CREATE TABLE a_pathologie (id_cas_cas INTEGER NOT NULL,
id_pathologie_pathologie INTEGER NOT NULL,
PRIMARY KEY (id_cas_cas,
 id_pathologie_pathologie));

DROP TABLE IF EXISTS ressent_effets_secondaires ;
CREATE TABLE ressent_effets_secondaires (id_personne_personne INTEGER NOT NULL,
id_effet_effets_secondaires INTEGER NOT NULL,
PRIMARY KEY (id_personne_personne,
 id_effet_effets_secondaires));

ALTER TABLE cas ADD CONSTRAINT FK_cas_hopital_id_hopital_hopital FOREIGN KEY (hopital_id_hopital_hopital) REFERENCES hopital (id_hopital_hopital);
ALTER TABLE cas ADD CONSTRAINT FK_cas_personne_id_personne_personne FOREIGN KEY (personne_id_personne_personne) REFERENCES personne (id_personne_personne);
ALTER TABLE hopital ADD CONSTRAINT FK_hopital_id_localisation_localisation FOREIGN KEY (id_localisation_localisation) REFERENCES localisation (id_localisation_localisation);
ALTER TABLE personne ADD CONSTRAINT FK_personne_id_localisation_localisation FOREIGN KEY (id_localisation_localisation) REFERENCES localisation (id_localisation_localisation);
ALTER TABLE personne ADD CONSTRAINT FK_personne_vaccin_id_vaccin_vaccin FOREIGN KEY (vaccin_id_vaccin_vaccin) REFERENCES vaccin (id_vaccin_vaccin);
ALTER TABLE est_diagnostique ADD CONSTRAINT FK_est_diagnostique_id_cas_cas FOREIGN KEY (id_cas_cas) REFERENCES cas (id_cas_cas);
ALTER TABLE est_diagnostique ADD CONSTRAINT FK_est_diagnostique_id_symptome_symptomes FOREIGN KEY (id_symptome_symptomes) REFERENCES symptomes (id_symptome_symptomes);
ALTER TABLE a_pathologie ADD CONSTRAINT FK_a_pathologie_id_cas_cas FOREIGN KEY (id_cas_cas) REFERENCES cas (id_cas_cas);
ALTER TABLE a_pathologie ADD CONSTRAINT FK_a_pathologie_id_pathologie_pathologie FOREIGN KEY (id_pathologie_pathologie) REFERENCES pathologie (id_pathologie_pathologie);
ALTER TABLE ressent_effets_secondaires ADD CONSTRAINT FK_ressent_effets_secondaires_id_personne_personne FOREIGN KEY (id_personne_personne) REFERENCES personne (id_personne_personne);
ALTER TABLE ressent_effets_secondaires ADD CONSTRAINT FK_ressent_effets_secondaires_id_effet_effets_secondaires FOREIGN KEY (id_effet_effets_secondaires) REFERENCES effets_secondaires (id_effet_effets_secondaires);
