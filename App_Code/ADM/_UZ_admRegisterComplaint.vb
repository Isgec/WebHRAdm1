Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Net.Mail
Imports System.Web.Mail
Namespace SIS.ADM
	Partial Public Class admRegisterComplaint
		Private _SendMail As Boolean = True
		Public Property SendMail() As Boolean
			Get
				Return _SendMail
			End Get
			Set(ByVal value As Boolean)
				_SendMail = value
			End Set
		End Property
		Public Property Disabled() As Boolean
			Get
				Return Not _FirstAttended
			End Get
			Set(ByVal value As Boolean)

			End Set
		End Property
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
		Public Shared Function UZ_Delete(ByVal Record As SIS.ADM.admRegisterComplaint) As Int32
			Dim oCal As SIS.ADM.admRegisterComplaint = SIS.ADM.admRegisterComplaint.GetByID(Record.CallID)
			If Not oCal.FirstAttended Then
				Dim oRes As List(Of SIS.ADM.admComplaintResponse) = SIS.ADM.admComplaintResponse.GetByCallID(Record.CallID, "")
				For Each res As SIS.ADM.admComplaintResponse In oRes
					SIS.ADM.admComplaintResponse.Delete(res)
				Next
				Return Delete(Record)
			End If
			Throw New Exception("<b>CALL ID:</b>" & Record.CallID & " is ATTENDED, can not be deleted.")
		End Function
		Public Shared Function UZ_Insert(ByVal Record As SIS.ADM.admRegisterComplaint) As Int32
			Dim _Result As Int32 = Insert(Record)
			Dim MaySendMail As Boolean = Record.SendMail
			If _Result > 0 Then
				Record = SIS.ADM.admRegisterComplaint.GetByID(_Result)
				'Insert Initial Auto Response
				Dim oRes As New SIS.ADM.admComplaintResponse
				With oRes
					.CallID = Record.CallID
					.Remarks = "<b>LOGGED:</b> " & Record.Description
					.AutoPosted = True
					.AttendedOn = Now
				End With
				SIS.ADM.admComplaintResponse.Insert(oRes)
				'SendMail
				If MaySendMail Then
					Dim ToEMailID As String = SIS.SYS.Utilities.GlobalVariables.GetEMailID(Record.EndUserID)
					Dim CCEMailID As String = SIS.SYS.Utilities.GlobalVariables.GetEMailID(Record.AssignedTo)
					If ToEMailID <> String.Empty Then
						Try
							Dim oClient As SmtpClient = New SmtpClient()

							Dim oMsg As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage(Record.FK_ADM_Complaints_ADM_CallTypes.DisplayField.Trim, ToEMailID)
							With oMsg
								.IsBodyHtml = True
								'.To.Add(ToEMailID)
								.CC.Add(CCEMailID)
								.CC.Add(Record.FK_ADM_Complaints_ADM_CallTypes.DisplayField.Trim)
								.Subject = "ADMIN Helpdesk"
								Dim mFile As String = HttpContext.Current.Server.MapPath("~/") & "Helpdesk.mail"
								Dim tr As IO.StreamReader = New IO.StreamReader(mFile)
								Dim mStr As String = tr.ReadToEnd
								tr.Close()

								mStr = mStr.Replace("<attendername>", Record.FK_ADM_Complaints_ADM_Users1.DisplayField)
								mStr = mStr.Replace("<username>", Record.FK_ADM_Complaints_HRM_Employees.DisplayField)
								mStr = mStr.Replace("<loggername>", Record.FK_ADM_Complaints_ADM_Users.DisplayField)
								mStr = mStr.Replace("<loggedon>", Record.LoggedOn)
								mStr = mStr.Replace("<CallID>", Record.CallID)
								mStr = mStr.Replace("<Details>", Record.Description)

								.Body = mStr
							End With
							oClient.Send(oMsg)

						Catch ex As Exception

						End Try
					End If

				End If

			End If
			Return _Result
		End Function
	End Class
End Namespace
