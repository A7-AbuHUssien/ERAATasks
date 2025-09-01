-- CREATE DATABASE Prescription_System;
USE Prescription_System;


CREATE TABLE Person (
    Person_ID INT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Address VARCHAR(200),
    Email VARCHAR(100),
    Phone VARCHAR(20)
);

CREATE TABLE Doctors (
    Doctor_ID INT PRIMARY KEY,
    Person_ID INT NOT NULL,
    Specialty VARCHAR(100),
    YearsOfExperience INT,
    FOREIGN KEY (Person_ID) REFERENCES Person(Person_ID)
);

CREATE TABLE Patients (
    URNumber INT PRIMARY KEY,
    Person_ID INT NOT NULL,
    Age INT,
    MedicareNumber VARCHAR(50),
    PrimaryDoctorID INT,
    FOREIGN KEY (Person_ID) REFERENCES Person(Person_ID),
    FOREIGN KEY (PrimaryDoctorID) REFERENCES Doctors(Doctor_ID)
);

CREATE TABLE PharmaceuticalCompanies (
    Company_ID INT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Address VARCHAR(200),
    Phone VARCHAR(20)
);

CREATE TABLE Drugs (
    Drug_ID INT PRIMARY KEY,
    TradeName VARCHAR(100) NOT NULL,
    Strength VARCHAR(50),
    Company_ID INT NOT NULL,
    FOREIGN KEY (Company_ID) REFERENCES PharmaceuticalCompanies(Company_ID) ON DELETE CASCADE
);


CREATE TABLE Prescriptions (
    Prescription_ID INT PRIMARY KEY,
    URNumber INT NOT NULL,
    Doctor_ID INT NOT NULL,
    PrescriptionDate DATE NOT NULL,
    FOREIGN KEY (URNumber) REFERENCES Patients(URNumber),
    FOREIGN KEY (Doctor_ID) REFERENCES Doctors(Doctor_ID),
);

CREATE TABLE PrescriptionItems (
    PrescriptionItem_ID INT PRIMARY KEY,
    Prescription_ID INT NOT NULL,
    Drug_ID INT NOT NULL,
    Quantity INT NOT NULL,
    Dosage VARCHAR(100),
    FOREIGN KEY (Prescription_ID) REFERENCES Prescriptions(Prescription_ID) ON DELETE CASCADE,
    FOREIGN KEY (Drug_ID) REFERENCES Drugs(Drug_ID)
);
