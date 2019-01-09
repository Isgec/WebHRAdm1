
Partial Class FVPaging
	Inherits System.Web.UI.Page

	Protected Sub FormView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.DataBound
		With ToolBar0_1
			.CurrentPage = FormView1.PageIndex
			.TotalPages = FormView1.PageCount
			'.RecordsPerPage = FormView1.PageSize
			.RecordsPerPage = 1
		End With
	End Sub
	Protected Sub ToolBar0_1_SearchClicked(ByVal SearchText As String, ByVal SearchState As Boolean) Handles ToolBar0_1.SearchClicked
		FormView1.PageIndex = 0
		ObjectDataSource1.SelectParameters("SearchState").DefaultValue = SearchState
		ObjectDataSource1.SelectParameters("SearchText").DefaultValue = SearchText
	End Sub
	Protected Sub FormView1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.Init
		Dim FileName As String = System.IO.Path.GetFileName(System.Web.HttpContext.Current.Request.Url.AbsolutePath)
		Try
			If Session("PageNoProvider") = True Then
				FormView1.PageIndex = SIS.SYS.Utilities.GlobalVariables.PageNo(FileName, HttpContext.Current.Session("LoginID"))
			Else
				FormView1.PageIndex = Session("PageNo_" & FileName)
			End If
			'If Session("PageSizeProvider") = True Then
			'	FormView1.PageSize = SIS.SYS.Utilities.GlobalVariables.PageSize(FileName, HttpContext.Current.Session("LoginID"))
			'Else
			'	FormView1.PageSize = Session("PageSize_" & FileName)
			'End If
		Catch ex As Exception
			FormView1.PageIndex = 0
			'FormView1.PageSize = 10
		End Try
	End Sub

	Protected Sub FormView1_PageIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.PageIndexChanged
		Dim FileName As String = System.IO.Path.GetFileName(System.Web.HttpContext.Current.Request.Url.AbsolutePath)
		If Session("PageNoProvider") = True Then
			SIS.SYS.Utilities.GlobalVariables.PageNo(FileName, HttpContext.Current.Session("LoginID"), FormView1.PageIndex)
		Else
			Session("PageNo_" & FileName) = FormView1.PageIndex
		End If
	End Sub
	Protected Sub ToolBar0_1_PageChanged(ByVal NewPageNo As Integer, ByVal PageSize As Integer) Handles ToolBar0_1.PageChanged
		Dim FileName As String = System.IO.Path.GetFileName(System.Web.HttpContext.Current.Request.Url.AbsolutePath)
		FormView1.PageIndex = NewPageNo
		'FormView1.PageSize = PageSize
		If Session("PageNoProvider") = True Then
			SIS.SYS.Utilities.GlobalVariables.PageNo(FileName, HttpContext.Current.Session("LoginID"), NewPageNo)
		Else
			Session("PageNo_" & FileName) = NewPageNo
		End If
		'If Session("PageSizeProvider") = True Then
		'	SIS.SYS.Utilities.GlobalVariables.PageSize(FileName, HttpContext.Current.Session("LoginID"), PageSize)
		'Else
		'	Session("PageSize_" & FileName) = PageSize
		'End If
	End Sub
End Class
