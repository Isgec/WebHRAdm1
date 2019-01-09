<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_admEMailGroups.ascx.vb" Inherits="LC_admEMailGroups" %>
<asp:DropDownList 
  ID = "DDLadmEMailGroups"
  DataSourceID = "OdsDdladmEMailGroups"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatoradmEMailGroups"
  Runat = "server" 
  ControlToValidate = "DDLadmEMailGroups"
  Text = "EMailGroups is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSEadmEMailGroups"
  runat = "server"
  TargetControlID = "DDLadmEMailGroups"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdladmEMailGroups"
  TypeName = "SIS.ADM.admEMailGroups"
  SortParameterName = "OrderBy"
  SelectMethod = "SelectList"
  Runat="server" />
