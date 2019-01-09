<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_admOffices.ascx.vb" Inherits="LC_admOffices" %>
<asp:DropDownList 
  ID = "DDLadmOffices"
  DataSourceID = "OdsDdladmOffices"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatoradmOffices"
  Runat = "server" 
  ControlToValidate = "DDLadmOffices"
  Text = "Office is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSEadmOffices"
  runat = "server"
  TargetControlID = "DDLadmOffices"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdladmOffices"
  TypeName = "SIS.ADM.admOffices"
  SortParameterName = "OrderBy"
  SelectMethod = "SelectList"
  Runat="server" />
