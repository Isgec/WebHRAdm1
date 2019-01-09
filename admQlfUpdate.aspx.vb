Partial Class admQlfUpdate
	Inherits System.Web.UI.Page
	Protected Sub FormView1_ItemUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewUpdatedEventArgs) Handles FormView1.ItemUpdated
		If e.Exception Is Nothing Then
			Response.Write("<h2>Updated Successfully</h2>")
		Else
			If Not e.Exception.InnerException Is Nothing Then
				Response.Write("Error: " & e.Exception.InnerException.ToString & vbCrLf & e.Exception.Message)
			Else
				Response.Write(e.Exception.Message)
			End If
			e.ExceptionHandled = True
		End If
		Response.Flush()
		Response.Close()
	End Sub
	'Protected Sub Page_PreRenderComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRenderComplete
	'	Dim uid As String = Request.QueryString("CardNo")
	'	Dim oEmp As SIS.ADM.admQlfUpdate = SIS.ADM.admQlfUpdate.UZ_GetByID(uid)
	'	If Not oEmp Is Nothing Then
	'		SIS.ADM.admQlfUpdate.Update1(oEmp)
	'	End If
	'End Sub
End Class
