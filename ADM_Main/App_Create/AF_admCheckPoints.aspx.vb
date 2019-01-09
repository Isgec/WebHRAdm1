Partial Class AF_admCheckPoints
  Inherits SIS.SYS.InsertBase
  Protected Sub FVadmCheckPoints_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVadmCheckPoints.Init
    DataClassName = "AadmCheckPoints"
    SetFormView = FVadmCheckPoints
  End Sub
  Protected Sub TBLadmCheckPoints_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLadmCheckPoints.Init
    SetToolBar = TBLadmCheckPoints
  End Sub
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function InitiatorCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.ADM.admUsers.SelectadmUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub FVadmCheckPoints_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVadmCheckPoints.PreRender
    Dim oF_ScheduleID As LC_admSchedules = FVadmCheckPoints.FindControl("F_ScheduleID")
    oF_ScheduleID.Enabled = True
    oF_ScheduleID.SelectedValue = String.Empty
    If Not Session("F_ScheduleID") Is Nothing Then
      If Session("F_ScheduleID") <> String.Empty Then
        oF_ScheduleID.SelectedValue = Session("F_ScheduleID")
      End If
    End If
    Dim oF_Initiator_Display As Label  = FVadmCheckPoints.FindControl("F_Initiator_Display")
    oF_Initiator_Display.Text = String.Empty
    If Not Session("F_Initiator_Display") Is Nothing Then
      If Session("F_Initiator_Display") <> String.Empty Then
        oF_Initiator_Display.Text = Session("F_Initiator_Display")
      End If
    End If
    Dim oF_Initiator As TextBox  = FVadmCheckPoints.FindControl("F_Initiator")
    oF_Initiator.Enabled = True
    oF_Initiator.Text = String.Empty
    If Not Session("F_Initiator") Is Nothing Then
      If Session("F_Initiator") <> String.Empty Then
        oF_Initiator.Text = Session("F_Initiator")
      End If
    End If
		Dim strScriptInitiator As String = "<script type=""text/javascript""> " & _
			"function ACEInitiator_Selected(o, e) {" & _
			"  var F_Initiator = $get('" & oF_Initiator.ClientID & "');" & _
			"  var F_Initiator_Display = $get('" & oF_Initiator_Display.ClientID & "');" & _
			"  var retval = e.get_value();" & _
			"  var p = retval.split('|');" & _
			"  F_Initiator.value = p[0];" & _
			"  F_Initiator_Display.innerHTML = e.get_text();" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("F_Initiator") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_Initiator", strScriptInitiator)
			End If
		Dim strScriptPopulatingInitiator As String = "<script type=""text/javascript""> " & _
			"function ACEInitiator_Populating(o,e) {" & _
			"  var p = o.get_element();" & _
			"  p.style.backgroundImage = 'url(../../images/loader.gif)';" & _
			"  p.style.backgroundRepeat = 'no-repeat';" & _
			"  p.style.backgroundPosition = 'right';" & _
			"  o._contextKey = '';" & _
			"}" & _
			"function ACEInitiator_Populated(o,e) {" & _
			"  var p = o.get_element();" & _
			"  p.style.backgroundImage  = 'none';" & _
			"}" & _
			"</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_InitiatorPopulating") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_InitiatorPopulating", strScriptPopulatingInitiator)
    End If
    Dim validateScriptScheduleID As String = "<script type=""text/javascript"">" & _
			"  function validate_ScheduleID(o) {" & _
			"    validated_FK_ADM_CheckPoints_ADM_Schedules.main = true;" & _
			"    validate_FK_ADM_CheckPoints_ADM_Schedules(o);" & _
			"  }" & _
		  "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateScheduleID") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateScheduleID", validateScriptScheduleID)
		End If
		Dim validateScriptInitiator As String = "<script type=""text/javascript"">" & _
			"  function validate_Initiator(o) {" & _
			"    validated_FK_ADM_CheckPoints_aspnet_Users.main = true;" & _
			"    validate_FK_ADM_CheckPoints_aspnet_Users(o);" & _
			"  }" & _
		  "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateInitiator") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateInitiator", validateScriptInitiator)
		End If
		Dim FK_ADM_CheckPoints_aspnet_UsersInitiator As TextBox = FVadmCheckPoints.FindControl("F_Initiator")
		Dim validateScriptFK_ADM_CheckPoints_aspnet_Users As String = "<script type=""text/javascript"">" & _
			"  function validate_FK_ADM_CheckPoints_aspnet_Users(o) {" & _
			"    var value = o.id;" & _
			"    var Initiator = $get('" & FK_ADM_CheckPoints_aspnet_UsersInitiator.ClientID & "');" & _
			"    if(Initiator.value==''){" & _
			"      if(validated_FK_ADM_CheckPoints_aspnet_Users.main){" & _
			"        var o_d = $get(o.id +'_Display');" & _
			"        try{o_d.innerHTML = '';}catch(ex){}" & _
			"      }" & _
			"      return true;" & _
			"    }" & _
			"    value = value + ',' + Initiator.value ;" & _
			"    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
			"    o.style.backgroundRepeat= 'no-repeat';" & _
			"    o.style.backgroundPosition = 'right';" & _
			"    PageMethods.validate_FK_ADM_CheckPoints_aspnet_Users(value, validated_FK_ADM_CheckPoints_aspnet_Users);" & _
			"  }" & _
			"  validated_FK_ADM_CheckPoints_aspnet_Users.main = false;" & _
			"  function validated_FK_ADM_CheckPoints_aspnet_Users(result) {" & _
			"    var p = result.split('|');" & _
			"    var o = $get(p[1]);" & _
			"    if(validated_FK_ADM_CheckPoints_aspnet_Users.main){" & _
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
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_ADM_CheckPoints_aspnet_Users") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_ADM_CheckPoints_aspnet_Users", validateScriptFK_ADM_CheckPoints_aspnet_Users)
		End If
  End Sub
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_ADM_CheckPoints_ADM_Schedules(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim ScheduleID As String = CType(aVal(1),String)
		Dim oVar As SIS.ADM.admSchedules = SIS.ADM.admSchedules.GetByID(ScheduleID)
    If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found." 
    Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_ADM_CheckPoints_aspnet_Users(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim Initiator As String = CType(aVal(1),String)
		Dim oVar As SIS.ADM.admUsers = SIS.ADM.admUsers.GetByID(Initiator)
    If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found." 
    Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
End Class
