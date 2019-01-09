<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_admEmployees.ascx.vb" Inherits="LC_admEmployees" %>
<asp:DropDownList 
  ID = "DDLadmEmployees"
  DataSourceID = "OdsDdladmEmployees"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatoradmEmployees"
  Runat = "server" 
  ControlToValidate = "DDLadmEmployees"
  Text = "Employees is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSEadmEmployees"
  runat = "server"
  TargetControlID = "DDLadmEmployees"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdladmEmployees"
  TypeName = "SIS.ADM.admEmployees"
  SortParameterName = "OrderBy"
  SelectMethod = "SelectList"
  Runat="server" />
