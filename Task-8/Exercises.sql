USE Prescription_System;
GO

-- Making Some Views To make work with data easiest
CREATE VIEW PatientData
AS
(
    SELECT p.URNumber, 
    per.Name,
    p.MedicareNumber,
    per.Phone,
    per.Email,
    p.PrimaryDoctorID,
    p.Age,
    per.Address
    FROM Person per JOIN Patients p ON p.Person_ID = per.Person_ID
);
GO

CREATE VIEW DoctorData
AS
(
    SELECT 
    d.Doctor_ID,
    p.Name,
    p.Phone,
    p.Email,
    p.Address,
    d.Specialty,
    d.YearsOfExperience
    FROM Doctors d JOIN Person p ON p.Person_ID = d.Person_ID
);
GO
------------------------------------------------------------------------------------------


-- 1
SELECT *FROM DoctorData;

-- 2
SELECT *FROM PatientData ORDER BY Age ASC;

-- 3
SELECT *
FROM PatientData
ORDER BY URNumber
OFFSET 4 ROWS
FETCH NEXT 10 ROWS ONLY;

-- 4
SELECT TOP 5 *
FROM DoctorData;

-- 5
SELECT DISTINCT Address
FROM PatientData;

-- 6
SELECT *
FROM PatientData
WHERE Age = 25;

-- 7
SELECT *
FROM PatientData
WHERE Email IS NULL;

-- 8
SELECT *
FROM DoctorData d
WHERE d.YearsOfExperience > 5
AND d.Specialty = 'Cardiology';

-- 9
SELECT *
FROM DoctorData d
WHERE d.Specialty IN ('Dermatology', 'Oncology');

-- 10
SELECT *
FROM PatientData
WHERE Age BETWEEN 18 AND 30;

-- 11
SELECT *
FROM DoctorData
WHERE Name LIKE 'Dr.%';

-- 12
SELECT 
    Name AS DoctorName,
    Email AS DoctorEmail
FROM DoctorData AS D;

-- 13
SELECT 
    P.Prescription_ID,
    CAST(pit.Dosage AS varchar )+ CAST(pit.Quantity AS varchar)  AS Medicine,
    Pat.Name AS PatientName
FROM Prescriptions AS P
JOIN PatientData AS Pat
    ON P.URNumber = Pat.URNumber
JOIN PrescriptionItems pit
    ON pit.Prescription_ID = P.Prescription_ID;


-- 14
SELECT 
    Address,
    COUNT(*) AS PatientCount
FROM PatientData
GROUP BY Address;

-- 15
SELECT 
    Address,
    COUNT(*) AS PatientCount
FROM PatientData
GROUP BY Address
HAVING COUNT(*) > 3;

-- 16
SELECT *
FROM PatientData AS Pat
WHERE EXISTS (
    SELECT 1
    FROM Prescriptions AS P
    WHERE P.URNumber = Pat.URNumber
);

-- 17
SELECT Name, Email
FROM DoctorData
UNION
SELECT Name, Email
FROM PatientData;

-- 18
INSERT INTO Person (Person_ID, Name, Address, Email, Phone)
VALUES (11, 'Dr. Ahmed Esam', 'Mit-Ghamr 123st','ahmed.Esam@gov.eg', '+201080724040');

INSERT INTO Doctors (Doctor_ID, Person_ID, Specialty, YearsOfExperience)
VALUES (106, 11, 'Cardiology', 10);

-- 19
INSERT INTO Person (Person_ID, Name, Address, Email, Phone)
VALUES 
    (12, 'Ali Hassan', 'Cairo 45st', 'ali.hassan@example.com', '+201011122233'),
    (13, 'Sara Ahmed', 'Alexandria 12st', 'sara.ahmed@example.com', '+201044455566'),
    (14, 'Omar Khaled', 'Giza 78st', NULL, '+201077788899');

INSERT INTO Patients (URNumber, Person_ID, Age, MedicareNumber, PrimaryDoctorID)
VALUES
    (211, 12, 25, 'M123456', 101),
    (212, 13, 30, 'M789012', 102),
    (213, 14, 22, 'M345678', 101);

-- 20
UPDATE P
SET P.Phone = '+201099988877'
FROM Person AS P
JOIN Doctors AS D
    ON P.Person_ID = D.Person_ID
WHERE D.Doctor_ID = 105;

-- 21
UPDATE P
SET P.Address = '123 New Street, Alexandria'
FROM Person AS P
JOIN Patients AS Pat
    ON P.Person_ID = Pat.Person_ID
JOIN Prescriptions AS PR
    ON Pat.URNumber = PR.URNumber
WHERE PR.Doctor_ID = 101;

-- 23
BEGIN TRANSACTION;
BEGIN TRY
    INSERT INTO Person (Person_ID, Name, Address, Email, Phone)
    VALUES (20, 'Dr. Mona Youssef', 'Cairo 15st', 'mona.youssef@example.com', '+201012345678');

    INSERT INTO Doctors (Doctor_ID, Person_ID, Specialty, YearsOfExperience)
    VALUES (5, 20, 'Neurology', 8);

    INSERT INTO Person (Person_ID, Name, Address, Email, Phone)
    VALUES (21, 'Khaled Sami', 'Giza 23st', 'khaled.sami@example.com', '+201098765432');

    INSERT INTO Patients (URNumber, Person_ID, Age, MedicareNumber, PrimaryDoctorID)
    VALUES (5, 21, 29, 'M123456', 5);

    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
END CATCH;
