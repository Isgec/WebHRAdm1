<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_admMeasures.ascx.vb" Inherits="LC_admMeasures" %>
<asp:DropDownList 
  ID = "DDLadmMeasures"
  DataSourceID = "OdsDdladmMeasures"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatoradmMeasures"
  Runat = "server" 
  ControlToValidate = "DDLadmMeasures"
  Text = "Measures and Monitoring Mechanism is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSEadmMeasures"
  runat = "server"
  TargetControlID = "DDLadmMeasures"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdladmMeasures"
  TypeName = "SIS.ADM.admMeasures"
  SortParameterName = "OrderBy"
  SelectMethod = "SelectList"
  Runat="server" />
