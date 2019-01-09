<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_admSchedules.ascx.vb" Inherits="LC_admSchedules" %>
<asp:DropDownList 
  ID = "DDLadmSchedules"
  DataSourceID = "OdsDdladmSchedules"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatoradmSchedules"
  Runat = "server" 
  ControlToValidate = "DDLadmSchedules"
  Text = "Schedules is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSEadmSchedules"
  runat = "server"
  TargetControlID = "DDLadmSchedules"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdladmSchedules"
  TypeName = "SIS.ADM.admSchedules"
  SortParameterName = "OrderBy"
  SelectMethod = "SelectList"
  Runat="server" />
