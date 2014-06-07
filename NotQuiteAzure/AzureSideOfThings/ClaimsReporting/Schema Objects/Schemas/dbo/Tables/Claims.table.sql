CREATE TABLE [dbo].[Claims](
	[claim_ID] [nvarchar](255) NOT NULL,
	[cust_ID] [nvarchar](255) NOT NULL,
	[longatude] [nvarchar](255) NOT NULL,
	[latitude] [nvarchar](255) NOT NULL,
	[policy_ID] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[claim_ID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
) 

GO