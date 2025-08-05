USE master

IF EXISTS (SELECT name FROM sys.databases WHERE name = 'TakeHomeTest')
BEGIN
    DROP DATABASE [TakeHomeTest]
	USE master
END

CREATE DATABASE TakeHomeTest
GO

USE TakeHomeTest
GO

CREATE TABLE [dbo].[LoanStatus]
(
	StatusId	INT PRIMARY KEY IDENTITY (1, 1),
	Name		VARCHAR(100) NULL	
)
GO

CREATE TABLE [dbo].[Loans]
(
	LoanId		INT PRIMARY KEY IDENTITY (1, 1),
	Amount			DECIMAL(10, 2) NULL,
	CurrentBalance	DECIMAL(10, 2) NULL,
	ApplicantName	VARCHAR(100) NULL,	
	StatusId		INT NOT NULL

	FOREIGN KEY (StatusId) REFERENCES LoanStatus(StatusId)
)
GO


/*---------------------------- SELECTS ----------------------------*/
SELECT * FROM [dbo].[LoanStatus]
SELECT * FROM [dbo].[Loans]


