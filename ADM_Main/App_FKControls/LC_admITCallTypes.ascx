<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_admITCallTypes.ascx.vb" Inherits="LC_admITCallTypes" %>
<asp:DropDownList 
  ID = "DDLadmITCallTypes"
  DataSourceID = "OdsDdladmITCallTypes"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatoradmITCallTypes"
  Runat = "server" 
  ControlToValidate = "DDLadmITCallTypes"
  Text = "Call Types is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSEadmITCallTypes"
  runat = "server"
  TargetControlID = "DDLadmITCallTypes"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdladmITCallTypes"
  TypeName = "SIS.ADM.admITCallTypes"
  SortParameterName = "OrderBy"
  SelectMethod = "SelectList"
  Runat="server" />
