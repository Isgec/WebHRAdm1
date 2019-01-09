Partial Class EF_admMonitorSheetHeader
  Inherits System.Web.UI.Page
  Private _CancelUrl As String = "~/ADM_Main/App_Forms/GF_admMonitorSheetHeader.aspx"
	Private _EditUrl As String = "~/ADM_Main/App_Edit/EF_admMonitorSheetDetails.aspx"
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
	Protected Sub NavBar1_PageChanged(ByVal NewPageNo As Integer, ByVal PageSize As Integer) Handles NavBar1.PageChanged
		GridView1.PageIndex = NewPageNo
		GridView1.PageSize = PageSize
	End Sub
	Protected Sub NavBar1_SearchClicked(ByVal SearchText As String, ByVal SearchState As Boolean) Handles NavBar1.SearchClicked
		GridView1.PageIndex = 0
		ObjectDataSource2.SelectParameters("SearchState").DefaultValue = SearchState
		ObjectDataSource2.SelectParameters("SearchText").DefaultValue = SearchText
	End Sub
	Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
		'If e.CommandName.ToString.ToLower = "save" Then
		'	Dim oRow As GridViewRow = GridView1.Rows(e.CommandArgument)
		'	Dim oSendStatus As LC_idmSendStatus = oRow.FindControl("F_SendStatusID")
		'	Dim oRemarks As TextBox = oRow.FindControl("F_SendRemarks")
		'	Dim oNoOfCopies As TextBox = oRow.FindControl("F_NoOfCopies")
		'	Dim oTDet As SIS.IDM.idmCTCreateDetail = SIS.IDM.idmCTCreateDetail.GetByID(GridView1.DataKeys(e.CommandArgument).Values("TmtlID"), GridView1.DataKeys(e.CommandArgument).Values("ProjectID"), GridView1.DataKeys(e.CommandArgument).Values("DocumentID"), GridView1.DataKeys(e.CommandArgument).Values("RevisionNo"))
		'	With oTDet
		'		.SendStatusID = oSendStatus.SelectedValue
		'		.NoOfCopies = oNoOfCopies.Text
		'		.SendRemarks = oRemarks.Text
		'	End With
		'	Try
		'		SIS.IDM.idmCTCreateDetail.UpdateDocumentInTransmittal(oTDet)
		'		SelectedDataKey.Text = ""
		'	Catch ex As Exception
		'		SelectedDataKey.Text = ex.Message
		'		mPopup.Show()
		'	End Try
		'End If
	End Sub
	Protected Sub GridView1_RowDeleted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeletedEventArgs) Handles GridView1.RowDeleted
	End Sub
End Class
