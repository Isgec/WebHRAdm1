<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_admInitiators.aspx.vb" Inherits="AF_admInitiators" title="Add: Initiators" %>
<asp:Content ID="Content1" ContentPlaceHolderID=cph1 Runat="Server">
<div id="div1" class="page">
<asp:FormView ID="FormView1"
	runat = "server"
	DataKeyNames = "ServiceID,InitiatorID"
	DataSourceID = "ObjectDataSource1"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMAdd"
      ValidationGroup = "admInitiators"
      runat = "server" />
    <hr />
    <asp:Label ID="LabeladmInitiators" runat="server" Text="Add Initiators" CssClass="sis_formheading"></asp:Label>
    <asp:Label ID="L_ErrMsg" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <hr />
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ServiceID" ForeColor="#CC6633" runat="server" Text="Service :" /></b>
				</td>
        <td>
          <LGM:LC_admServices
            ID="F_ServiceID"
            SelectedValue='<%# Bind("ServiceID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
						ValidationGroup = "admInitiators"
            RequiredFieldErrorMessage = "Service is required."
            Runat="Server" />
          </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_InitiatorID" ForeColor="#CC6633" runat="server" Text="Initiator :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_InitiatorID"
						CssClass = "mypktxt"
            Width="56px"
						Text='<%# Bind("InitiatorID") %>'
						AutoCompleteType = "None"
						onfocus = "return this.select();"
            ToolTip="Enter value for Initiator."
						ValidationGroup = "admInitiators"
            onblur= "validate_InitiatorID(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_InitiatorID_Display"
						Text='<%# Eval("FK_ADM_Initiators_HRM_Employees.DisplayField") %>'
						Runat="Server" />
					<asp:RequiredFieldValidator 
						ID = "RFVInitiatorID"
						runat = "server"
						ControlToValidate = "F_InitiatorID"
						Text = "Initiator is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "admInitiators"
						SetFocusOnError="true" />
          <AJX:AutoCompleteExtender
            ID="ACEInitiatorID"
            BehaviorID="B_ACEInitiatorID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="InitiatorIDCompletionList"
            TargetControlID="F_InitiatorID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEInitiatorID_Selected"
            OnClientPopulating="ACEInitiatorID_Populating"
            OnClientPopulated="ACEInitiatorID_Populated"
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
  DataObjectTypeName = "SIS.ADM.admInitiators"
  InsertMethod="Insert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ADM.admInitiators"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</asp:Content>
