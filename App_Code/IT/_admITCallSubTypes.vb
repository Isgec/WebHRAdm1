Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ADM
  <DataObject()> _
  Partial Public Class admITCallSubTypes
    Private Shared _RecordCount As Integer
    Private _CallTypeID As String = ""
    Private _CallSubTypeID As Int32 = 0
    Private _Description As String = ""
    Private _ADM_ITCallTypes1_Description As String = ""
    Private _FK_ADM_ITCallSubTypes_CallTypeID As SIS.ADM.admITCallTypes = Nothing
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
    Public Property CallTypeID() As String
      Get
        Return _CallTypeID
      End Get
      Set(ByVal value As String)
        _CallTypeID = value
      End Set
    End Property
    Public Property CallSubTypeID() As Int32
      Get
        Return _CallSubTypeID
      End Get
      Set(ByVal value As Int32)
        _CallSubTypeID = value
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
    Public Property ADM_ITCallTypes1_Description() As String
      Get
        Return _ADM_ITCallTypes1_Description
      End Get
      Set(ByVal value As String)
        _ADM_ITCallTypes1_Description = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _Description.ToString.PadRight(50, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _CallTypeID & "|" & _CallSubTypeID
      End Get
    End Property
    Public Shared Property RecordCount() As Integer
      Get
        Return _RecordCount
      End Get
      Set(ByVal value As Integer)
        _RecordCount = value
      End Set
    End Property
    Public Class PKadmITCallSubTypes
			Private _CallTypeID As String = ""
			Private _CallSubTypeID As Int32 = 0
			Public Property CallTypeID() As String
				Get
					Return _CallTypeID
				End Get
				Set(ByVal value As String)
					_CallTypeID = value
				End Set
			End Property
			Public Property CallSubTypeID() As Int32
				Get
					Return _CallSubTypeID
				End Get
				Set(ByVal value As Int32)
					_CallSubTypeID = value
				End Set
			End Property
    End Class
    Public ReadOnly Property FK_ADM_ITCallSubTypes_CallTypeID() As SIS.ADM.admITCallTypes
      Get
        If _FK_ADM_ITCallSubTypes_CallTypeID Is Nothing Then
					_FK_ADM_ITCallSubTypes_CallTypeID = SIS.ADM.admITCallTypes.GetByID(_CallTypeID)
        End If
        Return _FK_ADM_ITCallSubTypes_CallTypeID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function admITCallSubTypesSelectList(ByVal OrderBy As String) As List(Of SIS.ADM.admITCallSubTypes)
      Dim Results As List(Of SIS.ADM.admITCallSubTypes) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmITCallSubTypesSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ADM.admITCallSubTypes)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ADM.admITCallSubTypes(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function admITCallSubTypesGetNewRecord() As SIS.ADM.admITCallSubTypes
      Return New SIS.ADM.admITCallSubTypes()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function admITCallSubTypesGetByID(ByVal CallTypeID As String, ByVal CallSubTypeID As Int32) As SIS.ADM.admITCallSubTypes
      Dim Results As SIS.ADM.admITCallSubTypes = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmITCallSubTypesSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CallTypeID",SqlDbType.NVarChar,CallTypeID.ToString.Length, CallTypeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CallSubTypeID",SqlDbType.Int,CallSubTypeID.ToString.Length, CallSubTypeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Reader.Read() Then
						Results = New SIS.ADM.admITCallSubTypes(Reader)
					End If
					Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function admITCallSubTypesSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal CallTypeID As String) As List(Of SIS.ADM.admITCallSubTypes)
      Dim Results As List(Of SIS.ADM.admITCallSubTypes) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spadmITCallSubTypesSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spadmITCallSubTypesSelectListFilteres"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CallTypeID",SqlDbType.NVarChar,20, IIf(CallTypeID Is Nothing, String.Empty,CallTypeID))
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ADM.admITCallSubTypes)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ADM.admITCallSubTypes(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function admITCallSubTypesSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal CallTypeID As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function admITCallSubTypesGetByID(ByVal CallTypeID As String, ByVal CallSubTypeID As Int32, ByVal Filter_CallTypeID As String) As SIS.ADM.admITCallSubTypes
      Return admITCallSubTypesGetByID(CallTypeID, CallSubTypeID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function admITCallSubTypesInsert(ByVal Record As SIS.ADM.admITCallSubTypes) As SIS.ADM.admITCallSubTypes
      Dim _Rec As SIS.ADM.admITCallSubTypes = SIS.ADM.admITCallSubTypes.admITCallSubTypesGetNewRecord()
      With _Rec
        .CallTypeID = Record.CallTypeID
        .Description = Record.Description
      End With
      Return SIS.ADM.admITCallSubTypes.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.ADM.admITCallSubTypes) As SIS.ADM.admITCallSubTypes
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmITCallSubTypesInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CallTypeID",SqlDbType.NVarChar,21, Record.CallTypeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,51, Record.Description)
          Cmd.Parameters.Add("@Return_CallTypeID", SqlDbType.NVarChar, 21)
          Cmd.Parameters("@Return_CallTypeID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_CallSubTypeID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_CallSubTypeID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.CallTypeID = Cmd.Parameters("@Return_CallTypeID").Value
          Record.CallSubTypeID = Cmd.Parameters("@Return_CallSubTypeID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function admITCallSubTypesUpdate(ByVal Record As SIS.ADM.admITCallSubTypes) As SIS.ADM.admITCallSubTypes
      Dim _Rec As SIS.ADM.admITCallSubTypes = SIS.ADM.admITCallSubTypes.admITCallSubTypesGetByID(Record.CallTypeID, Record.CallSubTypeID)
      With _Rec
        .Description = Record.Description
      End With
      Return SIS.ADM.admITCallSubTypes.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.ADM.admITCallSubTypes) As SIS.ADM.admITCallSubTypes
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmITCallSubTypesUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_CallTypeID",SqlDbType.NVarChar,21, Record.CallTypeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_CallSubTypeID",SqlDbType.Int,11, Record.CallSubTypeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CallTypeID",SqlDbType.NVarChar,21, Record.CallTypeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,51, Record.Description)
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Con.Open()
          Cmd.ExecuteNonQuery()
          _RecordCount = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Delete, True)> _
    Public Shared Function admITCallSubTypesDelete(ByVal Record As SIS.ADM.admITCallSubTypes) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmITCallSubTypesDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_CallTypeID",SqlDbType.NVarChar,Record.CallTypeID.ToString.Length, Record.CallTypeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_CallSubTypeID",SqlDbType.Int,Record.CallSubTypeID.ToString.Length, Record.CallSubTypeID)
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Con.Open()
          Cmd.ExecuteNonQuery()
          _RecordCount = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return _RecordCount
    End Function
'		Autocomplete Method
		Public Shared Function SelectadmITCallSubTypesAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
			Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spadmITCallSubTypesAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
					Results = New List(Of String)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Not Reader.HasRows Then
					  Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(50, " "),"" & "|" & ""))
					End If
					While (Reader.Read())
            Dim Tmp As SIS.ADM.admITCallSubTypes = New SIS.ADM.admITCallSubTypes(Reader)
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(Tmp.DisplayField, Tmp.CallSubTypeID))
          End While
					Reader.Close()
				End Using
			End Using
			Return Results.ToArray
		End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      On Error Resume Next
      _CallTypeID = Ctype(Reader("CallTypeID"),String)
      _CallSubTypeID = Ctype(Reader("CallSubTypeID"),Int32)
      _Description = Ctype(Reader("Description"),String)
      _ADM_ITCallTypes1_Description = Ctype(Reader("ADM_ITCallTypes1_Description"),String)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
