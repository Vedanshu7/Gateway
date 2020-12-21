CREATE PROCEDURE [dbo].[getlog]
AS
	SELECT Id,EventDateTime,EventLevel,EventMessage from Logs
RETURN 0