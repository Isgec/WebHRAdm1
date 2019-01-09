Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ADM
  <DataObject()> _
  Partial Public Class admSchedules
    Private Shared _RecordCount As Integer
    Private _ScheduleID As String = ""
    Private _Description As String = ""
    Private _FixDate As Boolean = False
    Private _DaysOrDate As String = ""
    Private _IncludeHolidays As Boolean = False
    Public Property ScheduleID() As String
      Get
        Return _ScheduleID
      End Get
      Set(ByVal value As String)
        _ScheduleID = value
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
    Public Property FixDate() As Boolean
      Get
        Return _FixDate
      End Get
      Set(ByVal value As Boolean)
        _FixDate = value
      End Set
    End Property
    Public Property DaysOrDate() As String
      Get
        Return _DaysOrDate
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _DaysOrDate = ""
				 Else
					 _DaysOrDate = value
			   End If
      End Set
    End Property
    Public Property IncludeHolidays() As Boolean
      Get
        Return _IncludeHolidays
      End Get
      Set(ByVal value As Boolean)
        _IncludeHolidays = value
      End Set
    End Property
    Public Property DisplayField() As String
      Get
        Return "" & _Description.ToString.PadRight(20, " ")
      End Get
      Set(ByVal value As String)
      End Set
    End Property
    Public Property PrimaryKey() As String
      Get
        Return _ScheduleID
      End Get
      Set(ByVal value As String)
      End Set
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function SelectList(ByVal orderBy As String) As List(Of SIS.ADM.admSchedules)
      Dim Results As List(Of SIS.ADM.admSchedules) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmSchedulesSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ADM.admSchedules)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ADM.admSchedules(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetNewRecord() As SIS.ADM.admSchedules
      Dim Results As SIS.ADM.admSchedules = Nothing
      Results = New SIS.ADM.admSchedules()
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByID(ByVal ScheduleID As String) As SIS.ADM.admSchedules
      Dim Results As SIS.ADM.admSchedules = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmSchedulesSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ScheduleID",SqlDbType.NVarChar,ScheduleID.ToString.Length, ScheduleID)
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ADM.admSchedules(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function SelectList(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal orderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.ADM.admSchedules)
      Dim Results As List(Of SIS.ADM.admSchedules) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spadmSchedulesSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spadmSchedulesSelectListFilteres"
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@startRowIndex", SqlDbType.Int, -1, startRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@maximumRows", SqlDbType.Int, -1, maximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ADM.admSchedules)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ADM.admSchedules(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function Insert(ByVal Record As SIS.ADM.admSchedules) As String
      Dim _Result As String = Record.ScheduleID
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmSchedulesInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ScheduleID",SqlDbType.NVarChar,21, Record.ScheduleID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,21, Record.Description)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FixDate",SqlDbType.Bit,3, Record.FixDate)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DaysOrDate",SqlDbType.Int,11, Iif(Record.DaysOrDate= "" ,Convert.DBNull, Record.DaysOrDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IncludeHolidays",SqlDbType.Bit,3, Record.IncludeHolidays)
          Cmd.Parameters.Add("@Return_ScheduleID", SqlDbType.NVarChar, 20)
          Cmd.Parameters("@Return_ScheduleID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          _Result = Cmd.Parameters("@Return_ScheduleID").Value
        End Using
      End Using
      Return _Result
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function Update(ByVal Record As SIS.ADM.admSchedules) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmSchedulesUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ScheduleID",SqlDbType.NVarChar,21, Record.ScheduleID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,21, Record.Description)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FixDate",SqlDbType.Bit,3, Record.FixDate)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DaysOrDate",SqlDbType.Int,11, Iif(Record.DaysOrDate= "" ,Convert.DBNull, Record.DaysOrDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IncludeHolidays",SqlDbType.Bit,3, Record.IncludeHolidays)
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
    Public Shared Function Delete(ByVal Record As SIS.ADM.admSchedules) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmSchedulesDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ScheduleID",SqlDbType.NVarChar,Record.ScheduleID.ToString.Length, Record.ScheduleID)
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
		Public Shared Function SelectadmSchedulesAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
			Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spadmSchedulesAutoCompleteList"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix),0,IIf(Prefix.ToLower=Prefix, 0, 1)))
					Results = New List(Of String)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Not Reader.HasRows Then
					  Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(20, " "),""))
					End If
					While (Reader.Read())
            Dim Tmp As SIS.ADM.admSchedules = New SIS.ADM.admSchedules(Reader)
					  Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(Tmp.DisplayField, Tmp.PrimaryKey))
					End While
					Reader.Close()
				End Using
			End Using
			Return Results.ToArray
		End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      On Error Resume Next
      _ScheduleID = Ctype(Reader("ScheduleID"),String)
      _Description = Ctype(Reader("Description"),String)
      _FixDate = Ctype(Reader("FixDate"),Boolean)
      If Convert.IsDBNull(Reader("DaysOrDate")) Then
        _DaysOrDate = String.Empty
      Else
        _DaysOrDate = Ctype(Reader("DaysOrDate"), String)
      End If
      _IncludeHolidays = Ctype(Reader("IncludeHolidays"),Boolean)
    End Sub
    Public Sub New(ByVal AliasName As String, ByVal Reader As SqlDataReader)
      On Error Resume Next
      _ScheduleID = Ctype(Reader(AliasName & "_ScheduleID"),String)
      _Description = Ctype(Reader(AliasName & "_Description"),String)
      _FixDate = Ctype(Reader(AliasName & "_FixDate"),Boolean)
      If Convert.IsDBNull(Reader(AliasName & "_DaysOrDate")) Then
        _DaysOrDate = String.Empty
      Else
        _DaysOrDate = Ctype(Reader(AliasName & "_DaysOrDate"), String)
      End If
      _IncludeHolidays = Ctype(Reader(AliasName & "_IncludeHolidays"),Boolean)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
