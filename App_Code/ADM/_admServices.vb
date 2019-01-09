Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ADM
  <DataObject()> _
  Partial Public Class admServices
    Private Shared _RecordCount As Integer
    Private _ServiceID As String = ""
    Private _Description As String = ""
    Private _OfficeID As String = ""
    Private _ScheduleID As String = ""
    Private _LastSheetDate As String = ""
    Private _FK_ADM_Services_HRM_Offices As SIS.ADM.admOffices = Nothing
    Private _FK_ADM_Services_ADM_Schedules As SIS.ADM.admSchedules = Nothing
    Public Property ServiceID() As String
      Get
        Return _ServiceID
      End Get
      Set(ByVal value As String)
        _ServiceID = value
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
    Public Property OfficeID() As String
      Get
        Return _OfficeID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _OfficeID = ""
				 Else
					 _OfficeID = value
			   End If
      End Set
    End Property
    Public Property ScheduleID() As String
      Get
        Return _ScheduleID
      End Get
      Set(ByVal value As String)
        _ScheduleID = value
      End Set
    End Property
    Public Property LastSheetDate() As String
      Get
        If Not _LastSheetDate = String.Empty Then
          Return Convert.ToDateTime(_LastSheetDate).ToString("dd/MM/yyyy")
        End If
        Return _LastSheetDate
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _LastSheetDate = ""
				 Else
					 _LastSheetDate = value
			   End If
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
        Return _ServiceID
      End Get
      Set(ByVal value As String)
      End Set
    End Property
    Public ReadOnly Property FK_ADM_Services_HRM_Offices() As SIS.ADM.admOffices
      Get
        If _FK_ADM_Services_HRM_Offices Is Nothing Then
          _FK_ADM_Services_HRM_Offices = SIS.ADM.admOffices.GetByID(_OfficeID)
        End If
        Return _FK_ADM_Services_HRM_Offices
      End Get
    End Property
    Public ReadOnly Property FK_ADM_Services_ADM_Schedules() As SIS.ADM.admSchedules
      Get
        If _FK_ADM_Services_ADM_Schedules Is Nothing Then
          _FK_ADM_Services_ADM_Schedules = SIS.ADM.admSchedules.GetByID(_ScheduleID)
        End If
        Return _FK_ADM_Services_ADM_Schedules
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function SelectList(ByVal orderBy As String) As List(Of SIS.ADM.admServices)
      Dim Results As List(Of SIS.ADM.admServices) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmServicesSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ADM.admServices)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ADM.admServices(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetNewRecord() As SIS.ADM.admServices
      Dim Results As SIS.ADM.admServices = Nothing
      Results = New SIS.ADM.admServices()
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByID(ByVal ServiceID As String) As SIS.ADM.admServices
      Dim Results As SIS.ADM.admServices = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmServicesSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ServiceID",SqlDbType.NVarChar,ServiceID.ToString.Length, ServiceID)
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ADM.admServices(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function SelectList(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal orderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.ADM.admServices)
      Dim Results As List(Of SIS.ADM.admServices) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spadmServicesSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spadmServicesSelectListFilteres"
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@startRowIndex", SqlDbType.Int, -1, startRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@maximumRows", SqlDbType.Int, -1, maximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ADM.admServices)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ADM.admServices(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function Insert(ByVal Record As SIS.ADM.admServices) As String
      Dim _Result As String = Record.ServiceID
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmServicesInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ServiceID",SqlDbType.NVarChar,11, Record.ServiceID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,31, Record.Description)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OfficeID",SqlDbType.Int,11, Iif(Record.OfficeID= "" ,Convert.DBNull, Record.OfficeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ScheduleID",SqlDbType.NVarChar,21, Record.ScheduleID)
          Cmd.Parameters.Add("@Return_ServiceID", SqlDbType.NVarChar, 10)
          Cmd.Parameters("@Return_ServiceID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          _Result = Cmd.Parameters("@Return_ServiceID").Value
        End Using
      End Using
      Return _Result
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function Update(ByVal Record As SIS.ADM.admServices) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmServicesUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ServiceID",SqlDbType.NVarChar,11, Record.ServiceID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,31, Record.Description)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OfficeID",SqlDbType.Int,11, Iif(Record.OfficeID= "" ,Convert.DBNull, Record.OfficeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ScheduleID",SqlDbType.NVarChar,21, Record.ScheduleID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LastSheetDate",SqlDbType.DateTime,21, Iif(Record.LastSheetDate= "" ,Convert.DBNull, Record.LastSheetDate))
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
    Public Shared Function Delete(ByVal Record As SIS.ADM.admServices) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmServicesDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ServiceID",SqlDbType.NVarChar,Record.ServiceID.ToString.Length, Record.ServiceID)
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
		Public Shared Function SelectadmServicesAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
			Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spadmServicesAutoCompleteList"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix),0,IIf(Prefix.ToLower=Prefix, 0, 1)))
					Results = New List(Of String)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Not Reader.HasRows Then
					  Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(30, " "),""))
					End If
					While (Reader.Read())
            Dim Tmp As SIS.ADM.admServices = New SIS.ADM.admServices(Reader)
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
      _Description = Ctype(Reader("Description"),String)
      If Convert.IsDBNull(Reader("OfficeID")) Then
        _OfficeID = String.Empty
      Else
        _OfficeID = Ctype(Reader("OfficeID"), String)
      End If
      _ScheduleID = Ctype(Reader("ScheduleID"),String)
      If Convert.IsDBNull(Reader("LastSheetDate")) Then
        _LastSheetDate = String.Empty
      Else
        _LastSheetDate = Ctype(Reader("LastSheetDate"), String)
      End If
      _FK_ADM_Services_HRM_Offices = New SIS.ADM.admOffices("HRM_Offices1",Reader)
      _FK_ADM_Services_ADM_Schedules = New SIS.ADM.admSchedules("ADM_Schedules1",Reader)
    End Sub
    Public Sub New(ByVal AliasName As String, ByVal Reader As SqlDataReader)
      On Error Resume Next
      _ServiceID = Ctype(Reader(AliasName & "_ServiceID"),String)
      _Description = Ctype(Reader(AliasName & "_Description"),String)
      If Convert.IsDBNull(Reader(AliasName & "_OfficeID")) Then
        _OfficeID = String.Empty
      Else
        _OfficeID = Ctype(Reader(AliasName & "_OfficeID"), String)
      End If
      _ScheduleID = Ctype(Reader(AliasName & "_ScheduleID"),String)
      If Convert.IsDBNull(Reader(AliasName & "_LastSheetDate")) Then
        _LastSheetDate = String.Empty
      Else
        _LastSheetDate = Ctype(Reader(AliasName & "_LastSheetDate"), String)
      End If
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
