-- Database creation and schema for Transport Management System
CREATE DATABASE gestion_transport1;
USE gestion_transport1;

-- Drop existing tables if they exist
DROP TABLE IF EXISTS Rappelcam, Dépense, Facture, Camion, Voyage, Maintenance, Client, 
                     Chauffeur, Produit, Rappelchauff, Paiements, Frigo, Employés, History;

-- Table Employés (Users)
CREATE TABLE Employés (
    user_id INT IDENTITY(1,1) PRIMARY KEY,
    Utilisateur VARCHAR(255),
    mot_de_pass VARCHAR(255)
);

-- Table Client
CREATE TABLE Client (
    Num_Clt INT IDENTITY(1,1) PRIMARY KEY,
    Nom_Clt VARCHAR(255),
    Adresse VARCHAR(255),
    email VARCHAR(255),
    phone VARCHAR(255)
);

-- Table Produit (Products)
CREATE TABLE Produit (
    Ref_Prod INT IDENTITY(1,1) PRIMARY KEY,
    Nature_Prod VARCHAR(255),
    Poids DECIMAL(10, 2),
    Description_prod TEXT
);

-- Table Chauffeur (Drivers)
CREATE TABLE Chauffeur (
    Num_Chauff INT IDENTITY(1,1) PRIMARY KEY,
    Nom_Chauff VARCHAR(255),
    Prenom_Chauff VARCHAR(255),
    phone VARCHAR(255),
    Gender VARCHAR(10),
    age INT,
    adresse VARCHAR(255),
    date_adhésion DATE,
    CIN VARCHAR(255),
    Permis VARCHAR(255),
    passport VARCHAR(255),
    status_chauff VARCHAR(50)
);

-- Table Camion (Trucks)
CREATE TABLE Camion (
    Num_Cam INT IDENTITY(1,1) PRIMARY KEY,
    Modele VARCHAR(255),
    Matricule INT,
    assurance VARCHAR(255)
);

-- Table Voyage (Trips)
CREATE TABLE Voyage (
    Num_Voyage INT IDENTITY(1,1) PRIMARY KEY,
    Date_Emission DATE,
    Date_Réception DATE,
    Ville_Dep VARCHAR(255),
    Ville_Arr VARCHAR(255),
    Statut VARCHAR(50),
    Num_Clt INT FOREIGN KEY REFERENCES Client(Num_Clt) ON DELETE CASCADE,
    Ref_Prod INT FOREIGN KEY REFERENCES Produit(Ref_Prod) ON DELETE NO ACTION,
    Num_Cam INT FOREIGN KEY REFERENCES Camion(Num_Cam) ON DELETE NO ACTION,
    Num_Chauff INT FOREIGN KEY REFERENCES Chauffeur(Num_Chauff) ON DELETE NO ACTION,
    tracking_num VARCHAR(255)
);

-- Table Paiements (Payments)
CREATE TABLE Paiements (
    Paiement_Id INT IDENTITY(1,1) PRIMARY KEY,
    Date_Paiement DATE,
    Montant_Total DECIMAL(10, 2),
    Paiement_Method VARCHAR(255),
    Description TEXT,
    Statut VARCHAR(50),
    Num_Voyage INT FOREIGN KEY REFERENCES Voyage(Num_Voyage) ON DELETE NO ACTION
);

-- Table Dépense (Expenses)
CREATE TABLE Dépense (
    dépense_num INT IDENTITY(1,1) PRIMARY KEY,
    date_dépense DATE,
    carburant DECIMAL(10, 2),
    péages DECIMAL(10, 2),
    maintenance DECIMAL(10, 2),
    chauffeur_sal DECIMAL(10, 2),
    transitaire DECIMAL(10, 2),
    parkings DECIMAL(10, 2),
    marché DECIMAL(10, 2),
    Num_Voyage INT FOREIGN KEY REFERENCES Voyage(Num_Voyage) ON DELETE CASCADE
);

-- Table Maintenance
CREATE TABLE Maintenance (
    maintenance_num INT IDENTITY(1,1) PRIMARY KEY,
    MaintenanceType VARCHAR(255),
    MaintenanceDate DATE,
    Description_main TEXT,
    statut_main VARCHAR(50),
    Num_Cam INT FOREIGN KEY REFERENCES Camion(Num_Cam) ON DELETE CASCADE
);

-- Table Rappelchauff (Driver Reminders)
CREATE TABLE Rappelchauff (
    Num_rapp INT IDENTITY(1,1) PRIMARY KEY,
    date_rapp DATE,
    description_rapp TEXT,
    Num_Chauff INT FOREIGN KEY REFERENCES Chauffeur(Num_Chauff) ON DELETE NO ACTION
);

-- Table Rappelcam (Vehicle Reminders)
CREATE TABLE Rappelcam (
    Num_rapp INT IDENTITY(1,1) PRIMARY KEY,
    date_rapp DATE,
    description_rapp TEXT,
    Num_Cam INT FOREIGN KEY REFERENCES Camion(Num_Cam) ON DELETE NO ACTION
);

-- Table Frigo (Refrigeration Units)
CREATE TABLE Frigo (
    Num_frig INT IDENTITY(1,1) PRIMARY KEY,
    capacity DECIMAL(10, 2),
    Matricule_frig INT,
    Num_Cam INT FOREIGN KEY REFERENCES Camion(Num_Cam) ON DELETE CASCADE
);

-- Table Facture (Invoices)
CREATE TABLE Facture (
    Num_Facture INT IDENTITY(1,1) PRIMARY KEY,
    Date_facture DATE,
    Num_Voyage INT FOREIGN KEY REFERENCES Voyage(Num_Voyage) ON DELETE NO ACTION,
    Num_Clt INT FOREIGN KEY REFERENCES Client(Num_Clt) ON DELETE CASCADE,
    Ref_Prod INT FOREIGN KEY REFERENCES Produit(Ref_Prod) ON DELETE NO ACTION,
    Num_Cam INT FOREIGN KEY REFERENCES Camion(Num_Cam) ON DELETE NO ACTION,
    Num_frig INT FOREIGN KEY REFERENCES Frigo(Num_frig) ON DELETE NO ACTION,
    Paiement_Id INT FOREIGN KEY REFERENCES Paiements(Paiement_Id) ON DELETE NO ACTION
);

-- Table History (Action Logs)
CREATE TABLE History (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Utilisateur NVARCHAR(50),
    Action NVARCHAR(MAX),
    Timestamp DATETIME DEFAULT GETDATE()
);

-- Sample data for Employés
INSERT INTO Employés (Utilisateur, mot_de_pass) VALUES ('Badr', 'Badr'), ('Admin', 'Admin');

-- Useful query samples

-- Get all reminders (both truck and driver) for dashboard
SELECT 
    'Chauffeur' AS Type,
    C.Nom_Chauff AS Concerne,
    R.date_rapp AS Date,
    R.description_rapp AS Description
FROM 
    Rappelchauff R
JOIN 
    Chauffeur C ON R.Num_Chauff = C.Num_Chauff
UNION ALL
SELECT 
    'Camion' AS Type,
    CAST(M.Matricule AS VARCHAR(50)) AS Concerne,
    R.date_rapp AS Date,
    R.description_rapp AS Description
FROM 
    Rappelcam R
JOIN 
    Camion M ON R.Num_Cam = M.Num_Cam;

-- Get invoice details
SELECT 
    c.Matricule AS Camion_Matricule,
    f.Matricule_frig AS Frigo_Matricule,
    clt.Nom_Clt AS Client_Nom,
    clt.Adresse AS Client_Adresse,
    v.Date_Emission AS Date_Facture,
    p.Nature_Prod AS Designation,
    v.Ville_Dep AS Ville_Dep,
    v.Ville_Arr AS Ville_Arr,
    pm.Montant_Total AS Montant_Total,
    pm.Paiement_Method AS Paiement_Method
FROM 
    Voyage v
JOIN 
    Client clt ON v.Num_Clt = clt.Num_Clt
JOIN 
    Produit p ON v.Ref_Prod = p.Ref_Prod
JOIN 
    Camion c ON v.Num_Cam = c.Num_Cam
JOIN 
    Frigo f ON c.Num_Cam = f.Num_Cam
JOIN 
    Paiements pm ON v.Num_Voyage = pm.Num_Voyage
WHERE 
    v.Num_Voyage = 3;

-- Dashboard statistics
-- Count active voyages
SELECT COUNT(*) FROM Voyage WHERE Statut <> 'Annulé';

-- Sum total payments
SELECT SUM(Montant_Total) FROM Paiements;

-- Calculate total expenses
SELECT 
    ISNULL(SUM(marché), 0) +
    ISNULL(SUM(parkings), 0) +
    ISNULL(SUM(transitaire), 0) +
    ISNULL(SUM(chauffeur_sal), 0) +
    ISNULL(SUM(maintenance), 0) +
    ISNULL(SUM(péages), 0) +
    ISNULL(SUM(carburant), 0) 
FROM Dépense;