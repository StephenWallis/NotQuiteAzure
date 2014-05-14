CREATE TABLE [dbo].[Customers]
(
	cust_ID nvarchar(255) NOT NULL PRIMARY KEY, 
	custNo int,
	Name varchar(255) NOT NULL,
	DOB date,
	home_phone nvarchar(255),
	work_phone nvarchar(255),
	address nvarchar(255),
	email nvarchar(255)	
)


