Go
USE [master]
Go

IF DB_ID('OIT_Uber') IS NOT NULL
	DROP DATABASE [OIT_Uber]
GO

CREATE DATABASE [OIT_Uber]

GO
USE [OIT_Uber]
GO

CREATE TABLE [dbo].[Riders]
(
	RiderID int Identity(1,1) constraint PKRiderID Primary key,
	FirstName nvarchar(20),
	LastName nvarchar(20),
	CreditCardNumber nvarchar(20),
)

CREATE TABLE Drivers
(
	DriverID int Identity(1,1) constraint PKDriverID Primary Key,
	FirstName nvarchar(20),
	LastName nvarchar(20),
	LicensePlate nvarchar(20),
	VehicleType nvarchar(25)
)

Create Table ZipCodes
(
	ZipCode int Constraint PKZipCode Primary Key,
	City nvarchar(20)
)

Create Table Requests
(
	RequestID int Identity(1,1) constraint PKRequestID Primary Key ,
	RiderID int constraint FKRiderID references Riders(RiderID),
	Street nvarchar(30),
	ZipCode int constraint FKZipCode references ZipCodes(ZipCode),
	Completed nvarchar(3),
	timeneeded datetime
)
Create Table DriverRequests
(
	DriverID int Constraint FKDriverID references Drivers(DriverID),
	RequestID int Constraint FKRequestsID references Requests(RequestID),
	EstimatedTime decimal(4,0),
	Constraint DriverRequestsPK primary key (DriverID,RequestID)

)
INSERT INTO Riders(FirstName,LastName,CreditCardNumber)
VALUES
('Sterling','Archer',11111111),
('Pam','Poovey',23456789),
('Cheryl','Tunt',22222222),
('Cyril','Figgis', 12121212),
('Lana','Kane', 45454545)

INSERT INTO Drivers(FirstName,LastName,LicensePlate,VehicleType)
VALUES
('Leslie', 'Knope','PAWN33','Blue Prius'),
('Ben', 'Wyatt','B4TM4N','Black BatMobile'),
('Ron', 'Swanson','BRCKF4ST','Grey Truck'),
('Chris', 'Traeger','LTRLY!!','Green Subaru'),
('Andy' ,'Dwyer','STRL0RD','BlueBessie'),
('April', 'Ludgate','$4RCASM','Green T-REX')

INSERT INTO ZipCodes(ZipCode,City)
VALUES
(97068,'West Linn'),
(97070,'Wilsonville'),
(97601,'Klamath Falls'),
(97201,'Portland')

INSERT INTO Requests(RiderID,Street,ZipCode,Completed,timeneeded)
VALUES
(2,'1717 SW Park Ave',97201,'NO','20120618 10:34:09 AM'),
(1,'3432 Main St.',97068,'NO','20120618 10:34:09 AM'),
(3,'343 Birch St.',97601,'NO','20120618 10:34:09 AM'),
(4,'532 Balsam St.',97070,'YES','20120618 10:34:09 AM')

INSERT INTO DriverRequests(DriverID,RequestID,EstimatedTime)
VALUES
(1,4,25)
