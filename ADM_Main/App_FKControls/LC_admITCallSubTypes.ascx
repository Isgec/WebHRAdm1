<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_admITCallSubTypes.ascx.vb" Inherits="LC_admITCallSubTypes" %>
<asp:DropDownList 
  ID = "DDLadmITCallSubTypes"
  DataSourceID = "OdsDdladmITCallSubTypes"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatoradmITCallSubTypes"
  Runat = "server" 
  ControlToValidate = "DDLadmITCallSubTypes"
  Text = "Sub Call Types is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSEadmITCallSubTypes"
  runat = "server"
  TargetControlID = "DDLadmITCallSubTypes"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdladmITCallSubTypes"
  TypeName = "SIS.ADM.admITCallSubTypes"
  SortParameterName = "OrderBy"
  SelectMethod = "admITCallSubTypesSelectList"
  Runat="server" />
