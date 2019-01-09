
Partial Class Plain
	Inherits System.Web.UI.MasterPage
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If Not SIS.SYS.Utilities.ValidateURL.Validate(Request.AppRelativeCurrentExecutionFilePath) Then
			Response.Redirect("~/Login.aspx")
		End If
	End Sub
	Public Property EncType() As String
		Get
			Return form1.Enctype
		End Get
		Set(ByVal value As String)
			form1.Enctype = value
		End Set
	End Property
	Public Property Method() As String
		Get
			Return form1.Method
		End Get
		Set(ByVal value As String)
			form1.Method = value
		End Set
	End Property
End Class

