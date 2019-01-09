<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_admITEventTransactions.ascx.vb" Inherits="LC_admITEventTransactions" %>
<asp:DropDownList 
  ID = "DDLadmITEventTransactions"
  DataSourceID = "OdsDdladmITEventTransactions"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatoradmITEventTransactions"
  Runat = "server" 
  ControlToValidate = "DDLadmITEventTransactions"
  Text = "IT Event Transactions is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSEadmITEventTransactions"
  runat = "server"
  TargetControlID = "DDLadmITEventTransactions"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdladmITEventTransactions"
  TypeName = "SIS.ADM.admITEventTransactions"
  SortParameterName = "OrderBy"
  SelectMethod = "SelectList"
  Runat="server" />
