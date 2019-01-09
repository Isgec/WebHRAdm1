<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_admMonitors.aspx.vb" Inherits="AF_admMonitors" title="Add: Monitors" %>
<asp:Content ID="Content1" ContentPlaceHolderID=cph1 Runat="Server">
<div id="div1" class="page">
<asp:FormView ID="FormView1"
	runat = "server"
	DataKeyNames = "ServiceID,MonitorID"
	DataSourceID = "ObjectDataSource1"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
    <LGM:ToolBar0 
      ID = "ToolBar0_1"
      ToolType = "lgNMAdd"
      ValidationGroup = "admMonitors"
      runat = "server" />
    <hr />
    <asp:Label ID="LabeladmMonitors" runat="server" Text="Add Monitors" CssClass="sis_formheading"></asp:Label>
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
						ValidationGroup = "admMonitors"
            RequiredFieldErrorMessage = "Service is required."
            Runat="Server" />
          </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_MonitorID" ForeColor="#CC6633" runat="server" Text="Monitor :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_MonitorID"
						CssClass = "mypktxt"
            Width="56px"
						Text='<%# Bind("MonitorID") %>'
						AutoCompleteType = "None"
						onfocus = "return this.select();"
            ToolTip="Enter value for Monitor."
						ValidationGroup = "admMonitors"
            onblur= "validate_MonitorID(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_MonitorID_Display"
						Text='<%# Eval("FK_ADM_Monitors_HRM_Employees.DisplayField") %>'
						Runat="Server" />
					<asp:RequiredFieldValidator 
						ID = "RFVMonitorID"
						runat = "server"
						ControlToValidate = "F_MonitorID"
						Text = "Monitor is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "admMonitors"
						SetFocusOnError="true" />
          <AJX:AutoCompleteExtender
            ID="ACEMonitorID"
            BehaviorID="B_ACEMonitorID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="MonitorIDCompletionList"
            TargetControlID="F_MonitorID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEMonitorID_Selected"
            OnClientPopulating="ACEMonitorID_Populating"
            OnClientPopulated="ACEMonitorID_Populated"
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
  DataObjectTypeName = "SIS.ADM.admMonitors"
  InsertMethod="Insert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ADM.admMonitors"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</asp:Content>
