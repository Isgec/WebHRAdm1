Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ADM
  <DataObject()> _
  Partial Public Class admITRegisterComplaint
    Private Shared _RecordCount As Integer
    Private _CallID As Int32 = 0
    Private _EndUserID As String = ""
    Private _CallTypeID As String = ""
		Private _CallSubTypeID As String = ""
		Private _Description As String = ""
    Private _AssignedTo As String = ""
    Private _CallStatusID As String = ""
    Private _LoggedOn As String = ""
    Private _LoggedBy As String = ""
    Private _FirstAttended As Boolean = False
    Private _FirstAttendedOn As String = ""
    Private _Closed As Boolean = False
    Private _ClosedOn As String = ""
		Private _CallReceivedOn As String = ""
		Private _CallConverted As Boolean = False
		Private _ConvertedReference As String = ""
		Private _ConvertedRemarks As String = ""
		Private _Feedback As String = ""
		Private _ADM_ITCallStatus1_Description As String = ""
		Private _ADM_ITCallTypes2_Description As String = ""
		Private _HRM_Employees5_EmployeeName As String = ""
		Private _aspnet_users3_UserFullName As String = ""
		Private _aspnet_users4_UserFullName As String = ""
		Private _ADM_ITCallSubTypes6_Description As String = ""
		Private _FK_ADM_ITComplaints_ADM_ITCallStatus As SIS.ADM.admITCallStatus = Nothing
    Private _FK_ADM_ITComplaints_ADM_ITCallTypes As SIS.ADM.admITCallTypes = Nothing
    Private _FK_ADM_ITComplaints_HRM_Employees As SIS.ADM.admEmployees = Nothing
    Private _FK_ADM_ITComplaints_ADM_Users As SIS.ADM.admUsers = Nothing
    Private _FK_ADM_ITComplaints_ADM_Users1 As SIS.ADM.admUsers = Nothing
		Private _FK_ADM_ITComplaints_CallSubTypeID As SIS.ADM.admITCallSubTypes = Nothing
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
		Public Property CallSubTypeID() As String
			Get
				Return _CallSubTypeID
			End Get
			Set(ByVal value As String)
				If Convert.IsDBNull(Value) Then
					_CallSubTypeID = ""
				Else
					_CallSubTypeID = value
				End If
			End Set
		End Property
		Public Property Description() As String
			Get
				Return _Description
			End Get
			Set(ByVal value As String)
				If Convert.IsDBNull(value) Then
					_Description = ""
				Else
					_Description = value
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
    Public Property FirstAttended() As Boolean
      Get
        Return _FirstAttended
      End Get
      Set(ByVal value As Boolean)
        _FirstAttended = value
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
    Public Property Closed() As Boolean
      Get
        Return _Closed
      End Get
      Set(ByVal value As Boolean)
        _Closed = value
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
		Public Property CallConverted() As Boolean
			Get
				Return _CallConverted
			End Get
			Set(ByVal value As Boolean)
				_CallConverted = value
			End Set
		End Property
		Public Property ConvertedReference() As String
			Get
				Return _ConvertedReference
			End Get
			Set(ByVal value As String)
				If Convert.IsDBNull(value) Then
					_ConvertedReference = ""
				Else
					_ConvertedReference = value
				End If
			End Set
		End Property
		Public Property ConvertedRemarks() As String
			Get
				Return _ConvertedRemarks
			End Get
			Set(ByVal value As String)
				If Convert.IsDBNull(Value) Then
					_ConvertedRemarks = ""
				Else
					_ConvertedRemarks = value
				End If
			End Set
		End Property
		Public Property Feedback() As String
			Get
				Return _Feedback
			End Get
			Set(ByVal value As String)
				If Convert.IsDBNull(Value) Then
					_Feedback = ""
				Else
					_Feedback = value
				End If
			End Set
		End Property
		Public Property ADM_ITCallStatus1_Description() As String
			Get
				Return _ADM_ITCallStatus1_Description
			End Get
			Set(ByVal value As String)
				_ADM_ITCallStatus1_Description = value
			End Set
		End Property
		Public Property ADM_ITCallTypes2_Description() As String
			Get
				Return _ADM_ITCallTypes2_Description
			End Get
			Set(ByVal value As String)
				_ADM_ITCallTypes2_Description = value
			End Set
		End Property
		Public Property HRM_Employees5_EmployeeName() As String
			Get
				Return _HRM_Employees5_EmployeeName
			End Get
			Set(ByVal value As String)
				_HRM_Employees5_EmployeeName = value
			End Set
		End Property
		Public Property aspnet_users3_UserFullName() As String
			Get
				Return _aspnet_users3_UserFullName
			End Get
			Set(ByVal value As String)
				_aspnet_users3_UserFullName = value
			End Set
		End Property
		Public Property aspnet_users4_UserFullName() As String
			Get
				Return _aspnet_users4_UserFullName
			End Get
			Set(ByVal value As String)
				_aspnet_users4_UserFullName = value
			End Set
		End Property
		Public Property ADM_ITCallSubTypes6_Description() As String
			Get
				Return _ADM_ITCallSubTypes6_Description
			End Get
			Set(ByVal value As String)
				_ADM_ITCallSubTypes6_Description = value
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
        Return _CallID
      End Get
      Set(ByVal value As String)
      End Set
    End Property
    Public ReadOnly Property FK_ADM_ITComplaints_ADM_ITCallStatus() As SIS.ADM.admITCallStatus
      Get
        If _FK_ADM_ITComplaints_ADM_ITCallStatus Is Nothing Then
          _FK_ADM_ITComplaints_ADM_ITCallStatus = SIS.ADM.admITCallStatus.GetByID(_CallStatusID)
        End If
        Return _FK_ADM_ITComplaints_ADM_ITCallStatus
      End Get
    End Property
    Public ReadOnly Property FK_ADM_ITComplaints_ADM_ITCallTypes() As SIS.ADM.admITCallTypes
      Get
        If _FK_ADM_ITComplaints_ADM_ITCallTypes Is Nothing Then
          _FK_ADM_ITComplaints_ADM_ITCallTypes = SIS.ADM.admITCallTypes.GetByID(_CallTypeID)
        End If
        Return _FK_ADM_ITComplaints_ADM_ITCallTypes
      End Get
    End Property
    Public ReadOnly Property FK_ADM_ITComplaints_HRM_Employees() As SIS.ADM.admEmployees
      Get
        If _FK_ADM_ITComplaints_HRM_Employees Is Nothing Then
          _FK_ADM_ITComplaints_HRM_Employees = SIS.ADM.admEmployees.GetByID(_EndUserID)
        End If
        Return _FK_ADM_ITComplaints_HRM_Employees
      End Get
    End Property
    Public ReadOnly Property FK_ADM_ITComplaints_ADM_Users() As SIS.ADM.admUsers
      Get
        If _FK_ADM_ITComplaints_ADM_Users Is Nothing Then
          _FK_ADM_ITComplaints_ADM_Users = SIS.ADM.admUsers.GetByID(_LoggedBy)
        End If
        Return _FK_ADM_ITComplaints_ADM_Users
      End Get
    End Property
    Public ReadOnly Property FK_ADM_ITComplaints_ADM_Users1() As SIS.ADM.admUsers
      Get
        If _FK_ADM_ITComplaints_ADM_Users1 Is Nothing Then
          _FK_ADM_ITComplaints_ADM_Users1 = SIS.ADM.admUsers.GetByID(_AssignedTo)
        End If
        Return _FK_ADM_ITComplaints_ADM_Users1
      End Get
    End Property
		Public ReadOnly Property FK_ADM_ITComplaints_CallSubTypeID() As SIS.ADM.admITCallSubTypes
			Get
				If _FK_ADM_ITComplaints_CallSubTypeID Is Nothing Then
					_FK_ADM_ITComplaints_CallSubTypeID = SIS.ADM.admITCallSubTypes.admITCallSubTypesGetByID(_CallTypeID, _CallSubTypeID)
				End If
				Return _FK_ADM_ITComplaints_CallSubTypeID
			End Get
		End Property
		<DataObjectMethod(DataObjectMethodType.Select)> _
		Public Shared Function GetNewRecord() As SIS.ADM.admITRegisterComplaint
			Dim Results As SIS.ADM.admITRegisterComplaint = Nothing
			Results = New SIS.ADM.admITRegisterComplaint()
			Return Results
		End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByID(ByVal CallID As Int32) As SIS.ADM.admITRegisterComplaint
      Dim Results As SIS.ADM.admITRegisterComplaint = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmITRegisterComplaintSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CallID",SqlDbType.Int,CallID.ToString.Length, CallID)
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ADM.admITRegisterComplaint(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByID(ByVal CallID As Int32, ByVal Filter_EndUserID As String, ByVal Filter_CallTypeID As String, ByVal Filter_AssignedTo As String, ByVal Filter_CallStatusID As String) As SIS.ADM.admITRegisterComplaint
      Return GetByID(CallID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function SelectList(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal orderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal EndUserID As String, ByVal CallTypeID As String, ByVal AssignedTo As String, ByVal CallStatusID As String) As List(Of SIS.ADM.admITRegisterComplaint)
      Dim Results As List(Of SIS.ADM.admITRegisterComplaint) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "LoggedOn DESC"
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spadmITRegisterComplaintSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spadmITRegisterComplaintSelectListFilteres"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_EndUserID",SqlDbType.NVarChar,8, IIf(EndUserID Is Nothing, String.Empty,EndUserID))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CallTypeID",SqlDbType.NVarChar,20, IIf(CallTypeID Is Nothing, String.Empty,CallTypeID))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_AssignedTo",SqlDbType.NVarChar,8, IIf(AssignedTo Is Nothing, String.Empty,AssignedTo))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CallStatusID",SqlDbType.NVarChar,20, IIf(CallStatusID Is Nothing, String.Empty,CallStatusID))
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@startRowIndex", SqlDbType.Int, -1, startRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@maximumRows", SqlDbType.Int, -1, maximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ADM.admITRegisterComplaint)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ADM.admITRegisterComplaint(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function Insert(ByVal Record As SIS.ADM.admITRegisterComplaint) As Int32
      'Try
      '  Record.CallSubTypeID = Record.CallSubTypeID.Split("|".ToCharArray)(1)
      'Catch ex As Exception
      'End Try
      Dim _Result As Int32 = Record.CallID
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmITRegisterComplaintInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EndUserID",SqlDbType.NVarChar,9, Iif(Record.EndUserID= "" ,Convert.DBNull, Record.EndUserID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CallTypeID",SqlDbType.NVarChar,21, Iif(Record.CallTypeID= "" ,Convert.DBNull, Record.CallTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,251, Iif(Record.Description= "" ,Convert.DBNull, Record.Description))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AssignedTo",SqlDbType.NVarChar,9, Iif(Record.AssignedTo= "" ,Convert.DBNull, Record.AssignedTo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CallStatusID",SqlDbType.NVarChar,21, "FREE")
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoggedOn",SqlDbType.DateTime,21, Now)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoggedBy",SqlDbType.NVarChar,9, Global.System.Web.HttpContext.Current.Session("LoginID"))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CallReceivedOn", SqlDbType.DateTime, 21, IIf(Record.CallReceivedOn = "", Convert.DBNull, Record.CallReceivedOn))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CallSubTypeID", SqlDbType.Int, 11, IIf(Record.CallSubTypeID = "", Convert.DBNull, Record.CallSubTypeID))
					Cmd.Parameters.Add("@Return_CallID", SqlDbType.Int, 10)
          Cmd.Parameters("@Return_CallID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          _Result = Cmd.Parameters("@Return_CallID").Value
        End Using
      End Using
      Return _Result
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)>
    Public Shared Function Update(ByVal Record As SIS.ADM.admITRegisterComplaint) As Int32
      'Try
      '  Record.CallSubTypeID = Record.CallSubTypeID.Split("|".ToCharArray)(1)
      'Catch ex As Exception
      'End Try
      Dim _Result As Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmITRegisterComplaintUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_CallID", SqlDbType.Int, 11, Record.CallID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EndUserID", SqlDbType.NVarChar, 9, IIf(Record.EndUserID = "", Convert.DBNull, Record.EndUserID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CallTypeID", SqlDbType.NVarChar, 21, IIf(Record.CallTypeID = "", Convert.DBNull, Record.CallTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description", SqlDbType.NVarChar, 251, IIf(Record.Description = "", Convert.DBNull, Record.Description))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AssignedTo", SqlDbType.NVarChar, 9, IIf(Record.AssignedTo = "", Convert.DBNull, Record.AssignedTo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CallReceivedOn", SqlDbType.DateTime, 21, IIf(Record.CallReceivedOn = "", Convert.DBNull, Record.CallReceivedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CallConverted", SqlDbType.Bit, 3, Record.CallConverted)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ConvertedReference", SqlDbType.NVarChar, 51, IIf(Record.ConvertedReference = "", Convert.DBNull, Record.ConvertedReference))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ConvertedRemarks", SqlDbType.NVarChar, 501, IIf(Record.ConvertedRemarks = "", Convert.DBNull, Record.ConvertedRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CallSubTypeID", SqlDbType.Int, 11, IIf(Record.CallSubTypeID = "", Convert.DBNull, Record.CallSubTypeID))
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          _Result = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Dim oCom As SIS.ADM.admITRegisterComplaint = SIS.ADM.admITRegisterComplaint.GetByID(Record.CallID)
      If Not oCom Is Nothing Then
        If Not oCom.Closed Then
          If oCom.CallConverted Then
            SIS.ADM.admITRegisterComplaint.ConvertCall(oCom)
          End If
        End If
      End If

      Return _Result
    End Function
    <DataObjectMethod(DataObjectMethodType.Delete, True)> _
    Public Shared Function Delete(ByVal Record As SIS.ADM.admITRegisterComplaint) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmITRegisterComplaintDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_CallID",SqlDbType.Int,Record.CallID.ToString.Length, Record.CallID)
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          _Result = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return _Result
    End Function
    Public Shared Function SelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal EndUserID As String, ByVal CallTypeID As String, ByVal AssignedTo As String, ByVal CallStatusID As String) As Integer
      Return _RecordCount
    End Function
'		Autocomplete Method
		Public Shared Function SelectadmITRegisterComplaintAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
			Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spadmITRegisterComplaintAutoCompleteList"
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
            Dim Tmp As SIS.ADM.admITRegisterComplaint = New SIS.ADM.admITRegisterComplaint(Reader)
					  Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(Tmp.DisplayField, Tmp.PrimaryKey))
					End While
					Reader.Close()
				End Using
			End Using
			Return Results.ToArray
		End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      On Error Resume Next
      _CallID = Ctype(Reader("CallID"),Int32)
      If Convert.IsDBNull(Reader("EndUserID")) Then
        _EndUserID = String.Empty
      Else
        _EndUserID = Ctype(Reader("EndUserID"), String)
      End If
      If Convert.IsDBNull(Reader("CallTypeID")) Then
        _CallTypeID = String.Empty
      Else
        _CallTypeID = Ctype(Reader("CallTypeID"), String)
      End If
			If Convert.IsDBNull(Reader("CallSubTypeID")) Then
				_CallSubTypeID = String.Empty
			Else
				_CallSubTypeID = CType(Reader("CallSubTypeID"), String)
			End If
			If Convert.IsDBNull(Reader("Description")) Then
				_Description = String.Empty
			Else
				_Description = CType(Reader("Description"), String)
			End If
      If Convert.IsDBNull(Reader("AssignedTo")) Then
        _AssignedTo = String.Empty
      Else
        _AssignedTo = Ctype(Reader("AssignedTo"), String)
      End If
      If Convert.IsDBNull(Reader("CallStatusID")) Then
        _CallStatusID = String.Empty
      Else
        _CallStatusID = Ctype(Reader("CallStatusID"), String)
      End If
      If Convert.IsDBNull(Reader("LoggedOn")) Then
        _LoggedOn = String.Empty
      Else
        _LoggedOn = Ctype(Reader("LoggedOn"), String)
      End If
      If Convert.IsDBNull(Reader("LoggedBy")) Then
        _LoggedBy = String.Empty
      Else
        _LoggedBy = Ctype(Reader("LoggedBy"), String)
      End If
      _FirstAttended = Ctype(Reader("FirstAttended"),Boolean)
      If Convert.IsDBNull(Reader("FirstAttendedOn")) Then
        _FirstAttendedOn = String.Empty
      Else
        _FirstAttendedOn = Ctype(Reader("FirstAttendedOn"), String)
      End If
      _Closed = Ctype(Reader("Closed"),Boolean)
      If Convert.IsDBNull(Reader("ClosedOn")) Then
        _ClosedOn = String.Empty
      Else
        _ClosedOn = Ctype(Reader("ClosedOn"), String)
      End If
			If Convert.IsDBNull(Reader("CallReceivedOn")) Then
				_CallReceivedOn = String.Empty
			Else
				_CallReceivedOn = CType(Reader("CallReceivedOn"), String)
			End If
			_CallConverted = CType(Reader("CallConverted"), Boolean)
			If Convert.IsDBNull(Reader("ConvertedReference")) Then
				_ConvertedReference = String.Empty
			Else
				_ConvertedReference = CType(Reader("ConvertedReference"), String)
			End If
			If Convert.IsDBNull(Reader("ConvertedRemarks")) Then
				_ConvertedRemarks = String.Empty
			Else
				_ConvertedRemarks = CType(Reader("ConvertedRemarks"), String)
			End If
			_ADM_ITCallStatus1_Description = CType(Reader("ADM_ITCallStatus1_Description"), String)
			_ADM_ITCallTypes2_Description = CType(Reader("ADM_ITCallTypes2_Description"), String)
			_HRM_Employees5_EmployeeName = CType(Reader("HRM_Employees5_EmployeeName"), String)
			_aspnet_users3_UserFullName = CType(Reader("aspnet_users3_UserFullName"), String)
			_aspnet_users4_UserFullName = CType(Reader("aspnet_users4_UserFullName"), String)
			_ADM_ITCallSubTypes6_Description = CType(Reader("ADM_ITCallSubTypes6_Description"), String)
		End Sub
    Public Sub New(ByVal AliasName As String, ByVal Reader As SqlDataReader)
      On Error Resume Next
      _CallID = Ctype(Reader(AliasName & "_CallID"),Int32)
      If Convert.IsDBNull(Reader(AliasName & "_EndUserID")) Then
        _EndUserID = String.Empty
      Else
        _EndUserID = Ctype(Reader(AliasName & "_EndUserID"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_CallTypeID")) Then
        _CallTypeID = String.Empty
      Else
        _CallTypeID = Ctype(Reader(AliasName & "_CallTypeID"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_Description")) Then
        _Description = String.Empty
      Else
        _Description = Ctype(Reader(AliasName & "_Description"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_AssignedTo")) Then
        _AssignedTo = String.Empty
      Else
        _AssignedTo = Ctype(Reader(AliasName & "_AssignedTo"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_CallStatusID")) Then
        _CallStatusID = String.Empty
      Else
        _CallStatusID = Ctype(Reader(AliasName & "_CallStatusID"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_LoggedOn")) Then
        _LoggedOn = String.Empty
      Else
        _LoggedOn = Ctype(Reader(AliasName & "_LoggedOn"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_LoggedBy")) Then
        _LoggedBy = String.Empty
      Else
        _LoggedBy = Ctype(Reader(AliasName & "_LoggedBy"), String)
      End If
      _FirstAttended = Ctype(Reader(AliasName & "_FirstAttended"),Boolean)
      If Convert.IsDBNull(Reader(AliasName & "_FirstAttendedOn")) Then
        _FirstAttendedOn = String.Empty
      Else
        _FirstAttendedOn = Ctype(Reader(AliasName & "_FirstAttendedOn"), String)
      End If
      _Closed = Ctype(Reader(AliasName & "_Closed"),Boolean)
      If Convert.IsDBNull(Reader(AliasName & "_ClosedOn")) Then
        _ClosedOn = String.Empty
      Else
        _ClosedOn = Ctype(Reader(AliasName & "_ClosedOn"), String)
			End If
			If Convert.IsDBNull(Reader(AliasName & "_CallReceivedOn")) Then
				_CallReceivedOn = String.Empty
			Else
				_CallReceivedOn = CType(Reader(AliasName & "_CallReceivedOn"), String)
			End If
			_CallConverted = CType(Reader(AliasName & "_CallConverted"), Boolean)
			If Convert.IsDBNull(Reader(AliasName & "_ConvertedReference")) Then
				_ConvertedReference = String.Empty
			Else
				_ConvertedReference = CType(Reader(AliasName & "_ConvertedReference"), String)
			End If
			If Convert.IsDBNull(Reader(AliasName & "_ConvertedRemarks")) Then
				_ConvertedRemarks = String.Empty
			Else
				_ConvertedRemarks = CType(Reader(AliasName & "_ConvertedRemarks"), String)
			End If
		End Sub
		Public Sub New()
		End Sub
  End Class
End Namespace
