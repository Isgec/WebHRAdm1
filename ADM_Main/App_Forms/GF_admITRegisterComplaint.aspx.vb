Partial Class GF_admITRegisterComplaint
  Inherits SIS.SYS.GridBase
  Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVadmITRegisterComplaint.RowCommand
    If e.CommandName.ToLower = "lgclose" Then
      SIS.ADM.admITAttendComplaint.CloseComplaint(e.CommandArgument)
      GVadmITRegisterComplaint.DataBind()
    End If
    If e.CommandName.ToLower = "lgedit" Then
      Dim aVal() As String = e.CommandArgument.ToString.Split(",".ToCharArray)
      Dim RedirectUrl As String = TBLadmITRegisterComplaint.EditUrl & "?CallID=" & aVal(0)
      Response.Redirect(RedirectUrl)
    End If
    If e.CommandName.ToLower = "lgatnd" Then
      Dim aVal() As String = e.CommandArgument.ToString.Split(",".ToCharArray)
      Dim RedirectUrl As String = "~/ADM_Main/App_Create/AF_admITComplaintResponse.aspx?CallID=" & aVal(0)
      Response.Redirect(RedirectUrl)
    End If
    If e.CommandName.ToLower = "lgdetl" Then
      Dim aVal() As String = e.CommandArgument.ToString.Split(",".ToCharArray)
      Dim RedirectUrl As String = "~/ADM_Main/App_Forms/GF_admITComplaintResponse.aspx?CallID=" & aVal(0)
      Response.Redirect(RedirectUrl)
    End If
  End Sub
  Protected Sub GVadmITRegisterComplaint_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVadmITRegisterComplaint.Init
    DataClassName = "admITRegisterComplaint"
    SetGridView = GVadmITRegisterComplaint
  End Sub
  Private Sub TBLadmITRegisterComplaint_Init(sender As Object, e As EventArgs) Handles TBLadmITRegisterComplaint.Init
    SetToolBar = TBLadmITRegisterComplaint
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function EndUserIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.ADM.admEmployees.SelectadmEmployeesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function AssignedToCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.ADM.admUsers.SelectadmUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
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
    Dim strScriptEndUserID As String = "<script type=""text/javascript""> " &
     "function ACEEndUserID_Selected(sender, e) {" &
     "  var F_EndUserID = $get('" & F_EndUserID.ClientID & "');" &
     "  var F_EndUserID_Display = $get('" & F_EndUserID_Display.ClientID & "');" &
     "  var retval = e.get_value();" &
     "  var p = retval.split('|');" &
     "  F_EndUserID.value = p[0];" &
     "  F_EndUserID_Display.innerHTML = e.get_text();" &
     "}" &
     "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_EndUserID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_EndUserID", strScriptEndUserID)
    End If
    Dim strScriptPopulatingEndUserID As String = "<script type=""text/javascript""> " &
     "function ACEEndUserID_Populating(o,e) {" &
     "  var p = $get('" & F_EndUserID.ClientID & "');" &
     "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" &
     "  p.style.backgroundRepeat= 'no-repeat';" &
     "  p.style.backgroundPosition = 'right';" &
     "  o._contextKey = '';" &
     "}" &
     "function ACEEndUserID_Populated(o,e) {" &
     "  var p = $get('" & F_EndUserID.ClientID & "');" &
     "  p.style.backgroundImage  = 'none';" &
     "}" &
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
    Dim strScriptAssignedTo As String = "<script type=""text/javascript""> " &
     "function ACEAssignedTo_Selected(sender, e) {" &
     "  var F_AssignedTo = $get('" & F_AssignedTo.ClientID & "');" &
     "  var F_AssignedTo_Display = $get('" & F_AssignedTo_Display.ClientID & "');" &
     "  var retval = e.get_value();" &
     "  var p = retval.split('|');" &
     "  F_AssignedTo.value = p[0];" &
     "  F_AssignedTo_Display.innerHTML = e.get_text();" &
     "}" &
     "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_AssignedTo") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_AssignedTo", strScriptAssignedTo)
    End If
    Dim strScriptPopulatingAssignedTo As String = "<script type=""text/javascript""> " &
     "function ACEAssignedTo_Populating(o,e) {" &
     "  var p = $get('" & F_AssignedTo.ClientID & "');" &
     "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" &
     "  p.style.backgroundRepeat= 'no-repeat';" &
     "  p.style.backgroundPosition = 'right';" &
     "  o._contextKey = '';" &
     "}" &
     "function ACEAssignedTo_Populated(o,e) {" &
     "  var p = $get('" & F_AssignedTo.ClientID & "');" &
     "  p.style.backgroundImage  = 'none';" &
     "}" &
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
    Dim validateScriptEndUserID As String = "<script type=""text/javascript"">" &
     "  function validate_EndUserID(o) {" &
     "    validated_FK_ADM_ITComplaints_HRM_Employees.main = true;" &
     "    validate_FK_ADM_ITComplaints_HRM_Employees(o);" &
     "  }" &
     "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateEndUserID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateEndUserID", validateScriptEndUserID)
    End If
    Dim validateScriptAssignedTo As String = "<script type=""text/javascript"">" &
     "  function validate_AssignedTo(o) {" &
     "    validated_FK_ADM_ITComplaints_ADM_Users1.main = true;" &
     "    validate_FK_ADM_ITComplaints_ADM_Users1(o);" &
     "  }" &
     "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateAssignedTo") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateAssignedTo", validateScriptAssignedTo)
    End If
    Dim validateScriptFK_ADM_ITComplaints_HRM_Employees As String = "<script type=""text/javascript"">" &
     "  function validate_FK_ADM_ITComplaints_HRM_Employees(o) {" &
     "    var value = o.id;" &
     "    var EndUserID = $get('" & F_EndUserID.ClientID & "');" &
     "    try{" &
     "    if(EndUserID.value==''){" &
     "      if(validated_FK_ADM_ITComplaints_HRM_Employees.main){" &
     "        var o_d = $get(o.id +'_Display');" &
     "        try{o_d.innerHTML = '';}catch(ex){}" &
     "      }" &
     "    }" &
     "    value = value + ',' + EndUserID.value ;" &
     "    }catch(ex){}" &
     "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" &
     "    o.style.backgroundRepeat= 'no-repeat';" &
     "    o.style.backgroundPosition = 'right';" &
     "    PageMethods.validate_FK_ADM_ITComplaints_HRM_Employees(value, validated_FK_ADM_ITComplaints_HRM_Employees);" &
     "  }" &
     "  validated_FK_ADM_ITComplaints_HRM_Employees.main = false;" &
     "  function validated_FK_ADM_ITComplaints_HRM_Employees(result) {" &
     "    var p = result.split('|');" &
     "    var o = $get(p[1]);" &
     "    var o_d = $get(p[1]+'_Display');" &
     "    try{o_d.innerHTML = p[2];}catch(ex){}" &
     "    o.style.backgroundImage  = 'none';" &
     "    if(p[0]=='1'){" &
     "      o.value='';" &
     "      try{o_d.innerHTML = '';}catch(ex){}" &
     "      __doPostBack(o.id, o.value);" &
     "    }" &
     "    else" &
     "      __doPostBack(o.id, o.value);" &
     "  }" &
     "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_ADM_ITComplaints_HRM_Employees") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_ADM_ITComplaints_HRM_Employees", validateScriptFK_ADM_ITComplaints_HRM_Employees)
    End If
    Dim validateScriptFK_ADM_ITComplaints_ADM_Users1 As String = "<script type=""text/javascript"">" &
     "  function validate_FK_ADM_ITComplaints_ADM_Users1(o) {" &
     "    var value = o.id;" &
     "    var AssignedTo = $get('" & F_AssignedTo.ClientID & "');" &
     "    try{" &
     "    if(AssignedTo.value==''){" &
     "      if(validated_FK_ADM_ITComplaints_ADM_Users1.main){" &
     "        var o_d = $get(o.id +'_Display');" &
     "        try{o_d.innerHTML = '';}catch(ex){}" &
     "      }" &
     "    }" &
     "    value = value + ',' + AssignedTo.value ;" &
     "    }catch(ex){}" &
     "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" &
     "    o.style.backgroundRepeat= 'no-repeat';" &
     "    o.style.backgroundPosition = 'right';" &
     "    PageMethods.validate_FK_ADM_ITComplaints_ADM_Users1(value, validated_FK_ADM_ITComplaints_ADM_Users1);" &
     "  }" &
     "  validated_FK_ADM_ITComplaints_ADM_Users1.main = false;" &
     "  function validated_FK_ADM_ITComplaints_ADM_Users1(result) {" &
     "    var p = result.split('|');" &
     "    var o = $get(p[1]);" &
     "    var o_d = $get(p[1]+'_Display');" &
     "    try{o_d.innerHTML = p[2];}catch(ex){}" &
     "    o.style.backgroundImage  = 'none';" &
     "    if(p[0]=='1'){" &
     "      o.value='';" &
     "      try{o_d.innerHTML = '';}catch(ex){}" &
     "      __doPostBack(o.id, o.value);" &
     "    }" &
     "    else" &
     "      __doPostBack(o.id, o.value);" &
     "  }" &
     "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_ADM_ITComplaints_ADM_Users1") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_ADM_ITComplaints_ADM_Users1", validateScriptFK_ADM_ITComplaints_ADM_Users1)
    End If
  End Sub
  <System.Web.Services.WebMethod()>
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
  <System.Web.Services.WebMethod()>
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
