Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ADM
  <DataObject()> _
  Partial Public Class admITEventTransactions
    Private Shared _RecordCount As Integer
    Private _EventID As Int32 = 0
    Private _EventDate As String = ""
    Private _CardNo As String = ""
    Private _Description As String = ""
    Private _Completed As Boolean = False
		Private _CompletedOn As String = ""
		Private _EntryDate As String = ""
    Private _FK_ADM_ITEventTransactions_HRM_Employees As SIS.ADM.admEmployees = Nothing
    Public Property EventID() As Int32
      Get
        Return _EventID
      End Get
      Set(ByVal value As Int32)
        _EventID = value
      End Set
    End Property
    Public Property EventDate() As String
      Get
        If Not _EventDate = String.Empty Then
          Return Convert.ToDateTime(_EventDate).ToString("dd/MM/yyyy")
        End If
        Return _EventDate
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _EventDate = ""
				 Else
					 _EventDate = value
			   End If
      End Set
    End Property
    Public Property CardNo() As String
      Get
        Return _CardNo
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _CardNo = ""
				 Else
					 _CardNo = value
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
    Public Property Completed() As Boolean
      Get
        Return _Completed
      End Get
      Set(ByVal value As Boolean)
        _Completed = value
      End Set
    End Property
		Public Property CompletedOn() As String
			Get
				If Not _CompletedOn = String.Empty Then
					Return Convert.ToDateTime(_CompletedOn).ToString("dd/MM/yyyy")
				End If
				Return _CompletedOn
			End Get
			Set(ByVal value As String)
				If Convert.IsDBNull(Value) Then
					_CompletedOn = ""
				Else
					_CompletedOn = value
				End If
			End Set
		End Property
		Public Property EntryDate() As String
			Get
				If Not _EntryDate = String.Empty Then
					Return Convert.ToDateTime(_EntryDate).ToString("dd/MM/yyyy")
				End If
				Return _EntryDate
			End Get
			Set(ByVal value As String)
				If Convert.IsDBNull(value) Then
					_EntryDate = ""
				Else
					_EntryDate = value
				End If
			End Set
		End Property
		Public Property DisplayField() As String
			Get
				Return "" & _Description.ToString.PadRight(100, " ")
			End Get
			Set(ByVal value As String)
			End Set
		End Property
    Public Property PrimaryKey() As String
      Get
        Return _EventID
      End Get
      Set(ByVal value As String)
      End Set
    End Property
    Public ReadOnly Property FK_ADM_ITEventTransactions_HRM_Employees() As SIS.ADM.admEmployees
      Get
        If _FK_ADM_ITEventTransactions_HRM_Employees Is Nothing Then
          _FK_ADM_ITEventTransactions_HRM_Employees = SIS.ADM.admEmployees.GetByID(_CardNo)
        End If
        Return _FK_ADM_ITEventTransactions_HRM_Employees
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function SelectList(ByVal orderBy As String) As List(Of SIS.ADM.admITEventTransactions)
      Dim Results As List(Of SIS.ADM.admITEventTransactions) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmITEventTransactionsSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ADM.admITEventTransactions)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ADM.admITEventTransactions(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetNewRecord() As SIS.ADM.admITEventTransactions
      Dim Results As SIS.ADM.admITEventTransactions = Nothing
      Results = New SIS.ADM.admITEventTransactions()
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByID(ByVal EventID As Int32) As SIS.ADM.admITEventTransactions
      Dim Results As SIS.ADM.admITEventTransactions = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmITEventTransactionsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EventID",SqlDbType.Int,EventID.ToString.Length, EventID)
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ADM.admITEventTransactions(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByID(ByVal EventID As Int32, ByVal Filter_CardNo As String) As SIS.ADM.admITEventTransactions
      Return GetByID(EventID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function SelectList(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal orderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal CardNo As String) As List(Of SIS.ADM.admITEventTransactions)
      Dim Results As List(Of SIS.ADM.admITEventTransactions) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					If orderBy = String.Empty Then orderBy = "EventID DESC"
					Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spadmITEventTransactionsSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spadmITEventTransactionsSelectListFilteres"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CardNo", SqlDbType.NVarChar, 8, IIf(CardNo Is Nothing, String.Empty, CardNo))
					End If
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@startRowIndex", SqlDbType.Int, -1, startRowIndex)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@maximumRows", SqlDbType.Int, -1, maximumRows)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
					Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
					Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
					_RecordCount = -1
					Results = New List(Of SIS.ADM.admITEventTransactions)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results.Add(New SIS.ADM.admITEventTransactions(Reader))
					End While
					Reader.Close()
					_RecordCount = Cmd.Parameters("@RecordCount").Value
				End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function Insert(ByVal Record As SIS.ADM.admITEventTransactions) As Int32
      Dim _Result As Int32 = Record.EventID
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmITEventTransactionsInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EventDate",SqlDbType.DateTime,21, Iif(Record.EventDate= "" ,Convert.DBNull, Record.EventDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo",SqlDbType.NVarChar,9, Iif(Record.CardNo= "" ,Convert.DBNull, Record.CardNo))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description", SqlDbType.NVarChar, 101, IIf(Record.Description = "", Convert.DBNull, Record.Description))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Circular", SqlDbType.NText, -1, IIf(Record.Circular = "", Convert.DBNull, Record.Circular))
					Cmd.Parameters.Add("@Return_EventID", SqlDbType.Int, 10)
          Cmd.Parameters("@Return_EventID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          _Result = Cmd.Parameters("@Return_EventID").Value
        End Using
      End Using
      Return _Result
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function Update(ByVal Record As SIS.ADM.admITEventTransactions) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmITEventTransactionsUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_EventID",SqlDbType.Int,11, Record.EventID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EventDate",SqlDbType.DateTime,21, Iif(Record.EventDate= "" ,Convert.DBNull, Record.EventDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo",SqlDbType.NVarChar,9, Iif(Record.CardNo= "" ,Convert.DBNull, Record.CardNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,101, Iif(Record.Description= "" ,Convert.DBNull, Record.Description))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Completed",SqlDbType.Bit,3, Record.Completed)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CompletedOn",SqlDbType.DateTime,21, Iif(Record.CompletedOn= "" ,Convert.DBNull, Record.CompletedOn))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Circular", SqlDbType.NText, -1, IIf(Record.Circular = "", Convert.DBNull, Record.Circular))
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
    Public Shared Function Delete(ByVal Record As SIS.ADM.admITEventTransactions) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmITEventTransactionsDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_EventID",SqlDbType.Int,Record.EventID.ToString.Length, Record.EventID)
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          _Result = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return _Result
    End Function
    Public Shared Function SelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal CardNo As String) As Integer
      Return _RecordCount
    End Function
'		Autocomplete Method
		Public Shared Function SelectadmITEventTransactionsAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
			Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spadmITEventTransactionsAutoCompleteList"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
					Results = New List(Of String)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Not Reader.HasRows Then
					  Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(100, " "),""))
					End If
					While (Reader.Read())
            Dim Tmp As SIS.ADM.admITEventTransactions = New SIS.ADM.admITEventTransactions(Reader)
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
      If Convert.IsDBNull(Reader("EventDate")) Then
        _EventDate = String.Empty
      Else
        _EventDate = Ctype(Reader("EventDate"), String)
      End If
      If Convert.IsDBNull(Reader("CardNo")) Then
        _CardNo = String.Empty
      Else
        _CardNo = Ctype(Reader("CardNo"), String)
      End If
      If Convert.IsDBNull(Reader("Description")) Then
        _Description = String.Empty
      Else
        _Description = Ctype(Reader("Description"), String)
      End If
      _Completed = Ctype(Reader("Completed"),Boolean)
			If Convert.IsDBNull(Reader("CompletedOn")) Then
				_CompletedOn = String.Empty
			Else
				_CompletedOn = CType(Reader("CompletedOn"), String)
			End If
			If Convert.IsDBNull(Reader("EntryDate")) Then
				_EntryDate = String.Empty
			Else
				_EntryDate = CType(Reader("EntryDate"), String)
			End If
			_FK_ADM_ITEventTransactions_HRM_Employees = New SIS.ADM.admEmployees("HRM_Employees1", Reader)
			If Convert.IsDBNull(Reader("Circular")) Then
				_Circular = String.Empty
			Else
				_Circular = CType(Reader("Circular"), String)
			End If
    End Sub
    Public Sub New(ByVal AliasName As String, ByVal Reader As SqlDataReader)
      On Error Resume Next
      _EventID = Ctype(Reader(AliasName & "_EventID"),Int32)
      If Convert.IsDBNull(Reader(AliasName & "_EventDate")) Then
        _EventDate = String.Empty
      Else
        _EventDate = Ctype(Reader(AliasName & "_EventDate"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_CardNo")) Then
        _CardNo = String.Empty
      Else
        _CardNo = Ctype(Reader(AliasName & "_CardNo"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_Description")) Then
        _Description = String.Empty
      Else
        _Description = Ctype(Reader(AliasName & "_Description"), String)
      End If
      _Completed = Ctype(Reader(AliasName & "_Completed"),Boolean)
      If Convert.IsDBNull(Reader(AliasName & "_CompletedOn")) Then
        _CompletedOn = String.Empty
      Else
        _CompletedOn = Ctype(Reader(AliasName & "_CompletedOn"), String)
      End If
			If Convert.IsDBNull(Reader(AliasName & "_EntryDate")) Then
				_EntryDate = String.Empty
			Else
				_EntryDate = CType(Reader(AliasName & "_EntryDate"), String)
			End If
		End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
