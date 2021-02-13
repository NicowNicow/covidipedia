# Covidipedia

    Connexion Initiale à la Database Principale:
        > psql -U postgres
        > CREATE DATABASE covidipediabdd;
        > \c covidipediabdd
        > \i le fichier de creation de tables
        > \i le fichier de remplissage des tables (si besoin)
**IMPORTANT:** Penser à adapter le mot de passe et l'utilisateur dans "appsettings.json" > connectionStrings > MainDBConnection

**IMPORTANT 2:** Le serveur PostgreSQL doit être lancé pour pouvoir faire des requêtes sur la database
