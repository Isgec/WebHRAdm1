SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spadmLWServiceSheetDetailsSelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spadmLWServiceSheetDetailsSelectByID]
GO
 
CREATE PROCEDURE [dbo].[spadmLWServiceSheetDetailsSelectByID]
  @SheetID Int,
  @SerialNo Int 
  AS
  SELECT
		[ADM_ServiceSheetDetails].[SheetID] ,
		[ADM_ServiceSheetDetails].[SerialNo] ,
		[ADM_ServiceSheetDetails].[SheetDate] ,
		[ADM_ServiceSheetDetails].[ServiceID] ,
		[ADM_ServiceSheetDetails].[ScheduleID] ,
		[ADM_ServiceSheetDetails].[MeasureID] ,
		[ADM_ServiceSheetDetails].[CheckPointID] ,
		[ADM_ServiceSheetDetails].[Initiated] ,
		[ADM_ServiceSheetDetails].[InitiatedBy] ,
		[ADM_ServiceSheetDetails].[InitiatedOn] ,
		[ADM_ServiceSheetDetails].[InitiatorRemarks] ,
		[ADM_ServiceSheetDetails].[MonitoredBy] ,
		[ADM_ServiceSheetDetails].[Monitored] ,
		[ADM_ServiceSheetDetails].[MonitoredOn] ,
		[ADM_ServiceSheetDetails].[MonitorRemarks] ,
		[ADM_ServiceSheetDetails].[ProblemIdentified] ,
		[ADM_ServiceSheetDetails].[ProblemClosed] ,
		[ADM_ServiceSheetDetails].[ClosedBy] ,
		[ADM_ServiceSheetDetails].[ClosedOn] ,
		[ADM_ServiceSheetDetails].[ClosingRemarks] ,
		[ADM_ServiceSheetDetails].[CPInitiator] ,
		[ADM_CheckPoints1].[Descriptions] AS ADM_CheckPoints1_Descriptions,
		[ADM_Measures2].[Description] AS ADM_Measures2_Description,
		[ADM_Schedules3].[Description] AS ADM_Schedules3_Description,
		[ADM_Services4].[Description] AS ADM_Services4_Description,
		[aspnet_users9].[UserFullName] AS aspnet_users9_UserFullName,
		[HRM_Employees7].[EmployeeName] AS HRM_Employees7_EmployeeName,
		[HRM_Employees8].[EmployeeName] AS HRM_Employees8_EmployeeName,
		[HRM_Employees9].[EmployeeName] AS HRM_Employees9_EmployeeName 
  FROM [ADM_ServiceSheetDetails] 
  LEFT OUTER JOIN [ADM_CheckPoints] AS [ADM_CheckPoints1]
    ON [ADM_ServiceSheetDetails].[CheckPointID] = [ADM_CheckPoints1].[CheckPointID]
  LEFT OUTER JOIN [ADM_Measures] AS [ADM_Measures2]
    ON [ADM_ServiceSheetDetails].[MeasureID] = [ADM_Measures2].[MeasureID]
  LEFT OUTER JOIN [ADM_Schedules] AS [ADM_Schedules3]
    ON [ADM_ServiceSheetDetails].[ScheduleID] = [ADM_Schedules3].[ScheduleID]
  LEFT OUTER JOIN [ADM_Services] AS [ADM_Services4]
    ON [ADM_ServiceSheetDetails].[ServiceID] = [ADM_Services4].[ServiceID]
  INNER JOIN [ADM_ServiceSheetHeader] AS [ADM_ServiceSheetHeader5]
    ON [ADM_ServiceSheetDetails].[SheetID] = [ADM_ServiceSheetHeader5].[SheetID]
  LEFT OUTER JOIN [aspnet_Users] AS [aspnet_Users9]
    ON [ADM_ServiceSheetDetails].[CPInitiator] = [aspnet_Users9].[UserName]
  LEFT OUTER JOIN [HRM_Employees] AS [HRM_Employees7]
    ON [ADM_ServiceSheetDetails].[InitiatedBy] = [HRM_Employees7].[CardNo]
  LEFT OUTER JOIN [HRM_Employees] AS [HRM_Employees8]
    ON [ADM_ServiceSheetDetails].[MonitoredBy] = [HRM_Employees8].[CardNo]
  LEFT OUTER JOIN [HRM_Employees] AS [HRM_Employees9]
    ON [ADM_ServiceSheetDetails].[ClosedBy] = [HRM_Employees9].[CardNo]
  WHERE
  [ADM_ServiceSheetDetails].[SheetID] = @SheetID
  AND [ADM_ServiceSheetDetails].[SerialNo] = @SerialNo
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spadmLWServiceSheetDetailsSelectBySheetID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spadmLWServiceSheetDetailsSelectBySheetID]
GO
 
CREATE PROCEDURE [dbo].[spadmLWServiceSheetDetailsSelectBySheetID]
  @SheetID Int,
  @OrderBy NVarChar(50),
  @RecordCount Int = 0 OUTPUT
  AS
  SELECT
		[ADM_ServiceSheetDetails].[SheetID] ,
		[ADM_ServiceSheetDetails].[SerialNo] ,
		[ADM_ServiceSheetDetails].[SheetDate] ,
		[ADM_ServiceSheetDetails].[ServiceID] ,
		[ADM_ServiceSheetDetails].[ScheduleID] ,
		[ADM_ServiceSheetDetails].[MeasureID] ,
		[ADM_ServiceSheetDetails].[CheckPointID] ,
		[ADM_ServiceSheetDetails].[Initiated] ,
		[ADM_ServiceSheetDetails].[InitiatedBy] ,
		[ADM_ServiceSheetDetails].[InitiatedOn] ,
		[ADM_ServiceSheetDetails].[InitiatorRemarks] ,
		[ADM_ServiceSheetDetails].[MonitoredBy] ,
		[ADM_ServiceSheetDetails].[Monitored] ,
		[ADM_ServiceSheetDetails].[MonitoredOn] ,
		[ADM_ServiceSheetDetails].[MonitorRemarks] ,
		[ADM_ServiceSheetDetails].[ProblemIdentified] ,
		[ADM_ServiceSheetDetails].[ProblemClosed] ,
		[ADM_ServiceSheetDetails].[ClosedBy] ,
		[ADM_ServiceSheetDetails].[ClosedOn] ,
		[ADM_ServiceSheetDetails].[ClosingRemarks] ,
		[ADM_ServiceSheetDetails].[CPInitiator] ,
		[ADM_CheckPoints1].[Descriptions] AS ADM_CheckPoints1_Descriptions,
		[ADM_Measures2].[Description] AS ADM_Measures2_Description,
		[ADM_Schedules3].[Description] AS ADM_Schedules3_Description,
		[ADM_Services4].[Description] AS ADM_Services4_Description,
		[aspnet_users9].[UserFullName] AS aspnet_users9_UserFullName,
		[HRM_Employees7].[EmployeeName] AS HRM_Employees7_EmployeeName,
		[HRM_Employees8].[EmployeeName] AS HRM_Employees8_EmployeeName,
		[HRM_Employees9].[EmployeeName] AS HRM_Employees9_EmployeeName 
  FROM [ADM_ServiceSheetDetails] 
  LEFT OUTER JOIN [ADM_CheckPoints] AS [ADM_CheckPoints1]
    ON [ADM_ServiceSheetDetails].[CheckPointID] = [ADM_CheckPoints1].[CheckPointID]
  LEFT OUTER JOIN [ADM_Measures] AS [ADM_Measures2]
    ON [ADM_ServiceSheetDetails].[MeasureID] = [ADM_Measures2].[MeasureID]
  LEFT OUTER JOIN [ADM_Schedules] AS [ADM_Schedules3]
    ON [ADM_ServiceSheetDetails].[ScheduleID] = [ADM_Schedules3].[ScheduleID]
  LEFT OUTER JOIN [ADM_Services] AS [ADM_Services4]
    ON [ADM_ServiceSheetDetails].[ServiceID] = [ADM_Services4].[ServiceID]
  INNER JOIN [ADM_ServiceSheetHeader] AS [ADM_ServiceSheetHeader5]
    ON [ADM_ServiceSheetDetails].[SheetID] = [ADM_ServiceSheetHeader5].[SheetID]
  LEFT OUTER JOIN [aspnet_Users] AS [aspnet_Users9]
    ON [ADM_ServiceSheetDetails].[CPInitiator] = [aspnet_Users9].[UserName]
  LEFT OUTER JOIN [HRM_Employees] AS [HRM_Employees7]
    ON [ADM_ServiceSheetDetails].[InitiatedBy] = [HRM_Employees7].[CardNo]
  LEFT OUTER JOIN [HRM_Employees] AS [HRM_Employees8]
    ON [ADM_ServiceSheetDetails].[MonitoredBy] = [HRM_Employees8].[CardNo]
  LEFT OUTER JOIN [HRM_Employees] AS [HRM_Employees9]
    ON [ADM_ServiceSheetDetails].[ClosedBy] = [HRM_Employees9].[CardNo]
  WHERE
  [ADM_ServiceSheetDetails].[SheetID] = @SheetID
  ORDER BY
     CASE @orderBy WHEN 'SheetID' THEN [ADM_ServiceSheetDetails].[SheetID] END,
     CASE @orderBy WHEN 'SheetID DESC' THEN [ADM_ServiceSheetDetails].[SheetID] END DESC,
     CASE @orderBy WHEN 'SerialNo' THEN [ADM_ServiceSheetDetails].[SerialNo] END,
     CASE @orderBy WHEN 'SerialNo DESC' THEN [ADM_ServiceSheetDetails].[SerialNo] END DESC,
     CASE @orderBy WHEN 'SheetDate' THEN [ADM_ServiceSheetDetails].[SheetDate] END,
     CASE @orderBy WHEN 'SheetDate DESC' THEN [ADM_ServiceSheetDetails].[SheetDate] END DESC,
     CASE @orderBy WHEN 'ServiceID' THEN [ADM_ServiceSheetDetails].[ServiceID] END,
     CASE @orderBy WHEN 'ServiceID DESC' THEN [ADM_ServiceSheetDetails].[ServiceID] END DESC,
     CASE @orderBy WHEN 'ScheduleID' THEN [ADM_ServiceSheetDetails].[ScheduleID] END,
     CASE @orderBy WHEN 'ScheduleID DESC' THEN [ADM_ServiceSheetDetails].[ScheduleID] END DESC,
     CASE @orderBy WHEN 'MeasureID' THEN [ADM_ServiceSheetDetails].[MeasureID] END,
     CASE @orderBy WHEN 'MeasureID DESC' THEN [ADM_ServiceSheetDetails].[MeasureID] END DESC,
     CASE @orderBy WHEN 'CheckPointID' THEN [ADM_ServiceSheetDetails].[CheckPointID] END,
     CASE @orderBy WHEN 'CheckPointID DESC' THEN [ADM_ServiceSheetDetails].[CheckPointID] END DESC,
     CASE @orderBy WHEN 'Initiated' THEN [ADM_ServiceSheetDetails].[Initiated] END,
     CASE @orderBy WHEN 'Initiated DESC' THEN [ADM_ServiceSheetDetails].[Initiated] END DESC,
     CASE @orderBy WHEN 'InitiatedBy' THEN [ADM_ServiceSheetDetails].[InitiatedBy] END,
     CASE @orderBy WHEN 'InitiatedBy DESC' THEN [ADM_ServiceSheetDetails].[InitiatedBy] END DESC,
     CASE @orderBy WHEN 'InitiatedOn' THEN [ADM_ServiceSheetDetails].[InitiatedOn] END,
     CASE @orderBy WHEN 'InitiatedOn DESC' THEN [ADM_ServiceSheetDetails].[InitiatedOn] END DESC,
     CASE @orderBy WHEN 'InitiatorRemarks' THEN [ADM_ServiceSheetDetails].[InitiatorRemarks] END,
     CASE @orderBy WHEN 'InitiatorRemarks DESC' THEN [ADM_ServiceSheetDetails].[InitiatorRemarks] END DESC,
     CASE @orderBy WHEN 'MonitoredBy' THEN [ADM_ServiceSheetDetails].[MonitoredBy] END,
     CASE @orderBy WHEN 'MonitoredBy DESC' THEN [ADM_ServiceSheetDetails].[MonitoredBy] END DESC,
     CASE @orderBy WHEN 'Monitored' THEN [ADM_ServiceSheetDetails].[Monitored] END,
     CASE @orderBy WHEN 'Monitored DESC' THEN [ADM_ServiceSheetDetails].[Monitored] END DESC,
     CASE @orderBy WHEN 'MonitoredOn' THEN [ADM_ServiceSheetDetails].[MonitoredOn] END,
     CASE @orderBy WHEN 'MonitoredOn DESC' THEN [ADM_ServiceSheetDetails].[MonitoredOn] END DESC,
     CASE @orderBy WHEN 'MonitorRemarks' THEN [ADM_ServiceSheetDetails].[MonitorRemarks] END,
     CASE @orderBy WHEN 'MonitorRemarks DESC' THEN [ADM_ServiceSheetDetails].[MonitorRemarks] END DESC,
     CASE @orderBy WHEN 'ProblemIdentified' THEN [ADM_ServiceSheetDetails].[ProblemIdentified] END,
     CASE @orderBy WHEN 'ProblemIdentified DESC' THEN [ADM_ServiceSheetDetails].[ProblemIdentified] END DESC,
     CASE @orderBy WHEN 'ProblemClosed' THEN [ADM_ServiceSheetDetails].[ProblemClosed] END,
     CASE @orderBy WHEN 'ProblemClosed DESC' THEN [ADM_ServiceSheetDetails].[ProblemClosed] END DESC,
     CASE @orderBy WHEN 'ClosedBy' THEN [ADM_ServiceSheetDetails].[ClosedBy] END,
     CASE @orderBy WHEN 'ClosedBy DESC' THEN [ADM_ServiceSheetDetails].[ClosedBy] END DESC,
     CASE @orderBy WHEN 'ClosedOn' THEN [ADM_ServiceSheetDetails].[ClosedOn] END,
     CASE @orderBy WHEN 'ClosedOn DESC' THEN [ADM_ServiceSheetDetails].[ClosedOn] END DESC,
     CASE @orderBy WHEN 'ClosingRemarks' THEN [ADM_ServiceSheetDetails].[ClosingRemarks] END,
     CASE @orderBy WHEN 'ClosingRemarks DESC' THEN [ADM_ServiceSheetDetails].[ClosingRemarks] END DESC,
     CASE @orderBy WHEN 'CPInitiator' THEN [ADM_ServiceSheetDetails].[CPInitiator] END,
     CASE @orderBy WHEN 'CPInitiator DESC' THEN [ADM_ServiceSheetDetails].[CPInitiator] END DESC,
     CASE @orderBy WHEN 'ADM_CheckPoints1_Descriptions' THEN [ADM_CheckPoints1].[Descriptions] END,
     CASE @orderBy WHEN 'ADM_CheckPoints1_Descriptions DESC' THEN [ADM_CheckPoints1].[Descriptions] END DESC,
     CASE @orderBy WHEN 'ADM_Measures2_Description' THEN [ADM_Measures2].[Description] END,
     CASE @orderBy WHEN 'ADM_Measures2_Description DESC' THEN [ADM_Measures2].[Description] END DESC,
     CASE @orderBy WHEN 'ADM_Schedules3_Description' THEN [ADM_Schedules3].[Description] END,
     CASE @orderBy WHEN 'ADM_Schedules3_Description DESC' THEN [ADM_Schedules3].[Description] END DESC,
     CASE @orderBy WHEN 'ADM_Services4_Description' THEN [ADM_Services4].[Description] END,
     CASE @orderBy WHEN 'ADM_Services4_Description DESC' THEN [ADM_Services4].[Description] END DESC,
     CASE @orderBy WHEN 'aspnet_users9_UserFullName' THEN [aspnet_users9].[UserFullName] END,
     CASE @orderBy WHEN 'aspnet_users9_UserFullName DESC' THEN [aspnet_users9].[UserFullName] END DESC,
     CASE @orderBy WHEN 'HRM_Employees7_EmployeeName' THEN [HRM_Employees7].[EmployeeName] END,
     CASE @orderBy WHEN 'HRM_Employees7_EmployeeName DESC' THEN [HRM_Employees7].[EmployeeName] END DESC,
     CASE @orderBy WHEN 'HRM_Employees8_EmployeeName' THEN [HRM_Employees8].[EmployeeName] END,
     CASE @orderBy WHEN 'HRM_Employees8_EmployeeName DESC' THEN [HRM_Employees8].[EmployeeName] END DESC,
     CASE @orderBy WHEN 'HRM_Employees9_EmployeeName' THEN [HRM_Employees9].[EmployeeName] END,
     CASE @orderBy WHEN 'HRM_Employees9_EmployeeName DESC' THEN [HRM_Employees9].[EmployeeName] END DESC 
  SET @RecordCount = @@RowCount
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spadmLWServiceSheetDetailsSelectListSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spadmLWServiceSheetDetailsSelectListSearch]
GO
 
CREATE PROCEDURE [dbo].[spadmLWServiceSheetDetailsSelectListSearch]
  @StartRowIndex int,
  @MaximumRows int,
  @KeyWord VarChar(250),
  @OrderBy NVarChar(50),
  @RecordCount Int = 0 OUTPUT
  AS
  BEGIN
    DECLARE @KeyWord1 VarChar(260)
    SET @KeyWord1 = '%' + LOWER(@KeyWord) + '%'
  CREATE TABLE #PageIndex (
  IndexId INT IDENTITY (1, 1) NOT NULL
 ,SheetID Int NOT NULL
 ,SerialNo Int NOT NULL
  )
  INSERT INTO #PageIndex (SheetID, SerialNo)
  SELECT [ADM_ServiceSheetDetails].[SheetID], [ADM_ServiceSheetDetails].[SerialNo] FROM [ADM_ServiceSheetDetails]
  LEFT OUTER JOIN [ADM_CheckPoints] AS [ADM_CheckPoints1]
    ON [ADM_ServiceSheetDetails].[CheckPointID] = [ADM_CheckPoints1].[CheckPointID]
  LEFT OUTER JOIN [ADM_Measures] AS [ADM_Measures2]
    ON [ADM_ServiceSheetDetails].[MeasureID] = [ADM_Measures2].[MeasureID]
  LEFT OUTER JOIN [ADM_Schedules] AS [ADM_Schedules3]
    ON [ADM_ServiceSheetDetails].[ScheduleID] = [ADM_Schedules3].[ScheduleID]
  LEFT OUTER JOIN [ADM_Services] AS [ADM_Services4]
    ON [ADM_ServiceSheetDetails].[ServiceID] = [ADM_Services4].[ServiceID]
  INNER JOIN [ADM_ServiceSheetHeader] AS [ADM_ServiceSheetHeader5]
    ON [ADM_ServiceSheetDetails].[SheetID] = [ADM_ServiceSheetHeader5].[SheetID]
  LEFT OUTER JOIN [aspnet_Users] AS [aspnet_Users9]
    ON [ADM_ServiceSheetDetails].[CPInitiator] = [aspnet_Users9].[UserName]
  LEFT OUTER JOIN [HRM_Employees] AS [HRM_Employees7]
    ON [ADM_ServiceSheetDetails].[InitiatedBy] = [HRM_Employees7].[CardNo]
  LEFT OUTER JOIN [HRM_Employees] AS [HRM_Employees8]
    ON [ADM_ServiceSheetDetails].[MonitoredBy] = [HRM_Employees8].[CardNo]
  LEFT OUTER JOIN [HRM_Employees] AS [HRM_Employees9]
    ON [ADM_ServiceSheetDetails].[ClosedBy] = [HRM_Employees9].[CardNo]
 WHERE  
   ( 
         STR(ISNULL([ADM_ServiceSheetDetails].[SheetID], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ADM_ServiceSheetDetails].[SerialNo], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ADM_ServiceSheetDetails].[ServiceID],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ADM_ServiceSheetDetails].[ScheduleID],'')) LIKE @KeyWord1
     OR STR(ISNULL([ADM_ServiceSheetDetails].[MeasureID], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ADM_ServiceSheetDetails].[CheckPointID], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ADM_ServiceSheetDetails].[InitiatedBy],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ADM_ServiceSheetDetails].[InitiatorRemarks],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ADM_ServiceSheetDetails].[MonitoredBy],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ADM_ServiceSheetDetails].[MonitorRemarks],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ADM_ServiceSheetDetails].[ClosedBy],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ADM_ServiceSheetDetails].[ClosingRemarks],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ADM_ServiceSheetDetails].[CPInitiator],'')) LIKE @KeyWord1
   ) 
  ORDER BY
     CASE @orderBy WHEN 'SheetID' THEN [ADM_ServiceSheetDetails].[SheetID] END,
     CASE @orderBy WHEN 'SheetID DESC' THEN [ADM_ServiceSheetDetails].[SheetID] END DESC,
     CASE @orderBy WHEN 'SerialNo' THEN [ADM_ServiceSheetDetails].[SerialNo] END,
     CASE @orderBy WHEN 'SerialNo DESC' THEN [ADM_ServiceSheetDetails].[SerialNo] END DESC,
     CASE @orderBy WHEN 'SheetDate' THEN [ADM_ServiceSheetDetails].[SheetDate] END,
     CASE @orderBy WHEN 'SheetDate DESC' THEN [ADM_ServiceSheetDetails].[SheetDate] END DESC,
     CASE @orderBy WHEN 'ServiceID' THEN [ADM_ServiceSheetDetails].[ServiceID] END,
     CASE @orderBy WHEN 'ServiceID DESC' THEN [ADM_ServiceSheetDetails].[ServiceID] END DESC,
     CASE @orderBy WHEN 'ScheduleID' THEN [ADM_ServiceSheetDetails].[ScheduleID] END,
     CASE @orderBy WHEN 'ScheduleID DESC' THEN [ADM_ServiceSheetDetails].[ScheduleID] END DESC,
     CASE @orderBy WHEN 'MeasureID' THEN [ADM_ServiceSheetDetails].[MeasureID] END,
     CASE @orderBy WHEN 'MeasureID DESC' THEN [ADM_ServiceSheetDetails].[MeasureID] END DESC,
     CASE @orderBy WHEN 'CheckPointID' THEN [ADM_ServiceSheetDetails].[CheckPointID] END,
     CASE @orderBy WHEN 'CheckPointID DESC' THEN [ADM_ServiceSheetDetails].[CheckPointID] END DESC,
     CASE @orderBy WHEN 'Initiated' THEN [ADM_ServiceSheetDetails].[Initiated] END,
     CASE @orderBy WHEN 'Initiated DESC' THEN [ADM_ServiceSheetDetails].[Initiated] END DESC,
     CASE @orderBy WHEN 'InitiatedBy' THEN [ADM_ServiceSheetDetails].[InitiatedBy] END,
     CASE @orderBy WHEN 'InitiatedBy DESC' THEN [ADM_ServiceSheetDetails].[InitiatedBy] END DESC,
     CASE @orderBy WHEN 'InitiatedOn' THEN [ADM_ServiceSheetDetails].[InitiatedOn] END,
     CASE @orderBy WHEN 'InitiatedOn DESC' THEN [ADM_ServiceSheetDetails].[InitiatedOn] END DESC,
     CASE @orderBy WHEN 'InitiatorRemarks' THEN [ADM_ServiceSheetDetails].[InitiatorRemarks] END,
     CASE @orderBy WHEN 'InitiatorRemarks DESC' THEN [ADM_ServiceSheetDetails].[InitiatorRemarks] END DESC,
     CASE @orderBy WHEN 'MonitoredBy' THEN [ADM_ServiceSheetDetails].[MonitoredBy] END,
     CASE @orderBy WHEN 'MonitoredBy DESC' THEN [ADM_ServiceSheetDetails].[MonitoredBy] END DESC,
     CASE @orderBy WHEN 'Monitored' THEN [ADM_ServiceSheetDetails].[Monitored] END,
     CASE @orderBy WHEN 'Monitored DESC' THEN [ADM_ServiceSheetDetails].[Monitored] END DESC,
     CASE @orderBy WHEN 'MonitoredOn' THEN [ADM_ServiceSheetDetails].[MonitoredOn] END,
     CASE @orderBy WHEN 'MonitoredOn DESC' THEN [ADM_ServiceSheetDetails].[MonitoredOn] END DESC,
     CASE @orderBy WHEN 'MonitorRemarks' THEN [ADM_ServiceSheetDetails].[MonitorRemarks] END,
     CASE @orderBy WHEN 'MonitorRemarks DESC' THEN [ADM_ServiceSheetDetails].[MonitorRemarks] END DESC,
     CASE @orderBy WHEN 'ProblemIdentified' THEN [ADM_ServiceSheetDetails].[ProblemIdentified] END,
     CASE @orderBy WHEN 'ProblemIdentified DESC' THEN [ADM_ServiceSheetDetails].[ProblemIdentified] END DESC,
     CASE @orderBy WHEN 'ProblemClosed' THEN [ADM_ServiceSheetDetails].[ProblemClosed] END,
     CASE @orderBy WHEN 'ProblemClosed DESC' THEN [ADM_ServiceSheetDetails].[ProblemClosed] END DESC,
     CASE @orderBy WHEN 'ClosedBy' THEN [ADM_ServiceSheetDetails].[ClosedBy] END,
     CASE @orderBy WHEN 'ClosedBy DESC' THEN [ADM_ServiceSheetDetails].[ClosedBy] END DESC,
     CASE @orderBy WHEN 'ClosedOn' THEN [ADM_ServiceSheetDetails].[ClosedOn] END,
     CASE @orderBy WHEN 'ClosedOn DESC' THEN [ADM_ServiceSheetDetails].[ClosedOn] END DESC,
     CASE @orderBy WHEN 'ClosingRemarks' THEN [ADM_ServiceSheetDetails].[ClosingRemarks] END,
     CASE @orderBy WHEN 'ClosingRemarks DESC' THEN [ADM_ServiceSheetDetails].[ClosingRemarks] END DESC,
     CASE @orderBy WHEN 'CPInitiator' THEN [ADM_ServiceSheetDetails].[CPInitiator] END,
     CASE @orderBy WHEN 'CPInitiator DESC' THEN [ADM_ServiceSheetDetails].[CPInitiator] END DESC,
     CASE @orderBy WHEN 'ADM_CheckPoints1_Descriptions' THEN [ADM_CheckPoints1].[Descriptions] END,
     CASE @orderBy WHEN 'ADM_CheckPoints1_Descriptions DESC' THEN [ADM_CheckPoints1].[Descriptions] END DESC,
     CASE @orderBy WHEN 'ADM_Measures2_Description' THEN [ADM_Measures2].[Description] END,
     CASE @orderBy WHEN 'ADM_Measures2_Description DESC' THEN [ADM_Measures2].[Description] END DESC,
     CASE @orderBy WHEN 'ADM_Schedules3_Description' THEN [ADM_Schedules3].[Description] END,
     CASE @orderBy WHEN 'ADM_Schedules3_Description DESC' THEN [ADM_Schedules3].[Description] END DESC,
     CASE @orderBy WHEN 'ADM_Services4_Description' THEN [ADM_Services4].[Description] END,
     CASE @orderBy WHEN 'ADM_Services4_Description DESC' THEN [ADM_Services4].[Description] END DESC,
     CASE @orderBy WHEN 'aspnet_users9_UserFullName' THEN [aspnet_users9].[UserFullName] END,
     CASE @orderBy WHEN 'aspnet_users9_UserFullName DESC' THEN [aspnet_users9].[UserFullName] END DESC,
     CASE @orderBy WHEN 'HRM_Employees7_EmployeeName' THEN [HRM_Employees7].[EmployeeName] END,
     CASE @orderBy WHEN 'HRM_Employees7_EmployeeName DESC' THEN [HRM_Employees7].[EmployeeName] END DESC,
     CASE @orderBy WHEN 'HRM_Employees8_EmployeeName' THEN [HRM_Employees8].[EmployeeName] END,
     CASE @orderBy WHEN 'HRM_Employees8_EmployeeName DESC' THEN [HRM_Employees8].[EmployeeName] END DESC,
     CASE @orderBy WHEN 'HRM_Employees9_EmployeeName' THEN [HRM_Employees9].[EmployeeName] END,
     CASE @orderBy WHEN 'HRM_Employees9_EmployeeName DESC' THEN [HRM_Employees9].[EmployeeName] END DESC 

    SET @RecordCount = @@RowCount

  SELECT
		[ADM_ServiceSheetDetails].[SheetID] ,
		[ADM_ServiceSheetDetails].[SerialNo] ,
		[ADM_ServiceSheetDetails].[SheetDate] ,
		[ADM_ServiceSheetDetails].[ServiceID] ,
		[ADM_ServiceSheetDetails].[ScheduleID] ,
		[ADM_ServiceSheetDetails].[MeasureID] ,
		[ADM_ServiceSheetDetails].[CheckPointID] ,
		[ADM_ServiceSheetDetails].[Initiated] ,
		[ADM_ServiceSheetDetails].[InitiatedBy] ,
		[ADM_ServiceSheetDetails].[InitiatedOn] ,
		[ADM_ServiceSheetDetails].[InitiatorRemarks] ,
		[ADM_ServiceSheetDetails].[MonitoredBy] ,
		[ADM_ServiceSheetDetails].[Monitored] ,
		[ADM_ServiceSheetDetails].[MonitoredOn] ,
		[ADM_ServiceSheetDetails].[MonitorRemarks] ,
		[ADM_ServiceSheetDetails].[ProblemIdentified] ,
		[ADM_ServiceSheetDetails].[ProblemClosed] ,
		[ADM_ServiceSheetDetails].[ClosedBy] ,
		[ADM_ServiceSheetDetails].[ClosedOn] ,
		[ADM_ServiceSheetDetails].[ClosingRemarks] ,
		[ADM_ServiceSheetDetails].[CPInitiator] ,
		[ADM_CheckPoints1].[Descriptions] AS ADM_CheckPoints1_Descriptions,
		[ADM_Measures2].[Description] AS ADM_Measures2_Description,
		[ADM_Schedules3].[Description] AS ADM_Schedules3_Description,
		[ADM_Services4].[Description] AS ADM_Services4_Description,
		[aspnet_users9].[UserFullName] AS aspnet_users9_UserFullName,
		[HRM_Employees7].[EmployeeName] AS HRM_Employees7_EmployeeName,
		[HRM_Employees8].[EmployeeName] AS HRM_Employees8_EmployeeName,
		[HRM_Employees9].[EmployeeName] AS HRM_Employees9_EmployeeName 
  FROM [ADM_ServiceSheetDetails] 
    	INNER JOIN #PageIndex
          ON [ADM_ServiceSheetDetails].[SheetID] = #PageIndex.SheetID
          AND [ADM_ServiceSheetDetails].[SerialNo] = #PageIndex.SerialNo
  LEFT OUTER JOIN [ADM_CheckPoints] AS [ADM_CheckPoints1]
    ON [ADM_ServiceSheetDetails].[CheckPointID] = [ADM_CheckPoints1].[CheckPointID]
  LEFT OUTER JOIN [ADM_Measures] AS [ADM_Measures2]
    ON [ADM_ServiceSheetDetails].[MeasureID] = [ADM_Measures2].[MeasureID]
  LEFT OUTER JOIN [ADM_Schedules] AS [ADM_Schedules3]
    ON [ADM_ServiceSheetDetails].[ScheduleID] = [ADM_Schedules3].[ScheduleID]
  LEFT OUTER JOIN [ADM_Services] AS [ADM_Services4]
    ON [ADM_ServiceSheetDetails].[ServiceID] = [ADM_Services4].[ServiceID]
  INNER JOIN [ADM_ServiceSheetHeader] AS [ADM_ServiceSheetHeader5]
    ON [ADM_ServiceSheetDetails].[SheetID] = [ADM_ServiceSheetHeader5].[SheetID]
  LEFT OUTER JOIN [aspnet_Users] AS [aspnet_Users9]
    ON [ADM_ServiceSheetDetails].[CPInitiator] = [aspnet_Users9].[UserName]
  LEFT OUTER JOIN [HRM_Employees] AS [HRM_Employees7]
    ON [ADM_ServiceSheetDetails].[InitiatedBy] = [HRM_Employees7].[CardNo]
  LEFT OUTER JOIN [HRM_Employees] AS [HRM_Employees8]
    ON [ADM_ServiceSheetDetails].[MonitoredBy] = [HRM_Employees8].[CardNo]
  LEFT OUTER JOIN [HRM_Employees] AS [HRM_Employees9]
    ON [ADM_ServiceSheetDetails].[ClosedBy] = [HRM_Employees9].[CardNo]
  WHERE
        #PageIndex.IndexID > @startRowIndex
        AND #PageIndex.IndexID < (@startRowIndex + @maximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spadmLWServiceSheetDetailsSelectListFilteres]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spadmLWServiceSheetDetailsSelectListFilteres]
GO
 
CREATE PROCEDURE [dbo].[spadmLWServiceSheetDetailsSelectListFilteres]
  @StartRowIndex int,
  @MaximumRows int,
  @OrderBy NVarChar(50),
  @RecordCount Int = 0 OUTPUT
  AS
  BEGIN
  DECLARE @LGSQL VarChar(8000)
  CREATE TABLE #PageIndex (
  IndexId INT IDENTITY (1, 1) NOT NULL
 ,SheetID Int NOT NULL
 ,SerialNo Int NOT NULL
  )
  SET @LGSQL = 'INSERT INTO #PageIndex (' 
  SET @LGSQL = @LGSQL + 'SheetID'
  SET @LGSQL = @LGSQL + ', SerialNo'
  SET @LGSQL = @LGSQL + ')'
  SET @LGSQL = @LGSQL + ' SELECT '
  SET @LGSQL = @LGSQL + '[ADM_ServiceSheetDetails].[SheetID]'
  SET @LGSQL = @LGSQL + ', [ADM_ServiceSheetDetails].[SerialNo]'
  SET @LGSQL = @LGSQL + ' FROM [ADM_ServiceSheetDetails] '
  SET @LGSQL = @LGSQL + '  LEFT OUTER JOIN [ADM_CheckPoints] AS [ADM_CheckPoints1]'
  SET @LGSQL = @LGSQL + '    ON [ADM_ServiceSheetDetails].[CheckPointID] = [ADM_CheckPoints1].[CheckPointID]'
  SET @LGSQL = @LGSQL + '  LEFT OUTER JOIN [ADM_Measures] AS [ADM_Measures2]'
  SET @LGSQL = @LGSQL + '    ON [ADM_ServiceSheetDetails].[MeasureID] = [ADM_Measures2].[MeasureID]'
  SET @LGSQL = @LGSQL + '  LEFT OUTER JOIN [ADM_Schedules] AS [ADM_Schedules3]'
  SET @LGSQL = @LGSQL + '    ON [ADM_ServiceSheetDetails].[ScheduleID] = [ADM_Schedules3].[ScheduleID]'
  SET @LGSQL = @LGSQL + '  LEFT OUTER JOIN [ADM_Services] AS [ADM_Services4]'
  SET @LGSQL = @LGSQL + '    ON [ADM_ServiceSheetDetails].[ServiceID] = [ADM_Services4].[ServiceID]'
  SET @LGSQL = @LGSQL + '  INNER JOIN [ADM_ServiceSheetHeader] AS [ADM_ServiceSheetHeader5]'
  SET @LGSQL = @LGSQL + '    ON [ADM_ServiceSheetDetails].[SheetID] = [ADM_ServiceSheetHeader5].[SheetID]'
  SET @LGSQL = @LGSQL + '  LEFT OUTER JOIN [aspnet_Users] AS [aspnet_Users9]'
  SET @LGSQL = @LGSQL + '    ON [ADM_ServiceSheetDetails].[CPInitiator] = [aspnet_Users9].[UserName]'
  SET @LGSQL = @LGSQL + '  LEFT OUTER JOIN [HRM_Employees] AS [HRM_Employees7]'
  SET @LGSQL = @LGSQL + '    ON [ADM_ServiceSheetDetails].[InitiatedBy] = [HRM_Employees7].[CardNo]'
  SET @LGSQL = @LGSQL + '  LEFT OUTER JOIN [HRM_Employees] AS [HRM_Employees8]'
  SET @LGSQL = @LGSQL + '    ON [ADM_ServiceSheetDetails].[MonitoredBy] = [HRM_Employees8].[CardNo]'
  SET @LGSQL = @LGSQL + '  LEFT OUTER JOIN [HRM_Employees] AS [HRM_Employees9]'
  SET @LGSQL = @LGSQL + '    ON [ADM_ServiceSheetDetails].[ClosedBy] = [HRM_Employees9].[CardNo]'
  SET @LGSQL = @LGSQL + '  WHERE 1 = 1 '
  SET @LGSQL = @LGSQL + '  ORDER BY '
  SET @LGSQL = @LGSQL + CASE @OrderBy
                        WHEN 'SheetID' THEN '[ADM_ServiceSheetDetails].[SheetID]'
                        WHEN 'SheetID DESC' THEN '[ADM_ServiceSheetDetails].[SheetID] DESC'
                        WHEN 'SerialNo' THEN '[ADM_ServiceSheetDetails].[SerialNo]'
                        WHEN 'SerialNo DESC' THEN '[ADM_ServiceSheetDetails].[SerialNo] DESC'
                        WHEN 'SheetDate' THEN '[ADM_ServiceSheetDetails].[SheetDate]'
                        WHEN 'SheetDate DESC' THEN '[ADM_ServiceSheetDetails].[SheetDate] DESC'
                        WHEN 'ServiceID' THEN '[ADM_ServiceSheetDetails].[ServiceID]'
                        WHEN 'ServiceID DESC' THEN '[ADM_ServiceSheetDetails].[ServiceID] DESC'
                        WHEN 'ScheduleID' THEN '[ADM_ServiceSheetDetails].[ScheduleID]'
                        WHEN 'ScheduleID DESC' THEN '[ADM_ServiceSheetDetails].[ScheduleID] DESC'
                        WHEN 'MeasureID' THEN '[ADM_ServiceSheetDetails].[MeasureID]'
                        WHEN 'MeasureID DESC' THEN '[ADM_ServiceSheetDetails].[MeasureID] DESC'
                        WHEN 'CheckPointID' THEN '[ADM_ServiceSheetDetails].[CheckPointID]'
                        WHEN 'CheckPointID DESC' THEN '[ADM_ServiceSheetDetails].[CheckPointID] DESC'
                        WHEN 'Initiated' THEN '[ADM_ServiceSheetDetails].[Initiated]'
                        WHEN 'Initiated DESC' THEN '[ADM_ServiceSheetDetails].[Initiated] DESC'
                        WHEN 'InitiatedBy' THEN '[ADM_ServiceSheetDetails].[InitiatedBy]'
                        WHEN 'InitiatedBy DESC' THEN '[ADM_ServiceSheetDetails].[InitiatedBy] DESC'
                        WHEN 'InitiatedOn' THEN '[ADM_ServiceSheetDetails].[InitiatedOn]'
                        WHEN 'InitiatedOn DESC' THEN '[ADM_ServiceSheetDetails].[InitiatedOn] DESC'
                        WHEN 'InitiatorRemarks' THEN '[ADM_ServiceSheetDetails].[InitiatorRemarks]'
                        WHEN 'InitiatorRemarks DESC' THEN '[ADM_ServiceSheetDetails].[InitiatorRemarks] DESC'
                        WHEN 'MonitoredBy' THEN '[ADM_ServiceSheetDetails].[MonitoredBy]'
                        WHEN 'MonitoredBy DESC' THEN '[ADM_ServiceSheetDetails].[MonitoredBy] DESC'
                        WHEN 'Monitored' THEN '[ADM_ServiceSheetDetails].[Monitored]'
                        WHEN 'Monitored DESC' THEN '[ADM_ServiceSheetDetails].[Monitored] DESC'
                        WHEN 'MonitoredOn' THEN '[ADM_ServiceSheetDetails].[MonitoredOn]'
                        WHEN 'MonitoredOn DESC' THEN '[ADM_ServiceSheetDetails].[MonitoredOn] DESC'
                        WHEN 'MonitorRemarks' THEN '[ADM_ServiceSheetDetails].[MonitorRemarks]'
                        WHEN 'MonitorRemarks DESC' THEN '[ADM_ServiceSheetDetails].[MonitorRemarks] DESC'
                        WHEN 'ProblemIdentified' THEN '[ADM_ServiceSheetDetails].[ProblemIdentified]'
                        WHEN 'ProblemIdentified DESC' THEN '[ADM_ServiceSheetDetails].[ProblemIdentified] DESC'
                        WHEN 'ProblemClosed' THEN '[ADM_ServiceSheetDetails].[ProblemClosed]'
                        WHEN 'ProblemClosed DESC' THEN '[ADM_ServiceSheetDetails].[ProblemClosed] DESC'
                        WHEN 'ClosedBy' THEN '[ADM_ServiceSheetDetails].[ClosedBy]'
                        WHEN 'ClosedBy DESC' THEN '[ADM_ServiceSheetDetails].[ClosedBy] DESC'
                        WHEN 'ClosedOn' THEN '[ADM_ServiceSheetDetails].[ClosedOn]'
                        WHEN 'ClosedOn DESC' THEN '[ADM_ServiceSheetDetails].[ClosedOn] DESC'
                        WHEN 'ClosingRemarks' THEN '[ADM_ServiceSheetDetails].[ClosingRemarks]'
                        WHEN 'ClosingRemarks DESC' THEN '[ADM_ServiceSheetDetails].[ClosingRemarks] DESC'
                        WHEN 'CPInitiator' THEN '[ADM_ServiceSheetDetails].[CPInitiator]'
                        WHEN 'CPInitiator DESC' THEN '[ADM_ServiceSheetDetails].[CPInitiator] DESC'
                        WHEN 'ADM_CheckPoints1_Descriptions' THEN '[ADM_CheckPoints].[Descriptions]'
                        WHEN 'ADM_CheckPoints1_Descriptions DESC' THEN '[ADM_CheckPoints1].[Descriptions] DESC'
                        WHEN 'ADM_Measures2_Description' THEN '[ADM_Measures].[Description]'
                        WHEN 'ADM_Measures2_Description DESC' THEN '[ADM_Measures2].[Description] DESC'
                        WHEN 'ADM_Schedules3_Description' THEN '[ADM_Schedules].[Description]'
                        WHEN 'ADM_Schedules3_Description DESC' THEN '[ADM_Schedules3].[Description] DESC'
                        WHEN 'ADM_Services4_Description' THEN '[ADM_Services].[Description]'
                        WHEN 'ADM_Services4_Description DESC' THEN '[ADM_Services4].[Description] DESC'
                        WHEN 'aspnet_users9_UserFullName' THEN '[aspnet_users].[UserFullName]'
                        WHEN 'aspnet_users9_UserFullName DESC' THEN '[aspnet_users9].[UserFullName] DESC'
                        WHEN 'HRM_Employees7_EmployeeName' THEN '[HRM_Employees].[EmployeeName]'
                        WHEN 'HRM_Employees7_EmployeeName DESC' THEN '[HRM_Employees7].[EmployeeName] DESC'
                        WHEN 'HRM_Employees8_EmployeeName' THEN '[HRM_Employees].[EmployeeName]'
                        WHEN 'HRM_Employees8_EmployeeName DESC' THEN '[HRM_Employees8].[EmployeeName] DESC'
                        WHEN 'HRM_Employees9_EmployeeName' THEN '[HRM_Employees].[EmployeeName]'
                        WHEN 'HRM_Employees9_EmployeeName DESC' THEN '[HRM_Employees9].[EmployeeName] DESC'
                        ELSE '[ADM_ServiceSheetDetails].[SheetID],[ADM_ServiceSheetDetails].[SerialNo]'
                    END
  EXEC (@LGSQL)

  SET @RecordCount = @@RowCount

  SELECT
		[ADM_ServiceSheetDetails].[SheetID] ,
		[ADM_ServiceSheetDetails].[SerialNo] ,
		[ADM_ServiceSheetDetails].[SheetDate] ,
		[ADM_ServiceSheetDetails].[ServiceID] ,
		[ADM_ServiceSheetDetails].[ScheduleID] ,
		[ADM_ServiceSheetDetails].[MeasureID] ,
		[ADM_ServiceSheetDetails].[CheckPointID] ,
		[ADM_ServiceSheetDetails].[Initiated] ,
		[ADM_ServiceSheetDetails].[InitiatedBy] ,
		[ADM_ServiceSheetDetails].[InitiatedOn] ,
		[ADM_ServiceSheetDetails].[InitiatorRemarks] ,
		[ADM_ServiceSheetDetails].[MonitoredBy] ,
		[ADM_ServiceSheetDetails].[Monitored] ,
		[ADM_ServiceSheetDetails].[MonitoredOn] ,
		[ADM_ServiceSheetDetails].[MonitorRemarks] ,
		[ADM_ServiceSheetDetails].[ProblemIdentified] ,
		[ADM_ServiceSheetDetails].[ProblemClosed] ,
		[ADM_ServiceSheetDetails].[ClosedBy] ,
		[ADM_ServiceSheetDetails].[ClosedOn] ,
		[ADM_ServiceSheetDetails].[ClosingRemarks] ,
		[ADM_ServiceSheetDetails].[CPInitiator] ,
		[ADM_CheckPoints1].[Descriptions] AS ADM_CheckPoints1_Descriptions,
		[ADM_Measures2].[Description] AS ADM_Measures2_Description,
		[ADM_Schedules3].[Description] AS ADM_Schedules3_Description,
		[ADM_Services4].[Description] AS ADM_Services4_Description,
		[aspnet_users9].[UserFullName] AS aspnet_users9_UserFullName,
		[HRM_Employees7].[EmployeeName] AS HRM_Employees7_EmployeeName,
		[HRM_Employees8].[EmployeeName] AS HRM_Employees8_EmployeeName,
		[HRM_Employees9].[EmployeeName] AS HRM_Employees9_EmployeeName 
  FROM [ADM_ServiceSheetDetails] 
    	INNER JOIN #PageIndex
          ON [ADM_ServiceSheetDetails].[SheetID] = #PageIndex.SheetID
          AND [ADM_ServiceSheetDetails].[SerialNo] = #PageIndex.SerialNo
  LEFT OUTER JOIN [ADM_CheckPoints] AS [ADM_CheckPoints1]
    ON [ADM_ServiceSheetDetails].[CheckPointID] = [ADM_CheckPoints1].[CheckPointID]
  LEFT OUTER JOIN [ADM_Measures] AS [ADM_Measures2]
    ON [ADM_ServiceSheetDetails].[MeasureID] = [ADM_Measures2].[MeasureID]
  LEFT OUTER JOIN [ADM_Schedules] AS [ADM_Schedules3]
    ON [ADM_ServiceSheetDetails].[ScheduleID] = [ADM_Schedules3].[ScheduleID]
  LEFT OUTER JOIN [ADM_Services] AS [ADM_Services4]
    ON [ADM_ServiceSheetDetails].[ServiceID] = [ADM_Services4].[ServiceID]
  INNER JOIN [ADM_ServiceSheetHeader] AS [ADM_ServiceSheetHeader5]
    ON [ADM_ServiceSheetDetails].[SheetID] = [ADM_ServiceSheetHeader5].[SheetID]
  LEFT OUTER JOIN [aspnet_Users] AS [aspnet_Users9]
    ON [ADM_ServiceSheetDetails].[CPInitiator] = [aspnet_Users9].[UserName]
  LEFT OUTER JOIN [HRM_Employees] AS [HRM_Employees7]
    ON [ADM_ServiceSheetDetails].[InitiatedBy] = [HRM_Employees7].[CardNo]
  LEFT OUTER JOIN [HRM_Employees] AS [HRM_Employees8]
    ON [ADM_ServiceSheetDetails].[MonitoredBy] = [HRM_Employees8].[CardNo]
  LEFT OUTER JOIN [HRM_Employees] AS [HRM_Employees9]
    ON [ADM_ServiceSheetDetails].[ClosedBy] = [HRM_Employees9].[CardNo]
  WHERE
        #PageIndex.IndexID > @startRowIndex
        AND #PageIndex.IndexID < (@startRowIndex + @maximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spadmLWServiceSheetDetailsInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spadmLWServiceSheetDetailsInsert]
GO
 
CREATE PROCEDURE [dbo].[spadmLWServiceSheetDetailsInsert]
  @SheetID Int,
  @SheetDate DateTime,
  @ServiceID NVarChar(10),
  @ScheduleID NVarChar(20),
  @MeasureID Int,
  @CheckPointID Int,
  @Initiated Bit,
  @InitiatedBy NVarChar(8),
  @InitiatedOn DateTime,
  @InitiatorRemarks NVarChar(100),
  @MonitoredBy NVarChar(8),
  @Monitored Bit,
  @MonitoredOn DateTime,
  @MonitorRemarks NVarChar(100),
  @ProblemIdentified Bit,
  @ProblemClosed Bit,
  @ClosedBy NVarChar(8),
  @ClosedOn DateTime,
  @ClosingRemarks NVarChar(100),
  @CPInitiator NVarChar(8),
  @Return_SerialNo Int = null OUTPUT
  AS
  INSERT [ADM_ServiceSheetDetails]
  (
   [SheetID]
  ,[SheetDate]
  ,[ServiceID]
  ,[ScheduleID]
  ,[MeasureID]
  ,[CheckPointID]
  ,[Initiated]
  ,[InitiatedBy]
  ,[InitiatedOn]
  ,[InitiatorRemarks]
  ,[MonitoredBy]
  ,[Monitored]
  ,[MonitoredOn]
  ,[MonitorRemarks]
  ,[ProblemIdentified]
  ,[ProblemClosed]
  ,[ClosedBy]
  ,[ClosedOn]
  ,[ClosingRemarks]
  ,[CPInitiator]
  )
  VALUES
  (
   @SheetID
  ,@SheetDate
  ,@ServiceID
  ,@ScheduleID
  ,@MeasureID
  ,@CheckPointID
  ,@Initiated
  ,@InitiatedBy
  ,@InitiatedOn
  ,@InitiatorRemarks
  ,@MonitoredBy
  ,@Monitored
  ,@MonitoredOn
  ,@MonitorRemarks
  ,@ProblemIdentified
  ,@ProblemClosed
  ,@ClosedBy
  ,@ClosedOn
  ,@ClosingRemarks
  ,@CPInitiator
  )
  SET @Return_SerialNo = Scope_Identity()
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spadmLWServiceSheetDetailsUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spadmLWServiceSheetDetailsUpdate]
GO
 
CREATE PROCEDURE [dbo].[spadmLWServiceSheetDetailsUpdate]
  @Original_SheetID Int, 
  @Original_SerialNo Int, 
  @SheetID Int,
  @SheetDate DateTime,
  @ServiceID NVarChar(10),
  @ScheduleID NVarChar(20),
  @MeasureID Int,
  @CheckPointID Int,
  @Initiated Bit,
  @InitiatedBy NVarChar(8),
  @InitiatedOn DateTime,
  @InitiatorRemarks NVarChar(100),
  @MonitoredBy NVarChar(8),
  @Monitored Bit,
  @MonitoredOn DateTime,
  @MonitorRemarks NVarChar(100),
  @ProblemIdentified Bit,
  @ProblemClosed Bit,
  @ClosedBy NVarChar(8),
  @ClosedOn DateTime,
  @ClosingRemarks NVarChar(100),
  @CPInitiator NVarChar(8),
  @RowCount int = null OUTPUT
  AS
  UPDATE [ADM_ServiceSheetDetails] SET 
   [SheetID] = @SheetID
  ,[SheetDate] = @SheetDate
  ,[ServiceID] = @ServiceID
  ,[ScheduleID] = @ScheduleID
  ,[MeasureID] = @MeasureID
  ,[CheckPointID] = @CheckPointID
  ,[Initiated] = @Initiated
  ,[InitiatedBy] = @InitiatedBy
  ,[InitiatedOn] = @InitiatedOn
  ,[InitiatorRemarks] = @InitiatorRemarks
  ,[MonitoredBy] = @MonitoredBy
  ,[Monitored] = @Monitored
  ,[MonitoredOn] = @MonitoredOn
  ,[MonitorRemarks] = @MonitorRemarks
  ,[ProblemIdentified] = @ProblemIdentified
  ,[ProblemClosed] = @ProblemClosed
  ,[ClosedBy] = @ClosedBy
  ,[ClosedOn] = @ClosedOn
  ,[ClosingRemarks] = @ClosingRemarks
  ,[CPInitiator] = @CPInitiator
  WHERE
  [SheetID] = @Original_SheetID
  AND [SerialNo] = @Original_SerialNo
  SET @RowCount = @@RowCount
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spadmLWServiceSheetDetailsDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spadmLWServiceSheetDetailsDelete]
GO
 
CREATE PROCEDURE [dbo].[spadmLWServiceSheetDetailsDelete]
  @Original_SheetID Int,
  @Original_SerialNo Int,
  @RowCount int = null OUTPUT
  AS
  DELETE [ADM_ServiceSheetDetails]
  WHERE
  [ADM_ServiceSheetDetails].[SheetID] = @Original_SheetID
  AND [ADM_ServiceSheetDetails].[SerialNo] = @Original_SerialNo
  SET @RowCount = @@RowCount
  GO

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
