--Create database
--CREATE DATABASE dbFalStore;

USE [dbFalStore]
--Create table
--Category
CREATE TABLE Category
(
CategoryID int NOT NULL PRIMARY KEY,
CategoryName nvarchar(255),
Delete_Flg int,
CreateDate datetime,
CreateUser nvarchar(50),
UpdateDate datetime,
UpdateUser nvarchar(50)
);
--Product
CREATE TABLE Product
(
ProductID nvarchar(50)NOT NULL PRIMARY KEY,
ProductName nvarchar(255),
[Description] nvarchar(255),
CategoryID int,
ImportPrice money,
ExportPrice money,
Delete_Flg int,
CreateDate datetime,
CreateUser nvarchar(50),
UpdateDate datetime,
UpdateUser nvarchar(50)
);
--Color
CREATE TABLE Color
(
ColorID int NOT NULL PRIMARY KEY,
ColorName nvarchar(50),
ProductID nvarchar(50),
Delete_Flg int,
CreateDate datetime,
CreateUser nvarchar(50),
UpdateDate datetime,
UpdateUser nvarchar(50)
);
--Size
CREATE TABLE Size
(
SizeID int NOT NULL PRIMARY KEY,
SizeName nvarchar(50),
ColorID int,
Delete_Flg int,
CreateDate datetime,
CreateUser nvarchar(50),
UpdateDate datetime,
UpdateUser nvarchar(50)
);
--Branch
CREATE TABLE Branch
(
BranchID int NOT NULL PRIMARY KEY,
BranchName nvarchar(255),
[Address] nvarchar(255),
Delete_Flg int,
CreateDate datetime,
CreateUser nvarchar(50),
UpdateDate datetime,
UpdateUser nvarchar(50)
);
--Store
CREATE TABLE Store
(
StoreID int,
ProductID nvarchar(50),
VerID char(3),
ColorID int,
SizeID int,
BranchID int,
ExportPrice money,
Quantity int,
Delete_Flg int,
CreateDate datetime,
CreateUser nvarchar(50),
UpdateDate datetime,
UpdateUser nvarchar(50)
);
--Employee
CREATE TABLE Employee
(
EmployeeID int NOT NULL PRIMARY KEY,
EmployeeName nvarchar(255),
Gender int,
[Address] nvarchar(255),
Phone nvarchar(20),
Delete_Flg int,
CreateDate datetime,
CreateUser nvarchar(50),
UpdateDate datetime,
UpdateUser nvarchar(50)
);
--User
CREATE TABLE [User] 
(
UserID nvarchar(50)NOT NULL PRIMARY KEY,
[Password] nvarchar(50),
[Role] int,
EmployeeID int,
Delete_Flg int,
CreateDate datetime,
CreateUser nvarchar(50),
UpdateDate datetime,
UpdateUser nvarchar(50)
);
--Log_Store
CREATE TABLE Log_Store 
(
Log_StoreID nvarchar(50) NOT NULL PRIMARY KEY,
LogType int,
EmployeeID int,
LogDate datetime,
BranchFrom int,
BranchTo int,
[Description] nvarchar(255),
Delete_Flg int,
CreateDate datetime,
CreateUser nvarchar(50),
UpdateDate datetime,
UpdateUser nvarchar(50)
);
--Log_Detail
CREATE TABLE Log_Detail 
(
Log_DetailID int NOT NULL PRIMARY KEY,
Log_StoreID nvarchar(50),
ProductID nvarchar(50),
ColorID int,
SizeID int,
Sale float,
Quantity int,
Delete_Flg int,
CreateDate datetime,
CreateUser nvarchar(50),
UpdateDate datetime,
UpdateUser nvarchar(50)
);
--Customer
CREATE TABLE Customer 
(
CustomerID int NOT NULL PRIMARY KEY,
CustomerName nvarchar(255),
Email nvarchar(50),
Phone nvarchar(20),
Delete_Flg int,
CreateDate datetime,
CreateUser nvarchar(50),
UpdateDate datetime,
UpdateUser nvarchar(50)
);
--Bill
CREATE TABLE Bill 
(
BillID nvarchar(50) NOT NULL PRIMARY KEY,
EmployeeID int,
CustomerID int,
BranchID int,
TotalPrice money,
Sale float,
ActualTotalPrice money,
Delete_Flg int,
CreateDate datetime,
CreateUser nvarchar(50),
UpdateDate datetime,
UpdateUser nvarchar(50)
);
--Bill_Detail
CREATE TABLE Bill_Detail 
(
Bill_DetailID int NOT NULL PRIMARY KEY,
ProductID nvarchar(50),
Quantity int,
Amount money,
Delete_Flg int,
CreateDate datetime,
CreateUser nvarchar(50),
UpdateDate datetime,
UpdateUser nvarchar(50)
);
--Expenses
CREATE TABLE Expenses 
(
ExpensesID int NOT NULL PRIMARY KEY,
BranchID int,
EmployeeID int,
[Description] nvarchar(255),
Amount money,
Delete_Flg int,
CreateDate datetime,
CreateUser nvarchar(50),
UpdateDate datetime,
UpdateUser nvarchar(50)
);