Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Net.Mail
Imports System.Web.Mail
Namespace SIS.ADM
	Partial Public Class admITAttendComplaint
		Public Property Enabled() As Boolean
			Get
				Return _FirstAttended
			End Get
			Set(ByVal value As Boolean)

			End Set
		End Property
		Public Property Visible() As Boolean
			Get
				Return Not _Closed
			End Get
			Set(ByVal value As Boolean)

			End Set
		End Property
		Public Property ForeColor() As System.Drawing.Color
			Get
				Dim cl As System.Drawing.Color = Drawing.Color.Red
				Select Case _CallStatusID
					Case "FREE"
						cl = Drawing.Color.Red
					Case "ATTENDED"
						cl = Drawing.Color.Green
					Case "CLOSED"
						cl = Drawing.Color.Blue
				End Select
				Return cl
			End Get
			Set(ByVal value As System.Drawing.Color)

			End Set
		End Property
		Public Shared Sub CloseComplaint(ByVal CallID As Integer, Optional ByVal sendMail As Boolean = True)
			Dim oCom As SIS.ADM.admLWITComplaints = SIS.ADM.admLWITComplaints.GetByID(CallID)
			If oCom IsNot Nothing Then
				oCom.Closed = True
				oCom.ClosedOn = Now
				oCom.CallStatusID = "CLOSED"
				SIS.ADM.admLWITComplaints.Update(oCom)
				'Insert Close Auto Response
				Dim oRes As New SIS.ADM.admITComplaintResponse
				With oRes
					.CallID = oCom.CallID
					.Remarks = "<b>CLOSED:</b> " & oCom.Description
					.AutoPosted = True
					.AttendedOn = Now
				End With
				SIS.ADM.admITComplaintResponse.Insert(oRes)

				If Not sendMail Then Exit Sub

				Dim FromEMailID As String = SIS.ADM.admITCallTypes.GetByID(oCom.CallTypeID).Description
				Dim ToEMailID As String = SIS.SYS.Utilities.GlobalVariables.GetEMailID(oCom.EndUserID)
				Dim CCEMailID As String = SIS.SYS.Utilities.GlobalVariables.GetEMailID(oCom.AssignedTo)
				If ToEMailID <> String.Empty Then
					Try
						Dim oClient As SmtpClient = New SmtpClient()

						Dim oMsg As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage("itinfrasupport@isgec.co.in", ToEMailID)
						With oMsg
							.IsBodyHtml = True
							.CC.Add(CCEMailID)
							.CC.Add("itinfrasupport@isgec.co.in")
							.Subject = "Your Service Request " & oCom.CallID & " is Closed"
							Dim mFile As String = HttpContext.Current.Server.MapPath("~/") & "CallClose.mail"
							Dim tr As IO.StreamReader = New IO.StreamReader(mFile)
							Dim mStr As String = tr.ReadToEnd
							tr.Close()

							mStr = mStr.Replace("<CallID>", oCom.CallID)
							mStr = mStr.Replace("<CallDescription>", oCom.Description)
							mStr = mStr.Replace("<FeedBack>", "<a href=""" & HttpContext.Current.Request.Url.Scheme & System.Uri.SchemeDelimiter & HttpContext.Current.Request.Url.Authority & VirtualPathUtility.ToAbsolute("~/FeedBack.aspx") & "?callid=" & oCom.CallID & """>Feed Back</a>")

							.Body = mStr
						End With
						oClient.Send(oMsg)

					Catch ex As Exception

					End Try
				End If


			End If

		End Sub
	End Class
End Namespace
