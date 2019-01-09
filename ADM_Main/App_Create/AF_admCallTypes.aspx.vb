Partial Class AF_admCallTypes
  Inherits SIS.SYS.InsertBase

  Protected Sub FormView1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.PreRender
    Dim validateScriptCallTypeID As String = "<script type=""text/javascript"">" &
     "  function validate_CallTypeID(o) {" &
     "    validatePK_admCallTypes(o);" &
     "  }" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateCallTypeID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateCallTypeID", validateScriptCallTypeID)
    End If
    Dim ctlCallTypeID As TextBox = FormView1.FindControl("F_CallTypeID")
    Dim validateScript As String = "<script type=""text/javascript"">" &
     "  function validatePK_admCallTypes(o) {" &
     "    var value = o.id;" &
     "    try{$get('ctl00_ContentPlaceHolder1_FormView1_L_ErrMsg').innerHTML = '';}catch(ex){}" &
     "    var CallTypeID = $get('" & ctlCallTypeID.ClientID & "');" &
     "    if(CallTypeID.value=='')" &
     "      return true;" &
     "    value = value + ',' + CallTypeID.value ;" &
     "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" &
     "    o.style.backgroundRepeat= 'no-repeat';" &
     "    o.style.backgroundPosition = 'right';" &
     "    PageMethods.validatePK_admCallTypes(value, validatedPK_admCallTypes);" &
     "  }" &
     "  function validatedPK_admCallTypes(result) {" &
     "    var p = result.split('|');" &
     "    var o = $get(p[1]);" &
     "    o.style.backgroundImage  = 'none';" &
     "    if(p[0]=='1'){" &
     "      try{$get('ctl00_ContentPlaceHolder1_FormView1_L_ErrMsg').innerHTML = p[2];}catch(ex){}" &
     "      o.value='';" &
     "      o.focus();" &
     "    }" &
     "  }" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validatePKadmCallTypes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validatePKadmCallTypes", validateScript)
    End If
  End Sub

  Private Sub FormView1_Init(sender As Object, e As EventArgs) Handles FormView1.Init
    DataClassName = "admCallTypes"
    SetFormView = FormView1
  End Sub

  Private Sub ToolBar0_1_Init(sender As Object, e As EventArgs) Handles ToolBar0_1.Init
    SetToolBar = ToolBar0_1
  End Sub

  <System.Web.Services.WebMethod()>
  Public Shared Function validatePK_admCallTypes(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim CallTypeID As String = CType(aVal(1), String)
    Dim oVar As SIS.ADM.admCallTypes = SIS.ADM.admCallTypes.GetByID(CallTypeID)
    If Not oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record allready exists."
    End If
    Return mRet
  End Function
End Class
