USE Prescription_System;

INSERT INTO Person VALUES
(1, 'Dr. Alice Morgan', '123 Elm St', 'alice.morgan@example.com', '555-1234'),
(2, 'John Doe', '456 Oak St', 'john.doe@example.com', '555-5678'),
(3, 'Dr. Bob Smith', '789 Pine St', 'bob.smith@example.com', '555-9012'),
(4, 'Jane Roe', '321 Maple St', 'jane.roe@example.com', '555-3456'),
(5, 'Dr. Clara Oswald', '654 Birch St', 'clara.oswald@example.com', '555-7890'),
(6, 'Tom Hanks', '987 Cedar St', 'tom.hanks@example.com', '555-2345'),
(7, 'Dr. Gregory House', '111 Diagnosis Ln', 'greg.house@example.com', '555-6789'),
(8, 'Emily Blunt', '222 Sunset Blvd', 'emily.blunt@example.com', '555-4321'),
(9, 'Dr. Meredith Grey', '333 Anatomy Rd', 'meredith.grey@example.com', '555-8765'),
(10, 'Chris Evans', '444 Hero Ave', 'chris.evans@example.com', '555-6543');

INSERT INTO Doctors VALUES
(101, 1, 'Cardiology', 15),
(102, 3, 'Neurology', 10),
(103, 5, 'Pediatrics', 8),
(104, 7, 'Diagnostics', 20),
(105, 9, 'General Surgery', 12);

INSERT INTO Patients VALUES
(201, 2, 45, 'MED123456', 101),
(202, 4, 30, 'MED654321', 102),
(203, 6, 55, 'MED789012', 103),
(204, 8, 28, 'MED345678', 104),
(205, 10, 40, 'MED901234', 105),
(206, 2, 47, 'MED567890', 101),
(207, 4, 33, 'MED234567', 102),
(208, 6, 59, 'MED890123', 103),
(209, 8, 26, 'MED678901', 104),
(210, 10, 42, 'MED012345', 105);

INSERT INTO PharmaceuticalCompanies VALUES
(301, 'PharmaCorp', '100 Industry Rd', '555-1111'),
(302, 'MediHealth', '200 Wellness Blvd', '555-2222'),
(303, 'BioGenix', '300 Lab St', '555-3333'),
(304, 'CureAll Inc.', '400 Remedy Ave', '555-4444'),
(305, 'LifeMed', '500 Vitality Ln', '555-5555');

INSERT INTO Drugs VALUES
(401, 'Atenolol', '50mg', 301),
(402, 'Ibuprofen', '200mg', 302),
(403, 'Paracetamol', '500mg', 303),
(404, 'Amoxicillin', '250mg', 304),
(405, 'Metformin', '850mg', 305),
(406, 'Simvastatin', '20mg', 301),
(407, 'Omeprazole', '40mg', 302),
(408, 'Losartan', '100mg', 303),
(409, 'Ciprofloxacin', '500mg', 304),
(410, 'Hydrochlorothiazide', '25mg', 305);

INSERT INTO Prescriptions VALUES
(501, 201, 101, '2025-08-20'),
(502, 202, 102, '2025-08-21'),
(503, 203, 103, '2025-08-22'),
(504, 204, 104, '2025-08-23'),
(505, 205, 105, '2025-08-24'),
(506, 206, 101, '2025-08-25'),
(507, 207, 102, '2025-08-26'),
(508, 208, 103, '2025-08-27'),
(509, 209, 104, '2025-08-28'),
(510, 210, 105, '2025-08-29');


INSERT INTO PrescriptionItems VALUES
(601, 501, 401, 30, '1 tablet daily'),
(602, 502, 402, 20, '2 tablets after meals'),
(603, 503, 403, 15, '1 tablet every 6 hours'),
(604, 504, 404, 10, '1 capsule twice daily'),
(605, 505, 405, 60, '1 tablet morning and night'),
(606, 506, 406, 30, '1 tablet daily'),
(607, 507, 407, 20, '1 capsule before breakfast'),
(608, 508, 408, 25, '1 tablet daily'),
(609, 509, 409, 10, '1 tablet every 12 hours'),
(610, 510, 410, 40, '1 tablet in the morning');
