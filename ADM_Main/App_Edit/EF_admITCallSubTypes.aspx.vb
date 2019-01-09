Partial Class EF_admITCallSubTypes
  Inherits SIS.SYS.UpdateBase
  Protected Sub FVadmITCallSubTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVadmITCallSubTypes.Init
    DataClassName = "EadmITCallSubTypes"
    SetFormView = FVadmITCallSubTypes
  End Sub
  Protected Sub TBLadmITCallSubTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLadmITCallSubTypes.Init
    SetToolBar = TBLadmITCallSubTypes
  End Sub
  Protected Sub FVadmITCallSubTypes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVadmITCallSubTypes.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ADM_Main/App_Edit") & "/EF_admITCallSubTypes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptadmITCallSubTypes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptadmITCallSubTypes", mStr)
    End If
  End Sub
End Class
