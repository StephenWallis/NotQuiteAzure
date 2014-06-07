CREATE TABLE [dbo].[Call](
	[phone_number] [nvarchar](255) NOT NULL,
	[custNo] [nvarchar](255) NOT NULL,
 CONSTRAINT [pk_Call] PRIMARY KEY CLUSTERED 
(
	[phone_number] ASC,
	[custNo] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
) 

GO