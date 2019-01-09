Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ADM
	Partial Public Class admAttendComplaint
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
		Public Shared Sub CloseComplaint(ByVal CallID As Integer)
			Dim oCom As SIS.ADM.admLWComplaints = SIS.ADM.admLWComplaints.GetByID(CallID)
			If oCom IsNot Nothing Then
				oCom.Closed = True
				oCom.ClosedOn = Now
				oCom.CallStatusID = "CLOSED"
				SIS.ADM.admLWComplaints.Update(oCom)
				'Insert Close Auto Response
				Dim oRes As New SIS.ADM.admComplaintResponse
				With oRes
					.CallID = oCom.CallID
					.Remarks = "<b>CLOSED:</b> " & oCom.Description
					.AutoPosted = True
					.AttendedOn = Now
				End With
				SIS.ADM.admComplaintResponse.Insert(oRes)
			End If

		End Sub
	End Class
End Namespace
