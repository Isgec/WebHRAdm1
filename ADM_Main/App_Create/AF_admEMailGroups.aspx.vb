Partial Class AF_admEMailGroups
  Inherits System.Web.UI.Page
  Private _CancelUrl As String = "~/ADM_Main/App_Forms/GF_admEMailGroups.aspx"
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
		Dim validateScriptEMailGroup As String = "<script type=""text/javascript"">" & _
			"  function validate_EMailGroup(o) {" & _
			"    validatePK_admEMailGroups(o);" & _
			"  }" & _
		  "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateEMailGroup") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateEMailGroup", validateScriptEMailGroup)
		End If
		Dim ctlEMailGroup As TextBox = FormView1.FindControl("F_EMailGroup")
		Dim validateScript As String = "<script type=""text/javascript"">" & _
			"  function validatePK_admEMailGroups(o) {" & _
			"    var value = o.id;" & _
			"    try{$get('ctl00_ContentPlaceHolder1_FormView1_L_ErrMsg').innerHTML = '';}catch(ex){}" & _
			"    var EMailGroup = $get('" & ctlEMailGroup.ClientID & "');" & _
			"    if(EMailGroup.value=='')" & _
			"      return true;" & _
			"    value = value + ',' + EMailGroup.value ;" & _
			"    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
			"    o.style.backgroundRepeat= 'no-repeat';" & _
			"    o.style.backgroundPosition = 'right';" & _
			"    PageMethods.validatePK_admEMailGroups(value, validatedPK_admEMailGroups);" & _
			"  }" & _
			"  function validatedPK_admEMailGroups(result) {" & _
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
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validatePKadmEMailGroups") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validatePKadmEMailGroups", validateScript)
		End If
  End Sub
	<System.Web.Services.WebMethod()> _
  Public Shared Function validatePK_admEMailGroups(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim EMailGroup As String = CType(aVal(1),String)
		Dim oVar As SIS.ADM.admEMailGroups = SIS.ADM.admEMailGroups.GetByID(EMailGroup)
    If Not oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record allready exists." 
    End If
    Return mRet
  End Function
End Class
