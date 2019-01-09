Partial Class GF_admQlfUpdate
  Inherits System.Web.UI.Page
  Private _EditUrl As String = "~/ADM_Main/App_Edit/EF_admQlfUpdate.aspx"
  Private _AddUrl As String = "~/ADM_Main/App_Create/AF_admQlfUpdate.aspx"
  Private _InfoUrl As String = "~/ADM_Main/App_Display/DF_admQlfUpdate.aspx"
  Protected Sub Edit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _EditUrl  & "?CardNo=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
	Protected Sub FwdAll_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
		If From_CardNo.Text <> String.Empty Then
			If To_CardNo.Text <> String.Empty Then
				If To_CardNo.Text >= From_CardNo.Text Then
					SIS.ADM.admQlfUpdate.SendSurveyLinkMailToAll(From_CardNo.Text, To_CardNo.Text)
				End If
			End If
		End If
	End Sub
	Protected Sub Fwd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
		Dim oBut As ImageButton = CType(sender, ImageButton)
		Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
		Dim oQlf As SIS.ADM.admQlfUpdate = SIS.ADM.admQlfUpdate.GetByID(aVal(0))
		SIS.ADM.admQlfUpdate.SendSurveyLinkMail(oQlf)
	End Sub
	Protected Sub GridView1_PageIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.PageIndexChanged
		Dim FileName As String = System.IO.Path.GetFileName(System.Web.HttpContext.Current.Request.Url.AbsolutePath)
		If Session("PageNoProvider") = True Then
			SIS.SYS.Utilities.GlobalVariables.PageNo(FileName, HttpContext.Current.Session("LoginID"), GridView1.PageIndex)
		Else
			Session("PageNo_" & FileName) = GridView1.PageIndex
		End If
	End Sub
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    ToolBar0_1.AddUrl = _AddUrl
    ToolBar0_1.EditUrl = _EditUrl
    ToolBar0_1.SearchUrl = _EditUrl
  End Sub
	Protected Sub ToolBar0_1_CancelClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ToolBar0_1.CancelClicked
		Response.Redirect(Session("ApplicationDefaultPage"))
	End Sub
  Protected Sub ToolBar0_1_PageChanged(ByVal NewPageNo As Integer, ByVal PageSize As Integer) Handles ToolBar0_1.PageChanged
    Dim FileName As String = System.IO.Path.GetFileName(System.Web.HttpContext.Current.Request.Url.AbsolutePath)
    GridView1.PageIndex = NewPageNo
    GridView1.PageSize = PageSize
    If Session("PageNoProvider") = True Then
      SIS.SYS.Utilities.GlobalVariables.PageNo(FileName, HttpContext.Current.Session("LoginID"), NewPageNo)
    Else
      Session("PageNo_" & FileName) = NewPageNo
    End If
    If Session("PageSizeProvider") = True Then
      SIS.SYS.Utilities.GlobalVariables.PageSize(FileName, HttpContext.Current.Session("LoginID"), PageSize)
    Else
      Session("PageSize_" & FileName) = PageSize
    End If
  End Sub
  Protected Sub GridView1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.Init
    Dim FileName As String = System.IO.Path.GetFileName(System.Web.HttpContext.Current.Request.Url.AbsolutePath)
    Try
      If Session("PageNoProvider") = True Then
        GridView1.PageIndex = SIS.SYS.Utilities.GlobalVariables.PageNo(FileName, HttpContext.Current.Session("LoginID"))
      Else
        GridView1.PageIndex = Session("PageNo_" & FileName)
      End If
      If Session("PageSizeProvider") = True Then
        GridView1.PageSize = SIS.SYS.Utilities.GlobalVariables.PageSize(FileName, HttpContext.Current.Session("LoginID"))
      Else
        GridView1.PageSize = Session("PageSize_" & FileName)
      End If
    Catch ex As Exception
      GridView1.PageIndex = 0
      GridView1.PageSize = 10
    End Try
  End Sub
  Protected Sub F_CardNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_CardNo.TextChanged
    Session("F_CardNo") = F_CardNo.Text
    Session("F_CardNo_Display") = F_CardNo_Display.Text
    Dim FileName As String = System.IO.Path.GetFileName(System.Web.HttpContext.Current.Request.Url.AbsolutePath)
    If Session("PageNoProvider") = True Then
      SIS.SYS.Utilities.GlobalVariables.PageNo(FileName, HttpContext.Current.Session("LoginID"), 0)
    Else
      Session("PageNo_" & FileName) = 0
    End If
  End Sub
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function CardNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.ADM.admEmployees.SelectadmEmployeesAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub F_DepartmentID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_DepartmentID.TextChanged
    Session("F_DepartmentID") = F_DepartmentID.Text
    Session("F_DepartmentID_Display") = F_DepartmentID_Display.Text
    Dim FileName As String = System.IO.Path.GetFileName(System.Web.HttpContext.Current.Request.Url.AbsolutePath)
    If Session("PageNoProvider") = True Then
      SIS.SYS.Utilities.GlobalVariables.PageNo(FileName, HttpContext.Current.Session("LoginID"), 0)
    Else
      Session("PageNo_" & FileName) = 0
    End If
  End Sub
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function DepartmentIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.ADM.admDepartments.SelectadmDepartmentsAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub F_Qlf1ID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_Qlf1ID.SelectedIndexChanged
    Session("F_Qlf1ID") = F_Qlf1ID.SelectedValue
    Dim FileName As String = System.IO.Path.GetFileName(System.Web.HttpContext.Current.Request.Url.AbsolutePath)
    If Session("PageNoProvider") = True Then
      SIS.SYS.Utilities.GlobalVariables.PageNo(FileName, HttpContext.Current.Session("LoginID"), 0)
    Else
      Session("PageNo_" & FileName) = 0
    End If
  End Sub
  Protected Sub F_Qlf2ID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_Qlf2ID.SelectedIndexChanged
    Session("F_Qlf2ID") = F_Qlf2ID.SelectedValue
    Dim FileName As String = System.IO.Path.GetFileName(System.Web.HttpContext.Current.Request.Url.AbsolutePath)
    If Session("PageNoProvider") = True Then
      SIS.SYS.Utilities.GlobalVariables.PageNo(FileName, HttpContext.Current.Session("LoginID"), 0)
    Else
      Session("PageNo_" & FileName) = 0
    End If
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_CardNo_Display.Text = String.Empty
    If Not Session("F_CardNo_Display") Is Nothing Then
      If Session("F_CardNo_Display") <> String.Empty Then
        F_CardNo_Display.Text = Session("F_CardNo_Display")
      End If
    End If
    F_CardNo.Text = String.Empty
    If Not Session("F_CardNo") Is Nothing Then
      If Session("F_CardNo") <> String.Empty Then
        F_CardNo.Text = Session("F_CardNo")
      End If
    End If
		Dim strScriptCardNo As String = "<script type=""text/javascript""> " & _
			"function ACECardNo_Selected(sender, e) {" & _
			"  var F_CardNo = $get('" & F_CardNo.ClientID & "');" & _
			"  var F_CardNo_Display = $get('" & F_CardNo_Display.ClientID & "');" & _
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
			"  var p = $get('" & F_CardNo.ClientID & "');" & _
			"  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
			"  p.style.backgroundRepeat= 'no-repeat';" & _
			"  p.style.backgroundPosition = 'right';" & _
			"  o._contextKey = '';" & _
			"}" & _
			"function ACECardNo_Populated(o,e) {" & _
			"  var p = $get('" & F_CardNo.ClientID & "');" & _
			"  p.style.backgroundImage  = 'none';" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("F_CardNoPopulating") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_CardNoPopulating", strScriptPopulatingCardNo)
			End If
    F_DepartmentID_Display.Text = String.Empty
    If Not Session("F_DepartmentID_Display") Is Nothing Then
      If Session("F_DepartmentID_Display") <> String.Empty Then
        F_DepartmentID_Display.Text = Session("F_DepartmentID_Display")
      End If
    End If
    F_DepartmentID.Text = String.Empty
    If Not Session("F_DepartmentID") Is Nothing Then
      If Session("F_DepartmentID") <> String.Empty Then
        F_DepartmentID.Text = Session("F_DepartmentID")
      End If
    End If
		Dim strScriptDepartmentID As String = "<script type=""text/javascript""> " & _
			"function ACEDepartmentID_Selected(sender, e) {" & _
			"  var F_DepartmentID = $get('" & F_DepartmentID.ClientID & "');" & _
			"  var F_DepartmentID_Display = $get('" & F_DepartmentID_Display.ClientID & "');" & _
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
			"  var p = $get('" & F_DepartmentID.ClientID & "');" & _
			"  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
			"  p.style.backgroundRepeat= 'no-repeat';" & _
			"  p.style.backgroundPosition = 'right';" & _
			"  o._contextKey = '';" & _
			"}" & _
			"function ACEDepartmentID_Populated(o,e) {" & _
			"  var p = $get('" & F_DepartmentID.ClientID & "');" & _
			"  p.style.backgroundImage  = 'none';" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("F_DepartmentIDPopulating") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_DepartmentIDPopulating", strScriptPopulatingDepartmentID)
			End If
    F_Qlf1ID.SelectedValue = String.Empty
    If Not Session("F_Qlf1ID") Is Nothing Then
      If Session("F_Qlf1ID") <> String.Empty Then
        F_Qlf1ID.SelectedValue = Session("F_Qlf1ID")
      End If
    End If
    F_Qlf2ID.SelectedValue = String.Empty
    If Not Session("F_Qlf2ID") Is Nothing Then
      If Session("F_Qlf2ID") <> String.Empty Then
        F_Qlf2ID.SelectedValue = Session("F_Qlf2ID")
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
		Dim validateScriptFK_HRM_QlfUpdate_HRM_Departments As String = "<script type=""text/javascript"">" & _
			"  function validate_FK_HRM_QlfUpdate_HRM_Departments(o) {" & _
			"    var value = o.id;" & _
			"    var DepartmentID = $get('" & F_DepartmentID.ClientID & "');" & _
			"    try{" & _
			"    if(DepartmentID.value==''){" & _
			"      if(validated_FK_HRM_QlfUpdate_HRM_Departments.main){" & _
			"        var o_d = $get(o.id +'_Display');" & _
			"        try{o_d.innerHTML = '';}catch(ex){}" & _
			"      }" & _
			"    }" & _
			"    value = value + ',' + DepartmentID.value ;" & _
			"    }catch(ex){}" & _
			"    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
			"    o.style.backgroundRepeat= 'no-repeat';" & _
			"    o.style.backgroundPosition = 'right';" & _
			"    PageMethods.validate_FK_HRM_QlfUpdate_HRM_Departments(value, validated_FK_HRM_QlfUpdate_HRM_Departments);" & _
			"  }" & _
			"  validated_FK_HRM_QlfUpdate_HRM_Departments.main = false;" & _
			"  function validated_FK_HRM_QlfUpdate_HRM_Departments(result) {" & _
			"    var p = result.split('|');" & _
			"    var o = $get(p[1]);" & _
			"    var o_d = $get(p[1]+'_Display');" & _
			"    try{o_d.innerHTML = p[2];}catch(ex){}" & _
			"    o.style.backgroundImage  = 'none';" & _
			"    if(p[0]=='1'){" & _
			"      o.value='';" & _
			"      try{o_d.innerHTML = '';}catch(ex){}" & _
			"      __doPostBack(o.id, o.value);" & _
			"    }" & _
			"    else" & _
			"      __doPostBack(o.id, o.value);" & _
			"  }" & _
		  "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_HRM_QlfUpdate_HRM_Departments") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_HRM_QlfUpdate_HRM_Departments", validateScriptFK_HRM_QlfUpdate_HRM_Departments)
		End If
		Dim validateScriptFK_HRM_QlfUpdate_HRM_Employees As String = "<script type=""text/javascript"">" & _
			"  function validate_FK_HRM_QlfUpdate_HRM_Employees(o) {" & _
			"    var value = o.id;" & _
			"    var CardNo = $get('" & F_CardNo.ClientID & "');" & _
			"    try{" & _
			"    if(CardNo.value==''){" & _
			"      if(validated_FK_HRM_QlfUpdate_HRM_Employees.main){" & _
			"        var o_d = $get(o.id +'_Display');" & _
			"        try{o_d.innerHTML = '';}catch(ex){}" & _
			"      }" & _
			"    }" & _
			"    value = value + ',' + CardNo.value ;" & _
			"    }catch(ex){}" & _
			"    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
			"    o.style.backgroundRepeat= 'no-repeat';" & _
			"    o.style.backgroundPosition = 'right';" & _
			"    PageMethods.validate_FK_HRM_QlfUpdate_HRM_Employees(value, validated_FK_HRM_QlfUpdate_HRM_Employees);" & _
			"  }" & _
			"  validated_FK_HRM_QlfUpdate_HRM_Employees.main = false;" & _
			"  function validated_FK_HRM_QlfUpdate_HRM_Employees(result) {" & _
			"    var p = result.split('|');" & _
			"    var o = $get(p[1]);" & _
			"    var o_d = $get(p[1]+'_Display');" & _
			"    try{o_d.innerHTML = p[2];}catch(ex){}" & _
			"    o.style.backgroundImage  = 'none';" & _
			"    if(p[0]=='1'){" & _
			"      o.value='';" & _
			"      try{o_d.innerHTML = '';}catch(ex){}" & _
			"      __doPostBack(o.id, o.value);" & _
			"    }" & _
			"    else" & _
			"      __doPostBack(o.id, o.value);" & _
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
  Protected Sub GridView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.DataBound
    With ToolBar0_1
      .CurrentPage = GridView1.PageIndex
      .TotalPages = GridView1.PageCount
      .RecordsPerPage = GridView1.PageSize
    End With
  End Sub
	Protected Sub ToolBar0_1_SearchClicked(ByVal SearchText As String, ByVal SearchState As Boolean) Handles ToolBar0_1.SearchClicked
		GridView1.PageIndex = 0
		ObjectDataSource1.SelectParameters("SearchState").DefaultValue = SearchState
		ObjectDataSource1.SelectParameters("SearchText").DefaultValue = SearchText
	End Sub
End Class
