Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class RPT_admMonitorSheet
	Inherits SIS.SYS.ReportBase
	Private ReportWidth As Integer = 700
	Public Overrides Sub ProcessReport()

		Dim SheetID As String = Request.QueryString("sheetid")

		Dim Hdr As String = ""

		Dim oSht As SIS.ADM.admLWServiceSheetHeader = SIS.ADM.admLWServiceSheetHeader.GetByID(SheetID)
		Dim oSer As SIS.ADM.admServices = SIS.ADM.admServices.GetByID(oSht.ServiceID)
		Dim oInts As List(Of SIS.ADM.admInitiators) = SIS.ADM.admInitiators.GetByServiceID(oSht.ServiceID, "")
		Dim oMons As List(Of SIS.ADM.admMonitors) = SIS.ADM.admMonitors.GetByServiceID(oSht.ServiceID, "")

		Dim Ints As String = ""
		For Each oInt As SIS.ADM.admInitiators In oInts
			If Ints = String.Empty Then
				Ints = oInt.FK_ADM_Initiators_HRM_Employees.DisplayField
			Else
				Ints = Ints & ", " & oInt.FK_ADM_Initiators_HRM_Employees.DisplayField
			End If
		Next
		Dim Mons As String = ""
		For Each oMon As SIS.ADM.admMonitors In oMons
			If Mons = String.Empty Then
				Mons = oMon.FK_ADM_Monitors_HRM_Employees.DisplayField
			Else
				Mons = Mons & ", " & oMon.FK_ADM_Monitors_HRM_Employees.DisplayField
			End If
		Next

		Print("<table width=""" & ReportWidth & "px""><tr><td style=""text-align:center;font-size: 14px;font-weight:bold""><u>" & oSer.Description & "</u></td></tr></table>")
		Print("<table width=""" & ReportWidth & "px""><tr><td style=""text-align:center;font-size: 12px;font-weight:bold"">" & oSer.ScheduleID.ToUpper & " REPORT DATED: " & oSht.SheetDate & "</td></tr></table>")
		Print("<table width=""" & ReportWidth & "px""><tr><td style=""text-align:center;font-size: 10px""><b>INITIATOR:</b>&nbsp;" & Ints & "&nbsp;&nbsp;<b>MONITOR:</b>&nbsp;" & Mons & "</td></tr></table>")
		Print("</br>")

		Dim sn As Integer = 0
		Dim pagelength As Integer = 30

		ColumnHeader()


		Dim dbPage As Integer = 0
		Dim dbSize As Integer = 10
		Dim dbOrder As String = ""
		Dim oShtDets As List(Of SIS.ADM.admMonitorSheetDetails) = Nothing
		Dim LastValue As String = ""

		Do While True
			oShtDets = SIS.ADM.admMonitorSheetDetails.SelectList(dbPage * dbSize, dbSize, oSht.SheetID, dbOrder, False, "")
			If oShtDets.Count <= 0 Then
				Exit Do
			End If
			dbPage += 1

			For Each det As SIS.ADM.admMonitorSheetDetails In oShtDets
				sn += 1

				Print("<tr>")
				Print("<td style=""font-size:8px;text-align:right"">" & sn.ToString & "</td>")
				Print("<td style=""font-size:8px;text-align:left"">" & det.FK_ADM_ServiceSheetDetails_ADM_CheckPoints.Descriptions & "</td>")
				Print("<td style=""font-size:8px;text-align:left"">" & det.FK_ADM_ServiceSheetDetails_ADM_ServiceSheetDetails.Description & "</td>")
				Print("<td style=""font-size:8px;text-align:left"">" & det.FK_ADM_ServiceSheetDetails_ADM_ServiceSheetDetails.MonitoringMechanism & "</td>")
				Print("<td style=""font-size:8px;text-align:left"">" & det.FK_ADM_ServiceSheetDetails_HRM_Employees.EmployeeName & "</td>")
				Print("<td style=""font-size:8px;text-align:left"">" & det.InitiatorRemarks & "</td>")
				If det.ProblemIdentified Then
					Print("<td style=""font-size:8px;text-align:left"">YES</td>")
				Else
					Print("<td style=""font-size:8px;text-align:left"">NO</td>")
				End If
				Print("<td style=""font-size:8px;text-align:left"">" & det.FK_ADM_ServiceSheetDetails_HRM_Employees1.EmployeeName & "</td>")
				Print("<td style=""font-size:8px;text-align:left"">" & det.MonitorRemarks & "</td>")
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
		Print("<td style=""font-size:10px;font-weight:bold;width:30px;text-align:right;vertical-align:top"">CHECKPOINTS</td>")
		Print("<td style=""font-size:10px;font-weight:bold;width:60px;vertical-align:top"">POINTS TO CHECK</td>")
		Print("<td style=""font-size:10px;font-weight:bold;width:60px;vertical-align:top"">MONITORING MECHANISM</td>")
		Print("<td style=""font-size:10px;font-weight:bold;width:60px;vertical-align:top"">CHECKED BY</td>")
		Print("<td style=""font-size:10px;font-weight:bold;width:60px;vertical-align:top"">REMARKS</td>")
		Print("<td style=""font-size:10px;font-weight:bold;width:40px;vertical-align:top"">PROBLEM IDENTIFIED</td>")
		Print("<td style=""font-size:10px;font-weight:bold;width:60px;vertical-align:top"">MONITORED BY</td>")
		Print("<td style=""font-size:10px;font-weight:bold;width:60px;vertical-align:top"">REMARKS</td>")
		Print("</tr>")

	End Sub
	Public Sub New(ByVal Context As HttpContext)
		SetContext = Context
	End Sub
End Class
