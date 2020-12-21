CREATE PROCEDURE [dbo].[checkemail]
	@param1 varchar(128)
AS
	SELECT Email from Users where Email=@param1
RETURN