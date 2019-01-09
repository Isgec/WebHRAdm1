Partial Class AF_admQlfUpdate
  Inherits System.Web.UI.Page
  Private _CancelUrl As String = "~/ADM_Main/App_Forms/GF_admQlfUpdate.aspx"
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
  Public Shared Function DepartmentIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.ADM.admDepartments.SelectadmDepartmentsAutoCompleteList(prefixText, count, contextKey)
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
    Dim oF_DepartmentID_Display As Label  = FormView1.FindControl("F_DepartmentID_Display")
    oF_DepartmentID_Display.Text = String.Empty
    If Not Session("F_DepartmentID_Display") Is Nothing Then
      If Session("F_DepartmentID_Display") <> String.Empty Then
        oF_DepartmentID_Display.Text = Session("F_DepartmentID_Display")
      End If
    End If
    Dim oF_DepartmentID As TextBox  = FormView1.FindControl("F_DepartmentID")
    oF_DepartmentID.Enabled = True
    oF_DepartmentID.Text = String.Empty
    If Not Session("F_DepartmentID") Is Nothing Then
      If Session("F_DepartmentID") <> String.Empty Then
        oF_DepartmentID.Text = Session("F_DepartmentID")
      End If
    End If
		Dim strScriptDepartmentID As String = "<script type=""text/javascript""> " & _
			"function ACEDepartmentID_Selected(o, e) {" & _
			"  var F_DepartmentID = $get('" & oF_DepartmentID.ClientID & "');" & _
			"  var F_DepartmentID_Display = $get('" & oF_DepartmentID_Display.ClientID & "');" & _
			"  var retval = e.get_value();" & _
			"  var p = retval.split('|');" & _
			"  F_DepartmentID.value = p[0];" & _
			"  F_DepartmentID_Display.innerHTML = e.get_text();" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("F_DepartmentID") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_DepartmentID", strScriptDepartmentID)
			End If
		Dim strScriptPopulatingDepartmentID As String = "<script type=""text/javascript""> " & _
			"function ACEDepartmentID_Populating(o,e) {" & _
			"  var p = o.get_element();" & _
			"  p.style.backgroundImage = 'url(../../images/loader.gif)';" & _
			"  p.style.backgroundRepeat = 'no-repeat';" & _
			"  p.style.backgroundPosition = 'right';" & _
			"  o._contextKey = '';" & _
			"}" & _
			"function ACEDepartmentID_Populated(o,e) {" & _
			"  var p = o.get_element();" & _
			"  p.style.backgroundImage  = 'none';" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("F_DepartmentIDPopulating") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_DepartmentIDPopulating", strScriptPopulatingDepartmentID)
			End If
    Dim oF_Qlf1ID As LC_admQualifications = FormView1.FindControl("F_Qlf1ID")
    oF_Qlf1ID.Enabled = True
    oF_Qlf1ID.SelectedValue = String.Empty
    If Not Session("F_Qlf1ID") Is Nothing Then
      If Session("F_Qlf1ID") <> String.Empty Then
        oF_Qlf1ID.SelectedValue = Session("F_Qlf1ID")
      End If
    End If
    Dim oF_Qlf2ID As LC_admQualifications = FormView1.FindControl("F_Qlf2ID")
    oF_Qlf2ID.Enabled = True
    oF_Qlf2ID.SelectedValue = String.Empty
    If Not Session("F_Qlf2ID") Is Nothing Then
      If Session("F_Qlf2ID") <> String.Empty Then
        oF_Qlf2ID.SelectedValue = Session("F_Qlf2ID")
      End If
    End If
		Dim validateScriptCardNo As String = "<script type=""text/javascript"">" & _
			"  function validate_CardNo(o) {" & _
			"    validated_FK_HRM_QlfUpdate_HRM_Employees.main = true;" & _
			"    validate_FK_HRM_QlfUpdate_HRM_Employees(o);" & _
			"  }" & _
		  "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateCardNo") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateCardNo", validateScriptCardNo)
		End If
		Dim validateScriptDepartmentID As String = "<script type=""text/javascript"">" & _
			"  function validate_DepartmentID(o) {" & _
			"    validated_FK_HRM_QlfUpdate_HRM_Departments.main = true;" & _
			"    validate_FK_HRM_QlfUpdate_HRM_Departments(o);" & _
			"  }" & _
		  "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateDepartmentID") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateDepartmentID", validateScriptDepartmentID)
		End If
		Dim FK_HRM_QlfUpdate_HRM_DepartmentsDepartmentID As TextBox = FormView1.FindControl("F_DepartmentID")
		Dim validateScriptFK_HRM_QlfUpdate_HRM_Departments As String = "<script type=""text/javascript"">" & _
			"  function validate_FK_HRM_QlfUpdate_HRM_Departments(o) {" & _
			"    var value = o.id;" & _
			"    var DepartmentID = $get('" & FK_HRM_QlfUpdate_HRM_DepartmentsDepartmentID.ClientID & "');" & _
			"    if(DepartmentID.value==''){" & _
			"      if(validated_FK_HRM_QlfUpdate_HRM_Departments.main){" & _
			"        var o_d = $get(o.id +'_Display');" & _
			"        try{o_d.innerHTML = '';}catch(ex){}" & _
			"      }" & _
			"      return true;" & _
			"    }" & _
			"    value = value + ',' + DepartmentID.value ;" & _
			"    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
			"    o.style.backgroundRepeat= 'no-repeat';" & _
			"    o.style.backgroundPosition = 'right';" & _
			"    PageMethods.validate_FK_HRM_QlfUpdate_HRM_Departments(value, validated_FK_HRM_QlfUpdate_HRM_Departments);" & _
			"  }" & _
			"  validated_FK_HRM_QlfUpdate_HRM_Departments.main = false;" & _
			"  function validated_FK_HRM_QlfUpdate_HRM_Departments(result) {" & _
			"    var p = result.split('|');" & _
			"    var o = $get(p[1]);" & _
			"    if(validated_FK_HRM_QlfUpdate_HRM_Departments.main){" & _
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
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_HRM_QlfUpdate_HRM_Departments") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_HRM_QlfUpdate_HRM_Departments", validateScriptFK_HRM_QlfUpdate_HRM_Departments)
		End If
		Dim FK_HRM_QlfUpdate_HRM_EmployeesCardNo As TextBox = FormView1.FindControl("F_CardNo")
		Dim validateScriptFK_HRM_QlfUpdate_HRM_Employees As String = "<script type=""text/javascript"">" & _
			"  function validate_FK_HRM_QlfUpdate_HRM_Employees(o) {" & _
			"    var value = o.id;" & _
			"    var CardNo = $get('" & FK_HRM_QlfUpdate_HRM_EmployeesCardNo.ClientID & "');" & _
			"    if(CardNo.value==''){" & _
			"      if(validated_FK_HRM_QlfUpdate_HRM_Employees.main){" & _
			"        var o_d = $get(o.id +'_Display');" & _
			"        try{o_d.innerHTML = '';}catch(ex){}" & _
			"      }" & _
			"      return true;" & _
			"    }" & _
			"    value = value + ',' + CardNo.value ;" & _
			"    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
			"    o.style.backgroundRepeat= 'no-repeat';" & _
			"    o.style.backgroundPosition = 'right';" & _
			"    PageMethods.validate_FK_HRM_QlfUpdate_HRM_Employees(value, validated_FK_HRM_QlfUpdate_HRM_Employees);" & _
			"  }" & _
			"  validated_FK_HRM_QlfUpdate_HRM_Employees.main = false;" & _
			"  function validated_FK_HRM_QlfUpdate_HRM_Employees(result) {" & _
			"    var p = result.split('|');" & _
			"    var o = $get(p[1]);" & _
			"    if(validated_FK_HRM_QlfUpdate_HRM_Employees.main){" & _
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
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_HRM_QlfUpdate_HRM_Employees") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_HRM_QlfUpdate_HRM_Employees", validateScriptFK_HRM_QlfUpdate_HRM_Employees)
		End If
  End Sub
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_HRM_QlfUpdate_HRM_Departments(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim DepartmentID As String = CType(aVal(1),String)
		Dim oVar As SIS.ADM.admDepartments = SIS.ADM.admDepartments.GetByID(DepartmentID)
    If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found." 
    Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_HRM_QlfUpdate_HRM_Employees(ByVal value As String) As String
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
