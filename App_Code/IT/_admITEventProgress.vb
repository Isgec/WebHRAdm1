Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ADM
  <DataObject()> _
  Partial Public Class admITEventProgress
    Private Shared _RecordCount As Integer
    Private _EventID As Int32 = 0
    Private _ITServiceID As String = ""
    Private _ActionNotRequired As Boolean = False
    Private _ActionTaken As Boolean = False
    Private _Responded As Boolean = False
    Private _RespondedBy As String = ""
    Private _RespondedOn As String = ""
    Private _AlertedOn As String = ""
    Private _FK_ADM_ITEventStatus_ADM_ITEventTransactions As SIS.ADM.admITEventTransactions = Nothing
    Private _FK_ADM_ITEventStatus_ADM_ITServices As SIS.ADM.admITServices = Nothing
    Private _FK_ADM_ITEventStatus_HRM_Employees As SIS.ADM.admEmployees = Nothing
    Public Property EventID() As Int32
      Get
        Return _EventID
      End Get
      Set(ByVal value As Int32)
        _EventID = value
      End Set
    End Property
    Public Property ITServiceID() As String
      Get
        Return _ITServiceID
      End Get
      Set(ByVal value As String)
        _ITServiceID = value
      End Set
    End Property
    Public Property ActionNotRequired() As Boolean
      Get
        Return _ActionNotRequired
      End Get
      Set(ByVal value As Boolean)
        _ActionNotRequired = value
      End Set
    End Property
    Public Property ActionTaken() As Boolean
      Get
        Return _ActionTaken
      End Get
      Set(ByVal value As Boolean)
        _ActionTaken = value
      End Set
    End Property
    Public Property Responded() As Boolean
      Get
        Return _Responded
      End Get
      Set(ByVal value As Boolean)
        _Responded = value
      End Set
    End Property
    Public Property RespondedBy() As String
      Get
        Return _RespondedBy
      End Get
      Set(ByVal value As String)
        _RespondedBy = value
      End Set
    End Property
    Public Property RespondedOn() As String
      Get
        If Not _RespondedOn = String.Empty Then
          Return Convert.ToDateTime(_RespondedOn).ToString("dd/MM/yyyy")
        End If
        Return _RespondedOn
      End Get
      Set(ByVal value As String)
			   _RespondedOn = value
      End Set
    End Property
    Public Property AlertedOn() As String
      Get
        If Not _AlertedOn = String.Empty Then
          Return Convert.ToDateTime(_AlertedOn).ToString("dd/MM/yyyy")
        End If
        Return _AlertedOn
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _AlertedOn = ""
				 Else
					 _AlertedOn = value
			   End If
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
        Return _EventID & "|" & _ITServiceID
      End Get
      Set(ByVal value As String)
      End Set
    End Property
    Public ReadOnly Property FK_ADM_ITEventStatus_ADM_ITEventTransactions() As SIS.ADM.admITEventTransactions
      Get
        If _FK_ADM_ITEventStatus_ADM_ITEventTransactions Is Nothing Then
          _FK_ADM_ITEventStatus_ADM_ITEventTransactions = SIS.ADM.admITEventTransactions.GetByID(_EventID)
        End If
        Return _FK_ADM_ITEventStatus_ADM_ITEventTransactions
      End Get
    End Property
    Public ReadOnly Property FK_ADM_ITEventStatus_ADM_ITServices() As SIS.ADM.admITServices
      Get
        If _FK_ADM_ITEventStatus_ADM_ITServices Is Nothing Then
          _FK_ADM_ITEventStatus_ADM_ITServices = SIS.ADM.admITServices.GetByID(_ITServiceID)
        End If
        Return _FK_ADM_ITEventStatus_ADM_ITServices
      End Get
    End Property
    Public ReadOnly Property FK_ADM_ITEventStatus_HRM_Employees() As SIS.ADM.admEmployees
      Get
        If _FK_ADM_ITEventStatus_HRM_Employees Is Nothing Then
          _FK_ADM_ITEventStatus_HRM_Employees = SIS.ADM.admEmployees.GetByID(_RespondedBy)
        End If
        Return _FK_ADM_ITEventStatus_HRM_Employees
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetNewRecord() As SIS.ADM.admITEventProgress
      Dim Results As SIS.ADM.admITEventProgress = Nothing
      Results = New SIS.ADM.admITEventProgress()
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByID(ByVal EventID As Int32, ByVal ITServiceID As String) As SIS.ADM.admITEventProgress
      Dim Results As SIS.ADM.admITEventProgress = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmITEventProgressSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EventID",SqlDbType.Int,EventID.ToString.Length, EventID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ITServiceID",SqlDbType.NVarChar,ITServiceID.ToString.Length, ITServiceID)
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ADM.admITEventProgress(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByID(ByVal EventID As Int32, ByVal ITServiceID As String, ByVal Filter_EventID As Int32) As SIS.ADM.admITEventProgress
      Return GetByID(EventID, ITServiceID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByEventID(ByVal EventID As Int32, ByVal OrderBy as String) As List(Of SIS.ADM.admITEventProgress)
      Dim Results As List(Of SIS.ADM.admITEventProgress) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmITEventProgressSelectByEventID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EventID",SqlDbType.Int,EventID.ToString.Length, EventID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ADM.admITEventProgress)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ADM.admITEventProgress(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function SelectList(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal orderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal EventID As Int32) As List(Of SIS.ADM.admITEventProgress)
      Dim Results As List(Of SIS.ADM.admITEventProgress) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spadmITEventProgressSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spadmITEventProgressSelectListFilteres"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_EventID",SqlDbType.Int,10, IIf(EventID = Nothing, 0,EventID))
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@startRowIndex", SqlDbType.Int, -1, startRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@maximumRows", SqlDbType.Int, -1, maximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ADM.admITEventProgress)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ADM.admITEventProgress(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function Update(ByVal Record As SIS.ADM.admITEventProgress) As Int32
			Dim _Result As Integer = 0
			If Record.ActionNotRequired Or Record.ActionTaken Then
				Record.Responded = True
			Else
				Record.Responded = False
			End If
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmITEventProgressUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_EventID",SqlDbType.Int,11, Record.EventID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ITServiceID",SqlDbType.NVarChar,16, Record.ITServiceID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ActionNotRequired",SqlDbType.Bit,3, Record.ActionNotRequired)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ActionTaken",SqlDbType.Bit,3, Record.ActionTaken)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Responded",SqlDbType.Bit,3, Record.Responded)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RespondedBy",SqlDbType.NVarChar,9, Global.System.Web.HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RespondedOn",SqlDbType.DateTime,21, Now)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AlertedOn",SqlDbType.DateTime,21, Iif(Record.AlertedOn= "" ,Convert.DBNull, Record.AlertedOn))
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          _Result = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return _Result
    End Function
    Public Shared Function SelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal EventID As Int32) As Integer
      Return _RecordCount
    End Function
'		Autocomplete Method
		Public Shared Function SelectadmITEventProgressAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
			Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spadmITEventProgressAutoCompleteList"
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
            Dim Tmp As SIS.ADM.admITEventProgress = New SIS.ADM.admITEventProgress(Reader)
					  Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(Tmp.DisplayField, Tmp.PrimaryKey))
					End While
					Reader.Close()
				End Using
			End Using
			Return Results.ToArray
		End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      On Error Resume Next
      _EventID = Ctype(Reader("EventID"),Int32)
      _ITServiceID = Ctype(Reader("ITServiceID"),String)
      _ActionNotRequired = Ctype(Reader("ActionNotRequired"),Boolean)
      _ActionTaken = Ctype(Reader("ActionTaken"),Boolean)
      _Responded = Ctype(Reader("Responded"),Boolean)
      _RespondedBy = Ctype(Reader("RespondedBy"),String)
      _RespondedOn = Ctype(Reader("RespondedOn"),DateTime)
      If Convert.IsDBNull(Reader("AlertedOn")) Then
        _AlertedOn = String.Empty
      Else
        _AlertedOn = Ctype(Reader("AlertedOn"), String)
      End If
      _FK_ADM_ITEventStatus_ADM_ITEventTransactions = New SIS.ADM.admITEventTransactions("ADM_ITEventTransactions1",Reader)
      _FK_ADM_ITEventStatus_ADM_ITServices = New SIS.ADM.admITServices("ADM_ITServices2",Reader)
      _FK_ADM_ITEventStatus_HRM_Employees = New SIS.ADM.admEmployees("HRM_Employees3",Reader)
    End Sub
    Public Sub New(ByVal AliasName As String, ByVal Reader As SqlDataReader)
      On Error Resume Next
      _EventID = Ctype(Reader(AliasName & "_EventID"),Int32)
      _ITServiceID = Ctype(Reader(AliasName & "_ITServiceID"),String)
      _ActionNotRequired = Ctype(Reader(AliasName & "_ActionNotRequired"),Boolean)
      _ActionTaken = Ctype(Reader(AliasName & "_ActionTaken"),Boolean)
      _Responded = Ctype(Reader(AliasName & "_Responded"),Boolean)
      _RespondedBy = Ctype(Reader(AliasName & "_RespondedBy"),String)
      _RespondedOn = Ctype(Reader(AliasName & "_RespondedOn"),DateTime)
      If Convert.IsDBNull(Reader(AliasName & "_AlertedOn")) Then
        _AlertedOn = String.Empty
      Else
        _AlertedOn = Ctype(Reader(AliasName & "_AlertedOn"), String)
      End If
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
