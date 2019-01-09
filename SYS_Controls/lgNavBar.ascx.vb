Partial Class lgNavBar
	Inherits System.Web.UI.UserControl
	Public Event PageChanged(ByVal NewPageNo As Integer, ByVal PageSize As Integer)
	Public Event SearchClicked(ByVal SearchText As String, ByVal SearchState As Boolean)
	Public Property ValidationGroup() As String
		Get
			Return lg_Search.ValidationGroup
		End Get
		Set(ByVal value As String)
			lg_Search.ValidationGroup = value
			cmdSearch.ValidationGroup = value
		End Set
	End Property
	Public Property SearchState() As Boolean
		Get
			Return lg_End.Checked
		End Get
		Set(ByVal value As Boolean)
			lg_End.Checked = value
		End Set
	End Property
	Public Property EnableSearch() As Boolean
		Get
			Return cmdSearch.Enabled
		End Get
		Set(ByVal value As Boolean)
			cmdSearch.Enabled = value
			With cmdSearch
				If .Enabled Then .ImageUrl = .ImageUrl.Replace("1", "0") Else .ImageUrl = .ImageUrl.Replace("0", "1")
			End With
		End Set
	End Property
	Public Property TotalRecords() As Integer
		Get
			Return cmdSize.Text
		End Get
		Set(ByVal value As Integer)
			cmdSize.Text = value
			MEVg_cSize.MaximumValue = value
		End Set
	End Property
	Public Property RecordsPerPage() As Integer
		Get
			Return g_cSize.Text
		End Get
		Set(ByVal value As Integer)
			g_cSize.Text = value
		End Set
	End Property
	Public Property TotalPages() As Integer
		Get
			Return g_Pages.Text
		End Get
		Set(ByVal value As Integer)
			g_Pages.Text = value
			MEVg_cPage.MaximumValue = value
		End Set
	End Property
	Public Property CurrentPage() As Integer
		Get
			Return g_cPage.Text
		End Get
		Set(ByVal value As Integer)
			g_cPage.Text = value + 1
		End Set
	End Property
	Protected Sub SearchButton_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles CmdSearch.Click
		If Not lg_Search.Text = String.Empty Then
			lg_End.Enabled = True
			lg_End.Checked = True
			RaiseEvent SearchClicked(lg_Search.Text, True)
		End If
	End Sub
	Protected Sub DisableSearch_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lg_End.CheckedChanged
		lg_End.Enabled = False
		lg_End.Checked = False
		RaiseEvent SearchClicked(lg_Search.Text, False)
	End Sub
	Protected Sub g_cPage_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles g_cPage.TextChanged
		RaiseEvent PageChanged(Convert.ToInt32(g_cPage.Text) - 1, Convert.ToInt32(g_cSize.Text))
	End Sub
	Protected Sub navFirst_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles cmdFirst.Click
		RaiseEvent PageChanged(0, Convert.ToInt32(g_cSize.Text))
	End Sub
	Protected Sub navPrev_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles cmdPrev.Click
		Dim cp As Integer = Convert.ToInt32(g_cPage.Text)
		If cp - 1 >= 1 Then
			RaiseEvent PageChanged(cp - 2, Convert.ToInt32(g_cSize.Text))
		End If
	End Sub
	Protected Sub navNext_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles cmdNext.Click
		Dim cp As Integer = Convert.ToInt32(g_cPage.Text)
		Dim lp As Integer = Convert.ToInt32(g_Pages.Text)
		If cp + 1 <= lp Then
			RaiseEvent PageChanged(cp, Convert.ToInt32(g_cSize.Text))
		End If
	End Sub
	Protected Sub navLast_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles cmdLast.Click
		Dim lp As Integer = Convert.ToInt32(g_Pages.Text)
		RaiseEvent PageChanged(lp - 1, Convert.ToInt32(g_cSize.Text))
	End Sub
	Protected Sub _PageSizeButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSize.Click
		RaiseEvent PageChanged(1, Convert.ToInt32(g_cSize.Text))
	End Sub
	Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
		g_cPage.ValidationGroup = Me.ID
		MEVg_cPage.ValidationGroup = Me.ID
	End Sub
End Class
