Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ADM
	Partial Public Class admInitiatorSheetDetails
		Public ReadOnly Property Forecolor() As System.Drawing.Color
			Get
				Dim cl As System.Drawing.Color = Drawing.Color.Green
				If _ProblemIdentified Then
					cl = Drawing.Color.Red
					If _ProblemClosed Then
						cl = Drawing.Color.Purple
					End If
				ElseIf Not _Initiated And Not _Monitored Then
					If _ScheduleID.ToLower <> "daily" Then
						cl = Drawing.Color.Magenta
					Else
						cl = Drawing.Color.Goldenrod
					End If
				End If
				Return cl
			End Get
		End Property
		Public Shared Function UZ_Update(ByVal Record As SIS.ADM.admInitiatorSheetDetails) As Int32
			If Record.InitiatorRemarks = String.Empty Then
				Return 0
			End If
			Dim _Result As Integer = Update(Record)
			If _Result > 0 Then
				'************
				Record = SIS.ADM.admInitiatorSheetDetails.GetByID(Record.SheetID, Record.SerialNo)
				Dim chk As SIS.ADM.admCheckPoints = SIS.ADM.admCheckPoints.GetByID(Record.CheckPointID)
				If chk.LastEntryUpdatedOn <> String.Empty Then
					If Convert.ToDateTime(chk.LastEntryUpdatedOn) < Now Then
						chk.LastEntryUpdated = True
						chk.LastEntryUpdatedOn = Now
						SIS.ADM.admCheckPoints.UpdateData(chk)
					End If
				Else
					chk.LastEntryUpdated = True
					chk.LastEntryUpdatedOn = Now
					SIS.ADM.admCheckPoints.UpdateData(chk)
				End If
				'**************
				Dim oShtDets As List(Of SIS.ADM.admMonitorSheetDetails) = SIS.ADM.admMonitorSheetDetails.SelectList(0, 999, Record.SheetID, "", False, "")
				Dim Completed As Boolean = True
				For Each oShtDet As SIS.ADM.admMonitorSheetDetails In oShtDets
					With oShtDet
						If Not .Initiated And Not .Monitored Then
							Completed = False
							Exit For
						End If
					End With
				Next
				Dim osht As SIS.ADM.admInitiatorSheetHeader = SIS.ADM.admInitiatorSheetHeader.GetByID(Record.SheetID)
				osht.Initiated = Completed
				osht.ProblemIdentified = Record.ProblemIdentified
				SIS.ADM.admInitiatorSheetHeader.Update(osht)
			End If
			Return _Result
		End Function

		Public Shared Function SelectList(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal SheetID As Int32, ByVal orderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.ADM.admInitiatorSheetDetails)
			Dim Results As List(Of SIS.ADM.admInitiatorSheetDetails) = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spadm_LG_InitiatorSheetDetailsSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spadm_LG_InitiatorSheetDetailsSelectListFilteres"
					End If
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SheetID", SqlDbType.Int, SheetID.ToString.Length, SheetID)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@startRowIndex", SqlDbType.Int, -1, startRowIndex)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@maximumRows", SqlDbType.Int, -1, maximumRows)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
					Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
					Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
					_RecordCount = -1
					Results = New List(Of SIS.ADM.admInitiatorSheetDetails)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results.Add(New SIS.ADM.admInitiatorSheetDetails(Reader))
					End While
					Reader.Close()
					_RecordCount = Cmd.Parameters("@RecordCount").Value
				End Using
			End Using
			Return Results
		End Function
		Public Shared Function SelectCount(ByVal SheetID As Int32, ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
			Return _RecordCount
		End Function
	End Class
End Namespace
