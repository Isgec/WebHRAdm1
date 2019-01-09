Partial Class EF_admComplaintResponse
	Inherits System.Web.UI.Page
	Protected Sub FormView1_ItemDeleted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewDeletedEventArgs) Handles FormView1.ItemDeleted
		If e.Exception Is Nothing Then
			Response.Redirect(SIS.SYS.Utilities.SessionManager.PopNavBar())
		Else
			If Not e.Exception.InnerException Is Nothing Then
				Session("myError") = e.Exception.InnerException.ToString & vbCrLf & e.Exception.Message
			Else
				Session("myError") = e.Exception.Message
			End If
			e.ExceptionHandled = True
			Response.Redirect("~/ErrorPage.aspx")
		End If
	End Sub
	Protected Sub FormView1_ItemUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewUpdatedEventArgs) Handles FormView1.ItemUpdated
		If e.Exception Is Nothing Then
			Response.Redirect(SIS.SYS.Utilities.SessionManager.PopNavBar())
		Else
			If Not e.Exception.InnerException Is Nothing Then
				Session("myError") = e.Exception.InnerException.ToString & vbCrLf & e.Exception.Message
			Else
				Session("myError") = e.Exception.Message
			End If
			e.ExceptionHandled = True
			Response.Redirect("~/ErrorPage.aspx")
		End If
	End Sub
End Class
