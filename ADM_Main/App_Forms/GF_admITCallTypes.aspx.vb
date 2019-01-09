Partial Class GF_admITCallTypes
  Inherits SIS.SYS.GridBase

  Private Sub GridView1_Init(sender As Object, e As EventArgs) Handles GridView1.Init
    DataClassName = "admITCallTypes"
    SetGridView = GridView1
  End Sub

  Private Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand
    If e.CommandName.ToLower = "lgedit" Then
      Dim aVal() As String = e.CommandArgument.ToString.Split(",".ToCharArray)
      Dim RedirectUrl As String = ToolBar0_1.EditUrl & "?CallTypeID=" & aVal(0)
      Response.Redirect(RedirectUrl)
    End If
  End Sub

  Private Sub ToolBar0_1_Init(sender As Object, e As EventArgs) Handles ToolBar0_1.Init
    SetToolBar = ToolBar0_1
  End Sub
End Class
