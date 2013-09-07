USE [dbFalStore]
GO
/****** Object:  Table [dbo].[Size]    Script Date: 09/08/2013 05:32:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Size](
	[SizeID] [int] NOT NULL,
	[SizeName] [nvarchar](50) NULL,
	[ColorID] [int] NULL,
	[Delete_Flg] [int] NULL,
	[CreateDate] [datetime] NULL,
	[CreateUser] [nvarchar](50) NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateUser] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[SizeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 09/08/2013 05:32:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [nvarchar](50) NOT NULL,
	[ProductName] [nvarchar](255) NULL,
	[Description] [nvarchar](255) NULL,
	[CategoryID] [int] NULL,
	[ImportPrice] [money] NULL,
	[ExportPrice] [money] NULL,
	[TotalQuantity] [int] NULL,
	[Delete_Flg] [int] NULL,
	[CreateDate] [datetime] NULL,
	[CreateUser] [nvarchar](50) NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateUser] [nvarchar](50) NULL,
 CONSTRAINT [PK__Product__B40CC6ED117F9D94] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Log_Store]    Script Date: 09/08/2013 05:32:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Log_Store](
	[Log_StoreID] [nvarchar](50) NOT NULL,
	[LogType] [int] NULL,
	[EmployeeID] [int] NULL,
	[LogDate] [nvarchar](10) NULL,
	[BranchFrom] [int] NULL,
	[BranchTo] [int] NULL,
	[NCC] [nvarchar](50) NULL,
	[Description] [nvarchar](255) NULL,
	[Delete_Flg] [int] NULL,
	[CreateDate] [datetime] NULL,
	[CreateUser] [nvarchar](50) NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateUser] [nvarchar](50) NULL,
 CONSTRAINT [PK__Log_Stor__990313F529572725] PRIMARY KEY CLUSTERED 
(
	[Log_StoreID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Log_Detail]    Script Date: 09/08/2013 05:32:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Log_Detail](
	[Log_DetailID] [int] IDENTITY(1,1) NOT NULL,
	[Log_StoreID] [nvarchar](50) NULL,
	[ProductID] [nvarchar](50) NULL,
	[ColorID] [int] NULL,
	[Size] [nvarchar](10) NULL,
	[Sale] [float] NULL,
	[Quantity] [int] NULL,
	[Amount] [float] NULL,
	[Status_Flg] [int] NULL,
	[Delete_Flg] [int] NULL,
 CONSTRAINT [PK__Log_Deta__2F31DAC82D27B809] PRIMARY KEY CLUSTERED 
(
	[Log_DetailID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Expenses]    Script Date: 09/08/2013 05:32:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Expenses](
	[ExpensesID] [int] NOT NULL,
	[BranchID] [int] NULL,
	[EmployeeID] [int] NULL,
	[Description] [nvarchar](255) NULL,
	[Amount] [money] NULL,
	[Delete_Flg] [int] NULL,
	[CreateDate] [datetime] NULL,
	[CreateUser] [nvarchar](50) NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateUser] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ExpensesID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 09/08/2013 05:32:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeName] [nvarchar](255) NULL,
	[Gender] [int] NULL,
	[Address] [nvarchar](255) NULL,
	[Phone] [nvarchar](20) NULL,
	[Delete_Flg] [int] NULL,
	[CreateDate] [datetime] NULL,
	[CreateUser] [nvarchar](50) NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateUser] [nvarchar](50) NULL,
 CONSTRAINT [PK__Employee__7AD04FF121B6055D] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 09/08/2013 05:32:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](255) NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [nvarchar](20) NULL,
	[Delete_Flg] [int] NULL,
	[CreateDate] [datetime] NULL,
	[CreateUser] [nvarchar](50) NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateUser] [nvarchar](50) NULL,
 CONSTRAINT [PK__Customer__A4AE64B830F848ED] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Color]    Script Date: 09/08/2013 05:32:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Color](
	[ColorID] [int] IDENTITY(1,1) NOT NULL,
	[ColorName] [nvarchar](50) NULL,
	[ProductID] [nvarchar](50) NULL,
	[Delete_Flg] [int] NULL,
 CONSTRAINT [PK__Color__8DA7676D15502E78] PRIMARY KEY CLUSTERED 
(
	[ColorID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 09/08/2013 05:32:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](255) NULL,
	[Delete_Flg] [int] NULL,
	[CreateDate] [datetime] NULL,
	[CreateUser] [nvarchar](50) NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateUser] [nvarchar](50) NULL,
 CONSTRAINT [PK__Category__19093A2B412EB0B6] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Branch]    Script Date: 09/08/2013 05:32:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Branch](
	[BranchID] [int] IDENTITY(1,1) NOT NULL,
	[BranchName] [nvarchar](255) NULL,
	[Address] [nvarchar](50) NULL,
	[Description] [nvarchar](255) NULL,
	[Delete_Flg] [int] NULL,
	[CreateDate] [datetime] NULL,
	[CreateUser] [nvarchar](50) NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateUser] [nvarchar](50) NULL,
 CONSTRAINT [PK__Branch__A1682FA51CF15040] PRIMARY KEY CLUSTERED 
(
	[BranchID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bill_Detail]    Script Date: 09/08/2013 05:32:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill_Detail](
	[Bill_DetailID] [int] NOT NULL,
	[ProductID] [nvarchar](50) NULL,
	[Quantity] [int] NULL,
	[Amount] [money] NULL,
	[Delete_Flg] [int] NULL,
	[CreateDate] [datetime] NULL,
	[CreateUser] [nvarchar](50) NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateUser] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Bill_DetailID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bill]    Script Date: 09/08/2013 05:32:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[BillID] [nvarchar](50) NOT NULL,
	[EmployeeID] [int] NULL,
	[CustomerID] [int] NULL,
	[BranchID] [int] NULL,
	[TotalPrice] [money] NULL,
	[Sale] [float] NULL,
	[ActualTotalPrice] [money] NULL,
	[Delete_Flg] [int] NULL,
	[CreateDate] [datetime] NULL,
	[CreateUser] [nvarchar](50) NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateUser] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[BillID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[spProductGetByPaging]    Script Date: 09/08/2013 05:32:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spProductGetByPaging]
(
	@pageSize int  ,
	@pageIndex int ,
	@field nvarchar(100) = 'p.ProductID ',
	@total int out
	)
AS
BEGIN

	DECLARE @select nvarchar(max),
			@Paramlist nvarchar(max);
	SET @select = ' SELECT ROW_NUMBER() OVER (ORDER BY ' + @field + ') as row,
					p.ProductID, p.ProductName, c.CategoryName,p.ImportPrice,p.ExportPrice
					FROM Product p INNER JOIN Category c 
					ON p.CategoryID = c.CategoryID
					WHERE 1=1 and p.Delete_Flg = 0';
		
	-- paging
	declare @table nvarchar(max);
	set @table = 'WITH RESULT(row, ProductID, ProductName, CategoryName, ImportPrice, ExportPrice ) AS ( ';

	-- paging 
	declare @pagingSql nvarchar(max);
	declare @startRow int;
    declare @endRow   int;
	
	set @pagingSql	= 'SELECT * FROM result WHERE row between ';
	set @startRow	= (@pageIndex - 1) * @pageSize + 1;
	set @endRow		= @startRow + @pageSize - 1;
    set @pagingSql	= @pagingSql + convert(varchar(10), @startRow);
	set @pagingSql	= @pagingSql + ' AND ' ;
	set @pagingSql	= @pagingSql + convert(varchar(10), @endRow);
	
	declare @sql nvarchar(max);
	set  @sql = ' ';
	
	set @sql = @table + @select + ') ' + @pagingsql;
	print @sql
	
	set @Paramlist =N''
	exec SP_EXECUTESQL  @sql,
						@Paramlist
						
	declare @Total2 int;
	set @sql = @table + @select + ') select @Total2= count(row)  from result';
	set @Paramlist = N'@Total2 int out'					
	exec sp_executeSql @sql,
						@Paramlist, 
						@Total2 out
	set @total = @Total2
END
GO
/****** Object:  StoredProcedure [dbo].[spStoreSearch]    Script Date: 09/08/2013 05:32:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spStoreSearch]
	@ProductID nvarchar(50),
	@ProductName nvarchar(255),
	@BranchID int,
	@CategoryID int
	
AS
BEGIN

	Declare @select nvarchar(MAX);
	Declare @con1 nvarchar(MAX);
	Declare @con2 nvarchar(MAX);
	Declare @con3 nvarchar(MAX);
	Declare @con4 nvarchar(MAX);
	SET @select =	'SELECT b.BranchName,p.ProductID, p.ProductName, p.ImportPrice, p.ExportPrice , c.ColorName, s.Size
	FROM Store s inner join Branch b 
	ON s.BranchID = b.BranchID inner join Product p
	ON s.ProductID= p.ProductID inner join Color c
	ON c.ProductID = p.ProductID
	WHERE 1=1';
	
	if(@ProductID !=null)
	begin
		SET @con1 = 'AND s.ProductID =' + @ProductID;
	end
	else
	begin
		SET @con1 =' '
	end
	
	if(@ProductName !=null)
	begin
		SET @con2 = 'AND p.ProductName like %' + @ProductName + '%';
	end
	else
	begin
		SET @con2 =' '
	end
	
	if(@BranchID !=null)
	begin
	  SET @con3 = 'AND s.BranchID = @BranchID';
	end
	else
	begin
		SET @con3 =' '
	end
	
	if(@CategoryID !=null)
	begin
		SET @con4 ='AND p.CategoryID =' + @CategoryID;
	end
	else
	begin
		SET @con4 =' '
	end
	
	Declare @sql nvarchar(MAX);
	
	SET @sql = @select + @con1 + @con2 + @con3 + @con4;
	
	print @sql
	
	EXEC SP_EXECUTESQL  @sql
	
	
END
GO
/****** Object:  Table [dbo].[User]    Script Date: 09/08/2013 05:32:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NULL,
	[Role] [int] NULL,
	[EmployeeID] [int] NULL,
	[Delete_Flg] [int] NULL,
	[CreateDate] [datetime] NULL,
	[CreateUser] [nvarchar](50) NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateUser] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Store]    Script Date: 09/08/2013 05:32:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Store](
	[StoreID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [nvarchar](50) NULL,
	[VerID] [int] NULL,
	[ColorID] [int] NULL,
	[Size] [nvarchar](10) NULL,
	[BranchID] [int] NULL,
	[Log_StoreID] [nchar](10) NULL,
	[ExportPrice] [float] NULL,
	[Quantity] [int] NULL,
	[Status] [int] NULL,
	[Delete_Flg] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[spUserUpdate]    Script Date: 09/08/2013 05:32:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
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
/****** Object:  StoredProcedure [dbo].[spUserInsert]    Script Date: 09/08/2013 05:32:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
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
/****** Object:  StoredProcedure [dbo].[spUserGetAll]    Script Date: 09/08/2013 05:32:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spUserGetAll]
AS
BEGIN
	SELECT UserID,[Password],[Role],EmployeeID
	FROM [User]
	WHERE Delete_Flg=0
END
GO
/****** Object:  StoredProcedure [dbo].[spUserDelete]    Script Date: 09/08/2013 05:32:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
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
/****** Object:  StoredProcedure [dbo].[spStoreUpdateQuantity]    Script Date: 09/08/2013 05:32:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[spStoreUpdateQuantity]
	@ProductID nvarchar(50),
	@BranchID int,
	@ColorID int,
	@Size nvarchar(10),
	@NewQuantity int
AS
BEGIN
	declare @Quantity int
	select @Quantity = Quantity 
	from Store
	where BranchID = @BranchID and ProductID = @ProductID and ColorID = @ColorID and Size= @Size

	UPDATE Store
	SET Quantity = @Quantity + @NewQuantity
	where BranchID = @BranchID and ProductID = @ProductID and ColorID = @ColorID and Size= @Size
END
GO
/****** Object:  StoredProcedure [dbo].[spStoreInsert]    Script Date: 09/08/2013 05:32:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spStoreInsert]
	@ProductID nvarchar(50),
	@ColorID int,
	@Size nvarchar(10),
	@BranchID int,
	@ExportPrice float,
	@Quantity int,
	@LogStoreID nvarchar(50)
AS
BEGIN
	INSERT INTO Store(ProductID,VerID,ColorID,Size,BranchID,ExportPrice,Quantity,Log_StoreID,[Status],Delete_Flg)
	VALUES(@ProductID,1,@ColorID,@Size,@BranchID,@ExportPrice,@Quantity,@LogStoreID ,1,0)
END
GO
/****** Object:  StoredProcedure [dbo].[spStoreGetProductInfoByBranch]    Script Date: 09/08/2013 05:32:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[spStoreGetProductInfoByBranch]
	@ProductID nvarchar(50),
	@ColorID int,
	@Size nvarchar(10),
	@BranchID int
AS
BEGIN
	SELECT ProductID, ExportPrice
	FROM Store
	WHERE ProductID = @ProductID and ColorID = @ColorID and Size = @Size and BranchID = @BranchID
END
GO
/****** Object:  StoredProcedure [dbo].[spStoreGetProductID]    Script Date: 09/08/2013 05:32:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spStoreGetProductID]
	@ProductID nvarchar(50),
	@BranchID int
AS
BEGIN
	SELECT ProductID
	FROM Store 
	WHERE ProductID= @ProductID and BranchID = @BranchID
END
GO
/****** Object:  StoredProcedure [dbo].[spProductUpdateTotalQuantity]    Script Date: 09/08/2013 05:32:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spProductUpdateTotalQuantity]
	@ProductID nvarchar(50),
	@Quantity int
AS
BEGIN
	Declare @TotalQuantity int
	select @TotalQuantity = TotalQuantity from Product where ProductID = @ProductID
	
	UPDATE Product
	SET TotalQuantity = @TotalQuantity + @Quantity
	WHERE ProductID=@ProductID
END
GO
/****** Object:  StoredProcedure [dbo].[spProductUpdate]    Script Date: 09/08/2013 05:32:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spProductUpdate]
	@ProductID nvarchar(50),
	@ProductName nvarchar(255),
	@CategoryID int,
	@ImportPrice float,
	@ExportPrice float,
	@UpdateDate datetime,
	@UpdateUser nvarchar(50)
AS
BEGIN
	UPDATE Product
	SET ProductName = @ProductName,
		CategoryID=@CategoryID,
		ImportPrice=@ImportPrice,
		ExportPrice=@ExportPrice,
		UpdateDate=@UpdateDate,
		UpdateUser=@UpdateUser
	WHERE ProductID=@ProductID
END
GO
/****** Object:  StoredProcedure [dbo].[spProductInsert]    Script Date: 09/08/2013 05:32:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spProductInsert]
	@ProductID nvarchar(50),
	@ProductName nvarchar(255),
	@CategoryID int,
	@ImportPrice float,
	@ExportPrice float,
	@CreateDate datetime,
	@CreateUser nvarchar(50),
	@UpdateDate datetime,
	@UpdateUser nvarchar(50)
AS
BEGIN
	INSERT INTO Product(ProductID,ProductName,CategoryID,ImportPrice,ExportPrice,TotalQuantity, Delete_Flg,CreateDate,CreateUser,UpdateDate,UpdateUser)
	VALUES(@ProductID,@ProductName,@CategoryID,@ImportPrice,@ExportPrice,0,0,@CreateDate,@CreateUser,@UpdateDate,@UpdateUser)
END
GO
/****** Object:  StoredProcedure [dbo].[spProductGetTotalCount]    Script Date: 09/08/2013 05:32:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*Author:
 Create date:
 Description: 
 */
-- =============================================
Create proc [dbo].[spProductGetTotalCount]
(
	@total int out
	)
AS
BEGIN

	SELECT @total = COUNT(ProductID)
	FROM Product
	WHERE Delete_Flg= 0
	
END
GO
/****** Object:  StoredProcedure [dbo].[spProductGetByID]    Script Date: 09/08/2013 05:32:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spProductGetByID]
	@ProductID nvarchar(50)
AS
BEGIN
	SELECT ProductID,ProductName,CategoryID,ImportPrice,ExportPrice
	FROM Product
	WHERE ProductID= @ProductID and Delete_Flg=0
END
GO
/****** Object:  StoredProcedure [dbo].[spProductDelete]    Script Date: 09/08/2013 05:32:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
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
/****** Object:  StoredProcedure [dbo].[spLogStoreInsert]    Script Date: 09/08/2013 05:32:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[spLogStoreInsert]
	@LogStoreID nvarchar(50),
	@LogType int,
	@EmployeeID int,
	@LogDate nvarchar(10),
	@BranchFrom int,
	@BranchTo int,
	@NCC nvarchar(50),
	@Description nvarchar(255),
	@CreateDate datetime,
	@CreateUser nvarchar(50),
	@UpdateDate datetime,
	@UpdateUser nvarchar(50)
AS
BEGIN
	INSERT INTO Log_Store(Log_StoreID,LogType,EmployeeID,LogDate,BranchFrom,BranchTo,NCC,[Description],Delete_Flg,CreateDate,CreateUser,UpdateDate,UpdateUser)
	VALUES(@LogStoreID,@LogType,@EmployeeID,@LogDate,@BranchFrom,@BranchTo,@NCC,@Description,0,@CreateDate,@CreateUser,@UpdateDate,@UpdateUser)
END
GO
/****** Object:  StoredProcedure [dbo].[spLogStoreGetLastID]    Script Date: 09/08/2013 05:32:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spLogStoreGetLastID]
AS
BEGIN
	SELECT top 1 Log_StoreID
	FROM Log_Store
	ORDER BY Log_StoreID DESC
END
GO
/****** Object:  StoredProcedure [dbo].[spLogDetailUpdateStatus]    Script Date: 09/08/2013 05:32:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[spLogDetailUpdateStatus]
	@LogStoreID nvarchar(50)
AS
BEGIN
	UPDATE Log_Detail
	SET Status_Flg = 0
	WHERE Log_StoreID= @LogStoreID
END
GO
/****** Object:  StoredProcedure [dbo].[spLogDetailInsert]    Script Date: 09/08/2013 05:32:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spLogDetailInsert]
	@LogStoreID nvarchar(50),
	@ProductID nvarchar(50),
	@ColorID int,
	@Size nvarchar(10),
	@Sale float,
	@Quantity int,
	@Amount float
AS
BEGIN
	INSERT INTO Log_Detail(Log_StoreID,ProductID,ColorID,Size,Sale,Quantity,Amount,Status_Flg,Delete_Flg)
	VALUES(@LogStoreID,@ProductID,@ColorID,@Size,@Sale,@Quantity,@Amount,1,0)
END
GO
/****** Object:  StoredProcedure [dbo].[spLogDetailGetByLogStoreID]    Script Date: 09/08/2013 05:32:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spLogDetailGetByLogStoreID]
	@LogStoreID nvarchar(50),
	@StatusFlg int
AS
BEGIN
	SELECT ld.Log_StoreID,ld.ProductID,p.ProductName,p.ExportPrice,ld.Quantity,ld.Sale, ld.Amount,ld.Size,c.ColorName, c.ColorID
	FROM Log_Detail ld inner join Product p 
	ON ld.ProductID= p.ProductID inner join Color c 
	ON ld.ColorID= c.ColorID
	WHERE ld.Log_StoreID = @LogStoreID and ld.Delete_Flg=0 and ld.Status_flg = @StatusFlg
END
GO
/****** Object:  StoredProcedure [dbo].[spEmployeeUpdate]    Script Date: 09/08/2013 05:32:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
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
/****** Object:  StoredProcedure [dbo].[spEmployeeInsert]    Script Date: 09/08/2013 05:32:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
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
/****** Object:  StoredProcedure [dbo].[spEmployeeGetByPaging]    Script Date: 09/08/2013 05:32:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spEmployeeGetByPaging]
AS
BEGIN
	SELECT EmployeeID,EmployeeName,Gender,[Address],Phone
	FROM Employee
	WHERE Delete_Flg=0
END
GO
/****** Object:  StoredProcedure [dbo].[spEmployeeGetAll]    Script Date: 09/08/2013 05:32:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[spEmployeeGetAll]
AS
BEGIN
	SELECT EmployeeID,EmployeeName
	FROM Employee
	WHERE Delete_Flg=0
END
GO
/****** Object:  StoredProcedure [dbo].[spEmployeeDelete]    Script Date: 09/08/2013 05:32:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
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
/****** Object:  StoredProcedure [dbo].[spColorUpdate]    Script Date: 09/08/2013 05:32:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spColorUpdate]
	@ColorID int,
	@ColorName nvarchar(255)
AS
BEGIN
	UPDATE Color
	SET ColorName = @ColorName
	WHERE ColorID=@ColorID
END
GO
/****** Object:  StoredProcedure [dbo].[spColorInsert]    Script Date: 09/08/2013 05:32:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spColorInsert]
	@ColorName nvarchar(255),
	@ProductID nvarchar(255)
AS
BEGIN
	INSERT INTO	Color(ColorName,ProductID,Delete_Flg)
	VALUES (@ColorName,@ProductID,0)	
END
GO
/****** Object:  StoredProcedure [dbo].[spColorGetByProductID]    Script Date: 09/08/2013 05:32:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spColorGetByProductID]
	@ProductID nvarchar(50)
AS
BEGIN
	SELECT ColorID, ColorName
	FROM Color
	WHERE ProductID= @ProductID and Delete_Flg=0
END
GO
/****** Object:  StoredProcedure [dbo].[spCategoryUpdate]    Script Date: 09/08/2013 05:32:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
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
/****** Object:  StoredProcedure [dbo].[spCategoryInsert]    Script Date: 09/08/2013 05:32:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
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
/****** Object:  StoredProcedure [dbo].[spCategoryGetTotalCount]    Script Date: 09/08/2013 05:32:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*Author:
 Create date:
 Description: 
 */
-- =============================================
Create proc [dbo].[spCategoryGetTotalCount]
(
	@total int out
	)
AS
BEGIN

	SELECT @total = COUNT(CategoryID)
	FROM Category 
	WHERE Delete_Flg= 0
	
END
GO
/****** Object:  StoredProcedure [dbo].[spCategoryGetByPaging]    Script Date: 09/08/2013 05:32:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*Author:
 Create date:
 Description: 
 */
-- =============================================
CREATE proc [dbo].[spCategoryGetByPaging]
(
	@pageSize int  ,
	@pageIndex int ,
	@field nvarchar(100) = 'a.CategoryID ',
	@total int out
	)
AS
BEGIN

	SELECT @total = COUNT(CategoryID)
	FROM Category 
	WHERE Delete_Flg= 0
	
	DECLARE @select nvarchar(max),
			@Paramlist nvarchar(max);
	SET @select = ' SELECT ROW_NUMBER() OVER (ORDER BY ' + @field + ') as row,
					CategoryID, CategoryName FROM Category a WHERE 1=1 and Delete_Flg = 0';
		
	-- paging
	declare @table nvarchar(max);
	set @table = 'WITH RESULT(row, CategoryID, CategoryName ) AS ( ';

	-- paging 
	declare @pagingSql nvarchar(max);
	declare @startRow int;
    declare @endRow   int;
	
	set @pagingSql	= 'SELECT * FROM result WHERE row between ';
	set @startRow	= (@pageIndex - 1) * @pageSize + 1;
	set @endRow		= @startRow + @pageSize - 1;
    set @pagingSql	= @pagingSql + convert(varchar(10), @startRow);
	set @pagingSql	= @pagingSql + ' AND ' ;
	set @pagingSql	= @pagingSql + convert(varchar(10), @endRow);
	
	declare @sql nvarchar(max);
	set  @sql = ' ';
	
	set @sql = @table + @select + ') ' + @pagingsql;
	print @sql
	
	set @Paramlist =N''
	exec SP_EXECUTESQL  @sql,
						@Paramlist
						
END
GO
/****** Object:  StoredProcedure [dbo].[spCategoryGetByID]    Script Date: 09/08/2013 05:32:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[spCategoryGetByID]
	@CategoryID int
AS
BEGIN
	SELECT CategoryID,CategoryName
	FROM Category
	WHERE Delete_Flg=0 AND CategoryID=@CategoryID
END
GO
/****** Object:  StoredProcedure [dbo].[spCategoryGetAll]    Script Date: 09/08/2013 05:32:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[spCategoryGetAll]
AS
BEGIN
	SELECT CategoryID,CategoryName
	FROM Category
	WHERE Delete_Flg=0
END
GO
/****** Object:  StoredProcedure [dbo].[spCategoryDelete]    Script Date: 09/08/2013 05:32:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
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
/****** Object:  StoredProcedure [dbo].[spBranchUpdate]    Script Date: 09/08/2013 05:32:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spBranchUpdate]
	@BranchID int,
	@BranchName nvarchar(50),
	@Address nvarchar(50),
	@Description nvarchar(255),
	@UpdateDate datetime,
	@UpdateUser nvarchar(50) 
AS
BEGIN
	UPDATE Branch
	SET BranchName = @BranchName,
		[Address]= @Address,
		[Description]= @Description,
		UpdateDate=@UpdateDate,
		UpdateUser=@UpdateUser
	WHERE BranchID=@BranchID
END
GO
/****** Object:  StoredProcedure [dbo].[spBranchInsert]    Script Date: 09/08/2013 05:32:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spBranchInsert]
	@BranchName nvarchar(50),
	@Address nvarchar(50),
	@Description nvarchar(255),
	@CreateDate datetime,
	@CreateUser nvarchar(50),
	@UpdateDate datetime,
	@UpdateUser nvarchar(50) 
AS
BEGIN
	INSERT INTO Branch (BranchName,[Address],[Description],Delete_Flg,CreateDate,CreateUser,UpdateDate,UpdateUser)
	VALUES(@BranchName,@Address,@Description,0,@CreateDate,@CreateUser,@UpdateDate,@UpdateUser)
END
GO
/****** Object:  StoredProcedure [dbo].[spBranchGetTotalCount]    Script Date: 09/08/2013 05:32:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*Author:
 Create date:
 Description: 
 */
-- =============================================
Create proc [dbo].[spBranchGetTotalCount]
(
	@total int out
	)
AS
BEGIN

	SELECT @total = COUNT(BranchID)
	FROM Branch
	WHERE Delete_Flg= 0
	
END
GO
/****** Object:  StoredProcedure [dbo].[spBranchGetByPaging]    Script Date: 09/08/2013 05:32:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*Author:
 Create date:
 Description: 
 */
-- =============================================
Create proc [dbo].[spBranchGetByPaging]
(
	@pageSize int  ,
	@pageIndex int ,
	@field nvarchar(100) = 'a.BranchID ',
	@total int out
	)
AS
BEGIN

	SELECT @total = COUNT(BranchID)
	FROM Branch
	WHERE Delete_Flg= 0
	
	DECLARE @select nvarchar(max),
			@Paramlist nvarchar(max);
	SET @select = ' SELECT ROW_NUMBER() OVER (ORDER BY ' + @field + ') as row,
					BranchID, BranchName,Address,Description FROM Branch a WHERE 1=1 and Delete_Flg = 0';
		
	-- paging
	declare @table nvarchar(max);
	set @table = 'WITH RESULT(row, BranchID, BranchName,Address,Description ) AS ( ';

	-- paging 
	declare @pagingSql nvarchar(max);
	declare @startRow int;
    declare @endRow   int;
	
	set @pagingSql	= 'SELECT * FROM result WHERE row between ';
	set @startRow	= (@pageIndex - 1) * @pageSize + 1;
	set @endRow		= @startRow + @pageSize - 1;
    set @pagingSql	= @pagingSql + convert(varchar(10), @startRow);
	set @pagingSql	= @pagingSql + ' AND ' ;
	set @pagingSql	= @pagingSql + convert(varchar(10), @endRow);
	
	declare @sql nvarchar(max);
	set  @sql = ' ';
	
	set @sql = @table + @select + ') ' + @pagingsql;
	print @sql
	
	set @Paramlist =N''
	exec SP_EXECUTESQL  @sql,
						@Paramlist
						
END
GO
/****** Object:  StoredProcedure [dbo].[spBranchGetByID]    Script Date: 09/08/2013 05:32:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[spBranchGetByID]
	@BranchID int
AS
BEGIN
	SELECT BranchID,BranchName,[Address],[Description]
	FROM Branch
	WHERE Delete_Flg=0 AND BranchID=@BranchID
END
GO
/****** Object:  StoredProcedure [dbo].[spBranchGetAll]    Script Date: 09/08/2013 05:32:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spBranchGetAll] 
AS
BEGIN
	SELECT BranchID, BranchName, [Address],[Description]
	FROM Branch
	WHERE Delete_Flg=0
END
GO
/****** Object:  StoredProcedure [dbo].[spBranchDelete]    Script Date: 09/08/2013 05:32:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
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
