CREATE TABLE [dbo].[Claims]
(
	claim_ID nvarchar(255) PRIMARY KEY,
	policy_ID nvarchar(255) NOT NULL FOREIGN KEY REFERENCES Policy(policy_ID),
	cust_ID nvarchar(255) NOT NULL FOREIGN KEY REFERENCES Customers(cust_ID) 
)