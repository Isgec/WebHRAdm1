Partial Class AF_admRegisterComplaint
	Inherits System.Web.UI.Page
	Protected Sub FormView1_ItemInserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewInsertedEventArgs) Handles FormView1.ItemInserted
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
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
	 Public Shared Function EndUserIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
		Return SIS.ADM.admEmployees.SelectadmEmployeesAutoCompleteList(prefixText, count, contextKey)
	End Function
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
	 Public Shared Function AssignedToCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
		Return SIS.ADM.admUsers.SelectadmUsersAutoCompleteList(prefixText, count, contextKey)
	End Function
	Protected Sub FormView1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.PreRender
		Dim oF_EndUserID_Display As Label = FormView1.FindControl("F_EndUserID_Display")
		oF_EndUserID_Display.Text = String.Empty
		If Not Session("F_EndUserID_Display") Is Nothing Then
			If Session("F_EndUserID_Display") <> String.Empty Then
				oF_EndUserID_Display.Text = Session("F_EndUserID_Display")
			End If
		End If
		Dim oF_EndUserID As TextBox = FormView1.FindControl("F_EndUserID")
		oF_EndUserID.Enabled = True
		oF_EndUserID.Text = String.Empty
		If Not Session("F_EndUserID") Is Nothing Then
			If Session("F_EndUserID") <> String.Empty Then
				oF_EndUserID.Text = Session("F_EndUserID")
			End If
		End If
		Dim strScriptEndUserID As String = "<script type=""text/javascript""> " & _
		 "function ACEEndUserID_Selected(o, e) {" & _
		 "  var F_EndUserID = $get('" & oF_EndUserID.ClientID & "');" & _
		 "  var F_EndUserID_Display = $get('" & oF_EndUserID_Display.ClientID & "');" & _
		 "  var retval = e.get_value();" & _
		 "  var p = retval.split('|');" & _
		 "  F_EndUserID.value = p[0];" & _
		 "  F_EndUserID_Display.innerHTML = e.get_text();" & _
		 "}" & _
		 "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("F_EndUserID") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_EndUserID", strScriptEndUserID)
		End If
		Dim strScriptPopulatingEndUserID As String = "<script type=""text/javascript""> " & _
		 "function ACEEndUserID_Populating(o,e) {" & _
		 "  var p = o.get_element();" & _
		 "  p.style.backgroundImage = 'url(../../images/loader.gif)';" & _
		 "  p.style.backgroundRepeat = 'no-repeat';" & _
		 "  p.style.backgroundPosition = 'right';" & _
		 "  o._contextKey = '';" & _
		 "}" & _
		 "function ACEEndUserID_Populated(o,e) {" & _
		 "  var p = o.get_element();" & _
		 "  p.style.backgroundImage  = 'none';" & _
		 "}" & _
		 "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("F_EndUserIDPopulating") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_EndUserIDPopulating", strScriptPopulatingEndUserID)
		End If
		Dim oF_CallTypeID As LC_admCallTypes = FormView1.FindControl("F_CallTypeID")
		oF_CallTypeID.Enabled = True
		oF_CallTypeID.SelectedValue = String.Empty
		If Not Session("F_CallTypeID") Is Nothing Then
			If Session("F_CallTypeID") <> String.Empty Then
				oF_CallTypeID.SelectedValue = Session("F_CallTypeID")
			End If
		End If
		Dim oF_AssignedTo_Display As Label = FormView1.FindControl("F_AssignedTo_Display")
		oF_AssignedTo_Display.Text = String.Empty
		If Not Session("F_AssignedTo_Display") Is Nothing Then
			If Session("F_AssignedTo_Display") <> String.Empty Then
				oF_AssignedTo_Display.Text = Session("F_AssignedTo_Display")
			End If
		End If
		Dim oF_AssignedTo As TextBox = FormView1.FindControl("F_AssignedTo")
		oF_AssignedTo.Enabled = True
		oF_AssignedTo.Text = String.Empty
		If Not Session("F_AssignedTo") Is Nothing Then
			If Session("F_AssignedTo") <> String.Empty Then
				oF_AssignedTo.Text = Session("F_AssignedTo")
			End If
		End If
		Dim strScriptAssignedTo As String = "<script type=""text/javascript""> " & _
		 "function ACEAssignedTo_Selected(o, e) {" & _
		 "  var F_AssignedTo = $get('" & oF_AssignedTo.ClientID & "');" & _
		 "  var F_AssignedTo_Display = $get('" & oF_AssignedTo_Display.ClientID & "');" & _
		 "  var retval = e.get_value();" & _
		 "  var p = retval.split('|');" & _
		 "  F_AssignedTo.value = p[0];" & _
		 "  F_AssignedTo_Display.innerHTML = e.get_text();" & _
		 "}" & _
		 "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("F_AssignedTo") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_AssignedTo", strScriptAssignedTo)
		End If
		Dim strScriptPopulatingAssignedTo As String = "<script type=""text/javascript""> " & _
		 "function ACEAssignedTo_Populating(o,e) {" & _
		 "  var p = o.get_element();" & _
		 "  p.style.backgroundImage = 'url(../../images/loader.gif)';" & _
		 "  p.style.backgroundRepeat = 'no-repeat';" & _
		 "  p.style.backgroundPosition = 'right';" & _
		 "  o._contextKey = '';" & _
		 "}" & _
		 "function ACEAssignedTo_Populated(o,e) {" & _
		 "  var p = o.get_element();" & _
		 "  p.style.backgroundImage  = 'none';" & _
		 "}" & _
		 "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("F_AssignedToPopulating") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_AssignedToPopulating", strScriptPopulatingAssignedTo)
		End If
		Dim validateScriptEndUserID As String = "<script type=""text/javascript"">" & _
		 "  function validate_EndUserID(o) {" & _
		 "    validated_FK_ADM_ITComplaints_HRM_Employees.main = true;" & _
		 "    validate_FK_ADM_ITComplaints_HRM_Employees(o);" & _
		 "  }" & _
			"</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateEndUserID") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateEndUserID", validateScriptEndUserID)
		End If
		Dim validateScriptAssignedTo As String = "<script type=""text/javascript"">" & _
		 "  function validate_AssignedTo(o) {" & _
		 "    validated_FK_ADM_ITComplaints_ADM_Users1.main = true;" & _
		 "    validate_FK_ADM_ITComplaints_ADM_Users1(o);" & _
		 "  }" & _
			"</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateAssignedTo") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateAssignedTo", validateScriptAssignedTo)
		End If
		Dim FK_ADM_ITComplaints_HRM_EmployeesEndUserID As TextBox = FormView1.FindControl("F_EndUserID")
		Dim validateScriptFK_ADM_ITComplaints_HRM_Employees As String = "<script type=""text/javascript"">" & _
		 "  function validate_FK_ADM_ITComplaints_HRM_Employees(o) {" & _
		 "    var value = o.id;" & _
		 "    var EndUserID = $get('" & FK_ADM_ITComplaints_HRM_EmployeesEndUserID.ClientID & "');" & _
		 "    if(EndUserID.value==''){" & _
		 "      if(validated_FK_ADM_ITComplaints_HRM_Employees.main){" & _
		 "        var o_d = $get(o.id +'_Display');" & _
		 "        try{o_d.innerHTML = '';}catch(ex){}" & _
		 "      }" & _
		 "      return true;" & _
		 "    }" & _
		 "    value = value + ',' + EndUserID.value ;" & _
		 "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
		 "    o.style.backgroundRepeat= 'no-repeat';" & _
		 "    o.style.backgroundPosition = 'right';" & _
		 "    PageMethods.validate_FK_ADM_ITComplaints_HRM_Employees(value, validated_FK_ADM_ITComplaints_HRM_Employees);" & _
		 "  }" & _
		 "  validated_FK_ADM_ITComplaints_HRM_Employees.main = false;" & _
		 "  function validated_FK_ADM_ITComplaints_HRM_Employees(result) {" & _
		 "    var p = result.split('|');" & _
		 "    var o = $get(p[1]);" & _
		 "    if(validated_FK_ADM_ITComplaints_HRM_Employees.main){" & _
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
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_ADM_ITComplaints_HRM_Employees") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_ADM_ITComplaints_HRM_Employees", validateScriptFK_ADM_ITComplaints_HRM_Employees)
		End If
		Dim FK_ADM_ITComplaints_ADM_Users1AssignedTo As TextBox = FormView1.FindControl("F_AssignedTo")
		Dim validateScriptFK_ADM_ITComplaints_ADM_Users1 As String = "<script type=""text/javascript"">" & _
		 "  function validate_FK_ADM_ITComplaints_ADM_Users1(o) {" & _
		 "    var value = o.id;" & _
		 "    var AssignedTo = $get('" & FK_ADM_ITComplaints_ADM_Users1AssignedTo.ClientID & "');" & _
		 "    if(AssignedTo.value==''){" & _
		 "      if(validated_FK_ADM_ITComplaints_ADM_Users1.main){" & _
		 "        var o_d = $get(o.id +'_Display');" & _
		 "        try{o_d.innerHTML = '';}catch(ex){}" & _
		 "      }" & _
		 "      return true;" & _
		 "    }" & _
		 "    value = value + ',' + AssignedTo.value ;" & _
		 "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
		 "    o.style.backgroundRepeat= 'no-repeat';" & _
		 "    o.style.backgroundPosition = 'right';" & _
		 "    PageMethods.validate_FK_ADM_ITComplaints_ADM_Users1(value, validated_FK_ADM_ITComplaints_ADM_Users1);" & _
		 "  }" & _
		 "  validated_FK_ADM_ITComplaints_ADM_Users1.main = false;" & _
		 "  function validated_FK_ADM_ITComplaints_ADM_Users1(result) {" & _
		 "    var p = result.split('|');" & _
		 "    var o = $get(p[1]);" & _
		 "    if(validated_FK_ADM_ITComplaints_ADM_Users1.main){" & _
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
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_ADM_ITComplaints_ADM_Users1") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_ADM_ITComplaints_ADM_Users1", validateScriptFK_ADM_ITComplaints_ADM_Users1)
		End If
		'Default Value
		oF_AssignedTo.Text = HttpContext.Current.Session("LoginID")
		oF_AssignedTo_Display.Text = ""
		Dim oF_SendMail As CheckBox = FormView1.FindControl("F_SendMail")
		oF_SendMail.Checked = True
		'===
	End Sub
	<System.Web.Services.WebMethod()> _
	 Public Shared Function validate_FK_ADM_ITComplaints_HRM_Employees(ByVal value As String) As String
		Dim aVal() As String = value.Split(",".ToCharArray)
		Dim mRet As String = "0|" & aVal(0)
		Dim EndUserID As String = CType(aVal(1), String)
		Dim oVar As SIS.ADM.admEmployees = SIS.ADM.admEmployees.GetByID(EndUserID)
		If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found."
		Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
		End If
		Return mRet
	End Function
	<System.Web.Services.WebMethod()> _
	 Public Shared Function validate_FK_ADM_ITComplaints_ADM_Users1(ByVal value As String) As String
		Dim aVal() As String = value.Split(",".ToCharArray)
		Dim mRet As String = "0|" & aVal(0)
		Dim AssignedTo As String = CType(aVal(1), String)
		Dim oVar As SIS.ADM.admUsers = SIS.ADM.admUsers.GetByID(AssignedTo)
		If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found."
		Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
		End If
		Return mRet
	End Function
End Class
