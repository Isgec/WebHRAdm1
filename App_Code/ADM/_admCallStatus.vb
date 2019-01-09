Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ADM
	<DataObject()> _
	Partial Public Class admCallStatus
		Private Shared _RecordCount As Integer
		Private _CallStatusID As String = ""
		Private _Description As String = ""
		Public Property CallStatusID() As String
			Get
				Return _CallStatusID
			End Get
			Set(ByVal value As String)
				_CallStatusID = value
			End Set
		End Property
		Public Property Description() As String
			Get
				Return _Description
			End Get
			Set(ByVal value As String)
				_Description = value
			End Set
		End Property
		Public Property DisplayField() As String
			Get
				Return "" & _Description.ToString.PadRight(30, " ")
			End Get
			Set(ByVal value As String)
			End Set
		End Property
		Public Property PrimaryKey() As String
			Get
				Return _CallStatusID
			End Get
			Set(ByVal value As String)
			End Set
		End Property
		<DataObjectMethod(DataObjectMethodType.Select)> _
		Public Shared Function SelectList(ByVal orderBy As String) As List(Of SIS.ADM.admCallStatus)
			Dim Results As List(Of SIS.ADM.admCallStatus) = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spadmCallStatusSelectList"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
					Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
					Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
					_RecordCount = -1
					Results = New List(Of SIS.ADM.admCallStatus)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results.Add(New SIS.ADM.admCallStatus(Reader))
					End While
					Reader.Close()
					_RecordCount = Cmd.Parameters("@RecordCount").Value
				End Using
			End Using
			Return Results
		End Function
		<DataObjectMethod(DataObjectMethodType.Select)> _
		Public Shared Function GetNewRecord() As SIS.ADM.admCallStatus
			Dim Results As SIS.ADM.admCallStatus = Nothing
			Results = New SIS.ADM.admCallStatus()
			Return Results
		End Function
		<DataObjectMethod(DataObjectMethodType.Select)> _
		Public Shared Function GetByID(ByVal CallStatusID As String) As SIS.ADM.admCallStatus
			Dim Results As SIS.ADM.admCallStatus = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spadmCallStatusSelectByID"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CallStatusID", SqlDbType.NVarChar, CallStatusID.ToString.Length, CallStatusID)
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Reader.Read() Then
						Results = New SIS.ADM.admCallStatus(Reader)
					End If
					Reader.Close()
				End Using
			End Using
			Return Results
		End Function
		'Select By ID One Record Filtered Overloaded GetByID
		<DataObjectMethod(DataObjectMethodType.Select)> _
		Public Shared Function SelectList(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal orderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.ADM.admCallStatus)
			Dim Results As List(Of SIS.ADM.admCallStatus) = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spadmCallStatusSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spadmCallStatusSelectListFilteres"
					End If
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@startRowIndex", SqlDbType.Int, -1, startRowIndex)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@maximumRows", SqlDbType.Int, -1, maximumRows)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
					Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
					Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
					_RecordCount = -1
					Results = New List(Of SIS.ADM.admCallStatus)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results.Add(New SIS.ADM.admCallStatus(Reader))
					End While
					Reader.Close()
					_RecordCount = Cmd.Parameters("@RecordCount").Value
				End Using
			End Using
			Return Results
		End Function
		<DataObjectMethod(DataObjectMethodType.Insert, True)> _
		Public Shared Function Insert(ByVal Record As SIS.ADM.admCallStatus) As String
			Dim _Result As String = Record.CallStatusID
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spadmCallStatusInsert"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CallStatusID", SqlDbType.NVarChar, 21, Record.CallStatusID)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description", SqlDbType.NVarChar, 31, Record.Description)
					Cmd.Parameters.Add("@Return_CallStatusID", SqlDbType.NVarChar, 20)
					Cmd.Parameters("@Return_CallStatusID").Direction = ParameterDirection.Output
					Con.Open()
					Cmd.ExecuteNonQuery()
					_Result = Cmd.Parameters("@Return_CallStatusID").Value
				End Using
			End Using
			Return _Result
		End Function
		<DataObjectMethod(DataObjectMethodType.Update, True)> _
		Public Shared Function Update(ByVal Record As SIS.ADM.admCallStatus) As Int32
			Dim _Result As Integer = 0
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spadmCallStatusUpdate"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_CallStatusID", SqlDbType.NVarChar, 21, Record.CallStatusID)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description", SqlDbType.NVarChar, 31, Record.Description)
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
		Public Shared Function Delete(ByVal Record As SIS.ADM.admCallStatus) As Int32
			Dim _Result As Integer = 0
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spadmCallStatusDelete"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_CallStatusID", SqlDbType.NVarChar, Record.CallStatusID.ToString.Length, Record.CallStatusID)
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
		Public Shared Function SelectadmCallStatusAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
			Dim Results As List(Of String) = Nothing
			Dim aVal() As String = contextKey.Split("|".ToCharArray)
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spadmCallStatusAutoCompleteList"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, IIf(Prefix.ToLower = Prefix, 0, 1)))
					Results = New List(Of String)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Not Reader.HasRows Then
						Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(30, " "), ""))
					End If
					While (Reader.Read())
						Dim Tmp As SIS.ADM.admCallStatus = New SIS.ADM.admCallStatus(Reader)
						Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(Tmp.DisplayField, Tmp.PrimaryKey))
					End While
					Reader.Close()
				End Using
			End Using
			Return Results.ToArray
		End Function
		Public Sub New(ByVal Reader As SqlDataReader)
			On Error Resume Next
			_CallStatusID = CType(Reader("CallStatusID"), String)
			_Description = CType(Reader("Description"), String)
		End Sub
		Public Sub New(ByVal AliasName As String, ByVal Reader As SqlDataReader)
			On Error Resume Next
			_CallStatusID = CType(Reader(AliasName & "_CallStatusID"), String)
			_Description = CType(Reader(AliasName & "_Description"), String)
		End Sub
		Public Sub New()
		End Sub
	End Class
End Namespace
