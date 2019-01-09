Partial Class GF_admCreateSheet
	Inherits System.Web.UI.Page

	Protected Sub cmdCreate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCreate.Click
		Dim ci As System.Globalization.CultureInfo = New System.Globalization.CultureInfo("en-GB", True)
		Dim ForDate As DateTime = Convert.ToDateTime(F_ForDate.Text, ci)
		Try
			errMsg.Text = ""
			SIS.SYS.Utilities.ApplicationSpacific.GenerateSheet(ForDate)
		Catch ex As Exception
			errMsg.Text = ex.Message
			errMsg.Visible = True
		End Try
	End Sub
End Class
