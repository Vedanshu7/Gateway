CREATE PROCEDURE [dbo].[activeuser]
	@validation varchar(150)
AS
	Update Login set is_active ='active' where Email in (SELECT Email from Users where Validation=@validation)
RETURN 0