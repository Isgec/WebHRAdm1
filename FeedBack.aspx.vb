Imports System.Data
Imports System.Data.SqlClient
Partial Class FeedBack
	Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If Page.IsPostBack Or Page.IsCallback Then
			Dim FeedBack As String = F_FeedBack.SelectedValue
			Dim CallID As String = F_CallID.Text
			UpdFeedback(CallID, FeedBack)
			tblF.Visible = False
			tblS.Visible = False
			tblT.Visible = True
		Else
			Dim CallID As String = ""
			Try
				CallID = Request.QueryString("CallID")
			Catch ex As Exception
			End Try
			If CallID <> String.Empty Then
				If GetFeedback(CallID) = String.Empty Then
					F_CallID.Text = CallID
					tblF.Visible = True
					tblS.Visible = False
					tblT.Visible = False
				Else
					tblF.Visible = False
					tblS.Visible = True
					tblT.Visible = False
				End If
			End If
		End If
	End Sub
	Private Function GetFeedback(ByVal CallId As String) As String
		Dim mRet As String = ""
		Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
			Using Cmd As SqlCommand = Con.CreateCommand()
				Cmd.CommandType = CommandType.Text
				Cmd.CommandText = "Select ISNULL(feedback,'') from ADM_ITComplaints where callid=" & CallId
				Con.Open()
				mRet = Cmd.ExecuteScalar
				If mRet Is Nothing Then
					mRet = ""
				End If
			End Using
		End Using
		Return mRet
	End Function
	Private Function UpdFeedback(ByVal CallId As String, ByVal feedback As String) As String
		Dim mRet As String = ""
		Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
			Using Cmd As SqlCommand = Con.CreateCommand()
				Cmd.CommandType = CommandType.Text
				Cmd.CommandText = "Update ADM_ITComplaints set feedback = '" & feedback & "' where callid=" & CallId
				Con.Open()
				mRet = Cmd.ExecuteNonQuery
			End Using
		End Using
		Return mRet
	End Function

End Class
