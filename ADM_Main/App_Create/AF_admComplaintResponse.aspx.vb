Partial Class AF_admComplaintResponse
  Inherits SIS.SYS.InsertBase
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
    Return SIS.ADM.admRegisterComplaint.SelectadmRegisterComplaintAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub FormView1_ItemInserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewInsertEventArgs) Handles FormView1.ItemInserting
		e.Values("CallID") = CallID
	End Sub
	<System.Web.Services.WebMethod()> _
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
		Dim oF_CallID As TextBox = FormView1.FindControl("F_CallID")
		oF_CallID.Text = CallID
	End Sub

  Private Sub ToolBar0_1_Init(sender As Object, e As EventArgs) Handles ToolBar0_1.Init
    SetToolBar = ToolBar0_1
  End Sub

  Private Sub FormView1_Init(sender As Object, e As EventArgs) Handles FormView1.Init
    DataClassName = "admComplaintResponse"
    SetFormView = FormView1
  End Sub
End Class