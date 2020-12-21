CREATE PROCEDURE [dbo].[checklogin]
	@Email varchar(128)
AS
	SELECT * from Login where Email=@Email
RETURN
