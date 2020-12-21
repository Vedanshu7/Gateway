CREATE PROCEDURE [dbo].[getdetails]
	@Email varchar(128)
AS
	SELECT FirstName,LastName,Email,Phone,Age,Country,State,City,Town,PinCode,ImagePath,Gender from Users where Email=@Email
RETURN