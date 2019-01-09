Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ADM
  <DataObject()> _
  Partial Public Class admInitiatorSheetDetails
    Private Shared _RecordCount As Integer
    Private _SheetID As Int32 = 0
    Private _SerialNo As Int32 = 0
    Private _SheetDate As String = ""
    Private _ServiceID As String = ""
    Private _ScheduleID As String = ""
    Private _CheckPointID As String = ""
    Private _MeasureID As String = ""
    Private _Monitored As Boolean = False
    Private _ProblemClosed As Boolean = False
    Private _Initiated As Boolean = False
    Private _InitiatedBy As String = ""
    Private _InitiatedOn As String = ""
    Private _ProblemIdentified As Boolean = False
		Private _InitiatorRemarks As String = ""
		Private _CPInitiator As String = ""
		Private _aspnet_users9_UserFullName As String = ""
		Private _FK_ADM_ServiceSheetDetails_ADM_CheckPoints As SIS.ADM.admCheckPoints = Nothing
    Private _FK_ADM_ServiceSheetDetails_ADM_ServiceSheetDetails As SIS.ADM.admMeasures = Nothing
    Private _FK_ADM_ServiceSheetDetails_ADM_Schedules As SIS.ADM.admSchedules = Nothing
    Private _FK_ADM_ServiceSheetDetails_ADM_Services As SIS.ADM.admServices = Nothing
    Private _FK_ADM_ServiceSheetDetails_ADM_ServiceSheetHeader As SIS.ADM.admInitiatorSheetHeader = Nothing
		Private _FK_ADM_ServiceSheetDetails_HRM_Employees As SIS.ADM.admEmployees = Nothing
		Public Property aspnet_users9_UserFullName() As String
			Get
				Return _aspnet_users9_UserFullName
			End Get
			Set(ByVal value As String)
				If Convert.IsDBNull(value) Then
					_aspnet_users9_UserFullName = ""
				Else
					_aspnet_users9_UserFullName = value
				End If
			End Set
		End Property
		Public Property CPInitiator() As String
			Get
				Return _CPInitiator
			End Get
			Set(ByVal value As String)
				If Convert.IsDBNull(value) Then
					_CPInitiator = ""
				Else
					_CPInitiator = value
				End If
			End Set
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
    Public Property Monitored() As Boolean
      Get
        Return _Monitored
      End Get
      Set(ByVal value As Boolean)
        _Monitored = value
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
    Public Property ProblemIdentified() As Boolean
      Get
        Return _ProblemIdentified
      End Get
      Set(ByVal value As Boolean)
        _ProblemIdentified = value
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
    Public ReadOnly Property FK_ADM_ServiceSheetDetails_ADM_ServiceSheetHeader() As SIS.ADM.admInitiatorSheetHeader
      Get
        If _FK_ADM_ServiceSheetDetails_ADM_ServiceSheetHeader Is Nothing Then
          _FK_ADM_ServiceSheetDetails_ADM_ServiceSheetHeader = SIS.ADM.admInitiatorSheetHeader.GetByID(_SheetID)
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
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetNewRecord() As SIS.ADM.admInitiatorSheetDetails
      Dim Results As SIS.ADM.admInitiatorSheetDetails = Nothing
      Results = New SIS.ADM.admInitiatorSheetDetails()
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByID(ByVal SheetID As Int32, ByVal SerialNo As Int32) As SIS.ADM.admInitiatorSheetDetails
      Dim Results As SIS.ADM.admInitiatorSheetDetails = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmInitiatorSheetDetailsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SheetID",SqlDbType.Int,SheetID.ToString.Length, SheetID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ADM.admInitiatorSheetDetails(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetBySheetID(ByVal SheetID As Int32, ByVal OrderBy as String) As List(Of SIS.ADM.admInitiatorSheetDetails)
      Dim Results As List(Of SIS.ADM.admInitiatorSheetDetails) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmInitiatorSheetDetailsSelectBySheetID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SheetID",SqlDbType.Int,SheetID.ToString.Length, SheetID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ADM.admInitiatorSheetDetails)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ADM.admInitiatorSheetDetails(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function SelectList(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal orderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.ADM.admInitiatorSheetDetails)
      Dim Results As List(Of SIS.ADM.admInitiatorSheetDetails) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spadmInitiatorSheetDetailsSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spadmInitiatorSheetDetailsSelectListFilteres"
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@startRowIndex", SqlDbType.Int, -1, startRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@maximumRows", SqlDbType.Int, -1, maximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ADM.admInitiatorSheetDetails)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ADM.admInitiatorSheetDetails(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function Update(ByVal Record As SIS.ADM.admInitiatorSheetDetails) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmInitiatorSheetDetailsUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SheetID",SqlDbType.Int,11, Record.SheetID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Initiated",SqlDbType.Bit,3, 1)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InitiatedBy",SqlDbType.NVarChar,9, Global.System.Web.HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InitiatedOn",SqlDbType.DateTime,21, Now)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProblemIdentified",SqlDbType.Bit,3, Record.ProblemIdentified)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InitiatorRemarks",SqlDbType.NVarChar,101, Iif(Record.InitiatorRemarks= "" ,Convert.DBNull, Record.InitiatorRemarks))
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          _Result = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return _Result
    End Function
    Public Shared Function SelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
'		Autocomplete Method
		Public Shared Function SelectadmInitiatorSheetDetailsAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
			Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spadmInitiatorSheetDetailsAutoCompleteList"
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
            Dim Tmp As SIS.ADM.admInitiatorSheetDetails = New SIS.ADM.admInitiatorSheetDetails(Reader)
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
      _Monitored = Ctype(Reader("Monitored"),Boolean)
      _ProblemClosed = Ctype(Reader("ProblemClosed"),Boolean)
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
      _ProblemIdentified = Ctype(Reader("ProblemIdentified"),Boolean)
      If Convert.IsDBNull(Reader("InitiatorRemarks")) Then
        _InitiatorRemarks = String.Empty
      Else
        _InitiatorRemarks = Ctype(Reader("InitiatorRemarks"), String)
      End If
			_FK_ADM_ServiceSheetDetails_ADM_ServiceSheetDetails = New SIS.ADM.admMeasures("ADM_Measures2", Reader)
      _FK_ADM_ServiceSheetDetails_ADM_Schedules = New SIS.ADM.admSchedules("ADM_Schedules3",Reader)
      _FK_ADM_ServiceSheetDetails_ADM_Services = New SIS.ADM.admServices("ADM_Services4",Reader)
      _FK_ADM_ServiceSheetDetails_ADM_ServiceSheetHeader = New SIS.ADM.admInitiatorSheetHeader("ADM_ServiceSheetHeader5",Reader)
      _FK_ADM_ServiceSheetDetails_HRM_Employees = New SIS.ADM.admEmployees("HRM_Employees6",Reader)
			If Convert.IsDBNull(Reader("CPInitiator")) Then
				_CPInitiator = String.Empty
			Else
				_CPInitiator = CType(Reader("CPInitiator"), String)
			End If
			If Convert.IsDBNull(Reader("aspnet_users9_UserFullName")) Then
				_aspnet_users9_UserFullName = String.Empty
			Else
				_aspnet_users9_UserFullName = CType(Reader("aspnet_users9_UserFullName"), String)
			End If
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
      _Monitored = Ctype(Reader(AliasName & "_Monitored"),Boolean)
      _ProblemClosed = Ctype(Reader(AliasName & "_ProblemClosed"),Boolean)
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
      _ProblemIdentified = Ctype(Reader(AliasName & "_ProblemIdentified"),Boolean)
      If Convert.IsDBNull(Reader(AliasName & "_InitiatorRemarks")) Then
        _InitiatorRemarks = String.Empty
      Else
        _InitiatorRemarks = Ctype(Reader(AliasName & "_InitiatorRemarks"), String)
      End If
			If Convert.IsDBNull(Reader(AliasName & "_CPInitiator")) Then
				_CPInitiator = String.Empty
			Else
				_CPInitiator = CType(Reader(AliasName & "_CPInitiator"), String)
			End If
			If Convert.IsDBNull(Reader(AliasName & "_aspnet_users9_UserFullName")) Then
				_aspnet_users9_UserFullName = String.Empty
			Else
				_aspnet_users9_UserFullName = CType(Reader(AliasName & "_aspnet_users9_UserFullName"), String)
			End If
		End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
