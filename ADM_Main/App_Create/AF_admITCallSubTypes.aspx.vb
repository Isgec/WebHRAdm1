Partial Class AF_admITCallSubTypes
  Inherits SIS.SYS.InsertBase
  Protected Sub FVadmITCallSubTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVadmITCallSubTypes.Init
    DataClassName = "AadmITCallSubTypes"
    SetFormView = FVadmITCallSubTypes
  End Sub
  Protected Sub TBLadmITCallSubTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLadmITCallSubTypes.Init
    SetToolBar = TBLadmITCallSubTypes
  End Sub
  Protected Sub FVadmITCallSubTypes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVadmITCallSubTypes.PreRender
    Dim oF_CallTypeID As LC_admITCallTypes = FVadmITCallSubTypes.FindControl("F_CallTypeID")
    oF_CallTypeID.Enabled = True
    oF_CallTypeID.SelectedValue = String.Empty
    If Not Session("F_CallTypeID") Is Nothing Then
      If Session("F_CallTypeID") <> String.Empty Then
        oF_CallTypeID.SelectedValue = Session("F_CallTypeID")
      End If
    End If
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ADM_Main/App_Create") & "/AF_admITCallSubTypes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptadmITCallSubTypes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptadmITCallSubTypes", mStr)
    End If
    If Request.QueryString("CallTypeID") IsNot Nothing Then
      CType(FVadmITCallSubTypes.FindControl("F_CallTypeID"), TextBox).Text = Request.QueryString("CallTypeID")
      CType(FVadmITCallSubTypes.FindControl("F_CallTypeID"), TextBox).Enabled = False
    End If
    If Request.QueryString("CallSubTypeID") IsNot Nothing Then
      CType(FVadmITCallSubTypes.FindControl("F_CallSubTypeID"), TextBox).Text = Request.QueryString("CallSubTypeID")
      CType(FVadmITCallSubTypes.FindControl("F_CallSubTypeID"), TextBox).Enabled = False
    End If
  End Sub

End Class
