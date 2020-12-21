CREATE PROCEDURE [dbo].[insertuser]
    @FirstName VARCHAR (50)  ,
    @LastName  VARCHAR (50) ,
    @Email     VARCHAR (128) ,
    @Password  VARCHAR (150) ,
    @Phone     VARCHAR (50)  ,
    @Age       TINYINT       ,
    @Country   VARCHAR (50) ,
    @State     VARCHAR (50)  ,
    @City      VARCHAR (50)  ,
    @Town      VARCHAR (50)  ,
    @PinCode   VARCHAR (50) ,
    @ImagePath VARCHAR (50) ,
    @Gender    VARCHAR (50) ,
	@Validation VARCHAR (150)
AS
	Insert into Users values(@FirstName,@LastName,@Email,@Password,@Phone,@Age,@Country,@State,@City,@Town,@PinCode,@ImagePath,@Gender,@Validation)
RETURN