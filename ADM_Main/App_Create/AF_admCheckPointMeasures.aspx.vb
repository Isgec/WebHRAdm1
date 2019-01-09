Partial Class AF_admCheckPointMeasures
  Inherits System.Web.UI.Page
  Private _CancelUrl As String = "~/ADM_Main/App_Forms/GF_admCheckPointMeasures.aspx"
  Private _AddAndStay As Boolean = False
  Protected Sub FormView1_ItemCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewCommandEventArgs) Handles FormView1.ItemCommand
    If e.CommandName.ToLower = "cancel" Then
      Response.Redirect(_CancelUrl)
    End If
    If e.CommandArgument.ToLower = "stay" Then
      _AddAndStay = True
    End If
  End Sub
  Protected Sub FormView1_ItemInserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewInsertedEventArgs) Handles FormView1.ItemInserted
    If e.Exception Is Nothing Then
      If Not _AddAndStay Then
        Response.Redirect(_CancelUrl)
      End If
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
    Dim oF_CheckPointID As LC_admCheckPoints = FormView1.FindControl("F_CheckPointID")
    oF_CheckPointID.Enabled = True
    oF_CheckPointID.SelectedValue = String.Empty
    If Not Session("F_CheckPointID") Is Nothing Then
      If Session("F_CheckPointID") <> String.Empty Then
        oF_CheckPointID.SelectedValue = Session("F_CheckPointID")
      End If
    End If
    Dim oF_MeasureID As LC_admMeasures = FormView1.FindControl("F_MeasureID")
    oF_MeasureID.Enabled = True
    oF_MeasureID.SelectedValue = String.Empty
    If Not Session("F_MeasureID") Is Nothing Then
      If Session("F_MeasureID") <> String.Empty Then
        oF_MeasureID.SelectedValue = Session("F_MeasureID")
      End If
    End If
  End Sub
End Class
