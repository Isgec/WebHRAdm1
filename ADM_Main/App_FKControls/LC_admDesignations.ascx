<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_admDesignations.ascx.vb" Inherits="LC_admDesignations" %>
<asp:DropDownList 
  ID = "DDLadmDesignations"
  DataSourceID = "OdsDdladmDesignations"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatoradmDesignations"
  Runat = "server" 
  ControlToValidate = "DDLadmDesignations"
  Text = "Designations is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSEadmDesignations"
  runat = "server"
  TargetControlID = "DDLadmDesignations"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdladmDesignations"
  TypeName = "SIS.ADM.admDesignations"
  SortParameterName = "OrderBy"
  SelectMethod = "SelectList"
  Runat="server" />
