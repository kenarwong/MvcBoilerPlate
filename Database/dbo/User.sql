CREATE TABLE [dbo].[User]
(
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Identifier] [varchar](100) NOT NULL,
	[FirstName] [nvarchar](30) NOT NULL,
	[LastName] [nvarchar](30) NOT NULL,
	[UserName] [nvarchar](30) NOT NULL,
	[Domain] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](256) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
