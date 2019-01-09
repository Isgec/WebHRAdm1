Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ADM
  <DataObject()> _
  Partial Public Class IT_CallView
    Private Shared _RecordCount As Integer
    Private _CallID As Int32 = 0
    Private _EndUserID As String = ""
    Private _EmployeeName As String = ""
    Private _DepartmentDescription As String = ""
    Private _Location As String = ""
    Private _CallTypeID As String = ""
    Private _CallDesc As String = ""
    Private _AssignedTo As String = ""
    Private _CallStatusID As String = ""
    Private _LoggedOn As String = ""
    Private _LoggedBy As String = ""
    Private _FirstAttendedOn As String = ""
    Private _ClosedOn As String = ""
    Private _FirstAttended As Boolean = False
    Private _Closed As Boolean = False
    Private _CallReceivedOn As String = ""
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
    Public Property CallID() As Int32
      Get
        Return _CallID
      End Get
      Set(ByVal value As Int32)
        _CallID = value
      End Set
    End Property
    Public Property EndUserID() As String
      Get
        Return _EndUserID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _EndUserID = ""
				 Else
					 _EndUserID = value
			   End If
      End Set
    End Property
    Public Property EmployeeName() As String
      Get
        Return _EmployeeName
      End Get
      Set(ByVal value As String)
        _EmployeeName = value
      End Set
    End Property
    Public Property DepartmentDescription() As String
      Get
        Return _DepartmentDescription
      End Get
      Set(ByVal value As String)
        _DepartmentDescription = value
      End Set
    End Property
    Public Property Location() As String
      Get
        Return _Location
      End Get
      Set(ByVal value As String)
        _Location = value
      End Set
    End Property
    Public Property CallTypeID() As String
      Get
        Return _CallTypeID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _CallTypeID = ""
				 Else
					 _CallTypeID = value
			   End If
      End Set
    End Property
    Public Property CallDesc() As String
      Get
        Return _CallDesc
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _CallDesc = ""
				 Else
					 _CallDesc = value
			   End If
      End Set
    End Property
    Public Property AssignedTo() As String
      Get
        Return _AssignedTo
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _AssignedTo = ""
				 Else
					 _AssignedTo = value
			   End If
      End Set
    End Property
    Public Property CallStatusID() As String
      Get
        Return _CallStatusID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _CallStatusID = ""
				 Else
					 _CallStatusID = value
			   End If
      End Set
    End Property
    Public Property LoggedOn() As String
      Get
        If Not _LoggedOn = String.Empty Then
					Return Convert.ToDateTime(_LoggedOn).ToString("dd/MM/yyyy HH:mm")
        End If
        Return _LoggedOn
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _LoggedOn = ""
				 Else
					 _LoggedOn = value
			   End If
      End Set
    End Property
    Public Property LoggedBy() As String
      Get
        Return _LoggedBy
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _LoggedBy = ""
				 Else
					 _LoggedBy = value
			   End If
      End Set
    End Property
    Public Property FirstAttendedOn() As String
      Get
        If Not _FirstAttendedOn = String.Empty Then
					Return Convert.ToDateTime(_FirstAttendedOn).ToString("dd/MM/yyyy HH:mm")
        End If
        Return _FirstAttendedOn
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _FirstAttendedOn = ""
				 Else
					 _FirstAttendedOn = value
			   End If
      End Set
    End Property
    Public Property ClosedOn() As String
      Get
        If Not _ClosedOn = String.Empty Then
					Return Convert.ToDateTime(_ClosedOn).ToString("dd/MM/yyyy HH:mm")
        End If
        Return _ClosedOn
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ClosedOn = ""
				 Else
					 _ClosedOn = value
			   End If
      End Set
    End Property
    Public Property FirstAttended() As Boolean
      Get
        Return _FirstAttended
      End Get
      Set(ByVal value As Boolean)
        _FirstAttended = value
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
    Public Property CallReceivedOn() As String
      Get
        If Not _CallReceivedOn = String.Empty Then
					Return Convert.ToDateTime(_CallReceivedOn).ToString("dd/MM/yyyy HH:mm")
        End If
        Return _CallReceivedOn
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _CallReceivedOn = ""
				 Else
					 _CallReceivedOn = value
			   End If
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _CallID
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
    Public Class PKIT_CallView
			Private _CallID As Int32 = 0
			Public Property CallID() As Int32
				Get
					Return _CallID
				End Get
				Set(ByVal value As Int32)
					_CallID = value
				End Set
			End Property
    End Class
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function IT_CallViewGetNewRecord() As SIS.ADM.IT_CallView
      Return New SIS.ADM.IT_CallView()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function IT_CallViewGetByID(ByVal CallID As Int32) As SIS.ADM.IT_CallView
      Dim Results As SIS.ADM.IT_CallView = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spIT_CallViewSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CallID",SqlDbType.Int,CallID.ToString.Length, CallID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Reader.Read() Then
						Results = New SIS.ADM.IT_CallView(Reader)
					End If
					Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByLoggedOn(ByVal LoggedOn As DateTime, ByVal OrderBy as String) As List(Of SIS.ADM.IT_CallView)
      Dim Results As List(Of SIS.ADM.IT_CallView) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spIT_CallViewSelectByLoggedOn"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoggedOn",SqlDbType.DateTime,LoggedOn.ToString.Length, LoggedOn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ADM.IT_CallView)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ADM.IT_CallView(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function IT_CallViewSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.ADM.IT_CallView)
      Dim Results As List(Of SIS.ADM.IT_CallView) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spIT_CallViewSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spIT_CallViewSelectListFilteres"
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ADM.IT_CallView)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ADM.IT_CallView(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function IT_CallViewSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    Public Sub New(ByVal Reader As SqlDataReader)
      Try
        For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
          If pi.MemberType = Reflection.MemberTypes.Property Then
            Try
              Dim Found As Boolean = False
              For I As Integer = 0 To Reader.FieldCount - 1
                If Reader.GetName(I).ToLower = pi.Name.ToLower Then
                  Found = True
                  Exit For
                End If
              Next
              If Found Then
                If Convert.IsDBNull(Reader(pi.Name)) Then
                  Select Case Reader.GetDataTypeName(Reader.GetOrdinal(pi.Name))
                    Case "decimal"
                      CallByName(Me, pi.Name, CallType.Let, "0.00")
                    Case "bit"
                      CallByName(Me, pi.Name, CallType.Let, Boolean.FalseString)
                    Case Else
                      CallByName(Me, pi.Name, CallType.Let, String.Empty)
                  End Select
                Else
                  CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
                End If
              End If
            Catch ex As Exception
            End Try
          End If
        Next
      Catch ex As Exception
      End Try
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
