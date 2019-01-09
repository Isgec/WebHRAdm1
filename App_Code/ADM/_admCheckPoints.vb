Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ADM
  <DataObject()> _
  Partial Public Class admCheckPoints
    Private Shared _RecordCount As Integer
    Private _CheckPointID As Int32 = 0
    Private _Descriptions As String = ""
    Private _ScheduleID As String = ""
    Private _StartDate As String = ""
    Private _DayOfSchedule As String = ""
    Private _Floating As Boolean = False
    Private _LastGeneratedOn As String = ""
    Private _LastEntryUpdated As Boolean = False
    Private _LastEntryUpdatedOn As String = ""
    Private _Initiator As String = ""
    Private _ADM_Schedules1_Description As String = ""
    Private _aspnet_users1_UserFullName As String = ""
    Private _FK_ADM_CheckPoints_ADM_Schedules As SIS.ADM.admSchedules = Nothing
    Private _FK_ADM_CheckPoints_aspnet_Users As SIS.ADM.admUsers = Nothing
    Public ReadOnly Property ForeColor() As System.Drawing.Color
      Get
        Dim mRet As System.Drawing.Color = Drawing.Color.Blue
        Try
					mRet = GetColor()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Visible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
					mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Enable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
					mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Property CheckPointID() As Int32
      Get
        Return _CheckPointID
      End Get
      Set(ByVal value As Int32)
        _CheckPointID = value
      End Set
    End Property
    Public Property Descriptions() As String
      Get
        Return _Descriptions
      End Get
      Set(ByVal value As String)
        _Descriptions = value
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
    Public Property StartDate() As String
      Get
        If Not _StartDate = String.Empty Then
          Return Convert.ToDateTime(_StartDate).ToString("dd/MM/yyyy")
        End If
        Return _StartDate
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _StartDate = ""
				 Else
					 _StartDate = value
			   End If
      End Set
    End Property
    Public Property DayOfSchedule() As String
      Get
        Return _DayOfSchedule
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _DayOfSchedule = ""
				 Else
					 _DayOfSchedule = value
			   End If
      End Set
    End Property
    Public Property Floating() As Boolean
      Get
        Return _Floating
      End Get
      Set(ByVal value As Boolean)
        _Floating = value
      End Set
    End Property
    Public Property LastGeneratedOn() As String
      Get
        If Not _LastGeneratedOn = String.Empty Then
          Return Convert.ToDateTime(_LastGeneratedOn).ToString("dd/MM/yyyy")
        End If
        Return _LastGeneratedOn
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _LastGeneratedOn = ""
				 Else
					 _LastGeneratedOn = value
			   End If
      End Set
    End Property
    Public Property LastEntryUpdated() As Boolean
      Get
        Return _LastEntryUpdated
      End Get
      Set(ByVal value As Boolean)
        _LastEntryUpdated = value
      End Set
    End Property
    Public Property LastEntryUpdatedOn() As String
      Get
        If Not _LastEntryUpdatedOn = String.Empty Then
          Return Convert.ToDateTime(_LastEntryUpdatedOn).ToString("dd/MM/yyyy")
        End If
        Return _LastEntryUpdatedOn
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _LastEntryUpdatedOn = ""
				 Else
					 _LastEntryUpdatedOn = value
			   End If
      End Set
    End Property
    Public Property Initiator() As String
      Get
        Return _Initiator
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _Initiator = ""
				 Else
					 _Initiator = value
			   End If
      End Set
    End Property
    Public Property ADM_Schedules1_Description() As String
      Get
        Return _ADM_Schedules1_Description
      End Get
      Set(ByVal value As String)
        _ADM_Schedules1_Description = value
      End Set
    End Property
    Public Property aspnet_users1_UserFullName() As String
      Get
        Return _aspnet_users1_UserFullName
      End Get
      Set(ByVal value As String)
        _aspnet_users1_UserFullName = value
      End Set
    End Property
    Public Property DisplayField() As String
      Get
        Return "" & _Descriptions.ToString.PadRight(50, " ")
      End Get
      Set(ByVal value As String)
      End Set
    End Property
    Public Property PrimaryKey() As String
      Get
        Return _CheckPointID
      End Get
      Set(ByVal value As String)
      End Set
    End Property
    Public Property RecordCount() As Integer
      Get
        Return _RecordCount
      End Get
      Set(ByVal value As Integer)
        _RecordCount = value
      End Set
    End Property
    Public ReadOnly Property FK_ADM_CheckPoints_ADM_Schedules() As SIS.ADM.admSchedules
      Get
        If _FK_ADM_CheckPoints_ADM_Schedules Is Nothing Then
          _FK_ADM_CheckPoints_ADM_Schedules = SIS.ADM.admSchedules.GetByID(_ScheduleID)
        End If
        Return _FK_ADM_CheckPoints_ADM_Schedules
      End Get
    End Property
    Public ReadOnly Property FK_ADM_CheckPoints_aspnet_Users() As SIS.ADM.admUsers
      Get
        If _FK_ADM_CheckPoints_aspnet_Users Is Nothing Then
          _FK_ADM_CheckPoints_aspnet_Users = SIS.ADM.admUsers.GetByID(_Initiator)
        End If
        Return _FK_ADM_CheckPoints_aspnet_Users
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function SelectList(ByVal orderBy As String) As List(Of SIS.ADM.admCheckPoints)
      Dim Results As List(Of SIS.ADM.admCheckPoints) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmCheckPointsSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ADM.admCheckPoints)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ADM.admCheckPoints(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetNewRecord() As SIS.ADM.admCheckPoints
      Return New SIS.ADM.admCheckPoints()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByID(ByVal CheckPointID As Int32) As SIS.ADM.admCheckPoints
      Dim Results As SIS.ADM.admCheckPoints = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmCheckPointsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CheckPointID",SqlDbType.Int,CheckPointID.ToString.Length, CheckPointID)
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ADM.admCheckPoints(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function SelectList(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal orderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.ADM.admCheckPoints)
      Dim Results As List(Of SIS.ADM.admCheckPoints) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spadmCheckPointsSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spadmCheckPointsSelectListFilteres"
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@startRowIndex", SqlDbType.Int, -1, startRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@maximumRows", SqlDbType.Int, -1, maximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ADM.admCheckPoints)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ADM.admCheckPoints(Reader))
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
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function Insert(ByVal Record As SIS.ADM.admCheckPoints) As Int32
      Dim _Rec As SIS.ADM.admCheckPoints = SIS.ADM.admCheckPoints.GetNewRecord()
      With _Rec
        .Descriptions = Record.Descriptions
        .ScheduleID = Record.ScheduleID
        .StartDate = Record.StartDate
        .DayOfSchedule = Record.DayOfSchedule
        .Floating = Record.Floating
        .Initiator = Record.Initiator
      End With
      Return SIS.ADM.admCheckPoints.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.ADM.admCheckPoints) As Int32
      Dim _Result As Int32 = Record.CheckPointID
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmCheckPointsInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Descriptions",SqlDbType.NVarChar,51, Record.Descriptions)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ScheduleID",SqlDbType.NVarChar,21, Record.ScheduleID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartDate",SqlDbType.DateTime,21, Iif(Record.StartDate= "" ,Convert.DBNull, Record.StartDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DayOfSchedule",SqlDbType.Int,11, Iif(Record.DayOfSchedule= "" ,Convert.DBNull, Record.DayOfSchedule))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Floating",SqlDbType.Bit,3, Record.Floating)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LastGeneratedOn",SqlDbType.DateTime,21, Iif(Record.LastGeneratedOn= "" ,Convert.DBNull, Record.LastGeneratedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LastEntryUpdated",SqlDbType.Bit,3, Record.LastEntryUpdated)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LastEntryUpdatedOn",SqlDbType.DateTime,21, Iif(Record.LastEntryUpdatedOn= "" ,Convert.DBNull, Record.LastEntryUpdatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Initiator",SqlDbType.NVarChar,9, Iif(Record.Initiator= "" ,Convert.DBNull, Record.Initiator))
          Cmd.Parameters.Add("@Return_CheckPointID", SqlDbType.Int, 10)
          Cmd.Parameters("@Return_CheckPointID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          _Result = Cmd.Parameters("@Return_CheckPointID").Value
        End Using
      End Using
      Return _Result
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function Update(ByVal Record As SIS.ADM.admCheckPoints) As Int32
      Dim _Rec As SIS.ADM.admCheckPoints = SIS.ADM.admCheckPoints.GetByID(Record.CheckPointID)
      With _Rec
        .Descriptions = Record.Descriptions
        .ScheduleID = Record.ScheduleID
        .StartDate = Record.StartDate
        .DayOfSchedule = Record.DayOfSchedule
        .Floating = Record.Floating
        .LastGeneratedOn = Record.LastGeneratedOn
        .LastEntryUpdated = Record.LastEntryUpdated
        .LastEntryUpdatedOn = Record.LastEntryUpdatedOn
        .Initiator = Record.Initiator
      End With
      Return SIS.ADM.admCheckPoints.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.ADM.admCheckPoints) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmCheckPointsUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_CheckPointID",SqlDbType.Int,11, Record.CheckPointID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Descriptions",SqlDbType.NVarChar,51, Record.Descriptions)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ScheduleID",SqlDbType.NVarChar,21, Record.ScheduleID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartDate",SqlDbType.DateTime,21, Iif(Record.StartDate= "" ,Convert.DBNull, Record.StartDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DayOfSchedule",SqlDbType.Int,11, Iif(Record.DayOfSchedule= "" ,Convert.DBNull, Record.DayOfSchedule))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Floating",SqlDbType.Bit,3, Record.Floating)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LastGeneratedOn",SqlDbType.DateTime,21, Iif(Record.LastGeneratedOn= "" ,Convert.DBNull, Record.LastGeneratedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LastEntryUpdated",SqlDbType.Bit,3, Record.LastEntryUpdated)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LastEntryUpdatedOn",SqlDbType.DateTime,21, Iif(Record.LastEntryUpdatedOn= "" ,Convert.DBNull, Record.LastEntryUpdatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Initiator",SqlDbType.NVarChar,9, Iif(Record.Initiator= "" ,Convert.DBNull, Record.Initiator))
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
    Public Shared Function Delete(ByVal Record As SIS.ADM.admCheckPoints, Optional ByVal Cascade As Boolean = False) As Int32
      Dim _Result as Integer = 0
      If Cascade Then
				
      End If
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmCheckPointsDelete"
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
'		Autocomplete Method
		Public Shared Function SelectadmCheckPointsAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
			Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spadmCheckPointsAutoCompleteList"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
					Results = New List(Of String)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Not Reader.HasRows Then
					  Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(50, " "),""))
					End If
					While (Reader.Read())
            Dim Tmp As SIS.ADM.admCheckPoints = New SIS.ADM.admCheckPoints(Reader)
					  Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(Tmp.DisplayField, Tmp.PrimaryKey))
					End While
					Reader.Close()
				End Using
			End Using
			Return Results.ToArray
		End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      On Error Resume Next
      _CheckPointID = Ctype(Reader("CheckPointID"),Int32)
      _Descriptions = Ctype(Reader("Descriptions"),String)
      _ScheduleID = Ctype(Reader("ScheduleID"),String)
      If Convert.IsDBNull(Reader("StartDate")) Then
        _StartDate = String.Empty
      Else
        _StartDate = Ctype(Reader("StartDate"), String)
      End If
      If Convert.IsDBNull(Reader("DayOfSchedule")) Then
        _DayOfSchedule = String.Empty
      Else
        _DayOfSchedule = Ctype(Reader("DayOfSchedule"), String)
      End If
      _Floating = Ctype(Reader("Floating"),Boolean)
      If Convert.IsDBNull(Reader("LastGeneratedOn")) Then
        _LastGeneratedOn = String.Empty
      Else
        _LastGeneratedOn = Ctype(Reader("LastGeneratedOn"), String)
      End If
      _LastEntryUpdated = Ctype(Reader("LastEntryUpdated"),Boolean)
      If Convert.IsDBNull(Reader("LastEntryUpdatedOn")) Then
        _LastEntryUpdatedOn = String.Empty
      Else
        _LastEntryUpdatedOn = Ctype(Reader("LastEntryUpdatedOn"), String)
      End If
      If Convert.IsDBNull(Reader("Initiator")) Then
        _Initiator = String.Empty
      Else
        _Initiator = Ctype(Reader("Initiator"), String)
      End If
      _ADM_Schedules1_Description = Ctype(Reader("ADM_Schedules1_Description"),String)
      _aspnet_users1_UserFullName = Ctype(Reader("aspnet_users1_UserFullName"),String)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
