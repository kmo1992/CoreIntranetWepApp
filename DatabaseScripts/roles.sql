DROP TABLE IF EXISTS [dbo].[RoleMember]
DROP TABLE IF EXISTS [dbo].[AdUser]
DROP TABLE IF EXISTS [dbo].[Role]

CREATE TABLE [dbo].[Role](
	[RoleId] smallint IDENTITY(1,1) NOT NULL PRIMARY KEY CLUSTERED,
	[RoleName] nvarchar(30) NOT NULL
	)
GO

CREATE TABLE [dbo].[AdUser](
	[AdUserId] int IDENTITY(1,1) NOT NULL PRIMARY KEY CLUSTERED,
	[Username] nvarchar(30) NOT NULL
	)
GO

CREATE TABLE [dbo].[RoleMember](
	[RoleId] smallint NOT NULL,
	[AdUserId] int NOT NULL,
	CONSTRAINT [PK_role_member] PRIMARY KEY CLUSTERED ([RoleId], [AdUserId])
	)
GO

ALTER TABLE [dbo].[RoleMember]  WITH CHECK ADD  CONSTRAINT [FK_RoleMember_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([RoleId])
GO

ALTER TABLE [dbo].[RoleMember] CHECK CONSTRAINT [FK_RoleMember_Role]
GO

ALTER TABLE [dbo].[RoleMember]  WITH CHECK ADD  CONSTRAINT [FK_RoleMember_AdUser] FOREIGN KEY([AdUserId])
REFERENCES [dbo].[AdUser] ([AdUserId])
GO

ALTER TABLE [dbo].[RoleMember] CHECK CONSTRAINT [FK_RoleMember_AdUser]
GO

INSERT [dbo].[AdUser]
VALUES ('DOMAIN\john.doe')
	,('DOMAIN\jane.doe')
GO

INSERT [dbo].[Role]
VALUES ('User')
	,('Admin')
GO

INSERT [dbo].[RoleMember]
VALUES (1,1)
	,(2,1)
	,(2,2)
GO
