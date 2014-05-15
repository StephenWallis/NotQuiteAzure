﻿CREATE TABLE [dbo].[Policy](
	[policy_ID] [nvarchar](255) NOT NULL,
	[vehicle_make] [nvarchar](255) NULL,
	[vehicle_model] [nvarchar](255) NULL,
	[registration] [nvarchar](255) NOT NULL,
	[custNo] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[policy_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

