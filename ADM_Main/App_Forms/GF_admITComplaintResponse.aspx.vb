Partial Class GF_admITComplaintResponse
  Inherits SIS.SYS.GridBase
  Public Property NotClosed() As Boolean
    Get
      If Not ViewState("NotClosed") Is Nothing Then
        Return CType(ViewState("NotClosed"), Boolean)
      End If
      Return False
    End Get
    Set(ByVal value As Boolean)
      ViewState("NotClosed") = value
    End Set
  End Property
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
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    If Not Page.IsPostBack And Not Page.IsCallback Then
      CallID = Request.QueryString("CallID")
      Dim oCom As SIS.ADM.admLWITComplaints = SIS.ADM.admLWITComplaints.GetByID(CallID)
      If oCom IsNot Nothing Then
        NotClosed = Not oCom.Closed
      End If
    End If
  End Sub
  Protected Sub GVadmITComplaintResponse_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVadmITComplaintResponse.Init
    DataClassName = "admITComplaintResponse"
    SetGridView = GVadmITComplaintResponse
  End Sub
  <System.Web.Services.WebMethod()> _
	Public Shared Function validate_FK_ADM_ITComplaintResponse_ADM_ITComplaints(ByVal value As String) As String
		Dim aVal() As String = value.Split(",".ToCharArray)
		Dim mRet As String = "0|" & aVal(0)
		Dim CallID As Int32 = CType(aVal(1), Int32)
		Dim oVar As SIS.ADM.admITRegisterComplaint = SIS.ADM.admITRegisterComplaint.GetByID(CallID)
		If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found."
		Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
		End If
		Return mRet
	End Function
  Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
    If Not NotClosed Then
      TBLadmITComplaintResponse.EnableAdd = False
    End If
  End Sub

  Private Sub TBLadmITComplaintResponse_Init(sender As Object, e As EventArgs) Handles TBLadmITComplaintResponse.Init
    SetToolBar = TBLadmITComplaintResponse
  End Sub

  Private Sub GVadmITComplaintResponse_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GVadmITComplaintResponse.RowCommand
    If e.CommandName.ToLower = "lgedit" Then
      Dim aVal() As String = e.CommandArgument.ToString.Split(",".ToCharArray)
      Dim RedirectUrl As String = TBLadmITComplaintResponse.EditUrl & "?CallID=" & aVal(0) & "&SerialNo=" & aVal(1)
      Response.Redirect(RedirectUrl)
    End If
  End Sub
End Class
