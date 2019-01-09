Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Net.Mail
Imports System.Web.Mail

Namespace SIS.ADM
  Partial Public Class admITComplaintResponse
    Public Property F_sendMail As Boolean = False
    Public Property F_AssignedTo As String = ""
    Public Shared Function UZ_Insert(ByVal Record As SIS.ADM.admITComplaintResponse) As Int32
      Dim _Result As Int32 = Insert(Record)
      Record.SerialNo = _Result
      If _Result > 0 Then
        Dim oCom As SIS.ADM.admLWITComplaints = SIS.ADM.admLWITComplaints.GetByID(Record.CallID)
        If Not oCom.FirstAttended Then
          oCom.FirstAttended = True
          oCom.CallStatusID = "ATTENDED"
          oCom.FirstAttendedOn = Now
          SIS.ADM.admLWITComplaints.Update(oCom)
        End If
      End If
      SendMail(Record)
      Return _Result
    End Function
    Private Shared Sub SendMail(ByVal Record As SIS.ADM.admITComplaintResponse)

      If Record.F_sendMail Then
        If Record.F_AssignedTo <> String.Empty Then
          Dim oCal As SIS.ADM.admITRegisterComplaint = SIS.ADM.admITRegisterComplaint.GetByID(Record.CallID)
          Dim LastAssignedTo As String = oCal.AssignedTo
          Dim LastAssingnedName As String = oCal.FK_ADM_ITComplaints_ADM_Users1.UserFullName
          oCal.AssignedTo = Record.F_AssignedTo
          SIS.ADM.admITRegisterComplaint.Update(oCal)

          Dim ToEMailID As String = SIS.SYS.Utilities.GlobalVariables.GetEMailID(oCal.AssignedTo)
          Dim FromMailID As String = SIS.SYS.Utilities.GlobalVariables.GetEMailID(LastAssignedTo)
          If ToEMailID <> String.Empty Then
            Try
              Dim oClient As SmtpClient = New SmtpClient()
              Dim oMsg As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage(FromMailID, ToEMailID)
              With oMsg
                .IsBodyHtml = True
                .Subject = "Call Escalation/Forward for Call Reference No: " & oCal.CallID
                Dim mFile As String = HttpContext.Current.Server.MapPath("~/") & "CallForward.mail"
                Dim tr As IO.StreamReader = New IO.StreamReader(mFile)
                Dim mStr As String = tr.ReadToEnd
                tr.Close()

                mStr = mStr.Replace("<attendername>", LastAssingnedName)
                mStr = mStr.Replace("<CallID>", oCal.CallID)
                mStr = mStr.Replace("<Details>", Record.Remarks)


                '.Body = mStr
                Dim lgLk As New System.Net.Mail.LinkedResource(HttpContext.Current.Server.MapPath("~/Images/IsgecISSCTeInvite.jpg"), "image/jpeg")
                lgLk.TransferEncoding = Net.Mime.TransferEncoding.Base64
                lgLk.ContentId = "image1"

                Dim lgAv As Net.Mail.AlternateView = System.Net.Mail.AlternateView.CreateAlternateViewFromString(mStr, Nothing, "text/html")
                lgAv.LinkedResources.Add(lgLk)

                .AlternateViews.Add(lgAv)
              End With

              oClient.Send(oMsg)

            Catch ex As Exception
              Throw New Exception(ex.Message)
            End Try
          End If


        End If
      End If


    End Sub
    Public ReadOnly Property NotSystem() As Boolean
      Get
        Return Not _AutoPosted
      End Get
    End Property
    Public ReadOnly Property ForeColor() As System.Drawing.Color
      Get
        If _AutoPosted Then
          Return Drawing.Color.Red
        End If
        Return Drawing.Color.Green
      End Get
    End Property
  End Class
End Namespace
