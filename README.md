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

<details><summary>Guide de préparation du code source</summary>

Fix APIKey shall not be null error:
        > dotneet user-secrets init
        > dotnet user-secrets set SendGridUser Covidipedia
        > dotnet user-secrets set SendGridKey [ SENDGRID APIKEY]

**IMPORTANT:** Penser à adapter le mot de passe et l'utilisateur dans "appsettings.json" > connectionStrings > MainDBConnection & ApplicationDbContextConnection

---
</details>

<details><summary>Guide de connexion initiale aux bases de données</summary><br>

Les étapes suivantes sont nécessaires uniquement lors du premier paramétrage de l'environement de déploiement sur une machine. A noter qu'elles sont également nécessaire lors du déploiement, s'agissant du build des deux bases de données de l'application.  
<br>

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

> :heavy_check_mark: **De l'intérêt de la dernière commande**: La dernière commande permet de remplir la base de données avec des données générées de façon cohérente. Lors d'un déploiement en production, il ne faut donc pas lancer cette commande, les données générées restant fictives.

<br>

### Connexion initiale à la base de données d'authentification

Pour des mesures de sécurité, le système d'authentification est relié à une base de données secondaire, qui doit également être paramétrée.  
Dans une Console de Commande (cmd - bash -powershell):

```powershell linenums="1"
dotnet tool install --global dotnet-ef
dotnet ef database update --context applicationdbcontext
```

Les deux databases sont désormais créées et prêtes à être utilisées.

---
</details>

<details><summary>Guide de lancement des serveurs de tests</summary><br>

Afin de tester l'application/le système de connecteurs, il est tout d'abord nécessaire de lancer le service PostgreSQL.  
Dans une Console de Commande (cmd - bash -powershell):

```powershell linenums="1"
postgres -D $Path_to_PostgreSQL_data_folder
```

L'environement de développement est désormais prêt à l'utilisation.

<br>

<h4><ins> Tester l'Application Web </ins></h4>

Dans une Console de Commande (cmd - bash -powershell):

```powershell linenums="1"
cd $Path_to_covidipedia_front_folder
dotnet run
```

Si la commande `dotnet run` est executée dans le dossier où se situe le fichier `covidipedia.front.csproj`, un système d'hosting Microsoft va se lancer. Au bout de quelques secondes, le port du localhost sur lequel est hébergé l'application web sera mis à disposition.

> :warning: **Hosting Microsoft et Cache du Navigateur**: Lorsque le code source de l'application est modifié, il est nécessaire, après sauvegarde des modifications, de relancer le système d'host Microsoft à l'aide la commande `dotnet run` afin que celles ci soient prises en compte. De même, il peut être nécessaire de vider le cache du navigateur lors de la modification des fichiers Javascript et CSS.  

> :heavy_check_mark: **Commande dotnet run**: La commande `dotnet run` permet de tester l'application en cours de développement. Pour cela, des fichiers binaires temporaires sont générés dans les dossiers `/bin/` et `/obj/`. Il est recommandé de rajouter ces dossiers au fichier `.gitignore`, voir de les supprimer avant de procéder à un commit/push.

<br>

<h4><ins> Tester le Système de connecteurs </ins></h4>

Dans une Console de Commande (cmd - bash -powershell):

```powershell linenums="1"
cd $Path_to_covidipedia_connectors_folder
dotnet run
```

Si la commande `dotnet run` est executée dans le dossier où se situe le fichier `covidipedia.connectors.csproj`, un système d'hosting Microsoft va se lancer. Au bout de quelques secondes, le service aura terminé la mise à jour de la base de données, et le système d'hosting s'arrêtera de lui même.

> :heavy_check_mark: **Commande dotnet run**: La commande `dotnet run` permet de tester l'application en cours de développement. Pour cela, des fichiers binaires temporaires sont générés dans les dossiers `/bin/` et `/obj/`. Il est recommandé de rajouter ces dossiers au fichier `.gitignore`, voir de les supprimer avant de procéder à un commit/push.

---
</details>

## Création de binaires pour déploiement en production
