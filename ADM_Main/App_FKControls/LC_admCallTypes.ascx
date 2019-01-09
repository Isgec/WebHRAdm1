<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_admCallTypes.ascx.vb" Inherits="LC_admCallTypes" %>
<asp:DropDownList 
  ID = "DDLadmCallTypes"
  DataSourceID = "OdsDdladmCallTypes"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatoradmCallTypes"
  Runat = "server" 
  ControlToValidate = "DDLadmCallTypes"
  Text = "Call Types is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSEadmCallTypes"
  runat = "server"
  TargetControlID = "DDLadmCallTypes"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdladmCallTypes"
  TypeName = "SIS.ADM.admCallTypes"
  SortParameterName = "OrderBy"
  SelectMethod = "SelectList"
  Runat="server" />
