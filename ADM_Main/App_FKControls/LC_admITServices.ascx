<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_admITServices.ascx.vb" Inherits="LC_admITServices" %>
<asp:DropDownList 
  ID = "DDLadmITServices"
  DataSourceID = "OdsDdladmITServices"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatoradmITServices"
  Runat = "server" 
  ControlToValidate = "DDLadmITServices"
  Text = "IT Services is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSEadmITServices"
  runat = "server"
  TargetControlID = "DDLadmITServices"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdladmITServices"
  TypeName = "SIS.ADM.admITServices"
  SortParameterName = "OrderBy"
  SelectMethod = "SelectList"
  Runat="server" />
