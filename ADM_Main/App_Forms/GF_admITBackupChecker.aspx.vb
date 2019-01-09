Partial Class GF_admITBackupChecker
  Inherits System.Web.UI.Page
  Private _EditUrl As String = "~/ADM_Main/App_Edit/EF_admITBackupChecker.aspx"
  Private _AddUrl As String = "~/ADM_Main/App_Create/AF_admITBackupChecker.aspx"
  Private _InfoUrl As String = "~/ADM_Main/App_Display/DF_admITBackupChecker.aspx"
  Protected Sub Edit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _EditUrl  & "?BackupID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?BackupID=" & aVal(0)
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
		If Not Page.IsPostBack And Not Page.IsCallback Then
			ToolBar0_1.AddUrl = _AddUrl
		End If
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
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
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
