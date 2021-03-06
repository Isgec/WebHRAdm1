Partial Class EF_admITRegisterComplaint
  Inherits SIS.SYS.UpdateBase
  Protected Sub FVadmITRegisterComplaint_ItemCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewCommandEventArgs) Handles FVadmITRegisterComplaint.ItemCommand
    If e.CommandName.ToLower = "return" Then
      ObjectDataSource1.UpdateMethod = "UpdateReturn"
      FVadmITRegisterComplaint.UpdateItem(False)
    End If
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
  Protected Sub reload_subtype(s As Object, e As EventArgs)
    Dim oF_CallTypeID As LC_admITCallTypes = FVadmITRegisterComplaint.FindControl("F_CallTypeID")
    Dim oF_CallSubTypeID As LC_admITCallSubTypes = FVadmITRegisterComplaint.FindControl("F_CallSubTypeID")
    If oF_CallTypeID.SelectedValue <> "" Then
      oF_CallSubTypeID.OrderBy = oF_CallTypeID.SelectedValue
      oF_CallSubTypeID.Bind()
    End If
  End Sub
  Protected Sub FVadmITRegisterComplaint_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVadmITRegisterComplaint.PreRender
    'Dim oF_CallTypeID As LC_admITCallTypes = FVadmITRegisterComplaint.FindControl("F_CallTypeID")
    'Dim oF_CallSubTypeID As LC_admITCallSubTypes = FVadmITRegisterComplaint.FindControl("F_CallSubTypeID")
    'If oF_CallTypeID.SelectedValue <> "" Then
    '  oF_CallSubTypeID.OrderBy = oF_CallTypeID.SelectedValue
    '  oF_CallSubTypeID.Bind()
    'End If
    Dim oF_EndUserID_Display As Label = FVadmITRegisterComplaint.FindControl("F_EndUserID_Display")
    Dim oF_EndUserID As TextBox = FVadmITRegisterComplaint.FindControl("F_EndUserID")
    Dim strScriptEndUserID As String = "<script type=""text/javascript""> " &
      "function ACEEndUserID_Selected(sender, e) {" &
      "  var F_EndUserID = $get('" & oF_EndUserID.ClientID & "');" &
      "  var F_EndUserID_Display = $get('" & oF_EndUserID_Display.ClientID & "');" &
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
      "  var p = o.get_element();" &
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" &
      "  p.style.backgroundRepeat= 'no-repeat';" &
      "  p.style.backgroundPosition = 'right';" &
      "  o._contextKey = '';" &
      "}" &
      "function ACEEndUserID_Populated(o,e) {" &
      "  var p = o.get_element();" &
      "  p.style.backgroundImage  = 'none';" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_EndUserIDPopulating") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_EndUserIDPopulating", strScriptPopulatingEndUserID)
    End If
    Dim oF_AssignedTo_Display As Label = FVadmITRegisterComplaint.FindControl("F_AssignedTo_Display")
    Dim oF_AssignedTo As TextBox = FVadmITRegisterComplaint.FindControl("F_AssignedTo")
    Dim strScriptAssignedTo As String = "<script type=""text/javascript""> " &
      "function ACEAssignedTo_Selected(sender, e) {" &
      "  var F_AssignedTo = $get('" & oF_AssignedTo.ClientID & "');" &
      "  var F_AssignedTo_Display = $get('" & oF_AssignedTo_Display.ClientID & "');" &
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
      "  var p = o.get_element();" &
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" &
      "  p.style.backgroundRepeat= 'no-repeat';" &
      "  p.style.backgroundPosition = 'right';" &
      "  o._contextKey = '';" &
      "}" &
      "function ACEAssignedTo_Populated(o,e) {" &
      "  var p = o.get_element();" &
      "  p.style.backgroundImage  = 'none';" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_AssignedToPopulating") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_AssignedToPopulating", strScriptPopulatingAssignedTo)
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
    Dim FK_ADM_ITComplaints_HRM_EmployeesEndUserID As TextBox = FVadmITRegisterComplaint.FindControl("F_EndUserID")
    Dim validateScriptFK_ADM_ITComplaints_HRM_Employees As String = "<script type=""text/javascript"">" &
      "  function validate_FK_ADM_ITComplaints_HRM_Employees(o) {" &
      "    var value = o.id;" &
      "    var EndUserID = $get('" & FK_ADM_ITComplaints_HRM_EmployeesEndUserID.ClientID & "');" &
      "    if(EndUserID.value==''){" &
      "      if(validated_FK_ADM_ITComplaints_HRM_Employees.main){" &
      "        var o_d = $get(o.id +'_Display');" &
      "        try{o_d.innerHTML = '';}catch(ex){}" &
      "      }" &
      "      return true;" &
      "    }" &
      "    value = value + ',' + EndUserID.value ;" &
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" &
      "    o.style.backgroundRepeat= 'no-repeat';" &
      "    o.style.backgroundPosition = 'right';" &
      "    PageMethods.validate_FK_ADM_ITComplaints_HRM_Employees(value, validated_FK_ADM_ITComplaints_HRM_Employees);" &
      "  }" &
      "  validated_FK_ADM_ITComplaints_HRM_Employees.main = false;" &
      "  function validated_FK_ADM_ITComplaints_HRM_Employees(result) {" &
      "    var p = result.split('|');" &
      "    var o = $get(p[1]);" &
      "    if(validated_FK_ADM_ITComplaints_HRM_Employees.main){" &
      "      var o_d = $get(p[1]+'_Display');" &
      "      try{o_d.innerHTML = p[2];}catch(ex){}" &
      "    }" &
      "    o.style.backgroundImage  = 'none';" &
      "    if(p[0]=='1'){" &
      "      o.value='';" &
      "      o.focus();" &
      "    }" &
      "  }" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_ADM_ITComplaints_HRM_Employees") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_ADM_ITComplaints_HRM_Employees", validateScriptFK_ADM_ITComplaints_HRM_Employees)
    End If
    Dim FK_ADM_ITComplaints_ADM_Users1AssignedTo As TextBox = FVadmITRegisterComplaint.FindControl("F_AssignedTo")
    Dim validateScriptFK_ADM_ITComplaints_ADM_Users1 As String = "<script type=""text/javascript"">" &
      "  function validate_FK_ADM_ITComplaints_ADM_Users1(o) {" &
      "    var value = o.id;" &
      "    var AssignedTo = $get('" & FK_ADM_ITComplaints_ADM_Users1AssignedTo.ClientID & "');" &
      "    if(AssignedTo.value==''){" &
      "      if(validated_FK_ADM_ITComplaints_ADM_Users1.main){" &
      "        var o_d = $get(o.id +'_Display');" &
      "        try{o_d.innerHTML = '';}catch(ex){}" &
      "      }" &
      "      return true;" &
      "    }" &
      "    value = value + ',' + AssignedTo.value ;" &
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" &
      "    o.style.backgroundRepeat= 'no-repeat';" &
      "    o.style.backgroundPosition = 'right';" &
      "    PageMethods.validate_FK_ADM_ITComplaints_ADM_Users1(value, validated_FK_ADM_ITComplaints_ADM_Users1);" &
      "  }" &
      "  validated_FK_ADM_ITComplaints_ADM_Users1.main = false;" &
      "  function validated_FK_ADM_ITComplaints_ADM_Users1(result) {" &
      "    var p = result.split('|');" &
      "    var o = $get(p[1]);" &
      "    if(validated_FK_ADM_ITComplaints_ADM_Users1.main){" &
      "      var o_d = $get(p[1]+'_Display');" &
      "      try{o_d.innerHTML = p[2];}catch(ex){}" &
      "    }" &
      "    o.style.backgroundImage  = 'none';" &
      "    if(p[0]=='1'){" &
      "      o.value='';" &
      "      o.focus();" &
      "    }" &
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

  Private Sub FVadmITRegisterComplaint_Init(sender As Object, e As EventArgs) Handles FVadmITRegisterComplaint.Init
    DataClassName = "admITRegisterComplaint"
    SetFormView = FVadmITRegisterComplaint
  End Sub

  Private Sub TBLadmITRegisterComplaint_Init(sender As Object, e As EventArgs) Handles TBLadmITRegisterComplaint.Init
    SetToolBar = TBLadmITRegisterComplaint
  End Sub
End Class
