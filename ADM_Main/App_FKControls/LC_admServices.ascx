<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_admServices.ascx.vb" Inherits="LC_admServices" %>
<asp:DropDownList 
  ID = "DDLadmServices"
  DataSourceID = "OdsDdladmServices"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatoradmServices"
  Runat = "server" 
  ControlToValidate = "DDLadmServices"
  Text = "Administrative Services is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSEadmServices"
  runat = "server"
  TargetControlID = "DDLadmServices"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdladmServices"
  TypeName = "SIS.ADM.admServices"
  SortParameterName = "OrderBy"
  SelectMethod = "SelectList"
  Runat="server" />
