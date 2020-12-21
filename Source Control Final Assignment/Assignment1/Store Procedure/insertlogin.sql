CREATE PROCEDURE [dbo].[insertlogin]
	@Email varchar(128),
	@Password varchar(150),
	@active varchar(50)
AS
	insert into Login values(@Email,@Password,@active)
RETURN 0