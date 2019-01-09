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
Partial Class LC_admITCallStatus
  Inherits System.Web.UI.UserControl
  Private _OrderBy As String = String.Empty
  Private _IncludeDefault As Boolean = True
  Private _DefaultText As String = "-- Select --"
  Private _DefaultValue As String = String.Empty
	Public Event SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
	Public ReadOnly Property LCClientID() As String
		Get
			Return DDLadmITCallStatus.ClientID
		End Get
	End Property

  Public Property AddAttributes() As String
    Get
			Return DDLadmITCallStatus.Attributes.ToString
    End Get
    Set(ByVal value As String)
			Try
				Dim aVal() As String = value.Split(",".ToCharArray)
				DDLadmITCallStatus.Attributes.Add(aVal(0), aVal(1))
			Catch ex As Exception
			End Try
    End Set
  End Property
  Public Property CssClass() As String
    Get
      Return DDLadmITCallStatus.CssClass
    End Get
    Set(ByVal value As String)
      DDLadmITCallStatus.CssClass = value
    End Set
  End Property
  Public Property Width() As System.Web.UI.WebControls.Unit
    Get
      Return DDLadmITCallStatus.Width
    End Get
    Set(ByVal value As System.Web.UI.WebControls.Unit)
      DDLadmITCallStatus.Width = value
    End Set
  End Property
  Public Property RequiredFieldErrorMessage() As String
    Get
      Return RequiredFieldValidatoradmITCallStatus.Text
    End Get
    Set(ByVal value As String)
      RequiredFieldValidatoradmITCallStatus.Text = value
    End Set
  End Property
  Public Property ValidationGroup() As String
    Get
      Return RequiredFieldValidatoradmITCallStatus.ValidationGroup
    End Get
    Set(ByVal value As String)
      RequiredFieldValidatoradmITCallStatus.ValidationGroup = value
    End Set
  End Property
  Public Property Enabled() As Boolean
    Get
      Return DDLadmITCallStatus.Enabled
    End Get
    Set(ByVal value As Boolean)
      DDLadmITCallStatus.Enabled = value
    End Set
  End Property
  Public Property AutoPostBack() As Boolean
    Get
      Return DDLadmITCallStatus.AutoPostBack
    End Get
    Set(ByVal value As Boolean)
      DDLadmITCallStatus.AutoPostBack = value
    End Set
  End Property
  Public Property DataTextField() As String
    Get
      Return DDLadmITCallStatus.DataTextField
    End Get
    Set(ByVal value As String)
      DDLadmITCallStatus.DataTextField = value
    End Set
  End Property
  Public Property DataValueField() As String
    Get
      Return DDLadmITCallStatus.DataValueField
    End Get
    Set(ByVal value As String)
      DDLadmITCallStatus.DataValueField = value
    End Set
  End Property
  Public Property SelectedValue() As String
    Get
      Return DDLadmITCallStatus.SelectedValue
    End Get
    Set(ByVal value As String)
      If Convert.IsDBNull(value) Then
        DDLadmITCallStatus.SelectedValue = String.Empty
      Else
        DDLadmITCallStatus.SelectedValue = value
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
  Protected Sub OdsDdladmITCallStatus_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles OdsDdladmITCallStatus.Selecting
    e.Arguments.SortExpression = _OrderBy
  End Sub
  Protected Sub DDLadmITCallStatus_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLadmITCallStatus.DataBinding
    If _IncludeDefault Then
      DDLadmITCallStatus.Items.Add(new ListItem(_DefaultText, _DefaultValue))
		End If
		'Custom Status
		DDLadmITCallStatus.Items.Add(New ListItem("NOT Closed", "NOTCLOSED"))
	End Sub
  Protected Sub DDLadmITCallStatus_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLadmITCallStatus.SelectedIndexChanged
    RaiseEvent SelectedIndexChanged(sender, e)
  End Sub
End Class
