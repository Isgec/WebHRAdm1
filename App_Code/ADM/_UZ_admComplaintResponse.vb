Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ADM
	Partial Public Class admComplaintResponse
		Public Shared Function UZ_Insert(ByVal Record As SIS.ADM.admComplaintResponse) As Int32
			Dim _Result As Int32 = Insert(Record)
			If _Result > 0 Then
				Dim oCom As SIS.ADM.admLWComplaints = SIS.ADM.admLWComplaints.GetByID(Record.CallID)
				If Not oCom.FirstAttended Then
					oCom.FirstAttended = True
					oCom.CallStatusID = "ATTENDED"
					oCom.FirstAttendedOn = Now
					SIS.ADM.admLWComplaints.Update(oCom)
				End If
			End If
			Return _Result
		End Function
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
