CREATE DATABASE Barwon_Health
CREATE SCHEMA Manangment

CREATE TABLE Manangment.Patient(
    P_UR_Number INT PRIMARY KEY,
    P_Name VARCHAR(100),
    P_Address VARCHAR(255),
    P_Age INT,
    P_Phone VARCHAR(14),
    P_Email VARCHAR(50),
    P_Medicare_Number VARCHAR(11),
)


CREATE TABLE Manangment.Doctors(
    D_Id INT PRIMARY KEY,
    D_Name VARCHAR(100),
    years_of_experience INT,
    D_Specialty VARCHAR(50),
    D_Phone VARCHAR(14),
	P_UR_Number INT,

	 FOREIGN KEY (P_UR_Number) 
     REFERENCES Manangment.Patient(P_UR_Number)
)

CREATE TABLE Manangment.Drugs(
    Drug_Id INT PRIMARY KEY,
    Drug_Name VARCHAR(100) ,
    Drug_Strength VARCHAR(20),
)

CREATE TABLE Manangment.Prescriptions(
    Prescription_Id INT PRIMARY KEY,
    Prescription_Date DATE ,
    Quantity INT,
)

CREATE TABLE Manangment.Companies(
    Company_ID INT PRIMARY KEY,
    C_Name VARCHAR(100),
    C_Address VARCHAR(100),
    C_Phone VARCHAR(14),
)



CREATE TABLE Manangment.Doctors_Prescriptions(
    D_Id INT,
    Prescription_Id INT,
    PRIMARY KEY (D_Id, Prescription_Id),
    FOREIGN KEY (D_Id) REFERENCES Manangment.Doctors(D_Id),
    FOREIGN KEY (Prescription_Id) REFERENCES Manangment.Prescriptions(Prescription_Id),
)

CREATE TABLE Manangment.Patient_Prescriptions(
    P_UR_Number INT,
    Prescription_Id INT,
    PRIMARY KEY (P_UR_Number, Prescription_Id),
    FOREIGN KEY (P_UR_Number) REFERENCES Manangment.Patient(P_UR_Number),
    FOREIGN KEY (Prescription_Id) REFERENCES Manangment.Prescriptions(Prescription_Id),
)

CREATE TABLE Manangment.Drugs_Prescriptions(
    Drug_Id INT,
    Prescription_Id INT,
    PRIMARY KEY (Drug_Id, Prescription_Id),
    FOREIGN KEY (Drug_Id) REFERENCES Manangment.Drugs(Drug_Id),
    FOREIGN KEY (Prescription_Id) REFERENCES Manangment.Prescriptions(Prescription_Id),
)

CREATE TABLE Manangment.Drugs_Companies(
    Drug_Id INT,
    Company_ID INT,
    PRIMARY KEY (Drug_Id, Company_ID),
    FOREIGN KEY (Drug_Id) REFERENCES Manangment.Drugs(Drug_Id) ON DELETE CASCADE,
    FOREIGN KEY (Company_ID) REFERENCES Manangment.Companies(Company_ID) ON DELETE CASCADE,
)



