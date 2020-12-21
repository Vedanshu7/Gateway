CREATE TABLE [dbo].[Login] (
    [Email]     VARCHAR (128) NOT NULL,
    [Password]  VARCHAR (100) NOT NULL,
    [is_active] VARCHAR (50)  NOT NULL
);



CREATE TABLE [dbo].[Users] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [FirstName]  VARCHAR (50)  NOT NULL,
    [LastName]   VARCHAR (50)  NOT NULL,
    [Email]      VARCHAR (128) NOT NULL,
    [Password]   VARCHAR (150) NOT NULL,
    [Phone]      VARCHAR (50)  NOT NULL,
    [Age]        TINYINT       NOT NULL,
    [Country]    VARCHAR (50)  NOT NULL,
    [State]      VARCHAR (50)  NOT NULL,
    [City]       VARCHAR (50)  NOT NULL,
    [Town]       VARCHAR (50)  NOT NULL,
    [PinCode]    VARCHAR (50)  NOT NULL,
    [ImagePath]  VARCHAR (50)  NOT NULL,
    [Gender]     VARCHAR (50)  NOT NULL,
    [Validation] VARCHAR (150) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);



CREATE TABLE [dbo].[Logs] (
    [Id]                INT            IDENTITY (1, 1) NOT NULL,
    [EventDateTime]     DATETIME       NOT NULL,
    [EventLevel]        NVARCHAR (100) NOT NULL,
    [UserName]          NVARCHAR (100) NOT NULL,
    [MachineName]       NVARCHAR (100) NOT NULL,
    [EventMessage]      NVARCHAR (MAX) NOT NULL,
    [ErrorSource]       NVARCHAR (100) NULL,
    [ErrorClass]        NVARCHAR (500) NULL,
    [ErrorMethod]       NVARCHAR (MAX) NULL,
    [ErrorMessage]      NVARCHAR (MAX) NULL,
    [InnerErrorMessage] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED ([Id] ASC)
);

