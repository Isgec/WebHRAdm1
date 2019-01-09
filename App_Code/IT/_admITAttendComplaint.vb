Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ADM
  <DataObject()> _
  Partial Public Class admITAttendComplaint
    Private Shared _RecordCount As Integer
    Private _CallID As Int32 = 0
    Private _EndUserID As String = ""
    Private _CallTypeID As String = ""
    Private _Description As String = ""
    Private _AssignedTo As String = ""
    Private _CallStatusID As String = ""
    Private _LoggedOn As String = ""
    Private _LoggedBy As String = ""
    Private _FirstAttended As Boolean = False
    Private _FirstAttendedOn As String = ""
    Private _Closed As Boolean = False
    Private _ClosedOn As String = ""
    Private _FK_ADM_ITComplaints_ADM_ITCallStatus As SIS.ADM.admITCallStatus = Nothing
    Private _FK_ADM_ITComplaints_ADM_ITCallTypes As SIS.ADM.admITCallTypes = Nothing
    Private _FK_ADM_ITComplaints_HRM_Employees As SIS.ADM.admEmployees = Nothing
    Private _FK_ADM_ITComplaints_ADM_Users As SIS.ADM.admUsers = Nothing
    Public Property CallID() As Int32
      Get
        Return _CallID
      End Get
      Set(ByVal value As Int32)
        _CallID = value
      End Set
    End Property
    Public Property EndUserID() As String
      Get
        Return _EndUserID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _EndUserID = ""
				 Else
					 _EndUserID = value
			   End If
      End Set
    End Property
    Public Property CallTypeID() As String
      Get
        Return _CallTypeID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _CallTypeID = ""
				 Else
					 _CallTypeID = value
			   End If
      End Set
    End Property
    Public Property Description() As String
      Get
        Return _Description
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _Description = ""
				 Else
					 _Description = value
			   End If
      End Set
    End Property
    Public Property AssignedTo() As String
      Get
        Return _AssignedTo
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _AssignedTo = ""
				 Else
					 _AssignedTo = value
			   End If
      End Set
    End Property
    Public Property CallStatusID() As String
      Get
        Return _CallStatusID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _CallStatusID = ""
				 Else
					 _CallStatusID = value
			   End If
      End Set
    End Property
    Public Property LoggedOn() As String
      Get
        If Not _LoggedOn = String.Empty Then
					Return Convert.ToDateTime(_LoggedOn).ToString("dd/MM/yyyy HH:mm")
        End If
        Return _LoggedOn
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _LoggedOn = ""
				 Else
					 _LoggedOn = value
			   End If
      End Set
    End Property
    Public Property LoggedBy() As String
      Get
        Return _LoggedBy
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _LoggedBy = ""
				 Else
					 _LoggedBy = value
			   End If
      End Set
    End Property
    Public Property FirstAttended() As Boolean
      Get
        Return _FirstAttended
      End Get
      Set(ByVal value As Boolean)
        _FirstAttended = value
      End Set
    End Property
    Public Property FirstAttendedOn() As String
      Get
        If Not _FirstAttendedOn = String.Empty Then
					Return Convert.ToDateTime(_FirstAttendedOn).ToString("dd/MM/yyyy HH:mm")
        End If
        Return _FirstAttendedOn
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _FirstAttendedOn = ""
				 Else
					 _FirstAttendedOn = value
			   End If
      End Set
    End Property
    Public Property Closed() As Boolean
      Get
        Return _Closed
      End Get
      Set(ByVal value As Boolean)
        _Closed = value
      End Set
    End Property
    Public Property ClosedOn() As String
      Get
        If Not _ClosedOn = String.Empty Then
					Return Convert.ToDateTime(_ClosedOn).ToString("dd/MM/yyyy HH:mm")
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
    Public Property DisplayField() As String
      Get
        Return ""
      End Get
      Set(ByVal value As String)
      End Set
    End Property
    Public Property PrimaryKey() As String
      Get
        Return _CallID
      End Get
      Set(ByVal value As String)
      End Set
    End Property
    Public ReadOnly Property FK_ADM_ITComplaints_ADM_ITCallStatus() As SIS.ADM.admITCallStatus
      Get
        If _FK_ADM_ITComplaints_ADM_ITCallStatus Is Nothing Then
          _FK_ADM_ITComplaints_ADM_ITCallStatus = SIS.ADM.admITCallStatus.GetByID(_CallStatusID)
        End If
        Return _FK_ADM_ITComplaints_ADM_ITCallStatus
      End Get
    End Property
    Public ReadOnly Property FK_ADM_ITComplaints_ADM_ITCallTypes() As SIS.ADM.admITCallTypes
      Get
        If _FK_ADM_ITComplaints_ADM_ITCallTypes Is Nothing Then
          _FK_ADM_ITComplaints_ADM_ITCallTypes = SIS.ADM.admITCallTypes.GetByID(_CallTypeID)
        End If
        Return _FK_ADM_ITComplaints_ADM_ITCallTypes
      End Get
    End Property
    Public ReadOnly Property FK_ADM_ITComplaints_HRM_Employees() As SIS.ADM.admEmployees
      Get
        If _FK_ADM_ITComplaints_HRM_Employees Is Nothing Then
          _FK_ADM_ITComplaints_HRM_Employees = SIS.ADM.admEmployees.GetByID(_EndUserID)
        End If
        Return _FK_ADM_ITComplaints_HRM_Employees
      End Get
    End Property
    Public ReadOnly Property FK_ADM_ITComplaints_ADM_Users() As SIS.ADM.admUsers
      Get
        If _FK_ADM_ITComplaints_ADM_Users Is Nothing Then
          _FK_ADM_ITComplaints_ADM_Users = SIS.ADM.admUsers.GetByID(_LoggedBy)
        End If
        Return _FK_ADM_ITComplaints_ADM_Users
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetNewRecord() As SIS.ADM.admITAttendComplaint
      Dim Results As SIS.ADM.admITAttendComplaint = Nothing
      Results = New SIS.ADM.admITAttendComplaint()
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByID(ByVal CallID As Int32) As SIS.ADM.admITAttendComplaint
      Dim Results As SIS.ADM.admITAttendComplaint = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmITAttendComplaintSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CallID",SqlDbType.Int,CallID.ToString.Length, CallID)
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ADM.admITAttendComplaint(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByID(ByVal CallID As Int32, ByVal Filter_EndUserID As String, ByVal Filter_CallTypeID As String, ByVal Filter_CallStatusID As String) As SIS.ADM.admITAttendComplaint
      Return GetByID(CallID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function SelectList(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal orderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal EndUserID As String, ByVal CallTypeID As String, ByVal CallStatusID As String) As List(Of SIS.ADM.admITAttendComplaint)
      Dim Results As List(Of SIS.ADM.admITAttendComplaint) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "LoggedOn DESC"
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spadmITAttendComplaintSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spadmITAttendComplaintSelectListFilteres"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_EndUserID",SqlDbType.NVarChar,8, IIf(EndUserID Is Nothing, String.Empty,EndUserID))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CallTypeID",SqlDbType.NVarChar,20, IIf(CallTypeID Is Nothing, String.Empty,CallTypeID))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CallStatusID",SqlDbType.NVarChar,20, IIf(CallStatusID Is Nothing, String.Empty,CallStatusID))
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@startRowIndex", SqlDbType.Int, -1, startRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@maximumRows", SqlDbType.Int, -1, maximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AssignedTo",SqlDbType.NVarChar,8, Global.System.Web.HttpContext.Current.Session("LoginID"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ADM.admITAttendComplaint)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ADM.admITAttendComplaint(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function SelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal EndUserID As String, ByVal CallTypeID As String, ByVal CallStatusID As String) As Integer
      Return _RecordCount
    End Function
'		Autocomplete Method
		Public Shared Function SelectadmITAttendComplaintAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
			Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spadmITAttendComplaintAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AssignedTo",SqlDbType.NVarChar,8, Global.System.Web.HttpContext.Current.Session("LoginID"))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
					Results = New List(Of String)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Not Reader.HasRows Then
					  Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---",""))
					End If
					While (Reader.Read())
            Dim Tmp As SIS.ADM.admITAttendComplaint = New SIS.ADM.admITAttendComplaint(Reader)
					  Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(Tmp.DisplayField, Tmp.PrimaryKey))
					End While
					Reader.Close()
				End Using
			End Using
			Return Results.ToArray
		End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      On Error Resume Next
      _CallID = Ctype(Reader("CallID"),Int32)
      If Convert.IsDBNull(Reader("EndUserID")) Then
        _EndUserID = String.Empty
      Else
        _EndUserID = Ctype(Reader("EndUserID"), String)
      End If
      If Convert.IsDBNull(Reader("CallTypeID")) Then
        _CallTypeID = String.Empty
      Else
        _CallTypeID = Ctype(Reader("CallTypeID"), String)
      End If
      If Convert.IsDBNull(Reader("Description")) Then
        _Description = String.Empty
      Else
        _Description = Ctype(Reader("Description"), String)
      End If
      If Convert.IsDBNull(Reader("AssignedTo")) Then
        _AssignedTo = String.Empty
      Else
        _AssignedTo = Ctype(Reader("AssignedTo"), String)
      End If
      If Convert.IsDBNull(Reader("CallStatusID")) Then
        _CallStatusID = String.Empty
      Else
        _CallStatusID = Ctype(Reader("CallStatusID"), String)
      End If
      If Convert.IsDBNull(Reader("LoggedOn")) Then
        _LoggedOn = String.Empty
      Else
        _LoggedOn = Ctype(Reader("LoggedOn"), String)
      End If
      If Convert.IsDBNull(Reader("LoggedBy")) Then
        _LoggedBy = String.Empty
      Else
        _LoggedBy = Ctype(Reader("LoggedBy"), String)
      End If
      _FirstAttended = Ctype(Reader("FirstAttended"),Boolean)
      If Convert.IsDBNull(Reader("FirstAttendedOn")) Then
        _FirstAttendedOn = String.Empty
      Else
        _FirstAttendedOn = Ctype(Reader("FirstAttendedOn"), String)
      End If
      _Closed = Ctype(Reader("Closed"),Boolean)
      If Convert.IsDBNull(Reader("ClosedOn")) Then
        _ClosedOn = String.Empty
      Else
        _ClosedOn = Ctype(Reader("ClosedOn"), String)
      End If
      _FK_ADM_ITComplaints_ADM_ITCallStatus = New SIS.ADM.admITCallStatus("ADM_ITCallStatus1",Reader)
      _FK_ADM_ITComplaints_ADM_ITCallTypes = New SIS.ADM.admITCallTypes("ADM_ITCallTypes2",Reader)
      _FK_ADM_ITComplaints_HRM_Employees = New SIS.ADM.admEmployees("HRM_Employees5",Reader)
      _FK_ADM_ITComplaints_ADM_Users = New SIS.ADM.admUsers("aspnet_users3",Reader)
    End Sub
    Public Sub New(ByVal AliasName As String, ByVal Reader As SqlDataReader)
      On Error Resume Next
      _CallID = Ctype(Reader(AliasName & "_CallID"),Int32)
      If Convert.IsDBNull(Reader(AliasName & "_EndUserID")) Then
        _EndUserID = String.Empty
      Else
        _EndUserID = Ctype(Reader(AliasName & "_EndUserID"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_CallTypeID")) Then
        _CallTypeID = String.Empty
      Else
        _CallTypeID = Ctype(Reader(AliasName & "_CallTypeID"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_Description")) Then
        _Description = String.Empty
      Else
        _Description = Ctype(Reader(AliasName & "_Description"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_AssignedTo")) Then
        _AssignedTo = String.Empty
      Else
        _AssignedTo = Ctype(Reader(AliasName & "_AssignedTo"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_CallStatusID")) Then
        _CallStatusID = String.Empty
      Else
        _CallStatusID = Ctype(Reader(AliasName & "_CallStatusID"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_LoggedOn")) Then
        _LoggedOn = String.Empty
      Else
        _LoggedOn = Ctype(Reader(AliasName & "_LoggedOn"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_LoggedBy")) Then
        _LoggedBy = String.Empty
      Else
        _LoggedBy = Ctype(Reader(AliasName & "_LoggedBy"), String)
      End If
      _FirstAttended = Ctype(Reader(AliasName & "_FirstAttended"),Boolean)
      If Convert.IsDBNull(Reader(AliasName & "_FirstAttendedOn")) Then
        _FirstAttendedOn = String.Empty
      Else
        _FirstAttendedOn = Ctype(Reader(AliasName & "_FirstAttendedOn"), String)
      End If
      _Closed = Ctype(Reader(AliasName & "_Closed"),Boolean)
      If Convert.IsDBNull(Reader(AliasName & "_ClosedOn")) Then
        _ClosedOn = String.Empty
      Else
        _ClosedOn = Ctype(Reader(AliasName & "_ClosedOn"), String)
      End If
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
