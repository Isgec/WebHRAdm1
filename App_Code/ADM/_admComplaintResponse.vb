Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ADM
	<DataObject()> _
	Partial Public Class admComplaintResponse
		Private Shared _RecordCount As Integer
		Private _CallID As Int32 = 0
		Private _SerialNo As Int32 = 0
		Private _Remarks As String = ""
		Private _AttendedOn As String = ""
		Private _AttendedBy As String = ""
		Private _AutoPosted As Boolean = False
		Private _FK_ADM_ComplaintResponse_ADM_Users As SIS.ADM.admUsers = Nothing
		Public Property CallID() As Int32
			Get
				Return _CallID
			End Get
			Set(ByVal value As Int32)
				_CallID = value
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
		Public Property Remarks() As String
			Get
				Return _Remarks
			End Get
			Set(ByVal value As String)
				_Remarks = value
			End Set
		End Property
		Public Property AttendedOn() As String
			Get
				If Not _AttendedOn = String.Empty Then
					Return Convert.ToDateTime(_AttendedOn).ToString("dd/MM/yyyy HH:mm")
				End If
				Return _AttendedOn
			End Get
			Set(ByVal value As String)
				If Convert.IsDBNull(value) Then
					_AttendedOn = ""
				Else
					_AttendedOn = value
				End If
			End Set
		End Property
		Public Property AttendedBy() As String
			Get
				Return _AttendedBy
			End Get
			Set(ByVal value As String)
				If Convert.IsDBNull(value) Then
					_AttendedBy = ""
				Else
					_AttendedBy = value
				End If
			End Set
		End Property
		Public Property AutoPosted() As Boolean
			Get
				Return _AutoPosted
			End Get
			Set(ByVal value As Boolean)
				_AutoPosted = value
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
				Return _CallID & "|" & _SerialNo
			End Get
			Set(ByVal value As String)
			End Set
		End Property
		Public ReadOnly Property FK_ADM_ComplaintResponse_ADM_Users() As SIS.ADM.admUsers
			Get
				If _FK_ADM_ComplaintResponse_ADM_Users Is Nothing Then
					_FK_ADM_ComplaintResponse_ADM_Users = SIS.ADM.admUsers.GetByID(_AttendedBy)
				End If
				Return _FK_ADM_ComplaintResponse_ADM_Users
			End Get
		End Property
		<DataObjectMethod(DataObjectMethodType.Select)> _
		Public Shared Function GetNewRecord() As SIS.ADM.admComplaintResponse
			Dim Results As SIS.ADM.admComplaintResponse = Nothing
			Results = New SIS.ADM.admComplaintResponse()
			Return Results
		End Function
		<DataObjectMethod(DataObjectMethodType.Select)> _
		Public Shared Function GetByID(ByVal CallID As Int32, ByVal SerialNo As Int32) As SIS.ADM.admComplaintResponse
			Dim Results As SIS.ADM.admComplaintResponse = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spadmComplaintResponseSelectByID"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CallID", SqlDbType.Int, CallID.ToString.Length, CallID)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo", SqlDbType.Int, SerialNo.ToString.Length, SerialNo)
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Reader.Read() Then
						Results = New SIS.ADM.admComplaintResponse(Reader)
					End If
					Reader.Close()
				End Using
			End Using
			Return Results
		End Function
		'Select By ID One Record Filtered Overloaded GetByID
		<DataObjectMethod(DataObjectMethodType.Select)> _
		Public Shared Function GetByID(ByVal CallID As Int32, ByVal SerialNo As Int32, ByVal Filter_CallID As Int32) As SIS.ADM.admComplaintResponse
			Return GetByID(CallID, SerialNo)
		End Function
		<DataObjectMethod(DataObjectMethodType.Select)> _
		Public Shared Function GetByCallID(ByVal CallID As Int32, ByVal OrderBy As String) As List(Of SIS.ADM.admComplaintResponse)
			Dim Results As List(Of SIS.ADM.admComplaintResponse) = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					If OrderBy = String.Empty Then OrderBy = "AttendedOn DESC"
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spadmComplaintResponseSelectByCallID"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CallID", SqlDbType.Int, CallID.ToString.Length, CallID)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
					Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
					Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
					_RecordCount = -1
					Results = New List(Of SIS.ADM.admComplaintResponse)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results.Add(New SIS.ADM.admComplaintResponse(Reader))
					End While
					Reader.Close()
					_RecordCount = Cmd.Parameters("@RecordCount").Value
				End Using
			End Using
			Return Results
		End Function
		<DataObjectMethod(DataObjectMethodType.Select)> _
		Public Shared Function SelectList(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal orderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal CallID As Int32) As List(Of SIS.ADM.admComplaintResponse)
			Dim Results As List(Of SIS.ADM.admComplaintResponse) = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					If orderBy = String.Empty Then orderBy = "AttendedOn DESC"
					Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spadmComplaintResponseSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spadmComplaintResponseSelectListFilteres"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CallID", SqlDbType.Int, 10, IIf(CallID = Nothing, 0, CallID))
					End If
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@startRowIndex", SqlDbType.Int, -1, startRowIndex)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@maximumRows", SqlDbType.Int, -1, maximumRows)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
					Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
					Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
					_RecordCount = -1
					Results = New List(Of SIS.ADM.admComplaintResponse)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results.Add(New SIS.ADM.admComplaintResponse(Reader))
					End While
					Reader.Close()
					_RecordCount = Cmd.Parameters("@RecordCount").Value
				End Using
			End Using
			Return Results
		End Function
		<DataObjectMethod(DataObjectMethodType.Insert, True)> _
		Public Shared Function Insert(ByVal Record As SIS.ADM.admComplaintResponse) As Int32
			Dim _Result As Int32 = Record.SerialNo
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spadmComplaintResponseInsert"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CallID", SqlDbType.Int, 11, Record.CallID)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Remarks", SqlDbType.NVarChar, 251, Record.Remarks)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AttendedOn", SqlDbType.DateTime, 21, Now)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AttendedBy", SqlDbType.NVarChar, 9, Global.System.Web.HttpContext.Current.Session("LoginID"))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AutoPosted", SqlDbType.Bit, 3, Record.AutoPosted)
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
		Public Shared Function Update(ByVal Record As SIS.ADM.admComplaintResponse) As Int32
			Dim _Result As Integer = 0
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spadmComplaintResponseUpdate"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_CallID", SqlDbType.Int, 11, Record.CallID)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo", SqlDbType.Int, 11, Record.SerialNo)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Remarks", SqlDbType.NVarChar, 251, Record.Remarks)
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
		Public Shared Function Delete(ByVal Record As SIS.ADM.admComplaintResponse) As Int32
			Dim _Result As Integer = 0
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spadmComplaintResponseDelete"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_CallID", SqlDbType.Int, Record.CallID.ToString.Length, Record.CallID)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo", SqlDbType.Int, Record.SerialNo.ToString.Length, Record.SerialNo)
					Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
					Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
					Con.Open()
					Cmd.ExecuteNonQuery()
					_Result = Cmd.Parameters("@RowCount").Value
				End Using
			End Using
			Return _Result
		End Function
		Public Shared Function SelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal CallID As Int32) As Integer
			Return _RecordCount
		End Function
		'		Autocomplete Method
		Public Shared Function SelectadmComplaintResponseAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
			Dim Results As List(Of String) = Nothing
			Dim aVal() As String = contextKey.Split("|".ToCharArray)
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spadmComplaintResponseAutoCompleteList"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
					Results = New List(Of String)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Not Reader.HasRows Then
						Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---", "" & "|" & ""))
					End If
					While (Reader.Read())
						Dim Tmp As SIS.ADM.admComplaintResponse = New SIS.ADM.admComplaintResponse(Reader)
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
			_SerialNo = CType(Reader("SerialNo"), Int32)
			_Remarks = CType(Reader("Remarks"), String)
			If Convert.IsDBNull(Reader("AttendedOn")) Then
				_AttendedOn = String.Empty
			Else
				_AttendedOn = CType(Reader("AttendedOn"), String)
			End If
			If Convert.IsDBNull(Reader("AttendedBy")) Then
				_AttendedBy = String.Empty
			Else
				_AttendedBy = CType(Reader("AttendedBy"), String)
			End If
			_AutoPosted = CType(Reader("AutoPosted"), Boolean)
			_FK_ADM_ComplaintResponse_ADM_Users = New SIS.ADM.admUsers("aspnet_users2", Reader)
		End Sub
		Public Sub New(ByVal AliasName As String, ByVal Reader As SqlDataReader)
			On Error Resume Next
			_CallID = CType(Reader(AliasName & "_CallID"), Int32)
			_SerialNo = CType(Reader(AliasName & "_SerialNo"), Int32)
			_Remarks = CType(Reader(AliasName & "_Remarks"), String)
			If Convert.IsDBNull(Reader(AliasName & "_AttendedOn")) Then
				_AttendedOn = String.Empty
			Else
				_AttendedOn = CType(Reader(AliasName & "_AttendedOn"), String)
			End If
			If Convert.IsDBNull(Reader(AliasName & "_AttendedBy")) Then
				_AttendedBy = String.Empty
			Else
				_AttendedBy = CType(Reader(AliasName & "_AttendedBy"), String)
			End If
			_AutoPosted = CType(Reader(AliasName & "_AutoPosted"), Boolean)
		End Sub
		Public Sub New()
		End Sub
	End Class
End Namespace
