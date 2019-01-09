Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.SYS
  <DataObject()> _
  Partial Public Class VRUsers
    Private Shared _RecordCount As Integer
    Private _UserName As String
		Private _UserFullName As String
		Private _NewPassword As String = String.Empty
		Private _C_DateOfJoining As String = ""
		Private _C_CompanyID As String = ""
		Private _C_DivisionID As String = ""
		Private _C_OfficeID As String = ""
		Private _C_DepartmentID As String = ""
		Private _C_ProjectSiteID As String = ""
		Private _C_DesignationID As String = ""
		Private _ActiveState As Boolean = False
		Public Property C_DateOfJoining() As String
			Get
				If Not _C_DateOfJoining = String.Empty Then
					Return Convert.ToDateTime(_C_DateOfJoining).ToString("dd/MM/yyyy")
				End If
				Return _C_DateOfJoining
			End Get
			Set(ByVal value As String)
				If Convert.IsDBNull(value) Then
					_C_DateOfJoining = ""
				Else
					_C_DateOfJoining = value
				End If
			End Set
		End Property
		Public Property C_CompanyID() As String
			Get
				Return _C_CompanyID
			End Get
			Set(ByVal value As String)
				If Convert.IsDBNull(Value) Then
					_C_CompanyID = ""
				Else
					_C_CompanyID = value
				End If
			End Set
		End Property
		Public Property C_DivisionID() As String
			Get
				Return _C_DivisionID
			End Get
			Set(ByVal value As String)
				If Convert.IsDBNull(Value) Then
					_C_DivisionID = ""
				Else
					_C_DivisionID = value
				End If
			End Set
		End Property
		Public Property C_OfficeID() As String
			Get
				Return _C_OfficeID
			End Get
			Set(ByVal value As String)
				If Convert.IsDBNull(Value) Then
					_C_OfficeID = ""
				Else
					_C_OfficeID = value
				End If
			End Set
		End Property
		Public Property C_DepartmentID() As String
			Get
				Return _C_DepartmentID
			End Get
			Set(ByVal value As String)
				If Convert.IsDBNull(Value) Then
					_C_DepartmentID = ""
				Else
					_C_DepartmentID = value
				End If
			End Set
		End Property
		Public Property C_ProjectSiteID() As String
			Get
				Return _C_ProjectSiteID
			End Get
			Set(ByVal value As String)
				If Convert.IsDBNull(Value) Then
					_C_ProjectSiteID = ""
				Else
					_C_ProjectSiteID = value
				End If
			End Set
		End Property
		Public Property C_DesignationID() As String
			Get
				Return _C_DesignationID
			End Get
			Set(ByVal value As String)
				If Convert.IsDBNull(value) Then
					_C_DesignationID = ""
				Else
					_C_DesignationID = value
				End If
			End Set
		End Property
		Public Property ActiveState() As Boolean
			Get
				Return _ActiveState
			End Get
			Set(ByVal value As Boolean)
				_ActiveState = value
			End Set
		End Property
		Public Property NewPassword() As String
			Get
				Return _NewPassword
			End Get
			Set(ByVal value As String)
				_NewPassword = value
			End Set
		End Property
    Public Property UserName() As String
      Get
        Return _UserName
      End Get
      Set(ByVal value As String)
        _UserName = value
      End Set
    End Property
    Public Property UserFullName() As String
      Get
        Return _UserFullName
      End Get
      Set(ByVal value As String)
        _UserFullName = value
      End Set
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function SelectList(ByVal orderBy As String) As List(Of SIS.SYS.VRUsers)
      Dim Results As List(Of SIS.SYS.VRUsers) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spVRUsersSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.SYS.VRUsers)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.SYS.VRUsers(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByID(ByVal UserName As String) As SIS.SYS.VRUsers
      Dim Results As SIS.SYS.VRUsers = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spVRUsersSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserName",SqlDbType.NVarChar,UserName.ToString.Length, UserName)
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.SYS.VRUsers(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function SelectList(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal orderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.SYS.VRUsers)
      Dim Results As List(Of SIS.SYS.VRUsers) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spVRUsersSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spVRUsersSelectListFilteres"
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@startRowIndex", SqlDbType.Int, -1, startRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@maximumRows", SqlDbType.Int, -1, maximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.SYS.VRUsers)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.SYS.VRUsers(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function Insert(ByVal Record As SIS.SYS.VRUsers) As String
      Dim _Result As String = Record.UserName
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spVRUsersInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserName",SqlDbType.NVarChar,21, Record.UserName)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserFullName",SqlDbType.NVarChar,51, Record.UserFullName)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_DateOfJoining", SqlDbType.DateTime, 21, IIf(Record.C_DateOfJoining = "", Convert.DBNull, Record.C_DateOfJoining))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_CompanyID", SqlDbType.NVarChar, 7, IIf(Record.C_CompanyID = "", Convert.DBNull, Record.C_CompanyID))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_DivisionID", SqlDbType.NVarChar, 7, IIf(Record.C_DivisionID = "", Convert.DBNull, Record.C_DivisionID))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_OfficeID", SqlDbType.Int, 11, IIf(Record.C_OfficeID = "", Convert.DBNull, Record.C_OfficeID))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_DepartmentID", SqlDbType.NVarChar, 7, IIf(Record.C_DepartmentID = "", Convert.DBNull, Record.C_DepartmentID))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_ProjectSiteID", SqlDbType.NVarChar, 7, IIf(Record.C_ProjectSiteID = "", Convert.DBNull, Record.C_ProjectSiteID))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_DesignationID", SqlDbType.Int, 11, IIf(Record.C_DesignationID = "", Convert.DBNull, Record.C_DesignationID))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ActiveState", SqlDbType.Bit, 3, Record.ActiveState)
					Cmd.Parameters.Add("@Return_UserName", SqlDbType.NVarChar, 20)
          Cmd.Parameters("@Return_UserName").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          _Result = Cmd.Parameters("@Return_UserName").Value
        End Using
      End Using
      Return _Result
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function Update(ByVal Record As SIS.SYS.VRUsers) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spVRUsersUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_UserName",SqlDbType.NVarChar,21, Record.UserName)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserFullName",SqlDbType.NVarChar,51, Record.UserFullName)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_DateOfJoining", SqlDbType.DateTime, 21, IIf(Record.C_DateOfJoining = "", Convert.DBNull, Record.C_DateOfJoining))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_CompanyID", SqlDbType.NVarChar, 7, IIf(Record.C_CompanyID = "", Convert.DBNull, Record.C_CompanyID))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_DivisionID", SqlDbType.NVarChar, 7, IIf(Record.C_DivisionID = "", Convert.DBNull, Record.C_DivisionID))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_OfficeID", SqlDbType.Int, 11, IIf(Record.C_OfficeID = "", Convert.DBNull, Record.C_OfficeID))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_DepartmentID", SqlDbType.NVarChar, 7, IIf(Record.C_DepartmentID = "", Convert.DBNull, Record.C_DepartmentID))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_ProjectSiteID", SqlDbType.NVarChar, 7, IIf(Record.C_ProjectSiteID = "", Convert.DBNull, Record.C_ProjectSiteID))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_DesignationID", SqlDbType.Int, 11, IIf(Record.C_DesignationID = "", Convert.DBNull, Record.C_DesignationID))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ActiveState", SqlDbType.Bit, 3, Record.ActiveState)
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
    Public Shared Function Delete(ByVal Record As SIS.SYS.VRUsers) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spVRUsersDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_UserName",SqlDbType.NVarChar,Record.UserName.ToString.Length, Record.UserName)
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
		Public Shared Function SelectVRUsersAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, Optional ByVal ContextKey As String = "") As String()
			Dim Results As List(Of String) = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spVRUsersAutoCompleteList"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, IIf(Prefix.ToLower = Prefix, 0, 1)))
					Results = New List(Of String)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---", ""))
					While (Reader.Read())
						Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(Reader(0), Reader(1)))
					End While
					Reader.Close()
				End Using
			End Using
			Return Results.ToArray
		End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      On Error Resume Next
      _UserName = Ctype(Reader("UserName"),String)
      _UserFullName = Ctype(Reader("UserFullName"),String)
			If Convert.IsDBNull(Reader("C_DateOfJoining")) Then
				_C_DateOfJoining = String.Empty
			Else
				_C_DateOfJoining = CType(Reader("C_DateOfJoining"), String)
			End If
			If Convert.IsDBNull(Reader("C_CompanyID")) Then
				_C_CompanyID = String.Empty
			Else
				_C_CompanyID = CType(Reader("C_CompanyID"), String)
			End If
			If Convert.IsDBNull(Reader("C_DivisionID")) Then
				_C_DivisionID = String.Empty
			Else
				_C_DivisionID = CType(Reader("C_DivisionID"), String)
			End If
			If Convert.IsDBNull(Reader("C_OfficeID")) Then
				_C_OfficeID = String.Empty
			Else
				_C_OfficeID = CType(Reader("C_OfficeID"), String)
			End If
			If Convert.IsDBNull(Reader("C_DepartmentID")) Then
				_C_DepartmentID = String.Empty
			Else
				_C_DepartmentID = CType(Reader("C_DepartmentID"), String)
			End If
			If Convert.IsDBNull(Reader("C_ProjectSiteID")) Then
				_C_ProjectSiteID = String.Empty
			Else
				_C_ProjectSiteID = CType(Reader("C_ProjectSiteID"), String)
			End If
			If Convert.IsDBNull(Reader("C_DesignationID")) Then
				_C_DesignationID = String.Empty
			Else
				_C_DesignationID = CType(Reader("C_DesignationID"), String)
			End If
			_ActiveState = CType(Reader("ActiveState"), Boolean)
		End Sub
    Public Sub New(ByVal AliasName As String, ByVal Reader As SqlDataReader)
      On Error Resume Next
      _UserName = Ctype(Reader(AliasName & "_UserName"),String)
      _UserFullName = Ctype(Reader(AliasName & "_UserFullName"),String)
			If Convert.IsDBNull(Reader(AliasName & "C_DateOfJoining")) Then
				_C_DateOfJoining = String.Empty
			Else
				_C_DateOfJoining = CType(Reader(AliasName & "C_DateOfJoining"), String)
			End If
			If Convert.IsDBNull(Reader(AliasName & "C_CompanyID")) Then
				_C_CompanyID = String.Empty
			Else
				_C_CompanyID = CType(Reader(AliasName & "C_CompanyID"), String)
			End If
			If Convert.IsDBNull(Reader(AliasName & "C_DivisionID")) Then
				_C_DivisionID = String.Empty
			Else
				_C_DivisionID = CType(Reader(AliasName & "C_DivisionID"), String)
			End If
			If Convert.IsDBNull(Reader(AliasName & "C_OfficeID")) Then
				_C_OfficeID = String.Empty
			Else
				_C_OfficeID = CType(Reader(AliasName & "C_OfficeID"), String)
			End If
			If Convert.IsDBNull(Reader(AliasName & "C_DepartmentID")) Then
				_C_DepartmentID = String.Empty
			Else
				_C_DepartmentID = CType(Reader(AliasName & "C_DepartmentID"), String)
			End If
			If Convert.IsDBNull(Reader(AliasName & "C_ProjectSiteID")) Then
				_C_ProjectSiteID = String.Empty
			Else
				_C_ProjectSiteID = CType(Reader(AliasName & "C_ProjectSiteID"), String)
			End If
			If Convert.IsDBNull(Reader(AliasName & "C_DesignationID")) Then
				_C_DesignationID = String.Empty
			Else
				_C_DesignationID = CType(Reader(AliasName & "C_DesignationID"), String)
			End If
			_ActiveState = CType(Reader(AliasName & "ActiveState"), Boolean)
		End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
