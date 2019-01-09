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
Partial Class LC_admMeasures
  Inherits System.Web.UI.UserControl
  Private _OrderBy As String = String.Empty
  Private _IncludeDefault As Boolean = True
  Private _DefaultText As String = "-- Select --"
  Private _DefaultValue As String = String.Empty
  Public Event SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
  Public Property AddAttributes() As String
    Get
      Return DDLadmMeasures.ToString
    End Get
    Set(ByVal value As String)
			Try
				Dim aVal() As String = value.Split(",".ToCharArray)
				DDLadmMeasures.Attributes.Add(aVal(0), aVal(1))
			Catch ex As Exception
			End Try
    End Set
  End Property
  Public Property CssClass() As String
    Get
      Return DDLadmMeasures.CssClass
    End Get
    Set(ByVal value As String)
      DDLadmMeasures.CssClass = value
    End Set
  End Property
  Public Property Width() As System.Web.UI.WebControls.Unit
    Get
      Return DDLadmMeasures.Width
    End Get
    Set(ByVal value As System.Web.UI.WebControls.Unit)
      DDLadmMeasures.Width = value
    End Set
  End Property
  Public Property RequiredFieldErrorMessage() As String
    Get
      Return RequiredFieldValidatoradmMeasures.Text
    End Get
    Set(ByVal value As String)
      RequiredFieldValidatoradmMeasures.Text = value
    End Set
  End Property
  Public Property ValidationGroup() As String
    Get
      Return RequiredFieldValidatoradmMeasures.ValidationGroup
    End Get
    Set(ByVal value As String)
      RequiredFieldValidatoradmMeasures.ValidationGroup = value
    End Set
  End Property
  Public Property Enabled() As Boolean
    Get
      Return DDLadmMeasures.Enabled
    End Get
    Set(ByVal value As Boolean)
      DDLadmMeasures.Enabled = value
    End Set
  End Property
  Public Property AutoPostBack() As Boolean
    Get
      Return DDLadmMeasures.AutoPostBack
    End Get
    Set(ByVal value As Boolean)
      DDLadmMeasures.AutoPostBack = value
    End Set
  End Property
  Public Property DataTextField() As String
    Get
      Return DDLadmMeasures.DataTextField
    End Get
    Set(ByVal value As String)
      DDLadmMeasures.DataTextField = value
    End Set
  End Property
  Public Property DataValueField() As String
    Get
      Return DDLadmMeasures.DataValueField
    End Get
    Set(ByVal value As String)
      DDLadmMeasures.DataValueField = value
    End Set
  End Property
  Public Property SelectedValue() As String
    Get
      Return DDLadmMeasures.SelectedValue
    End Get
    Set(ByVal value As String)
      If Convert.IsDBNull(value) Then
        DDLadmMeasures.SelectedValue = String.Empty
      Else
        DDLadmMeasures.SelectedValue = value
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
  Protected Sub OdsDdladmMeasures_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles OdsDdladmMeasures.Selecting
    e.Arguments.SortExpression = _OrderBy
  End Sub
  Protected Sub DDLadmMeasures_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLadmMeasures.DataBinding
    If _IncludeDefault Then
      DDLadmMeasures.Items.Add(new ListItem(_DefaultText, _DefaultValue))
    End If
  End Sub
  Protected Sub DDLadmMeasures_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLadmMeasures.SelectedIndexChanged
    RaiseEvent SelectedIndexChanged(sender, e)
  End Sub
End Class
