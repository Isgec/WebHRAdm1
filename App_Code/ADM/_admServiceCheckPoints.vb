Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ADM
  <DataObject()> _
  Partial Public Class admServiceCheckPoints
    Private Shared _RecordCount As Integer
    Private _ServiceID As String = ""
    Private _CheckPointID As Int32 = 0
    Private _FK_ADM_ServiceCheckPoints_ADM_CheckPoints As SIS.ADM.admCheckPoints = Nothing
    Private _FK_ADM_ServiceCheckPoints_ADM_Services As SIS.ADM.admServices = Nothing
    Public Property ServiceID() As String
      Get
        Return _ServiceID
      End Get
      Set(ByVal value As String)
        _ServiceID = value
      End Set
    End Property
    Public Property CheckPointID() As Int32
      Get
        Return _CheckPointID
      End Get
      Set(ByVal value As Int32)
        _CheckPointID = value
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
        Return _ServiceID & "|" & _CheckPointID
      End Get
      Set(ByVal value As String)
      End Set
    End Property
    Public ReadOnly Property FK_ADM_ServiceCheckPoints_ADM_CheckPoints() As SIS.ADM.admCheckPoints
      Get
        If _FK_ADM_ServiceCheckPoints_ADM_CheckPoints Is Nothing Then
          _FK_ADM_ServiceCheckPoints_ADM_CheckPoints = SIS.ADM.admCheckPoints.GetByID(_CheckPointID)
        End If
        Return _FK_ADM_ServiceCheckPoints_ADM_CheckPoints
      End Get
    End Property
    Public ReadOnly Property FK_ADM_ServiceCheckPoints_ADM_Services() As SIS.ADM.admServices
      Get
        If _FK_ADM_ServiceCheckPoints_ADM_Services Is Nothing Then
          _FK_ADM_ServiceCheckPoints_ADM_Services = SIS.ADM.admServices.GetByID(_ServiceID)
        End If
        Return _FK_ADM_ServiceCheckPoints_ADM_Services
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetNewRecord() As SIS.ADM.admServiceCheckPoints
      Dim Results As SIS.ADM.admServiceCheckPoints = Nothing
      Results = New SIS.ADM.admServiceCheckPoints()
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByID(ByVal ServiceID As String, ByVal CheckPointID As Int32) As SIS.ADM.admServiceCheckPoints
      Dim Results As SIS.ADM.admServiceCheckPoints = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmServiceCheckPointsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ServiceID",SqlDbType.NVarChar,ServiceID.ToString.Length, ServiceID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CheckPointID",SqlDbType.Int,CheckPointID.ToString.Length, CheckPointID)
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ADM.admServiceCheckPoints(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByServiceID(ByVal ServiceID As String, ByVal OrderBy as String) As List(Of SIS.ADM.admServiceCheckPoints)
      Dim Results As List(Of SIS.ADM.admServiceCheckPoints) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmServiceCheckPointsSelectByServiceID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ServiceID",SqlDbType.NVarChar,ServiceID.ToString.Length, ServiceID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ADM.admServiceCheckPoints)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ADM.admServiceCheckPoints(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function SelectList(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal orderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.ADM.admServiceCheckPoints)
      Dim Results As List(Of SIS.ADM.admServiceCheckPoints) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spadmServiceCheckPointsSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spadmServiceCheckPointsSelectListFilteres"
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@startRowIndex", SqlDbType.Int, -1, startRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@maximumRows", SqlDbType.Int, -1, maximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ADM.admServiceCheckPoints)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ADM.admServiceCheckPoints(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function Insert(ByVal Record As SIS.ADM.admServiceCheckPoints) As String
      Dim _Result As String = Record.ServiceID
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmServiceCheckPointsInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ServiceID",SqlDbType.NVarChar,11, Record.ServiceID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CheckPointID",SqlDbType.Int,11, Record.CheckPointID)
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
    Public Shared Function Delete(ByVal Record As SIS.ADM.admServiceCheckPoints) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmServiceCheckPointsDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ServiceID",SqlDbType.NVarChar,Record.ServiceID.ToString.Length, Record.ServiceID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_CheckPointID",SqlDbType.Int,Record.CheckPointID.ToString.Length, Record.CheckPointID)
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
		Public Shared Function SelectadmServiceCheckPointsAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
			Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spadmServiceCheckPointsAutoCompleteList"
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
            Dim Tmp As SIS.ADM.admServiceCheckPoints = New SIS.ADM.admServiceCheckPoints(Reader)
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
      _CheckPointID = Ctype(Reader("CheckPointID"),Int32)
			_FK_ADM_ServiceCheckPoints_ADM_Services = New SIS.ADM.admServices("ADM_Services2", Reader)
    End Sub
    Public Sub New(ByVal AliasName As String, ByVal Reader As SqlDataReader)
      On Error Resume Next
      _ServiceID = Ctype(Reader(AliasName & "_ServiceID"),String)
      _CheckPointID = Ctype(Reader(AliasName & "_CheckPointID"),Int32)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
