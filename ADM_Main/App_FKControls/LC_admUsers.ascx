<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_admUsers.ascx.vb" Inherits="LC_admUsers" %>
<asp:DropDownList 
  ID = "DDLadmUsers"
  DataSourceID = "OdsDdladmUsers"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatoradmUsers"
  Runat = "server" 
  ControlToValidate = "DDLadmUsers"
  Text = "Web Users is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSEadmUsers"
  runat = "server"
  TargetControlID = "DDLadmUsers"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdladmUsers"
  TypeName = "SIS.ADM.admUsers"
  SortParameterName = "OrderBy"
  SelectMethod = "SelectList"
  Runat="server" />
