﻿CREATE TABLE [dbo].[Colors]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(), 
    [Name] NVARCHAR(50) NOT NULL, 
    [VendorID] NVARCHAR(50) NOT NULL
)
