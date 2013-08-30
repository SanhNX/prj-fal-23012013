USE [dbFalStore]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<spBranchDelete>
-- =============================================
CREATE PROCEDURE [dbo].[spBranchDelete]
	@BranchID int,
	@UpdateDate datetime,
	@UpdateUser nvarchar(50) 
AS
BEGIN
	UPDATE Branch
	SET Delete_Flg= 1,
		UpdateDate=@UpdateDate,
		UpdateUser=@UpdateUser
	WHERE BranchID=@BranchID
END

GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<spBranchGetAll>
-- =============================================
CREATE PROCEDURE [dbo].[spBranchGetAll] 
AS
BEGIN
	SELECT BranchID, BranchName, [Address]
	FROM Branch
	WHERE Delete_Flg=0
END

GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<spBranchInsert>
-- =============================================
CREATE PROCEDURE [dbo].[spBranchInsert]
	@BranchName nvarchar(255),
	@Address nvarchar(255),
	@CreateDate datetime,
	@CreateUser nvarchar(50),
	@UpdateDate datetime,
	@UpdateUser nvarchar(50) 
AS
BEGIN
	INSERT INTO Branch (BranchName,[Address],Delete_Flg,CreateDate,CreateUser,UpdateDate,UpdateUser)
	VALUES(@BranchName,@Address,0,@CreateDate,@CreateUser,@UpdateDate,@UpdateUser)
END

GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<spBranchUpdate>
-- =============================================
CREATE PROCEDURE [dbo].[spBranchUpdate]
	@BranchID int,
	@BranchName nvarchar(255),
	@Address nvarchar(255),
	@UpdateDate datetime,
	@UpdateUser nvarchar(50) 
AS
BEGIN
	UPDATE Branch
	SET BranchName = @BranchName,
		[Address]= @Address,
		UpdateDate=@UpdateDate,
		UpdateUser=@UpdateUser
	WHERE BranchID=@BranchID
END

GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<spCategoryDelete>
-- =============================================
CREATE PROCEDURE [dbo].[spCategoryDelete]
	@CategoryID int,
	@UpdateDate datetime,
	@UpdateUser nvarchar(50)	
AS
BEGIN
	UPDATE Category
	SET Delete_Flg = 1,
		UpdateDate = @UpdateDate,
		UpdateUser = @UpdateUser
	WHERE CategoryID = @CategoryID
END

GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<spCategoryGetAll>
-- =============================================
CREATE PROCEDURE [dbo].[spCategoryGetAll]
AS
BEGIN
	SELECT CategoryID, CategoryName 
	FROM Category
	WHERE Delete_Flg=0
END

GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<spCategoryInsert>
-- =============================================
CREATE PROCEDURE [dbo].[spCategoryInsert]
	@CategoryName nvarchar(255),
	@CreateDate datetime,
	@CreateUser nvarchar(50),
	@UpdateDate datetime,
	@UpdateUser nvarchar(50)
AS
BEGIN
	INSERT INTO	Category (CategoryName,Delete_Flg,CreateDate,CreateUser,UpdateDate,UpdateUser)
	VALUES (@CategoryName,0,@CreateDate,@CreateUser,@UpdateDate,@UpdateUser)	
END

GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<spCategoryUpdate>
-- =============================================
CREATE PROCEDURE [dbo].[spCategoryUpdate]
	@CategoryID int,
	@CategoryName nvarchar(255),
	@UpdateDate datetime,
	@UpdateUser nvarchar(50)	
AS
BEGIN
	UPDATE Category
	SET CategoryName = @CategoryName,
		UpdateDate = @UpdateDate,
		UpdateUser = @UpdateUser
	WHERE CategoryID = @CategoryID
END

GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<spEmployeeDelete>
-- =============================================
CREATE PROCEDURE [dbo].[spEmployeeDelete]
	@EmployeeID int,
	@UpdateDate datetime,
	@UpdateUser nvarchar(50)
AS
BEGIN
	UPDATE Employee
	SET Delete_Flg=1,
		UpdateDate=@UpdateDate,
		UpdateUser=@UpdateUser
	WHERE EmployeeID= @EmployeeID
END

GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<spEmployeeGetAll>
-- =============================================
CREATE PROCEDURE [dbo].[spEmployeeGetAll]
AS
BEGIN
	SELECT EmployeeID,EmployeeName,Gender,[Address],Phone
	FROM Employee
	WHERE Delete_Flg=0
END

GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<spEmployeeInsert>
-- =============================================
CREATE PROCEDURE [dbo].[spEmployeeInsert]
	@EmployeeName nvarchar(255),
	@Gender int,
	@Address nvarchar(255),
	@Phone nvarchar(20),
	@CreateDate datetime,
	@CreateUser nvarchar(50),
	@UpdateDate datetime,
	@UpdateUser nvarchar(50)
AS
BEGIN
	INSERT INTO Employee(EmployeeName,Gender,[Address],Phone,Delete_Flg,CreateDate,CreateUser,UpdateDate,UpdateUser)
	VALUES(@EmployeeName,@Gender,@Address,@Phone,0,@CreateDate,@CreateUser,@UpdateDate,@UpdateUser)
END

GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<spEmployeeUpdate>
-- =============================================
CREATE PROCEDURE [dbo].[spEmployeeUpdate]
	@EmployeeID int,
	@EmployeeName nvarchar(255),
	@Gender int,
	@Address nvarchar(255),
	@Phone nvarchar(20),
	@UpdateDate datetime,
	@UpdateUser nvarchar(50)
AS
BEGIN
	UPDATE Employee
	SET EmployeeName = @EmployeeName,
		Gender= @Gender,
		[Address] = @Address,
		Phone=@Phone,
		UpdateDate=@UpdateDate,
		UpdateUser=@UpdateUser
	WHERE EmployeeID= @EmployeeID
END

GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<spProductDelete>
-- =============================================
CREATE PROCEDURE [dbo].[spProductDelete]
	@ProductID nvarchar(50),
	@UpdateDate datetime,
	@UpdateUser nvarchar(50)
AS
BEGIN
	UPDATE Product
	SET Delete_Flg =1 ,
		UpdateDate=@UpdateDate,
		UpdateUser=@UpdateUser
	WHERE ProductID=@ProductID
END

GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<spProductGetAll>
-- =============================================
CREATE PROCEDURE [dbo].[spProductGetAll]
AS
BEGIN
	SELECT ProductID,ProductName,[Description],CategoryID,ImportPrice,ExportPrice
	FROM Product
	WHERE Delete_Flg= 0
END

GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<spProductInsert>
-- =============================================
CREATE PROCEDURE [dbo].[spProductInsert]
	@ProductID nvarchar(50),
	@ProuctName nvarchar(255),
	@Description nvarchar(255),
	@CategoryID int,
	@ImportPrice float,
	@ExportPrice float,
	@CreateDate datetime,
	@CreateUser nvarchar(50),
	@UpdateDate datetime,
	@UpdateUser nvarchar(50)
AS
BEGIN
	INSERT INTO Product(ProductID,ProductName,[Description],CategoryID,ImportPrice,ExportPrice,Delete_Flg,CreateDate,CreateUser,UpdateDate,UpdateUser)
	VALUES(@ProductID,@ProuctName,@Description,@CategoryID,@ImportPrice,@ExportPrice,0,@CreateDate,@CreateUser,@UpdateDate,@UpdateUser)
END

GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<spProductUpdate>
-- =============================================
CREATE PROCEDURE [dbo].[spProductUpdate]
	@ProductID nvarchar(50),
	@ProuctName nvarchar(255),
	@Description nvarchar(255),
	@CategoryID int,
	@ImportPrice float,
	@ExportPrice float,
	@UpdateDate datetime,
	@UpdateUser nvarchar(50)
AS
BEGIN
	UPDATE Product
	SET ProductName = @ProuctName,
		[Description]= @Description,
		CategoryID=@CategoryID,
		ImportPrice=@ImportPrice,
		ExportPrice=@ExportPrice,
		UpdateDate=@UpdateDate,
		UpdateUser=@UpdateUser
	WHERE ProductID=@ProductID
END

GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<spUserDelete>
-- =============================================
CREATE PROCEDURE [dbo].[spUserDelete]
	@UserID nvarchar(50),
	@UpdateDate datetime,
	@UpdateUser nvarchar(50)
AS
BEGIN
	UPDATE [User]
	SET Delete_Flg = 1,
		UpdateDate=@UpdateDate,
		UpdateUser=@UpdateUser
	WHERE UserID=@UserID
END

GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<spUserGetAll>
-- =============================================
CREATE PROCEDURE [dbo].[spUserGetAll]
AS
BEGIN
	SELECT UserID,[Password],[Role],EmployeeID
	FROM [User]
	WHERE Delete_Flg=0
END

GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<spUserInsert>
-- =============================================
CREATE PROCEDURE [dbo].[spUserInsert]
	@UserID nvarchar(50),
	@Password nvarchar(50),
	@Role int,
	@EmployeeID int,
	@CreateDate datetime,
	@CreateUser nvarchar(50),
	@UpdateDate datetime,
	@UpdateUser nvarchar(50)
AS
BEGIN
	INSERT INTO [User](UserID,[Password],[Role],EmployeeID,Delete_Flg,CreateDate,CreateUser,UpdateDate,UpdateUser)
	VALUES(@UserID,@Password,@Role,@EmployeeID,0,@CreateDate,@CreateUser,@UpdateDate,@UpdateUser) 
END

GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<spUserUpdate>
-- =============================================
CREATE PROCEDURE [dbo].[spUserUpdate]
	@UserID nvarchar(50),
	@Password nvarchar(50),
	@Role int,
	@EmployeeID int,
	@UpdateDate datetime,
	@UpdateUser nvarchar(50)
AS
BEGIN
	UPDATE [User]
	SET [Password]= @Password,
		[Role] = @Role,
		EmployeeID=@EmployeeID,
		UpdateDate=@UpdateDate,
		UpdateUser=@UpdateUser
	WHERE UserID=@UserID
END

GO






