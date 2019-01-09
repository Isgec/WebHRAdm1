Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ADM
  <DataObject()> _
  Partial Public Class admLWServiceSheetDetails
    Private Shared _RecordCount As Integer
    Private _SheetID As Int32 = 0
    Private _SerialNo As Int32 = 0
    Private _SheetDate As String = ""
    Private _ServiceID As String = ""
    Private _ScheduleID As String = ""
    Private _MeasureID As String = ""
    Private _CheckPointID As String = ""
    Private _Initiated As Boolean = False
    Private _InitiatedBy As String = ""
    Private _InitiatedOn As String = ""
    Private _InitiatorRemarks As String = ""
    Private _MonitoredBy As String = ""
    Private _Monitored As Boolean = False
    Private _MonitoredOn As String = ""
    Private _MonitorRemarks As String = ""
    Private _ProblemIdentified As Boolean = False
    Private _ProblemClosed As Boolean = False
    Private _ClosedBy As String = ""
    Private _ClosedOn As String = ""
    Private _ClosingRemarks As String = ""
    Private _CPInitiator As String = ""
    Private _ADM_CheckPoints1_Descriptions As String = ""
    Private _ADM_Measures2_Description As String = ""
    Private _ADM_Schedules3_Description As String = ""
    Private _ADM_Services4_Description As String = ""
    Private _aspnet_users9_UserFullName As String = ""
    Private _HRM_Employees7_EmployeeName As String = ""
    Private _HRM_Employees8_EmployeeName As String = ""
    Private _HRM_Employees9_EmployeeName As String = ""
    Private _FK_ADM_ServiceSheetDetails_ADM_CheckPoints As SIS.ADM.admCheckPoints = Nothing
    Private _FK_ADM_ServiceSheetDetails_ADM_ServiceSheetDetails As SIS.ADM.admMeasures = Nothing
    Private _FK_ADM_ServiceSheetDetails_ADM_Schedules As SIS.ADM.admSchedules = Nothing
    Private _FK_ADM_ServiceSheetDetails_ADM_Services As SIS.ADM.admServices = Nothing
    Private _FK_ADM_ServiceSheetDetails_ADM_ServiceSheetHeader As SIS.ADM.admMonitorSheetHeader = Nothing
    Private _FK_ADM_ServiceSheetDetails_aspnet_Users As SIS.ADM.admUsers = Nothing
    Private _FK_ADM_ServiceSheetDetails_HRM_Employees As SIS.ADM.admEmployees = Nothing
    Private _FK_ADM_ServiceSheetDetails_HRM_Employees1 As SIS.ADM.admEmployees = Nothing
    Private _FK_ADM_ServiceSheetDetails_HRM_Employees2 As SIS.ADM.admEmployees = Nothing
    Public ReadOnly Property ForeColor() As System.Drawing.Color
      Get
        Dim mRet As System.Drawing.Color = Drawing.Color.Blue
        Try
					mRet = GetColor()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Visible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
					mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Enable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
					mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Property SheetID() As Int32
      Get
        Return _SheetID
      End Get
      Set(ByVal value As Int32)
        _SheetID = value
      End Set
    End Property
    Public Property SerialNo() As Int32
      Get
        Return _SerialNo
      End Get
      Set(ByVal value As Int32)
        _SerialNo = value
      End Set
    End Property
    Public Property SheetDate() As String
      Get
        If Not _SheetDate = String.Empty Then
          Return Convert.ToDateTime(_SheetDate).ToString("dd/MM/yyyy")
        End If
        Return _SheetDate
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _SheetDate = ""
				 Else
					 _SheetDate = value
			   End If
      End Set
    End Property
    Public Property ServiceID() As String
      Get
        Return _ServiceID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ServiceID = ""
				 Else
					 _ServiceID = value
			   End If
      End Set
    End Property
    Public Property ScheduleID() As String
      Get
        Return _ScheduleID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ScheduleID = ""
				 Else
					 _ScheduleID = value
			   End If
      End Set
    End Property
    Public Property MeasureID() As String
      Get
        Return _MeasureID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _MeasureID = ""
				 Else
					 _MeasureID = value
			   End If
      End Set
    End Property
    Public Property CheckPointID() As String
      Get
        Return _CheckPointID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _CheckPointID = ""
				 Else
					 _CheckPointID = value
			   End If
      End Set
    End Property
    Public Property Initiated() As Boolean
      Get
        Return _Initiated
      End Get
      Set(ByVal value As Boolean)
        _Initiated = value
      End Set
    End Property
    Public Property InitiatedBy() As String
      Get
        Return _InitiatedBy
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _InitiatedBy = ""
				 Else
					 _InitiatedBy = value
			   End If
      End Set
    End Property
    Public Property InitiatedOn() As String
      Get
        If Not _InitiatedOn = String.Empty Then
          Return Convert.ToDateTime(_InitiatedOn).ToString("dd/MM/yyyy")
        End If
        Return _InitiatedOn
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _InitiatedOn = ""
				 Else
					 _InitiatedOn = value
			   End If
      End Set
    End Property
    Public Property InitiatorRemarks() As String
      Get
        Return _InitiatorRemarks
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _InitiatorRemarks = ""
				 Else
					 _InitiatorRemarks = value
			   End If
      End Set
    End Property
    Public Property MonitoredBy() As String
      Get
        Return _MonitoredBy
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _MonitoredBy = ""
				 Else
					 _MonitoredBy = value
			   End If
      End Set
    End Property
    Public Property Monitored() As Boolean
      Get
        Return _Monitored
      End Get
      Set(ByVal value As Boolean)
        _Monitored = value
      End Set
    End Property
    Public Property MonitoredOn() As String
      Get
        If Not _MonitoredOn = String.Empty Then
          Return Convert.ToDateTime(_MonitoredOn).ToString("dd/MM/yyyy")
        End If
        Return _MonitoredOn
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _MonitoredOn = ""
				 Else
					 _MonitoredOn = value
			   End If
      End Set
    End Property
    Public Property MonitorRemarks() As String
      Get
        Return _MonitorRemarks
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _MonitorRemarks = ""
				 Else
					 _MonitorRemarks = value
			   End If
      End Set
    End Property
    Public Property ProblemIdentified() As Boolean
      Get
        Return _ProblemIdentified
      End Get
      Set(ByVal value As Boolean)
        _ProblemIdentified = value
      End Set
    End Property
    Public Property ProblemClosed() As Boolean
      Get
        Return _ProblemClosed
      End Get
      Set(ByVal value As Boolean)
        _ProblemClosed = value
      End Set
    End Property
    Public Property ClosedBy() As String
      Get
        Return _ClosedBy
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ClosedBy = ""
				 Else
					 _ClosedBy = value
			   End If
      End Set
    End Property
    Public Property ClosedOn() As String
      Get
        If Not _ClosedOn = String.Empty Then
          Return Convert.ToDateTime(_ClosedOn).ToString("dd/MM/yyyy")
        End If
        Return _ClosedOn
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ClosedOn = ""
				 Else
					 _ClosedOn = value
			   End If
      End Set
    End Property
    Public Property ClosingRemarks() As String
      Get
        Return _ClosingRemarks
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ClosingRemarks = ""
				 Else
					 _ClosingRemarks = value
			   End If
      End Set
    End Property
    Public Property CPInitiator() As String
      Get
        Return _CPInitiator
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _CPInitiator = ""
				 Else
					 _CPInitiator = value
			   End If
      End Set
    End Property
    Public Property ADM_CheckPoints1_Descriptions() As String
      Get
        Return _ADM_CheckPoints1_Descriptions
      End Get
      Set(ByVal value As String)
        _ADM_CheckPoints1_Descriptions = value
      End Set
    End Property
    Public Property ADM_Measures2_Description() As String
      Get
        Return _ADM_Measures2_Description
      End Get
      Set(ByVal value As String)
        _ADM_Measures2_Description = value
      End Set
    End Property
    Public Property ADM_Schedules3_Description() As String
      Get
        Return _ADM_Schedules3_Description
      End Get
      Set(ByVal value As String)
        _ADM_Schedules3_Description = value
      End Set
    End Property
    Public Property ADM_Services4_Description() As String
      Get
        Return _ADM_Services4_Description
      End Get
      Set(ByVal value As String)
        _ADM_Services4_Description = value
      End Set
    End Property
    Public Property aspnet_users9_UserFullName() As String
      Get
        Return _aspnet_users9_UserFullName
      End Get
      Set(ByVal value As String)
        _aspnet_users9_UserFullName = value
      End Set
    End Property
    Public Property HRM_Employees7_EmployeeName() As String
      Get
        Return _HRM_Employees7_EmployeeName
      End Get
      Set(ByVal value As String)
        _HRM_Employees7_EmployeeName = value
      End Set
    End Property
    Public Property HRM_Employees8_EmployeeName() As String
      Get
        Return _HRM_Employees8_EmployeeName
      End Get
      Set(ByVal value As String)
        _HRM_Employees8_EmployeeName = value
      End Set
    End Property
    Public Property HRM_Employees9_EmployeeName() As String
      Get
        Return _HRM_Employees9_EmployeeName
      End Get
      Set(ByVal value As String)
        _HRM_Employees9_EmployeeName = value
      End Set
    End Property
    Public Property DisplayField() As String
      Get
        Return ""
      End Get
      Set(ByVal value As String)
      End Set
    End Property
    Public Property PrimaryKey() As String
      Get
        Return _SheetID & "|" & _SerialNo
      End Get
      Set(ByVal value As String)
      End Set
    End Property
    Public Property RecordCount() As Integer
      Get
        Return _RecordCount
      End Get
      Set(ByVal value As Integer)
        _RecordCount = value
      End Set
    End Property
    Public ReadOnly Property FK_ADM_ServiceSheetDetails_ADM_CheckPoints() As SIS.ADM.admCheckPoints
      Get
        If _FK_ADM_ServiceSheetDetails_ADM_CheckPoints Is Nothing Then
          _FK_ADM_ServiceSheetDetails_ADM_CheckPoints = SIS.ADM.admCheckPoints.GetByID(_CheckPointID)
        End If
        Return _FK_ADM_ServiceSheetDetails_ADM_CheckPoints
      End Get
    End Property
    Public ReadOnly Property FK_ADM_ServiceSheetDetails_ADM_ServiceSheetDetails() As SIS.ADM.admMeasures
      Get
        If _FK_ADM_ServiceSheetDetails_ADM_ServiceSheetDetails Is Nothing Then
          _FK_ADM_ServiceSheetDetails_ADM_ServiceSheetDetails = SIS.ADM.admMeasures.GetByID(_MeasureID)
        End If
        Return _FK_ADM_ServiceSheetDetails_ADM_ServiceSheetDetails
      End Get
    End Property
    Public ReadOnly Property FK_ADM_ServiceSheetDetails_ADM_Schedules() As SIS.ADM.admSchedules
      Get
        If _FK_ADM_ServiceSheetDetails_ADM_Schedules Is Nothing Then
          _FK_ADM_ServiceSheetDetails_ADM_Schedules = SIS.ADM.admSchedules.GetByID(_ScheduleID)
        End If
        Return _FK_ADM_ServiceSheetDetails_ADM_Schedules
      End Get
    End Property
    Public ReadOnly Property FK_ADM_ServiceSheetDetails_ADM_Services() As SIS.ADM.admServices
      Get
        If _FK_ADM_ServiceSheetDetails_ADM_Services Is Nothing Then
          _FK_ADM_ServiceSheetDetails_ADM_Services = SIS.ADM.admServices.GetByID(_ServiceID)
        End If
        Return _FK_ADM_ServiceSheetDetails_ADM_Services
      End Get
    End Property
    Public ReadOnly Property FK_ADM_ServiceSheetDetails_ADM_ServiceSheetHeader() As SIS.ADM.admMonitorSheetHeader
      Get
        If _FK_ADM_ServiceSheetDetails_ADM_ServiceSheetHeader Is Nothing Then
          _FK_ADM_ServiceSheetDetails_ADM_ServiceSheetHeader = SIS.ADM.admMonitorSheetHeader.GetByID(_SheetID)
        End If
        Return _FK_ADM_ServiceSheetDetails_ADM_ServiceSheetHeader
      End Get
    End Property
    Public ReadOnly Property FK_ADM_ServiceSheetDetails_aspnet_Users() As SIS.ADM.admUsers
      Get
        If _FK_ADM_ServiceSheetDetails_aspnet_Users Is Nothing Then
          _FK_ADM_ServiceSheetDetails_aspnet_Users = SIS.ADM.admUsers.GetByID(_CPInitiator)
        End If
        Return _FK_ADM_ServiceSheetDetails_aspnet_Users
      End Get
    End Property
    Public ReadOnly Property FK_ADM_ServiceSheetDetails_HRM_Employees() As SIS.ADM.admEmployees
      Get
        If _FK_ADM_ServiceSheetDetails_HRM_Employees Is Nothing Then
          _FK_ADM_ServiceSheetDetails_HRM_Employees = SIS.ADM.admEmployees.GetByID(_InitiatedBy)
        End If
        Return _FK_ADM_ServiceSheetDetails_HRM_Employees
      End Get
    End Property
    Public ReadOnly Property FK_ADM_ServiceSheetDetails_HRM_Employees1() As SIS.ADM.admEmployees
      Get
        If _FK_ADM_ServiceSheetDetails_HRM_Employees1 Is Nothing Then
          _FK_ADM_ServiceSheetDetails_HRM_Employees1 = SIS.ADM.admEmployees.GetByID(_MonitoredBy)
        End If
        Return _FK_ADM_ServiceSheetDetails_HRM_Employees1
      End Get
    End Property
    Public ReadOnly Property FK_ADM_ServiceSheetDetails_HRM_Employees2() As SIS.ADM.admEmployees
      Get
        If _FK_ADM_ServiceSheetDetails_HRM_Employees2 Is Nothing Then
          _FK_ADM_ServiceSheetDetails_HRM_Employees2 = SIS.ADM.admEmployees.GetByID(_ClosedBy)
        End If
        Return _FK_ADM_ServiceSheetDetails_HRM_Employees2
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetNewRecord() As SIS.ADM.admLWServiceSheetDetails
      Return New SIS.ADM.admLWServiceSheetDetails()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByID(ByVal SheetID As Int32, ByVal SerialNo As Int32) As SIS.ADM.admLWServiceSheetDetails
      Dim Results As SIS.ADM.admLWServiceSheetDetails = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmLWServiceSheetDetailsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SheetID",SqlDbType.Int,SheetID.ToString.Length, SheetID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ADM.admLWServiceSheetDetails(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetBySheetID(ByVal SheetID As Int32, ByVal OrderBy as String) As List(Of SIS.ADM.admLWServiceSheetDetails)
      Dim Results As List(Of SIS.ADM.admLWServiceSheetDetails) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmLWServiceSheetDetailsSelectBySheetID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SheetID",SqlDbType.Int,SheetID.ToString.Length, SheetID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ADM.admLWServiceSheetDetails)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ADM.admLWServiceSheetDetails(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function SelectList(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal orderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.ADM.admLWServiceSheetDetails)
      Dim Results As List(Of SIS.ADM.admLWServiceSheetDetails) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spadmLWServiceSheetDetailsSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spadmLWServiceSheetDetailsSelectListFilteres"
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@startRowIndex", SqlDbType.Int, -1, startRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@maximumRows", SqlDbType.Int, -1, maximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ADM.admLWServiceSheetDetails)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ADM.admLWServiceSheetDetails(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function SelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function Insert(ByVal Record As SIS.ADM.admLWServiceSheetDetails) As Int32
      Dim _Rec As SIS.ADM.admLWServiceSheetDetails = SIS.ADM.admLWServiceSheetDetails.GetNewRecord()
      With _Rec
        .SheetID = Record.SheetID
        .SheetDate = Record.SheetDate
        .ServiceID = Record.ServiceID
        .ScheduleID = Record.ScheduleID
        .MeasureID = Record.MeasureID
        .CheckPointID = Record.CheckPointID
        .Initiated = Record.Initiated
        .InitiatedBy = Record.InitiatedBy
        .InitiatedOn = Record.InitiatedOn
        .InitiatorRemarks = Record.InitiatorRemarks
        .MonitoredBy = Record.MonitoredBy
        .Monitored = Record.Monitored
        .MonitoredOn = Record.MonitoredOn
        .MonitorRemarks = Record.MonitorRemarks
        .ProblemIdentified = Record.ProblemIdentified
        .ProblemClosed = Record.ProblemClosed
        .ClosedBy = Record.ClosedBy
        .ClosedOn = Record.ClosedOn
        .ClosingRemarks = Record.ClosingRemarks
        .CPInitiator = Record.CPInitiator
      End With
      Return SIS.ADM.admLWServiceSheetDetails.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.ADM.admLWServiceSheetDetails) As Int32
      Dim _Result As Int32 = Record.SerialNo
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmLWServiceSheetDetailsInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SheetID",SqlDbType.Int,11, Record.SheetID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SheetDate",SqlDbType.DateTime,21, Iif(Record.SheetDate= "" ,Convert.DBNull, Record.SheetDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ServiceID",SqlDbType.NVarChar,11, Iif(Record.ServiceID= "" ,Convert.DBNull, Record.ServiceID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ScheduleID",SqlDbType.NVarChar,21, Iif(Record.ScheduleID= "" ,Convert.DBNull, Record.ScheduleID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MeasureID",SqlDbType.Int,11, Iif(Record.MeasureID= "" ,Convert.DBNull, Record.MeasureID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CheckPointID",SqlDbType.Int,11, Iif(Record.CheckPointID= "" ,Convert.DBNull, Record.CheckPointID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Initiated",SqlDbType.Bit,3, Record.Initiated)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InitiatedBy",SqlDbType.NVarChar,9, Iif(Record.InitiatedBy= "" ,Convert.DBNull, Record.InitiatedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InitiatedOn",SqlDbType.DateTime,21, Iif(Record.InitiatedOn= "" ,Convert.DBNull, Record.InitiatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InitiatorRemarks",SqlDbType.NVarChar,101, Iif(Record.InitiatorRemarks= "" ,Convert.DBNull, Record.InitiatorRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MonitoredBy",SqlDbType.NVarChar,9, Iif(Record.MonitoredBy= "" ,Convert.DBNull, Record.MonitoredBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Monitored",SqlDbType.Bit,3, Record.Monitored)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MonitoredOn",SqlDbType.DateTime,21, Iif(Record.MonitoredOn= "" ,Convert.DBNull, Record.MonitoredOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MonitorRemarks",SqlDbType.NVarChar,101, Iif(Record.MonitorRemarks= "" ,Convert.DBNull, Record.MonitorRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProblemIdentified",SqlDbType.Bit,3, Record.ProblemIdentified)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProblemClosed",SqlDbType.Bit,3, Record.ProblemClosed)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ClosedBy",SqlDbType.NVarChar,9, Iif(Record.ClosedBy= "" ,Convert.DBNull, Record.ClosedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ClosedOn",SqlDbType.DateTime,21, Iif(Record.ClosedOn= "" ,Convert.DBNull, Record.ClosedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ClosingRemarks",SqlDbType.NVarChar,101, Iif(Record.ClosingRemarks= "" ,Convert.DBNull, Record.ClosingRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CPInitiator",SqlDbType.NVarChar,9, Iif(Record.CPInitiator= "" ,Convert.DBNull, Record.CPInitiator))
          Cmd.Parameters.Add("@Return_SerialNo", SqlDbType.Int, 10)
          Cmd.Parameters("@Return_SerialNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          _Result = Cmd.Parameters("@Return_SerialNo").Value
        End Using
      End Using
      Return _Result
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function Update(ByVal Record As SIS.ADM.admLWServiceSheetDetails) As Int32
      Dim _Rec As SIS.ADM.admLWServiceSheetDetails = SIS.ADM.admLWServiceSheetDetails.GetByID(Record.SheetID, Record.SerialNo)
      With _Rec
        .SheetDate = Record.SheetDate
        .ServiceID = Record.ServiceID
        .ScheduleID = Record.ScheduleID
        .MeasureID = Record.MeasureID
        .CheckPointID = Record.CheckPointID
        .Initiated = Record.Initiated
        .InitiatedBy = Record.InitiatedBy
        .InitiatedOn = Record.InitiatedOn
        .InitiatorRemarks = Record.InitiatorRemarks
        .MonitoredBy = Record.MonitoredBy
        .Monitored = Record.Monitored
        .MonitoredOn = Record.MonitoredOn
        .MonitorRemarks = Record.MonitorRemarks
        .ProblemIdentified = Record.ProblemIdentified
        .ProblemClosed = Record.ProblemClosed
        .ClosedBy = Record.ClosedBy
        .ClosedOn = Record.ClosedOn
        .ClosingRemarks = Record.ClosingRemarks
        .CPInitiator = Record.CPInitiator
      End With
      Return SIS.ADM.admLWServiceSheetDetails.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.ADM.admLWServiceSheetDetails) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmLWServiceSheetDetailsUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SheetID",SqlDbType.Int,11, Record.SheetID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SheetID",SqlDbType.Int,11, Record.SheetID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SheetDate",SqlDbType.DateTime,21, Iif(Record.SheetDate= "" ,Convert.DBNull, Record.SheetDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ServiceID",SqlDbType.NVarChar,11, Iif(Record.ServiceID= "" ,Convert.DBNull, Record.ServiceID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ScheduleID",SqlDbType.NVarChar,21, Iif(Record.ScheduleID= "" ,Convert.DBNull, Record.ScheduleID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MeasureID",SqlDbType.Int,11, Iif(Record.MeasureID= "" ,Convert.DBNull, Record.MeasureID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CheckPointID",SqlDbType.Int,11, Iif(Record.CheckPointID= "" ,Convert.DBNull, Record.CheckPointID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Initiated",SqlDbType.Bit,3, Record.Initiated)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InitiatedBy",SqlDbType.NVarChar,9, Iif(Record.InitiatedBy= "" ,Convert.DBNull, Record.InitiatedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InitiatedOn",SqlDbType.DateTime,21, Iif(Record.InitiatedOn= "" ,Convert.DBNull, Record.InitiatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InitiatorRemarks",SqlDbType.NVarChar,101, Iif(Record.InitiatorRemarks= "" ,Convert.DBNull, Record.InitiatorRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MonitoredBy",SqlDbType.NVarChar,9, Iif(Record.MonitoredBy= "" ,Convert.DBNull, Record.MonitoredBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Monitored",SqlDbType.Bit,3, Record.Monitored)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MonitoredOn",SqlDbType.DateTime,21, Iif(Record.MonitoredOn= "" ,Convert.DBNull, Record.MonitoredOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MonitorRemarks",SqlDbType.NVarChar,101, Iif(Record.MonitorRemarks= "" ,Convert.DBNull, Record.MonitorRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProblemIdentified",SqlDbType.Bit,3, Record.ProblemIdentified)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProblemClosed",SqlDbType.Bit,3, Record.ProblemClosed)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ClosedBy",SqlDbType.NVarChar,9, Iif(Record.ClosedBy= "" ,Convert.DBNull, Record.ClosedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ClosedOn",SqlDbType.DateTime,21, Iif(Record.ClosedOn= "" ,Convert.DBNull, Record.ClosedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ClosingRemarks",SqlDbType.NVarChar,101, Iif(Record.ClosingRemarks= "" ,Convert.DBNull, Record.ClosingRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CPInitiator",SqlDbType.NVarChar,9, Iif(Record.CPInitiator= "" ,Convert.DBNull, Record.CPInitiator))
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          _Result = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return _Result
    End Function
    <DataObjectMethod(DataObjectMethodType.Delete, True)> _
    Public Shared Function Delete(ByVal Record As SIS.ADM.admLWServiceSheetDetails, Optional ByVal Cascade As Boolean = False) As Int32
      Dim _Result as Integer = 0
      If Cascade Then
				
      End If
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmLWServiceSheetDetailsDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SheetID",SqlDbType.Int,Record.SheetID.ToString.Length, Record.SheetID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,Record.SerialNo.ToString.Length, Record.SerialNo)
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          _Result = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return _Result
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      On Error Resume Next
      _SheetID = Ctype(Reader("SheetID"),Int32)
      _SerialNo = Ctype(Reader("SerialNo"),Int32)
      If Convert.IsDBNull(Reader("SheetDate")) Then
        _SheetDate = String.Empty
      Else
        _SheetDate = Ctype(Reader("SheetDate"), String)
      End If
      If Convert.IsDBNull(Reader("ServiceID")) Then
        _ServiceID = String.Empty
      Else
        _ServiceID = Ctype(Reader("ServiceID"), String)
      End If
      If Convert.IsDBNull(Reader("ScheduleID")) Then
        _ScheduleID = String.Empty
      Else
        _ScheduleID = Ctype(Reader("ScheduleID"), String)
      End If
      If Convert.IsDBNull(Reader("MeasureID")) Then
        _MeasureID = String.Empty
      Else
        _MeasureID = Ctype(Reader("MeasureID"), String)
      End If
      If Convert.IsDBNull(Reader("CheckPointID")) Then
        _CheckPointID = String.Empty
      Else
        _CheckPointID = Ctype(Reader("CheckPointID"), String)
      End If
      _Initiated = Ctype(Reader("Initiated"),Boolean)
      If Convert.IsDBNull(Reader("InitiatedBy")) Then
        _InitiatedBy = String.Empty
      Else
        _InitiatedBy = Ctype(Reader("InitiatedBy"), String)
      End If
      If Convert.IsDBNull(Reader("InitiatedOn")) Then
        _InitiatedOn = String.Empty
      Else
        _InitiatedOn = Ctype(Reader("InitiatedOn"), String)
      End If
      If Convert.IsDBNull(Reader("InitiatorRemarks")) Then
        _InitiatorRemarks = String.Empty
      Else
        _InitiatorRemarks = Ctype(Reader("InitiatorRemarks"), String)
      End If
      If Convert.IsDBNull(Reader("MonitoredBy")) Then
        _MonitoredBy = String.Empty
      Else
        _MonitoredBy = Ctype(Reader("MonitoredBy"), String)
      End If
      _Monitored = Ctype(Reader("Monitored"),Boolean)
      If Convert.IsDBNull(Reader("MonitoredOn")) Then
        _MonitoredOn = String.Empty
      Else
        _MonitoredOn = Ctype(Reader("MonitoredOn"), String)
      End If
      If Convert.IsDBNull(Reader("MonitorRemarks")) Then
        _MonitorRemarks = String.Empty
      Else
        _MonitorRemarks = Ctype(Reader("MonitorRemarks"), String)
      End If
      _ProblemIdentified = Ctype(Reader("ProblemIdentified"),Boolean)
      _ProblemClosed = Ctype(Reader("ProblemClosed"),Boolean)
      If Convert.IsDBNull(Reader("ClosedBy")) Then
        _ClosedBy = String.Empty
      Else
        _ClosedBy = Ctype(Reader("ClosedBy"), String)
      End If
      If Convert.IsDBNull(Reader("ClosedOn")) Then
        _ClosedOn = String.Empty
      Else
        _ClosedOn = Ctype(Reader("ClosedOn"), String)
      End If
      If Convert.IsDBNull(Reader("ClosingRemarks")) Then
        _ClosingRemarks = String.Empty
      Else
        _ClosingRemarks = Ctype(Reader("ClosingRemarks"), String)
      End If
      If Convert.IsDBNull(Reader("CPInitiator")) Then
        _CPInitiator = String.Empty
      Else
        _CPInitiator = Ctype(Reader("CPInitiator"), String)
      End If
      _ADM_CheckPoints1_Descriptions = Ctype(Reader("ADM_CheckPoints1_Descriptions"),String)
      _ADM_Measures2_Description = Ctype(Reader("ADM_Measures2_Description"),String)
      _ADM_Schedules3_Description = Ctype(Reader("ADM_Schedules3_Description"),String)
      _ADM_Services4_Description = Ctype(Reader("ADM_Services4_Description"),String)
      _aspnet_users9_UserFullName = Ctype(Reader("aspnet_users9_UserFullName"),String)
      _HRM_Employees7_EmployeeName = Ctype(Reader("HRM_Employees7_EmployeeName"),String)
      _HRM_Employees8_EmployeeName = Ctype(Reader("HRM_Employees8_EmployeeName"),String)
      _HRM_Employees9_EmployeeName = Ctype(Reader("HRM_Employees9_EmployeeName"),String)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
