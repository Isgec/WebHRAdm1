<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_admEmployeeEMailGroup.aspx.vb" Inherits="AF_admEmployeeEMailGroup" title="Add: Employee EMail Group" %>
<asp:Content ID="Content1" ContentPlaceHolderID=cph1 Runat="Server">
<div id="div1" class="page">
<asp:FormView ID="FormView1"
	runat = "server"
	DataKeyNames = "CardNo,EMailGroup"
	DataSourceID = "ObjectDataSource1"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMAdd"
      ValidationGroup = "admEmployeeEMailGroup"
      runat = "server" />
    <hr />
    <asp:Label ID="LabeladmEmployeeEMailGroup" runat="server" Text="Add Employee EMail Group" CssClass="sis_formheading"></asp:Label>
    <asp:Label ID="L_ErrMsg" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <hr />
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_CardNo" ForeColor="#CC6633" runat="server" Text="CardNo :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_CardNo"
						CssClass = "mypktxt"
            Width="56px"
						Text='<%# Bind("CardNo") %>'
						AutoCompleteType = "None"
						onfocus = "return this.select();"
            ToolTip="Enter value for CardNo."
						ValidationGroup = "admEmployeeEMailGroup"
            onblur= "validate_CardNo(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_CardNo_Display"
						Text='<%# Eval("FK_HRM_EmployeeEMailGroup_HRM_Employees.DisplayField") %>'
						Runat="Server" />
					<asp:RequiredFieldValidator 
						ID = "RFVCardNo"
						runat = "server"
						ControlToValidate = "F_CardNo"
						Text = "CardNo is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "admEmployeeEMailGroup"
						SetFocusOnError="true" />
          <AJX:AutoCompleteExtender
            ID="ACECardNo"
            BehaviorID="B_ACECardNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="CardNoCompletionList"
            TargetControlID="F_CardNo"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACECardNo_Selected"
            OnClientPopulating="ACECardNo_Populating"
            OnClientPopulated="ACECardNo_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_EMailGroup" ForeColor="#CC6633" runat="server" Text="EMailGroup :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_EMailGroup"
						CssClass = "mypktxt"
            Width="350px"
						Text='<%# Bind("EMailGroup") %>'
						AutoCompleteType = "None"
						onfocus = "return this.select();"
            ToolTip="Enter value for EMailGroup."
						ValidationGroup = "admEmployeeEMailGroup"
            onblur= "validate_EMailGroup(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_EMailGroup_Display"
						Text='<%# Eval("FK_HRM_EmployeeEMailGroup_HRM_EMailGroups.DisplayField") %>'
						Runat="Server" />
					<asp:RequiredFieldValidator 
						ID = "RFVEMailGroup"
						runat = "server"
						ControlToValidate = "F_EMailGroup"
						Text = "EMailGroup is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "admEmployeeEMailGroup"
						SetFocusOnError="true" />
          <AJX:AutoCompleteExtender
            ID="ACEEMailGroup"
            BehaviorID="B_ACEEMailGroup"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="EMailGroupCompletionList"
            TargetControlID="F_EMailGroup"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEEMailGroup_Selected"
            OnClientPopulating="ACEEMailGroup_Populating"
            OnClientPopulated="ACEEMailGroup_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
			</tr>
		</table>
	</InsertItemTemplate>
</asp:FormView>
<asp:ObjectDataSource 
  ID = "ObjectDataSource1"
  DataObjectTypeName = "SIS.ADM.admEmployeeEMailGroup"
  InsertMethod="Insert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ADM.admEmployeeEMailGroup"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</asp:Content>
