Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ADM
  <DataObject()> _
  Partial Public Class admQlfUpdate
    Private Shared _RecordCount As Integer
    Private _CardNo As String = ""
    Private _uid As String = ""
    Private _emailid As String = ""
    Private _DepartmentID As String = ""
    Private _Qlf1ID As String = ""
    Private _Qlf1Yr As String = ""
    Private _Qlf1NotInList As Boolean = False
    Private _Qlf1Specified As String = ""
    Private _Qlf2ID As String = ""
    Private _Qlf2Yr As String = ""
    Private _Qlf2NotInList As Boolean = False
    Private _Qlf2Specified As String = ""
    Private _FatherName As String = ""
    Private _DateOfBirth As String = ""
    Private _BloodGroupID As String = ""
    Private _N_CellNo As String = ""
    Private _N_Qlf1ID As String = ""
    Private _N_Qlf1Yr As String = ""
    Private _N_Qlf2ID As String = ""
    Private _N_Qlf2Yr As String = ""
    Private _N_FatherName As String = ""
    Private _N_DateOfBirth As String = ""
    Private _N_BloodGroupID As String = ""
    Private _sendmail As Boolean = False
    Private _Changed As Boolean = False
    Private _Updated As Boolean = False
    Private _UpdatedOn As String = ""
    Private _FK_HRM_QlfUpdate_HRM_Departments As SIS.ADM.admDepartments = Nothing
    Private _FK_HRM_QlfUpdate_HRM_Employees As SIS.ADM.admEmployees = Nothing
    Private _FK_HRM_QlfUpdate_HRM_Qualifications As SIS.ADM.admQualifications = Nothing
    Private _FK_HRM_QlfUpdate_HRM_Qualifications1 As SIS.ADM.admQualifications = Nothing
    Public Property CardNo() As String
      Get
        Return _CardNo
      End Get
      Set(ByVal value As String)
        _CardNo = value
      End Set
    End Property
    Public Property uid() As String
      Get
        Return _uid
      End Get
      Set(ByVal value As String)
        _uid = value
      End Set
    End Property
    Public Property emailid() As String
      Get
        Return _emailid
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _emailid = ""
				 Else
					 _emailid = value
			   End If
      End Set
    End Property
    Public Property DepartmentID() As String
      Get
        Return _DepartmentID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _DepartmentID = ""
				 Else
					 _DepartmentID = value
			   End If
      End Set
    End Property
    Public Property Qlf1ID() As String
      Get
        Return _Qlf1ID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _Qlf1ID = ""
				 Else
					 _Qlf1ID = value
			   End If
      End Set
    End Property
    Public Property Qlf1Yr() As String
      Get
        Return _Qlf1Yr
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _Qlf1Yr = ""
				 Else
					 _Qlf1Yr = value
			   End If
      End Set
    End Property
    Public Property Qlf1NotInList() As Boolean
      Get
        Return _Qlf1NotInList
      End Get
      Set(ByVal value As Boolean)
        _Qlf1NotInList = value
      End Set
    End Property
    Public Property Qlf1Specified() As String
      Get
        Return _Qlf1Specified
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _Qlf1Specified = ""
				 Else
					 _Qlf1Specified = value
			   End If
      End Set
    End Property
    Public Property Qlf2ID() As String
      Get
        Return _Qlf2ID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _Qlf2ID = ""
				 Else
					 _Qlf2ID = value
			   End If
      End Set
    End Property
    Public Property Qlf2Yr() As String
      Get
        Return _Qlf2Yr
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _Qlf2Yr = ""
				 Else
					 _Qlf2Yr = value
			   End If
      End Set
    End Property
    Public Property Qlf2NotInList() As Boolean
      Get
        Return _Qlf2NotInList
      End Get
      Set(ByVal value As Boolean)
        _Qlf2NotInList = value
      End Set
    End Property
    Public Property Qlf2Specified() As String
      Get
        Return _Qlf2Specified
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _Qlf2Specified = ""
				 Else
					 _Qlf2Specified = value
			   End If
      End Set
    End Property
    Public Property FatherName() As String
      Get
        Return _FatherName
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _FatherName = ""
				 Else
					 _FatherName = value
			   End If
      End Set
    End Property
    Public Property DateOfBirth() As String
      Get
        If Not _DateOfBirth = String.Empty Then
          Return Convert.ToDateTime(_DateOfBirth).ToString("dd/MM/yyyy")
        End If
        Return _DateOfBirth
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _DateOfBirth = ""
				 Else
					 _DateOfBirth = value
			   End If
      End Set
    End Property
    Public Property BloodGroupID() As String
      Get
        Return _BloodGroupID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _BloodGroupID = ""
				 Else
					 _BloodGroupID = value
			   End If
      End Set
    End Property
    Public Property N_CellNo() As String
      Get
        Return _N_CellNo
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _N_CellNo = ""
				 Else
					 _N_CellNo = value
			   End If
      End Set
    End Property
    Public Property N_Qlf1ID() As String
      Get
        Return _N_Qlf1ID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _N_Qlf1ID = ""
				 Else
					 _N_Qlf1ID = value
			   End If
      End Set
    End Property
    Public Property N_Qlf1Yr() As String
      Get
        Return _N_Qlf1Yr
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _N_Qlf1Yr = ""
				 Else
					 _N_Qlf1Yr = value
			   End If
      End Set
    End Property
    Public Property N_Qlf2ID() As String
      Get
        Return _N_Qlf2ID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _N_Qlf2ID = ""
				 Else
					 _N_Qlf2ID = value
			   End If
      End Set
    End Property
    Public Property N_Qlf2Yr() As String
      Get
        Return _N_Qlf2Yr
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _N_Qlf2Yr = ""
				 Else
					 _N_Qlf2Yr = value
			   End If
      End Set
    End Property
    Public Property N_FatherName() As String
      Get
        Return _N_FatherName
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _N_FatherName = ""
				 Else
					 _N_FatherName = value
			   End If
      End Set
    End Property
    Public Property N_DateOfBirth() As String
      Get
        If Not _N_DateOfBirth = String.Empty Then
          Return Convert.ToDateTime(_N_DateOfBirth).ToString("dd/MM/yyyy")
        End If
        Return _N_DateOfBirth
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _N_DateOfBirth = ""
				 Else
					 _N_DateOfBirth = value
			   End If
      End Set
    End Property
    Public Property N_BloodGroupID() As String
      Get
        Return _N_BloodGroupID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _N_BloodGroupID = ""
				 Else
					 _N_BloodGroupID = value
			   End If
      End Set
    End Property
    Public Property sendmail() As Boolean
      Get
        Return _sendmail
      End Get
      Set(ByVal value As Boolean)
        _sendmail = value
      End Set
    End Property
    Public Property Changed() As Boolean
      Get
        Return _Changed
      End Get
      Set(ByVal value As Boolean)
        _Changed = value
      End Set
    End Property
    Public Property Updated() As Boolean
      Get
        Return _Updated
      End Get
      Set(ByVal value As Boolean)
        _Updated = value
      End Set
    End Property
    Public Property UpdatedOn() As String
      Get
        If Not _UpdatedOn = String.Empty Then
          Return Convert.ToDateTime(_UpdatedOn).ToString("dd/MM/yyyy")
        End If
        Return _UpdatedOn
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _UpdatedOn = ""
				 Else
					 _UpdatedOn = value
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
        Return _CardNo
      End Get
      Set(ByVal value As String)
      End Set
    End Property
    Public ReadOnly Property FK_HRM_QlfUpdate_HRM_Departments() As SIS.ADM.admDepartments
      Get
        If _FK_HRM_QlfUpdate_HRM_Departments Is Nothing Then
          _FK_HRM_QlfUpdate_HRM_Departments = SIS.ADM.admDepartments.GetByID(_DepartmentID)
        End If
        Return _FK_HRM_QlfUpdate_HRM_Departments
      End Get
    End Property
    Public ReadOnly Property FK_HRM_QlfUpdate_HRM_Employees() As SIS.ADM.admEmployees
      Get
        If _FK_HRM_QlfUpdate_HRM_Employees Is Nothing Then
          _FK_HRM_QlfUpdate_HRM_Employees = SIS.ADM.admEmployees.GetByID(_CardNo)
        End If
        Return _FK_HRM_QlfUpdate_HRM_Employees
      End Get
    End Property
    Public ReadOnly Property FK_HRM_QlfUpdate_HRM_Qualifications() As SIS.ADM.admQualifications
      Get
        If _FK_HRM_QlfUpdate_HRM_Qualifications Is Nothing Then
          _FK_HRM_QlfUpdate_HRM_Qualifications = SIS.ADM.admQualifications.GetByID(_Qlf1ID)
        End If
        Return _FK_HRM_QlfUpdate_HRM_Qualifications
      End Get
    End Property
    Public ReadOnly Property FK_HRM_QlfUpdate_HRM_Qualifications1() As SIS.ADM.admQualifications
      Get
        If _FK_HRM_QlfUpdate_HRM_Qualifications1 Is Nothing Then
          _FK_HRM_QlfUpdate_HRM_Qualifications1 = SIS.ADM.admQualifications.GetByID(_Qlf2ID)
        End If
        Return _FK_HRM_QlfUpdate_HRM_Qualifications1
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetNewRecord() As SIS.ADM.admQlfUpdate
      Dim Results As SIS.ADM.admQlfUpdate = Nothing
      Results = New SIS.ADM.admQlfUpdate()
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByID(ByVal CardNo As String) As SIS.ADM.admQlfUpdate
      Dim Results As SIS.ADM.admQlfUpdate = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmQlfUpdateSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo",SqlDbType.NVarChar,CardNo.ToString.Length, CardNo)
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ADM.admQlfUpdate(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByID(ByVal CardNo As String, ByVal Filter_CardNo As String, ByVal Filter_DepartmentID As String, ByVal Filter_Qlf1ID As Int32, ByVal Filter_Qlf2ID As Int32) As SIS.ADM.admQlfUpdate
      Return GetByID(CardNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function SelectList(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal orderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal CardNo As String, ByVal DepartmentID As String, ByVal Qlf1ID As Int32, ByVal Qlf2ID As Int32) As List(Of SIS.ADM.admQlfUpdate)
      Dim Results As List(Of SIS.ADM.admQlfUpdate) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spadmQlfUpdateSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spadmQlfUpdateSelectListFilteres"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CardNo",SqlDbType.NVarChar,8, IIf(CardNo Is Nothing, String.Empty,CardNo))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_DepartmentID",SqlDbType.NVarChar,6, IIf(DepartmentID Is Nothing, String.Empty,DepartmentID))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_Qlf1ID",SqlDbType.Int,10, IIf(Qlf1ID = Nothing, 0,Qlf1ID))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_Qlf2ID",SqlDbType.Int,10, IIf(Qlf2ID = Nothing, 0,Qlf2ID))
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@startRowIndex", SqlDbType.Int, -1, startRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@maximumRows", SqlDbType.Int, -1, maximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ADM.admQlfUpdate)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ADM.admQlfUpdate(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function Insert(ByVal Record As SIS.ADM.admQlfUpdate) As String
      Dim _Result As String = Record.CardNo
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmQlfUpdateInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo",SqlDbType.NVarChar,9, Record.CardNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@emailid",SqlDbType.NVarChar,101, Iif(Record.emailid= "" ,Convert.DBNull, Record.emailid))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DepartmentID",SqlDbType.NVarChar,7, Iif(Record.DepartmentID= "" ,Convert.DBNull, Record.DepartmentID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Qlf1ID",SqlDbType.Int,11, Iif(Record.Qlf1ID= "" ,Convert.DBNull, Record.Qlf1ID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Qlf1Yr",SqlDbType.NVarChar,5, Iif(Record.Qlf1Yr= "" ,Convert.DBNull, Record.Qlf1Yr))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Qlf1NotInList",SqlDbType.Bit,3, Record.Qlf1NotInList)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Qlf1Specified",SqlDbType.NVarChar,51, Iif(Record.Qlf1Specified= "" ,Convert.DBNull, Record.Qlf1Specified))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Qlf2ID",SqlDbType.Int,11, Iif(Record.Qlf2ID= "" ,Convert.DBNull, Record.Qlf2ID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Qlf2Yr",SqlDbType.NVarChar,5, Iif(Record.Qlf2Yr= "" ,Convert.DBNull, Record.Qlf2Yr))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Qlf2NotInList",SqlDbType.Bit,3, Record.Qlf2NotInList)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Qlf2Specified",SqlDbType.NVarChar,51, Iif(Record.Qlf2Specified= "" ,Convert.DBNull, Record.Qlf2Specified))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FatherName",SqlDbType.NVarChar,51, Iif(Record.FatherName= "" ,Convert.DBNull, Record.FatherName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DateOfBirth",SqlDbType.DateTime,21, Iif(Record.DateOfBirth= "" ,Convert.DBNull, Record.DateOfBirth))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BloodGroupID",SqlDbType.NVarChar,6, Iif(Record.BloodGroupID= "" ,Convert.DBNull, Record.BloodGroupID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@sendmail",SqlDbType.Bit,3, Record.sendmail)
          Cmd.Parameters.Add("@Return_CardNo", SqlDbType.NVarChar, 8)
          Cmd.Parameters("@Return_CardNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          _Result = Cmd.Parameters("@Return_CardNo").Value
        End Using
      End Using
      Return _Result
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function Update(ByVal Record As SIS.ADM.admQlfUpdate) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmQlfUpdateUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_CardNo",SqlDbType.NVarChar,9, Record.CardNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@emailid",SqlDbType.NVarChar,101, Iif(Record.emailid= "" ,Convert.DBNull, Record.emailid))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Qlf1NotInList",SqlDbType.Bit,3, Record.Qlf1NotInList)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Qlf1Specified",SqlDbType.NVarChar,51, Iif(Record.Qlf1Specified= "" ,Convert.DBNull, Record.Qlf1Specified))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Qlf2NotInList",SqlDbType.Bit,3, Record.Qlf2NotInList)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Qlf2Specified",SqlDbType.NVarChar,51, Iif(Record.Qlf2Specified= "" ,Convert.DBNull, Record.Qlf2Specified))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@N_CellNo", SqlDbType.NVarChar, 51, IIf(Record.N_CellNo = "", Convert.DBNull, Record.N_CellNo))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@N_Qlf1ID", SqlDbType.Int, 11, IIf(Record.Qlf1ID = "", Convert.DBNull, Record.Qlf1ID))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@N_Qlf1Yr", SqlDbType.NVarChar, 5, IIf(Record.Qlf1Yr = "", Convert.DBNull, Record.Qlf1Yr))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@N_Qlf2ID", SqlDbType.Int, 11, IIf(Record.Qlf2ID = "", Convert.DBNull, Record.Qlf2ID))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@N_Qlf2Yr", SqlDbType.NVarChar, 5, IIf(Record.Qlf2Yr = "", Convert.DBNull, Record.Qlf2Yr))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@N_FatherName", SqlDbType.NVarChar, 51, IIf(Record.FatherName = "", Convert.DBNull, Record.FatherName))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@N_DateOfBirth", SqlDbType.DateTime, 21, IIf(Record.DateOfBirth = "", Convert.DBNull, Record.DateOfBirth))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@N_BloodGroupID", SqlDbType.NVarChar, 6, IIf(Record.BloodGroupID = "", Convert.DBNull, Record.BloodGroupID))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@sendmail", SqlDbType.Bit, 3, Record.sendmail)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Changed",SqlDbType.Bit,3, Record.Changed)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Updated",SqlDbType.Bit,3, 1)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UpdatedOn",SqlDbType.DateTime,21, Now)
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
    Public Shared Function Delete(ByVal Record As SIS.ADM.admQlfUpdate) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spadmQlfUpdateDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_CardNo",SqlDbType.NVarChar,Record.CardNo.ToString.Length, Record.CardNo)
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          _Result = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return _Result
    End Function
    Public Shared Function SelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal CardNo As String, ByVal DepartmentID As String, ByVal Qlf1ID As Int32, ByVal Qlf2ID As Int32) As Integer
      Return _RecordCount
    End Function
'		Autocomplete Method
		Public Shared Function SelectadmQlfUpdateAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
			Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spadmQlfUpdateAutoCompleteList"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix),0,IIf(Prefix.ToLower=Prefix, 0, 1)))
					Results = New List(Of String)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Not Reader.HasRows Then
					  Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---",""))
					End If
					While (Reader.Read())
            Dim Tmp As SIS.ADM.admQlfUpdate = New SIS.ADM.admQlfUpdate(Reader)
					  Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(Tmp.DisplayField, Tmp.PrimaryKey))
					End While
					Reader.Close()
				End Using
			End Using
			Return Results.ToArray
		End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      On Error Resume Next
      _CardNo = Ctype(Reader("CardNo"),String)
			'_uid = Ctype(Reader("uid"),String)
			uid = System.Convert.ChangeType(Reader("uid"), TypeCode.String)
      If Convert.IsDBNull(Reader("emailid")) Then
        _emailid = String.Empty
      Else
        _emailid = Ctype(Reader("emailid"), String)
      End If
      If Convert.IsDBNull(Reader("DepartmentID")) Then
        _DepartmentID = String.Empty
      Else
        _DepartmentID = Ctype(Reader("DepartmentID"), String)
      End If
      If Convert.IsDBNull(Reader("Qlf1ID")) Then
        _Qlf1ID = String.Empty
      Else
        _Qlf1ID = Ctype(Reader("Qlf1ID"), String)
      End If
      If Convert.IsDBNull(Reader("Qlf1Yr")) Then
        _Qlf1Yr = String.Empty
      Else
        _Qlf1Yr = Ctype(Reader("Qlf1Yr"), String)
      End If
      _Qlf1NotInList = Ctype(Reader("Qlf1NotInList"),Boolean)
      If Convert.IsDBNull(Reader("Qlf1Specified")) Then
        _Qlf1Specified = String.Empty
      Else
        _Qlf1Specified = Ctype(Reader("Qlf1Specified"), String)
      End If
      If Convert.IsDBNull(Reader("Qlf2ID")) Then
        _Qlf2ID = String.Empty
      Else
        _Qlf2ID = Ctype(Reader("Qlf2ID"), String)
      End If
      If Convert.IsDBNull(Reader("Qlf2Yr")) Then
        _Qlf2Yr = String.Empty
      Else
        _Qlf2Yr = Ctype(Reader("Qlf2Yr"), String)
      End If
      _Qlf2NotInList = Ctype(Reader("Qlf2NotInList"),Boolean)
      If Convert.IsDBNull(Reader("Qlf2Specified")) Then
        _Qlf2Specified = String.Empty
      Else
        _Qlf2Specified = Ctype(Reader("Qlf2Specified"), String)
      End If
      If Convert.IsDBNull(Reader("FatherName")) Then
        _FatherName = String.Empty
      Else
        _FatherName = Ctype(Reader("FatherName"), String)
      End If
      If Convert.IsDBNull(Reader("DateOfBirth")) Then
        _DateOfBirth = String.Empty
      Else
        _DateOfBirth = Ctype(Reader("DateOfBirth"), String)
      End If
      If Convert.IsDBNull(Reader("BloodGroupID")) Then
        _BloodGroupID = String.Empty
      Else
        _BloodGroupID = Ctype(Reader("BloodGroupID"), String)
      End If
      If Convert.IsDBNull(Reader("N_CellNo")) Then
        _N_CellNo = String.Empty
      Else
        _N_CellNo = Ctype(Reader("N_CellNo"), String)
      End If
      If Convert.IsDBNull(Reader("N_Qlf1ID")) Then
        _N_Qlf1ID = String.Empty
      Else
        _N_Qlf1ID = Ctype(Reader("N_Qlf1ID"), String)
      End If
      If Convert.IsDBNull(Reader("N_Qlf1Yr")) Then
        _N_Qlf1Yr = String.Empty
      Else
        _N_Qlf1Yr = Ctype(Reader("N_Qlf1Yr"), String)
      End If
      If Convert.IsDBNull(Reader("N_Qlf2ID")) Then
        _N_Qlf2ID = String.Empty
      Else
        _N_Qlf2ID = Ctype(Reader("N_Qlf2ID"), String)
      End If
      If Convert.IsDBNull(Reader("N_Qlf2Yr")) Then
        _N_Qlf2Yr = String.Empty
      Else
        _N_Qlf2Yr = Ctype(Reader("N_Qlf2Yr"), String)
      End If
      If Convert.IsDBNull(Reader("N_FatherName")) Then
        _N_FatherName = String.Empty
      Else
        _N_FatherName = Ctype(Reader("N_FatherName"), String)
      End If
      If Convert.IsDBNull(Reader("N_DateOfBirth")) Then
        _N_DateOfBirth = String.Empty
      Else
        _N_DateOfBirth = Ctype(Reader("N_DateOfBirth"), String)
      End If
      If Convert.IsDBNull(Reader("N_BloodGroupID")) Then
        _N_BloodGroupID = String.Empty
      Else
        _N_BloodGroupID = Ctype(Reader("N_BloodGroupID"), String)
      End If
      _sendmail = Ctype(Reader("sendmail"),Boolean)
      _Changed = Ctype(Reader("Changed"),Boolean)
      _Updated = Ctype(Reader("Updated"),Boolean)
      If Convert.IsDBNull(Reader("UpdatedOn")) Then
        _UpdatedOn = String.Empty
      Else
        _UpdatedOn = Ctype(Reader("UpdatedOn"), String)
      End If
      _FK_HRM_QlfUpdate_HRM_Departments = New SIS.ADM.admDepartments("HRM_Departments1",Reader)
      _FK_HRM_QlfUpdate_HRM_Employees = New SIS.ADM.admEmployees("HRM_Employees2",Reader)
      _FK_HRM_QlfUpdate_HRM_Qualifications = New SIS.ADM.admQualifications("HRM_Qualifications3",Reader)
      _FK_HRM_QlfUpdate_HRM_Qualifications1 = New SIS.ADM.admQualifications("HRM_Qualifications4",Reader)
    End Sub
    Public Sub New(ByVal AliasName As String, ByVal Reader As SqlDataReader)
      On Error Resume Next
      _CardNo = Ctype(Reader(AliasName & "_CardNo"),String)
      _uid = Ctype(Reader(AliasName & "_uid"),String)
      If Convert.IsDBNull(Reader(AliasName & "_emailid")) Then
        _emailid = String.Empty
      Else
        _emailid = Ctype(Reader(AliasName & "_emailid"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_DepartmentID")) Then
        _DepartmentID = String.Empty
      Else
        _DepartmentID = Ctype(Reader(AliasName & "_DepartmentID"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_Qlf1ID")) Then
        _Qlf1ID = String.Empty
      Else
        _Qlf1ID = Ctype(Reader(AliasName & "_Qlf1ID"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_Qlf1Yr")) Then
        _Qlf1Yr = String.Empty
      Else
        _Qlf1Yr = Ctype(Reader(AliasName & "_Qlf1Yr"), String)
      End If
      _Qlf1NotInList = Ctype(Reader(AliasName & "_Qlf1NotInList"),Boolean)
      If Convert.IsDBNull(Reader(AliasName & "_Qlf1Specified")) Then
        _Qlf1Specified = String.Empty
      Else
        _Qlf1Specified = Ctype(Reader(AliasName & "_Qlf1Specified"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_Qlf2ID")) Then
        _Qlf2ID = String.Empty
      Else
        _Qlf2ID = Ctype(Reader(AliasName & "_Qlf2ID"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_Qlf2Yr")) Then
        _Qlf2Yr = String.Empty
      Else
        _Qlf2Yr = Ctype(Reader(AliasName & "_Qlf2Yr"), String)
      End If
      _Qlf2NotInList = Ctype(Reader(AliasName & "_Qlf2NotInList"),Boolean)
      If Convert.IsDBNull(Reader(AliasName & "_Qlf2Specified")) Then
        _Qlf2Specified = String.Empty
      Else
        _Qlf2Specified = Ctype(Reader(AliasName & "_Qlf2Specified"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_FatherName")) Then
        _FatherName = String.Empty
      Else
        _FatherName = Ctype(Reader(AliasName & "_FatherName"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_DateOfBirth")) Then
        _DateOfBirth = String.Empty
      Else
        _DateOfBirth = Ctype(Reader(AliasName & "_DateOfBirth"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_BloodGroupID")) Then
        _BloodGroupID = String.Empty
      Else
        _BloodGroupID = Ctype(Reader(AliasName & "_BloodGroupID"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_N_CellNo")) Then
        _N_CellNo = String.Empty
      Else
        _N_CellNo = Ctype(Reader(AliasName & "_N_CellNo"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_N_Qlf1ID")) Then
        _N_Qlf1ID = String.Empty
      Else
        _N_Qlf1ID = Ctype(Reader(AliasName & "_N_Qlf1ID"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_N_Qlf1Yr")) Then
        _N_Qlf1Yr = String.Empty
      Else
        _N_Qlf1Yr = Ctype(Reader(AliasName & "_N_Qlf1Yr"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_N_Qlf2ID")) Then
        _N_Qlf2ID = String.Empty
      Else
        _N_Qlf2ID = Ctype(Reader(AliasName & "_N_Qlf2ID"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_N_Qlf2Yr")) Then
        _N_Qlf2Yr = String.Empty
      Else
        _N_Qlf2Yr = Ctype(Reader(AliasName & "_N_Qlf2Yr"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_N_FatherName")) Then
        _N_FatherName = String.Empty
      Else
        _N_FatherName = Ctype(Reader(AliasName & "_N_FatherName"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_N_DateOfBirth")) Then
        _N_DateOfBirth = String.Empty
      Else
        _N_DateOfBirth = Ctype(Reader(AliasName & "_N_DateOfBirth"), String)
      End If
      If Convert.IsDBNull(Reader(AliasName & "_N_BloodGroupID")) Then
        _N_BloodGroupID = String.Empty
      Else
        _N_BloodGroupID = Ctype(Reader(AliasName & "_N_BloodGroupID"), String)
      End If
      _sendmail = Ctype(Reader(AliasName & "_sendmail"),Boolean)
      _Changed = Ctype(Reader(AliasName & "_Changed"),Boolean)
      _Updated = Ctype(Reader(AliasName & "_Updated"),Boolean)
      If Convert.IsDBNull(Reader(AliasName & "_UpdatedOn")) Then
        _UpdatedOn = String.Empty
      Else
        _UpdatedOn = Ctype(Reader(AliasName & "_UpdatedOn"), String)
      End If
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
