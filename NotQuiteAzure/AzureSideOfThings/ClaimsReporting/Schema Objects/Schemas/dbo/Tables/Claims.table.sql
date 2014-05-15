CREATE TABLE [dbo].[Claims](
	[claim_ID] [nvarchar](255) NOT NULL,
	[cust_ID] [nvarchar](255) NOT NULL,
	[longatude] [nvarchar](255) NOT NULL,
	[latitude] [nvarchar](255) NOT NULL,
    [policy_ID] [nvarchar](255) NOT NULL
PRIMARY KEY CLUSTERED 
(
	[claim_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Claims]  WITH NOCHECK ADD FOREIGN KEY([cust_ID])
REFERENCES [dbo].[Customers] ([cust_ID])
GO

ALTER TABLE [dbo].[Claims]  WITH NOCHECK ADD FOREIGN KEY([policy_ID])
REFERENCES [dbo].[Policy] ([policy_ID])
GO