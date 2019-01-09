Partial Class EF_admITEventStatus
  Inherits System.Web.UI.Page
  Private _CancelUrl As String = "~/ADM_Main/App_Forms/GF_admITEventStatus.aspx"
  Protected Sub FormView1_ItemCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewCommandEventArgs) Handles FormView1.ItemCommand
    If e.CommandName.ToLower = "cancel" Then
      Response.Redirect(_CancelUrl)
    End If
    If e.CommandName.ToLower = "return" Then
      ObjectDataSource1.UpdateMethod = "UpdateReturn"
      FormView1.UpdateItem(False)
    End If
  End Sub
  Protected Sub FormView1_ItemDeleted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewDeletedEventArgs) Handles FormView1.ItemDeleted
    If e.Exception Is Nothing Then
      Response.Redirect(_CancelUrl)
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
      Response.Redirect(_CancelUrl)
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
  Protected Sub FormView1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.PreRender
    Dim oF_EventID As TextBox  = FormView1.FindControl("F_EventID")
    Dim oF_ITServiceID As TextBox  = FormView1.FindControl("F_ITServiceID")
  End Sub
End Class
