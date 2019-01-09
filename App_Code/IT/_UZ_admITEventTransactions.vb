Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Net.Mail
Namespace SIS.ADM
	Partial Public Class admITEventTransactions
		Private _Circular As String = ""
		Public Property Circular() As String
			Get
				Return _Circular
			End Get
			Set(ByVal value As String)
				If Convert.IsDBNull(value) Then
					_Circular = ""
				Else
					_Circular = value
				End If
			End Set
		End Property
		Public ReadOnly Property DashBoardStatus() As String
			Get
				Dim mRet As String = "<table border=""1"" cellspacing=""0"" cellpadding=""0"" ><tr>"
				Dim oSrvs As List(Of SIS.ADM.admITEventProgress) = SIS.ADM.admITEventProgress.GetByEventID(_EventID, "")
				Dim Incomplete As Boolean = False
				For Each srv As SIS.ADM.admITEventProgress In oSrvs
					If srv.Responded Then
						mRet += "<td onmouseover=""show_tt(this);"" onmouseout=""hide_tt(this);"" id=""" & _EventID & "_" & srv.FK_ADM_ITEventStatus_ADM_ITServices.DisplayField & """ class=""ok_button""><input type=""image"" style=""height:16px;width:24px"" onclick=""return false;"" alt=""" & srv.ITServiceID.ToUpper & """ src=""../../App_Themes/Default/Images/btn_green2.gif"" /></td>"
					Else
						mRet += "<td onmouseover=""show_tt(this);"" onmouseout=""hide_tt(this);"" id=""" & _EventID & "_" & srv.FK_ADM_ITEventStatus_ADM_ITServices.DisplayField & """ class=""cancel_button""><input type=""image"" style=""height:16px;width:24px"" onclick=""return false;"" alt=""" & srv.ITServiceID.ToUpper & """ src=""../../App_Themes/Default/Images/btn_red2.gif"" /></td>"
						Incomplete = True
					End If
				Next
				mRet += "</tr></table>"
				If Not Incomplete Then
					mRet = ""
				End If
				Return mRet
			End Get
		End Property
		Public ReadOnly Property EditDashBoardStatus() As String
			Get
				Dim mRet As String = "<table border=""1"" cellspacing=""0"" cellpadding=""0"" ><tr>"
				Dim oSrvs As List(Of SIS.ADM.admITEventProgress) = SIS.ADM.admITEventProgress.GetByEventID(_EventID, "")
				Dim Incomplete As Boolean = False
				For Each srv As SIS.ADM.admITEventProgress In oSrvs
					If srv.Responded Then
						mRet += "<td title=""" & srv.FK_ADM_ITEventStatus_ADM_ITServices.DisplayField & """ style=""background-color:rgb(149,206,145);cursor:pointer;font-size:10px;height:16px;width:20px;padding:2px"" onclick=""return showProgressPopup(this);"" id=""" & _EventID & "|" & srv.FK_ADM_ITEventStatus_ADM_ITServices.DisplayField & "|" & FK_ADM_ITEventTransactions_HRM_Employees.DisplayField.Trim & "|" & srv.ITServiceID & """>" & srv.ITServiceID.Substring(0, 3) & "</td>"
					Else
						mRet += "<td title=""" & srv.FK_ADM_ITEventStatus_ADM_ITServices.DisplayField & """ style=""background-color:rgb(255, 102, 0);cursor:pointer;font-size:10px;height:16px;width:20px;padding:2px"" onclick=""return showProgressPopup(this);"" id=""" & _EventID & "|" & srv.FK_ADM_ITEventStatus_ADM_ITServices.DisplayField & "|" & FK_ADM_ITEventTransactions_HRM_Employees.DisplayField.Trim & "|" & srv.ITServiceID & """>" & srv.ITServiceID.Substring(0, 3) & "</td>"
						Incomplete = True
					End If
				Next
				mRet += "</tr></table>"
				If Not Incomplete Then
					mRet = ""
				End If
				Return mRet
			End Get
		End Property
		Public Shared Function UZ_Insert(ByVal Record As SIS.ADM.admITEventTransactions) As Int32
			Record.EventID = Insert(Record)
			If Record.EventID > 0 Then
				Dim oSrvs As List(Of SIS.ADM.admITServices) = SIS.ADM.admITServices.SelectList("")
				For Each srv As SIS.ADM.admITServices In oSrvs
					Dim osts As New SIS.ADM.admITEventStatus
					With osts
						.EventID = Record.EventID
						.ITServiceID = srv.ITServiceID
					End With
					SIS.ADM.admITEventStatus.Insert(osts)
					If srv.EMailGroup <> String.Empty Then
						Dim oEMailIDs As List(Of SIS.ADM.admEmployeeEMailGroup) = SIS.ADM.admEmployeeEMailGroup.GetByEMailGroup(srv.EMailGroup, "")
						For Each emp As SIS.ADM.admEmployeeEMailGroup In oEMailIDs
							Dim EMailID As String = SIS.SYS.Utilities.GlobalVariables.GetEMailID(emp.CardNo)
							If EMailID <> String.Empty Then
								Try
									Dim oClient As SmtpClient = New SmtpClient()
									Dim oMsg As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage("hrdisgec.co.in", EMailID)
									With oMsg
										.IsBodyHtml = True
										.To.Add(EMailID)
										.Subject = "Emp.ID Management for " & srv.Description
										Dim mStr As String = "<table border=""0"" cellspacing=""0"" cellpadding=""0"">"
										mStr = mStr & "<tr><td><b>Dear All,</b></br></br></td></tr>"
										mStr = mStr & "<tr><td><b>Event ID :</b>" & Record.EventID & "</td></tr>"
										mStr = mStr & "<tr><td><b>Employee :</b>" & Record.CardNo & "-" & Record.FK_ADM_ITEventTransactions_HRM_Employees.EmployeeName & "</td></tr>"
										mStr = mStr & "<tr><td><b>Description :</b>" & Record.Description & "</br></br></td></tr>"
										mStr = mStr & "<tr><td>Please update required field(s) in system, and confirm your action.</br></br></td></tr>"
										mStr = mStr & "<tr><td>Thanx.</td></tr>"
										mStr = mStr & "</table>"
										.Body = mStr
									End With
									oClient.Send(oMsg)
								Catch ex As Exception
								End Try
							End If
						Next
					End If
				Next
			End If
			Return Record.EventID
		End Function
		Public Shared Function UZ_Update(ByVal Record As SIS.ADM.admITEventTransactions) As Int32
			Dim oSrvs As List(Of SIS.ADM.admITServices) = SIS.ADM.admITServices.SelectList("")
			For Each srv As SIS.ADM.admITServices In oSrvs
				Dim osts As SIS.ADM.admITEventStatus = SIS.ADM.admITEventStatus.GetByID(Record.EventID, srv.ITServiceID)
				If osts Is Nothing Then
					osts = New SIS.ADM.admITEventStatus
					With osts
						.EventID = Record.EventID
						.ITServiceID = srv.ITServiceID
					End With
					SIS.ADM.admITEventStatus.Insert(osts)
				End If
			Next
			Return Update(Record)
		End Function
		Public Shared Function UZ_Delete(ByVal Record As SIS.ADM.admITEventTransactions) As Int32
			Dim oStss As List(Of SIS.ADM.admITEventStatus) = SIS.ADM.admITEventStatus.GetByEventID(Record.EventID, "")
			For Each sts As SIS.ADM.admITEventStatus In oStss
				SIS.ADM.admITEventStatus.Delete(sts)
			Next
			Return Delete(Record)
		End Function
		Public Shared Function SelectPendingList(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal orderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal CardNo As String) As List(Of SIS.ADM.admITEventTransactions)
			Dim Results As List(Of SIS.ADM.admITEventTransactions) = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					If orderBy = String.Empty Then orderBy = "EventID DESC"
					Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spadm_LG_ITEventTransactionsSelectPendingListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spadm_LG_ITEventTransactionsSelectPendingListFilteres"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CardNo", SqlDbType.NVarChar, 8, IIf(CardNo Is Nothing, String.Empty, CardNo))
					End If
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@startRowIndex", SqlDbType.Int, -1, startRowIndex)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@maximumRows", SqlDbType.Int, -1, maximumRows)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, orderBy)
					Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
					Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
					_RecordCount = -1
					Results = New List(Of SIS.ADM.admITEventTransactions)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results.Add(New SIS.ADM.admITEventTransactions(Reader))
					End While
					Reader.Close()
					_RecordCount = Cmd.Parameters("@RecordCount").Value
				End Using
			End Using
			Return Results
		End Function
		Public Function GetStatusDetails(ByVal OrderBy As String) As List(Of SIS.ADM.admITEventStatus)
			Return SIS.ADM.admITEventTransactions.GetStatusDetails(_EventID, OrderBy)
		End Function
		Public Shared Function GetStatusDetails(ByVal EventID As Int32, ByVal OrderBy As String) As List(Of SIS.ADM.admITEventStatus)
			Return SIS.ADM.admITEventStatus.GetByEventID(EventID, OrderBy)
		End Function
	End Class
End Namespace
