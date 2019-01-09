<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_admQualifications.ascx.vb" Inherits="LC_admQualifications" %>
<asp:DropDownList 
  ID = "DDLadmQualifications"
  DataSourceID = "OdsDdladmQualifications"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatoradmQualifications"
  Runat = "server" 
  ControlToValidate = "DDLadmQualifications"
  Text = "Qualifications is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSEadmQualifications"
  runat = "server"
  TargetControlID = "DDLadmQualifications"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdladmQualifications"
  TypeName = "SIS.ADM.admQualifications"
  SortParameterName = "OrderBy"
  SelectMethod = "SelectList"
  Runat="server" />
