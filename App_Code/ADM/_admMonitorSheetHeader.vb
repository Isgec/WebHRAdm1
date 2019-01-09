Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ADM
  <DataObject()> _
  Partial Public Class admMonitorSheetHeader
    Private Shared _RecordCount As Integer
    Private _SheetID As Int32 = 0
    Private _SheetDate As String = ""
    Private _ServiceID As String = ""
    Private _ScheduleID As String = ""
    Private _Description As String = ""
    Private _Initiated As Boolean = False
    Private _Monitored As Boolean = False
    Private _ProblemIdentified As Boolean = False
    Private _Closed As Boolean = False
    Private _FK_ADM_ServiceSheetHeader_ADM_Schedules As SIS.ADM.admSchedules = Nothing
		Private _FK_ADM_ServiceSheetHeader_ADM_Services As SIS.ADM.admServices = Nothing
		Public ReadOnly Property Forecolor() As System.Drawing.Color
			Get
				Dim cl As System.Drawing.Color = Drawing.Color.Green

				'Dim oShtDets As List(Of SIS.ADM.admMonitorSheetDetails) = SIS.ADM.admMonitorSheetDetails.SelectList(0, 999, _SheetID, "", False, "")
				'Dim ProblemIdentified As Boolean = False
				'Dim Incomplete As Boolean = False
				'For Each oShtDet As SIS.ADM.admMonitorSheetDetails In oShtDets
				'	With oShtDet
				'		If .ProblemIdentified Then
				'			ProblemIdentified = True
				'		End If
				'		If Not .Initiated And Not .Monitored Then
				'			Incomplete = True
				'		End If
				'	End With
				'Next
				If _ProblemIdentified Then
					cl = Drawing.Color.Red
					If _Closed Then
						cl = Drawing.Color.Purple
					End If
				ElseIf Not _Initiated And Not _Monitored Then
					cl = Drawing.Color.Goldenrod
				End If
				Return cl
			End Get
		End Property
    Public Property SheetID() As Int32
      Get
        Return _SheetID
      End Get
      Set(ByVal value As Int32)
        _SheetID = value
      End Set
    End Property
    Public Property SheetDate() As String
      Get
        If Not _SheetDate = String.Empty Then
          Return Convert.ToDateTime(_SheetDate).ToString("dd/MM/yyyy")
        End If
        Return _SheetDate
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _SheetDate = ""
				 Else
					 _SheetDate = value
			   End If
      End Set
    End Property
    Public Property ServiceID() As String
      Get
        Return _ServiceID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ServiceID = ""
				 Else
					 _ServiceID = value
			   End If
      End Set
    End Property
    Public Property ScheduleID() As String
      Get
        Return _ScheduleID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ScheduleID = ""
				 Else
					 _ScheduleID = value
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
    Public Property Initiated() As Boolean
      Get
        Return _Initiated
      End Get
      Set(ByVal value As Boolean)
        _Initiated = value
      End Set
    End Property
    Public Property Monitored() As Boolean
      Get
        Return _Monitored
      End Get
      Set(ByVal value As Boolean)
        _Monitored = value
      End Set
    End Property
    Public Property ProblemIdentified() As Boolean
      Get
        Return _ProblemIdentified
      End Get
      Set(ByVal value As Boolean)
        _ProblemIdentified = value
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
        Return _SheetID
      End Get
      Set(ByVal value As String)
      End Set
    End Property
    Public ReadOnly Property FK_ADM_ServiceSheetHeader_ADM_Schedules() As SIS.ADM.admSchedules
      Get
        If _FK_ADM_ServiceSheetHeader_ADM_Schedules Is Nothing Then
          _FK_ADM_ServiceSheetHeader_ADM_Schedules = SIS.ADM.admSchedules.GetByID(_ScheduleID)
        End If
        Return _FK_ADM_ServiceSheetHeader_ADM_Schedules
      End Get
    End Property
    Public ReadOnly Property FK_ADM_ServiceSheetHeader_ADM_Services() As SIS.ADM.admServices
      Get
        If _FK_ADM_ServiceSheetHeader_ADM_Services Is Nothing Then
          _FK_ADM_ServiceSheetHeader_ADM_Services = SIS.ADM.admServices.GetByID(_ServiceID)
        End If
        Return _FK_ADM_ServiceSheetHeader_ADM_Services
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetNewRecord() As SIS.ADM.admMonitorSheetHeader
      Dim Results As SIS.ADM.admMonitorSheetHeader = Nothing
      Results = New SIS.ADM.admMonitorSheetHeader()
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByID(ByVal SheetID As Int32) As SIS.ADM.admMonitorSheetHeader
      Dim Results As SIS.ADM.admMonitorSheetHeader = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmMonitorSheetHeaderSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SheetID",SqlDbType.Int,SheetID.ToString.Length, SheetID)
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ADM.admMonitorSheetHeader(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByID(ByVal SheetID As Int32, ByVal Filter_ServiceID As String, ByVal Filter_ScheduleID As String) As SIS.ADM.admMonitorSheetHeader
      Return GetByID(SheetID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function SelectList(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal orderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ServiceID As String, ByVal ScheduleID As String) As List(Of SIS.ADM.admMonitorSheetHeader)
      Dim Results As List(Of SIS.ADM.admMonitorSheetHeader) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "SheetDate DESC"
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spadmMonitorSheetHeaderSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spadmMonitorSheetHeaderSelectListFilteres"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ServiceID",SqlDbType.NVarChar,10, IIf(ServiceID Is Nothing, String.Empty,ServiceID))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ScheduleID",SqlDbType.NVarChar,20, IIf(ScheduleID Is Nothing, String.Empty,ScheduleID))
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@startRowIndex", SqlDbType.Int, -1, startRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@maximumRows", SqlDbType.Int, -1, maximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ADM.admMonitorSheetHeader)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ADM.admMonitorSheetHeader(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function Update(ByVal Record As SIS.ADM.admMonitorSheetHeader) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmMonitorSheetHeaderUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SheetID",SqlDbType.Int,11, Record.SheetID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SheetDate",SqlDbType.DateTime,21, Iif(Record.SheetDate= "" ,Convert.DBNull, Record.SheetDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ServiceID",SqlDbType.NVarChar,11, Iif(Record.ServiceID= "" ,Convert.DBNull, Record.ServiceID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ScheduleID",SqlDbType.NVarChar,21, Iif(Record.ScheduleID= "" ,Convert.DBNull, Record.ScheduleID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,51, Iif(Record.Description= "" ,Convert.DBNull, Record.Description))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Monitored",SqlDbType.Bit,3, Record.Monitored)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProblemIdentified",SqlDbType.Bit,3, Record.ProblemIdentified)
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          _Result = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return _Result
    End Function
    Public Shared Function SelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ServiceID As String, ByVal ScheduleID As String) As Integer
      Return _RecordCount
    End Function
'		Autocomplete Method
		Public Shared Function SelectadmMonitorSheetHeaderAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
			Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spadmMonitorSheetHeaderAutoCompleteList"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
					Results = New List(Of String)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Not Reader.HasRows Then
					  Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---",""))
					End If
					While (Reader.Read())
            Dim Tmp As SIS.ADM.admMonitorSheetHeader = New SIS.ADM.admMonitorSheetHeader(Reader)
					  Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(Tmp.DisplayField, Tmp.PrimaryKey))
					End While
					Reader.Close()
				End Using
			End Using
			Return Results.ToArray
		End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      On Error Resume Next
      _SheetID = Ctype(Reader("SheetID"),Int32)
      If Convert.IsDBNull(Reader("SheetDate")) Then
        _SheetDate = String.Empty
      Else
        _SheetDate = Ctype(Reader("SheetDate"), String)
      End If
      If Convert.IsDBNull(Reader("ServiceID")) Then
        _ServiceID = String.Empty
      Else
        _ServiceID = Ctype(Reader("ServiceID"), String)
      End If
      If Convert.IsDBNull(Reader("ScheduleID")) Then
        _ScheduleID = String.Empty
      Else
        _ScheduleID = Ctype(Reader("ScheduleID"), String)
      End If
      If Convert.IsDBNull(Reader("Description")) Then
        _Description = String.Empty
      Else
        _Description = Ctype(Reader("Description"), String)
      End If
      _Initiated = Ctype(Reader("Initiated"),Boolean)
      _Monitored = Ctype(Reader("Monitored"),Boolean)
      _ProblemIdentified = Ctype(Reader("ProblemIdentified"),Boolean)
      _Closed = Ctype(Reader("Closed"),Boolean)
      _FK_ADM_ServiceSheetHeader_ADM_Schedules = New SIS.ADM.admSchedules("ADM_Schedules1",Reader)
      _FK_ADM_ServiceSheetHeader_ADM_Services = New SIS.ADM.admServices("ADM_Services2",Reader)
    End Sub
    Public Sub New(ByVal AliasName As String, ByVal Reader As SqlDataReader)
      On Error Resume Next
      _SheetID = Ctype(Reader(AliasName & "_SheetID"),Int32)
      If Convert.IsDBNull(Reader(AliasName & "_SheetDate")) Then
        _SheetDate = String.Empty
      Else
        _SheetDate = Ctype(Reader(AliasName & "_SheetDate"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_ServiceID")) Then
        _ServiceID = String.Empty
      Else
        _ServiceID = Ctype(Reader(AliasName & "_ServiceID"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_ScheduleID")) Then
        _ScheduleID = String.Empty
      Else
        _ScheduleID = Ctype(Reader(AliasName & "_ScheduleID"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_Description")) Then
        _Description = String.Empty
      Else
        _Description = Ctype(Reader(AliasName & "_Description"), String)
      End If
      _Initiated = Ctype(Reader(AliasName & "_Initiated"),Boolean)
      _Monitored = Ctype(Reader(AliasName & "_Monitored"),Boolean)
      _ProblemIdentified = Ctype(Reader(AliasName & "_ProblemIdentified"),Boolean)
      _Closed = Ctype(Reader(AliasName & "_Closed"),Boolean)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
