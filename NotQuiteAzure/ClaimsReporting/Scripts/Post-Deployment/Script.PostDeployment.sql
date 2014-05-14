/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

/*Customers*/
SET DATEFORMAT DMY

INSERT INTO Customers(cust_ID, custNo, Name, DOB, home_phone, work_phone, address, email)
VALUES("1079607", 0, "Bob Jones", "12/3/1982", "03 312 8967", "03 345 8077", "128 Random Street, RD24, Kaiapoi, 1895", "bob.jones@hotmail.com");

INSERT INTO Customers(cust_ID, custNo, Name, DOB, home_phone, work_phone, address, email)
VALUES("2349981", 1, "Steve Hadwin", "12/9/1966", "03 313 4502", "03 344 7867", "Northwood Towers, Ashburton, 7098", "steve.hadwin@hotmail.com");

INSERT INTO Customers(cust_ID, custNo, Name, DOB, home_phone, work_phone, address, email)
VALUES("1098767", 2, "Tanya Smith", "12/3/1967", "03 312 7810", "03 365 0098", "16 Westbourne Street, Ashburton, 9087", "tanya1203@hotmail.com");

/*Policy*/
INSERT INTO Policy(policy_ID, cust_ID, vehicle_make, vehicle_model, registration)
VALUES("1079607M01", "1079607", "Skoda", "Fabia", "EUH509")

INSERT INTO Policy(policy_ID, cust_ID, vehicle_make, vehicle_model, registration)
VALUES("1079607M02", "1079607", "Toyota", "Hilux Surf", "EBY567")

INSERT INTO Policy(policy_ID, cust_ID, vehicle_make, vehicle_model, registration)
VALUES("1079607M03", "1079607", "Vauxhall", "Astra", "EDF524")

INSERT INTO Policy(policy_ID, cust_ID, vehicle_make, vehicle_model, registration)
VALUES("2349981M01", "2349981", "Hyundai", "Santa Fe", "EEE443")

INSERT INTO Policy(policy_ID, cust_ID, vehicle_make, vehicle_model, registration)
VALUES("1098767M01", "1098767", "Toyota", "Starlet", "LTK007")

INSERT INTO Policy(policy_ID, cust_ID, vehicle_make, vehicle_model, registration)
VALUES("1098767M02", "1098767", "Porche", "911", "ALG800")

/*Claims*/

INSERT INTO Claims(policy_ID, claim_ID, cust_ID)
VALUES("1079607M02","1079607C01","1079607")

INSERT INTO Claims(policy_ID, claim_ID, cust_ID)
VALUES("2349981M01","2349981C01","2349981")

/*Calls*/

INSERT INTO Call(cust_ID, phone_number)
VALUES("1079607", "027 334 9987");

INSERT INTO Call(cust_ID, phone_number)
VALUES("2349981", "03 477 8800");

