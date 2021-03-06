-- ##########################################################################
-- ##
-- ## Adjust the following script by replacing the 2(!) occurences of
-- ## 'PUT_YOUR_SERVER_NAME_HERE' with your actual server name.
-- ##
-- ##########################################################################


GO

CREATE DATABASE [ZetaHelpDesk]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ZetaHelpDesk_sql', FILENAME = N'E:\DB_FILES\ZetaHelpDesk_sql.mdf' , SIZE = 6144KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ZetaHelpDesk_sql_log', FILENAME = N'E:\DB_FILES\ZetaHelpDesk_sql_log.LDF' , SIZE = 1216KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO



-- ##########################################################################

USE [ZetaHelpDesk]

GO

CREATE TABLE [dbo].[CountryCodes] (
	[ID] [int] IDENTITY (1, 1) NOT NULL,
	[Code2] [nvarchar] (5) NULL,
	[Code3] [nvarchar] (7) NULL,
	[TLD] [nvarchar] (10) NULL,
	[NameEN] [nvarchar] (200) NULL,
	[NameDE] [nvarchar] (200) NULL,
	[IsEUMember] [bit] NOT NULL,
	[IsEurope] [bit] NOT NULL,
	[IsEuroCurrency] [bit] NOT NULL 
)  
GO

CREATE TABLE [dbo].[CustomerCompanies] (
	[ID] [int] IDENTITY (1, 1) NOT NULL,
	[DateCreated] [smalldatetime] NULL,
	[UserSamNameCreated] [nvarchar] (250) NULL,
	[DateModified] [smalldatetime] NULL,
	[UserSamNameModified] [nvarchar] (250) NULL,
	[Remarks] [ntext] NULL,
	[Name1] [nvarchar] (250) NULL,
	[Name2] [nvarchar] (250) NULL,
	[Address1] [nvarchar] (250) NULL,
	[Address2] [nvarchar] (250) NULL,
	[Zip] [nvarchar] (20) NULL,
	[City] [nvarchar] (250) NULL,
	[Country] [nvarchar] (250) NULL,
	[State] [nvarchar] (250) NULL,
	[Phone] [nvarchar] (250) NULL,
	[Fax] [nvarchar] (250) NULL,
	[Mobile] [nvarchar] (250) NULL,
	[EMail] [nvarchar] (250) NULL,
	[Www] [nvarchar] (250) NULL,
	[CrmReplicationUniqueID] [uniqueidentifier] NOT NULL,
	[Timestamp] [timestamp] NOT NULL 
)  
GO

CREATE TABLE [dbo].[CustomerCompanyProperties] (
	[ID] [int] IDENTITY (1, 1) NOT NULL,
	[UniqueID] uniqueidentifier ROWGUIDCOL NOT NULL,
	[CustomerCompanyID] [int] NOT NULL,
	[SymbolicName] [nvarchar] (200) NOT NULL,
	[GroupName] [nvarchar] (200) NULL,
	[Name] [nvarchar] (400) NOT NULL,
	[Value] [nvarchar] (400) NULL,
	[DataType] [nvarchar] (20) NOT NULL,
	[OrderPosition] [int] NULL,
	[IsReadOnly] [bit] NOT NULL 
)  
GO

CREATE TABLE [dbo].[CustomerPersons] (
	[ID] [int] IDENTITY (1, 1) NOT NULL,
	[DateCreated] [smalldatetime] NULL,
	[UserSamNameCreated] [nvarchar] (250) NULL,
	[DateModified] [smalldatetime] NULL,
	[UserSamNameModified] [nvarchar] (250) NULL,
	[Remarks] [ntext] NULL,
	[CompanyID] [int] NULL,
	[FirstName] [nvarchar] (250) NULL,
	[LastName] [nvarchar] (250) NULL,
	[Address1] [nvarchar] (250) NULL,
	[Address2] [nvarchar] (250) NULL,
	[Gender] [nvarchar] (50) NULL,
	[Zip] [nvarchar] (20) NULL,
	[City] [nvarchar] (250) NULL,
	[Country] [nvarchar] (250) NULL,
	[State] [nvarchar] (250) NULL,
	[Phone] [nvarchar] (250) NULL,
	[Fax] [nvarchar] (250) NULL,
	[Mobile] [nvarchar] (250) NULL,
	[EMail] [nvarchar] (250) NULL,
	[Www] [nvarchar] (250) NULL,
	[CrmReplicationUniqueID] [uniqueidentifier] NULL,
	[Department] [nvarchar] (200) NULL,
	[Position] [nvarchar] (200) NULL,
	[Title] [nvarchar] (200) NULL 
)  
GO

CREATE TABLE [dbo].[KeepAlives] (
	[ID] [int] IDENTITY (1, 1) NOT NULL,
	[LastDate] [smalldatetime] NULL,
	[UserName] [nvarchar] (255) NULL,
	[UserDomainName] [nvarchar] (255) NULL,
	[UserWorkstationName] [nvarchar] (255) NULL,
	[MainWindowHandle] [int] NULL 
)  
GO

CREATE TABLE [dbo].[Locks] (
	[ID] [int] IDENTITY (1, 1) NOT NULL,
	[LockDate] [smalldatetime] NULL,
	[Username] [nvarchar] (255) NULL,
	[UserDomainName] [nvarchar] (255) NULL,
	[UserWorkstationName] [nvarchar] (255) NULL,
	[ObjectType] [nvarchar] (255) NULL,
	[ObjectID] [int] NULL,
	[MainWindowHandle] [int] NULL 
)  
GO

CREATE TABLE [dbo].[ProjectTasks] (
	[ID] [int] IDENTITY (1, 1) NOT NULL,
	[DateCreated] [smalldatetime] NULL,
	[UserSamNameCreated] [nvarchar] (250) NULL,
	[DateModified] [smalldatetime] NULL,
	[UserSamNameModified] [nvarchar] (250) NULL,
	[Remarks] [ntext] NULL,
	[ProjectID] [int] NULL,
	[IsCompleted] [bit] NOT NULL,
	[IsBillable] [bit] NULL,
	[WasBilled] [bit] NULL,
	[Name] [nvarchar] (300) NULL,
	[Description] [ntext] NULL,
	[DueDate] [datetime] NULL,
	[Duration] [int] NULL,
	[Date] [datetime] NULL,
	[AttachmentFilename] [nvarchar] (250) NULL,
	[AttachmentFileExtension] [nvarchar] (250) NULL,
	[AttachmentUserReadableFilename] [nvarchar] (250) NULL,
	[AttachmentDescription] [ntext] NULL 
)  
GO

CREATE TABLE [dbo].[Projects] (
	[ID] [int] IDENTITY (1, 1) NOT NULL,
	[UniqueID] uniqueidentifier ROWGUIDCOL NOT NULL,
	[DateCreated] [smalldatetime] NULL,
	[UserSamNameCreated] [nvarchar] (250) NULL,
	[DateModified] [smalldatetime] NULL,
	[UserSamNameModified] [nvarchar] (250) NULL,
	[Remarks] [ntext] NULL,
	[Category] [nvarchar] (400) NULL,
	[Name] [nvarchar] (400) NOT NULL,
	[DueDate] [datetime] NULL,
	[IsCompleted] [bit] NULL,
	[Description] [ntext] NULL,
	[CustomerCompanyID] [int] NOT NULL,
	[AssignedToUserSamName] [nvarchar] (200) NULL 
)  
GO

CREATE TABLE [dbo].[TicketEvents] (
	[ID] [int] IDENTITY (1, 1) NOT NULL,
	[DateCreated] [smalldatetime] NULL,
	[UserSamNameCreated] [nvarchar] (250) NULL,
	[DateModified] [smalldatetime] NULL,
	[UserSamNameModified] [nvarchar] (250) NULL,
	[Remarks] [ntext] NULL,
	[TicketID] [int] NULL,
	[Description] [ntext] NULL,
	[State] [nvarchar] (250) NULL,
	[EventDate] [smalldatetime] NULL,
	[Duration] [int] NULL,
	[AttachmentFilename] [nvarchar] (250) NULL,
	[AttachmentFileExtension] [nvarchar] (250) NULL,
	[AttachmentUserReadableFilename] [nvarchar] (250) NULL,
	[AttachmentDescription] [ntext] NULL,
	[AssignedToUserSamName] [nvarchar] (250) NULL,
	[ContactType] [nvarchar] (250) NULL,
	[CustomerPersonID] [int] NULL 
)  
GO

CREATE TABLE [dbo].[Tickets] (
	[ID] [int] IDENTITY (1, 1) NOT NULL,
	[DateCreated] [smalldatetime] NULL,
	[UserSamNameCreated] [nvarchar] (250) NULL,
	[DateModified] [smalldatetime] NULL,
	[UserSamNameModified] [nvarchar] (250) NULL,
	[Remarks] [ntext] NULL,
	[Title] [nvarchar] (250) NULL,
	[CustomerCompanyID] [int] NULL,
	[CustomerPersonID] [int] NULL,
	[AssignedToUserSamName] [nvarchar] (250) NULL,
	[State] [nvarchar] (250) NULL,
	[Description] [ntext] NULL,
	[TicketClosedDate] [datetime] NULL,
	[TicketDueDate] [datetime] NULL,
	[IsBillable] [bit] NULL,
	[WasBilled] [bit] NULL,
	[GroupName] [nvarchar] (400) NULL 
)  
GO

CREATE TABLE [dbo].[UserGroups] (
	[ID] [int] IDENTITY (1, 1) NOT NULL,
	[DateCreated] [smalldatetime] NULL,
	[UserSamNameCreated] [nvarchar] (250) NULL,
	[DateModified] [smalldatetime] NULL,
	[UserSamNameModified] [nvarchar] (250) NULL,
	[Remarks] [ntext] NULL,
	[Name] [nvarchar] (250) NULL 
)  
GO

CREATE TABLE [dbo].[Users] (
	[ID] [int] IDENTITY (1, 1) NOT NULL,
	[DateCreated] [smalldatetime] NULL,
	[UserSamNameCreated] [nvarchar] (250) NULL,
	[DateModified] [smalldatetime] NULL,
	[UserSamNameModified] [nvarchar] (250) NULL,
	[Remarks] [ntext] NULL,
	[FirstName] [nvarchar] (250) NULL,
	[LastName] [nvarchar] (250) NULL,
	[SamName] [nvarchar] (250) NULL,
	[DomainName] [nvarchar] (250) NULL,
	[Password] [nvarchar] (250) NULL,
	[EMail] [nvarchar] (250) NULL 
)  
GO

ALTER TABLE [dbo].[CountryCodes] WITH NOCHECK ADD 
	CONSTRAINT [PK_CountryCodes] PRIMARY KEY CLUSTERED 
	(
		[ID]
	) WITH FILLFACTOR = 90   
GO

ALTER TABLE [dbo].[CustomerCompanies] WITH NOCHECK ADD 
	CONSTRAINT [PK_CustomerCompanies_1] PRIMARY KEY CLUSTERED 
	(
		[ID]
	) WITH FILLFACTOR = 90   
GO

ALTER TABLE [dbo].[CustomerCompanyProperties] WITH NOCHECK ADD 
	CONSTRAINT [PK_CustomerCompanyProperties] PRIMARY KEY CLUSTERED 
	(
		[ID]
	) WITH FILLFACTOR = 90   
GO

ALTER TABLE [dbo].[CustomerPersons] WITH NOCHECK ADD 
	CONSTRAINT [PK_CustomerPersons] PRIMARY KEY CLUSTERED 
	(
		[ID]
	) WITH FILLFACTOR = 90   
GO

ALTER TABLE [dbo].[KeepAlives] WITH NOCHECK ADD 
	CONSTRAINT [PK_KeepAlives] PRIMARY KEY CLUSTERED 
	(
		[ID]
	) WITH FILLFACTOR = 90   
GO

ALTER TABLE [dbo].[Locks] WITH NOCHECK ADD 
	CONSTRAINT [PK_Locks] PRIMARY KEY CLUSTERED 
	(
		[ID]
	) WITH FILLFACTOR = 90   
GO

ALTER TABLE [dbo].[ProjectTasks] WITH NOCHECK ADD 
	CONSTRAINT [PK_ProjectTasks] PRIMARY KEY CLUSTERED 
	(
		[ID]
	) WITH FILLFACTOR = 90   
GO

ALTER TABLE [dbo].[Projects] WITH NOCHECK ADD 
	CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED 
	(
		[ID]
	) WITH FILLFACTOR = 90   
GO

ALTER TABLE [dbo].[TicketEvents] WITH NOCHECK ADD 
	CONSTRAINT [PK_TicketEvents] PRIMARY KEY CLUSTERED 
	(
		[ID]
	) WITH FILLFACTOR = 90   
GO

ALTER TABLE [dbo].[Tickets] WITH NOCHECK ADD 
	CONSTRAINT [PK_Tickets] PRIMARY KEY CLUSTERED 
	(
		[ID]
	) WITH FILLFACTOR = 90   
GO

ALTER TABLE [dbo].[UserGroups] WITH NOCHECK ADD 
	CONSTRAINT [PK_UserGroups] PRIMARY KEY CLUSTERED 
	(
		[ID]
	) WITH FILLFACTOR = 90   
GO

ALTER TABLE [dbo].[Users] WITH NOCHECK ADD 
	CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
	(
		[ID]
	) WITH FILLFACTOR = 90   
GO

ALTER TABLE [dbo].[CustomerCompanyProperties] ADD 
	CONSTRAINT [DF_CustomerCompanyProperties_UniqueID] DEFAULT (newid()) FOR [UniqueID]
GO

ALTER TABLE [dbo].[Projects] ADD 
	CONSTRAINT [DF_Projects_UniqueID] DEFAULT (newid()) FOR [UniqueID]
GO

ALTER TABLE [dbo].[CustomerCompanyProperties] ADD 
	CONSTRAINT [FK_CustomerCompanyProperties_CustomerCompanies1] FOREIGN KEY 
	(
		[CustomerCompanyID]
	) REFERENCES [dbo].[CustomerCompanies] (
		[ID]
	) ON DELETE CASCADE ON UPDATE CASCADE 
GO

ALTER TABLE [dbo].[CustomerPersons] ADD 
	CONSTRAINT [FK_CustomerPersons_CustomerCompanies1] FOREIGN KEY 
	(
		[CompanyID]
	) REFERENCES [dbo].[CustomerCompanies] (
		[ID]
	) ON DELETE CASCADE ON UPDATE CASCADE 
GO

ALTER TABLE [dbo].[ProjectTasks] ADD 
	CONSTRAINT [FK_ProjectTasks_Projects] FOREIGN KEY 
	(
		[ProjectID]
	) REFERENCES [dbo].[Projects] (
		[ID]
	) ON DELETE CASCADE ON UPDATE CASCADE 
GO

ALTER TABLE [dbo].[Projects] ADD 
	CONSTRAINT [FK_Projects_CustomerCompanies1] FOREIGN KEY 
	(
		[CustomerCompanyID]
	) REFERENCES [dbo].[CustomerCompanies] (
		[ID]
	) ON DELETE CASCADE ON UPDATE CASCADE 
GO

ALTER TABLE [dbo].[TicketEvents] ADD 
	CONSTRAINT [FK_TicketEvents_Tickets] FOREIGN KEY 
	(
		[TicketID]
	) REFERENCES [dbo].[Tickets] (
		[ID]
	) ON DELETE CASCADE ON UPDATE CASCADE 
GO

ALTER TABLE [dbo].[Tickets] ADD 
	CONSTRAINT [FK_Tickets_CustomerCompanies1] FOREIGN KEY 
	(
		[CustomerCompanyID]
	) REFERENCES [dbo].[CustomerCompanies] (
		[ID]
	),
	CONSTRAINT [FK_Tickets_CustomerPersons] FOREIGN KEY 
	(
		[CustomerPersonID]
	) REFERENCES [dbo].[CustomerPersons] (
		[ID]
	)
GO

alter table [dbo].[Tickets] nocheck constraint [FK_Tickets_CustomerCompanies1]
GO

alter table [dbo].[Tickets] nocheck constraint [FK_Tickets_CustomerPersons]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.DeleteCustomerCompanyByID
	@ID int
	
AS
	DELETE FROM [CustomerCompanies] WHERE [ID]=@ID
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.DeleteCustomerCompanyPropertyByID
	@ID int
	
AS
	DELETE
	FROM [CustomerCompanyProperties]
	WHERE [ID]=@ID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.DeleteCustomerPersonByID
	@ID int
	
AS
	DELETE FROM [CustomerPersons] WHERE [ID]=@ID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.DeleteProjectByID
	@ID int
AS
	DELETE FROM [Projects] WHERE [ID]=@ID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

create PROCEDURE dbo.DeleteProjectTaskByID
	@ID int
AS
	DELETE FROM [ProjectTasks] WHERE [ID]=@ID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.DeleteTicketByID
	@ID int
AS
	DELETE FROM [Tickets] WHERE [ID]=@ID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.DeleteTicketEventByID
	@ID int
AS
	DELETE FROM [TicketEvents] WHERE [ID]=@ID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.DeleteUserByID
	@ID int
AS
	DELETE FROM [Users] WHERE [ID]=@ID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

create PROCEDURE dbo.GetAllCountryCodes
AS
	SELECT * FROM [CountryCodes] ORDER BY [NameEN]

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.GetAllCustomerCompanies
	@FilterText nvarchar(300)=''

AS
	SET @FilterText = '%' + @FilterText + '%'

	SELECT * 
	FROM [CustomerCompanies] 
	WHERE 
	(
		[Name1] LIKE @FilterText OR
		[Name2] LIKE @FilterText
	)
	ORDER BY [Name1], [Name2]
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.GetAllCustomerCompaniesWithTickets
	@FilterText nvarchar(300),
	@UserSamName nvarchar(300)=''
	
AS
	SET @FilterText = '%' + @FilterText + '%'

	IF @UserSamName<>'' AND (NOT (@UserSamName IS NULL))
	BEGIN
		SELECT * 
		FROM [CustomerCompanies] 
		WHERE ID IN 
		(
			SELECT DISTINCT([CustomerCompanyID]) 
			FROM [Tickets]
			WHERE [AssignedToUserSamName]=@UserSamName
		) 
		AND 
		(
			[Name1] LIKE @FilterText OR
			[Name2] LIKE @FilterText
		)
		ORDER BY [Name1], [Name2]
	END
	ELSE
	BEGIN
		SELECT * 
		FROM [CustomerCompanies] 
		WHERE ID IN 
		(
			SELECT DISTINCT([CustomerCompanyID]) 
			FROM [Tickets]
		) 
		AND 
		(
			[Name1] LIKE @FilterText OR
			[Name2] LIKE @FilterText
		)
		ORDER BY [Name1], [Name2]
	END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.GetAllCustomerCompaniesWithUnbilledBillableTickets 
	@StartDate datetime,
	@EndDate datetime
AS
	SELECT *
	FROM [CustomerCompanies]
	WHERE [ID] IN
	(
		SELECT [CustomerCompanyID]
		FROM [Tickets]
		WHERE [DateCreated]>=@StartDate 
		AND [DateCreated]<@EndDate
		AND ([WasBilled]=0 OR [WasBilled] IS NULL)
		AND [IsBillable]=1
		AND 
		(
			[State]='ClosedResolved' OR
			[State]='ClosedUnresolved'
		)
	)
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.GetAllCustomerCompanyProperties

AS
	SELECT *
	FROM [CustomerCompanyProperties]
	ORDER BY [CustomerCompanyID], [GroupName], [OrderPosition], [Name], [SymbolicName]
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

create PROCEDURE dbo.GetAllProjectTasks
AS
	SELECT * FROM [ProjectTasks]
	
	
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.GetAllProjects
AS
	SELECT * FROM [Projects]
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.GetAllProjectsWithUnbilledBillableProjectTasks
	@StartDate datetime,
	@EndDate datetime
AS
	SELECT * FROM [Projects]
	WHERE [ID] IN
	(
		SELECT [ProjectID]
		FROM [ProjectTasks]
		
		WHERE [Date]>=@StartDate 
		AND [Date]<@EndDate
		AND ([WasBilled]=0 OR [WasBilled] IS NULL)
		AND [IsBillable]=1
		AND [IsCompleted]=1
	)
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.GetAllTickets
	@FilterText nvarchar(300)=''
AS
	SET @FilterText = '%' + @FilterText + '%'

	SELECT * 
	FROM [Tickets] 
	WHERE
	(
		[Title] LIKE @FilterText OR
		[Description] LIKE @FilterText
	)
	ORDER BY [DateCreated] DESC
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.GetAllUnbilledBillableProjectTasksByProjectID
	@ProjectID int,
	@StartDate datetime,
	@EndDate datetime
AS
	SELECT * FROM [ProjectTasks]
	
	WHERE 
	[ProjectID]=@ProjectID
	AND [Date]>=@StartDate 
	AND [Date]<@EndDate
	AND ([WasBilled]=0 OR [WasBilled] IS NULL)
	AND [IsBillable]=1
	AND [IsCompleted]=1

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.GetAllUsers
AS
	SELECT * FROM [Users]
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.GetCountryCodeByID
	@ID int
AS
	SELECT * FROM [CountryCodes] WHERE [ID]=@ID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.GetCustomerCompanyByID
	@ID int
AS
	SELECT * FROM [CustomerCompanies] WHERE [ID]=@ID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.GetCustomerCompanyPropertyByCustomerCompanyID
	@ID int

AS
	SELECT *
	FROM [CustomerCompanyProperties]
	WHERE [CustomerCompanyID]=@ID
	ORDER BY [GroupName], [OrderPosition], [Name], [SymbolicName]
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.GetCustomerCompanyPropertyByID
	@ID int

AS
	SELECT *
	FROM [CustomerCompanyProperties]
	WHERE [ID]=@ID
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.GetCustomerCompanyPropertyBySymbolicName
	@SymbolicName nvarchar(100)

AS
	SELECT *
	FROM [CustomerCompanyProperties]
	WHERE [SymbolicName]=@SymbolicName
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.GetCustomerCompanySupportContractByCustomerCompanyCrmReplicationUniqueID
	@CrmReplicationUniqueID uniqueidentifier
AS
	SELECT *
	FROM [CustomerCompanySupportContracts]
	WHERE [CrmReplicationUniqueID]=@CrmReplicationUniqueID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.GetCustomerPersonByCustomerCompanyID
	@ID int
AS
	SELECT * FROM [CustomerPersons] WHERE [CompanyID]=@ID ORDER BY [LastName], [FirstName]

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.GetCustomerPersonByID
	@ID int

AS
	SELECT * FROM [CustomerPersons] WHERE [ID]=@ID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.GetDistinctGroupNamesByCustomerCompanyID
	@CustomerCompanyID int

AS
	SELECT DISTINCT([GroupName])
	FROM [Tickets]
	WHERE [CustomerCompanyID]=@CustomerCompanyID
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.GetProjectByID
	@ID int
AS
	SELECT * FROM [Projects] WHERE [ID]=@ID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

create PROCEDURE dbo.GetProjectTaskByID
	@ID int
AS
	SELECT * FROM [ProjectTasks] WHERE [ID]=@ID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.GetProjectTasksByInfo 
	@ProjectID int,
	@StateType nvarchar(100),
	@Print bit=0
	
AS
	DECLARE @SqlWhere nvarchar(4000)
	SET @SqlWhere = ''

	--
	
	IF @SqlWhere<>'' SET @SqlWhere = @SqlWhere + ' AND '

	SET @SqlWhere = @SqlWhere +
		'([ProjectID]=' + CONVERT(nvarchar(100),@ProjectID) + ') '
			
	--
	
	IF @StateType='UnbilledProjectTasks'
	BEGIN
		IF @SqlWhere<>'' SET @SqlWhere = @SqlWhere + ' AND '
	
		SET @SqlWhere = @SqlWhere +
			'([WasBilled]=NULL OR [WasBilled]=0) '
	END
	
	--
	
	DECLARE @Sql nvarchar(4000)
	
	SET @Sql = 
		'SELECT * ' +
		'FROM [ProjectTasks] ' +
		'WHERE ' +
		@SqlWhere + ' ' +
		'ORDER BY [DateCreated] DESC '
		
	--
	
	IF @Print=1
	BEGIN
		PRINT (@Sql)
	END
	ELSE
	BEGIN
		EXECUTE (@Sql)
	END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.GetProjectTasksByProjectID
	@ID int
AS
	SELECT * 
	FROM [ProjectTasks] 
	WHERE [ProjectID]=@ID
	ORDER BY [Date] DESC
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

create PROCEDURE dbo.GetProjectsByCustomerCompanyID
	@ID int
AS
	SELECT * 
	FROM [Projects] 
	WHERE [CustomerCompanyID]=@ID
	ORDER BY [DateCreated] DESC
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.GetProjectsByInfo 
	@UserSamName nvarchar(200),
	@OwnerType nvarchar(100),
	@StateType nvarchar(100),
	@FilterText nvarchar(300),
	@Print bit=0
	
AS

	DECLARE @SqlWhere nvarchar(4000)
	SET @SqlWhere = ''

	--
	
	IF @FilterText<>''
	BEGIN
		IF @SqlWhere<>'' SET @SqlWhere = @SqlWhere + ' AND '
		
		SET @SqlWhere = @SqlWhere + 
			'( ' +
			'	[Name] LIKE ''%' + @FilterText + '%'' OR' +
			'	[Description] LIKE ''%' + @FilterText + '%'' ' +
			') '
	END
	
	IF @OwnerType='OwnProjects' AND @UserSamName<>''
	BEGIN
		IF @SqlWhere<>'' SET @SqlWhere = @SqlWhere + ' AND '
	
		SET @SqlWhere = @SqlWhere +
			'[AssignedToUserSamName]=''' + @UserSamName + ''' '
	END
	
	IF @StateType='OpenProjects'
	BEGIN
		IF @SqlWhere<>'' SET @SqlWhere = @SqlWhere + ' AND '
	
		SET @SqlWhere = @SqlWhere +
			'([IsCompleted]=NULL OR [IsCompleted]=0) '
	END
	
	--
	
	DECLARE @Sql nvarchar(4000)
	
	SET @Sql = 
		'SELECT * ' +
		'FROM [Projects] ' +
		'WHERE ' +
		@SqlWhere + ' ' +
		'ORDER BY [DateCreated] DESC '
		
	--
	
	IF @Print=1
	BEGIN
		PRINT (@Sql)
	END
	ELSE
	BEGIN
		EXECUTE (@Sql)
	END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.GetTicketByID
	@ID int
AS
	SELECT * FROM [Tickets] WHERE [ID]=@ID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.GetTicketEventByID
	@ID int
AS
	SELECT * FROM [TicketEvents] WHERE [ID]=@ID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.GetTicketEventsByTicketID
	@ID int
AS
	SELECT * FROM [TicketEvents] WHERE [TicketID]=@ID ORDER BY [EventDate] ASC

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.GetTicketsAssignedToUserSamName
	@UserSamName nvarchar(200),
	@FilterText nvarchar(300)=''
	
AS
	SET @FilterText = '%' + @FilterText + '%'

	SELECT * 
	FROM [Tickets] 
	WHERE [AssignedToUserSamName]=@UserSamName 
	AND
	(
		[Title] LIKE @FilterText OR
		[Description] LIKE @FilterText
	)
	ORDER BY [DateCreated] DESC
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.GetTicketsAssignedToUserSamNameForCustomerCompany
	@UserSamName nvarchar(200),
	@ID int,
	@FilterText nvarchar(300)=''
	
AS
	SET @FilterText = '%' + @FilterText + '%'

	SELECT * 
	FROM [Tickets] 
	WHERE [AssignedToUserSamName]=@UserSamName 
	AND [CustomerCompanyID]=@ID 
	AND
	(
		[Title] LIKE @FilterText OR
		[Description] LIKE @FilterText
	)
	ORDER BY [DateCreated] DESC
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.GetTicketsAssignedToUserSamNameWithState
	@UserSamName nvarchar(200),
	@State nvarchar(100)
	
AS
	SELECT * 
	FROM [Tickets] 
	WHERE [AssignedToUserSamName]=@UserSamName 
	AND [State]=@State 
	ORDER BY [DateCreated] DESC
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.GetTicketsByCustomerCompanyID
	@ID int,
	@FilterText nvarchar(300)=''
AS
	SET @FilterText = '%' + @FilterText + '%'

	SELECT * 
	FROM [Tickets] 
	WHERE [CustomerCompanyID]=@ID
	AND
	(
		[Title] LIKE @FilterText OR
		[Description] LIKE @FilterText
	)
	ORDER BY [DateCreated] DESC
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.GetTicketsByInfo 
	@CustomerCompanyID int,
	@UserSamName nvarchar(200),
	@OwnerType nvarchar(100),
	@StateType nvarchar(100),
	@FilterText nvarchar(300),
	@Print bit=0
	
AS

	DECLARE @SqlWhere nvarchar(4000)
	SET @SqlWhere = ''

	--
	
	IF @FilterText<>''
	BEGIN
		IF @SqlWhere<>'' SET @SqlWhere = @SqlWhere + ' AND '
		
		SET @SqlWhere = @SqlWhere + 
			'( ' +
			'	[Title] LIKE ''%' + @FilterText + '%'' OR' +
			'	[Description] LIKE ''%' + @FilterText + '%'' ' +
			') '
	END
	
	IF @CustomerCompanyID>0
	BEGIN
		IF @SqlWhere<>'' SET @SqlWhere = @SqlWhere + ' AND '
	
		SET @SqlWhere = @SqlWhere +
			'[CustomerCompanyID]=' + CONVERT(nvarchar(10),@CustomerCompanyID)
	END
	
	IF @OwnerType='OwnTickets' AND @UserSamName<>''
	BEGIN
		IF @SqlWhere<>'' SET @SqlWhere = @SqlWhere + ' AND '
	
		SET @SqlWhere = @SqlWhere +
			'[AssignedToUserSamName]=''' + @UserSamName + ''' '
	END
	
	IF @StateType='OpenTickets'
	BEGIN
		IF @SqlWhere<>'' SET @SqlWhere = @SqlWhere + ' AND '
	
		SET @SqlWhere = @SqlWhere +
			'[State]=''Open'' '
	END
	
	--
	
	DECLARE @Sql nvarchar(4000)
	
	SET @Sql = 
		'SELECT * ' +
		'FROM [Tickets] ' +
		'WHERE ' +
		@SqlWhere + ' ' +
		'ORDER BY [DateCreated] DESC '
		
	--
	
	IF @Print=1
	BEGIN
		PRINT (@Sql)
	END
	ELSE
	BEGIN
		EXECUTE (@Sql)
	END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.GetTicketsForCustomerCompanyAssignedToUser
	@ID int,
	@UserSamName nvarchar(300)
AS
	SELECT * 
	FROM [Tickets] 
	WHERE [CustomerCompanyID]=@ID 
	AND [AssignedToUserSamName]=@UserSamName
	ORDER BY [DateCreated] DESC
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.GetUnbilledBillableTicketsByCustomerCompanyID 
	@CustomerCompanyID int,
	@StartDate datetime,
	@EndDate datetime
AS
	SELECT *
	FROM [Tickets]
	WHERE 
	[CustomerCompanyID]=@CustomerCompanyID
	AND [DateCreated]>=@StartDate 
	AND [DateCreated]<@EndDate
	AND ([WasBilled]=0 OR [WasBilled] IS NULL)
	AND [IsBillable]=1
	AND 
	(
		[State]='ClosedResolved' OR
		[State]='ClosedUnresolved'
	)

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

create PROCEDURE dbo.GetUserByDomainNameAndSamName
	@DomainName nvarchar(200),
	@SamName nvarchar(200)
AS
	SELECT * FROM [Users] WHERE [SamName]=@SamName AND [DomainName]=@DomainName
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.GetUserByID
	@ID int
AS
	SELECT * FROM [Users] WHERE [ID]=@ID
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.GetUserBySamName
	@SamName nvarchar(200)
AS
	SELECT * FROM [Users] WHERE [SamName]=@SamName
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.GetUserBySamNameAndPassword
	@SamName nvarchar(200),
	@Password nvarchar(200)
AS
	SELECT * FROM [Users] WHERE [SamName]=@SamName AND [Password]=@Password
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.GetUserByEMailAddress
	@EMailAddress nvarchar(200)
AS
	SELECT * FROM [Users] WHERE [EMail]=@EMailAddress
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE TABLE [dbo].[CustomerCompanySupportContracts] (
	[CrmReplicationUniqueID] [uniqueidentifier] NULL ,
	[ID] [int] NOT NULL ,
	[StartDate] [datetime] NULL ,
	[EndDate] [datetime] NULL ,
	[Description] [text] NULL ,
	[Name1] [varchar] (200) NULL 
)
GO

-- ##########################################################################
-- Added 2005-10-20.

CREATE PROCEDURE dbo.SearchSimpleForTickets 
	@SearchText nvarchar(1000)
AS
	DECLARE @RealSearchText nvarchar(1500)
	SET @RealSearchText = '%' + @SearchText + '%'
	
	SELECT *
	FROM [Tickets] t
	
	WHERE 
		t.[Title] LIKE @RealSearchText OR
		t.[Description] LIKE @RealSearchText OR
		t.[GroupName] LIKE @RealSearchText OR
		t.[Remarks] LIKE @RealSearchText OR
		t.[ID] IN
		(	
			SELECT e.[TicketID]
			FROM [TicketEvents] e
			WHERE
				e.[Description] LIKE @RealSearchText OR
				e.[Remarks] LIKE @RealSearchText OR
				e.[AttachmentFilename] LIKE @RealSearchText OR
				e.[AttachmentDescription] LIKE @RealSearchText
		)

	ORDER BY t.[DateCreated] DESC
GO

-- ##########################################################################

