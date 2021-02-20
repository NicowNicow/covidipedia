# Covidipedia: Manuel d'Installation

Ceci est un manuel détaillant la mise en place d'un environement de développement adapté pour cette application, ainsi que la méthode de création des binaires en vue d'un éventuel déploiement.

## Installation en environnement de développement  

<details><summary>Guide d'installation du SDK .NET Core</summary>

---
</details>

<details><summary>Guide d'installation de PostgreSQL</summary>

---
</details>

<details><summary>Guide d'installation de Visual Studio Code et de ses extensions</summary>

---
</details>

<details><summary>Guide de préparation du repository</summary>

Fix APIKey shall not be null error:
        > dotneet user-secrets init
        > dotnet user-secrets set SendGridUser Covidipedia
        > dotnet user-secrets set SendGridKey [ SENDGRID APIKEY]

---
</details>

<details><summary>Guide de connexion initiale aux bases de données</summary><br>

Les étapes suivantes sont nécessaires uniquement lors du premier paramétrage de l'environement de déploiement sur une machine. A noter qu'elles sont également nécessaire lors du déploiement, s'agissant du build des deux bases de données de l'application.  

### Connexion initiale à la base de données principale

Dans une Console de Commande (cmd - bash -powershell):

```powershell hl_lines="6" linenums="1"
psql - U $PostgreSQL_Username
$PostgreSQL_Password
CREATE DATABASE bddcovidipedia;
\c bddcovidipedia;
\i $Path_to_scriptBDDindex
\i $Path_to_dataSet
```

La base de données principale est désormais créée et remplie de données utilisables pour tester les fonctionnalités de l'application lors du déploiement.

!!!warning "De l'intérêt de la dernière commande"
    La dernière commande permet de remplir la base de données avec des données générées de façon cohérente. Lors d'un déploiement en production, il ne faut donc pas lancer cette commande, les données générées restant fictives.

### Connexion initiale à la base de données d'authentification

Pour des mesures de sécurité, le système d'authentification est relié à une base de données secondaire, qui doit également être paramétrée.  
Dans une Console de Commande (cmd - bash -powershell):

```powershell linenums="1"
dotnet tool install --global dotnet-ef
dotnet ef database update --context applicationdbcontext
```

**IMPORTANT:** Penser à adapter le mot de passe et l'utilisateur dans "appsettings.json" > connectionStrings > MainDBConnection & ApplicationDbContextConnection

---
</details>

<details><summary>Guide de lancement des serveurs de tests</summary>

**IMPORTANT 2:** Le serveur PostgreSQL doit être lancé pour pouvoir faire des requêtes sur la database

---
</details>

## Création de binaires pour déploiement en production
