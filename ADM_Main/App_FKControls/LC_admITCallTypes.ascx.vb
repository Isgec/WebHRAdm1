Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

<ValidationProperty("SelectedValue")> _
Partial Class LC_admITCallTypes
	Inherits System.Web.UI.UserControl
	Private _OrderBy As String = String.Empty
	Private _IncludeDefault As Boolean = True
	Private _DefaultText As String = "-- Select --"
	Private _DefaultValue As String = String.Empty
	Public Event SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
	Public ReadOnly Property LCClientID() As String
		Get
			Return DDLadmITCallTypes.ClientID
		End Get
	End Property
	Public Property AddAttributes() As String
		Get
			Return DDLadmITCallTypes.ToString
		End Get
		Set(ByVal value As String)
			Try
				Dim aVal() As String = value.Split(",".ToCharArray)
				DDLadmITCallTypes.Attributes.Add(aVal(0), aVal(1))
			Catch ex As Exception
			End Try
		End Set
	End Property
	Public Property CssClass() As String
		Get
			Return DDLadmITCallTypes.CssClass
		End Get
		Set(ByVal value As String)
			DDLadmITCallTypes.CssClass = value
		End Set
	End Property
	Public Property Width() As System.Web.UI.WebControls.Unit
		Get
			Return DDLadmITCallTypes.Width
		End Get
		Set(ByVal value As System.Web.UI.WebControls.Unit)
			DDLadmITCallTypes.Width = value
		End Set
	End Property
	Public Property RequiredFieldErrorMessage() As String
		Get
			Return RequiredFieldValidatoradmITCallTypes.Text
		End Get
		Set(ByVal value As String)
			RequiredFieldValidatoradmITCallTypes.Text = value
		End Set
	End Property
	Public Property ValidationGroup() As String
		Get
			Return RequiredFieldValidatoradmITCallTypes.ValidationGroup
		End Get
		Set(ByVal value As String)
			RequiredFieldValidatoradmITCallTypes.ValidationGroup = value
		End Set
	End Property
	Public Property Enabled() As Boolean
		Get
			Return DDLadmITCallTypes.Enabled
		End Get
		Set(ByVal value As Boolean)
			DDLadmITCallTypes.Enabled = value
		End Set
	End Property
	Public Property AutoPostBack() As Boolean
		Get
			Return DDLadmITCallTypes.AutoPostBack
		End Get
		Set(ByVal value As Boolean)
			DDLadmITCallTypes.AutoPostBack = value
		End Set
	End Property
	Public Property DataTextField() As String
		Get
			Return DDLadmITCallTypes.DataTextField
		End Get
		Set(ByVal value As String)
			DDLadmITCallTypes.DataTextField = value
		End Set
	End Property
	Public Property DataValueField() As String
		Get
			Return DDLadmITCallTypes.DataValueField
		End Get
		Set(ByVal value As String)
			DDLadmITCallTypes.DataValueField = value
		End Set
	End Property
	Public Property SelectedValue() As String
		Get
			Return DDLadmITCallTypes.SelectedValue
		End Get
		Set(ByVal value As String)
			If Convert.IsDBNull(value) Then
				DDLadmITCallTypes.SelectedValue = String.Empty
			Else
				DDLadmITCallTypes.SelectedValue = value
			End If
		End Set
	End Property
	Public Property OrderBy() As String
		Get
			Return _OrderBy
		End Get
		Set(ByVal value As String)
			_OrderBy = value
		End Set
	End Property
	Public Property IncludeDefault() As Boolean
		Get
			Return _IncludeDefault
		End Get
		Set(ByVal value As Boolean)
			_IncludeDefault = value
		End Set
	End Property
	Public Property DefaultText() As String
		Get
			Return _DefaultText
		End Get
		Set(ByVal value As String)
			_DefaultText = value
		End Set
	End Property
	Public Property DefaultValue() As String
		Get
			Return _DefaultValue
		End Get
		Set(ByVal value As String)
			_DefaultValue = value
		End Set
	End Property
	Protected Sub OdsDdladmITCallTypes_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles OdsDdladmITCallTypes.Selecting
		e.Arguments.SortExpression = _OrderBy
	End Sub
	Protected Sub DDLadmITCallTypes_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLadmITCallTypes.DataBinding
		If _IncludeDefault Then
			DDLadmITCallTypes.Items.Add(New ListItem(_DefaultText, _DefaultValue))
		End If
	End Sub
	Protected Sub DDLadmITCallTypes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLadmITCallTypes.SelectedIndexChanged
		RaiseEvent SelectedIndexChanged(sender, e)
	End Sub
End Class
