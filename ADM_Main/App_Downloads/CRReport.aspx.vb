Imports System.Data
Imports System.Data.SqlClient
Imports OfficeOpenXml
Partial Class CRReport
	Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		Dim mLastScriptTimeout As Integer = HttpContext.Current.Server.ScriptTimeout
		HttpContext.Current.Server.ScriptTimeout = 1200
		Dim FromDate As String = ""
		Dim ToDate As String = ""
		Dim Division As String = ""
		Try
			FromDate = Request.QueryString("fd")
			ToDate = Request.QueryString("td")
			Division = Request.QueryString("typ")
		Catch ex As Exception
			FromDate = ""
			ToDate = ""
			Division = ""
		End Try
		If FromDate = String.Empty Then Return
		Dim DWFile As String = "Change Requests " & FromDate & "_" & ToDate
		Dim FilePath As String = CreateFile(FromDate, ToDate)
		HttpContext.Current.Server.ScriptTimeout = mLastScriptTimeout
		Response.ClearContent()
    Response.AppendHeader("content-disposition", "attachment; filename=" & DWFile & ".xlsx")
    Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(IO.Path.GetFileName(FilePath))
		Response.WriteFile(FilePath)
		Response.End()
	End Sub
	Private Function CreateFile(ByVal FromDate As String, ByVal ToDate As String) As String
		Dim FileName As String = Server.MapPath("~/..") & "App_Temp\" & Guid.NewGuid().ToString()
		IO.File.Copy(Server.MapPath("~/App_Templates") & "\CRTemplate.xlsx", FileName)
		Dim FileInfo As IO.FileInfo = New IO.FileInfo(FileName)
		Dim xlPk As ExcelPackage = New ExcelPackage(FileInfo)

		Dim xlWS As ExcelWorksheet = xlPk.Workbook.Worksheets("Data")
		Dim oDocs As List(Of SIS.ADM.IT_CallView) = ReportClass.GetAllReleasedDocuments(FromDate, ToDate)
		Dim r As Integer = 5
		Dim c As Integer = 1
		With xlWS
			.Cells(2, 3).Value = FromDate
			.Cells(3, 3).Value = ToDate
			For Each doc As SIS.ADM.IT_CallView In oDocs
				If r > 5 Then
					xlWS.InsertRow(r, 1, r + 1)
				End If
				'CallID, EndUserID, EmployeeName, DepartmentDescription, Location, CallTypeID, 
				'CallDesc, AssignedTo, CallStatusID, LoggedOn, LoggedBy, FirstAttendedOn, ClosedOn, 
				'FirstAttended, Closed, CallReceivedOn

				.Cells(r, 1).Value = doc.CallID
				.Cells(r, 2).Value = doc.EndUserID
				.Cells(r, 3).Value = doc.EmployeeName
				.Cells(r, 4).Value = doc.DepartmentDescription
				.Cells(r, 5).Value = doc.Location
				Try
					.Cells(r, 6).Value = doc.CallTypeID
				Catch ex As Exception
					.Cells(r, 6).Value = ""
				End Try
				.Cells(r, 7).Value = doc.CallDesc

        Try
          .Cells(r, 8).Value = doc.Description
        Catch ex As Exception
          .Cells(r, 8).Value = ""
        End Try

        Try
          .Cells(r, 9).Value = doc.AssignedTo
        Catch ex As Exception
          .Cells(r, 9).Value = ""
        End Try
        .Cells(r, 10).Value = doc.CallStatusID
        Try
          .Cells(r, 11).Value = Convert.ToDateTime(doc.LoggedOn).ToString("dd/MM/yyyy HH:mm")
        Catch ex As Exception
          .Cells(r, 11).Value = ""
        End Try
				Try
          .Cells(r, 12).Value = doc.LoggedBy
        Catch ex As Exception
          .Cells(r, 12).Value = ""
        End Try
				Try
          .Cells(r, 13).Value = Convert.ToDateTime(doc.FirstAttendedOn).ToString("dd/MM/yyyy HH:mm")
        Catch ex As Exception
          .Cells(r, 13).Value = ""
        End Try
				Try
          .Cells(r, 14).Value = Convert.ToDateTime(doc.ClosedOn).ToString("dd/MM/yyyy HH:mm")
        Catch ex As Exception
          .Cells(r, 14).Value = ""
        End Try
        .Cells(r, 15).Value = doc.FirstAttended
        .Cells(r, 16).Value = doc.Closed
        Try
          .Cells(r, 17).Value = Convert.ToDateTime(doc.CallReceivedOn).ToString("dd/MM/yyyy HH:mm")
        Catch ex As Exception
          .Cells(r, 17).Value = ""
        End Try
				r += 1
			Next
		End With


		xlPk.Save()
		xlPk.Dispose()
		Return FileName
	End Function
	Private Function RemoveChars(ByVal mstr As String) As String
		'Dim tstr As String = ""
		'For i As Integer = 0 To mstr.Length - 1
		'	If Asc(mstr.Chars(i)) Then

		'	End If
		'Next
		Return mstr.Replace(vbCr, "").Replace(vbLf, "").Replace(vbCrLf, "").Replace(vbNewLine, "")
	End Function
End Class
Public Class ReportClass
	Public Shared Function GetAllReleasedDocuments(ByVal FromDate As String, ByVal ToDate As String) As List(Of SIS.ADM.IT_CallView)
		Dim Sql As String = ""
		Sql &= "  SELECT"
		Sql &= "  [IT_CallView].[CallID] ,"
		Sql &= "  [IT_CallView].[EndUserID] ,"
		Sql &= "  [IT_CallView].[EmployeeName] ,"
		Sql &= "  [IT_CallView].[DepartmentDescription] ,"
		Sql &= "  [IT_CallView].[Location] ,"
    Sql &= "  [IT_CallView].[CallTypeID] ,"
    Sql &= "  [IT_CallView].[Description] ,"
    Sql &= "  Replace([IT_CallView].[CallDesc],char(10),'') AS CallDesc ,"
    Sql &= "  [IT_CallView].[AssignedTo] ,"
		Sql &= "  [IT_CallView].[CallStatusID] ,"
		Sql &= "  [IT_CallView].[LoggedOn] ,"
		Sql &= "  [IT_CallView].[LoggedBy] ,"
		Sql &= "  [IT_CallView].[FirstAttendedOn] ,"
		Sql &= "  [IT_CallView].[ClosedOn] ,"
		Sql &= "  [IT_CallView].[FirstAttended] ,"
		Sql &= "  [IT_CallView].[Closed] ,"
		Sql &= "  [IT_CallView].[CallReceivedOn]  "
		Sql &= "  FROM [IT_CallView] "
		Sql &= "  WHERE"
		Sql &= "  [IT_CallView].[LoggedOn] >= Convert(datetime,'" & FromDate & "',103) AND [IT_CallView].[LoggedOn] <= convert(datetime,'" & ToDate & "',103) "
		Sql &= "  ORDER BY [IT_CallView].[CallID]"

		Return GetReportClass(Sql)
	End Function
	Private Shared Function GetReportClass(ByVal Sql As String) As List(Of SIS.ADM.IT_CallView)
		Dim Results As List(Of SIS.ADM.IT_CallView) = Nothing
		Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
			Using Cmd As SqlCommand = Con.CreateCommand()
				Cmd.CommandType = CommandType.Text
				Cmd.CommandText = Sql
				Cmd.CommandTimeout = 1200
				Results = New List(Of SIS.ADM.IT_CallView)
				Con.Open()
				Dim Reader As SqlDataReader = Cmd.ExecuteReader()
				While (Reader.Read())
					Results.Add(New SIS.ADM.IT_CallView(Reader))
				End While
				Reader.Close()
			End Using
		End Using
		Return Results

	End Function
	Sub New()
		'dummy
	End Sub
End Class
