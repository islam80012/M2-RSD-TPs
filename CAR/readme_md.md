# TP4 : Persistence des Données avec ADO.NET et Oracle

Ce projet contient l'ensemble des exemples de travaux pratiques (TP4) portant sur l'utilisation d'**ADO.NET** avec le SGBD **Oracle** en C# (.NET Framework), couvrant les applications Console et Windows Forms (SELECT, INSERT, DELETE, UPDATE).

---

## 1. Prérequis et Téléchargements

Pour exécuter ce TP, vous devez avoir installé :
- **Visual Studio** (avec la charge de travail Développement Desktop .NET).
- **Oracle Database Express Edition (XE)** : [Télécharger Oracle XE](https://www.oracle.com/database/technologies/xe-downloads.html)
- **Oracle SQL Developer** : [Télécharger SQL Developer](https://www.oracle.com/database/sqldeveloper/technologies/download/)

---

## 2. Configuration d'Oracle et Création de l'Utilisateur

### Étape A : Connexion Administrateur (SYSTEM)
Ouvrez **SQL Developer**, ajoutez une nouvelle connexion avec les paramètres suivants :

| Champ | Valeur |
| :--- | :--- |
| **Connection Name** | `Oracle_Admin` |
| **Username** | `SYSTEM` |
| **Password** | *(Mot de passe défini lors de l'installation)* |
| **Hostname** | `localhost` |
| **Port** | `1521` |
| **Connection Type** | `Basic` |
| **Service Name** | `XEPDB1` |

---

### Étape B : Création de l'utilisateur `oracle` et de la table `Etudiant`
Une fois connecté avec `SYSTEM`, exécutez le script SQL suivant pour créer l'utilisateur et lui attribuer les privilèges :

```sql
-- 1. Création de l'utilisateur
CREATE USER oracle IDENTIFIED BY manager;
GRANT DBA TO oracle WITH ADMIN OPTION;
```

---

### Étape C : Connexion avec l'utilisateur `oracle`
Créez une seconde connexion dans SQL Developer pour l'utilisateur de l'application :

| Champ | Valeur |
| :--- | :--- |
| **Connection Name** | `Oracle_TP4` |
| **Username** | `oracle` |
| **Password** | `manager` |
| **Hostname** | `localhost` |
| **Port** | `1521` |
| **Connection Type** | `Basic` |
| **Service Name** | `XEPDB1` |

Connectez-vous avec `Oracle_TP4` et exécutez le script de création de la table :

```sql
-- Création de la table Etudiant
CREATE TABLE Etudiant (
    matricule NUMBER(5),
    nom VARCHAR2(20),
    prenom VARCHAR2(20),
    CONSTRAINT etudiant_pk PRIMARY KEY (matricule) ENABLE
);

-- Insertion de jeu de test
INSERT INTO Etudiant VALUES (1, 'boulkrinat', 'samia');
INSERT INTO Etudiant VALUES (2, 'hachichi', 'assia');
INSERT INTO Etudiant VALUES (3, 'benhamouda', 'ilham');
INSERT INTO Etudiant VALUES (4, 'belguerche', 'nadia');
INSERT INTO Etudiant VALUES (5, 'chenait', 'manel');
INSERT INTO Etudiant VALUES (6, 'zebbane', 'kahina');
COMMIT;
```

---

## 3. Configuration des Projets Visual Studio

Pour chaque projet C# de la solution (`Ado-Exemple1` à `Ado-Exemple5`), il est impératif d'effectuer deux configurations matérielles et logicielles :

### 1. Ajout de la Référence `Oracle.DataAccess.dll`
1. Faites un clic droit sur le projet > **Ajouter** > **Référence...**
2. Allez dans l'onglet **Parcourir** et cliquez sur le bouton **Parcourir...** en bas.
3. Obtenez la DLL en naviguant vers le chemin d'installation local :
   ```text
   D:\Oracle\dbhomeXE\ODP.NET\bin\4\Oracle.DataAccess.dll
   ```
4. Cochez `Oracle.DataAccess.dll` puis validez avec **OK**.

---

### 2. Configuration de l'Architecture (Résolution de l'erreur `BadImageFormatException`)
Pour éviter l'erreur de chargement du module natif Oracle (`System.BadImageFormatException`) :
1. Fait un clic droit sur le projet > **Propriétés**.
2. Allez dans l'onglet **Générer** (Build).
3. Changez la **Plateforme cible** (Target Platform) de `Any CPU` vers **`x64`**.
4. Enregistrez et nettoyez la solution (**Générer** > **Nettoyer la solution**) avant d'exécuter (**F5**).

---

## 4. Chaîne de Connexion C#

Dans vos fichiers de code C# (`Connection.cs` ou `Form1.cs`), la chaîne de connexion doit cibler le service **XEPDB1** :

```csharp
string oradb = "Data Source=localhost:1521/XEPDB1; User Id=oracle; Password=manager;";
OracleConnection conn = new OracleConnection(oradb);
```

---

## 5. TP4 – Partie 2 : Application Distribuée avec C#, Remoting et Oracle

Cette deuxième partie du TP4 consiste à développer une application de gestion des étudiants en utilisant une **architecture à trois tiers** :

1. **Client Windows Forms** : interface graphique permettant d'ajouter, afficher, rechercher, modifier et supprimer des étudiants.
2. **Serveur Console** : expose les opérations à distance à travers .NET Remoting et l'interface partagée.
3. **Base de données Oracle** : assure la persistance des données à l'aide d'ADO.NET et de `Oracle.DataAccess.Client`.

### 5.1. Architecture du projet

Le projet est organisé en trois parties :

- `RemotingInterface` : bibliothèque de classes contenant l'interface `IRemoteOperation`, qui définit les méthodes accessibles à distance.
- `RemotingServer` : application Console contenant la classe `RemoteOperation`, qui implémente les méthodes CRUD et communique avec Oracle.
- `RemotingClient` : application Windows Forms qui appelle les méthodes du serveur et affiche les résultats dans un `DataGridView`.

### 5.2. Configuration de la connexion Oracle

La chaîne de connexion utilisée dans le serveur est :

```csharp
private string oradb =
    "Data Source=localhost:1521/XEPDB1; User Id=oracle; Password=manager;";
```

La connexion est centralisée dans la classe `RemoteOperation` afin d'éviter de répéter la chaîne de connexion dans chaque méthode.

Une méthode dédiée permet de créer les connexions :

```csharp
private OracleConnection GetConnection()
{
    return new OracleConnection(oradb);
}
```

Chaque opération ouvre et libère sa propre connexion avec `using`.

### 5.3. Opérations disponibles

L'application permet d'effectuer les opérations suivantes sur la table `Etudiant` :

| Méthode | Opération SQL | Description |
|---|---|---|
| `Afficher()` | SELECT | Afficher tous les étudiants |
| `Ajouter()` | INSERT | Ajouter un étudiant |
| `Supprimer()` | DELETE | Supprimer un étudiant par matricule |
| `Modifier()` | UPDATE | Modifier les informations d'un étudiant |
| `Rechercher()` | SELECT | Rechercher un étudiant par matricule |

### 5.4. Exécution du projet

Pour lancer correctement l'application :

1. Vérifier que le service Oracle `XEPDB1` est démarré.
2. Vérifier que la table `Etudiant` existe et que l'utilisateur `oracle` possède les privilèges nécessaires.
3. Vérifier que la référence `Oracle.DataAccess.dll` est ajoutée aux projets concernés.
4. Vérifier la compatibilité de la plateforme cible (`x64` si nécessaire selon l'installation Oracle).
5. Démarrer le projet `RemotingServer` en premier.
6. Démarrer ensuite le projet `RemotingClient`.
7. Tester les opérations CRUD depuis l'interface Windows Forms.

**Remarque :** Cette partie complète les exemples ADO.NET de la première partie du TP4 en introduisant la communication distante entre un client et un serveur.

---