Partial Class AF_admInitiators
  Inherits System.Web.UI.Page
  Private _CancelUrl As String = "~/ADM_Main/App_Forms/GF_admInitiators.aspx"
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
  Public Shared Function InitiatorIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
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
    Dim oF_InitiatorID_Display As Label  = FormView1.FindControl("F_InitiatorID_Display")
    oF_InitiatorID_Display.Text = String.Empty
    If Not Session("F_InitiatorID_Display") Is Nothing Then
      If Session("F_InitiatorID_Display") <> String.Empty Then
        oF_InitiatorID_Display.Text = Session("F_InitiatorID_Display")
      End If
    End If
    Dim oF_InitiatorID As TextBox  = FormView1.FindControl("F_InitiatorID")
    oF_InitiatorID.Enabled = True
    oF_InitiatorID.Text = String.Empty
    If Not Session("F_InitiatorID") Is Nothing Then
      If Session("F_InitiatorID") <> String.Empty Then
        oF_InitiatorID.Text = Session("F_InitiatorID")
      End If
    End If
		Dim strScriptInitiatorID As String = "<script type=""text/javascript""> " & _
			"function ACEInitiatorID_Selected(o, e) {" & _
			"  var F_InitiatorID = $get('" & oF_InitiatorID.ClientID & "');" & _
			"  var F_InitiatorID_Display = $get('" & oF_InitiatorID_Display.ClientID & "');" & _
			"  var retval = e.get_value();" & _
			"  var p = retval.split('|');" & _
			"  F_InitiatorID.value = p[0];" & _
			"  F_InitiatorID_Display.innerHTML = e.get_text();" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("F_InitiatorID") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_InitiatorID", strScriptInitiatorID)
			End If
		Dim strScriptPopulatingInitiatorID As String = "<script type=""text/javascript""> " & _
			"function ACEInitiatorID_Populating(o,e) {" & _
			"  var p = o.get_element();" & _
			"  p.style.backgroundImage = 'url(../../images/loader.gif)';" & _
			"  p.style.backgroundRepeat = 'no-repeat';" & _
			"  p.style.backgroundPosition = 'right';" & _
			"  o._contextKey = '';" & _
			"}" & _
			"function ACEInitiatorID_Populated(o,e) {" & _
			"  var p = o.get_element();" & _
			"  p.style.backgroundImage  = 'none';" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("F_InitiatorIDPopulating") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_InitiatorIDPopulating", strScriptPopulatingInitiatorID)
			End If
		Dim validateScriptInitiatorID As String = "<script type=""text/javascript"">" & _
			"  function validate_InitiatorID(o) {" & _
			"    validated_FK_ADM_Initiators_HRM_Employees.main = true;" & _
			"    validate_FK_ADM_Initiators_HRM_Employees(o);" & _
			"  }" & _
		  "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateInitiatorID") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateInitiatorID", validateScriptInitiatorID)
		End If
		Dim FK_ADM_Initiators_HRM_EmployeesInitiatorID As TextBox = FormView1.FindControl("F_InitiatorID")
		Dim validateScriptFK_ADM_Initiators_HRM_Employees As String = "<script type=""text/javascript"">" & _
			"  function validate_FK_ADM_Initiators_HRM_Employees(o) {" & _
			"    var value = o.id;" & _
			"    var InitiatorID = $get('" & FK_ADM_Initiators_HRM_EmployeesInitiatorID.ClientID & "');" & _
			"    if(InitiatorID.value==''){" & _
			"      if(validated_FK_ADM_Initiators_HRM_Employees.main){" & _
			"        var o_d = $get(o.id +'_Display');" & _
			"        try{o_d.innerHTML = '';}catch(ex){}" & _
			"      }" & _
			"      return true;" & _
			"    }" & _
			"    value = value + ',' + InitiatorID.value ;" & _
			"    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
			"    o.style.backgroundRepeat= 'no-repeat';" & _
			"    o.style.backgroundPosition = 'right';" & _
			"    PageMethods.validate_FK_ADM_Initiators_HRM_Employees(value, validated_FK_ADM_Initiators_HRM_Employees);" & _
			"  }" & _
			"  validated_FK_ADM_Initiators_HRM_Employees.main = false;" & _
			"  function validated_FK_ADM_Initiators_HRM_Employees(result) {" & _
			"    var p = result.split('|');" & _
			"    var o = $get(p[1]);" & _
			"    if(validated_FK_ADM_Initiators_HRM_Employees.main){" & _
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
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_ADM_Initiators_HRM_Employees") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_ADM_Initiators_HRM_Employees", validateScriptFK_ADM_Initiators_HRM_Employees)
		End If
  End Sub
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_ADM_Initiators_HRM_Employees(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim InitiatorID As String = CType(aVal(1),String)
		Dim oVar As SIS.ADM.admEmployees = SIS.ADM.admEmployees.GetByID(InitiatorID)
    If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found." 
    Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
End Class
