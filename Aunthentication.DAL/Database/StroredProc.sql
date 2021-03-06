USE AUTOPRO
GO 

/* ROLE */

CREATE PROCEDURE spRoleGet
AS
SELECT * FROM PRO_ROLE
GO

CREATE PROCEDURE spRoleGetbyId @Id INT
AS
SELECT * FROM PRO_ROLE where ID=@Id
GO

CREATE PROCEDURE spRoleGetbyName @Name NVARCHAR(50)
AS
SELECT * FROM PRO_ROLE where NAME=@Name
GO

CREATE PROCEDURE spRoleAdd @Name NVARCHAR(50)
AS
INSERT INTO PRO_ROLE(NAME) VALUES(@Name)
GO 

CREATE PROCEDURE spRoleUpdate @Id INT, @Name NVARCHAR(50)
AS
UPDATE PRO_ROLE set NAME=@Name where ID=@Id
GO

CREATE PROCEDURE spRoleDelete @Id	INT
AS
DELETE FROM dbo.PRO_USERROLE where ID_ROLE=@Id
Delete from PRO_ROLE where ID=@Id
GO

/*USER*/
CREATE PROCEDURE spUserAdd @Login NVARCHAR(50), @Password NVARCHAR(50), @Email NVARCHAR(50)=NULL, @Tel NVARCHAR(50)=NULL
AS
INSERT INTO PRO_USER(LOGIN, PASSWORD, EMAIL, TEL) VALUES (@Login,@Password,@Email,@Tel)
GO

CREATE PROCEDURE spUserUpdate @Id int, @Login NVARCHAR(50), @Password NVARCHAR(50), @Email NVARCHAR(50)=NULL, @Tel NVARCHAR(50)=NULL
AS
UPDATE PRO_USER set LOGIN=@Login, EMAIL=@Email, TEL=@Tel, PASSWORD=@Password where ID=@Id
GO

CREATE PROCEDURE spUserGet
AS
Select * from PRO_USER
GO

CREATE PROCEDURE spUserGetbyLogin @Login NVARCHAR(50)
AS
SELECT * from PRO_USER where LOGIN=@Login
GO

CREATE PROCEDURE spUserGetbyId @Id NVARCHAR(50)
AS
SELECT * from PRO_USER where ID=@Id
GO

CREATE PROCEDURE spUserValidate @Login NVARCHAR(50), @Password NVARCHAR(50)
AS
Select * from PRO_USER where LOGIN=@Login and PASSWORD=@Password
GO

CREATE PROCEDURE spUserDelete @Id int
AS
Delete from PRO_USERROLE where ID_USER=@Id
Delete from PRO_USER where ID=@Id
GO

/*UserROLE*/
CREATE PROCEDURE spURAddUserToRole @ID_USER int, @ID_ROLE int
AS
INSERT INTO PRO_USERROLE(ID_USER, ID_ROLE) VALUES (@ID_USER, @ID_ROLE)
GO

CREATE PROCEDURE spURGetRolesbyUser @Login NVARCHAR(50)
AS
Select * from PRO_ROLE where ID in (SELECT ID_ROLE FROM PRO_USERROLE where ID_USER in (SELECT ID FROM PRO_USER where LOGIN=@Login))
GO

CREATE PROCEDURE spURGetRolesbyUserId @UserId NVARCHAR(50)
AS
Select * from PRO_ROLE where ID in (SELECT ID_ROLE FROM PRO_USERROLE where ID_USER = @UserId)
GO

CREATE PROCEDURE spURGetUsersbyRole @RoleName NVARCHAR(50)
AS
Select * from PRO_USER where ID in (SELECT ID_USER FROM PRO_USERROLE where ID_ROLE in (SELECT ID FROM PRO_ROLE where NAME=@RoleName))
GO

CREATE PROCEDURE spURGetUsersbyRoleId @RoleId int
AS
Select * from PRO_USER where ID in (SELECT ID_USER FROM PRO_USERROLE where ID_ROLE = @RoleId)
GO

/* TEST */
/*
Exec dbo.spRoleGetbyId 2
Exec dbo.spRoleDelete 1
Exec dbo.spRoleAdd ADMINISTRATEUR

Exec dbo.spUserGet
Exec dbo.spUserAdd pkaco, azerty, 'a@b.com'
Exec dbo.spUserAdd erdo, qwerty, 'b@c.com'
*/