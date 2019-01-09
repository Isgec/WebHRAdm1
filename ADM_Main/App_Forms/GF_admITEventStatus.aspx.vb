Partial Class GF_admITEventStatus
  Inherits System.Web.UI.Page
  Private _EditUrl As String = "~/ADM_Main/App_Edit/EF_admITEventStatus.aspx"
  Private _AddUrl As String = "~/ADM_Main/App_Create/AF_admITEventStatus.aspx"
  Private _InfoUrl As String = "~/ADM_Main/App_Display/DF_admITEventStatus.aspx"
  Protected Sub Edit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _EditUrl  & "?EventID=" & aVal(0) & "&ITServiceID=" & aVal(1)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?EventID=" & aVal(0) & "&ITServiceID=" & aVal(1)
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
  Protected Sub F_EventID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_EventID.TextChanged
    Session("F_EventID") = F_EventID.Text
    Session("F_EventID_Display") = F_EventID_Display.Text
    Dim FileName As String = System.IO.Path.GetFileName(System.Web.HttpContext.Current.Request.Url.AbsolutePath)
    If Session("PageNoProvider") = True Then
      SIS.SYS.Utilities.GlobalVariables.PageNo(FileName, HttpContext.Current.Session("LoginID"), 0)
    Else
      Session("PageNo_" & FileName) = 0
    End If
  End Sub
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function EventIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.ADM.admITEventTransactions.SelectadmITEventTransactionsAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub F_ITServiceID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_ITServiceID.TextChanged
    Session("F_ITServiceID") = F_ITServiceID.Text
    Session("F_ITServiceID_Display") = F_ITServiceID_Display.Text
    Dim FileName As String = System.IO.Path.GetFileName(System.Web.HttpContext.Current.Request.Url.AbsolutePath)
    If Session("PageNoProvider") = True Then
      SIS.SYS.Utilities.GlobalVariables.PageNo(FileName, HttpContext.Current.Session("LoginID"), 0)
    Else
      Session("PageNo_" & FileName) = 0
    End If
  End Sub
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ITServiceIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.ADM.admITServices.SelectadmITServicesAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_EventID_Display.Text = String.Empty
    If Not Session("F_EventID_Display") Is Nothing Then
      If Session("F_EventID_Display") <> String.Empty Then
        F_EventID_Display.Text = Session("F_EventID_Display")
      End If
    End If
    F_EventID.Text = String.Empty
    If Not Session("F_EventID") Is Nothing Then
      If Session("F_EventID") <> String.Empty Then
        F_EventID.Text = Session("F_EventID")
      End If
    End If
		Dim strScriptEventID As String = "<script type=""text/javascript""> " & _
			"function ACEEventID_Selected(sender, e) {" & _
			"  var F_EventID = $get('" & F_EventID.ClientID & "');" & _
			"  var F_EventID_Display = $get('" & F_EventID_Display.ClientID & "');" & _
			"  var retval = e.get_value();" & _
			"  var p = retval.split('|');" & _
			"  F_EventID.value = p[0];" & _
			"  F_EventID_Display.innerHTML = e.get_text();" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("F_EventID") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_EventID", strScriptEventID)
			End If
		Dim strScriptPopulatingEventID As String = "<script type=""text/javascript""> " & _
			"function ACEEventID_Populating(o,e) {" & _
			"  var p = $get('" & F_EventID.ClientID & "');" & _
			"  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
			"  p.style.backgroundRepeat= 'no-repeat';" & _
			"  p.style.backgroundPosition = 'right';" & _
			"  o._contextKey = '';" & _
			"}" & _
			"function ACEEventID_Populated(o,e) {" & _
			"  var p = $get('" & F_EventID.ClientID & "');" & _
			"  p.style.backgroundImage  = 'none';" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("F_EventIDPopulating") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_EventIDPopulating", strScriptPopulatingEventID)
			End If
    F_ITServiceID_Display.Text = String.Empty
    If Not Session("F_ITServiceID_Display") Is Nothing Then
      If Session("F_ITServiceID_Display") <> String.Empty Then
        F_ITServiceID_Display.Text = Session("F_ITServiceID_Display")
      End If
    End If
    F_ITServiceID.Text = String.Empty
    If Not Session("F_ITServiceID") Is Nothing Then
      If Session("F_ITServiceID") <> String.Empty Then
        F_ITServiceID.Text = Session("F_ITServiceID")
      End If
    End If
		Dim strScriptITServiceID As String = "<script type=""text/javascript""> " & _
			"function ACEITServiceID_Selected(sender, e) {" & _
			"  var F_ITServiceID = $get('" & F_ITServiceID.ClientID & "');" & _
			"  var F_ITServiceID_Display = $get('" & F_ITServiceID_Display.ClientID & "');" & _
			"  var retval = e.get_value();" & _
			"  var p = retval.split('|');" & _
			"  F_ITServiceID.value = p[0];" & _
			"  F_ITServiceID_Display.innerHTML = e.get_text();" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("F_ITServiceID") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_ITServiceID", strScriptITServiceID)
			End If
		Dim strScriptPopulatingITServiceID As String = "<script type=""text/javascript""> " & _
			"function ACEITServiceID_Populating(o,e) {" & _
			"  var p = $get('" & F_ITServiceID.ClientID & "');" & _
			"  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
			"  p.style.backgroundRepeat= 'no-repeat';" & _
			"  p.style.backgroundPosition = 'right';" & _
			"  o._contextKey = '';" & _
			"}" & _
			"function ACEITServiceID_Populated(o,e) {" & _
			"  var p = $get('" & F_ITServiceID.ClientID & "');" & _
			"  p.style.backgroundImage  = 'none';" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("F_ITServiceIDPopulating") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_ITServiceIDPopulating", strScriptPopulatingITServiceID)
			End If
  End Sub
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
