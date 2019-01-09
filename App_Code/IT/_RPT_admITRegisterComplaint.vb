Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class RPT_admITRegisterComplaint
	Inherits SIS.SYS.ReportBase
	Private ReportWidth As Integer = 1300
	Public Overrides Sub ProcessReport()

		Dim EndUserID As String = Request.QueryString("enduserid")
		Dim AssignedTo As String = Request.QueryString("assignedto")
		Dim CallTypeID As String = Request.QueryString("calltypeid")
		Dim CallStatusID As String = Request.QueryString("callstatusid")

		Dim Hdr As String = ""


		Print("<table width=""" & ReportWidth & "px""><tr><td style=""text-align:center;font-size: 14px;font-weight:bold""><u>Registered Complaints</u></td></tr></table>")
		'		Print("<table width=""" & ReportWidth & "px""><tr><td style=""text-align:center;font-size: 12px;font-weight:bold"">" & oSer.ScheduleID.ToUpper & " REPORT DATED: " & oSht.SheetDate & "</td></tr></table>")
		'		Print("<table width=""" & ReportWidth & "px""><tr><td style=""text-align:center;font-size: 10px""><b>INITIATOR:</b>&nbsp;" & Ints & "&nbsp;&nbsp;<b>MONITOR:</b>&nbsp;" & Mons & "</td></tr></table>")
		Print("</br>")

		Dim sn As Integer = 0
		Dim pagelength As Integer = 30

		ColumnHeader()


		Dim dbPage As Integer = 0
		Dim dbSize As Integer = 10
		Dim dbOrder As String = ""
		Dim oCalls As List(Of SIS.ADM.admITRegisterComplaint) = Nothing
		Dim LastValue As String = ""

		Do While True
			oCalls = SIS.ADM.admITRegisterComplaint.SelectList(dbPage * dbSize, dbSize, dbOrder, False, "", EndUserID, CallTypeID, AssignedTo, CallStatusID)
			If oCalls.Count <= 0 Then
				Exit Do
			End If
			dbPage += 1

			For Each det As SIS.ADM.admITRegisterComplaint In oCalls
				sn += 1

				Print("<tr>")
				Print("<td style=""font-size:8px;text-align:right"">" & sn.ToString & "</td>")
				Print("<td style=""font-size:8px;text-align:right"">" & det.CallID & "</td>")
				Print("<td style=""font-size:8px;text-align:left"">[" & det.EndUserID & "] " & det.FK_ADM_ITComplaints_HRM_Employees.EmployeeName & "</td>")
				Print("<td style=""font-size:8px;text-align:left"">" & det.FK_ADM_ITComplaints_ADM_ITCallTypes.Description & "</td>")
				Print("<td style=""font-size:8px;text-align:left"">" & det.Description & "</td>")
				Print("<td style=""font-size:8px;text-align:left"">" & det.FK_ADM_ITComplaints_ADM_Users1.UserFullName & "</td>")
				Print("<td style=""font-size:8px;text-align:left"">" & det.LoggedOn & "</td>")
				Print("<td style=""font-size:8px;text-align:left"">" & det.LoggedOn.Substring(0, 5) & "</td>")
				Print("<td style=""font-size:8px;text-align:left"">" & det.FK_ADM_ITComplaints_ADM_Users.UserFullName & "</td>")
				Print("<td style=""font-size:8px;text-align:left"">" & det.FirstAttendedOn & "</td>")
				Print("<td style=""font-size:8px;text-align:left"">" & det.ClosedOn & "</td>")
				Print("</tr>")

			Next
		Loop
		Print("</table>")

		Print("</br>")
		Print("</br>")

	End Sub
	Private Sub ColumnHeader()

		Print("</br>")
		Print("<table border=""1pt"" width=""" & ReportWidth & "px"">")

		Print("<tr>")
		Print("<td style=""font-size:10px;font-weight:bold;width:30px;text-align:right;vertical-align:top"">S.N.</td>")
		Print("<td style=""font-size:10px;font-weight:bold;width:30px;text-align:right;vertical-align:top"">ID</td>")
		Print("<td style=""font-size:10px;font-weight:bold;width:160px;vertical-align:top"">END USER</td>")
		Print("<td style=""font-size:10px;font-weight:bold;width:60px;vertical-align:top"">CALL TYPE</td>")
		Print("<td style=""font-size:10px;font-weight:bold;width:260px;vertical-align:top"">DESCRIPTION</td>")
		Print("<td style=""font-size:10px;font-weight:bold;width:140px;vertical-align:top"">ASSIGNED TO</td>")
		Print("<td style=""font-size:10px;font-weight:bold;width:80px;vertical-align:top"">LOGGED ON</td>")
		Print("<td style=""font-size:10px;font-weight:bold;width:40px;vertical-align:top"">DD/MM</td>")
		Print("<td style=""font-size:10px;font-weight:bold;width:140px;vertical-align:top"">LOGGED BY</td>")
		Print("<td style=""font-size:10px;font-weight:bold;width:80px;vertical-align:top"">ATTENDED ON</td>")
		Print("<td style=""font-size:10px;font-weight:bold;width:80px;vertical-align:top"">CLOSED ON</td>")
		Print("</tr>")

	End Sub
	Public Sub New(ByVal Context As HttpContext)
		SetContext = Context
	End Sub
End Class
