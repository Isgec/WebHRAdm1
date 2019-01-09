<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_admITCallStatus.ascx.vb" Inherits="LC_admITCallStatus" %>
<asp:DropDownList 
  ID = "DDLadmITCallStatus"
  DataSourceID = "OdsDdladmITCallStatus"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatoradmITCallStatus"
  Runat = "server" 
  ControlToValidate = "DDLadmITCallStatus"
  Text = "Call Status is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSEadmITCallStatus"
  runat = "server"
  TargetControlID = "DDLadmITCallStatus"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdladmITCallStatus"
  TypeName = "SIS.ADM.admITCallStatus"
  SortParameterName = "OrderBy"
  SelectMethod = "SelectList"
  Runat="server" />
