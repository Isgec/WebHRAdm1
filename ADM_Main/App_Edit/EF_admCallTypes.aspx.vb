Partial Class EF_admCallTypes
  Inherits SIS.SYS.UpdateBase

  Private Sub FormView1_Init(sender As Object, e As EventArgs) Handles FormView1.Init
    DataClassName = "admCallTypes"
    SetFormView = FormView1
  End Sub

  Private Sub ToolBar0_1_Init(sender As Object, e As EventArgs) Handles ToolBar0_1.Init
    SetToolBar = ToolBar0_1
  End Sub
End Class
