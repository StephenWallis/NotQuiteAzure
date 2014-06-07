/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
This script has been edited to work for Azure.			
--------------------------------------------------------------------------------------
*/

SET DATEFORMAT DMY

/*Customers*/

INSERT INTO Customers([cust_ID],[custNo],[Name],[DOB],[home_phone],[work_phone],[address],[email])
VALUES
('1079607', 0, 'Bob Jones', '12/3/1982', '03 312 8967', '03 345 8077', '128 Random Street, RD24, Kaiapoi, 1895', 'bob.jones@hotmail.com'),
('2349981', 1, 'Steve Hadwin', '12/9/1966', '03 313 4502', '03 344 7867', 'Northwood Towers, Ashburton, 7098', 'steve.hadwin@hotmail.com'),
('1098767', 2, 'Tanya Smith', '12/3/1967', '03 312 7810', '03 365 0098', '16 Westbourne Street, Ashburton, 9087', 'tanya1203@hotmail.com');
GO


/*Policy*/
INSERT INTO Policy(policy_ID, custno, vehicle_make, vehicle_model, registration)
VALUES
('1079607M01', 0 , 'Skoda', 'Fabia', 'EUH509'),
('1079607M02', 0, 'Toyota', 'Hilux Surf', 'EBY567'),
('1079607M03', 0, 'Vauxhall', 'Astra', 'EDF524'),
('2349981M01', 1, 'Hyundai', 'Santa Fe', 'EEE443'),
('1098767M01', 2, 'Toyota', 'Starlet', 'LTK007'),
('1098767M02', 2, 'Porche', '911', 'ALG800');

/*Claims*/

INSERT INTO Claims(policy_ID, claim_ID, cust_ID, longatude, latitude)
VALUES
('1079607M02','1079607C01','1079607','-43.3757205','172.5427305'),
('2349981M01','2349981C01','2349981','-43.3757205','172.5427305');

/*Calls*/

INSERT INTO Call(custno, phone_number)
VALUES
(0, '027 334 9987'),
(1, '03 477 8800');