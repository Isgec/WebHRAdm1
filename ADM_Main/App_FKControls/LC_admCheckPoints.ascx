<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_admCheckPoints.ascx.vb" Inherits="LC_admCheckPoints" %>
<asp:DropDownList 
  ID = "DDLadmCheckPoints"
  DataSourceID = "OdsDdladmCheckPoints"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatoradmCheckPoints"
  Runat = "server" 
  ControlToValidate = "DDLadmCheckPoints"
  Text = "Check Points is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSEadmCheckPoints"
  runat = "server"
  TargetControlID = "DDLadmCheckPoints"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdladmCheckPoints"
  TypeName = "SIS.ADM.admCheckPoints"
  SortParameterName = "OrderBy"
  SelectMethod = "SelectList"
  Runat="server" />
