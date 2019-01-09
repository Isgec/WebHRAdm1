Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ADM
  <DataObject()> _
  Partial Public Class admMonitors
    Private Shared _RecordCount As Integer
    Private _ServiceID As String = ""
    Private _MonitorID As String = ""
    Private _FK_ADM_Monitors_ADM_Services As SIS.ADM.admServices = Nothing
    Private _FK_ADM_Monitors_HRM_Employees As SIS.ADM.admEmployees = Nothing
    Public Property ServiceID() As String
      Get
        Return _ServiceID
      End Get
      Set(ByVal value As String)
        _ServiceID = value
      End Set
    End Property
    Public Property MonitorID() As String
      Get
        Return _MonitorID
      End Get
      Set(ByVal value As String)
        _MonitorID = value
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
        Return _ServiceID & "|" & _MonitorID
      End Get
      Set(ByVal value As String)
      End Set
    End Property
    Public ReadOnly Property FK_ADM_Monitors_ADM_Services() As SIS.ADM.admServices
      Get
        If _FK_ADM_Monitors_ADM_Services Is Nothing Then
          _FK_ADM_Monitors_ADM_Services = SIS.ADM.admServices.GetByID(_ServiceID)
        End If
        Return _FK_ADM_Monitors_ADM_Services
      End Get
    End Property
    Public ReadOnly Property FK_ADM_Monitors_HRM_Employees() As SIS.ADM.admEmployees
      Get
        If _FK_ADM_Monitors_HRM_Employees Is Nothing Then
          _FK_ADM_Monitors_HRM_Employees = SIS.ADM.admEmployees.GetByID(_MonitorID)
        End If
        Return _FK_ADM_Monitors_HRM_Employees
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetNewRecord() As SIS.ADM.admMonitors
      Dim Results As SIS.ADM.admMonitors = Nothing
      Results = New SIS.ADM.admMonitors()
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByID(ByVal ServiceID As String, ByVal MonitorID As String) As SIS.ADM.admMonitors
      Dim Results As SIS.ADM.admMonitors = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmMonitorsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ServiceID",SqlDbType.NVarChar,ServiceID.ToString.Length, ServiceID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MonitorID",SqlDbType.NVarChar,MonitorID.ToString.Length, MonitorID)
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ADM.admMonitors(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByServiceID(ByVal ServiceID As String, ByVal OrderBy as String) As List(Of SIS.ADM.admMonitors)
      Dim Results As List(Of SIS.ADM.admMonitors) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmMonitorsSelectByServiceID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ServiceID",SqlDbType.NVarChar,ServiceID.ToString.Length, ServiceID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ADM.admMonitors)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ADM.admMonitors(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function SelectList(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal orderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.ADM.admMonitors)
      Dim Results As List(Of SIS.ADM.admMonitors) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spadmMonitorsSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spadmMonitorsSelectListFilteres"
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@startRowIndex", SqlDbType.Int, -1, startRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@maximumRows", SqlDbType.Int, -1, maximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ADM.admMonitors)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ADM.admMonitors(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function Insert(ByVal Record As SIS.ADM.admMonitors) As String
      Dim _Result As String = Record.ServiceID
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmMonitorsInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ServiceID",SqlDbType.NVarChar,11, Record.ServiceID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MonitorID",SqlDbType.NVarChar,9, Record.MonitorID)
          Cmd.Parameters.Add("@Return_ServiceID", SqlDbType.NVarChar, 10)
          Cmd.Parameters("@Return_ServiceID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          _Result = Cmd.Parameters("@Return_ServiceID").Value
        End Using
      End Using
      Return _Result
    End Function
    <DataObjectMethod(DataObjectMethodType.Delete, True)> _
    Public Shared Function Delete(ByVal Record As SIS.ADM.admMonitors) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmMonitorsDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ServiceID",SqlDbType.NVarChar,Record.ServiceID.ToString.Length, Record.ServiceID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_MonitorID",SqlDbType.NVarChar,Record.MonitorID.ToString.Length, Record.MonitorID)
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
		Public Shared Function SelectadmMonitorsAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
			Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spadmMonitorsAutoCompleteList"
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
            Dim Tmp As SIS.ADM.admMonitors = New SIS.ADM.admMonitors(Reader)
					  Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(Tmp.DisplayField, Tmp.PrimaryKey))
					End While
					Reader.Close()
				End Using
			End Using
			Return Results.ToArray
		End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      On Error Resume Next
      _ServiceID = Ctype(Reader("ServiceID"),String)
      _MonitorID = Ctype(Reader("MonitorID"),String)
      _FK_ADM_Monitors_ADM_Services = New SIS.ADM.admServices("ADM_Services1",Reader)
      _FK_ADM_Monitors_HRM_Employees = New SIS.ADM.admEmployees("HRM_Employees2",Reader)
    End Sub
    Public Sub New(ByVal AliasName As String, ByVal Reader As SqlDataReader)
      On Error Resume Next
      _ServiceID = Ctype(Reader(AliasName & "_ServiceID"),String)
      _MonitorID = Ctype(Reader(AliasName & "_MonitorID"),String)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
