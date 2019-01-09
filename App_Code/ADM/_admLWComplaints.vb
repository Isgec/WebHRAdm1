Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ADM
	<DataObject()> _
	Partial Public Class admLWComplaints
		Private Shared _RecordCount As Integer
		Private _CallID As Int32 = 0
		Private _EndUserID As String = ""
		Private _CallTypeID As String = ""
		Private _Description As String = ""
		Private _AssignedTo As String = ""
		Private _CallStatusID As String = ""
		Private _LoggedOn As String = ""
		Private _LoggedBy As String = ""
		Private _FirstAttendedOn As String = ""
		Private _ClosedOn As String = ""
		Private _FirstAttended As Boolean = False
		Private _Closed As Boolean = False
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
				If Convert.IsDBNull(value) Then
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
				If Convert.IsDBNull(value) Then
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
				If Convert.IsDBNull(value) Then
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
				If Convert.IsDBNull(value) Then
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
				If Convert.IsDBNull(value) Then
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
				If Convert.IsDBNull(value) Then
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
				If Convert.IsDBNull(value) Then
					_LoggedBy = ""
				Else
					_LoggedBy = value
				End If
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
				If Convert.IsDBNull(value) Then
					_FirstAttendedOn = ""
				Else
					_FirstAttendedOn = value
				End If
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
				If Convert.IsDBNull(value) Then
					_ClosedOn = ""
				Else
					_ClosedOn = value
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
		Public Property Closed() As Boolean
			Get
				Return _Closed
			End Get
			Set(ByVal value As Boolean)
				_Closed = value
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
		<DataObjectMethod(DataObjectMethodType.Select)> _
		Public Shared Function GetNewRecord() As SIS.ADM.admLWComplaints
			Dim Results As SIS.ADM.admLWComplaints = Nothing
			Results = New SIS.ADM.admLWComplaints()
			Return Results
		End Function
		<DataObjectMethod(DataObjectMethodType.Select)> _
		Public Shared Function GetByID(ByVal CallID As Int32) As SIS.ADM.admLWComplaints
			Dim Results As SIS.ADM.admLWComplaints = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spadmLWComplaintsSelectByID"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CallID", SqlDbType.Int, CallID.ToString.Length, CallID)
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Reader.Read() Then
						Results = New SIS.ADM.admLWComplaints(Reader)
					End If
					Reader.Close()
				End Using
			End Using
			Return Results
		End Function
		'Select By ID One Record Filtered Overloaded GetByID
		<DataObjectMethod(DataObjectMethodType.Select)> _
		Public Shared Function SelectList(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal orderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.ADM.admLWComplaints)
			Dim Results As List(Of SIS.ADM.admLWComplaints) = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spadmLWComplaintsSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spadmLWComplaintsSelectListFilteres"
					End If
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@startRowIndex", SqlDbType.Int, -1, startRowIndex)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@maximumRows", SqlDbType.Int, -1, maximumRows)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
					Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
					Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
					_RecordCount = -1
					Results = New List(Of SIS.ADM.admLWComplaints)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results.Add(New SIS.ADM.admLWComplaints(Reader))
					End While
					Reader.Close()
					_RecordCount = Cmd.Parameters("@RecordCount").Value
				End Using
			End Using
			Return Results
		End Function
		<DataObjectMethod(DataObjectMethodType.Insert, True)> _
		Public Shared Function Insert(ByVal Record As SIS.ADM.admLWComplaints) As Int32
			Dim _Result As Int32 = Record.CallID
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spadmLWComplaintsInsert"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EndUserID", SqlDbType.NVarChar, 9, IIf(Record.EndUserID = "", Convert.DBNull, Record.EndUserID))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CallTypeID", SqlDbType.NVarChar, 21, IIf(Record.CallTypeID = "", Convert.DBNull, Record.CallTypeID))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description", SqlDbType.NVarChar, 251, IIf(Record.Description = "", Convert.DBNull, Record.Description))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AssignedTo", SqlDbType.NVarChar, 9, IIf(Record.AssignedTo = "", Convert.DBNull, Record.AssignedTo))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CallStatusID", SqlDbType.NVarChar, 21, IIf(Record.CallStatusID = "", Convert.DBNull, Record.CallStatusID))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoggedOn", SqlDbType.DateTime, 21, IIf(Record.LoggedOn = "", Convert.DBNull, Record.LoggedOn))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoggedBy", SqlDbType.NVarChar, 9, IIf(Record.LoggedBy = "", Convert.DBNull, Record.LoggedBy))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FirstAttendedOn", SqlDbType.DateTime, 21, IIf(Record.FirstAttendedOn = "", Convert.DBNull, Record.FirstAttendedOn))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ClosedOn", SqlDbType.DateTime, 21, IIf(Record.ClosedOn = "", Convert.DBNull, Record.ClosedOn))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FirstAttended", SqlDbType.Bit, 3, Record.FirstAttended)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Closed", SqlDbType.Bit, 3, Record.Closed)
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
		Public Shared Function Update(ByVal Record As SIS.ADM.admLWComplaints) As Int32
			Dim _Result As Integer = 0
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spadmLWComplaintsUpdate"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_CallID", SqlDbType.Int, 11, Record.CallID)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EndUserID", SqlDbType.NVarChar, 9, IIf(Record.EndUserID = "", Convert.DBNull, Record.EndUserID))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CallTypeID", SqlDbType.NVarChar, 21, IIf(Record.CallTypeID = "", Convert.DBNull, Record.CallTypeID))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description", SqlDbType.NVarChar, 251, IIf(Record.Description = "", Convert.DBNull, Record.Description))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AssignedTo", SqlDbType.NVarChar, 9, IIf(Record.AssignedTo = "", Convert.DBNull, Record.AssignedTo))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CallStatusID", SqlDbType.NVarChar, 21, IIf(Record.CallStatusID = "", Convert.DBNull, Record.CallStatusID))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoggedOn", SqlDbType.DateTime, 21, IIf(Record.LoggedOn = "", Convert.DBNull, Record.LoggedOn))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoggedBy", SqlDbType.NVarChar, 9, IIf(Record.LoggedBy = "", Convert.DBNull, Record.LoggedBy))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FirstAttendedOn", SqlDbType.DateTime, 21, IIf(Record.FirstAttendedOn = "", Convert.DBNull, Record.FirstAttendedOn))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ClosedOn", SqlDbType.DateTime, 21, IIf(Record.ClosedOn = "", Convert.DBNull, Record.ClosedOn))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FirstAttended", SqlDbType.Bit, 3, Record.FirstAttended)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Closed", SqlDbType.Bit, 3, Record.Closed)
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
		Public Shared Function Delete(ByVal Record As SIS.ADM.admLWComplaints) As Int32
			Dim _Result As Integer = 0
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spadmLWComplaintsDelete"
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
		Public Shared Function SelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
			Return _RecordCount
		End Function
		'		Autocomplete Method
		Public Shared Function SelectadmLWComplaintsAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
			Dim Results As List(Of String) = Nothing
			Dim aVal() As String = contextKey.Split("|".ToCharArray)
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spadmLWComplaintsAutoCompleteList"
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
						Dim Tmp As SIS.ADM.admLWComplaints = New SIS.ADM.admLWComplaints(Reader)
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
			If Convert.IsDBNull(Reader("FirstAttendedOn")) Then
				_FirstAttendedOn = String.Empty
			Else
				_FirstAttendedOn = CType(Reader("FirstAttendedOn"), String)
			End If
			If Convert.IsDBNull(Reader("ClosedOn")) Then
				_ClosedOn = String.Empty
			Else
				_ClosedOn = CType(Reader("ClosedOn"), String)
			End If
			_FirstAttended = CType(Reader("FirstAttended"), Boolean)
			_Closed = CType(Reader("Closed"), Boolean)
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
			If Convert.IsDBNull(Reader(AliasName & "_FirstAttendedOn")) Then
				_FirstAttendedOn = String.Empty
			Else
				_FirstAttendedOn = CType(Reader(AliasName & "_FirstAttendedOn"), String)
			End If
			If Convert.IsDBNull(Reader(AliasName & "_ClosedOn")) Then
				_ClosedOn = String.Empty
			Else
				_ClosedOn = CType(Reader(AliasName & "_ClosedOn"), String)
			End If
			_FirstAttended = CType(Reader(AliasName & "_FirstAttended"), Boolean)
			_Closed = CType(Reader(AliasName & "_Closed"), Boolean)
		End Sub
		Public Sub New()
		End Sub
	End Class
End Namespace
