Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Net.Mail
Namespace SIS.ADM
	Partial Public Class admQlfUpdate
		Public Shared Function UZ_GetByID(ByVal CardNo As String) As SIS.ADM.admQlfUpdate
			Dim Results As SIS.ADM.admQlfUpdate = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spadm_LG_QlfUpdateSelectByID"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo", SqlDbType.NVarChar, CardNo.ToString.Length, CardNo)
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Reader.Read() Then
						Results = New SIS.ADM.admQlfUpdate(Reader)
					End If
					Reader.Close()
				End Using
			End Using
			Return Results
		End Function
		Public Shared Function Update1(ByVal Record As SIS.ADM.admQlfUpdate) As Int32
			Dim _Result As Integer = 0
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spadmQlfUpdateUpdate"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_CardNo", SqlDbType.NVarChar, 9, Record.CardNo)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@emailid", SqlDbType.NVarChar, 101, IIf(Record.emailid = "", Convert.DBNull, Record.emailid))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Qlf1NotInList", SqlDbType.Bit, 3, Record.Qlf1NotInList)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Qlf1Specified", SqlDbType.NVarChar, 51, IIf(Record.Qlf1Specified = "", Convert.DBNull, Record.Qlf1Specified))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Qlf2NotInList", SqlDbType.Bit, 3, Record.Qlf2NotInList)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Qlf2Specified", SqlDbType.NVarChar, 51, IIf(Record.Qlf2Specified = "", Convert.DBNull, Record.Qlf2Specified))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@N_CellNo", SqlDbType.NVarChar, 51, IIf(Record.N_CellNo = "", Convert.DBNull, Record.N_CellNo))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@N_Qlf1ID", SqlDbType.Int, 11, IIf(Record.Qlf1ID = "", Convert.DBNull, Record.Qlf1ID))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@N_Qlf1Yr", SqlDbType.NVarChar, 5, IIf(Record.Qlf1Yr = "", Convert.DBNull, Record.Qlf1Yr))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@N_Qlf2ID", SqlDbType.Int, 11, IIf(Record.Qlf2ID = "", Convert.DBNull, Record.Qlf2ID))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@N_Qlf2Yr", SqlDbType.NVarChar, 5, IIf(Record.Qlf2Yr = "", Convert.DBNull, Record.Qlf2Yr))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@N_FatherName", SqlDbType.NVarChar, 51, IIf(Record.FatherName = "", Convert.DBNull, Record.FatherName))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@N_DateOfBirth", SqlDbType.DateTime, 21, IIf(Record.DateOfBirth = "", Convert.DBNull, Record.DateOfBirth))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@N_BloodGroupID", SqlDbType.NVarChar, 6, IIf(Record.BloodGroupID = "", Convert.DBNull, Record.BloodGroupID))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@sendmail", SqlDbType.Bit, 3, Record.sendmail)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Changed", SqlDbType.Bit, 3, Record.Changed)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Updated", SqlDbType.Bit, 3, 1)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UpdatedOn", SqlDbType.DateTime, 21, Now)
					Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
					Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
					Con.Open()
					Cmd.ExecuteNonQuery()
					_Result = Cmd.Parameters("@RowCount").Value
				End Using
			End Using
			Return _Result
		End Function
		Public Shared Function UZ_Update(ByVal Record As SIS.ADM.admQlfUpdate) As Int32
			Dim _Result As Integer = 0
			Dim Original_Record As SIS.ADM.admQlfUpdate = SIS.ADM.admQlfUpdate.GetByID(Record.CardNo)
			With Original_Record
				'check for changed
				If .Qlf1ID <> Record.Qlf1ID Then
					.Changed = True
				ElseIf .Qlf1Yr <> Record.Qlf1Yr Then
					.Changed = True
				ElseIf .Qlf1Specified <> Record.Qlf1Specified Then
					.Changed = True
				ElseIf .Qlf2ID <> Record.Qlf2ID Then
					.Changed = True
				ElseIf .Qlf2Yr <> Record.Qlf2Yr Then
					.Changed = True
				ElseIf .Qlf2Specified <> Record.Qlf2Specified Then
					.Changed = True
				ElseIf .FatherName <> Record.FatherName Then
					.Changed = True
				ElseIf .DateOfBirth <> Record.DateOfBirth Then
					.Changed = True
				ElseIf .BloodGroupID <> Record.BloodGroupID Then
					.Changed = True
				ElseIf .N_CellNo <> Record.N_CellNo Then
					.Changed = True
				End If
				.Qlf1ID = Record.Qlf1ID
				.Qlf1Yr = Record.Qlf1Yr
				.Qlf1NotInList = Record.Qlf1NotInList
				.Qlf1Specified = Record.Qlf1Specified
				.Qlf2ID = Record.Qlf2ID
				.Qlf2Yr = Record.Qlf2Yr
				.Qlf2NotInList = Record.Qlf2NotInList
				.Qlf2Specified = Record.Qlf2Specified
				.FatherName = Record.FatherName
				.DateOfBirth = Record.DateOfBirth
				.BloodGroupID = Record.BloodGroupID
				.N_CellNo = Record.N_CellNo
			End With
			_Result = Update1(Original_Record)
			'Send Mail If Last Survey Date Has Past
			Dim L_Date As DateTime = Convert.ToDateTime(ConfigurationManager.AppSettings("LastSurveyDate"))
			If DateDiff(DateInterval.Day, L_Date, Now) > 0 Then
				'Send Mail To Sangeeta
				Try
					Dim oClient As SmtpClient = New SmtpClient()

					Dim oMsg As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage("hrdisgec.co.in", "sangeeta.ranaisgec.co.in")
					With oMsg
						.IsBodyHtml = True
						.CC.Add("hrdisgec.co.in")
						.Subject = "Employee Master Data Updation: " & Record.FK_HRM_QlfUpdate_HRM_Employees.DisplayField
						Dim mFile As String = HttpContext.Current.Server.MapPath("~/") & "DelayResponse.mail"
						Dim tr As IO.StreamReader = New IO.StreamReader(mFile)
						Dim mStr As String = tr.ReadToEnd
						tr.Close()
						mStr = mStr.Replace("<employee>", Record.CardNo & ": " & Record.FK_HRM_QlfUpdate_HRM_Employees.DisplayField)
						mStr = mStr.Replace("<department>", Record.DepartmentID)
						mStr = mStr.Replace("<changed>", IIf(Original_Record.Changed, "changed", "not changed"))
						mStr = mStr.Replace("<updatedon>", Now.ToString("dd/MM/yyyy"))

						.Body = mStr
					End With
					oClient.Send(oMsg)

				Catch ex As Exception

				End Try

			End If

			Return _Result
		End Function
		Public Shared Function SendSurveyLinkMail(ByVal Record As SIS.ADM.admQlfUpdate) As Boolean

			Try
				Dim oClient As SmtpClient = New SmtpClient()

				Dim oMsg As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage("hrdisgec.co.in", Record.emailid)
				With oMsg
					.IsBodyHtml = True
					.CC.Add("hrdisgec.co.in")
					.Subject = "Employee Master Data Updation: " & Record.FK_HRM_QlfUpdate_HRM_Employees.DisplayField.Trim & " [" & Record.CardNo & "]"
					Dim mFile As String = HttpContext.Current.Server.MapPath("~/") & "EmpSurvey.mail"
					Dim tr As IO.StreamReader = New IO.StreamReader(mFile)
					Dim mStr As String = tr.ReadToEnd
					tr.Close()
					Try
						mStr = mStr.Replace("<employee>", Record.CardNo & ": " & Record.FK_HRM_QlfUpdate_HRM_Employees.DisplayField)
					Catch ex As Exception
					End Try
					Try
						mStr = mStr.Replace("<department>", Record.DepartmentID)
					Catch ex As Exception
					End Try
					Try
						mStr = mStr.Replace("<qlf1>", Record.FK_HRM_QlfUpdate_HRM_Qualifications.DisplayField)
					Catch ex As Exception
					End Try
					Try
						mStr = mStr.Replace("<qlf1yr>", Record.Qlf1Yr)
					Catch ex As Exception
					End Try
					Try
						mStr = mStr.Replace("<qlf2>", Record.FK_HRM_QlfUpdate_HRM_Qualifications1.DisplayField)
					Catch ex As Exception
					End Try
					Try
						mStr = mStr.Replace("<qlf2yr>", Record.Qlf2Yr)
					Catch ex As Exception
					End Try
					Try
						mStr = mStr.Replace("<fathername>", Record.FatherName)
					Catch ex As Exception
					End Try
					Try
						mStr = mStr.Replace("<dob>", Record.DateOfBirth)
					Catch ex As Exception
					End Try
					Try
						mStr = mStr.Replace("<bloodgroup>", Record.BloodGroupID)
					Catch ex As Exception
					End Try
					Try
						mStr = mStr.Replace("<uid>", Record.uid)
					Catch ex As Exception
					End Try
					Try
						mStr = mStr.Replace("<lastdate>", ConfigurationManager.AppSettings("LastSurveyDate"))
					Catch ex As Exception
					End Try
					Try
						mStr = mStr.Replace("<url>", ConfigurationManager.AppSettings("SurveyURL"))
					Catch ex As Exception
					End Try


					.Body = mStr
				End With
				oClient.Send(oMsg)

			Catch ex As Exception

			End Try
      Return True
    End Function
		Public Shared Function SendSurveyLinkMailToAll(ByVal FromCardNo As String, ByVal ToCardNo As String) As Boolean
			Dim mPage As Integer = 0
			Dim mRows As Integer = 10
			Dim oEmps As List(Of SIS.ADM.admQlfUpdate) = SIS.ADM.admQlfUpdate.SelectList(mPage, mRows, "", False, "", "", "", 0, 0)
      Do While oEmps.Count > 0
        For Each oEmp As SIS.ADM.admQlfUpdate In oEmps
          If oEmp.CardNo >= FromCardNo And oEmp.CardNo <= ToCardNo Then
            If oEmp.sendmail Then
              If oEmp.emailid <> String.Empty Then
                SendSurveyLinkMail(oEmp)
              End If
            End If
          End If
        Next
        mPage += 10
        oEmps = SIS.ADM.admQlfUpdate.SelectList(mPage, mRows, "", False, "", "", "", 0, 0)
      Loop
      Return True
    End Function
	End Class
End Namespace
