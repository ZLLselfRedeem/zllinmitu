CREATE TABLE [dbo].[Table]
(
	[CarID] INT NOT NULL, 
    [Make] VARCHAR(50) NULL, 
    [Color] VARCHAR(50) NULL, 
    [PetName] NCHAR(10) NULL, 
    CONSTRAINT [PK_Table] PRIMARY KEY ([CarID]) 
)
