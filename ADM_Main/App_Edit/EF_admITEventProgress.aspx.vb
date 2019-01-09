Partial Class EF_admITEventProgress
  Inherits System.Web.UI.Page
	Private _CancelUrl As String = "~/ADM_Main/App_Forms/GF_admITEventProgress.aspx"
	Public Property DirectCall() As Boolean
		Get
			If Not ViewState("DirectCall") Is Nothing Then
				Return Convert.ToBoolean(ViewState("DirectCall"))
			End If
			Return False
		End Get
		Set(ByVal value As Boolean)
			ViewState("DirectCall") = value
		End Set
	End Property
	Public Property CancelURL() As String
		Get
			If ViewState("CancelURL") IsNot Nothing Then
				Return CType(ViewState("CancelURL"), String)
			End If
			Return ""
		End Get
		Set(ByVal value As String)
			ViewState.Add("CancelURL", value)
		End Set
	End Property
	Protected Sub FormView1_ItemCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewCommandEventArgs) Handles FormView1.ItemCommand
		If e.CommandName.ToLower = "cancel" Then
			Response.Redirect(CancelURL)
		End If
	End Sub
	Protected Sub FormView1_ItemUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewUpdatedEventArgs) Handles FormView1.ItemUpdated
		If e.Exception Is Nothing Then
			If DirectCall Then
				Dim mStr As String = "<script type=""text/javascript""> " & _
				"  window.parent.hideProgressPopup();" & _
				"</script>"
				If Not Page.ClientScript.IsClientScriptBlockRegistered("CloseIt") Then
					Page.ClientScript.RegisterStartupScript(GetType(System.String), "CloseIt", mStr)
				End If
			Else
				Response.Redirect(CancelURL)
			End If
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
  Protected Sub FormView1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.Load
    CancelURL = _CancelUrl & "?EventID=" & Request.QueryString("EventID")

    If Not Request.QueryString("DC") Is Nothing Then
      DirectCall = True
      Dim oTbl As lgToolBar = FormView1.FindControl("ToolBar0_1")
      Dim oBut As Button = FormView1.FindControl("cmdUpdateButton")
      If Not oTbl Is Nothing Then
        oTbl.Visible = False
      End If
      If Not oBut Is Nothing Then
        oBut.Visible = True
      End If
    End If

  End Sub
  Protected Sub FormView1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.PreRender
		Dim oEvtProgress As SIS.ADM.admITEventProgress = FormView1.DataItem
		Dim oEvt As SIS.ADM.admITEventTransactions = SIS.ADM.admITEventTransactions.GetByID(oEvtProgress.EventID)
		Dim CardNo As String = oEvt.CardNo
		Dim mStr As String = "<ul>"
		Dim oEmp As SIS.ADM.admEmployees = SIS.ADM.admEmployees.GetByID(CardNo)
		If Not oEmp Is Nothing Then
			mStr &= "<li><b>Employee Code:</b>&nbsp;" & oEmp.CardNo & "</li>"
			mStr &= "<li><b>Employee Name:</b>&nbsp;" & oEmp.EmployeeName & "</li>"
			Try
				mStr &= "<li><b>Department:</b>&nbsp;" & oEmp.FK_HRM_Employees_HRM_Departments.DisplayField & "</li>"
			Catch ex As Exception
			End Try
			Try
				mStr &= "<li><b>Designation:</b>&nbsp;" & oEmp.FK_HRM_Employees_HRM_Designations.DisplayField & "</li>"
			Catch ex As Exception
			End Try
			Try
				mStr &= "<li><b>Location:</b>&nbsp;" & oEmp.FK_HRM_Employees_HRM_Offices.DisplayField & "</li>"
			Catch ex As Exception
			End Try
			Try
				mStr &= "<li><b>Active:</b>&nbsp;" & oEmp.ActiveState & "</li>"
			Catch ex As Exception
			End Try
		End If
		mStr &= "</ul>"
		Dim oPnl As Label = FormView1.FindControl("PnlEmpInfo")
		oPnl.Text = mStr
	End Sub
	Dim EmpStr As String = ""
	'Protected Sub ObjectDataSource1_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ObjectDataSource1.Selected
	'	Dim oEvtProgress As SIS.ADM.admITEventProgress = e.ReturnValue
	'	Dim oEvt As SIS.ADM.admITEventTransactions = SIS.ADM.admITEventTransactions.GetByID(oEvtProgress.EventID)
	'	Dim CardNo As String = oEvt.CardNo
	'	Dim mStr As String = "<ul>"
	'	Dim oEmp As SIS.ADM.admEmployees = SIS.ADM.admEmployees.GetByID(CardNo)
	'	If Not oEmp Is Nothing Then
	'		mStr &= "<li><b>Employee Code:</b>&nbsp;" & oEmp.CardNo & "</li>"
	'		mStr &= "<li><b>Employee Name:</b>&nbsp;" & oEmp.EmployeeName & "</li>"
	'		Try
	'			mStr &= "<li><b>Department:</b>&nbsp;" & oEmp.FK_HRM_Employees_HRM_Departments.DisplayField & "</li>"
	'		Catch ex As Exception
	'		End Try
	'		Try
	'			mStr &= "<li><b>Designation:</b>&nbsp;" & oEmp.FK_HRM_Employees_HRM_Designations.DisplayField & "</li>"
	'		Catch ex As Exception
	'		End Try
	'		Try
	'			mStr &= "<li><b>Location:</b>&nbsp;" & oEmp.FK_HRM_Employees_HRM_Offices.DisplayField & "</li>"
	'		Catch ex As Exception
	'		End Try
	'		Try
	'			mStr &= "<li><b>Active:</b>&nbsp;" & oEmp.ActiveState & "</li>"
	'		Catch ex As Exception
	'		End Try
	'	End If
	'	mStr &= "</ul>"
	'	EmpStr = mStr
	'End Sub
End Class
