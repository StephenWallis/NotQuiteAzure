CREATE TABLE [dbo].[Policy]
(
	policy_ID nvarchar(255) PRIMARY KEY, 
	vehicle_make nvarchar(255),
	vehicle_model nvarchar(255),
	registration nvarchar(255) NOT NULL,
	cust_ID nvarchar(255) NOT NULL FOREIGN KEY REFERENCES Customers(cust_ID)
)
