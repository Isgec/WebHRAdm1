Partial Class EF_admITComplaintResponse
  Inherits SIS.SYS.UpdateBase

  Private Sub FVadmITComplaintResponse_Init(sender As Object, e As EventArgs) Handles FVadmITComplaintResponse.Init
    DataClassName = "admITComplaintResponse"
    SetFormView = FVadmITComplaintResponse
  End Sub

  Private Sub TBLadmITComplaintResponse_Init(sender As Object, e As EventArgs) Handles TBLadmITComplaintResponse.Init
    SetToolBar = TBLadmITComplaintResponse
  End Sub
End Class
