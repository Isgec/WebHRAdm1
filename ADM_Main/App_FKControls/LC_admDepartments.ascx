<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_admDepartments.ascx.vb" Inherits="LC_admDepartments" %>
<asp:DropDownList 
  ID = "DDLadmDepartments"
  DataSourceID = "OdsDdladmDepartments"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatoradmDepartments"
  Runat = "server" 
  ControlToValidate = "DDLadmDepartments"
  Text = "Departments is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSEadmDepartments"
  runat = "server"
  TargetControlID = "DDLadmDepartments"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdladmDepartments"
  TypeName = "SIS.ADM.admDepartments"
  SortParameterName = "OrderBy"
  SelectMethod = "SelectList"
  Runat="server" />
