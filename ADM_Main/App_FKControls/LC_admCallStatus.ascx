<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_admCallStatus.ascx.vb" Inherits="LC_admCallStatus" %>
<asp:DropDownList 
  ID = "DDLadmCallStatus"
  DataSourceID = "OdsDdladmCallStatus"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatoradmCallStatus"
  Runat = "server" 
  ControlToValidate = "DDLadmCallStatus"
  Text = "Call Status is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSEadmCallStatus"
  runat = "server"
  TargetControlID = "DDLadmCallStatus"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdladmCallStatus"
  TypeName = "SIS.ADM.admCallStatus"
  SortParameterName = "OrderBy"
  SelectMethod = "SelectList"
  Runat="server" />
