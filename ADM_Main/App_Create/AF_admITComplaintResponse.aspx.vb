Imports System.Net.Mail
Imports System.Web.Mail
Partial Class AF_admITComplaintResponse
  Inherits SIS.SYS.InsertBase
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function AssignedToCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.ADM.admUsers.SelectadmUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
  Public Property CallID() As Integer
    Get
      If Not ViewState("CallID") Is Nothing Then
        Return CType(ViewState("CallID"), Integer)
      End If
      Return -1
    End Get
    Set(ByVal value As Integer)
      ViewState("CallID") = value
    End Set
  End Property
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function CallIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.ADM.admITRegisterComplaint.SelectadmITRegisterComplaintAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub FVadmITComplaintResponse_ItemInserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewInsertEventArgs) Handles FVadmITComplaintResponse.ItemInserting
    e.Values("CallID") = CallID
  End Sub
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_ADM_ITComplaintResponse_HRM_Employees(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim AttendedBy As String = CType(aVal(1), String)
    Dim oVar As SIS.ADM.admEmployees = SIS.ADM.admEmployees.GetByID(AttendedBy)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    If Not Page.IsCallback And Not Page.IsPostBack Then
      CallID = Request.QueryString("CallID")
    End If
  End Sub
  Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
    Dim oF_CallID As TextBox = FVadmITComplaintResponse.FindControl("F_CallID")
    oF_CallID.Text = CallID
  End Sub

  Protected Sub FVadmITComplaintResponse_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVadmITComplaintResponse.PreRender
    Dim oF_AssignedTo_Display As Label = FVadmITComplaintResponse.FindControl("F_AssignedTo_Display")
    oF_AssignedTo_Display.Text = String.Empty
    If Not Session("F_AssignedTo_Display") Is Nothing Then
      If Session("F_AssignedTo_Display") <> String.Empty Then
        oF_AssignedTo_Display.Text = Session("F_AssignedTo_Display")
      End If
    End If
    Dim oF_AssignedTo As TextBox = FVadmITComplaintResponse.FindControl("F_AssignedTo")
    oF_AssignedTo.Enabled = True
    oF_AssignedTo.Text = String.Empty
    If Not Session("F_AssignedTo") Is Nothing Then
      If Session("F_AssignedTo") <> String.Empty Then
        oF_AssignedTo.Text = Session("F_AssignedTo")
      End If
    End If
    Dim strScriptAssignedTo As String = "<script type=""text/javascript""> " &
     "function ACEAssignedTo_Selected(o, e) {" &
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
     "  p.style.backgroundImage = 'url(../../images/loader.gif)';" &
     "  p.style.backgroundRepeat = 'no-repeat';" &
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
    Dim validateScriptAssignedTo As String = "<script type=""text/javascript"">" &
   "  function validate_AssignedTo(o) {" &
   "    validated_FK_ADM_ITComplaints_ADM_Users1.main = true;" &
   "    validate_FK_ADM_ITComplaints_ADM_Users1(o);" &
   "  }" &
   "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateAssignedTo") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateAssignedTo", validateScriptAssignedTo)
    End If
    Dim FK_ADM_ITComplaints_ADM_Users1AssignedTo As TextBox = FVadmITComplaintResponse.FindControl("F_AssignedTo")
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

  Private Sub FVadmITComplaintResponse_Init(sender As Object, e As EventArgs) Handles FVadmITComplaintResponse.Init
    DataClassName = "admITComplaintResponse"
    SetFormView = FVadmITComplaintResponse
  End Sub

  Private Sub TBLadmITComplaintResponse_Init(sender As Object, e As EventArgs) Handles TBLadmITComplaintResponse.Init
    SetToolBar = TBLadmITComplaintResponse
  End Sub
End Class