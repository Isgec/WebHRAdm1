Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class RPT_asmTransferGatePass
	Inherits SIS.SYS.ReportBase
	Private ReportWidth As Integer = 700
	Public Overrides Sub ProcessReport()

		'	Dim TransferID As String = Request.QueryString("transferid")

		'	Dim oTrnf As SIS.ASM.asmAstLWTransferHeader = SIS.ASM.asmAstLWTransferHeader.GetByID(TransferID)


		'	Dim tHdr As String = ""
		'	Select Case oTrnf.TransferStatusID
		'		Case "Free"
		'			tHdr = "PROVISIONAL OUTWARD GATE PASS"
		'		Case "Transfered"
		'			tHdr = "OUTWARD GATE PASS [Material Transfered - Not for use]"
		'		Case "Cancelled"
		'			tHdr = "OUTWARD GATE PASS [Cancelled - Not for use]"
		'		Case Else
		'			tHdr = "OUTWARD GATE PASS"
		'	End Select
		'	Print("<table width=""" & ReportWidth & "px"">")
		'	Print("<tr>")
		'	Print("<td rowspan=""5"" style=""text-align: left; width: 106px;""><input type=""image"" id=""logo"" alt=""ijtlogo"" src=""../../images/sislogo.png"" style=""height:56;width:104"" /></td>")
		'	Print("<td rowspan=""5"" style=""text-align: left;font-size: 14px;font-weight:bold"">Isgec Heavy Engineering Limited</td>")
		'	Print("<td style=""font-size:10px;text-align:right"">&nbsp;</td>")
		'	Print("</tr>")
		'	Print("<tr><td style=""font-size:10px;text-align:right"">A-4, SECTOR-24, NOIDA</td></tr>")
		'	Print("<tr><td style=""font-size:10px;text-align:right"">Utterpradesh, INDIA-201 301</td></tr>")
		'	Print("<tr><td style=""font-size:10px;text-align:right"">Phone: +91-120-3302001</td></tr>")
		'	Print("<tr><td style=""font-size:10px;text-align:right"">Fax: +91-120-3302100</td></tr>")
		'	Print("</table>")
		'	Print("</br>")
		'	Print("<table width=""" & ReportWidth & "px""><tr><td style=""text-align: center""><h3><u>" & tHdr & "</u></h3></td></tr></table>")
		'	Print("</br>")


		'	Print("<table width=""" & ReportWidth & "px"">")
		'	Print("<tr>")
		'	Print("<td style=""text-align:left""><b>SERIAL NO :</b>&nbsp;" & oTrnf.TransferID & "</td>")
		'	Print("<td style=""text-align:right""><b>DATE :</b>&nbsp;" & oTrnf.T_ApprovedOn & "</td>")
		'	Print("</tr>")
		'	Print("</table>")


		'	Print("<table width=""" & ReportWidth & "px"">")
		'	Print("<tr>")
		'	Print("<td style=""text-align:left"">TO LOCATION :&nbsp;" & SIS.ASM.asmOffices.GetByID(oTrnf.TransferTo).Description & "</td>")
		'	Print("<td style=""text-align:right"">FROM :&nbsp;" & SIS.ASM.asmOffices.GetByID(oTrnf.TransferFrom).Description & "</td>")
		'	Print("</tr>")
		'	Print("</table>")




		'	Print("<table width=""" & ReportWidth & "px"">")
		'	Print("<tr>")
		'	Print("<td style=""text-align:left"">TYPE :&nbsp;<b>" & IIf(oTrnf.Returnable, "RETURNABLE", "TRANSFER") & "</b></td>")
		'	Print("<td style=""text-align:right"">" & IIf(oTrnf.Returnable, "DATE OF RETURN :&nbsp;" & IIf(oTrnf.Returnable, oTrnf.ExpectedDate, "&nbsp;"), "&nbsp;") & "</td>")
		'	Print("</tr>")
		'	Print("</table>")

		'	Print("</br>")

		'	Print("<table width=""" & ReportWidth & "px"">")
		'	Print("<tr>")
		'	Print("<td style="" width:15%""><b>PURPOSE :</b></td>")
		'	Print("<td style="" width:85%"">" & oTrnf.TransferRemarks & "</td>")
		'	Print("</tr>")
		'	Print("</table>")


		'	Dim sn As Integer = 0
		'	Dim pagelength As Integer = 30

		'	ColumnHeader()

		'	Dim oAsts As List(Of SIS.ASM.asmAstLWTransferDetails) = SIS.ASM.asmAstLWTransferDetails.GetByTransferID(oTrnf.TransferID, "")

		'	For Each ast As SIS.ASM.asmAstLWTransferDetails In oAsts
		'		sn += 1

		'		Print("<tr>")
		'		Print("<td style=""text-align:right;padding-top:10px"">" & sn.ToString & "</td>")
		'		Print("<td style=""text-align:right;padding-top:10px"">" & ast.AssetID.ToString & "</td>")
		'		Print("<td style=""text-align:left;padding-top:10px""><b>" & SIS.ASM.asmAstTypes.GetByID(ast.AssetTypeID).Description & ",</b>&nbsp;<i>Make:</i>&nbsp;" & SIS.ASM.asmAstBrands.GetByID(ast.BrandID).Description & ",&nbsp;<i>Serial No:</i>&nbsp;" & ast.AssetSerialNo & "</td>")
		'		Print("<td style=""text-align:center;padding-top:10px"">1</td>")
		'		Print("</tr>")
		'		'Print("<tr style=""border-top:none"" >")
		'		'Print("<td style=""text-align:right;border-top:none"">&nbsp;</td>")
		'		'Print("<td style=""text-align:right;border-top:none"">&nbsp;</td>")
		'		'Print("<td style=""border-top:none""><b>Serial No.:" & ast.AssetSerialNo & "</b>&nbsp;</td>")
		'		'Print("<td style=""text-align:right;border-top:none"">&nbsp;</td>")
		'		'Print("</tr>")

		'	Next
		'	'print blank rows if items are less than 10
		'	For i As Integer = oAsts.Count To 10
		'		Print("<tr><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr>")
		'	Next

		'	Print("</table>")

		'	Print("<table width=""" & ReportWidth & "px""><tr><td style=""font-size:10px;text-align:left;width:60px"">Triplicate:-</td><td style=""font-size:10px;text-align:left"">Security</td></tr></table>")
		'	Print("<table width=""" & ReportWidth & "px""><tr><td style=""font-size:10px;text-align:left;width:60px"">&nbsp;</td><td style=""font-size:10px;text-align:left"">Concerned Department</td></tr></table>")
		'	Print("<table width=""" & ReportWidth & "px""><tr><td style=""font-size:10px;text-align:left;width:60px"">&nbsp;</td><td style=""font-size:10px;text-align:left"">Person Taking the goods</td></tr></table>")


		'	Dim aprvbBy As String = "&nbsp;"
		'	If oTrnf.T_ApprovedBy <> "" Then
		'		aprvbBy = SIS.ASM.asmEmployees.GetByID(oTrnf.T_ApprovedBy).EmployeeName
		'	End If
		'	Print("<table width=""" & ReportWidth & "px""><tr><td align=""right"">________</td><td align=""right"" width=""150px"">________</td><td align=""right"" width=""150px"">___________</td></tr>")
		'	Print("<tr><td align=""right"">Security</td><td align=""right"" width=""150px"">Taken By</td><td align=""right"" width=""150px"">Approved By</td></tr>")
		'	Print("<tr><td align=""right"">&nbsp;</td><td align=""right"" width=""150px""><b>" & oTrnf.T_TakenBy & "</b></td><td align=""right"" width=""150px""><b>" & aprvbBy & "</b></td></tr></table>")


		'	Print("</br>")
		'	Print("</br>")




		'End Sub
		'Private Sub ColumnHeader()

		'	Print("</br>")

		'	'Print("<table border=""1pt"" cellspacing=""0pt"" cellpadding=""0pt"" width=""" & ReportWidth & "px"">")
		'	'Print("<table border=""1pt"" width=""" & ReportWidth & "px"">")
		'	Print("<table border=""1pt"" rules=""cols"" width=""" & ReportWidth & "px"">")

		'	Print("<tr>")
		'	Print("<td style=""font-size: 12px;font-weight:bold;width:30px;text-align:right;vertical-align: top;border-bottom: solid 1pt black"">S.N.</td>")
		'	Print("<td style=""font-size: 12px;font-weight:bold;width:30px;text-align:right;vertical-align: top;border-bottom: solid 1pt black"">I.D.</td>")
		'	Print("<td style=""font-size: 12px;font-weight:bold;width:600px;vertical-align: top;border-bottom: solid 1pt black"">ITEM</td>")
		'	Print("<td style=""font-size: 12px;font-weight:bold;width:40px;vertical-align: top;border-bottom: solid 1pt black"">QTY.</td>")
		'	Print("</tr>")

	End Sub
	Public Sub New(ByVal Context As HttpContext)
		SetContext = Context
	End Sub
End Class
