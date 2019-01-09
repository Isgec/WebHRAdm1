Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ADM
	<DataObject()> _
	Partial Public Class admRegisterComplaint
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
		Private _FK_ADM_Complaints_ADM_CallStatus As SIS.ADM.admCallStatus = Nothing
		Private _FK_ADM_Complaints_ADM_CallTypes As SIS.ADM.admCallTypes = Nothing
		Private _FK_ADM_Complaints_HRM_Employees As SIS.ADM.admEmployees = Nothing
		Private _FK_ADM_Complaints_ADM_Users As SIS.ADM.admUsers = Nothing
		Private _FK_ADM_Complaints_ADM_Users1 As SIS.ADM.admUsers = Nothing
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
		Public ReadOnly Property FK_ADM_Complaints_ADM_CallStatus() As SIS.ADM.admCallStatus
			Get
				If _FK_ADM_Complaints_ADM_CallStatus Is Nothing Then
					_FK_ADM_Complaints_ADM_CallStatus = SIS.ADM.admCallStatus.GetByID(_CallStatusID)
				End If
				Return _FK_ADM_Complaints_ADM_CallStatus
			End Get
		End Property
		Public ReadOnly Property FK_ADM_Complaints_ADM_CallTypes() As SIS.ADM.admCallTypes
			Get
				If _FK_ADM_Complaints_ADM_CallTypes Is Nothing Then
					_FK_ADM_Complaints_ADM_CallTypes = SIS.ADM.admCallTypes.GetByID(_CallTypeID)
				End If
				Return _FK_ADM_Complaints_ADM_CallTypes
			End Get
		End Property
		Public ReadOnly Property FK_ADM_Complaints_HRM_Employees() As SIS.ADM.admEmployees
			Get
				If _FK_ADM_Complaints_HRM_Employees Is Nothing Then
					_FK_ADM_Complaints_HRM_Employees = SIS.ADM.admEmployees.GetByID(_EndUserID)
				End If
				Return _FK_ADM_Complaints_HRM_Employees
			End Get
		End Property
		Public ReadOnly Property FK_ADM_Complaints_ADM_Users() As SIS.ADM.admUsers
			Get
				If _FK_ADM_Complaints_ADM_Users Is Nothing Then
					_FK_ADM_Complaints_ADM_Users = SIS.ADM.admUsers.GetByID(_LoggedBy)
				End If
				Return _FK_ADM_Complaints_ADM_Users
			End Get
		End Property
		Public ReadOnly Property FK_ADM_Complaints_ADM_Users1() As SIS.ADM.admUsers
			Get
				If _FK_ADM_Complaints_ADM_Users1 Is Nothing Then
					_FK_ADM_Complaints_ADM_Users1 = SIS.ADM.admUsers.GetByID(_AssignedTo)
				End If
				Return _FK_ADM_Complaints_ADM_Users1
			End Get
		End Property
		<DataObjectMethod(DataObjectMethodType.Select)> _
		Public Shared Function GetNewRecord() As SIS.ADM.admRegisterComplaint
			Dim Results As SIS.ADM.admRegisterComplaint = Nothing
			Results = New SIS.ADM.admRegisterComplaint()
			Return Results
		End Function
		<DataObjectMethod(DataObjectMethodType.Select)> _
		Public Shared Function GetByID(ByVal CallID As Int32) As SIS.ADM.admRegisterComplaint
			Dim Results As SIS.ADM.admRegisterComplaint = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spadmRegisterComplaintSelectByID"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CallID", SqlDbType.Int, CallID.ToString.Length, CallID)
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Reader.Read() Then
						Results = New SIS.ADM.admRegisterComplaint(Reader)
					End If
					Reader.Close()
				End Using
			End Using
			Return Results
		End Function
		'Select By ID One Record Filtered Overloaded GetByID
		<DataObjectMethod(DataObjectMethodType.Select)> _
		Public Shared Function GetByID(ByVal CallID As Int32, ByVal Filter_EndUserID As String, ByVal Filter_CallTypeID As String, ByVal Filter_AssignedTo As String, ByVal Filter_CallStatusID As String) As SIS.ADM.admRegisterComplaint
			Return GetByID(CallID)
		End Function
		<DataObjectMethod(DataObjectMethodType.Select)> _
		Public Shared Function SelectList(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal orderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal EndUserID As String, ByVal CallTypeID As String, ByVal AssignedTo As String, ByVal CallStatusID As String) As List(Of SIS.ADM.admRegisterComplaint)
			Dim Results As List(Of SIS.ADM.admRegisterComplaint) = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					If orderBy = String.Empty Then orderBy = "LoggedOn DESC"
					Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spadmRegisterComplaintSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spadmRegisterComplaintSelectListFilteres"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_EndUserID", SqlDbType.NVarChar, 8, IIf(EndUserID Is Nothing, String.Empty, EndUserID))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CallTypeID", SqlDbType.NVarChar, 20, IIf(CallTypeID Is Nothing, String.Empty, CallTypeID))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_AssignedTo", SqlDbType.NVarChar, 8, IIf(AssignedTo Is Nothing, String.Empty, AssignedTo))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CallStatusID", SqlDbType.NVarChar, 20, IIf(CallStatusID Is Nothing, String.Empty, CallStatusID))
					End If
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@startRowIndex", SqlDbType.Int, -1, startRowIndex)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@maximumRows", SqlDbType.Int, -1, maximumRows)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
					Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
					Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
					_RecordCount = -1
					Results = New List(Of SIS.ADM.admRegisterComplaint)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results.Add(New SIS.ADM.admRegisterComplaint(Reader))
					End While
					Reader.Close()
					_RecordCount = Cmd.Parameters("@RecordCount").Value
				End Using
			End Using
			Return Results
		End Function
		<DataObjectMethod(DataObjectMethodType.Insert, True)> _
		Public Shared Function Insert(ByVal Record As SIS.ADM.admRegisterComplaint) As Int32
			Dim _Result As Int32 = Record.CallID
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spadmRegisterComplaintInsert"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EndUserID", SqlDbType.NVarChar, 9, IIf(Record.EndUserID = "", Convert.DBNull, Record.EndUserID))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CallTypeID", SqlDbType.NVarChar, 21, IIf(Record.CallTypeID = "", Convert.DBNull, Record.CallTypeID))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description", SqlDbType.NVarChar, 251, IIf(Record.Description = "", Convert.DBNull, Record.Description))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AssignedTo", SqlDbType.NVarChar, 9, IIf(Record.AssignedTo = "", Convert.DBNull, Record.AssignedTo))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CallStatusID", SqlDbType.NVarChar, 21, "FREE")
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoggedOn", SqlDbType.DateTime, 21, Now)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoggedBy", SqlDbType.NVarChar, 9, Global.System.Web.HttpContext.Current.Session("LoginID"))
					Cmd.Parameters.Add("@Return_CallID", SqlDbType.Int, 10)
					Cmd.Parameters("@Return_CallID").Direction = ParameterDirection.Output
					Con.Open()
					Cmd.ExecuteNonQuery()
					_Result = Cmd.Parameters("@Return_CallID").Value
				End Using
			End Using
			Return _Result
		End Function
		<DataObjectMethod(DataObjectMethodType.Update, True)> _
		Public Shared Function Update(ByVal Record As SIS.ADM.admRegisterComplaint) As Int32
			Dim _Result As Integer = 0
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spadmRegisterComplaintUpdate"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_CallID", SqlDbType.Int, 11, Record.CallID)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EndUserID", SqlDbType.NVarChar, 9, IIf(Record.EndUserID = "", Convert.DBNull, Record.EndUserID))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CallTypeID", SqlDbType.NVarChar, 21, IIf(Record.CallTypeID = "", Convert.DBNull, Record.CallTypeID))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description", SqlDbType.NVarChar, 251, IIf(Record.Description = "", Convert.DBNull, Record.Description))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AssignedTo", SqlDbType.NVarChar, 9, IIf(Record.AssignedTo = "", Convert.DBNull, Record.AssignedTo))
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
		Public Shared Function Delete(ByVal Record As SIS.ADM.admRegisterComplaint) As Int32
			Dim _Result As Integer = 0
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spadmRegisterComplaintDelete"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_CallID", SqlDbType.Int, Record.CallID.ToString.Length, Record.CallID)
					Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
					Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
					Con.Open()
					Cmd.ExecuteNonQuery()
					_Result = Cmd.Parameters("@RowCount").Value
				End Using
			End Using
			Return _Result
		End Function
		Public Shared Function SelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal EndUserID As String, ByVal CallTypeID As String, ByVal AssignedTo As String, ByVal CallStatusID As String) As Integer
			Return _RecordCount
		End Function
		'		Autocomplete Method
		Public Shared Function SelectadmRegisterComplaintAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
			Dim Results As List(Of String) = Nothing
			Dim aVal() As String = contextKey.Split("|".ToCharArray)
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spadmRegisterComplaintAutoCompleteList"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
					Results = New List(Of String)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Not Reader.HasRows Then
						Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---", ""))
					End If
					While (Reader.Read())
						Dim Tmp As SIS.ADM.admRegisterComplaint = New SIS.ADM.admRegisterComplaint(Reader)
						Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(Tmp.DisplayField, Tmp.PrimaryKey))
					End While
					Reader.Close()
				End Using
			End Using
			Return Results.ToArray
		End Function
		Public Sub New(ByVal Reader As SqlDataReader)
			On Error Resume Next
			_CallID = CType(Reader("CallID"), Int32)
			If Convert.IsDBNull(Reader("EndUserID")) Then
				_EndUserID = String.Empty
			Else
				_EndUserID = CType(Reader("EndUserID"), String)
			End If
			If Convert.IsDBNull(Reader("CallTypeID")) Then
				_CallTypeID = String.Empty
			Else
				_CallTypeID = CType(Reader("CallTypeID"), String)
			End If
			If Convert.IsDBNull(Reader("Description")) Then
				_Description = String.Empty
			Else
				_Description = CType(Reader("Description"), String)
			End If
			If Convert.IsDBNull(Reader("AssignedTo")) Then
				_AssignedTo = String.Empty
			Else
				_AssignedTo = CType(Reader("AssignedTo"), String)
			End If
			If Convert.IsDBNull(Reader("CallStatusID")) Then
				_CallStatusID = String.Empty
			Else
				_CallStatusID = CType(Reader("CallStatusID"), String)
			End If
			If Convert.IsDBNull(Reader("LoggedOn")) Then
				_LoggedOn = String.Empty
			Else
				_LoggedOn = CType(Reader("LoggedOn"), String)
			End If
			If Convert.IsDBNull(Reader("LoggedBy")) Then
				_LoggedBy = String.Empty
			Else
				_LoggedBy = CType(Reader("LoggedBy"), String)
			End If
			_FirstAttended = CType(Reader("FirstAttended"), Boolean)
			If Convert.IsDBNull(Reader("FirstAttendedOn")) Then
				_FirstAttendedOn = String.Empty
			Else
				_FirstAttendedOn = CType(Reader("FirstAttendedOn"), String)
			End If
			_Closed = CType(Reader("Closed"), Boolean)
			If Convert.IsDBNull(Reader("ClosedOn")) Then
				_ClosedOn = String.Empty
			Else
				_ClosedOn = CType(Reader("ClosedOn"), String)
			End If
			_FK_ADM_Complaints_ADM_CallStatus = New SIS.ADM.admCallStatus("ADM_CallStatus1", Reader)
			_FK_ADM_Complaints_ADM_CallTypes = New SIS.ADM.admCallTypes("ADM_CallTypes2", Reader)
			_FK_ADM_Complaints_HRM_Employees = New SIS.ADM.admEmployees("HRM_Employees5", Reader)
			_FK_ADM_Complaints_ADM_Users = New SIS.ADM.admUsers("aspnet_users3", Reader)
			_FK_ADM_Complaints_ADM_Users1 = New SIS.ADM.admUsers("aspnet_users4", Reader)
		End Sub
		Public Sub New(ByVal AliasName As String, ByVal Reader As SqlDataReader)
			On Error Resume Next
			_CallID = CType(Reader(AliasName & "_CallID"), Int32)
			If Convert.IsDBNull(Reader(AliasName & "_EndUserID")) Then
				_EndUserID = String.Empty
			Else
				_EndUserID = CType(Reader(AliasName & "_EndUserID"), String)
			End If
			If Convert.IsDBNull(Reader(AliasName & "_CallTypeID")) Then
				_CallTypeID = String.Empty
			Else
				_CallTypeID = CType(Reader(AliasName & "_CallTypeID"), String)
			End If
			If Convert.IsDBNull(Reader(AliasName & "_Description")) Then
				_Description = String.Empty
			Else
				_Description = CType(Reader(AliasName & "_Description"), String)
			End If
			If Convert.IsDBNull(Reader(AliasName & "_AssignedTo")) Then
				_AssignedTo = String.Empty
			Else
				_AssignedTo = CType(Reader(AliasName & "_AssignedTo"), String)
			End If
			If Convert.IsDBNull(Reader(AliasName & "_CallStatusID")) Then
				_CallStatusID = String.Empty
			Else
				_CallStatusID = CType(Reader(AliasName & "_CallStatusID"), String)
			End If
			If Convert.IsDBNull(Reader(AliasName & "_LoggedOn")) Then
				_LoggedOn = String.Empty
			Else
				_LoggedOn = CType(Reader(AliasName & "_LoggedOn"), String)
			End If
			If Convert.IsDBNull(Reader(AliasName & "_LoggedBy")) Then
				_LoggedBy = String.Empty
			Else
				_LoggedBy = CType(Reader(AliasName & "_LoggedBy"), String)
			End If
			_FirstAttended = CType(Reader(AliasName & "_FirstAttended"), Boolean)
			If Convert.IsDBNull(Reader(AliasName & "_FirstAttendedOn")) Then
				_FirstAttendedOn = String.Empty
			Else
				_FirstAttendedOn = CType(Reader(AliasName & "_FirstAttendedOn"), String)
			End If
			_Closed = CType(Reader(AliasName & "_Closed"), Boolean)
			If Convert.IsDBNull(Reader(AliasName & "_ClosedOn")) Then
				_ClosedOn = String.Empty
			Else
				_ClosedOn = CType(Reader(AliasName & "_ClosedOn"), String)
			End If
		End Sub
		Public Sub New()
		End Sub
	End Class
End Namespace
