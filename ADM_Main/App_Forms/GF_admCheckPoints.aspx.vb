Partial Class GF_admCheckPoints
  Inherits SIS.SYS.GridBase
  Private _EditUrl As String = "~/ADM_Main/App_Edit/EF_admCheckPoints.aspx"
  Private _AddUrl As String = "~/ADM_Main/App_Create/AF_admCheckPoints.aspx"
  Private _InfoUrl As String = "~/ADM_Main/App_Display/DF_admCheckPoints.aspx"
  Protected Sub Edit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _EditUrl  & "?CheckPointID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?CheckPointID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVadmCheckPoints_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVadmCheckPoints.Init
    DataClassName = "GadmCheckPoints"
    SetGridView = GVadmCheckPoints
  End Sub
  Protected Sub TBLadmCheckPoints_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLadmCheckPoints.Init
    SetToolBar = TBLadmCheckPoints
  End Sub
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If Not Page.IsPostBack And Not Page.IsCallback Then
			TBLadmCheckPoints.AddUrl = _AddUrl
		End If
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
