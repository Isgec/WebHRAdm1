Partial Class EF_admITEventTransactions
  Inherits System.Web.UI.Page
	Private _CancelUrl As String = "~/ADM_Main/App_Forms/GF_admITEventTransactions.aspx"
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
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function CardNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.ADM.admEmployees.SelectadmEmployeesAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub FormView1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.PreRender
    Dim oF_CardNo_Display As Label  = FormView1.FindControl("F_CardNo_Display")
    Dim oF_CardNo As TextBox  = FormView1.FindControl("F_CardNo")
		Dim strScriptCardNo As String = "<script type=""text/javascript""> " & _
			"function ACECardNo_Selected(sender, e) {" & _
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
			"  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
			"  p.style.backgroundRepeat= 'no-repeat';" & _
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
		Dim validateScriptCardNo As String = "<script type=""text/javascript"">" & _
			"  function validate_CardNo(o) {" & _
			"    validated_FK_ADM_ITEventTransactions_HRM_Employees.main = true;" & _
			"    validate_FK_ADM_ITEventTransactions_HRM_Employees(o);" & _
			"  }" & _
		  "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateCardNo") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateCardNo", validateScriptCardNo)
		End If
		Dim FK_ADM_ITEventTransactions_HRM_EmployeesCardNo As TextBox = FormView1.FindControl("F_CardNo")
		Dim validateScriptFK_ADM_ITEventTransactions_HRM_Employees As String = "<script type=""text/javascript"">" & _
			"  function validate_FK_ADM_ITEventTransactions_HRM_Employees(o) {" & _
			"    var value = o.id;" & _
			"    var CardNo = $get('" & FK_ADM_ITEventTransactions_HRM_EmployeesCardNo.ClientID & "');" & _
			"    if(CardNo.value==''){" & _
			"      if(validated_FK_ADM_ITEventTransactions_HRM_Employees.main){" & _
			"        var o_d = $get(o.id +'_Display');" & _
			"        try{o_d.innerHTML = '';}catch(ex){}" & _
			"      }" & _
			"      return true;" & _
			"    }" & _
			"    value = value + ',' + CardNo.value ;" & _
			"    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
			"    o.style.backgroundRepeat= 'no-repeat';" & _
			"    o.style.backgroundPosition = 'right';" & _
			"    PageMethods.validate_FK_ADM_ITEventTransactions_HRM_Employees(value, validated_FK_ADM_ITEventTransactions_HRM_Employees);" & _
			"  }" & _
			"  validated_FK_ADM_ITEventTransactions_HRM_Employees.main = false;" & _
			"  function validated_FK_ADM_ITEventTransactions_HRM_Employees(result) {" & _
			"    var p = result.split('|');" & _
			"    var o = $get(p[1]);" & _
			"    if(validated_FK_ADM_ITEventTransactions_HRM_Employees.main){" & _
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
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_ADM_ITEventTransactions_HRM_Employees") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_ADM_ITEventTransactions_HRM_Employees", validateScriptFK_ADM_ITEventTransactions_HRM_Employees)
		End If
  End Sub
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_ADM_ITEventTransactions_HRM_Employees(ByVal value As String) As String
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
	Protected Sub FormView1_ItemUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewUpdateEventArgs) Handles FormView1.ItemUpdating
		e.NewValues.Add("Circular", CType(FormView1.FindControl("CKEditorControl1"), CKEditor.NET.CKEditorControl).Text)
	End Sub
	Protected Sub FormView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.DataBound
		Dim oB As SIS.ADM.admITEventTransactions = SIS.ADM.admITEventTransactions.GetByID(Request.QueryString("EventID"))
		CType(FormView1.FindControl("CKEditorControl1"), CKEditor.NET.CKEditorControl).Text = oB.Circular
	End Sub
End Class
