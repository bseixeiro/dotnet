Ceci est le TP

Pour lancer le projet il faut dotnet en version 8 ou superieur
pour verifier cela

```sh
dotnet --version
```

Actuellement l'app fonctionne avec une BDD Sqlite donc un fichier est compris dans le livrable mais si jamais vous souhaiter utiliser une autre BDD veuillez trouver le driver correspondant dans les packages nugget et installer une version '8.0.11' pour une meilleur compatibiliter, veuillez a changer egalement le Default Connexion dans le appsettings.json

L'app utilise entityframework, il vous suffit de taper deux commande quand votre service de BDD est pret

```sh
dotnet ef migrations add [migrationsName]
dotnet ef database update
```

Dans le cas ou une erreur se produit, supprimer le dossier de migrations et verifier que dotnet-ef est bien installer.

pour lancer l app :

```sh
dotnet run
```
