Partial Class EF_admInitiatorSheetHeader
  Inherits System.Web.UI.Page
  Private _CancelUrl As String = "~/ADM_Main/App_Forms/GF_admInitiatorSheetHeader.aspx"
	Private _EditUrl As String = "~/ADM_Main/App_Edit/EF_admInitiatorSheetDetails.aspx"
	Protected Sub Edit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
		Dim oBut As ImageButton = CType(sender, ImageButton)
		Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
		Dim RedirectUrl As String = _EditUrl & "?SheetID=" & aVal(0) & "&SerialNo=" & aVal(1)
		Response.Redirect(RedirectUrl)
	End Sub
	Protected Sub FormView1_ItemCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewCommandEventArgs) Handles FormView1.ItemCommand
		If e.CommandName.ToLower = "cancel" Then
			Response.Redirect(_CancelUrl)
		End If
		If e.CommandName.ToLower = "return" Then
			ObjectDataSource1.UpdateMethod = "UpdateReturn"
			FormView1.UpdateItem(False)
		End If
	End Sub
  Protected Sub FormView1_ItemDeleted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewDeletedEventArgs) Handles FormView1.ItemDeleted
    If e.Exception Is Nothing Then
      Response.Redirect(_CancelUrl)
    Else
			If Not e.Exception.InnerException Is Nothing Then
				Session("myError") = e.Exception.InnerException.ToString & vbCrLf & e.Exception.Message
			Else
				Session("myError") = e.Exception.Message
			End If
      e.ExceptionHandled = True
      Response.Redirect("~/ErrorPage.aspx")
    End If
  End Sub
  Protected Sub FormView1_ItemUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewUpdatedEventArgs) Handles FormView1.ItemUpdated
    If e.Exception Is Nothing Then
      Response.Redirect(_CancelUrl)
    Else
			If Not e.Exception.InnerException Is Nothing Then
				Session("myError") = e.Exception.InnerException.ToString & vbCrLf & e.Exception.Message
			Else
				Session("myError") = e.Exception.Message
			End If
      e.ExceptionHandled = True
      Response.Redirect("~/ErrorPage.aspx")
    End If
  End Sub
	Protected Sub GridView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.DataBound
		With NavBar1
			.CurrentPage = GridView1.PageIndex
			.TotalPages = GridView1.PageCount
			.RecordsPerPage = GridView1.PageSize
		End With
	End Sub
	Protected Sub GridView1_PageIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.PageIndexChanged
		Dim FileName As String = System.IO.Path.GetFileName(System.Web.HttpContext.Current.Request.Url.AbsolutePath)
		If Session("PageNoProvider") = True Then
			SIS.SYS.Utilities.GlobalVariables.PageNo(FileName, HttpContext.Current.Session("LoginID"), GridView1.PageIndex)
		Else
			Session("PageNo_" & FileName) = GridView1.PageIndex
		End If
	End Sub
	Protected Sub NavBar1_PageChanged(ByVal NewPageNo As Integer, ByVal PageSize As Integer) Handles NavBar1.PageChanged
		Try
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

		Catch ex As Exception

		End Try
	End Sub
	Protected Sub NavBar1_SearchClicked(ByVal SearchText As String, ByVal SearchState As Boolean) Handles NavBar1.SearchClicked
		GridView1.PageIndex = 0
		ObjectDataSource2.SelectParameters("SearchState").DefaultValue = SearchState
		ObjectDataSource2.SelectParameters("SearchText").DefaultValue = SearchText
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
