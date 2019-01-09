Partial Class AF_admITEventStatus
  Inherits System.Web.UI.Page
  Private _CancelUrl As String = "~/ADM_Main/App_Forms/GF_admITEventStatus.aspx"
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
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function EventIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.ADM.admITEventTransactions.SelectadmITEventTransactionsAutoCompleteList(prefixText, count, contextKey)
  End Function
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ITServiceIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.ADM.admITServices.SelectadmITServicesAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub FormView1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.PreRender
    Dim oF_EventID_Display As Label  = FormView1.FindControl("F_EventID_Display")
    oF_EventID_Display.Text = String.Empty
    If Not Session("F_EventID_Display") Is Nothing Then
      If Session("F_EventID_Display") <> String.Empty Then
        oF_EventID_Display.Text = Session("F_EventID_Display")
      End If
    End If
    Dim oF_EventID As TextBox  = FormView1.FindControl("F_EventID")
    oF_EventID.Enabled = True
    oF_EventID.Text = String.Empty
    If Not Session("F_EventID") Is Nothing Then
      If Session("F_EventID") <> String.Empty Then
        oF_EventID.Text = Session("F_EventID")
      End If
    End If
		Dim strScriptEventID As String = "<script type=""text/javascript""> " & _
			"function ACEEventID_Selected(o, e) {" & _
			"  var F_EventID = $get('" & oF_EventID.ClientID & "');" & _
			"  var F_EventID_Display = $get('" & oF_EventID_Display.ClientID & "');" & _
			"  var retval = e.get_value();" & _
			"  var p = retval.split('|');" & _
			"  F_EventID.value = p[0];" & _
			"  F_EventID_Display.innerHTML = e.get_text();" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("F_EventID") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_EventID", strScriptEventID)
			End If
		Dim strScriptPopulatingEventID As String = "<script type=""text/javascript""> " & _
			"function ACEEventID_Populating(o,e) {" & _
			"  var p = o.get_element();" & _
			"  p.style.backgroundImage = 'url(../../images/loader.gif)';" & _
			"  p.style.backgroundRepeat = 'no-repeat';" & _
			"  p.style.backgroundPosition = 'right';" & _
			"  o._contextKey = '';" & _
			"}" & _
			"function ACEEventID_Populated(o,e) {" & _
			"  var p = o.get_element();" & _
			"  p.style.backgroundImage  = 'none';" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("F_EventIDPopulating") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_EventIDPopulating", strScriptPopulatingEventID)
			End If
    Dim oF_ITServiceID_Display As Label  = FormView1.FindControl("F_ITServiceID_Display")
    oF_ITServiceID_Display.Text = String.Empty
    If Not Session("F_ITServiceID_Display") Is Nothing Then
      If Session("F_ITServiceID_Display") <> String.Empty Then
        oF_ITServiceID_Display.Text = Session("F_ITServiceID_Display")
      End If
    End If
    Dim oF_ITServiceID As TextBox  = FormView1.FindControl("F_ITServiceID")
    oF_ITServiceID.Enabled = True
    oF_ITServiceID.Text = String.Empty
    If Not Session("F_ITServiceID") Is Nothing Then
      If Session("F_ITServiceID") <> String.Empty Then
        oF_ITServiceID.Text = Session("F_ITServiceID")
      End If
    End If
		Dim strScriptITServiceID As String = "<script type=""text/javascript""> " & _
			"function ACEITServiceID_Selected(o, e) {" & _
			"  var F_ITServiceID = $get('" & oF_ITServiceID.ClientID & "');" & _
			"  var F_ITServiceID_Display = $get('" & oF_ITServiceID_Display.ClientID & "');" & _
			"  var retval = e.get_value();" & _
			"  var p = retval.split('|');" & _
			"  F_ITServiceID.value = p[0];" & _
			"  F_ITServiceID_Display.innerHTML = e.get_text();" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("F_ITServiceID") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_ITServiceID", strScriptITServiceID)
			End If
		Dim strScriptPopulatingITServiceID As String = "<script type=""text/javascript""> " & _
			"function ACEITServiceID_Populating(o,e) {" & _
			"  var p = o.get_element();" & _
			"  p.style.backgroundImage = 'url(../../images/loader.gif)';" & _
			"  p.style.backgroundRepeat = 'no-repeat';" & _
			"  p.style.backgroundPosition = 'right';" & _
			"  o._contextKey = '';" & _
			"}" & _
			"function ACEITServiceID_Populated(o,e) {" & _
			"  var p = o.get_element();" & _
			"  p.style.backgroundImage  = 'none';" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("F_ITServiceIDPopulating") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_ITServiceIDPopulating", strScriptPopulatingITServiceID)
			End If
  End Sub
End Class
