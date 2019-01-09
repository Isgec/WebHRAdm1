Partial Class GF_admITAttendComplaint
  Inherits System.Web.UI.Page
  Private _EditUrl As String = "~/ADM_Main/App_Edit/EF_admITAttendComplaint.aspx"
  Private _AddUrl As String = "~/ADM_Main/App_Create/AF_admITAttendComplaint.aspx"
	Private _InfoUrl As String = "~/ADM_Main/App_Forms/GF_admITComplaintResponse.aspx"
  Protected Sub Edit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _EditUrl  & "?CallID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?CallID=" & aVal(0)
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
    F_CallStatusID.SelectedValue = String.Empty
    If Not Session("F_CallStatusID") Is Nothing Then
      If Session("F_CallStatusID") <> String.Empty Then
        F_CallStatusID.SelectedValue = Session("F_CallStatusID")
      End If
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
		Dim validateScriptFK_ADM_ITComplaints_HRM_Employees As String = "<script type=""text/javascript"">" & _
			"  function validate_FK_ADM_ITComplaints_HRM_Employees(o) {" & _
			"    var value = o.id;" & _
			"    var EndUserID = $get('" & F_EndUserID.ClientID & "');" & _
			"    try{" & _
			"    if(EndUserID.value==''){" & _
			"      if(validated_FK_ADM_ITComplaints_HRM_Employees.main){" & _
			"        var o_d = $get(o.id +'_Display');" & _
			"        try{o_d.innerHTML = '';}catch(ex){}" & _
			"      }" & _
			"    }" & _
			"    value = value + ',' + EndUserID.value ;" & _
			"    }catch(ex){}" & _
			"    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
			"    o.style.backgroundRepeat= 'no-repeat';" & _
			"    o.style.backgroundPosition = 'right';" & _
			"    PageMethods.validate_FK_ADM_ITComplaints_HRM_Employees(value, validated_FK_ADM_ITComplaints_HRM_Employees);" & _
			"  }" & _
			"  validated_FK_ADM_ITComplaints_HRM_Employees.main = false;" & _
			"  function validated_FK_ADM_ITComplaints_HRM_Employees(result) {" & _
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
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_ADM_ITComplaints_HRM_Employees") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_ADM_ITComplaints_HRM_Employees", validateScriptFK_ADM_ITComplaints_HRM_Employees)
		End If
  End Sub
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_ADM_ITComplaints_HRM_Employees(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim EndUserID As String = CType(aVal(1),String)
		Dim oVar As SIS.ADM.admEmployees = SIS.ADM.admEmployees.GetByID(EndUserID)
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
	Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
		If e.CommandName.ToLower = "close" Then
			SIS.ADM.admITAttendComplaint.CloseComplaint(e.CommandArgument)
			GridView1.Sort(GridView1.SortExpression, GridView1.SortDirection)
		End If
	End Sub
End Class
