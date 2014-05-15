CREATE TABLE [dbo].[Call]
(
	phone_number nvarchar(255),
	cust_ID nvarchar(255) NOT NULL FOREIGN KEY REFERENCES Customers(cust_ID),
	CONSTRAINT pk_Call PRIMARY KEY(phone_number, cust_ID)
)
