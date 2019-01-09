Partial Class AF_admMonitors
  Inherits System.Web.UI.Page
  Private _CancelUrl As String = "~/ADM_Main/App_Forms/GF_admMonitors.aspx"
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
  Public Shared Function MonitorIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.ADM.admEmployees.SelectadmEmployeesAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub FormView1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.PreRender
    Dim oF_ServiceID As LC_admServices = FormView1.FindControl("F_ServiceID")
    oF_ServiceID.Enabled = True
    oF_ServiceID.SelectedValue = String.Empty
    If Not Session("F_ServiceID") Is Nothing Then
      If Session("F_ServiceID") <> String.Empty Then
        oF_ServiceID.SelectedValue = Session("F_ServiceID")
      End If
    End If
    Dim oF_MonitorID_Display As Label  = FormView1.FindControl("F_MonitorID_Display")
    oF_MonitorID_Display.Text = String.Empty
    If Not Session("F_MonitorID_Display") Is Nothing Then
      If Session("F_MonitorID_Display") <> String.Empty Then
        oF_MonitorID_Display.Text = Session("F_MonitorID_Display")
      End If
    End If
    Dim oF_MonitorID As TextBox  = FormView1.FindControl("F_MonitorID")
    oF_MonitorID.Enabled = True
    oF_MonitorID.Text = String.Empty
    If Not Session("F_MonitorID") Is Nothing Then
      If Session("F_MonitorID") <> String.Empty Then
        oF_MonitorID.Text = Session("F_MonitorID")
      End If
    End If
		Dim strScriptMonitorID As String = "<script type=""text/javascript""> " & _
			"function ACEMonitorID_Selected(o, e) {" & _
			"  var F_MonitorID = $get('" & oF_MonitorID.ClientID & "');" & _
			"  var F_MonitorID_Display = $get('" & oF_MonitorID_Display.ClientID & "');" & _
			"  var retval = e.get_value();" & _
			"  var p = retval.split('|');" & _
			"  F_MonitorID.value = p[0];" & _
			"  F_MonitorID_Display.innerHTML = e.get_text();" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("F_MonitorID") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_MonitorID", strScriptMonitorID)
			End If
		Dim strScriptPopulatingMonitorID As String = "<script type=""text/javascript""> " & _
			"function ACEMonitorID_Populating(o,e) {" & _
			"  var p = o.get_element();" & _
			"  p.style.backgroundImage = 'url(../../images/loader.gif)';" & _
			"  p.style.backgroundRepeat = 'no-repeat';" & _
			"  p.style.backgroundPosition = 'right';" & _
			"  o._contextKey = '';" & _
			"}" & _
			"function ACEMonitorID_Populated(o,e) {" & _
			"  var p = o.get_element();" & _
			"  p.style.backgroundImage  = 'none';" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("F_MonitorIDPopulating") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_MonitorIDPopulating", strScriptPopulatingMonitorID)
			End If
		Dim validateScriptMonitorID As String = "<script type=""text/javascript"">" & _
			"  function validate_MonitorID(o) {" & _
			"    validated_FK_ADM_Monitors_HRM_Employees.main = true;" & _
			"    validate_FK_ADM_Monitors_HRM_Employees(o);" & _
			"  }" & _
		  "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateMonitorID") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateMonitorID", validateScriptMonitorID)
		End If
		Dim FK_ADM_Monitors_HRM_EmployeesMonitorID As TextBox = FormView1.FindControl("F_MonitorID")
		Dim validateScriptFK_ADM_Monitors_HRM_Employees As String = "<script type=""text/javascript"">" & _
			"  function validate_FK_ADM_Monitors_HRM_Employees(o) {" & _
			"    var value = o.id;" & _
			"    var MonitorID = $get('" & FK_ADM_Monitors_HRM_EmployeesMonitorID.ClientID & "');" & _
			"    if(MonitorID.value==''){" & _
			"      if(validated_FK_ADM_Monitors_HRM_Employees.main){" & _
			"        var o_d = $get(o.id +'_Display');" & _
			"        try{o_d.innerHTML = '';}catch(ex){}" & _
			"      }" & _
			"      return true;" & _
			"    }" & _
			"    value = value + ',' + MonitorID.value ;" & _
			"    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
			"    o.style.backgroundRepeat= 'no-repeat';" & _
			"    o.style.backgroundPosition = 'right';" & _
			"    PageMethods.validate_FK_ADM_Monitors_HRM_Employees(value, validated_FK_ADM_Monitors_HRM_Employees);" & _
			"  }" & _
			"  validated_FK_ADM_Monitors_HRM_Employees.main = false;" & _
			"  function validated_FK_ADM_Monitors_HRM_Employees(result) {" & _
			"    var p = result.split('|');" & _
			"    var o = $get(p[1]);" & _
			"    if(validated_FK_ADM_Monitors_HRM_Employees.main){" & _
			"      var o_d = $get(p[1]+'_Display');" & _
			"      try{o_d.innerHTML = p[2];}catch(ex){}" & _
			"    }" & _
			"    o.style.backgroundImage  = 'none';" & _
			"    if(p[0]=='1'){" & _
			"      o.value='';" & _
			"      o.focus();" & _
			"    }" & _
			"  }" & _
		  "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_ADM_Monitors_HRM_Employees") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_ADM_Monitors_HRM_Employees", validateScriptFK_ADM_Monitors_HRM_Employees)
		End If
  End Sub
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_ADM_Monitors_HRM_Employees(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim MonitorID As String = CType(aVal(1),String)
		Dim oVar As SIS.ADM.admEmployees = SIS.ADM.admEmployees.GetByID(MonitorID)
    If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found." 
    Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
End Class
