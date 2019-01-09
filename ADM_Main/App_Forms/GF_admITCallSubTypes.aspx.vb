Partial Class GF_admITCallSubTypes
  Inherits SIS.SYS.GridBase
  Protected Sub GVadmITCallSubTypes_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVadmITCallSubTypes.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim CallTypeID As String = GVadmITCallSubTypes.DataKeys(e.CommandArgument).Values("CallTypeID")
        Dim CallSubTypeID As Int32 = GVadmITCallSubTypes.DataKeys(e.CommandArgument).Values("CallSubTypeID")
        Dim RedirectUrl As String = TBLadmITCallSubTypes.EditUrl & "?CallTypeID=" & CallTypeID & "&CallSubTypeID=" & CallSubTypeID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVadmITCallSubTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVadmITCallSubTypes.Init
    DataClassName = "GadmITCallSubTypes"
    SetGridView = GVadmITCallSubTypes
  End Sub
  Protected Sub TBLadmITCallSubTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLadmITCallSubTypes.Init
    SetToolBar = TBLadmITCallSubTypes
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_CallTypeID.SelectedValue = String.Empty
    If Not Session("F_CallTypeID") Is Nothing Then
      If Session("F_CallTypeID") <> String.Empty Then
        F_CallTypeID.SelectedValue = Session("F_CallTypeID")
      End If
    End If
  End Sub
End Class
