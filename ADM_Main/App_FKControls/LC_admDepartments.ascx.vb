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
Partial Class LC_admDepartments
  Inherits System.Web.UI.UserControl
  Private _OrderBy As String = String.Empty
  Private _IncludeDefault As Boolean = True
  Private _DefaultText As String = "-- Select --"
  Private _DefaultValue As String = String.Empty
  Public Event SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
  Public Property AddAttributes() As String
    Get
      Return DDLadmDepartments.ToString
    End Get
    Set(ByVal value As String)
			Try
				Dim aVal() As String = value.Split(",".ToCharArray)
				DDLadmDepartments.Attributes.Add(aVal(0), aVal(1))
			Catch ex As Exception
			End Try
    End Set
  End Property
  Public Property CssClass() As String
    Get
      Return DDLadmDepartments.CssClass
    End Get
    Set(ByVal value As String)
      DDLadmDepartments.CssClass = value
    End Set
  End Property
  Public Property Width() As System.Web.UI.WebControls.Unit
    Get
      Return DDLadmDepartments.Width
    End Get
    Set(ByVal value As System.Web.UI.WebControls.Unit)
      DDLadmDepartments.Width = value
    End Set
  End Property
  Public Property RequiredFieldErrorMessage() As String
    Get
      Return RequiredFieldValidatoradmDepartments.Text
    End Get
    Set(ByVal value As String)
      RequiredFieldValidatoradmDepartments.Text = value
    End Set
  End Property
  Public Property ValidationGroup() As String
    Get
      Return RequiredFieldValidatoradmDepartments.ValidationGroup
    End Get
    Set(ByVal value As String)
      RequiredFieldValidatoradmDepartments.ValidationGroup = value
    End Set
  End Property
  Public Property Enabled() As Boolean
    Get
      Return DDLadmDepartments.Enabled
    End Get
    Set(ByVal value As Boolean)
      DDLadmDepartments.Enabled = value
    End Set
  End Property
  Public Property AutoPostBack() As Boolean
    Get
      Return DDLadmDepartments.AutoPostBack
    End Get
    Set(ByVal value As Boolean)
      DDLadmDepartments.AutoPostBack = value
    End Set
  End Property
  Public Property DataTextField() As String
    Get
      Return DDLadmDepartments.DataTextField
    End Get
    Set(ByVal value As String)
      DDLadmDepartments.DataTextField = value
    End Set
  End Property
  Public Property DataValueField() As String
    Get
      Return DDLadmDepartments.DataValueField
    End Get
    Set(ByVal value As String)
      DDLadmDepartments.DataValueField = value
    End Set
  End Property
  Public Property SelectedValue() As String
    Get
      Return DDLadmDepartments.SelectedValue
    End Get
    Set(ByVal value As String)
      If Convert.IsDBNull(value) Then
        DDLadmDepartments.SelectedValue = String.Empty
      Else
        DDLadmDepartments.SelectedValue = value
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
  Protected Sub OdsDdladmDepartments_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles OdsDdladmDepartments.Selecting
    e.Arguments.SortExpression = _OrderBy
  End Sub
  Protected Sub DDLadmDepartments_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLadmDepartments.DataBinding
    If _IncludeDefault Then
      DDLadmDepartments.Items.Add(new ListItem(_DefaultText, _DefaultValue))
    End If
  End Sub
  Protected Sub DDLadmDepartments_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLadmDepartments.SelectedIndexChanged
    RaiseEvent SelectedIndexChanged(sender, e)
  End Sub
End Class
