﻿CREATE PROCEDURE sp_AllEmployees
AS
BEGIN
	SET NOCOUNT ON; 

	SELECT * FROM EmployeeData;
	RETURN
END