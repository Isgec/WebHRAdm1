Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ADM
  <DataObject()> _
  Partial Public Class admEmployeeEMailGroup
    Private Shared _RecordCount As Integer
    Private _CardNo As String = ""
    Private _EMailGroup As String = ""
    Private _FK_HRM_EmployeeEMailGroup_HRM_EMailGroups As SIS.ADM.admEMailGroups = Nothing
    Private _FK_HRM_EmployeeEMailGroup_HRM_Employees As SIS.ADM.admEmployees = Nothing
    Public Property CardNo() As String
      Get
        Return _CardNo
      End Get
      Set(ByVal value As String)
        _CardNo = value
      End Set
    End Property
    Public Property EMailGroup() As String
      Get
        Return _EMailGroup
      End Get
      Set(ByVal value As String)
        _EMailGroup = value
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
        Return _CardNo & "|" & _EMailGroup
      End Get
      Set(ByVal value As String)
      End Set
    End Property
    Public ReadOnly Property FK_HRM_EmployeeEMailGroup_HRM_EMailGroups() As SIS.ADM.admEMailGroups
      Get
        If _FK_HRM_EmployeeEMailGroup_HRM_EMailGroups Is Nothing Then
          _FK_HRM_EmployeeEMailGroup_HRM_EMailGroups = SIS.ADM.admEMailGroups.GetByID(_EMailGroup)
        End If
        Return _FK_HRM_EmployeeEMailGroup_HRM_EMailGroups
      End Get
    End Property
    Public ReadOnly Property FK_HRM_EmployeeEMailGroup_HRM_Employees() As SIS.ADM.admEmployees
      Get
        If _FK_HRM_EmployeeEMailGroup_HRM_Employees Is Nothing Then
          _FK_HRM_EmployeeEMailGroup_HRM_Employees = SIS.ADM.admEmployees.GetByID(_CardNo)
        End If
        Return _FK_HRM_EmployeeEMailGroup_HRM_Employees
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetNewRecord() As SIS.ADM.admEmployeeEMailGroup
      Dim Results As SIS.ADM.admEmployeeEMailGroup = Nothing
      Results = New SIS.ADM.admEmployeeEMailGroup()
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByID(ByVal CardNo As String, ByVal EMailGroup As String) As SIS.ADM.admEmployeeEMailGroup
      Dim Results As SIS.ADM.admEmployeeEMailGroup = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmEmployeeEMailGroupSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo",SqlDbType.NVarChar,CardNo.ToString.Length, CardNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EMailGroup",SqlDbType.NVarChar,EMailGroup.ToString.Length, EMailGroup)
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ADM.admEmployeeEMailGroup(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
		<DataObjectMethod(DataObjectMethodType.Select)> _
		Public Shared Function GetByEMailGroup(ByVal EMailGroup As String, ByVal OrderBy As String) As List(Of SIS.ADM.admEmployeeEMailGroup)
			Dim Results As List(Of SIS.ADM.admEmployeeEMailGroup) = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spadmEmployeeEMailGroupSelectByEMailGroup"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EMailGroup", SqlDbType.NVarChar, EMailGroup.ToString.Length, EMailGroup)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
					Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
					Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
					_RecordCount = -1
					Results = New List(Of SIS.ADM.admEmployeeEMailGroup)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results.Add(New SIS.ADM.admEmployeeEMailGroup(Reader))
					End While
					Reader.Close()
					_RecordCount = Cmd.Parameters("@RecordCount").Value
				End Using
			End Using
			Return Results
		End Function
		'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function SelectList(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal orderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.ADM.admEmployeeEMailGroup)
      Dim Results As List(Of SIS.ADM.admEmployeeEMailGroup) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spadmEmployeeEMailGroupSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spadmEmployeeEMailGroupSelectListFilteres"
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@startRowIndex", SqlDbType.Int, -1, startRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@maximumRows", SqlDbType.Int, -1, maximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ADM.admEmployeeEMailGroup)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ADM.admEmployeeEMailGroup(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function Insert(ByVal Record As SIS.ADM.admEmployeeEMailGroup) As String
      Dim _Result As String = Record.CardNo
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmEmployeeEMailGroupInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo",SqlDbType.NVarChar,9, Record.CardNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EMailGroup",SqlDbType.NVarChar,51, Record.EMailGroup)
          Cmd.Parameters.Add("@Return_CardNo", SqlDbType.NVarChar, 8)
          Cmd.Parameters("@Return_CardNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          _Result = Cmd.Parameters("@Return_CardNo").Value
        End Using
      End Using
      Return _Result
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function Update(ByVal Record As SIS.ADM.admEmployeeEMailGroup) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmEmployeeEMailGroupUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_CardNo",SqlDbType.NVarChar,9, Record.CardNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_EMailGroup",SqlDbType.NVarChar,51, Record.EMailGroup)
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
    Public Shared Function Delete(ByVal Record As SIS.ADM.admEmployeeEMailGroup) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmEmployeeEMailGroupDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_CardNo",SqlDbType.NVarChar,Record.CardNo.ToString.Length, Record.CardNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_EMailGroup",SqlDbType.NVarChar,Record.EMailGroup.ToString.Length, Record.EMailGroup)
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
		Public Shared Function SelectadmEmployeeEMailGroupAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
			Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spadmEmployeeEMailGroupAutoCompleteList"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix),0,IIf(Prefix.ToLower=Prefix, 0, 1)))
					Results = New List(Of String)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Not Reader.HasRows Then
					  Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---","" & "|" & ""))
					End If
					While (Reader.Read())
            Dim Tmp As SIS.ADM.admEmployeeEMailGroup = New SIS.ADM.admEmployeeEMailGroup(Reader)
					  Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(Tmp.DisplayField, Tmp.PrimaryKey))
					End While
					Reader.Close()
				End Using
			End Using
			Return Results.ToArray
		End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      On Error Resume Next
      _CardNo = Ctype(Reader("CardNo"),String)
      _EMailGroup = Ctype(Reader("EMailGroup"),String)
      _FK_HRM_EmployeeEMailGroup_HRM_EMailGroups = New SIS.ADM.admEMailGroups("HRM_EMailGroups1",Reader)
      _FK_HRM_EmployeeEMailGroup_HRM_Employees = New SIS.ADM.admEmployees("HRM_Employees2",Reader)
    End Sub
    Public Sub New(ByVal AliasName As String, ByVal Reader As SqlDataReader)
      On Error Resume Next
      _CardNo = Ctype(Reader(AliasName & "_CardNo"),String)
      _EMailGroup = Ctype(Reader(AliasName & "_EMailGroup"),String)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
