Imports System.Data.SqlClient
Namespace SIS.SYS.Utilities
	Partial Public Class ApplicationSpacific
		Public Shared Sub GenerateSheet(ByVal FromDate As DateTime, ByVal ToDate As DateTime, ByVal ServiceID As String)
			Dim DataDate As DateTime = FromDate
			Do While DataDate <= ToDate
				Try
					GenerateSheet(DataDate, ServiceID)
				Catch ex As Exception
					Throw New Exception("Error During Sheet Creation. Service ID:" & ServiceID & ", Date: " & DataDate.ToString("dd/MM/yyyy"))
				End Try
				DataDate = DataDate.AddDays(1)
			Loop
		End Sub
		Public Shared Sub GenerateSheet(ByVal FromDate As DateTime, ByVal ToDate As DateTime)
			Dim DataDate As DateTime = FromDate
			Dim oSrvs As List(Of SIS.ADM.admServices) = SIS.ADM.admServices.SelectList("")
			Do While DataDate <= ToDate
				For Each oSrv As SIS.ADM.admServices In oSrvs
					Try
						GenerateSheet(DataDate, oSrv.ServiceID)
					Catch ex As Exception
						Throw New Exception("Error During Sheet Creation. Service ID:" & oSrv.ServiceID & ", Date: " & DataDate.ToString("dd/MM/yyyy"))
					End Try
				Next
				DataDate = DataDate.AddDays(1)
			Loop
		End Sub
		Public Shared Sub GenerateSheet(ByVal DataDate As DateTime)
			Dim oSrvs As List(Of SIS.ADM.admServices) = SIS.ADM.admServices.SelectList("")
			For Each oSrv As SIS.ADM.admServices In oSrvs
				Try
					GenerateSheet(DataDate, oSrv.ServiceID)
				Catch ex As Exception
					Throw New Exception("Error During Sheet Creation. Service ID:" & oSrv.ServiceID & ", Date: " & DataDate.ToString("dd/MM/yyyy"))
				End Try
			Next
		End Sub
		Public Shared Sub GenerateSheet_old(ByVal DataDate As DateTime, ByVal ServiceID As String)
			Dim ci As System.Globalization.CultureInfo = New System.Globalization.CultureInfo("en-GB", True)
			If DateValue(DataDate) < DateValue(Now) Then
				Throw New Exception("Invalid Date.")
			End If
			Dim oSht As SIS.ADM.admLWServiceSheetHeader = SIS.ADM.admLWServiceSheetHeader.GetByServiceDate(DataDate, ServiceID)
			Dim mayContinue As Boolean = True
			If oSht Is Nothing Then
				mayContinue = False
				Dim oSrv As SIS.ADM.admServices = SIS.ADM.admServices.GetByID(ServiceID)
				Dim txtLDt As String = oSrv.LastSheetDate
				Dim LDt As DateTime = Now.AddDays(1)
				If txtLDt <> String.Empty Then
					LDt = Convert.ToDateTime(txtLDt, ci)
				End If
				Dim oShd As SIS.ADM.admSchedules = SIS.ADM.admSchedules.GetByID(oSrv.ScheduleID)

				Select Case oShd.ScheduleID.ToLower
					Case "daily"
						mayContinue = True
					Case "weekly"
						If txtLDt <> String.Empty Then
							If DateDiff(DateInterval.Day, LDt, DataDate) Mod 7 = 0 Then
								mayContinue = True
							End If
						Else
							mayContinue = True
						End If
					Case "fortnightly"
						If DataDate.Day = 1 Or DataDate.Day = 15 Then
							mayContinue = True
						End If
					Case "monthly"
						If DataDate.Day = 1 Then
							mayContinue = True
						End If
					Case "quarterly"
						If DataDate.Day = 1 And (DataDate.Month = 1 Or DataDate.Month = 3 Or DataDate.Month = 6 Or DataDate.Month = 9) Then
							mayContinue = True
						End If
					Case "halfyearly"
						If DataDate.Day = 1 And (DataDate.Month = 1 Or DataDate.Month = 6) Then
							mayContinue = True
						End If
					Case "yearly"
						If DataDate.Day = 1 And DataDate.Month = 1 Then
							mayContinue = True
						End If
				End Select
				If mayContinue Then
					oSht = New SIS.ADM.admLWServiceSheetHeader
					With oSht
						.SheetDate = DataDate
						.Description = oSrv.Description.Trim & " : " & oShd.Description.Trim & " : " & DataDate.ToString("dd/MM/yyyy")
						.ServiceID = ServiceID
						.ScheduleID = oShd.ScheduleID
					End With
					oSht.SheetID = SIS.ADM.admLWServiceSheetHeader.Insert(oSht)
				End If
			End If
			'===============================
			'===============================
			'===============================
			If Not mayContinue Then Exit Sub
			'===============================
			'===============================
			'===============================
			Try
				If Not oSht.Initiated Then
					Dim oShtMsrs As List(Of SIS.ADM.admLWServiceSheetDetails) = SIS.ADM.admLWServiceSheetDetails.GetBySheetID(oSht.SheetID, "")
					For Each oShtMsr As SIS.ADM.admLWServiceSheetDetails In oShtMsrs
						SIS.ADM.admLWServiceSheetDetails.Delete(oShtMsr)
					Next
				End If
				'Re fetch and insert all measures
				Dim oSrvChkPTs As List(Of SIS.ADM.admServiceCheckPoints) = SIS.ADM.admServiceCheckPoints.GetByServiceID(ServiceID, "")
				For Each oSrvChkPt As SIS.ADM.admServiceCheckPoints In oSrvChkPTs
					Dim oChkPTMsrs As List(Of SIS.ADM.admCheckPointMeasures) = SIS.ADM.admCheckPointMeasures.GetByCheckPointID(oSrvChkPt.CheckPointID, "")
					For Each oChkPtMsr As SIS.ADM.admCheckPointMeasures In oChkPTMsrs
						Dim oShtDet As SIS.ADM.admLWServiceSheetDetails = New SIS.ADM.admLWServiceSheetDetails
						With oShtDet
							.SheetID = oSht.SheetID
							.SheetDate = oSht.SheetDate
							.ServiceID = oSht.ServiceID
							.ScheduleID = oSht.ScheduleID
							.MeasureID = oChkPtMsr.MeasureID
							.CheckPointID = oChkPtMsr.CheckPointID
						End With
						SIS.ADM.admLWServiceSheetDetails.Insert(oShtDet)
					Next
				Next
			Catch ex As Exception
				Throw New Exception("Error During Sheet Detail Creation. Service ID:" & ServiceID & ", Date: " & DataDate.ToString("dd/MM/yyyy"))
			End Try
		End Sub
		Public Shared Sub GenerateSheet(ByVal DataDate As DateTime, ByVal ServiceID As String)
			Dim ci As System.Globalization.CultureInfo = New System.Globalization.CultureInfo("en-GB", True)
			If DataDate < Now.Date Then
				Throw New Exception("Invalid Date.")
				Return
			End If
			Dim oSht As SIS.ADM.admLWServiceSheetHeader = SIS.ADM.admLWServiceSheetHeader.GetByServiceDate(DataDate, ServiceID)
			Dim mayContinue As Boolean = True
			If oSht Is Nothing Then
				mayContinue = False
				Dim oSrv As SIS.ADM.admServices = SIS.ADM.admServices.GetByID(ServiceID)
				Dim txtLDt As String = oSrv.LastSheetDate
				Dim LDt As DateTime = Now.AddDays(1)
				If txtLDt <> String.Empty Then
					LDt = Convert.ToDateTime(txtLDt, ci)
				End If
				Dim oShd As SIS.ADM.admSchedules = SIS.ADM.admSchedules.GetByID(oSrv.ScheduleID)

				Select Case oShd.ScheduleID.ToLower
					Case "daily"
						mayContinue = True
					Case "weekly"
						If txtLDt <> String.Empty Then
							If DateDiff(DateInterval.Day, LDt, DataDate) Mod 7 = 0 Then
								mayContinue = True
							End If
						Else
							mayContinue = True
						End If
					Case "fortnightly"
						If DataDate.Day = 1 Or DataDate.Day = 15 Then
							mayContinue = True
						End If
					Case "monthly"
						If DataDate.Day = 1 Then
							mayContinue = True
						End If
					Case "quarterly"
						If DataDate.Day = 1 And (DataDate.Month = 1 Or DataDate.Month = 3 Or DataDate.Month = 6 Or DataDate.Month = 9) Then
							mayContinue = True
						End If
					Case "halfyearly"
						If DataDate.Day = 1 And (DataDate.Month = 1 Or DataDate.Month = 6) Then
							mayContinue = True
						End If
					Case "yearly"
						If DataDate.Day = 1 And DataDate.Month = 1 Then
							mayContinue = True
						End If
				End Select
				If mayContinue Then
					oSht = New SIS.ADM.admLWServiceSheetHeader
					With oSht
						.SheetDate = DataDate
						.Description = oSrv.Description.Trim & " : " & oShd.Description.Trim & " : " & DataDate.ToString("dd/MM/yyyy")
						.ServiceID = ServiceID
						.ScheduleID = oShd.ScheduleID
					End With
					oSht.SheetID = SIS.ADM.admLWServiceSheetHeader.Insert(oSht)
				End If
			End If
			'===============================
			'===============================
			'===============================
			If Not mayContinue Then Exit Sub
			'===============================
			'===============================
			'===============================
			Try
				If Not oSht.Initiated Then
					Dim oShtMsrs As List(Of SIS.ADM.admLWServiceSheetDetails) = SIS.ADM.admLWServiceSheetDetails.GetBySheetID(oSht.SheetID, "")
					For Each oShtMsr As SIS.ADM.admLWServiceSheetDetails In oShtMsrs
						SIS.ADM.admLWServiceSheetDetails.Delete(oShtMsr)
					Next
				End If
				'Re fetch and insert all measures
				Dim oSrvChkPTs As List(Of SIS.ADM.admServiceCheckPoints) = SIS.ADM.admServiceCheckPoints.GetByServiceID(ServiceID, "")
				For Each oSrvChkPt As SIS.ADM.admServiceCheckPoints In oSrvChkPTs
					Dim chk As SIS.ADM.admCheckPoints = oSrvChkPt.FK_ADM_ServiceCheckPoints_ADM_CheckPoints
					If chk.StartDate <> String.Empty Then
						Dim mayGo As Boolean = True
						Dim ldt As Date = Nothing
						Dim sdt As Date = Convert.ToDateTime(chk.StartDate, ci)
						If chk.LastGeneratedOn <> String.Empty Then
							ldt = Convert.ToDateTime(chk.LastGeneratedOn, ci)
						End If
						Select Case chk.ScheduleID.ToLower
							Case "daily"
								mayGo = True
							Case Else
								If chk.LastGeneratedOn <> String.Empty Then
									Dim LFact As Integer = GetPartSinceStartDate(chk.ScheduleID, sdt, ldt)
									Dim CFact As Integer = GetPartSinceStartDate(chk.ScheduleID, sdt, DataDate)
									If LFact = CFact Then
										If chk.LastEntryUpdated Then
											mayGo = False
										Else
											mayGo = True
										End If
									Else
										If chk.LastEntryUpdated Then
											If Not chk.Floating Then
												Dim dDt As Date = GetScheduleDateFromFactor(chk.ScheduleID, sdt, CFact).AddDays(chk.DayOfSchedule)
												If DataDate = dDt Then
													mayGo = True
												Else
													mayGo = False
												End If
											Else
												Dim ludt As Date = Convert.ToDateTime(chk.LastEntryUpdatedOn, ci)
												Dim tFact As Integer = GetPartSinceStartDate(chk.ScheduleID, ludt, DataDate)
												Dim dDt As Date = GetScheduleDateFromFactor(chk.ScheduleID, ludt, tFact).AddDays(chk.DayOfSchedule)
												If DataDate = dDt Then
													mayGo = True
												Else
													mayGo = False
												End If
											End If
										Else
											mayGo = True
										End If
									End If
								Else
									Dim CFact As Integer = GetPartSinceStartDate(chk.ScheduleID, sdt, DataDate)
									Dim dDt As Date = GetScheduleDateFromFactor(chk.ScheduleID, sdt, CFact).AddDays(chk.DayOfSchedule)
									If DataDate >= dDt Then
										mayGo = True
									Else
										mayGo = False
									End If
								End If
						End Select
						If Not mayGo Then Continue For

					End If
					'================
					Dim oChkPTMsrs As List(Of SIS.ADM.admCheckPointMeasures) = SIS.ADM.admCheckPointMeasures.GetByCheckPointID(oSrvChkPt.CheckPointID, "")
					For Each oChkPtMsr As SIS.ADM.admCheckPointMeasures In oChkPTMsrs
						Dim oShtDet As SIS.ADM.admLWServiceSheetDetails = New SIS.ADM.admLWServiceSheetDetails
						With oShtDet
							.SheetID = oSht.SheetID
							.SheetDate = oSht.SheetDate
							.ServiceID = oSht.ServiceID
							.ScheduleID = oSht.ScheduleID
							.MeasureID = oChkPtMsr.MeasureID
							.CheckPointID = oChkPtMsr.CheckPointID
							.CPInitiator = oChkPtMsr.FK_ADM_CheckPointMeasures_ADM_CheckPoints.Initiator
						End With
						SIS.ADM.admLWServiceSheetDetails.Insert(oShtDet)
					Next
					'******Update Check Point For Generated
					chk.LastGeneratedOn = DataDate
					chk.LastEntryUpdated = False
					chk.LastEntryUpdatedOn = ""
					SIS.ADM.admCheckPoints.UpdateData(chk)
					'*******
				Next
			Catch ex As Exception
				Throw New Exception("Error During Sheet Detail Creation. Service ID:" & ServiceID & ", Date: " & DataDate.ToString("dd/MM/yyyy"))
			End Try
		End Sub
		Private Shared Function GetScheduleDateFromFactor(ByVal Part As String, ByVal BaseDate As Date, ByVal Fact As Integer) As Date
			Dim ddt As Date
			Fact = Fact - 1
			Select Case Part.ToLower
				Case "weekly"
					ddt = BaseDate.AddDays(Fact * 7)
				Case "fortnightly"
					ddt = BaseDate.AddMonths(Fact).AddDays(Fact * (-15))
				Case "monthly"
					ddt = BaseDate.AddMonths(Fact)
				Case "quarterly"
					ddt = BaseDate.AddMonths(Fact * 3)
				Case "halfyearly"
					ddt = BaseDate.AddMonths(Fact * 6)
				Case "yearly"
					ddt = BaseDate.AddMonths(Fact * 12)
			End Select
			Return ddt
		End Function
		Private Shared Function GetPartSinceStartDate(ByVal Part As String, ByVal StartDate As Date, ByVal dt As Date) As Integer
			Dim mRet As Integer = 0
			If dt < StartDate Then
				mRet = -1
			Else
				mRet = 0
				Dim tDt As Date = StartDate
				Do While dt > tDt
					mRet += 1
					Select Case Part.ToLower
						Case "weekly"
							tDt = tDt.AddDays(mRet * 7)
						Case "fortnightly"
							tDt = tDt.AddMonths(mRet).AddDays(-15)
						Case "monthly"
							tDt = tDt.AddMonths(mRet)
						Case "quarterly"
							tDt = tDt.AddMonths(mRet * 3)
						Case "halfyearly"
							tDt = tDt.AddMonths(mRet * 6)
						Case "yearly"
							tDt = tDt.AddMonths(mRet * 12)
					End Select
				Loop
			End If
			Return mRet
		End Function
	End Class
End Namespace