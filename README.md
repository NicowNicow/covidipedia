# Covidipedia

    Connexion Initiale à la Database Principale:
        > psql -U postgres
        > CREATE DATABASE covidipediabdd;
        > \c covidipediabdd
        > \i le fichier de creation de tables
        > \i le fichier de remplissage des tables (si besoin)


    Connexion initiale à la Database d'Authentification
        > dotnet tool install --global dotnet-ef
        > dotnet ef database update --context Applicationdbcontext

**IMPORTANT:** Penser à adapter le mot de passe et l'utilisateur dans "appsettings.json" > connectionStrings > MainDBConnection & ApplicationDbContextConnection

**IMPORTANT 2:** Le serveur PostgreSQL doit être lancé pour pouvoir faire des requêtes sur la database

    Fix APIKey shall not be null error:
        > dotneet user-secrets init
        > dotnet user-secrets set SendGridUser Covidipedia
        > dotnet user-secrets set SendGridKey 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
