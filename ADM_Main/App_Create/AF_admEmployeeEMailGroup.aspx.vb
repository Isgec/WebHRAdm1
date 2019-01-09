Partial Class AF_admEmployeeEMailGroup
  Inherits System.Web.UI.Page
  Private _CancelUrl As String = "~/ADM_Main/App_Forms/GF_admEmployeeEMailGroup.aspx"
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
  Public Shared Function CardNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.ADM.admEmployees.SelectadmEmployeesAutoCompleteList(prefixText, count, contextKey)
  End Function
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function EMailGroupCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.ADM.admEMailGroups.SelectadmEMailGroupsAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub FormView1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.PreRender
    Dim oF_CardNo_Display As Label  = FormView1.FindControl("F_CardNo_Display")
    oF_CardNo_Display.Text = String.Empty
    If Not Session("F_CardNo_Display") Is Nothing Then
      If Session("F_CardNo_Display") <> String.Empty Then
        oF_CardNo_Display.Text = Session("F_CardNo_Display")
      End If
    End If
    Dim oF_CardNo As TextBox  = FormView1.FindControl("F_CardNo")
    oF_CardNo.Enabled = True
    oF_CardNo.Text = String.Empty
    If Not Session("F_CardNo") Is Nothing Then
      If Session("F_CardNo") <> String.Empty Then
        oF_CardNo.Text = Session("F_CardNo")
      End If
    End If
		Dim strScriptCardNo As String = "<script type=""text/javascript""> " & _
			"function ACECardNo_Selected(o, e) {" & _
			"  var F_CardNo = $get('" & oF_CardNo.ClientID & "');" & _
			"  var F_CardNo_Display = $get('" & oF_CardNo_Display.ClientID & "');" & _
			"  var retval = e.get_value();" & _
			"  var p = retval.split('|');" & _
			"  F_CardNo.value = p[0];" & _
			"  F_CardNo_Display.innerHTML = e.get_text();" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("F_CardNo") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_CardNo", strScriptCardNo)
			End If
		Dim strScriptPopulatingCardNo As String = "<script type=""text/javascript""> " & _
			"function ACECardNo_Populating(o,e) {" & _
			"  var p = o.get_element();" & _
			"  p.style.backgroundImage = 'url(../../images/loader.gif)';" & _
			"  p.style.backgroundRepeat = 'no-repeat';" & _
			"  p.style.backgroundPosition = 'right';" & _
			"  o._contextKey = '';" & _
			"}" & _
			"function ACECardNo_Populated(o,e) {" & _
			"  var p = o.get_element();" & _
			"  p.style.backgroundImage  = 'none';" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("F_CardNoPopulating") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_CardNoPopulating", strScriptPopulatingCardNo)
			End If
    Dim oF_EMailGroup_Display As Label  = FormView1.FindControl("F_EMailGroup_Display")
    oF_EMailGroup_Display.Text = String.Empty
    If Not Session("F_EMailGroup_Display") Is Nothing Then
      If Session("F_EMailGroup_Display") <> String.Empty Then
        oF_EMailGroup_Display.Text = Session("F_EMailGroup_Display")
      End If
    End If
    Dim oF_EMailGroup As TextBox  = FormView1.FindControl("F_EMailGroup")
    oF_EMailGroup.Enabled = True
    oF_EMailGroup.Text = String.Empty
    If Not Session("F_EMailGroup") Is Nothing Then
      If Session("F_EMailGroup") <> String.Empty Then
        oF_EMailGroup.Text = Session("F_EMailGroup")
      End If
    End If
		Dim strScriptEMailGroup As String = "<script type=""text/javascript""> " & _
			"function ACEEMailGroup_Selected(o, e) {" & _
			"  var F_EMailGroup = $get('" & oF_EMailGroup.ClientID & "');" & _
			"  var F_EMailGroup_Display = $get('" & oF_EMailGroup_Display.ClientID & "');" & _
			"  var retval = e.get_value();" & _
			"  var p = retval.split('|');" & _
			"  F_EMailGroup.value = p[0];" & _
			"  F_EMailGroup_Display.innerHTML = e.get_text();" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("F_EMailGroup") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_EMailGroup", strScriptEMailGroup)
			End If
		Dim strScriptPopulatingEMailGroup As String = "<script type=""text/javascript""> " & _
			"function ACEEMailGroup_Populating(o,e) {" & _
			"  var p = o.get_element();" & _
			"  p.style.backgroundImage = 'url(../../images/loader.gif)';" & _
			"  p.style.backgroundRepeat = 'no-repeat';" & _
			"  p.style.backgroundPosition = 'right';" & _
			"  o._contextKey = '';" & _
			"}" & _
			"function ACEEMailGroup_Populated(o,e) {" & _
			"  var p = o.get_element();" & _
			"  p.style.backgroundImage  = 'none';" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("F_EMailGroupPopulating") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_EMailGroupPopulating", strScriptPopulatingEMailGroup)
			End If
		Dim validateScriptCardNo As String = "<script type=""text/javascript"">" & _
			"  function validate_CardNo(o) {" & _
			"    validated_FK_HRM_EmployeeEMailGroup_HRM_Employees.main = true;" & _
			"    validate_FK_HRM_EmployeeEMailGroup_HRM_Employees(o);" & _
			"    validatePK_admEmployeeEMailGroup(o);" & _
			"  }" & _
		  "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateCardNo") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateCardNo", validateScriptCardNo)
		End If
		Dim validateScriptEMailGroup As String = "<script type=""text/javascript"">" & _
			"  function validate_EMailGroup(o) {" & _
			"    validated_FK_HRM_EmployeeEMailGroup_HRM_EMailGroups.main = true;" & _
			"    validate_FK_HRM_EmployeeEMailGroup_HRM_EMailGroups(o);" & _
			"    validatePK_admEmployeeEMailGroup(o);" & _
			"  }" & _
		  "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateEMailGroup") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateEMailGroup", validateScriptEMailGroup)
		End If
		Dim FK_HRM_EmployeeEMailGroup_HRM_EMailGroupsEMailGroup As TextBox = FormView1.FindControl("F_EMailGroup")
		Dim validateScriptFK_HRM_EmployeeEMailGroup_HRM_EMailGroups As String = "<script type=""text/javascript"">" & _
			"  function validate_FK_HRM_EmployeeEMailGroup_HRM_EMailGroups(o) {" & _
			"    var value = o.id;" & _
			"    var EMailGroup = $get('" & FK_HRM_EmployeeEMailGroup_HRM_EMailGroupsEMailGroup.ClientID & "');" & _
			"    if(EMailGroup.value==''){" & _
			"      if(validated_FK_HRM_EmployeeEMailGroup_HRM_EMailGroups.main){" & _
			"        var o_d = $get(o.id +'_Display');" & _
			"        try{o_d.innerHTML = '';}catch(ex){}" & _
			"      }" & _
			"      return true;" & _
			"    }" & _
			"    value = value + ',' + EMailGroup.value ;" & _
			"    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
			"    o.style.backgroundRepeat= 'no-repeat';" & _
			"    o.style.backgroundPosition = 'right';" & _
			"    PageMethods.validate_FK_HRM_EmployeeEMailGroup_HRM_EMailGroups(value, validated_FK_HRM_EmployeeEMailGroup_HRM_EMailGroups);" & _
			"  }" & _
			"  validated_FK_HRM_EmployeeEMailGroup_HRM_EMailGroups.main = false;" & _
			"  function validated_FK_HRM_EmployeeEMailGroup_HRM_EMailGroups(result) {" & _
			"    var p = result.split('|');" & _
			"    var o = $get(p[1]);" & _
			"    if(validated_FK_HRM_EmployeeEMailGroup_HRM_EMailGroups.main){" & _
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
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_HRM_EmployeeEMailGroup_HRM_EMailGroups") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_HRM_EmployeeEMailGroup_HRM_EMailGroups", validateScriptFK_HRM_EmployeeEMailGroup_HRM_EMailGroups)
		End If
		Dim FK_HRM_EmployeeEMailGroup_HRM_EmployeesCardNo As TextBox = FormView1.FindControl("F_CardNo")
		Dim validateScriptFK_HRM_EmployeeEMailGroup_HRM_Employees As String = "<script type=""text/javascript"">" & _
			"  function validate_FK_HRM_EmployeeEMailGroup_HRM_Employees(o) {" & _
			"    var value = o.id;" & _
			"    var CardNo = $get('" & FK_HRM_EmployeeEMailGroup_HRM_EmployeesCardNo.ClientID & "');" & _
			"    if(CardNo.value==''){" & _
			"      if(validated_FK_HRM_EmployeeEMailGroup_HRM_Employees.main){" & _
			"        var o_d = $get(o.id +'_Display');" & _
			"        try{o_d.innerHTML = '';}catch(ex){}" & _
			"      }" & _
			"      return true;" & _
			"    }" & _
			"    value = value + ',' + CardNo.value ;" & _
			"    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
			"    o.style.backgroundRepeat= 'no-repeat';" & _
			"    o.style.backgroundPosition = 'right';" & _
			"    PageMethods.validate_FK_HRM_EmployeeEMailGroup_HRM_Employees(value, validated_FK_HRM_EmployeeEMailGroup_HRM_Employees);" & _
			"  }" & _
			"  validated_FK_HRM_EmployeeEMailGroup_HRM_Employees.main = false;" & _
			"  function validated_FK_HRM_EmployeeEMailGroup_HRM_Employees(result) {" & _
			"    var p = result.split('|');" & _
			"    var o = $get(p[1]);" & _
			"    if(validated_FK_HRM_EmployeeEMailGroup_HRM_Employees.main){" & _
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
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_HRM_EmployeeEMailGroup_HRM_Employees") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_HRM_EmployeeEMailGroup_HRM_Employees", validateScriptFK_HRM_EmployeeEMailGroup_HRM_Employees)
		End If
		Dim ctlCardNo As TextBox = FormView1.FindControl("F_CardNo")
		Dim ctlEMailGroup As TextBox = FormView1.FindControl("F_EMailGroup")
		Dim validateScript As String = "<script type=""text/javascript"">" & _
			"  function validatePK_admEmployeeEMailGroup(o) {" & _
			"    var value = o.id;" & _
			"    try{$get('ctl00_ContentPlaceHolder1_FormView1_L_ErrMsg').innerHTML = '';}catch(ex){}" & _
			"    var CardNo = $get('" & ctlCardNo.ClientID & "');" & _
			"    if(CardNo.value=='')" & _
			"      return true;" & _
			"    value = value + ',' + CardNo.value ;" & _
			"    var EMailGroup = $get('" & ctlEMailGroup.ClientID & "');" & _
			"    if(EMailGroup.value=='')" & _
			"      return true;" & _
			"    value = value + ',' + EMailGroup.value ;" & _
			"    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
			"    o.style.backgroundRepeat= 'no-repeat';" & _
			"    o.style.backgroundPosition = 'right';" & _
			"    PageMethods.validatePK_admEmployeeEMailGroup(value, validatedPK_admEmployeeEMailGroup);" & _
			"  }" & _
			"  function validatedPK_admEmployeeEMailGroup(result) {" & _
			"    var p = result.split('|');" & _
			"    var o = $get(p[1]);" & _
			"    o.style.backgroundImage  = 'none';" & _
			"    if(p[0]=='1'){" & _
			"      try{$get('ctl00_ContentPlaceHolder1_FormView1_L_ErrMsg').innerHTML = p[2];}catch(ex){}" & _
			"      o.value='';" & _
			"      o.focus();" & _
			"    }" & _
			"  }" & _
		  "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validatePKadmEmployeeEMailGroup") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validatePKadmEmployeeEMailGroup", validateScript)
		End If
  End Sub
	<System.Web.Services.WebMethod()> _
  Public Shared Function validatePK_admEmployeeEMailGroup(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim CardNo As String = CType(aVal(1),String)
		Dim EMailGroup As String = CType(aVal(2),String)
		Dim oVar As SIS.ADM.admEmployeeEMailGroup = SIS.ADM.admEmployeeEMailGroup.GetByID(CardNo,EMailGroup)
    If Not oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record allready exists." 
    End If
    Return mRet
  End Function
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_HRM_EmployeeEMailGroup_HRM_EMailGroups(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim EMailGroup As String = CType(aVal(1),String)
		Dim oVar As SIS.ADM.admEMailGroups = SIS.ADM.admEMailGroups.GetByID(EMailGroup)
    If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found." 
    Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_HRM_EmployeeEMailGroup_HRM_Employees(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim CardNo As String = CType(aVal(1),String)
		Dim oVar As SIS.ADM.admEmployees = SIS.ADM.admEmployees.GetByID(CardNo)
    If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found." 
    Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
End Class
