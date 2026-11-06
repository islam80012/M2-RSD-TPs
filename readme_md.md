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