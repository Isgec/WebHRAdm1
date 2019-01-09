Partial Class GF_admRegisterComplaint
	Inherits System.Web.UI.Page
	Private _EditUrl As String = "~/ADM_Main/App_Edit/EF_admRegisterComplaint.aspx"
	Private _AddUrl As String = "~/ADM_Main/App_Create/AF_admRegisterComplaint.aspx"
	Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
		If e.CommandName.ToLower = "close" Then
			SIS.ADM.admAttendComplaint.CloseComplaint(e.CommandArgument)
			GridView1.Sort(GridView1.SortExpression, GridView1.SortDirection)
		End If
	End Sub
	Protected Sub Edit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
		Dim oBut As ImageButton = CType(sender, ImageButton)
		Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
		Dim RedirectUrl As String = _EditUrl & "?CallID=" & aVal(0)
		Response.Redirect(RedirectUrl)
	End Sub
	Protected Sub Atnd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
		Dim oBut As ImageButton = CType(sender, ImageButton)
		Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
		Dim RedirectUrl As String = "~/ADM_Main/App_Create/AF_admComplaintResponse.aspx?CallID=" & aVal(0)
		Response.Redirect(RedirectUrl)
	End Sub
	Protected Sub Dets_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
		Dim oBut As ImageButton = CType(sender, ImageButton)
		Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
		Dim RedirectUrl As String = "~/ADM_Main/App_Forms/GF_admComplaintResponse.aspx?CallID=" & aVal(0)
		Response.Redirect(RedirectUrl)
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
		If Not Page.IsPostBack And Not Page.IsCallback Then
			ToolBar0_1.AddUrl = _AddUrl
		End If
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
	Protected Sub F_EndUserID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_EndUserID.TextChanged
		Session("F_EndUserID") = F_EndUserID.Text
		Session("F_EndUserID_Display") = F_EndUserID_Display.Text
		Dim FileName As String = System.IO.Path.GetFileName(System.Web.HttpContext.Current.Request.Url.AbsolutePath)
		If Session("PageNoProvider") = True Then
			SIS.SYS.Utilities.GlobalVariables.PageNo(FileName, HttpContext.Current.Session("LoginID"), 0)
		Else
			Session("PageNo_" & FileName) = 0
		End If
	End Sub
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
	 Public Shared Function EndUserIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
		Return SIS.ADM.admEmployees.SelectadmEmployeesAutoCompleteList(prefixText, count, contextKey)
	End Function
	Protected Sub F_CallTypeID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_CallTypeID.SelectedIndexChanged
		Session("F_CallTypeID") = F_CallTypeID.SelectedValue
		Dim FileName As String = System.IO.Path.GetFileName(System.Web.HttpContext.Current.Request.Url.AbsolutePath)
		If Session("PageNoProvider") = True Then
			SIS.SYS.Utilities.GlobalVariables.PageNo(FileName, HttpContext.Current.Session("LoginID"), 0)
		Else
			Session("PageNo_" & FileName) = 0
		End If
	End Sub
	Protected Sub F_AssignedTo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_AssignedTo.TextChanged
		Session("F_AssignedTo") = F_AssignedTo.Text
		Session("F_AssignedTo_Display") = F_AssignedTo_Display.Text
		Dim FileName As String = System.IO.Path.GetFileName(System.Web.HttpContext.Current.Request.Url.AbsolutePath)
		If Session("PageNoProvider") = True Then
			SIS.SYS.Utilities.GlobalVariables.PageNo(FileName, HttpContext.Current.Session("LoginID"), 0)
		Else
			Session("PageNo_" & FileName) = 0
		End If
	End Sub
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
	 Public Shared Function AssignedToCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
		Return SIS.ADM.admUsers.SelectadmChennaiUsersAutoCompleteList(prefixText, count, contextKey)
	End Function
	Protected Sub F_CallStatusID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_CallStatusID.SelectedIndexChanged
		Session("F_CallStatusID") = F_CallStatusID.SelectedValue
		Dim FileName As String = System.IO.Path.GetFileName(System.Web.HttpContext.Current.Request.Url.AbsolutePath)
		If Session("PageNoProvider") = True Then
			SIS.SYS.Utilities.GlobalVariables.PageNo(FileName, HttpContext.Current.Session("LoginID"), 0)
		Else
			Session("PageNo_" & FileName) = 0
		End If
	End Sub
	Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
		If Not Page.IsPostBack And Not Page.IsCallback Then
			Session("F_AssignedTo") = HttpContext.Current.Session("LoginID")
			Session("F_CallStatusID") = "NOTCLOSED"
		End If
		F_EndUserID_Display.Text = String.Empty
		If Not Session("F_EndUserID_Display") Is Nothing Then
			If Session("F_EndUserID_Display") <> String.Empty Then
				F_EndUserID_Display.Text = Session("F_EndUserID_Display")
			End If
		End If
		F_EndUserID.Text = String.Empty
		If Not Session("F_EndUserID") Is Nothing Then
			If Session("F_EndUserID") <> String.Empty Then
				F_EndUserID.Text = Session("F_EndUserID")
			End If
		End If
		Dim strScriptEndUserID As String = "<script type=""text/javascript""> " & _
		 "function ACEEndUserID_Selected(sender, e) {" & _
		 "  var F_EndUserID = $get('" & F_EndUserID.ClientID & "');" & _
		 "  var F_EndUserID_Display = $get('" & F_EndUserID_Display.ClientID & "');" & _
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
		 "  var p = $get('" & F_EndUserID.ClientID & "');" & _
		 "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
		 "  p.style.backgroundRepeat= 'no-repeat';" & _
		 "  p.style.backgroundPosition = 'right';" & _
		 "  o._contextKey = '';" & _
		 "}" & _
		 "function ACEEndUserID_Populated(o,e) {" & _
		 "  var p = $get('" & F_EndUserID.ClientID & "');" & _
		 "  p.style.backgroundImage  = 'none';" & _
		 "}" & _
		 "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("F_EndUserIDPopulating") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_EndUserIDPopulating", strScriptPopulatingEndUserID)
		End If
		F_CallTypeID.SelectedValue = String.Empty
		If Not Session("F_CallTypeID") Is Nothing Then
			If Session("F_CallTypeID") <> String.Empty Then
				F_CallTypeID.SelectedValue = Session("F_CallTypeID")
			End If
		End If
		F_AssignedTo_Display.Text = String.Empty
		If Not Session("F_AssignedTo_Display") Is Nothing Then
			If Session("F_AssignedTo_Display") <> String.Empty Then
				F_AssignedTo_Display.Text = Session("F_AssignedTo_Display")
			End If
		End If
		F_AssignedTo.Text = String.Empty
		If Not Session("F_AssignedTo") Is Nothing Then
			If Session("F_AssignedTo") <> String.Empty Then
				F_AssignedTo.Text = Session("F_AssignedTo")
			End If
		End If
		Dim strScriptAssignedTo As String = "<script type=""text/javascript""> " & _
		 "function ACEAssignedTo_Selected(sender, e) {" & _
		 "  var F_AssignedTo = $get('" & F_AssignedTo.ClientID & "');" & _
		 "  var F_AssignedTo_Display = $get('" & F_AssignedTo_Display.ClientID & "');" & _
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
		 "  var p = $get('" & F_AssignedTo.ClientID & "');" & _
		 "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
		 "  p.style.backgroundRepeat= 'no-repeat';" & _
		 "  p.style.backgroundPosition = 'right';" & _
		 "  o._contextKey = '';" & _
		 "}" & _
		 "function ACEAssignedTo_Populated(o,e) {" & _
		 "  var p = $get('" & F_AssignedTo.ClientID & "');" & _
		 "  p.style.backgroundImage  = 'none';" & _
		 "}" & _
		 "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("F_AssignedToPopulating") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_AssignedToPopulating", strScriptPopulatingAssignedTo)
		End If
		F_CallStatusID.SelectedValue = String.Empty
		If Not Session("F_CallStatusID") Is Nothing Then
			If Session("F_CallStatusID") <> String.Empty Then
				F_CallStatusID.SelectedValue = Session("F_CallStatusID")
			End If
		End If
		Dim validateScriptEndUserID As String = "<script type=""text/javascript"">" & _
		 "  function validate_EndUserID(o) {" & _
		 "    validated_FK_ADM_Complaints_HRM_Employees.main = true;" & _
		 "    validate_FK_ADM_Complaints_HRM_Employees(o);" & _
		 "  }" & _
		 "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateEndUserID") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateEndUserID", validateScriptEndUserID)
		End If
		Dim validateScriptAssignedTo As String = "<script type=""text/javascript"">" & _
		 "  function validate_AssignedTo(o) {" & _
		 "    validated_FK_ADM_Complaints_ADM_Users1.main = true;" & _
		 "    validate_FK_ADM_Complaints_ADM_Users1(o);" & _
		 "  }" & _
		 "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateAssignedTo") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateAssignedTo", validateScriptAssignedTo)
		End If
		Dim validateScriptFK_ADM_Complaints_HRM_Employees As String = "<script type=""text/javascript"">" & _
		 "  function validate_FK_ADM_Complaints_HRM_Employees(o) {" & _
		 "    var value = o.id;" & _
		 "    var EndUserID = $get('" & F_EndUserID.ClientID & "');" & _
		 "    try{" & _
		 "    if(EndUserID.value==''){" & _
		 "      if(validated_FK_ADM_Complaints_HRM_Employees.main){" & _
		 "        var o_d = $get(o.id +'_Display');" & _
		 "        try{o_d.innerHTML = '';}catch(ex){}" & _
		 "      }" & _
		 "    }" & _
		 "    value = value + ',' + EndUserID.value ;" & _
		 "    }catch(ex){}" & _
		 "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
		 "    o.style.backgroundRepeat= 'no-repeat';" & _
		 "    o.style.backgroundPosition = 'right';" & _
		 "    PageMethods.validate_FK_ADM_Complaints_HRM_Employees(value, validated_FK_ADM_Complaints_HRM_Employees);" & _
		 "  }" & _
		 "  validated_FK_ADM_Complaints_HRM_Employees.main = false;" & _
		 "  function validated_FK_ADM_Complaints_HRM_Employees(result) {" & _
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
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_ADM_Complaints_HRM_Employees") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_ADM_Complaints_HRM_Employees", validateScriptFK_ADM_Complaints_HRM_Employees)
		End If
		Dim validateScriptFK_ADM_Complaints_ADM_Users1 As String = "<script type=""text/javascript"">" & _
		 "  function validate_FK_ADM_Complaints_ADM_Users1(o) {" & _
		 "    var value = o.id;" & _
		 "    var AssignedTo = $get('" & F_AssignedTo.ClientID & "');" & _
		 "    try{" & _
		 "    if(AssignedTo.value==''){" & _
		 "      if(validated_FK_ADM_Complaints_ADM_Users1.main){" & _
		 "        var o_d = $get(o.id +'_Display');" & _
		 "        try{o_d.innerHTML = '';}catch(ex){}" & _
		 "      }" & _
		 "    }" & _
		 "    value = value + ',' + AssignedTo.value ;" & _
		 "    }catch(ex){}" & _
		 "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
		 "    o.style.backgroundRepeat= 'no-repeat';" & _
		 "    o.style.backgroundPosition = 'right';" & _
		 "    PageMethods.validate_FK_ADM_Complaints_ADM_Users1(value, validated_FK_ADM_Complaints_ADM_Users1);" & _
		 "  }" & _
		 "  validated_FK_ADM_Complaints_ADM_Users1.main = false;" & _
		 "  function validated_FK_ADM_Complaints_ADM_Users1(result) {" & _
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
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_ADM_Complaints_ADM_Users1") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_ADM_Complaints_ADM_Users1", validateScriptFK_ADM_Complaints_ADM_Users1)
		End If
	End Sub
	<System.Web.Services.WebMethod()> _
	 Public Shared Function validate_FK_ADM_Complaints_HRM_Employees(ByVal value As String) As String
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
	 Public Shared Function validate_FK_ADM_Complaints_ADM_Users1(ByVal value As String) As String
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
