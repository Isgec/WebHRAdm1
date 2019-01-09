Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ADM
	Partial Public Class admITEventProgress
		Public Property ForeColor() As System.Drawing.Color
			Get
				Dim cl As System.Drawing.Color = Drawing.Color.Red
				If _Responded Then
					cl = Drawing.Color.Green
				End If
				Return cl
			End Get
			Set(ByVal value As System.Drawing.Color)

			End Set
		End Property
		Public Shared Function UZ_Update(ByVal Record As SIS.ADM.admITEventProgress) As Int32
			If Record.ActionNotRequired Or Record.ActionTaken Then
				Record.Responded = True
			Else
				Record.Responded = False
			End If
			Dim _Result As Integer = Update(Record)
			If _Result > 0 Then
				Dim Completed As Boolean = True
				Dim oStss As List(Of SIS.ADM.admITEventStatus) = SIS.ADM.admITEventStatus.GetByEventID(Record.EventID, "")
				For Each sts As SIS.ADM.admITEventStatus In oStss
					If Not sts.Responded Then
						Completed = False
						Exit For
					End If
				Next
				If Completed Then
					Dim oEvent As SIS.ADM.admITEventTransactions = SIS.ADM.admITEventTransactions.GetByID(Record.EventID)
					oEvent.Completed = True
					oEvent.CompletedOn = Now
					SIS.ADM.admITEventTransactions.Update(oEvent)
				End If
			End If
			Return _Result
		End Function
	End Class
End Namespace
