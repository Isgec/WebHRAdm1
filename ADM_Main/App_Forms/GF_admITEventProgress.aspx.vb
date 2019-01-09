Partial Class GF_admITEventProgress
  Inherits System.Web.UI.Page
  Private _EditUrl As String = "~/ADM_Main/App_Edit/EF_admITEventProgress.aspx"
	Protected Sub Edit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
		Dim oBut As ImageButton = CType(sender, ImageButton)
		Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
		Dim RedirectUrl As String = _EditUrl & "?EventID=" & aVal(0) & "&ITServiceID=" & aVal(1)
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
End Class
