Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ADM
  <DataObject()> _
  Partial Public Class admPendingProblems
    Private Shared _RecordCount As Integer
    Private _SheetID As Int32 = 0
    Private _SerialNo As Int32 = 0
    Private _SheetDate As String = ""
    Private _ServiceID As String = ""
    Private _ScheduleID As String = ""
    Private _CheckPointID As String = ""
    Private _MeasureID As String = ""
    Private _Initiated As Boolean = False
    Private _InitiatedBy As String = ""
    Private _InitiatedOn As String = ""
    Private _InitiatorRemarks As String = ""
    Private _MonitoredBy As String = ""
    Private _MonitoredOn As String = ""
    Private _MonitorRemarks As String = ""
    Private _Monitored As Boolean = False
    Private _ProblemIdentified As Boolean = False
    Private _ProblemClosed As Boolean = False
    Private _ClosedBy As String = ""
    Private _ClosedOn As String = ""
    Private _ClosingRemarks As String = ""
    Private _FK_ADM_ServiceSheetDetails_ADM_CheckPoints As SIS.ADM.admCheckPoints = Nothing
    Private _FK_ADM_ServiceSheetDetails_ADM_ServiceSheetDetails As SIS.ADM.admMeasures = Nothing
    Private _FK_ADM_ServiceSheetDetails_ADM_Schedules As SIS.ADM.admSchedules = Nothing
    Private _FK_ADM_ServiceSheetDetails_ADM_Services As SIS.ADM.admServices = Nothing
    Private _FK_ADM_ServiceSheetDetails_ADM_ServiceSheetHeader As SIS.ADM.admMonitorSheetHeader = Nothing
    Private _FK_ADM_ServiceSheetDetails_HRM_Employees As SIS.ADM.admEmployees = Nothing
    Private _FK_ADM_ServiceSheetDetails_HRM_Employees1 As SIS.ADM.admEmployees = Nothing
    Private _FK_ADM_ServiceSheetDetails_HRM_Employees2 As SIS.ADM.admEmployees = Nothing
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
    Public Property Monitored() As Boolean
      Get
        Return _Monitored
      End Get
      Set(ByVal value As Boolean)
        _Monitored = value
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
    Public Shared Function GetNewRecord() As SIS.ADM.admPendingProblems
      Dim Results As SIS.ADM.admPendingProblems = Nothing
      Results = New SIS.ADM.admPendingProblems()
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByID(ByVal SheetID As Int32, ByVal SerialNo As Int32) As SIS.ADM.admPendingProblems
      Dim Results As SIS.ADM.admPendingProblems = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmPendingProblemsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SheetID",SqlDbType.Int,SheetID.ToString.Length, SheetID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ADM.admPendingProblems(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByID(ByVal SheetID As Int32, ByVal SerialNo As Int32, ByVal Filter_ServiceID As String, ByVal Filter_CheckPointID As Int32) As SIS.ADM.admPendingProblems
      Return GetByID(SheetID, SerialNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function SelectList(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal orderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ServiceID As String, ByVal CheckPointID As Int32) As List(Of SIS.ADM.admPendingProblems)
      Dim Results As List(Of SIS.ADM.admPendingProblems) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "SheetDate DESC"
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spadmPendingProblemsSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spadmPendingProblemsSelectListFilteres"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ServiceID",SqlDbType.NVarChar,10, IIf(ServiceID Is Nothing, String.Empty,ServiceID))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CheckPointID",SqlDbType.Int,10, IIf(CheckPointID = Nothing, 0,CheckPointID))
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@startRowIndex", SqlDbType.Int, -1, startRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@maximumRows", SqlDbType.Int, -1, maximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProblemIdentified",SqlDbType.Bit,2, 1)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProblemClosed",SqlDbType.Bit,2, 0)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ADM.admPendingProblems)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ADM.admPendingProblems(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function Update(ByVal Record As SIS.ADM.admPendingProblems) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmPendingProblemsUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SheetID",SqlDbType.Int,11, Record.SheetID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProblemClosed",SqlDbType.Bit,3, Record.ProblemClosed)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ClosedBy",SqlDbType.NVarChar,9, Global.System.Web.HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ClosedOn",SqlDbType.DateTime,21, Now)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ClosingRemarks",SqlDbType.NVarChar,101, Iif(Record.ClosingRemarks= "" ,Convert.DBNull, Record.ClosingRemarks))
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          _Result = Cmd.Parameters("@RowCount").Value
        End Using
			End Using
			If _Result > 0 Then
				Dim osht As SIS.ADM.admMonitorSheetHeader = SIS.ADM.admMonitorSheetHeader.GetByID(Record.SheetID)
				osht.Closed = Record.ProblemClosed
				SIS.ADM.admMonitorSheetHeader.Update(osht)
			End If
      Return _Result
    End Function
    Public Shared Function SelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ServiceID As String, ByVal CheckPointID As Int32) As Integer
      Return _RecordCount
    End Function
'		Autocomplete Method
		Public Shared Function SelectadmPendingProblemsAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
			Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spadmPendingProblemsAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProblemIdentified",SqlDbType.Bit,2, 1)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProblemClosed",SqlDbType.Bit,2, 0)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
					Results = New List(Of String)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Not Reader.HasRows Then
					  Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---","" & "|" & ""))
					End If
					While (Reader.Read())
            Dim Tmp As SIS.ADM.admPendingProblems = New SIS.ADM.admPendingProblems(Reader)
					  Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(Tmp.DisplayField, Tmp.PrimaryKey))
					End While
					Reader.Close()
				End Using
			End Using
			Return Results.ToArray
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
      If Convert.IsDBNull(Reader("CheckPointID")) Then
        _CheckPointID = String.Empty
      Else
        _CheckPointID = Ctype(Reader("CheckPointID"), String)
      End If
      If Convert.IsDBNull(Reader("MeasureID")) Then
        _MeasureID = String.Empty
      Else
        _MeasureID = Ctype(Reader("MeasureID"), String)
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
      _Monitored = Ctype(Reader("Monitored"),Boolean)
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
			_FK_ADM_ServiceSheetDetails_ADM_ServiceSheetDetails = New SIS.ADM.admMeasures("ADM_Measures2", Reader)
      _FK_ADM_ServiceSheetDetails_ADM_Schedules = New SIS.ADM.admSchedules("ADM_Schedules3",Reader)
      _FK_ADM_ServiceSheetDetails_ADM_Services = New SIS.ADM.admServices("ADM_Services4",Reader)
      _FK_ADM_ServiceSheetDetails_ADM_ServiceSheetHeader = New SIS.ADM.admMonitorSheetHeader("ADM_ServiceSheetHeader5",Reader)
      _FK_ADM_ServiceSheetDetails_HRM_Employees = New SIS.ADM.admEmployees("HRM_Employees6",Reader)
      _FK_ADM_ServiceSheetDetails_HRM_Employees1 = New SIS.ADM.admEmployees("HRM_Employees7",Reader)
      _FK_ADM_ServiceSheetDetails_HRM_Employees2 = New SIS.ADM.admEmployees("HRM_Employees8",Reader)
    End Sub
    Public Sub New(ByVal AliasName As String, ByVal Reader As SqlDataReader)
      On Error Resume Next
      _SheetID = Ctype(Reader(AliasName & "_SheetID"),Int32)
      _SerialNo = Ctype(Reader(AliasName & "_SerialNo"),Int32)
      If Convert.IsDBNull(Reader(AliasName & "_SheetDate")) Then
        _SheetDate = String.Empty
      Else
        _SheetDate = Ctype(Reader(AliasName & "_SheetDate"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_ServiceID")) Then
        _ServiceID = String.Empty
      Else
        _ServiceID = Ctype(Reader(AliasName & "_ServiceID"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_ScheduleID")) Then
        _ScheduleID = String.Empty
      Else
        _ScheduleID = Ctype(Reader(AliasName & "_ScheduleID"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_CheckPointID")) Then
        _CheckPointID = String.Empty
      Else
        _CheckPointID = Ctype(Reader(AliasName & "_CheckPointID"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_MeasureID")) Then
        _MeasureID = String.Empty
      Else
        _MeasureID = Ctype(Reader(AliasName & "_MeasureID"), String)
      End If
      _Initiated = Ctype(Reader(AliasName & "_Initiated"),Boolean)
      If Convert.IsDBNull(Reader(AliasName & "_InitiatedBy")) Then
        _InitiatedBy = String.Empty
      Else
        _InitiatedBy = Ctype(Reader(AliasName & "_InitiatedBy"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_InitiatedOn")) Then
        _InitiatedOn = String.Empty
      Else
        _InitiatedOn = Ctype(Reader(AliasName & "_InitiatedOn"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_InitiatorRemarks")) Then
        _InitiatorRemarks = String.Empty
      Else
        _InitiatorRemarks = Ctype(Reader(AliasName & "_InitiatorRemarks"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_MonitoredBy")) Then
        _MonitoredBy = String.Empty
      Else
        _MonitoredBy = Ctype(Reader(AliasName & "_MonitoredBy"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_MonitoredOn")) Then
        _MonitoredOn = String.Empty
      Else
        _MonitoredOn = Ctype(Reader(AliasName & "_MonitoredOn"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_MonitorRemarks")) Then
        _MonitorRemarks = String.Empty
      Else
        _MonitorRemarks = Ctype(Reader(AliasName & "_MonitorRemarks"), String)
      End If
      _Monitored = Ctype(Reader(AliasName & "_Monitored"),Boolean)
      _ProblemIdentified = Ctype(Reader(AliasName & "_ProblemIdentified"),Boolean)
      _ProblemClosed = Ctype(Reader(AliasName & "_ProblemClosed"),Boolean)
      If Convert.IsDBNull(Reader(AliasName & "_ClosedBy")) Then
        _ClosedBy = String.Empty
      Else
        _ClosedBy = Ctype(Reader(AliasName & "_ClosedBy"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_ClosedOn")) Then
        _ClosedOn = String.Empty
      Else
        _ClosedOn = Ctype(Reader(AliasName & "_ClosedOn"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_ClosingRemarks")) Then
        _ClosingRemarks = String.Empty
      Else
        _ClosingRemarks = Ctype(Reader(AliasName & "_ClosingRemarks"), String)
      End If
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
