Partial Class EF_admMonitorSheetDetails
  Inherits System.Web.UI.Page
	Private _CancelUrl As String = "~/ADM_Main/App_Edit/EF_admMonitorSheetHeader.aspx"
	Public Property CancelURL() As String
		Get
			If ViewState("CancelURL") IsNot Nothing Then
				Return CType(ViewState("CancelURL"), String)
			End If
			Return ""
		End Get
		Set(ByVal value As String)
			ViewState.Add("CancelURL", value)
		End Set
	End Property
	Protected Sub FormView1_ItemCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewCommandEventArgs) Handles FormView1.ItemCommand
		If e.CommandName.ToLower = "cancel" Then
			Response.Redirect(CancelURL)
		End If
		If e.CommandName.ToLower = "return" Then
			ObjectDataSource1.UpdateMethod = "UpdateReturn"
			FormView1.UpdateItem(False)
		End If
	End Sub
  Protected Sub FormView1_ItemDeleted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewDeletedEventArgs) Handles FormView1.ItemDeleted
    If e.Exception Is Nothing Then
			Response.Redirect(CancelURL)
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
			Response.Redirect(CancelURL)
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
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		CancelURL = _CancelUrl & "?SheetID=" & Request.QueryString("SheetID")
	End Sub
End Class
