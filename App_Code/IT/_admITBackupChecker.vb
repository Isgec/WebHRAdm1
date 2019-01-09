Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ADM
  <DataObject()> _
  Partial Public Class admITBackupChecker
    Private Shared _RecordCount As Integer
    Private _BackupID As Int32 = 0
    Private _Description As String = ""
    Private _SourcePath As String = ""
    Private _TargetPath As String = ""
    Private _USBPath As String = ""
    Private _SourceDrive As String = ""
    Private _TargetDrive As String = ""
    Private _USBDrive As String = ""
    Private _CheckPointID As String = ""
    Private _Active As Boolean = False
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
    Public Property BackupID() As Int32
      Get
        Return _BackupID
      End Get
      Set(ByVal value As Int32)
        _BackupID = value
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
    Public Property SourcePath() As String
      Get
        Return _SourcePath
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _SourcePath = ""
				 Else
					 _SourcePath = value
			   End If
      End Set
    End Property
    Public Property TargetPath() As String
      Get
        Return _TargetPath
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _TargetPath = ""
				 Else
					 _TargetPath = value
			   End If
      End Set
    End Property
    Public Property USBPath() As String
      Get
        Return _USBPath
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _USBPath = ""
				 Else
					 _USBPath = value
			   End If
      End Set
    End Property
    Public Property SourceDrive() As String
      Get
        Return _SourceDrive
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _SourceDrive = ""
				 Else
					 _SourceDrive = value
			   End If
      End Set
    End Property
    Public Property TargetDrive() As String
      Get
        Return _TargetDrive
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _TargetDrive = ""
				 Else
					 _TargetDrive = value
			   End If
      End Set
    End Property
    Public Property USBDrive() As String
      Get
        Return _USBDrive
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _USBDrive = ""
				 Else
					 _USBDrive = value
			   End If
      End Set
    End Property
    Public Property CheckPointID() As String
      Get
        Return _CheckPointID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _CheckPointID = ""
				 Else
					 _CheckPointID = value
			   End If
      End Set
    End Property
    Public Property Active() As Boolean
      Get
        Return _Active
      End Get
      Set(ByVal value As Boolean)
        _Active = value
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
        Return _BackupID
      End Get
      Set(ByVal value As String)
      End Set
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetNewRecord() As SIS.ADM.admITBackupChecker
      Dim Results As SIS.ADM.admITBackupChecker = Nothing
      Results = New SIS.ADM.admITBackupChecker()
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByID(ByVal BackupID As Int32) As SIS.ADM.admITBackupChecker
      Dim Results As SIS.ADM.admITBackupChecker = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmITBackupCheckerSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BackupID",SqlDbType.Int,BackupID.ToString.Length, BackupID)
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ADM.admITBackupChecker(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function SelectList(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal orderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.ADM.admITBackupChecker)
      Dim Results As List(Of SIS.ADM.admITBackupChecker) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spadmITBackupCheckerSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spadmITBackupCheckerSelectListFilteres"
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@startRowIndex", SqlDbType.Int, -1, startRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@maximumRows", SqlDbType.Int, -1, maximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ADM.admITBackupChecker)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ADM.admITBackupChecker(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function Insert(ByVal Record As SIS.ADM.admITBackupChecker) As Int32
      Dim _Result As Int32 = Record.BackupID
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmITBackupCheckerInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,51, Iif(Record.Description= "" ,Convert.DBNull, Record.Description))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SourcePath",SqlDbType.NVarChar,251, Iif(Record.SourcePath= "" ,Convert.DBNull, Record.SourcePath))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TargetPath",SqlDbType.NVarChar,251, Iif(Record.TargetPath= "" ,Convert.DBNull, Record.TargetPath))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@USBPath",SqlDbType.NVarChar,251, Iif(Record.USBPath= "" ,Convert.DBNull, Record.USBPath))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SourceDrive",SqlDbType.NVarChar,2, Iif(Record.SourceDrive= "" ,Convert.DBNull, Record.SourceDrive))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TargetDrive",SqlDbType.NVarChar,2, Iif(Record.TargetDrive= "" ,Convert.DBNull, Record.TargetDrive))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@USBDrive",SqlDbType.NVarChar,2, Iif(Record.USBDrive= "" ,Convert.DBNull, Record.USBDrive))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CheckPointID",SqlDbType.Int,11, Iif(Record.CheckPointID= "" ,Convert.DBNull, Record.CheckPointID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Active",SqlDbType.Bit,3, Record.Active)
          Cmd.Parameters.Add("@Return_BackupID", SqlDbType.Int, 10)
          Cmd.Parameters("@Return_BackupID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          _Result = Cmd.Parameters("@Return_BackupID").Value
        End Using
      End Using
      Return _Result
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function Update(ByVal Record As SIS.ADM.admITBackupChecker) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmITBackupCheckerUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_BackupID",SqlDbType.Int,11, Record.BackupID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,51, Iif(Record.Description= "" ,Convert.DBNull, Record.Description))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SourcePath",SqlDbType.NVarChar,251, Iif(Record.SourcePath= "" ,Convert.DBNull, Record.SourcePath))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TargetPath",SqlDbType.NVarChar,251, Iif(Record.TargetPath= "" ,Convert.DBNull, Record.TargetPath))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@USBPath",SqlDbType.NVarChar,251, Iif(Record.USBPath= "" ,Convert.DBNull, Record.USBPath))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SourceDrive",SqlDbType.NVarChar,2, Iif(Record.SourceDrive= "" ,Convert.DBNull, Record.SourceDrive))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TargetDrive",SqlDbType.NVarChar,2, Iif(Record.TargetDrive= "" ,Convert.DBNull, Record.TargetDrive))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@USBDrive",SqlDbType.NVarChar,2, Iif(Record.USBDrive= "" ,Convert.DBNull, Record.USBDrive))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CheckPointID",SqlDbType.Int,11, Iif(Record.CheckPointID= "" ,Convert.DBNull, Record.CheckPointID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Active",SqlDbType.Bit,3, Record.Active)
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
    Public Shared Function Delete(ByVal Record As SIS.ADM.admITBackupChecker, Optional ByVal Cascade As Boolean = False) As Int32
      Dim _Result as Integer = 0
      If Cascade Then
				
      End If
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmITBackupCheckerDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_BackupID",SqlDbType.Int,Record.BackupID.ToString.Length, Record.BackupID)
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
    Public Sub New(ByVal Reader As SqlDataReader)
      On Error Resume Next
      _BackupID = Ctype(Reader("BackupID"),Int32)
      If Convert.IsDBNull(Reader("Description")) Then
        _Description = String.Empty
      Else
        _Description = Ctype(Reader("Description"), String)
      End If
      If Convert.IsDBNull(Reader("SourcePath")) Then
        _SourcePath = String.Empty
      Else
        _SourcePath = Ctype(Reader("SourcePath"), String)
      End If
      If Convert.IsDBNull(Reader("TargetPath")) Then
        _TargetPath = String.Empty
      Else
        _TargetPath = Ctype(Reader("TargetPath"), String)
      End If
      If Convert.IsDBNull(Reader("USBPath")) Then
        _USBPath = String.Empty
      Else
        _USBPath = Ctype(Reader("USBPath"), String)
      End If
      If Convert.IsDBNull(Reader("SourceDrive")) Then
        _SourceDrive = String.Empty
      Else
        _SourceDrive = Ctype(Reader("SourceDrive"), String)
      End If
      If Convert.IsDBNull(Reader("TargetDrive")) Then
        _TargetDrive = String.Empty
      Else
        _TargetDrive = Ctype(Reader("TargetDrive"), String)
      End If
      If Convert.IsDBNull(Reader("USBDrive")) Then
        _USBDrive = String.Empty
      Else
        _USBDrive = Ctype(Reader("USBDrive"), String)
      End If
      If Convert.IsDBNull(Reader("CheckPointID")) Then
        _CheckPointID = String.Empty
      Else
        _CheckPointID = Ctype(Reader("CheckPointID"), String)
      End If
      _Active = Ctype(Reader("Active"),Boolean)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
