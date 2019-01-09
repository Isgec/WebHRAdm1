Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ADM
  <DataObject()> _
  Partial Public Class admUsers
    Private Shared _RecordCount As Integer
    Private _UserName As String = ""
    Private _UserFullName As String = ""
    Private _LocationID As String = ""
    Private _ExtnNo As String = ""
    Private _MobileNo As String = ""
    Private _EMailID As String = ""
    Private _C_DateOfJoining As String = ""
    Private _C_CompanyID As String = ""
    Private _C_DivisionID As String = ""
    Private _C_OfficeID As String = ""
    Private _C_DepartmentID As String = ""
    Private _C_ProjectSiteID As String = ""
    Private _C_DesignationID As String = ""
    Private _ActiveState As String = ""
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
    Public Property LocationID() As String
      Get
        Return _LocationID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _LocationID = ""
				 Else
					 _LocationID = value
			   End If
      End Set
    End Property
    Public Property ExtnNo() As String
      Get
        Return _ExtnNo
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ExtnNo = ""
				 Else
					 _ExtnNo = value
			   End If
      End Set
    End Property
    Public Property MobileNo() As String
      Get
        Return _MobileNo
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _MobileNo = ""
				 Else
					 _MobileNo = value
			   End If
      End Set
    End Property
    Public Property EMailID() As String
      Get
        Return _EMailID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _EMailID = ""
				 Else
					 _EMailID = value
			   End If
      End Set
    End Property
    Public Property C_DateOfJoining() As String
      Get
        If Not _C_DateOfJoining = String.Empty Then
          Return Convert.ToDateTime(_C_DateOfJoining).ToString("dd/MM/yyyy")
        End If
        Return _C_DateOfJoining
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
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
				 If Convert.IsDBNull(Value) Then
					 _C_DesignationID = ""
				 Else
					 _C_DesignationID = value
			   End If
      End Set
    End Property
    Public Property ActiveState() As String
      Get
        Return _ActiveState
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ActiveState = ""
				 Else
					 _ActiveState = value
			   End If
      End Set
    End Property
    Public Property DisplayField() As String
      Get
        Return "" & _UserFullName.ToString.PadRight(50, " ")
      End Get
      Set(ByVal value As String)
      End Set
    End Property
    Public Property PrimaryKey() As String
			Get
				Return _UserName
			End Get
      Set(ByVal value As String)
      End Set
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function SelectList(ByVal orderBy As String) As List(Of SIS.ADM.admUsers)
      Dim Results As List(Of SIS.ADM.admUsers) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmUsersSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ADM.admUsers)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ADM.admUsers(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetNewRecord() As SIS.ADM.admUsers
      Dim Results As SIS.ADM.admUsers = Nothing
      Results = New SIS.ADM.admUsers()
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByID(ByVal UserName As String) As SIS.ADM.admUsers
      Dim Results As SIS.ADM.admUsers = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmUsersSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserName",SqlDbType.NVarChar,UserName.ToString.Length, UserName)
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ADM.admUsers(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function SelectList(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal orderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.ADM.admUsers)
      Dim Results As List(Of SIS.ADM.admUsers) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spadmUsersSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spadmUsersSelectListFilteres"
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@startRowIndex", SqlDbType.Int, -1, startRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@maximumRows", SqlDbType.Int, -1, maximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ADM.admUsers)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ADM.admUsers(Reader))
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
'		Autocomplete Method
		Public Shared Function SelectadmUsersAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
			Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spadmUsersAutoCompleteList"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix),0,IIf(Prefix.ToLower=Prefix, 0, 1)))
					Results = New List(Of String)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Not Reader.HasRows Then
					  Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(50, " "),""))
					End If
					While (Reader.Read())
            Dim Tmp As SIS.ADM.admUsers = New SIS.ADM.admUsers(Reader)
					  Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(Tmp.DisplayField, Tmp.PrimaryKey))
					End While
					Reader.Close()
				End Using
			End Using
			Return Results.ToArray
		End Function
		Public Shared Function SelectadmChennaiUsersAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
			Dim Results As List(Of String) = Nothing
			Dim aVal() As String = contextKey.Split("|".ToCharArray)
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spadm_LG_ChennaiUsersAutoCompleteList"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, IIf(Prefix.ToLower = Prefix, 0, 1)))
					Results = New List(Of String)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Not Reader.HasRows Then
						Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(50, " "), ""))
					End If
					While (Reader.Read())
						Dim Tmp As SIS.ADM.admUsers = New SIS.ADM.admUsers(Reader)
						Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(Tmp.DisplayField, Tmp.PrimaryKey))
					End While
					Reader.Close()
				End Using
			End Using
			Return Results.ToArray
		End Function
		Public Sub New(ByVal Reader As SqlDataReader)
			On Error Resume Next
			_UserName = CType(Reader("UserName"), String)
			_UserFullName = CType(Reader("UserFullName"), String)
			If Convert.IsDBNull(Reader("LocationID")) Then
				_LocationID = String.Empty
			Else
				_LocationID = CType(Reader("LocationID"), String)
			End If
			If Convert.IsDBNull(Reader("ExtnNo")) Then
				_ExtnNo = String.Empty
			Else
				_ExtnNo = CType(Reader("ExtnNo"), String)
			End If
			If Convert.IsDBNull(Reader("MobileNo")) Then
				_MobileNo = String.Empty
			Else
				_MobileNo = CType(Reader("MobileNo"), String)
			End If
			If Convert.IsDBNull(Reader("EMailID")) Then
				_EMailID = String.Empty
			Else
				_EMailID = CType(Reader("EMailID"), String)
			End If
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
			If Convert.IsDBNull(Reader("ActiveState")) Then
				_ActiveState = String.Empty
			Else
				_ActiveState = CType(Reader("ActiveState"), String)
			End If
		End Sub
    Public Sub New(ByVal AliasName As String, ByVal Reader As SqlDataReader)
      On Error Resume Next
      _UserName = Ctype(Reader(AliasName & "_UserName"),String)
      _UserFullName = Ctype(Reader(AliasName & "_UserFullName"),String)
      If Convert.IsDBNull(Reader(AliasName & "_LocationID")) Then
        _LocationID = String.Empty
      Else
        _LocationID = Ctype(Reader(AliasName & "_LocationID"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_ExtnNo")) Then
        _ExtnNo = String.Empty
      Else
        _ExtnNo = Ctype(Reader(AliasName & "_ExtnNo"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_MobileNo")) Then
        _MobileNo = String.Empty
      Else
        _MobileNo = Ctype(Reader(AliasName & "_MobileNo"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_EMailID")) Then
        _EMailID = String.Empty
      Else
        _EMailID = Ctype(Reader(AliasName & "_EMailID"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_C_OfficeID")) Then
        _C_OfficeID = String.Empty
      Else
        _C_OfficeID = Ctype(Reader(AliasName & "_C_OfficeID"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_C_DepartmentID")) Then
        _C_DepartmentID = String.Empty
      Else
        _C_DepartmentID = Ctype(Reader(AliasName & "_C_DepartmentID"), String)
      End If
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
